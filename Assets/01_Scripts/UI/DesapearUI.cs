using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesapearUI : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(DeactivateObj), 1);
    }

    void DeactivateObj()
    {
        gameObject.SetActive(false);
    }
}
