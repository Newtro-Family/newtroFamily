using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragPlayer : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    public float sizeKeyPlayer = 0.0f;

    // 플레이어 위치 판별하기 위한 사분면 별 진리값 변수
    bool range1, range2, range3, range4 = true;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // 오브젝트 최초 크기 저장
        float originSize = rectTransform.sizeDelta.x;
        //Debug.Log(originSize);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        /*
        if (CheckRange1() && CheckRange2() && CheckRange3() && CheckRange4())
        {
            rectTransform.anchoredPosition += eventData.delta;
            float positionY = rectTransform.anchoredPosition.y;
        }
        else
        {
            rectTransform.anchoredPosition -= eventData.delta;
            float positionY = rectTransform.anchoredPosition.y;
        }
        */

        rectTransform.anchoredPosition += eventData.delta;
        float positionY = rectTransform.anchoredPosition.y;

        //Debug.Log("현재 y 좌표: " + rectTransform.anchoredPosition.y);

        // 캐릭터 크기 변환
        // 변환 key
        sizeKeyPlayer = rectTransform.anchoredPosition.y * 0.1f;

        //if (eventData.delta.y == 0) rectTransform.sizeDelta = new Vector2(originSize, originSize);
        if (eventData.delta.y < 0) rectTransform.sizeDelta = new Vector2(100 - sizeKeyPlayer, 100 - sizeKeyPlayer);
        else rectTransform.sizeDelta = new Vector2(100 - sizeKeyPlayer, 100 - sizeKeyPlayer);

        //Debug.Log("현재 플레이어 크기: " + rectTransform.sizeDelta);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }


    // 플레이어 위치 판별
    // 1사분면의 위치에 플레이어가 존재하는지 확인
    bool CheckRange1()
    {
        if (rectTransform.anchoredPosition.y < rectTransform.anchoredPosition.x * (-38) / 181.0f + 35060 / 181.0f)
            range1 = true;
        else
        {
            range1 = false;
            Debug.Log("1사분면");
        }

        return range1;
    }

    // 2사분면의 위치에 플레이어가 존재하는지 확인
    bool CheckRange2()
    {
        if (rectTransform.anchoredPosition.y < rectTransform.anchoredPosition.x * 9 / 29.0f + 6070 / 29.0f)
            range2 = true;
        else
        {
            range2 = false;
            Debug.Log("2사분면");
        }

        return range2;
    }

    // 3사분면의 위치에 플레이어가 존재하는지 확인
    bool CheckRange3()
    {
        if (rectTransform.anchoredPosition.y > rectTransform.anchoredPosition.x * (-19) / 40.0f - 995 / 2.0f)
            range3 = true;
        else
        {
            range3 = false;
            Debug.Log("3사분면");
        }

        return range3;
    }

    // 4사분면의 위치에 플레이어가 존재하는지 확인
    bool CheckRange4()
    {
        if (rectTransform.anchoredPosition.y > rectTransform.anchoredPosition.x * 92 / 195.0f - 15710 / 39.0f)
            range4 = true;
        else
        {
            range4 = false;
            Debug.Log("4사분면");
        }

        return range4;
    }
}