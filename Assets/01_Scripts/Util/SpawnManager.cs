using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace gunggme
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnTransforms;

        [Header("Spawn Time")] 
        [SerializeField] private float _curSpawnTime;
        [SerializeField] private float _maxSpawnTime;
        [SerializeField] private float _speed;

        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>(); 
            Debug.Log(_gameManager);
        }

        private void Update()
        {
            if (_gameManager._isAlive)
            {
                SpawnTimer();
            }
        }

        void SpawnTimer()
        {
            if (_curSpawnTime > 0)
            {
                _curSpawnTime -= Time.deltaTime;
            }
            else
            {
                int ranSpawn = Random.Range(1, 3);
                if (ranSpawn == 1)
                {
                    SpawnEnem();
                }
                else if(ranSpawn == 2)
                {
                    SpawnEnem(0);
                    SpawnEnem(1);
                }

                _curSpawnTime = _maxSpawnTime;
            }
        }
        
        void SpawnEnem()
        {
            int ranIndex = Random.Range(0, _spawnTransforms.Length);

            GameObject temp = PoolManager.Instance.Get(0);
            temp.transform.position = _spawnTransforms[ranIndex].position;
            Enem tempEnem = temp.GetComponent<Enem>();
            if (ranIndex == 0)
            {
                tempEnem._speed = Mathf.Abs(tempEnem._speed ) * -1 * (1 + _gameManager.AliveTime * _speed);
            }
            else
            {
                tempEnem._speed = Mathf.Abs(tempEnem._speed) * (1 + _gameManager.AliveTime * _speed);
            }
        }
        
        void SpawnEnem(int n)
        {
            GameObject temp = PoolManager.Instance.Get(0);
            temp.transform.position = _spawnTransforms[n].position;
            
            Enem tempEnem = temp.GetComponent<Enem>();
            if (n == 0)
            {
                tempEnem._speed =  Mathf.Abs(tempEnem._speed) * -1 * (1 + _gameManager.AliveTime * _speed);
            }
            else
            {
                tempEnem._speed = Mathf.Abs(tempEnem._speed) * (1 + _gameManager.AliveTime * _speed);
            }
        }
    }
}
