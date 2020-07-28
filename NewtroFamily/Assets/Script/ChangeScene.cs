﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void SceneChange_Main()
    {
        //쿠폰 박스 씬으로 이동
        SceneManager.LoadScene("00_MainScene");
    }
    public void SceneChange_coupon()
    {
        //쿠폰 박스 씬으로 이동
        SceneManager.LoadScene("01_CouponBox");
    }

    public void SceneChange_selectplayer()
    {
        //플레이어 수 설정 씬으로 이동
        SceneManager.LoadScene("02_SelectPlayer");
    }

    public void SceneChange_selectgame()
    {
        //플레이어 수 설정 씬으로 이동
        SceneManager.LoadScene("03_SelectGame");
    }

    public void SceneChange_game1()
    {
        //플레이어 수 설정 씬으로 이동
        SceneManager.LoadScene("04_Game1");
    }
    public void SceneChange_game2()
    {
        //플레이어 수 설정 씬으로 이동
        SceneManager.LoadScene("05_Game2");
    }
    public void SceneChange_game3()
    {
        //플레이어 수 설정 씬으로 이동
        SceneManager.LoadScene("06_Game3");
    }
}
