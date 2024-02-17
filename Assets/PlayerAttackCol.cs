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
            if (other.TryGetComponent(out Item item))
            {
                if (item.CollisionPlayerAttack())
                {
                }
                item.ShootingEffect();
                gameObject.SetActive(false);//팔 내리기
                _player.OffAttack();
            }
        }
    }
}
