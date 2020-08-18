﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game3Manager : MonoBehaviour
{
    public PlayerNumManager PM;
    public GameObject playerMananger,Timer;

    //UI
    public GameObject player1, player2, player3, player4; //플레이어 점수판 오브젝트

    public GameObject go_correct, go_wrong, quiz_status;
    public GameObject ready_2;
    public GameObject t_1, t_2, t_3, t_4, t_5, t_6, t_7, t_8;
    public Text t_question, t_count, p1_count, p2_count,p3_count,p4_count;
    public Text[] Txts_option; //size=8
    public Button[] Btns_option; //size=8

    //변수
    char[] corrects = new char[10];
    bool wrong = false;
    int count, page = 0;
    public int quiz_num = 1;
    public int p_num = 0;
    StringReader q_stringReader;
    string c_tmp;

    //타이머 변수
    public Slider timerSlider;
    public Text timerText;
    public float gameTime;

    private float endTime;
    private bool isTimer = false;


    //상수
    const string LOCATION = "quiz/";
    readonly char[] corrects1 = { '1', '4', '3', '2', '7', '5', '6', '8' };
    readonly char[] corrects2 = { '2', '6', '3', '8', '5', '4', '1', '7' };
    readonly char[] corrects3 = { '1', '4', '3', '2', '7', '5', '6', '8' };
    readonly char[] corrects4 = { '2', '6', '3', '8', '5', '4', '1', '7' };
    readonly WaitForSeconds term = new WaitForSeconds(1f);
    readonly WaitForSeconds start_term = new WaitForSeconds(2f); //딱지 보여지는 시간
    readonly WaitForSeconds next_turn = new WaitForSeconds(1.5f); //다음 플레이어 대기 시간 

    // Start is called before the first frame update
    void Start()
    {
        //카운트 초기화
        count = 0;
        //타이머 시작 
        StartTimer(gameTime);

        PM = GameObject.Find("playernum").GetComponent<PlayerNumManager>();

        //플레이어 수 선정
        if (PM.player_num == 1)
        {
            player2.SetActive(true);
        }
        else if (PM.player_num == 2)
        {
            player2.SetActive(true);
            player3.SetActive(true);
        }
        else if (PM.player_num == 3)
        {
            player2.SetActive(true);
            player3.SetActive(true);
            player4.SetActive(true);
        }


        //퀴즈 
        string q_file_name = "quiz" + quiz_num;

        //퀴즈 내용 불러오기
        TextAsset q_file = Resources.Load(LOCATION + q_file_name) as TextAsset;
        //page 초기화
        page = 0; 


#if DEV_TEST
        //파일 존재 여부 체크
        if(q_file.Equals(null))
        {
            print("Error : 파일명 체크 부탁");
            return;
        }
#endif
        q_stringReader = new StringReader(q_file.text);
        SetQuiz();
        StartCoroutine(Start_Delay());

        //정답 설정
        switch (q_file_name)
        {
            case "quiz1":
                corrects = corrects1;
                p_num = 1;
                break;

            case "quiz2":
                corrects = corrects2;
                p_num = 2;
                break;

            case "quiz3":
                corrects = corrects3;
                p_num = 3;
                break;

            case "quiz4":
                corrects = corrects4;
                p_num = 4;
                break;
        }

        //플레이어 턴에 맞게 크기 변경
        switch (quiz_num)
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

        // 옵션 초기화
        t_1.SetActive(true);
        t_2.SetActive(true);
        t_3.SetActive(true);
        t_4.SetActive(true);
        t_5.SetActive(true);
        t_6.SetActive(true);
        t_7.SetActive(true);
        t_8.SetActive(true);

        for(int i=0;i<8;i++)
        {
            Button option = Btns_option[i];
            Btns_option[i].interactable = true;
        }
    }

    void Update()
    {
        if (isTimer)
        {
            float time = endTime - Time.time;

            if (time <= 0.0f)
            {
                UpdateSlider(0.0f);
                isTimer = false;

                if (p_num == 1)
                {
                    p1_count.text = count.ToString();
                }
                else if (p_num == 2)
                {
                    p2_count.text = count.ToString();
                }
                else if (p_num == 3)
                {
                    p3_count.text = count.ToString();
                }
                else if (p_num == 4)
                {
                    p4_count.text = count.ToString();
                }

                quiz_num++;

                // Game2로 넘어가기
                if (quiz_num == 5)
                {
                    SceneManager.LoadScene("05_Game2");
                    Debug.Log("게임2로딩");
                }

                StartCoroutine(ReadyDelay());

                Invoke("Start", 1f);
            }
            else
                UpdateSlider(time);
        }
    }

    //private 함수들 ------------------------------------------------------------------------------
    private void UpdateSlider(float time)
    {
        timerText.text = string.Format("{0:0}", time);
        timerSlider.value = time;
    }

    void Wrong_3times()
    {
        Invoke("Next_Question", 1f);
    }

    void Next_Question()
    {
        page++;
        Reset();
    }

    void SetQuiz()
    {
        t_question.text = q_stringReader.ReadLine();
        t_count.text = count.ToString();

        for (int i = 0; i < 8; i++)
            Txts_option[i].text = q_stringReader.ReadLine();

    }

    void Reset()
    {
        //내용 설정
        SetQuiz();

        for (int i = 0; i < 8; i++)
        {
            Btns_option[i].interactable = true;
        }

    }

    //public 함수들 ------------------------------------------------------------------------
    public void StartTimer(float time)
    {
        endTime = Time.time + time;
        timerSlider.maxValue = time;
        isTimer = true;
    }

    public void Select(int num)
    {
        Button option = Btns_option[num - 1];
        Text t_option = Txts_option[num - 1];
        GameObject _option;

        //정답 이벤트
        if (num.Equals(corrects[page] - '0'))
        {

            // 정답일 때 글자 활성화
            for (int i = 0; i < 8; i++)
            {
                _option = GameObject.Find("option_" + num).transform.Find("t_" + num).gameObject;
                _option.SetActive(true);
            }

            if (wrong)
                wrong = false;


            StartCoroutine(Routine_check(true));

            //모두 다 맞췄을 때
            if (page.Equals(7))
            {
                if (p_num == 1)
                {
                    p1_count.text = count.ToString();
                }
                else if (p_num == 2)
                {
                    p2_count.text = count.ToString();
                }
                else if (p_num == 3)
                {
                    p3_count.text = count.ToString();
                }
                else if (p_num ==4)
                {
                    p4_count.text = count.ToString();
                }

                quiz_status.SetActive(true);
                StartCoroutine(ReadyDelay());

                Invoke("Start", 1f);
                quiz_num++;
                //count = 0;

            }
            else
            {
                Invoke("Next_Question", 1f);
            }
        }

        //오답 이벤트
        else
        {
            option.interactable = false;

            wrong = true;

            StartCoroutine(Routine_check(false));
            
        }
    }

    //코루틴 --------------------------------------------------------------------------------------------

    IEnumerator Start_Delay()
    {
        yield return start_term;

        t_1.SetActive(false);
        t_2.SetActive(false);
        t_3.SetActive(false);
        t_4.SetActive(false);
        t_5.SetActive(false);
        t_6.SetActive(false);
        t_7.SetActive(false);
        t_8.SetActive(false);


    }

    IEnumerator NextTurn()
    {
        yield return 0;
        quiz_status.SetActive(false);
    }

    IEnumerator Routine_check(bool correct)
    {
        GameObject check;
        if (correct)
        {
            go_wrong.SetActive(false);
            check = go_correct;
            count++;
        }
        else
            check = go_wrong;
            
        check.SetActive(true);

        yield return term;

        check.SetActive(false);
    }

    IEnumerator ReadyDelay()
    {
        quiz_status.SetActive(false);
        ready_2.SetActive(true);

        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 6.0f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        ready_2.gameObject.SetActive(false);

        Time.timeScale = 1.0f;
    }


}
