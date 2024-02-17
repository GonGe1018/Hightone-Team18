using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public float speed;
        
    
    private void Update()
    {
        
    }

    void Move()
    {
        transform.position += -transform.right * (speed * Time.deltaTime);
    }

}
