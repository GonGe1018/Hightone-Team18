using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gunggme
{
    public class PlayerAttackCol : MonoBehaviour
    {
        private Player _player;

        private void Start()
        {
            _player = GetComponentInParent<Player>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                gameObject.SetActive(false);
                _player.OffAttack();
            }
        }
    }
}
