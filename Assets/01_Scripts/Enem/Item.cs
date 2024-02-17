using System;
using System.Collections;
using System.Collections.Generic;
using gunggme;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

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
        
        itemCategori = Random.Range(0, 6);
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
                speed = 0.3f;
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PlayerAttack"))
        {
            gameObject.SetActive(false);
        }

        if (collider.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }


}
