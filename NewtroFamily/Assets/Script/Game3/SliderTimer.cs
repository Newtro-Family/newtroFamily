﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{
    //타이머 변수
    public Slider timeSlider;
    public Text timerText;
    private float gameTime;

    public bool stopTimer;

    // Start is called before the first frame update
    void Start()
    {
        //타이머 초기화
        stopTimer = true;
        timeSlider.maxValue = 30f;
        timeSlider.value = gameTime;
        gameTime = 30f;

    }

    // Update is called once per frame
    void Update()
    {
        stopTimer = false;
        timeSlider.enabled = true;

            float time = gameTime - Time.time;

            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);

            string textTime = string.Format("{0:0}", seconds);

            if (time <= 0)
            {
                stopTimer = true;
            }

            if (stopTimer == false)
            {
                timerText.text = textTime;
                timeSlider.value = time;
            }
        
        
    }
}
