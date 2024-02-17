using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;


[Serializable]
public class UserRecord
{
    public string token, name, seconds;
    public UserRecord(string token, string name, string sec)
    {
        this.token = token;
        this.name = name;
        this.seconds = sec;
    }

    // public override string ToString()
    // {
    //     return $"token : {token}\n name : {name}\n sec : {sec}";
    // }
}

public class ApiHandler : Singelton<ApiHandler>
{
    string url= "https://1228-2001-e60-908f-fc2b-b452-c843-3700-bc93.ngrok-free.app/";
    
    private void Awake()
    {
        // StartCoroutine(SendRecord("asdf","asdf",12.1f,
        //     (result) =>
        //     {
        //         print(result);
        //     }));
        // StartCoroutine(GetRanking(
        //     (result) =>
        //     {
        //         print(result);
        //     },
        //     (rankingJson) =>
        //     {
        //         print(rankingJson[1]["name"]);
        //     }
        //     )
        // );

        
    }
    



    public IEnumerator PostRecord(string token, string name, string sec,  Action<string> result)//기록 보내기
    {
        if (token == string.Empty)
        {
            yield break;
        }
        
        UserRecord userRecord = new UserRecord(token, name, sec);
        string json = JsonUtility.ToJson(userRecord);

        using (UnityWebRequest www = UnityWebRequest.Post(url+"ranking",json))
        {
            WWWForm form = new WWWForm();
            
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            www.uploadHandler = new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.error != null)
            {
                result(form.data.ToString());
            }
            else
            {
                result(form.ToString());
            }

            Debug.Log(www.downloadHandler.text);

            www.Dispose();
            www.uploadHandler.Dispose();
            www.downloadHandler.Dispose();
        }
    }

    public IEnumerator GetRanking(Action<string> result, Action<JsonData> rankingJson)
    {
        // string json =
        //     @"
        //     [
        //       {
        //         ""token"": ""FEFEW2342"",
        //         ""name"": ""우준성"",
        //         ""seconds"": ""2000""
        //       },
        //       {
        //         ""token"": ""FEFEW2343"",
        //         ""name"": ""우준캐슬"",
        //         ""seconds"": ""2000""
        //       }
        //     ]";
        
        UnityWebRequest www = UnityWebRequest.Get(url+"ranking");
        JsonData data = new JsonData();
        yield return www.SendWebRequest();
        
        if (!www.isNetworkError && !www.isHttpError)
        {
            data = JsonMapper.ToObject(www.downloadHandler.text);
            //JsonData data = JsonMapper.ToObject(json);
            if (0 < data.Count && data.Count < 10)
            {
                result("SUCESS");
                rankingJson(data);
                Debug.Log($"응답 받은 데이터 : {data.Count}");
            }
            else
            {
                result("TOO_MANY_DATA");
                Debug.Log("랭킹 데이터가 너무 많음");
            }
        }
        else
        {
            Debug.Log("에러");
            result("ERROR");
        }
        
        //JsonData data = JsonMapper.ToObject(data);
        //rankingJson(data);
        www.Dispose();
    }


}
