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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("부딛힘2");
                gameObject.SetActive(false);
                _player.OffAttack();
            }
        }
    }
}
