using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Setting 씬 이벤트 담당 스크립트

public class SettingManager : MonoBehaviour
{
    SoundManager SM;

    void Start()
    {
        SM = SoundManager.Instance;
        Time.timeScale = 0;
    }

    public void BE_Gomain()
    {
        SceneManager.LoadScene("00_MainScene");
    }
    public void BE_Play()
    {
        Time.timeScale = 1.0f;
        SceneManager.UnloadSceneAsync("07_Setting");
    }
}
