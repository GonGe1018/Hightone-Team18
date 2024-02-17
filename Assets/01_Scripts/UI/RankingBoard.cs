using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordData
{
    public string token, name, seconds;
    
    public RecordData(string token, string name, string seconds)
    {
        this.token = token;
        this.name = name;
        this.seconds = seconds;
    }
}

public class RankingBoard : MonoBehaviour
{
    [SerializeField] private GameObject rankCardPrefab;
    [SerializeField] private RectTransform contentTransform;
    
    List<RecordData> recordDataList = new List<RecordData>();
    
    void OnEnable()
    {
        StartCoroutine(ApiHandler.Instance.GetRanking(
                (result) =>
                {
                    
                },
                (rankingJson) =>
                {
                    if (rankingJson.Count == 0)
                    {
                        CreateCard(-1,true);
                        Debug.Log("아주 잘 안됨");
                    }
                    else
                    {
                        for(int i=0; i<rankingJson.Count; i++)
                        {
                            recordDataList.Add(new RecordData(
                                rankingJson[i]["token"].ToString(),
                                rankingJson[i]["name"].ToString(),
                                rankingJson[i]["seconds"].ToString()
                                )
                            );
                        }
                        for(int i=0; i<recordDataList.Count; i++)
                        {
                            CreateCard(i);
                        }
                    
                    }
                }
            )
        );
        Debug.Log("ㅁㄴㅇㄹㅁㄴㅇㄹ");
    }

    void CreateCard(int idx, bool isNone = false)
    {
        GameObject cardObj = Instantiate(rankCardPrefab, contentTransform);
        RankCard rankCard = cardObj.GetComponent<RankCard>();
       
        if (isNone)
        {
            rankCard.nameText.text = "유저가 없습니다";
            /*rankCard.recordText.text = "";
            rankCard.rankingText.text = "";*/
        }
        else
        {
            rankCard.nameText.text = $"{idx+1}위 {recordDataList[idx].name} {recordDataList[idx].seconds}";
        }
        
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
