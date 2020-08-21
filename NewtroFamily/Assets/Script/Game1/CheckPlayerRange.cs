using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerRange : MonoBehaviour
{
    private RectTransform rectTransform;    //플레이어

    // 플레이어 위치 판별하기 위한 사분면 별 진리값 변수
    bool range1, range2, range3, range4 = true;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 1사분면의 위치에 플레이어가 존재하는지 확인
    bool CheckRange1()
    {
        if (rectTransform.anchoredPosition.y <= rectTransform.anchoredPosition.x * (-38) / 181.0f + 35060 / 181.0f)
            range1 = true;
        else range1 = false;

        return range1;
    }

    // 2사분면의 위치에 플레이어가 존재하는지 확인
    bool CheckRange2()
    {
        if (rectTransform.anchoredPosition.y <= rectTransform.anchoredPosition.x * 9 / 29.0f + 6070 / 29.0f)
            range2 = true;
        else range2 = false;

        return range2;
    }

    // 3사분면의 위치에 플레이어가 존재하는지 확인
    bool CheckRange3()
    {
        if (rectTransform.anchoredPosition.y >= rectTransform.anchoredPosition.x * (-25) / 87.0f - 9530 / 29.0f)
            range3 = true;
        else range3 = false;

        return range3;
    }

    // 4사분면의 위치에 플레이어가 존재하는지 확인
    bool CheckRange4()
    {
        if (rectTransform.anchoredPosition.y >= rectTransform.anchoredPosition.x * 66 / 181.0f + 55940 / 181.0f)
            range4 = true;
        else range3 = false;

        return range4;
    }
}
