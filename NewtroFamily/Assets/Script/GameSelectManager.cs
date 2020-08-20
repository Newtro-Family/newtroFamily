﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSelectManager : MonoBehaviour
{
    //UI
    public Button game1_btn, game2_btn, game3_btn, start_btn;

    //Resources
    public Sprite[] gamenum;

    //변수
    //public int count=0;
    public int[] gameflow = new int[3];
    public bool clear;
    //static int levelCount;


    public void Game1()
    {

        GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();

        if (game2_btn.interactable == true && game3_btn.interactable == true)
        {
            game1_btn.GetComponent<Image>().sprite = gamenum[0];
            game1_btn.interactable = false;

            flowM.SetFirst(1);
        }
        else if ((game2_btn.interactable == false && game3_btn.interactable == true) || (game2_btn.interactable == true && game3_btn.interactable == false))
        {
            game1_btn.GetComponent<Image>().sprite = gamenum[1];
            game1_btn.interactable = false;
            flowM.SetSecond(1);
            //gameflow[1] = 1;
        }
        else if (game2_btn.interactable == false && game3_btn.interactable == false)
        {
            game1_btn.GetComponent<Image>().sprite = gamenum[2];
            game1_btn.interactable = false;
            flowM.SetThird(3);
            //gameflow[2] = 1;

            if (game1_btn.interactable == false && game2_btn.interactable == false && game3_btn.interactable == false)
            {
                start_btn.interactable = true;
                start_btn.GetComponent<Image>().sprite = gamenum[3];
            }
        }
    }
    public void Game2()
    {
        GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();

        if (game1_btn.interactable == true && game3_btn.interactable == true)
        {
            game2_btn.GetComponent<Image>().sprite = gamenum[0];
            game2_btn.interactable = false;
            flowM.SetFirst(2);
        }
        else if ((game1_btn.interactable == false && game3_btn.interactable == true) || (game1_btn.interactable == true && game3_btn.interactable == false))
        {
            game2_btn.GetComponent<Image>().sprite = gamenum[1];
            game2_btn.interactable = false;
            flowM.SetSecond(2);
        }
        else if (game1_btn.interactable == false && game3_btn.interactable == false)
        {
            game2_btn.GetComponent<Image>().sprite = gamenum[2];
            game2_btn.interactable = false;
            flowM.SetThird(2);

            if (game1_btn.interactable == false && game2_btn.interactable == false && game3_btn.interactable == false)
            {
                start_btn.interactable = true;
                start_btn.GetComponent<Image>().sprite = gamenum[3];
            }
        }
    }
    public void Game3()
    {
        GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();

        if (game2_btn.interactable == true && game1_btn.interactable == true)
        {
            game3_btn.GetComponent<Image>().sprite = gamenum[0];
            game3_btn.interactable = false;
            flowM.SetFirst(3);
        }
        else if ((game2_btn.interactable == false && game1_btn.interactable == true) || (game2_btn.interactable == true && game1_btn.interactable == false))
        {
            game3_btn.GetComponent<Image>().sprite = gamenum[1];
            game3_btn.interactable = false;
            flowM.SetSecond(3);
        }
        else if (game2_btn.interactable == false && game1_btn.interactable == false)
        {
            game3_btn.GetComponent<Image>().sprite = gamenum[2];
            game3_btn.interactable = false;
            flowM.SetThird(3);

            if (game1_btn.interactable == false && game2_btn.interactable == false && game3_btn.interactable == false)
            {
                start_btn.interactable = true;
                start_btn.GetComponent<Image>().sprite = gamenum[3];
            }
        }

    }

    // 순서에 따라 게임 플레이
    void Start()
    {
        start_btn.onClick.AddListener(LoadGameFlow);
    }

    public void LoadGameFlow()
    {
        GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();
        flowM.StartFirst();
    }


    /*
    public void GameStart(int num)
    {
        if (game1_btn.enabled == false && game2_btn.enabled == false && game3_btn.enabled == false)
        {
            switch (num)
            {
                case 1:
                    Debug.Log("case 1");
                    if (game1_btn.GetComponent<Image>().sprite = gamenum[0])
                    {
                        SceneManager.LoadScene("04_Game1");
                        if (clear == true)
                        {
                            if (game2_btn.GetComponent<Image>().sprite = gamenum[1])
                            {
                                clear = false;
                                SceneManager.LoadScene("05_Game2");
                                if (clear == true)
                                {
                                    clear = false;
                                    SceneManager.LoadScene("06_Game3");
                                }
                            }
                            else if (game3_btn.GetComponent<Image>().sprite = gamenum[1])
                            {
                                clear = false;
                                SceneManager.LoadScene("06_Game3");
                                if (clear == true)
                                {
                                    clear = false;
                                    SceneManager.LoadScene("05_Game2");
                                }
                            }

                        }
                    }
                    break;
                case 2:
                    Debug.Log("case 2");
                    if (game2_btn.GetComponent<Image>().sprite = gamenum[0])
                    {
                        SceneManager.LoadScene("05_Game2");
                        if (clear == true)
                        {
                            if (game1_btn.GetComponent<Image>().sprite = gamenum[1])
                            {
                                clear = false;
                                SceneManager.LoadScene("04_Game1");
                                if (clear == true)
                                {
                                    SceneManager.LoadScene("06_Game3");
                                }

                            }
                            else if (game3_btn.GetComponent<Image>().sprite = gamenum[1])
                            {
                                clear = false;
                                SceneManager.LoadScene("06_Game3");
                                if (clear == true)
                                {
                                    SceneManager.LoadScene("04_Game1");
                                }
                            }
                        }

                    }
                    break;
                case 3:
                    Debug.Log("case 3");
                    if (game3_btn.GetComponent<Image>().sprite = gamenum[0])
                    {
                        SceneManager.LoadScene("06_Game3");
                        if (clear == true)
                        {
                            if (game1_btn.GetComponent<Image>().sprite = gamenum[1])
                            {
                                clear = false;
                                SceneManager.LoadScene("04_Game1");
                                if (clear == true)
                                {
                                    SceneManager.LoadScene("05_Game2");
                                }
                            }
                            else if (game2_btn.GetComponent<Image>().sprite = gamenum[1])
                            {
                                clear = false;
                                SceneManager.LoadScene("05_Game2");
                                if (clear == true)
                                {
                                    SceneManager.LoadScene("04_Game1");
                                }
                            }

                        }
                    }
                    break;
            }
        }
    }*/
}


    


