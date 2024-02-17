using System;
using System.Collections;
using System.Collections.Generic;
using BackEnd;
using UnityEngine;

namespace gunggme
{
    public class GoogleLoginManager : MonoBehaviour
    {
        private void Start()
        {
            StartGoogleLogin();
        }

        public void StartGoogleLogin() {
            TheBackend.ToolKit.GoogleLogin.Android.GoogleLogin(GoogleLoginCallback);
        }

        private void GoogleLoginCallback(bool isSuccess, string errorMessage, string token) {
            if (isSuccess == false) {
                Debug.LogError(errorMessage);
                return;
            }
    
            Debug.Log("구글 토큰 : " + token);
            var bro = Backend.BMember.AuthorizeFederation(token, FederationType.Google);
            Debug.Log("페데레이션 로그인 결과 : " + bro);
        }
    }
}
