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
        int HP = player.GetComponent<Health>().health;
        Debug.Log(HP);
        Vector3 playerPos = player.transform.position;
        GameObject mob =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/mob_0"), playerPos, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        int NowHP = player.GetComponent<Health>().health;
        Debug.Log(NowHP);
        Object.Destroy(mob);
        Assert.Greater(HP, player.GetComponent<Health>().health);
        
    }
}
