using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject Bridge;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Bridge.SetActive(true);
    }
}
