using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gunggme
{
    [Serializable]
    public enum PlayerState
    {
        infant = 0,
        early_childhood = 1,
        adolescence = 2,
        youth = 3,
        middle_age = 4,
        old_age = 5
    }
    
    public class Player : MonoBehaviour
    {
        public float SpeedOfTheBall; //speed of the ball in z axis(to move forward)
        public float Damping = 0.2f; //Smoothness of the ball when moving in x axis

        [Header("플레이어 상태")]
        [SerializeField] private PlayerState _playerState;
        [SerializeField] private GameObject[] _playerObjs;

        [Header("플레이어 스탯")]
        [SerializeField] private float _curAttackSpeed;
        [SerializeField] private float _maxAttackSpeed;

        private void Update()
        {
            Move();
        }

        void Move()
        {
#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Casting ray from screen to world
                RaycastHit hit; //A raycastHit variable to detect the ray
                if (Physics.Raycast(ray,
                        out hit)) //Physics.Raycast returns bool, if it hits something like tile, it will return true
                {
                    Vector3 point = hit.point; //Assigning the hit position of tile to point
                    point.z = gameObject.transform.position.z; //Ensuring that z axis doesn't change with hit
                    point.y = gameObject.transform.position.y; //ensuring y axis remains constant
                    gameObject.transform.position =
                        Vector3.MoveTowards(gameObject.transform.position, point,
                            Damping); //Moving the ball to above assigned Point position
                }
            }
#elif UNITY_ANDROID
        for (int i = 0; i < Input.touchCount; i++)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Casting ray from screen to world
                RaycastHit hit; //A raycastHit variable to detect the ray
                if (Physics.Raycast(ray,
                        out hit)) //Physics.Raycast returns bool, if it hits something like tile, it will return true
                {
                    Vector3 point = hit.point; //Assigning the hit position of tile to point
                    point.z = gameObject.transform.position.z; //Ensuring that z axis doesn't change with hit
                    point.y = gameObject.transform.position.y; //ensuring y axis remains constant
                    gameObject.transform.position =
                        Vector3.MoveTowards(gameObject.transform.position, point,
                            Damping); //Moving the ball to above assigned Point position
                }
            }
#endif
            //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 1f), SpeedOfTheBall);
            //Moving the ball forward towards z axis, Speed of the ball is needed here that how fast it will go
        }

        void ShotObj()
        {
            if (_curAttackSpeed > 0)
            {
                _curAttackSpeed -= Time.deltaTime;
            }
            else
            {
                // todo 물건 발사
            }
        }

        public void ChangeState(PlayerState state)
        {
            _playerState = state;

            for (int i = 0; i < _playerObjs.Length; i++)
            {
                _playerObjs[i].SetActive((int)_playerState == i);
            }
        }
    }
}
