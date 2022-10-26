using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IInitializePotentialDragHandler
{
    public ActiveAbility AbilityItem;

    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Image image;

    [SerializeField] private RectTransform rectTransform;
    public ItemSlot itemSlot;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        image = GetComponent<Image>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        image.maskable = false;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.maskable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        if(itemSlot != null)
        {
            rectTransform.position = itemSlot.rectTransform.position;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("onPointerDown");
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        eventData.useDragThreshold = false;
    }
}
