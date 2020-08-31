using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    // 순위 저장할 배열
    int[] rankIndex = new int[4];

    // 이미지
    public GameObject First1, First2, First3, First4;   // 1등
    public GameObject Second1, Second2, Second3, Second4;   // 2등
    public GameObject Third1, Third2, Third3, Third4;   // 3등
    public GameObject Fourth1, Fourth2, Fourth3, Fourth4;   // 4등

    // 점수표
    public Text txtSumKY, txtSumDH, txtSumYH, txtSumCS,         // 총점
                txtGame1KY, txtGame1DH, txtGame1YH, txtGame1CS, // 제기차기
                txtGame2KY, txtGame2DH, txtGame2YH, txtGame2CS, // 고무신던지기
                txtGame3KY, txtGame3DH, txtGame3YH, txtGame3CS; // 딱지치기

    // Start is called before the first frame update
    void Start()
    {
        GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();

        rankIndex[0] = flowM.score[0];
        rankIndex[1] = flowM.score[1];
        rankIndex[2] = flowM.score[2];
        rankIndex[3] = flowM.score[3];

        // 기영이 / 다혜 / 영희 / 철수
        Debug.Log("최종 점수: " + flowM.score[0].ToString() + " / " + flowM.score[1].ToString()
            + " / " + flowM.score[2].ToString() + " / " + flowM.score[3].ToString() + " / ");

        // 표에 총점 표시
        txtSumKY.text = flowM.score[0].ToString();
        txtSumDH.text = flowM.score[1].ToString();
        txtSumYH.text = flowM.score[2].ToString();
        txtSumCS.text = flowM.score[3].ToString();

        // 표에 제기차기 점수 표시
        txtGame1KY.text = flowM.score1[0].ToString();
        txtGame1DH.text = flowM.score1[1].ToString();
        txtGame1YH.text = flowM.score1[2].ToString();
        txtGame1CS.text = flowM.score1[3].ToString();

        // 표에 고무신던지기 점수 표시 -> X

        // 표에 딱지뒤집기 점수 표시
        txtGame3KY.text = flowM.score3[0].ToString();
        txtGame3DH.text = flowM.score3[1].ToString();
        txtGame3YH.text = flowM.score3[2].ToString();
        txtGame3CS.text = flowM.score3[3].ToString();

        Sort(); //지워도될듯(테스트안해봄)
    }

    // 크기 순서
    void Sort()
    {
        GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();

        System.Array.Sort(rankIndex);
        
        Debug.Log("Sort 결과: " + rankIndex[0].ToString() + " / " + rankIndex[1].ToString()
            + " / " + rankIndex[2].ToString() + " / " + rankIndex[3].ToString());

        Rank1(); Rank2(); Rank3(); Rank4();
    }

    // 시상대에 반영 ---------------------------------------------------------------
    // 코드 너무 더럽..
    void Rank1()
    {
        GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();

        if (rankIndex[3] == flowM.score[0])
        {
            Debug.Log("1등: 기영이");

            First1.gameObject.SetActive(true);
            First2.gameObject.SetActive(false);
            First3.gameObject.SetActive(false);
            First4.gameObject.SetActive(false);
        }
        else if (rankIndex[3] == flowM.score[1])
        {
            Debug.Log("1등: 다혜");

            First1.gameObject.SetActive(false);
            First2.gameObject.SetActive(true);
            First3.gameObject.SetActive(false);
            First4.gameObject.SetActive(false);
        }
        else if (rankIndex[3] == flowM.score[2])
        {
            Debug.Log("1등: 영희");

            First1.gameObject.SetActive(false);
            First2.gameObject.SetActive(false);
            First3.gameObject.SetActive(true);
            First4.gameObject.SetActive(false);
        }
        else if (rankIndex[3] == flowM.score[3])
        {
            Debug.Log("1등: 철수");

            First1.gameObject.SetActive(false);
            First2.gameObject.SetActive(false);
            First3.gameObject.SetActive(false);
            First4.gameObject.SetActive(true);
        }
    }

    void Rank2()
    {
        GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();

        if (rankIndex[2] == flowM.score[0])
        {
            Debug.Log("2등: 기영이");

            Second1.gameObject.SetActive(true);
            Second2.gameObject.SetActive(false);
            Second3.gameObject.SetActive(false);
            Second4.gameObject.SetActive(false);
        }
        else if (rankIndex[2] == flowM.score[1])
        {
            Debug.Log("2등: 다혜");

            Second1.gameObject.SetActive(false);
            Second2.gameObject.SetActive(true);
            Second3.gameObject.SetActive(false);
            Second4.gameObject.SetActive(false);
        }
        else if (rankIndex[2] == flowM.score[2])
        {
            Debug.Log("2등: 영희");

            Second1.gameObject.SetActive(false);
            Second2.gameObject.SetActive(false);
            Second3.gameObject.SetActive(true);
            Second4.gameObject.SetActive(false);
        }
        else if (rankIndex[2] == flowM.score[3])
        {
            Debug.Log("2등: 철수");

            Second1.gameObject.SetActive(false);
            Second2.gameObject.SetActive(false);
            Second3.gameObject.SetActive(false);
            Second4.gameObject.SetActive(true);
        }
    }

    void Rank3()
    {
        GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();

        if (rankIndex[1] == flowM.score[0])
        {
            Debug.Log("3등: 기영이");

            Third1.gameObject.SetActive(true);
            Third2.gameObject.SetActive(false);
            Third3.gameObject.SetActive(false);
            Third4.gameObject.SetActive(false);
        }
        else if (rankIndex[1] == flowM.score[1])
        {
            Debug.Log("3등: 다혜");

            Third1.gameObject.SetActive(false);
            Third2.gameObject.SetActive(true);
            Third3.gameObject.SetActive(false);
            Third4.gameObject.SetActive(false);
        }
        else if (rankIndex[1] == flowM.score[2])
        {
            Debug.Log("3등: 영희");

            Third1.gameObject.SetActive(false);
            Third2.gameObject.SetActive(false);
            Third3.gameObject.SetActive(true);
            Third4.gameObject.SetActive(false);
        }
        else if (rankIndex[1] == flowM.score[3])
        {
            Debug.Log("3등: 철수");

            Third1.gameObject.SetActive(false);
            Third2.gameObject.SetActive(false);
            Third3.gameObject.SetActive(false);
            Third4.gameObject.SetActive(true);
        }
    }

    void Rank4()
    {
        GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();

        if (rankIndex[0] == flowM.score[0])
        {
            Debug.Log("4등: 기영이");

            Fourth1.gameObject.SetActive(true);
            Fourth2.gameObject.SetActive(false);
            Fourth3.gameObject.SetActive(false);
            Fourth4.gameObject.SetActive(false);
        }
        else if (rankIndex[0] == flowM.score[1])
        {
            Debug.Log("4등: 다혜");

            Fourth1.gameObject.SetActive(false);
            Fourth2.gameObject.SetActive(true);
            Fourth3.gameObject.SetActive(false);
            Fourth4.gameObject.SetActive(false);
        }
        else if (rankIndex[0] == flowM.score[2])
        {
            Debug.Log("4등: 영희");

            Fourth1.gameObject.SetActive(false);
            Fourth2.gameObject.SetActive(false);
            Fourth3.gameObject.SetActive(true);
            Fourth4.gameObject.SetActive(false);
        }
        else if (rankIndex[0] == flowM.score[3])
        {
            Debug.Log("4등: 철수");

            Fourth1.gameObject.SetActive(false);
            Fourth2.gameObject.SetActive(false);
            Fourth3.gameObject.SetActive(false);
            Fourth4.gameObject.SetActive(true);
        }
    }
}
