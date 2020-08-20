using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game2Manager : MonoBehaviour
{

    //UI
    public GameObject player1, player2, player3, player4; //플레이어 점수판 오브젝트
    public Text p1_count, p2_count, p3_count, p4_count; //플레이어 획득 점수 text
    public GameObject ready_2; //카운트 다운 애니메이션

    //box 숫자 표시
    //public Text[] Box_options;
    public Text box1, box2, box3, box4;
    public List<int> BoxList = new List<int>() { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

    //변수
    private int playturn = 1;

    void Start()
    {
        switch(playturn)
        {
            case 1:
                player1.transform.localScale = new Vector2(1.25f, 1.18f);
                break;
            case 2:
                player1.transform.localScale = new Vector2(1f, 1f);
                player2.transform.localScale = new Vector2(1.25f, 1.18f);
                break;
            case 3:
                player2.transform.localScale = new Vector2(1f, 1f);
                player3.transform.localScale = new Vector2(1.25f, 1.18f);
                break;
            case 4:
                player3.transform.localScale = new Vector2(1f, 1f);
                player4.transform.localScale = new Vector2(1.25f, 1.18f);
                break;
        }
    }
    public void Gatcha(int box_num)
    {
            int rand = Random.Range(0, BoxList.Count);
            print(BoxList[rand]);
            BoxList.RemoveAt(rand);

            switch (box_num)
            {
                case 1:
                    box1.text = BoxList[rand].ToString();
                    break;

                case 2:
                    box2.text = BoxList[rand].ToString();
                    break;
                case 3:
                    box3.text = BoxList[rand].ToString();
                    break;
                case 4:
                    box4.text = BoxList[rand].ToString();
                    break;
            }

        if (playturn == 1)
        {
            p1_count.text = BoxList[rand].ToString();
        }
        else if (playturn == 2)
        {
            p2_count.text = BoxList[rand].ToString();
        }
        else if (playturn == 3)
        {
            p3_count.text = BoxList[rand].ToString();
        }
        else if (playturn == 4)
        {
            p4_count.text = BoxList[rand].ToString();
        }
            
        playturn++;

        if (playturn < 5)
        {
            StartCoroutine(ReadyDelay());
        }
        else
        {
            Debug.Log("다음 게임");

            GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();

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

        Invoke("Start", 1f);
        
    }

    IEnumerator ReadyDelay()
    {
        ready_2.SetActive(true);

        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 6.0f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        ready_2.gameObject.SetActive(false);

        Time.timeScale = 1.0f;
    }
}
