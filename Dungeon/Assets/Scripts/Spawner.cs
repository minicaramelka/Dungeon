using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objects;
    private void Start()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/Mobs"));
        int rand = Random.Range(0, objects.Length);
        GameObject instance = (GameObject)Instantiate(objects[rand], transform.position, Quaternion.identity, GameObject.Find("Mobs").transform);
        instance.transform.parent = transform;
    }
}
