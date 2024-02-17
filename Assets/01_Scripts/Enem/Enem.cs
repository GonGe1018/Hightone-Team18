using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gunggme
{
    public class Enem : MonoBehaviour
    {
        [SerializeField] public float _speed;
        
        private void Update()
        {
            var transform1 = transform;
            // 기본적으로 왼쪽으로 이동
            transform1.position += -transform1.right * (_speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PlayerAttack"))
            {
                Debug.Log("부딛힘");
                gameObject.SetActive(false);
            }
        }
    }
}
