using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Don't Destroy On Load. 게임 실행 순서 관리

public class GameFlowManager : MonoBehaviour
{
    public GameObject GameFlow;

    // 게임순서 저장 배열
    public int[] gameflow = new int[3];
    
    // 플레이어별 총점 저장
    public int[] score = new int[4];

    // 플레이어별 제기차기, 고무신던지기, 딱지뒤집기 점수 저장
    public int[] score1 = new int[4];
    public int[] score2 = new int[4];
    public int[] score3 = new int[4];

    // 현재 게임이 몇번째인지
    public int game = 0;

    //---------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(GameFlow);

        // 점수 0으로 초기화
        score[0] = 0; score[1] = 0; score[2] = 0; score[3] = 0;
        score1[0] = 0; score1[1] = 0; score1[2] = 0; score1[3] = 0;
        score2[0] = 0; score2[1] = 0; score2[2] = 0; score2[3] = 0;
        score3[0] = 0; score3[1] = 0; score3[2] = 0; score3[3] = 0;

    }

    // 게임 순서 설정 ----------------------------------------------
    // n을 첫번째 게임으로 설정
    public void SetFirst(int n)
    {
        Debug.Log("Game" + n + "을 첫번째로 플레이");
        gameflow[0] = n;
    }

    // n을 두번째 게임으로 설정
    public void SetSecond(int n)
    {
        Debug.Log("Game" + n + "을 두번째로 플레이");
        gameflow[1] = n;
    }

    // n을 세번째 게임으로 설정
    public void SetThird(int n)
    {
        Debug.Log("Game" + n + "을 세번째로 플레이");
        gameflow[2] = n;
    }

    // 게임 순서대로 실행 -----------------------------------------
    public void StartFirst()
    {
        Debug.Log("첫번째 게임: " + gameflow[0]);
        game = 1;

        if (gameflow[0] == 1) SceneManager.LoadScene("04_Game1");
        else if (gameflow[0] == 2) SceneManager.LoadScene("05_Game2");
        else if (gameflow[0] == 3) SceneManager.LoadScene("06_Game3");
    }

    public void StartSecond()
    {
        Debug.Log("두번째 게임: " + gameflow[1]);
        game = 2;

        if (gameflow[1] == 1) SceneManager.LoadScene("04_Game1");
        else if (gameflow[1] == 2) SceneManager.LoadScene("05_Game2");
        else if (gameflow[1] == 3) SceneManager.LoadScene("06_Game3");
    }

    public void StartThird()
    {
        Debug.Log("세번째 게임: " + gameflow[2]);
        game = 3;

        if (gameflow[2] == 1) SceneManager.LoadScene("04_Game1");
        else if (gameflow[2] == 2) SceneManager.LoadScene("05_Game2");
        else if (gameflow[2] == 3) SceneManager.LoadScene("06_Game3");
    }

}