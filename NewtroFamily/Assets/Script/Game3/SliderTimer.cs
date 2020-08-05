using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{
    //타이머 변수
    public GameObject game_status;
    public Slider timeSlider;
    public Text timerText;
    public float gameTime;

    private bool stopTimer;

    //리소스
    public Sprite finish_img;

    // Start is called before the first frame update
    void Start()
    {
        //타이머 초기화
        stopTimer = false;
        timeSlider.value = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        float time = gameTime - Time.time;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0}", seconds);

        if (time <= 0)
        {
            stopTimer = true;
            game_status.GetComponent<Image>().sprite = Resources.Load("Resources/06Game3/finish") as Sprite;
        }

        if (stopTimer == false)
        {
            timerText.text = textTime;
            timeSlider.value = time;
        }
    }
}
