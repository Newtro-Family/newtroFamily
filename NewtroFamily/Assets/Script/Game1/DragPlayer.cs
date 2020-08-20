using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragPlayer : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        /*
        // 주어진 범위를 벗어나지 않을 때에만 위치 변경 (x)
        if (rectTransform.anchoredPosition.x >= -700 && rectTransform.anchoredPosition.x <= 700)
            rectTransform.anchoredPosition += eventData.delta;  // x값만 변경해야함..

        // 주어진 범위를 벗어나지 않을 때에만 위치 변경 (y)
        if (rectTransform.anchoredPosition.y >= -300 && rectTransform.anchoredPosition.y <= 130)
            rectTransform.anchoredPosition += eventData.delta;  // y값만 변경해야함..
        */

        rectTransform.anchoredPosition += eventData.delta;


        // 캐릭터 크기 설정
        if (eventData.delta.y < 0) rectTransform.sizeDelta *= (1 - eventData.delta.y * 0.0011f);
        else if (eventData.delta.y > 0) rectTransform.sizeDelta *= (1 - eventData.delta.y * 0.001f);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}