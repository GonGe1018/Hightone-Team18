using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        [SerializeField] private float handTime;

        [SerializeField] private TMP_Text[] effectTexts;
        
        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();

            foreach (var coll in _colls)
            {
                coll.SetActive(false);
            }
        }


        private void Update()
        {
            
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.A))
            {
                DirectionButton(0);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                DirectionButton(1);
            }
#endif
            if (handTime > 0)
            {
                handTime -= Time.deltaTime;
            }
        }


        /// <summary>
        /// 막을 위치
        /// </summary>
        /// <param name="n"></param>
        public void DirectionButton(int n)
        {
            if (handTime > 0)
            {
                //handTime -= Time.deltaTime;
                return;
            }
            //_animator.SetTrigger(_animNames[n]);
            _spriteRenderer.sprite = _sprites[n];
            SetCool(0.3f);
            CollDirection(n);
        }

        public void CollDirection(int n)
        {
            for (int i = 0; i < _colls.Length; i++)
            {
                _colls[i].SetActive(i == n);
            }
        }

        public void SetCool(float time)
        {
            handTime = time;
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
                if (item.CollisionPlayerAttack())//아이템의 타입이 패널티일 때
                {
                    SoundManager.Instance.PrintVFX(SoundManager.Instance.vfxAudioClips[1]);
                    if (isInvincible)
                    {
                        isInvincible = false;
                        effectTexts[1].gameObject.SetActive(false);
                        other.gameObject.SetActive(false);
                    }
                    else
                    {
                        _gameManager.GameOver();
                        other.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                    }

                    
                }
                else// 혜택일 때
                {
                    SoundManager.Instance.PrintVFX(SoundManager.Instance.vfxAudioClips[0]);
                    // todo 
                    switch (item.ItemCategori)
                    {
                        case 0:
                            // 속도 느리게
                            try
                            {
                                StartCoroutine(SpawnManager.Instance.SlowSpeed(3f, 1, effectTexts[0]));
                            }
                            catch
                            { }
                            break;
                        case 1:
                            //1회 무적
                            isInvincible = true;
                            effectTexts[1].gameObject.SetActive(true);
                            break;
                        case 2:
                            // 기록 시간 추가
                            Debug.Log("");
                            _gameManager.SetTime(20, effectTexts[2].gameObject);
                            break;
                    }
                }
                other.gameObject.SetActive(false);
            }
        }
        
        
    }
}
