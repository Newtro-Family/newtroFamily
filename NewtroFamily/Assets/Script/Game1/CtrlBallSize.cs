using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 제기 위치에 따른 크기 조정
public class CtrlBallSize : MonoBehaviour
{
    private RectTransform rectBall;

    // Start is called before the first frame update
    void Start()
    {
        rectBall = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // 제기 크기 변환
        // 변환 key
        float sizeKey = rectBall.anchoredPosition.y * 0.2f;
        rectBall.sizeDelta = new Vector2(100 - sizeKey, 100 - sizeKey);
    }
}
