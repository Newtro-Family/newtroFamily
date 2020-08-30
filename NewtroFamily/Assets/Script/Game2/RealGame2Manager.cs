using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RealGame2Manager : MonoBehaviour
{
    //UI
    public GameObject loading;
    public Button btnNext;  // 다음 게임으로 버튼

    //변수
    readonly WaitForSeconds term = new WaitForSeconds(1f);


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingScene());

        btnNext.onClick.AddListener(NextGame);
    }

    // 다음 게임으로 넘어가는 함수
    void NextGame()
    {
        GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();

        Debug.Log("다음 게임");

        if (flowM.game == 1)
        {
            flowM.StartSecond(); Debug.Log("고무신던지기 완료. 두번째 게임: " + flowM.gameflow[1]);
        }
        else if (flowM.game == 2)
        {
            flowM.StartThird(); Debug.Log("고무신던지기 완료. 세번째 게임: " + flowM.gameflow[2]);
        }
        else if (flowM.game == 3)
        {
            SceneManager.LoadScene("09_GameResult");
            Debug.Log("고무신던지기 완료. 결과 화면으로");
        }
    }

    IEnumerator LoadingScene()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3.0f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        loading.SetActive(false);

        Time.timeScale = 1.0f;
    }

}
