using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gunggme
{
    public class Player : MonoBehaviour
    {
        private Animator _animator;

        private string[] _animNames;
        [SerializeField] private GameObject[] _colls;
        private SpriteRenderer _spriteRenderer;
        private GameManager _gameManager;
        
        private void Start()
        {
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }

        /// <summary>
        /// 막을 위치
        /// </summary>
        /// <param name="n"></param>
        public void DirectionButton(int n)
        {
            //_animator.SetTrigger(_animNames[n]);
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
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Enemy"))
            {
                // todo 게임오버 처리
                Debug.Log("게임 오버");
                _gameManager.GameOver();
            }
        }
    }
}
