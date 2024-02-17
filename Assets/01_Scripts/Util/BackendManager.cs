using System;
using System.Collections;
using System.Collections.Generic;
using BackEnd;
using UnityEngine;

namespace gunggme
{
    public class BackendManager : Singelton<BackendManager>
    {
        public string Token;
        public string Nickname;
        public GoogleLoginManager gpgs;
        
        protected override void Awake()
        {
            base.Awake();
            
            var bro = Backend.Initialize(true); // 뒤끝 초기화

            // 뒤끝 초기화에 대한 응답값
            if(bro.IsSuccess()) {
                Debug.Log("초기화 성공 : " + bro); // 성공일 경우 statusCode 204 Success
            } else {
                Debug.LogError("초기화 실패 : " + bro); // 실패일 경우 statusCode 400대 에러 발생
            }
            StartCoroutine(gpgs.StartGoogleLogin());
        }
        public void GetNickname()
        {
            BackendReturnObject bro = Backend.BMember.GetUserInfo();
            Nickname = bro.GetReturnValuetoJSON()["row"]["nickname"].ToString();
            Debug.Log(Token + " " + Nickname);
        }
    }
}
