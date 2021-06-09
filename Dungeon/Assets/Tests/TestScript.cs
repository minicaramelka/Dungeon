using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScript
{
    public GameObject player;
    public GameObject game;

    [SetUp]
    public void SetUp()
    {
        game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        player = GameObject.Find("player_0");
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(game);
        Object.Destroy(GameObject.Find("Rooms(Clone)"));
    }

    [UnityTest]
    public IEnumerator WallCollideTest()
    {
        Vector3 playerPos = player.transform.position;
        playerPos.x += 1;
        GameObject wall =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/wall_0"), playerPos, Quaternion.identity);
        player.GetComponent<Player>().runRight();
        yield return new WaitForSeconds(2f);
        float x1 = player.gameObject.transform.position.x;
        yield return new WaitForSeconds(2f);
        Object.Destroy(wall);
        Assert.AreEqual(x1, player.gameObject.transform.position.x);
    }

    [UnityTest]
    public IEnumerator EnemyCollisionTest()
    {
        int HP = player.GetComponent<PlayerHealth>().health;
        Vector3 playerPos = player.transform.position;
        GameObject mob =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/mob_0"), playerPos, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        int NowHP = player.GetComponent<PlayerHealth>().health;
        Object.Destroy(mob);
        Assert.Greater(HP, player.GetComponent<PlayerHealth>().health);
        
    }

    [UnityTest]
    public IEnumerator AttackCollisionTest()
    {
        Vector3 playerPos = player.transform.position;
        playerPos.x += 0.05f;
        GameObject mob =
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/mob_0"), playerPos, Quaternion.identity);
        int HP = mob.GetComponent<Enemy>().health;
        Debug.Log(HP);
        player.GetComponent<PlayerAttack>().Attack();
        yield return new WaitForSeconds(3f);
        int HP1 = mob.GetComponent<Enemy>().health;
        Debug.Log(HP1);
        Object.Destroy(mob);
        Assert.Greater(HP, HP1);
    }
}
