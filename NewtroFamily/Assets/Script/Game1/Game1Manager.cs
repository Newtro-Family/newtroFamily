using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game1Manager : MonoBehaviour
{
    // 플레이어 차례관리
    public GameObject player1, player2, player3, player4;   // 플레이어 점수판
    List<GameObject> PlayerList = new List<GameObject>();   // 플레이어 점수판 리스트
    int pm = 0; // 리스트 인덱스 참조 위한 변수

    public GameObject ball; // 제기
    public Rigidbody2D rigidBall;   // 제기 rigidBody

    // 점수 관리 -> 추후에 코드 깔끔하게 바꾸기(지금 숫자가 아니라 텍스트로 가져옴..)
    public Text currentGoal;    // 현재점수
    public Text goal1, goal2, goal3, goal4; // 플레이어 점수판의 텍스트
    public List<Text> GoalList = new List<Text>();  // 플레이어 점수 텍스트 리스트

    public GameObject ready_1, ready_2, ready_3, ready_4; //플레이어 레디 오브젝트

    // Start is called before the first frame update
    void Start()
    {
        // 플레이어 점수판 리스트에 점수판 오브젝트 추가
        PlayerList.Add(player1);
        PlayerList.Add(player2);
        PlayerList.Add(player3);
        PlayerList.Add(player4);

        // 점수 텍스트 리스트
        GoalList.Add(goal1);
        GoalList.Add(goal2);
        GoalList.Add(goal3);
        GoalList.Add(goal4);
        /*
        // 첫번째 플레이어만 활성화
        PlayerList[0].SetActive(true);
        PlayerList[1].SetActive(false);
        PlayerList[2].SetActive(false);
        PlayerList[3].SetActive(false);*/

        // 점수 데이터 가져오기 -> 로그에만 찍는거로 변경
        GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();

        Debug.Log("현재까지 총 점수: 철수(" + flowM.score[0].ToString() + ") / 다혜(" + flowM.score[1].ToString() + ") / 영희("
            + flowM.score[2].ToString() + ") / 철수(" + flowM.score[3].ToString() + ")");
        if (pm == 0)
        {
            GoalList[0].text = "-";
            GoalList[1].text = "-";
            GoalList[2].text = "-";
            GoalList[3].text = "-";
        }
        
        /*
        GoalList[0].text = flowM.score[0].ToString();
        GoalList[1].text = flowM.score[1].ToString();
        GoalList[2].text = flowM.score[2].ToString();
        GoalList[3].text = flowM.score[3].ToString();
        */
    }

    // Update is called once per frame
    void Update()
    {
        // 제기 위치가 플레이어보다 적을 때 플레이어 변경
        if (PlayerList[pm].transform.position.y - ball.transform.position.y > 300) ChangePlayer();
    }

    // 현재 플레이어 변경 함수
    public void ChangePlayer()
    {

        Bounce numGoal = GameObject.Find("Ball").GetComponent<Bounce>();

        // 점수 데이터 저장
        GameFlowManager flowM = GameObject.Find("GameFlow").GetComponent<GameFlowManager>();
        flowM.score[pm] += numGoal.numGoal;
        Debug.Log(pm + 1 + "번째 플레이어의 제기 점수: " + numGoal.numGoal + "/ 총 점수: " + flowM.score[pm].ToString());

        // 현재 게임 씬에서 점수 반영 -> 현재점수로
        //GoalList[pm].text = flowM.score[pm].ToString();
        GoalList[pm].text = numGoal.numGoal.ToString();

        numGoal.numGoal = 0;    //현재점수 초기화

        // 플레이어 원위치
        PlayerList[pm].transform.position = new Vector2(960.0f, 535.0f);

        // 다음 차례의 리스트로
        //if (pm == 3) pm = 0;
        //else pm++;
        pm++;

        // 4명 모두 한 경우에는 다음 플로우로
        if (pm == 4)
        {
            Debug.Log("다음 게임");

            if (flowM.game == 1)
            {
                flowM.StartSecond(); Debug.Log("제기차기 완료. 두번째 게임: " + flowM.gameflow[1]);
            }
            else if (flowM.game == 2)
            {
                flowM.StartThird(); Debug.Log("제기차기 완료. 세번째 게임: " + flowM.gameflow[2]);
            }
            else if (flowM.game == 3)
            {
                SceneManager.LoadScene("09_GameResult");
                Debug.Log("제기차기 완료. 결과 화면으로");
            }
        }
        else
        {
            // 현재 플레이어만 활성화
            PlayerList[0].SetActive(false);
            PlayerList[1].SetActive(false);
            PlayerList[2].SetActive(false);
            PlayerList[3].SetActive(false);

            PlayerList[pm].SetActive(true);

            // 플레이어, 제기 위치 원상태로
            ball.transform.position = new Vector2(1021.0f, 890.0f);
            rigidBall.velocity = new Vector2(0, 0);

            // 카운트다운
            StartCoroutine(ReadyDelay());

            Invoke("Start", 1f);
        }
    }


    // 카운트다운 코루틴
    IEnumerator ReadyDelay()
    {
        if (pm == 0)
        {
            ready_1.SetActive(true);
        }
        else if (pm == 1)
        {
            ready_2.SetActive(true);
        }
        else if (pm == 2)
        {
            ready_3.SetActive(true);
        }
        else if (pm == 3)
        {
            ready_4.SetActive(true);
        }

        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 6.0f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        ready_1.gameObject.SetActive(false);

        if(pm==1)
        {
            ready_2.SetActive(false);
        }
        else if(pm==2)
        {
            ready_3.SetActive(false);
        }
        else if(pm==3)
        {
            ready_4.SetActive(false);
        }

        Time.timeScale = 1.0f;
    }
}
