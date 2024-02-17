using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace gunggme
{
    public class SpawnManager : Singelton<SpawnManager>
    {
        [SerializeField] private Transform[] _spawnTransforms;

        [Header("Spawn Time")] 
        [SerializeField] private float _curSpawnTime;
        [SerializeField] private float _maxSpawnTime;
        [SerializeField] public int _speed { get; set; }

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
                if (ranSpawn == 1)//한쪽에서만
                {
                    SpawnItem(-1);
                }
                else if(ranSpawn == 2)
                {
                    SpawnItem(0);
                    SpawnItem(1);
                }

                _curSpawnTime = _maxSpawnTime;
            }
        }
        

        void SpawnItem(int n)
        {
            
            GameObject temp = PoolManager.Instance.Get(0);
            
            
            Item tempItem = temp.GetComponent<Item>();
            
            if (n == -1)//랜덤
            {
                int ranIndex = Random.Range(0, _spawnTransforms.Length);
                temp.transform.position = _spawnTransforms[ranIndex].position;
                int moveDir = ranIndex == 0 ? -1 : 1;
                tempItem.speed =  Mathf.Abs(tempItem.speed) * moveDir * (1 + _gameManager.AliveTime * _speed * 0.01f);
            }
            else if (n == 0)
            {
                temp.transform.position = _spawnTransforms[n].position;
                tempItem.speed =  Mathf.Abs(tempItem.speed) * -1 * (1 + _gameManager.AliveTime * _speed * 0.01f);
            }
            else if(n == 1)
            {
                temp.transform.position = _spawnTransforms[n].position;
                tempItem.speed = Mathf.Abs(tempItem.speed) * (1 + _gameManager.AliveTime * _speed * 0.01f);
            }
        }

        public IEnumerator SlowSpeed(float time, int speed)
        {
            int temp = _speed;
            _speed = temp;
            yield return new WaitForSeconds(time);

            _speed = temp;
        }
    }
}
