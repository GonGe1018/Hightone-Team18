using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gunggme
{
    public class Enem : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private void Update()
        {
            var transform1 = transform;
            // 기본적으로 왼쪽으로 이동
            transform1.position += -transform1.right * (_speed * Time.deltaTime);
        }
    }
}
