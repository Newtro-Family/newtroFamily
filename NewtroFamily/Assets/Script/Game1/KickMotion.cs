using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 제기와의 거리에 따라 플레이어 Sprite 변화
public class KickMotion : MonoBehaviour
{
    public GameObject player;  // 플레이어
    private float distance; // 플레이어와 제기 거리

    public GameObject ball;    // 제기
    public Sprite imgNormalL, imgKickingL, imgNormalR, imgKickingR;   // 원래상태 & 발차기 (왼/오)


    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(player.transform.position, ball.transform.position);

        // 제기 가까워졌을 때
        if (distance <= 80f)
        {
            // 제기가 더 왼쪽에 있을때
            if (player.transform.position.x < ball.transform.position.x)
                player.GetComponent<Image>().sprite = imgKickingR;
            // 제기가 오른쪽에 있을 때
            else player.GetComponent<Image>().sprite = imgKickingL;
        }
        else
        {
            // 제기가 더 왼쪽에 있을때
            if (player.transform.position.x < ball.transform.position.x)
                player.GetComponent<Image>().sprite = imgNormalR;
            // 제기가 오른쪽에 있을 때
            else player.GetComponent<Image>().sprite = imgNormalL;
        }
    }
}
