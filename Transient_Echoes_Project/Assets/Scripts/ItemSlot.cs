using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public RectTransform rectTransform;

    [SerializeField] private bool isAbilitySlot;
    public PlayerNum PlayerAbilitySlot;
    public ActiveAbility activeAbility;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.gameObject.tag == "Ability")
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition;
            if(eventData.pointerDrag.GetComponent<DragDrop>() != null)
            {
                eventData.pointerDrag.GetComponent<DragDrop>().itemSlot = this;
                eventData.pointerDrag.transform.SetParent(gameObject.transform);
            }

            if(isAbilitySlot == true)
            {
                activeAbility = eventData.pointerDrag.GetComponent<DragDrop>().AbilityItem;
                PlayerMovement[] player = FindObjectsOfType<PlayerMovement>();
                for(int i = 0; i < player.Length; i++)
                {
                    if(player[i].PlayerNum == PlayerAbilitySlot)
                    {
                        player[i].CurrentAbility = activeAbility;
                    }
                }
            }
        }
    }
}
