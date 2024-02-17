using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;




public class ApiHandler : Singelton<ApiHandler>
{
    string url= "http://127.0.0.1:8000/";
    
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
    
    


    public IEnumerator PostRecord(string token, string name, float sec,  Action<string> result)//기록 보내기
    {
        if (token == string.Empty)
        {
            yield break;
        }

        //유저 기록 보내기
        WWWForm form = new WWWForm();
        
        form.AddField("token",token);
        form.AddField("name",name);
        form.AddField("seconds",sec.ToString());
        
        UnityWebRequest www = UnityWebRequest.Post(url+"ranking",form);
        
        yield return www.SendWebRequest();

        if (www.error == null)
        {
            result(www.downloadHandler.text);
        }
        else
        {
            result("result");
        }

        Debug.Log(www.downloadHandler.text);
    }

    public IEnumerator GetRanking(Action<string> result, Action<JsonData> rankingJson)
    {
        string json =
            @"
            [
              {
                ""token"": ""FEFEW2342"",
                ""name"": ""우준성"",
                ""seconds"": ""2000""
              },
              {
                ""token"": ""FEFEW2343"",
                ""name"": ""우준캐슬"",
                ""seconds"": ""2000""
              }
            ]";
        
        UnityWebRequest www = UnityWebRequest.Get(url+"???");
        
        yield return www.SendWebRequest();
        
        // if (www.error == null)
        // {
        //     //JsonData data = JsonMapper.ToObject(www.downloadHandler.text);
        //     JsonData data = JsonMapper.ToObject(json);
        //     if (0 < data.Count && data.Count < 10)
        //     {
        //         result("SUCESS");
        //         rankingJson(data);
        //         Debug.Log("랭킹 잘 불러와짐");
        //     }
        //     else
        //     {
        //         result("TOO_MANY_DATA");
        //         Debug.Log("랭킹 데이터가 너무 많음");
        //     }
        // }
        // else
        // {
        //     Debug.Log("에러");
        //     result("ERROR");
        // }
        
        JsonData data = JsonMapper.ToObject(json);
        rankingJson(data);
    }


}
