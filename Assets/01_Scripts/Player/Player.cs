using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gunggme
{
    public class Player : MonoBehaviour
    {
        public bool isInvincible = false;
            
        private Animator _animator;

        private string[] _animNames;
        [SerializeField] private GameObject[] _colls;

        [Header("Player_Sprite")] 
        [SerializeField] private Sprite[] _sprites;
        
        private SpriteRenderer _spriteRenderer;
        private GameManager _gameManager;
        
        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                DirectionButton(0);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                DirectionButton(1);
            }
        }
#endif

        /// <summary>
        /// 막을 위치
        /// </summary>
        /// <param name="n"></param>
        public void DirectionButton(int n)
        {
            //_animator.SetTrigger(_animNames[n]);
            _spriteRenderer.sprite = _sprites[n];
            CollDirection(n);
        }

        public void CollDirection(int n)
        {
            for (int i = 0; i < _colls.Length; i++)
            {
                _colls[i].SetActive(i == n);
            }
        }

        public void OffAttack()
        {
            //todo 상태 초기화
            _spriteRenderer.sprite = _sprites[2];
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Item") && other.transform.TryGetComponent(out Item item))
            {
                // todo 게임오버 처리
                Debug.Log("게임 오버");
                
                if (item.CollisionPlayerAttack())
                {
                    if (isInvincible)
                    {
                        return;
                    }

                    gameObject.SetActive(false);
                    _gameManager.GameOver();
                }
                else
                {
                    // todo 
                    switch (item.ItemCategori)
                    {
                        case 0:
                            // 속도 느리게
                            StartCoroutine(SpawnManager.Instance.SlowSpeed(10f, 1));
                            break;
                        case 1:
                            //1회 무적
                            if (!isInvincible)
                            {
                                isInvincible = true;
                            }
                            break;
                        case 2:
                            // 기록 시간 추가
                            _gameManager.SetTime(20);
                            break;
                    }
                }
            }
        }
    }
}
