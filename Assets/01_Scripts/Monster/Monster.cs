using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gunggme;
using UnityEditor;
using Random = UnityEngine.Random;

enum MonsterType {
    Penalty,
    Benefit
}

public class Monster : MonoBehaviour
{
    private int hp { get; set; } = 10;

    //private Collider track;
    
    private MonsterType monsterType;
    private int dieParameter; //죽었을 시 작동되는 혜택, 패널티에 대한 값
    private int spawnRate; //스폰 빈도
    private int ageGroup;// 연령대 분류
    
    //데미지 처리 컴포넌트
    private Damageable _damageable;
    
    //몬스터 생성될 시 타입 정하기
    //
    
    private void Awake()
    {
        // gameObject.SetActive(false);
        //Init();
    }
    

    void Init()
    {
        //ageGroup = //;
        
        //나이대별 체력 변경
        _damageable.SetHP((ageGroup + 1) * 10);

        //몬스터 타입 정하기
        int n = Random.Range(0, 2); //0: Penalty //1: Benefit
        monsterType = n == 0 ? MonsterType.Penalty : MonsterType.Benefit;
    }

    void PlayerCollison(Player player) //플레이어가 닿았을 때
    {
        gameObject.SetActive(false);
        if (monsterType == MonsterType.Penalty)
        {
            //패널티를 주어야할 때
            //공격 속도 줄이기
        }
        else if (monsterType == MonsterType.Benefit)
        {
            //혜택을 주어야할 때
            //공격 속도 올리기
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("Player"))
        {
            Player player = other.collider.GetComponent<Player>();
            PlayerCollison(player);
        }
    }
}
