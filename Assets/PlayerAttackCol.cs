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

        private void OnEnable()
        {
            Invoke(nameof(Deactivate), 0.1f);
        }

        void Deactivate()
        {
            _player.SetCool(0.1f);
            gameObject.SetActive(false);//팔 내리기
            _player.OffAttack();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Item item))
            {
                if (item.CollisionPlayerAttack())
                {
                }

                item.ShootingEffect();
                SoundManager.Instance.PrintVFX(SoundManager.Instance.vfxAudioClips[2]);
                gameObject.SetActive(false);
                _player.OffAttack();
            }
            
            
        }
    }
}
