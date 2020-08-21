using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartOrOver : MonoBehaviour
{
    public Button btnRestart, btnOver;
    // 다 열렸나 확인
    public GameObject ticket1, ticket2, ticket3, ticket4;

    // Start is called before the first frame update
    void Start()
    {
        btnRestart.onClick.AddListener(Restart);
        btnOver.onClick.AddListener(GameOver);

        // 일단 안보이게
        btnRestart.gameObject.SetActive(false);
        btnOver.gameObject.SetActive(false);
    }

    void Update()
    {
        if (ticket1.activeSelf && ticket2.activeSelf && ticket3.activeSelf && ticket4.activeSelf)
        {
            btnRestart.gameObject.SetActive(true);
            btnOver.gameObject.SetActive(true);
        }
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
