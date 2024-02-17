using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateTrack : MonoBehaviour
{
    [SerializeField] private TrackManager _trackManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Track"))
        {
            other.gameObject.SetActive(false);
            _trackManager.Spawn();
        }
    }
}
