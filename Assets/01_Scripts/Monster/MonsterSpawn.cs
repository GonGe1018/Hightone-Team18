using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using gunggme;
using UnityEditor;
using Random = UnityEngine.Random;


public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField] private BoxCollider coll;

    private void Start()
    {
        Excute();
    }

    void Excute()
    {
        for (int i = 0; i < 10; i++)
        {
            float x = coll.bounds.max.x;
            float z = coll.bounds.max.z;

            Vector3 vec = new Vector3(Random.Range(-x, x), 0, /*Random.Range(-z, z)*/0);
            Debug.Log(1);
            GameObject temp = PoolManager.Instance.Get(1);
            temp.transform.position = vec;
        }
    }
}
