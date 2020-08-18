using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerTest : MonoBehaviour
{
    public Slider timerSlider;
    public Text timerText;
    public float gameTime;

    private float endTime;
    private bool isTimer = false;


    public void StartTimer(float time)
    {
        endTime = Time.time + time;
        timerSlider.maxValue = time;
        isTimer = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartTimer(gameTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimer)
        {
            float time = endTime - Time.time;

            if (time <= 0.0f)
            {
                UpdateSlider(0.0f);
                isTimer = false;
            }
            else
                UpdateSlider(time);
        }
    }

    private void UpdateSlider(float time)
    {
        timerText.text = string.Format("{0:0}", time);
        timerSlider.value = time;
    }
}
