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

        // 오브젝트 최초 크기 저장
        float originSize = rectTransform.sizeDelta.x;
        Debug.Log(originSize);
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
            rectTransform.anchoredPosition += eventData.delta;  // x값만 변경해야함

        // 주어진 범위를 벗어나지 않을 때에만 위치 변경 (y)
        if (rectTransform.anchoredPosition.y >= -300 && rectTransform.anchoredPosition.y <= 130)
            rectTransform.anchoredPosition += eventData.delta;  // y값만 변경해야함
        */

        rectTransform.anchoredPosition += eventData.delta;
        float positionY = rectTransform.anchoredPosition.y;

        Debug.Log("현재 y 좌표: " + rectTransform.anchoredPosition.y);

        // 캐릭터 크기 변환
        // 변환 key
        float sizeKey = rectTransform.anchoredPosition.y;

        //if (eventData.delta.y == 0) rectTransform.sizeDelta = new Vector2(originSize, originSize);
         if (eventData.delta.y < 0) rectTransform.sizeDelta = new Vector2(100 - sizeKey, 100 - sizeKey);
        else rectTransform.sizeDelta = new Vector2(100 - sizeKey, 100 - sizeKey);
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