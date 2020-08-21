using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//슬라이더를 통해 소리의 설정 값을 다루는 스크립트

public class SoundController : MonoBehaviour
{
    //객체 할당
    public Slider s_bgm, s_effect;

    private AudioSource bgm;
    private AudioSource effect;

    //변수
    private float value_effect = 1f;
    private float value_bgm = 1f;


    // 초기화
    void Start()
    {
        bgm = SoundManager.Instance.Game_bgm;
        effect = SoundManager.Instance.Game_effect;

        //슬라이더 초기화
        s_bgm.value = bgm.volume;
        s_effect.value = effect.volume;
    }
    
    //배경음악 설정
    public void SetBGM()
    {
        value_bgm = s_bgm.value;
        bgm.volume = value_bgm;
        PlayerPrefs.SetFloat("tmp_bgm", value_bgm);
    }

    //효과음 설정
    public void SetEffect()
    {
        value_effect = s_effect.value;
        effect.volume = value_effect;
        PlayerPrefs.SetFloat("tmp_effect", value_effect);
    }
}
