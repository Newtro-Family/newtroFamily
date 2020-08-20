using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartOrOver : MonoBehaviour
{
    public Button btnRestart, btnOver;

    // Start is called before the first frame update
    void Start()
    {
        btnRestart.onClick.AddListener(Restart);
        btnOver.onClick.AddListener(GameOver);
    }

    void Restart()
    {
        Debug.Log("게임 다시 시작");  // 점수 그대로 누적되어있나?
        SceneManager.LoadScene("02_Selectplayer");
    }

    void GameOver()
    {
        // 점수 리셋
        GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();
        flowM.score[0] = 0; flowM.score[1] = 0; flowM.score[2] = 0; flowM.score[3] = 0;

        Debug.Log("게임종료");
        Application.Quit();
    }
}
