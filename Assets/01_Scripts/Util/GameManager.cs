using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace gunggme
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] public bool _isAlive = true;
        public bool IsAlive => _isAlive;

        [SerializeField] private float _aliveTime;
        public float AliveTime => _aliveTime;
        [SerializeField] private TMP_Text _timeText;
        
        private void Update()
        {
            if (_isAlive)
            {
                _aliveTime += Time.deltaTime;
                _timeText.text = TimeSpan.FromSeconds(_aliveTime).ToString(@"mm\:ss");
            }
        }

        public void SetTime(float time)
        {
            Debug.Log($"시간 재설정 전 :{_aliveTime}");
            _aliveTime += time;
            _timeText.text = TimeSpan.FromSeconds(_aliveTime).ToString(@"mm\:ss");
            Debug.Log($"시간 재설정 후 :{_aliveTime}");
        }

        string GetTimer()
        {
            int temp = (int)Math.Ceiling(_aliveTime);
            return temp.ToString();
        }
        
        string SetTimeString()
        {
            int temp = (int)Math.Ceiling(_aliveTime);
            return temp.ToString();
        }
        

        public void GameOver()
        {
            _isAlive = false;
            // todo 게임 오버 패널 불러오기
            StartCoroutine(ApiHandler.Instance.PostRecord(
                token : BackendManager.Instance.Token,
                name : BackendManager.Instance.Nickname,
                sec : SetTimeString(),
                (result) =>
                {
                    print(result);
                }
                ));
            
            UIManager.Instance.GameOverPanel();
        }
    }
}
