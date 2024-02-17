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
        
        private void Start()
        {
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
    }
}
