﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//사운드의 기본 구성에 대한 스크립트

public class SoundManager : MonoBehaviour
{
    //싱글톤 인스턴스
    public static SoundManager Instance = null;

    //할당 받을 오디오 관련 컴포넌트 및 리소스
    public AudioSource Game_bgm, Game_effect;
    public AudioClip bgm_main, effect1, effect2;

    public object Value_BGM { get; internal set; }
    public object Value_Effect { get; internal set; }

    //싱글톤 구현
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(Instance ==null)
        {
            Instance = this;
            ChangeScene.Instance = GetComponent<ChangeScene>();
        }
        else if (Instance !=this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }
    // 소리값 초기화
    void Start()
    {
        Game_bgm.volume = PlayerPrefs.GetFloat("tmp_bgm", 1f);
        Game_effect.volume = PlayerPrefs.GetFloat("tmp_effect", 1f);
       
    }

    //Effect 선택 play
    public void Play_effect(int num)
    {
        if (num.Equals(1))
            Game_effect.PlayOneShot(effect1);
        else if (num.Equals(2))
            Game_effect.PlayOneShot(effect2);

    }


    //BGM 소리 크기 설정
    public void SetBGM_Volume(float v)
    {
        Game_bgm.volume = v;
    }
   
}
