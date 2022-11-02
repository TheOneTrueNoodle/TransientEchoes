using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject Bridge;
    public SpriteRenderer buttonSprite;
    public Color buttonColor;
    public Color buttonPressedColor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Bridge.SetActive(true);
        buttonSprite.color = buttonPressedColor;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Bridge.SetActive(false);
        buttonSprite.color = buttonColor;
    }
}
