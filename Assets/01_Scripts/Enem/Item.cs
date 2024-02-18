using System;
using System.Collections;
using System.Collections.Generic;
using gunggme;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

[Serializable]
public enum ItemType
{
    Penalty,
    Benefit
}

public class Item : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private ItemType itemType;
    public ItemType ItemType => itemType;
    [SerializeField] private int itemCategori;
    public int ItemCategori => itemCategori;
    [SerializeField] private Sprite[] _sprites;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Init();
    }
    private void OnEnable()
    {
        Init();
    }
    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += -transform.right * (speed * Time.deltaTime);
    }

    void Init()
    {
        
        int randTemp = Random.Range(0, 101);
        if (randTemp <= 70)
        {
            itemCategori = Random.Range(3, 6);
        }
        else if (randTemp <= 95)
        {
            itemCategori = Random.Range(0, 2);
        }
        else if(randTemp <= 100)
        {
            itemCategori = 2;
        }
        itemType = itemCategori >= 3 ? ItemType.Penalty : ItemType.Benefit;
        //speed = Random.Range(1.0f, 2.0f);
        switch (itemCategori)
        {
            case 0:
                speed = 2;
                break;
            case 1:
                speed = 1;
                break;
            case 2:
                speed = 0.7f;
                break;
            case 3:
                speed = 1.5f;
                break;
            case 4:
                speed = 2f;
                break;
            case 5:
                speed = 1;
                break;
        }

        _spriteRenderer.sprite = _sprites[itemCategori];
    }

    //Penalty(3: 게임기, 4: 에드캔, 5: 휴대폰)
    //Benefit(0: 우유, 1: 안대, 2: 양)
    public bool CollisionPlayerAttack()//
    {
        if (itemType == ItemType.Penalty)
        {
            return true;
        }

        return false;
    }

    public void ShootingEffect()
    {
        Sequence seq = DOTween.Sequence();
        if (transform.position.x > 0)
        {
            seq.Append(gameObject.transform.DOJump(new Vector3(12, 0, 0), 2, 1, 1));
        }
        else
        {
            seq.Append(gameObject.transform.DOJump(new Vector3(-12, 0, 0), 2, 1, 1));
        }
        seq.Insert(1f, DOTween.To(() => 0f, x => gameObject.SetActive(false), 0f, 0f));
    }
    
}
