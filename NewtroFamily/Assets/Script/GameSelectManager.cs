using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSelectManager : MonoBehaviour
{
    //UI
    public Button game1_btn, game2_btn, game3_btn, start_btn;
    public GameObject game1_can, game2_can, game3_can;

    //Resources
    public Sprite[] gamenum;
    public Sprite[] game;

    //변수
    //public int count=0;
    public int[] gameflow = new int[3];
    public bool clear;
    //static int levelCount;



    // 순서에 따라 게임 플레이
    void Start()
    {
        game1_can.SetActive(false);
        game2_can.SetActive(false);
        game3_can.SetActive(false);
        start_btn.onClick.AddListener(LoadGameFlow);
    }

    public void Game1()
    {

        GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();

        if (game2_btn.interactable == true && game3_btn.interactable == true) //제기차기 게임이 첫번째 게임일 때
        {
            game1_btn.GetComponent<Image>().sprite = gamenum[0];
            game1_btn.interactable = false;
            game1_can.SetActive(true); // 게임1 선택 시 취소 기능 활성화

            flowM.SetFirst(1);
        }
        else if ((game2_btn.interactable == false && game3_btn.interactable == true) || (game2_btn.interactable == true && game3_btn.interactable == false))
        {
            //제기차기 게임이 두번째 게임으로 선택될 때

            game1_btn.GetComponent<Image>().sprite = gamenum[1];
            game1_btn.interactable = false;
            game1_can.SetActive(true); // 게임1 선택 시 취소 기능 활성화

            flowM.SetSecond(1);
            //gameflow[1] = 1;
        }
        else if (game2_btn.interactable == false && game3_btn.interactable == false) //제기차기 게임 마지막 순서일 때
        {
            game1_btn.GetComponent<Image>().sprite = gamenum[2];
            game1_btn.interactable = false;
            game1_can.SetActive(true); // 게임1 선택 시 취소 기능 활성화

            flowM.SetThird(3);
            //gameflow[2] = 1;

            if (game1_btn.interactable == false && game2_btn.interactable == false && game3_btn.interactable == false) 
            {
                //게임 선택 완료 시 게임시작 버튼 활성화

                start_btn.interactable = true;
                start_btn.GetComponent<Image>().sprite = gamenum[3];
            }
        }
    }
    public void Game2()
    {
        GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();

        if (game1_btn.interactable == true && game3_btn.interactable == true) //고무신 게임 첫번째 게임으로 선정
        {
            game2_btn.GetComponent<Image>().sprite = gamenum[0];
            game2_btn.interactable = false;
            game2_can.SetActive(true); // 고무신 게임 선택 시 취소 기능 활성화

            flowM.SetFirst(2);
        }
        else if ((game1_btn.interactable == false && game3_btn.interactable == true) || (game1_btn.interactable == true && game3_btn.interactable == false))
        {
            //고무신 게임 두번째 게임으로 선정

            game2_btn.GetComponent<Image>().sprite = gamenum[1];
            game2_btn.interactable = false;
            game2_can.SetActive(true); // 고무신 게임 선택 시 취소 기능 활성화

            flowM.SetSecond(2);
        }
        else if (game1_btn.interactable == false && game3_btn.interactable == false)
        {
            //고무신 게임 마지막 게임으로 선정
            game2_btn.GetComponent<Image>().sprite = gamenum[2];
            game2_btn.interactable = false;
            game2_can.SetActive(true); // 고무신 게임 선택 시 취소 기능 활성화

            flowM.SetThird(2);

            if (game1_btn.interactable == false && game2_btn.interactable == false && game3_btn.interactable == false)
            {
                //게임 선택 완료 시 게임시작 버튼 활성화
                start_btn.interactable = true;
                start_btn.GetComponent<Image>().sprite = gamenum[3];
            }
        }
    }
    public void Game3()
    {
        GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();

        if (game2_btn.interactable == true && game1_btn.interactable == true) //딱지치기 게임 첫번째 설정
        {
            game3_btn.GetComponent<Image>().sprite = gamenum[0];
            game3_btn.interactable = false;
            game3_can.SetActive(true); ; //딱지치기 선택 시 취소 기능 활성화

            flowM.SetFirst(3);
        }
        else if ((game2_btn.interactable == false && game1_btn.interactable == true) || (game2_btn.interactable == true && game1_btn.interactable == false))
        {
            game3_btn.GetComponent<Image>().sprite = gamenum[1];
            game3_btn.interactable = false;
            game3_can.SetActive(true); //딱지치기 선택 시 취소 기능 활성화

            flowM.SetSecond(3);
        }
        else if (game2_btn.interactable == false && game1_btn.interactable == false)
        {
            game3_btn.GetComponent<Image>().sprite = gamenum[2];
            game3_btn.interactable = false;
            game3_can.SetActive(true);//딱지치기 선택 시 취소 기능 활성화

            flowM.SetThird(3);

            if (game1_btn.interactable == false && game2_btn.interactable == false && game3_btn.interactable == false)
            {
                //게임 선택 완료 시 게임시작 버튼 활성화
                start_btn.interactable = true;
                start_btn.GetComponent<Image>().sprite = gamenum[3];
            }
        }

    }

    //게임 선택 취소 시 다시 원래 이미지로 돌아오기 
    public void Game1Cancle()
    {
        game1_btn.GetComponent<Image>().sprite = game[0];
        game1_btn.interactable = true;
        game1_can.SetActive(false);
    }

    public void Game2Cancle()
    {
        game2_btn.GetComponent<Image>().sprite = game[1];
        game2_btn.interactable = true;
        game2_can.SetActive(false);
    }

    public void Game3Cancle()
    {
        game3_btn.GetComponent<Image>().sprite = game[2];
        game3_btn.interactable = true;
        game3_can.SetActive(false);
    }

    public void LoadGameFlow()
    {
        GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();
        flowM.StartFirst();
    }

}


    


