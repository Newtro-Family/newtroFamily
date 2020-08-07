using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game3Manager : MonoBehaviour
{
    public PlayerNumManager PM;
    public GameObject playerMananger;
    
    //UI
    public GameObject player1, player2, player3, player4; //플레이어 점수판 오브젝트
    //public GameObject tutorial;

    public GameObject go_correct, go_wrong;
    public Text t_question, t_count;
    public Text[] Txts_option; //size=8
    public Button[] Btns_option; //size=8

    //변수
    char[] corrects = new char[8];
    bool wrong = false;
    int count,page = 0;
    int quiz_num = 1;
    StringReader q_stringReader;
    string c_tmp;

    //상수
    const string LOCATION = "quiz/";
    readonly char[] corrects1 = { '1', '4', '3', '2', '2', '3','6','8' };
    readonly char[] corrects2 = { '1', '4', '3', '2', '2', '3', '6', '8' };
    readonly char[] corrects3 = { '1', '4', '3', '2', '2', '3', '6', '8' };
    readonly char[] corrects4 = { '1', '4', '3', '2', '2', '3', '6', '8' };
    readonly WaitForSeconds term = new WaitForSeconds(1f);

    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 0.0f; //게임 시간

        PM = GameObject.Find("playernum").GetComponent<PlayerNumManager>();
        //플레이어 수 선정
        if (PM.player_num==1)
        {
            player2.SetActive(true);
        }
        else if(PM.player_num == 2)
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

        //정답 설정
        switch (q_file_name)
        {
            case "quiz1":
                corrects = corrects1;
                break;

            case "quiz2":
                corrects = corrects2;
                break;

            case "quiz3":
                corrects = corrects3;
                break;

            case "quiz4":
                corrects = corrects4;
                break;
        }
        //게임 설명, 카운트다운 씬 실행
        //LoadSceneAdditive();
    }

    //private 함수들 ------------------------------------------------------------------------------
    void Next_Question()
    {
        page++;
        Reset();
    }

    void SetQuiz()
    {
        t_question.text = q_stringReader.ReadLine();
        for(int i=0; i<8; i++)        
            Txts_option[i].text = q_stringReader.ReadLine();
        
    }

     void Reset()
    {
        //내용 설정
        SetQuiz();
        for(int i=0; i <8; i++)
        {
            Btns_option[i].interactable = true;
        }
       
    }

    //public 함수들 ------------------------------------------------------------------------
    public void Select(int num)
    {
        Button option = Btns_option[num - 1];
        Text t_option = Txts_option[num - 1];

        //정답 이벤트
        if (num.Equals(corrects[page]-'0'))
        {
            for(int i=0; i<8; i++)
                Btns_option[i].interactable = false;

            if (wrong)
                wrong = false;
            else
                count++;

            StartCoroutine(Routine_check(true));
        }

        //오답 이벤트
        else
        {
            option.interactable = false;

            wrong = true;

            StartCoroutine(Routine_check(false));
        }
    }

    IEnumerator Routine_check(bool correct)
    {
        GameObject check;
        if (correct)
        {
            go_wrong.SetActive(false);
            check = go_correct;
        }
        else
            check = go_wrong;
        check.SetActive(true);

        yield return term;

        check.SetActive(false);
    }

    // Update is called once per frame
    public void LoadSceneAdditive()
    {
        SceneManager.LoadScene("08_GameReady",LoadSceneMode.Additive);
    }

    /*public void Go_Game()
    {
        tutorial.SetActive(false);
    }*/
}
