using System;
using System.Collections;
using System.Collections.Generic;
using gunggme;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField]private Transform spawnTransform;
    
    public void Spawn()
    {
        GameObject temp = PoolManager.Instance.Get(0);
        temp.transform.position = spawnTransform.localPosition;
        
    }
    
}
