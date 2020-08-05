using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//게임 시작 전 화면 

public class GameReadyManager : MonoBehaviour
{
    //리소스 
    static public Sprite player_call, three,two,one;

    //변수
    private int count = 3;
    public GameObject player_ready,countdown;
    //private SpriteRenderer renderer;
    int readyNo = 1;

    // Start is called before the first frame update
    void Start()
    { 
        InvokeRepeating("Countdown",2.0f,1.0f);
    }

    // Update is called once per frame
    public void Playerturn()
    {

        /*if (readyNo == 1)
        {*/
            player_ready.GetComponent<Image>().sprite = Resources.Load("Resources/06Game3/ready" + readyNo) as Sprite;
            readyNo++;
       /* }
        else if (readyNo ==2)
        {
            player_ready.GetComponent<Image>().sprite = Resources.Load("Resources/06Game3/ready" + readyNo) as Sprite;
        }
        else if(readyNo == 3)
        {
            renderer.sprite = Resources.Load("Resources/06Game3/ready" + readyNo) as Sprite;
        }*/

    }

    void Countdown()
    {
        player_ready.SetActive(false);
        countdown.SetActive(true);

        Debug.Log("hello");
        if(count==3)
        {
            countdown.GetComponent<Image>().sprite = Resources.Load("Resources/06Game3/ready" + count) as Sprite;
            count--;
        }
        else if (count==2)
        {
            countdown.GetComponent<Image>().sprite = Resources.Load("Resources/06Game3/ready" + count) as Sprite;
            count--;
        }
        else if(count ==1)
        {
            countdown.GetComponent<Image>().sprite = Resources.Load("Resources/06Game3/ready" + count) as Sprite;
            count--;
        }
    }

    void Update()
    {
        if(count>=0)
        {
            CancelInvoke("Countdown");
            SceneManager.UnloadSceneAsync("08_GameReady");
        }
    }

    public void Go_Game()
    {
        SceneManager.UnloadSceneAsync("08_GameReady");
    }
}
