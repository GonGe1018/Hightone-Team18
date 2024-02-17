using System;
using System.Collections;
using System.Collections.Generic;
using BackEnd;
using UnityEngine;

namespace gunggme
{
    public class GoogleLoginManager : MonoBehaviour
    {
        [SerializeField] private GameObject _playerNameInputObj;

        private string _token;
//#if UNITY_ANDROID

        void OnEnable()
        {
            StartCoroutine(StartGoogleLogin());
            if (PoolManager.Instance != null)
            {
                PoolManager.Instance.DestroyObj();
            }

            if (UIManager.Instance != null)
            {
                UIManager.Instance.DestroyObj();
            }
        }
        public IEnumerator StartGoogleLogin() {
            TheBackend.ToolKit.GoogleLogin.Android.GoogleLogin(GoogleLoginCallback);
            yield return new WaitForSeconds(0.02f);
            BackendManager.Instance.Token = _token;
        }

        private void GoogleLoginCallback(bool isSuccess, string errorMessage, string token) {
            if (isSuccess == false) {
                Debug.LogError(errorMessage);
                return;
            }
    
            Debug.Log("구글 토큰 : " + token);
            var bro = Backend.BMember.AuthorizeFederation(token, FederationType.Google);
            Debug.Log("페데레이션 로그인 결과 : " + bro);
            _token = token;
            
            if (bro.GetStatusCode() == "200")
            {
                // 넘기기
            }
            else if (bro.GetStatusCode() == "201")
            {
                _playerNameInputObj.gameObject.SetActive(true);
            }
        }
//#endif
    }
}
