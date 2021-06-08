using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScript
{
    private GameObject player;
    private GameObject game;

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
        Assert.AreEqual(x1, player.gameObject.transform.position.x);
    }
}
