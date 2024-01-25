using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource BGM1;
    public AudioSource BGM2;
    public AudioSource SFX1;
    public AudioSource SFX2;
    public AudioSource SFX3;
    public AudioSource SFX4;
    public AudioSource SFX5;
    public AudioSource SFX6;
    public AudioSource SFX7;
    public AudioSource SFX8;

    public void Awake()
    {
        DataManager.Instance.bgm = PlayerPrefs.GetInt("BGM");
        DataManager.Instance.sfx = PlayerPrefs.GetInt("SFX");
    }

    // 배경음악 재생
    public void Update()
    {
        if (DataManager.Instance.bgm == 0)
        {
            BGM1.volume = 100;
            BGM2.volume = 100;


        }
        else if (DataManager.Instance.bgm == 1)
        {

            BGM1.volume = 0;
            BGM2.volume = 0;

        }

        if (DataManager.Instance.sfx == 0)
        {

            SFX1.volume = 100;
            SFX2.volume = 100;
            SFX3.volume = 100;
            SFX4.volume = 100;
            SFX5.volume = 100;
            SFX6.volume = 100;
            SFX7.volume = 100;
            SFX8.volume = 100;

        }
        else if (DataManager.Instance.sfx == 1)
        {

            SFX1.volume = 0;
            SFX2.volume = 0;
            SFX3.volume = 0;
            SFX4.volume = 0;
            SFX5.volume = 0;
            SFX6.volume = 0;
            SFX7.volume = 0;
            SFX8.volume = 0;
        }
    }
}


    

