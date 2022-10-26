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
    private PlayerMovement PlayerNumberObj;
    public ActiveAbility activeAbility;
    private GameObject activeAbilityObj;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        PlayerMovement[] player = FindObjectsOfType<PlayerMovement>();
        for (int i = 0; i < player.Length; i++)
        {
            if (player[i].PlayerNum == PlayerAbilitySlot)
            {
                PlayerNumberObj = player[i];
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.gameObject.tag == "Ability")
        {
            DragDrop dragDrop;
            if(eventData.pointerDrag.GetComponent<DragDrop>() != null)
            {
                dragDrop = eventData.pointerDrag.GetComponent<DragDrop>();

                //If there is an item in this slot
                if(activeAbilityObj != null)
                {
                    //If the other item slot is an ability slot.
                    if (dragDrop.itemSlot.isAbilitySlot == true)
                    {
                        //Save dragDrop original values
                        ActiveAbility nAbilityItem = dragDrop.AbilityItem;
                        GameObject nActiveAbilityObj = dragDrop.gameObject;

                        //Take Item from this and move to other ability slot
                        dragDrop.itemSlot.activeAbility = activeAbility;
                        dragDrop.itemSlot.activeAbilityObj = activeAbilityObj;
                        dragDrop.itemSlot.PlayerNumberObj.CurrentAbility = activeAbility;
                        activeAbilityObj.GetComponent<DragDrop>().itemSlot = dragDrop.itemSlot;
                        activeAbilityObj.transform.SetParent(dragDrop.itemSlot.gameObject.transform);
                        activeAbilityObj.GetComponent<RectTransform>().localPosition = Vector3.zero;

                        //Then assign the new one in...
                        activeAbility = nAbilityItem;
                        activeAbilityObj = nActiveAbilityObj;
                        activeAbilityObj.GetComponent<DragDrop>().itemSlot = dragDrop.itemSlot;
                        activeAbilityObj.transform.SetParent(gameObject.transform);
                        activeAbilityObj.GetComponent<RectTransform>().localPosition = Vector3.zero;
                    }
                    else
                    {
                        //Save dragDrop original values
                        ActiveAbility nAbilityItem = dragDrop.AbilityItem;
                        GameObject nActiveAbilityObj = dragDrop.gameObject;

                        //Take Item from this and move to other ability slot
                        dragDrop.itemSlot.activeAbility = ActiveAbility.None;
                        dragDrop.itemSlot.activeAbilityObj = activeAbilityObj;
                        dragDrop.itemSlot.PlayerNumberObj.CurrentAbility = ActiveAbility.None;
                        activeAbilityObj.GetComponent<DragDrop>().itemSlot = dragDrop.itemSlot;
                        activeAbilityObj.transform.SetParent(dragDrop.itemSlot.gameObject.transform);
                        activeAbilityObj.GetComponent<RectTransform>().localPosition = Vector3.zero;

                        //Then assign the new one in...
                        activeAbility = nAbilityItem;
                        activeAbilityObj = nActiveAbilityObj;
                        activeAbilityObj.GetComponent<DragDrop>().itemSlot = dragDrop.itemSlot;
                        activeAbilityObj.transform.SetParent(gameObject.transform);
                        activeAbilityObj.GetComponent<RectTransform>().localPosition = Vector3.zero;
                    }
                }
                else if(dragDrop.itemSlot != null && dragDrop.itemSlot.isAbilitySlot == true)
                {
                    dragDrop.itemSlot.activeAbility = ActiveAbility.None;
                    activeAbilityObj = null;
                    PlayerNumberObj.CurrentAbility = ActiveAbility.None;
                }

                //What actually moves the item
                dragDrop.itemSlot = this;
                eventData.pointerDrag.transform.SetParent(gameObject.transform);
                eventData.pointerDrag.GetComponent<RectTransform>().localPosition = Vector3.zero;
                activeAbilityObj = dragDrop.gameObject;

                if (isAbilitySlot == true)
                {
                    dragDrop = eventData.pointerDrag.GetComponent<DragDrop>();
                    activeAbility = dragDrop.AbilityItem;
                    PlayerNumberObj.CurrentAbility = activeAbility;
                }
            }
        }
    }
}
