using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class TimeController2 : MonoBehaviour
{
    public MainController2 mainController2;

    public Slider timerSlider; // UI 슬라이더 연결
    public float timer = 60f; // 제한 시간 30초 설정
    public Text timeText; // 시간 출력

    public float readyCounter = 3f; //대기 시간 3초 설정
    public Text readyCount; // 대기 시간 출력

    GameObject Player;

    private void Awake()
    {
        this.Player = GameObject.Find("Player");
    }

    public void Start()
    {
        Debug.Log("초기화");

        // 슬라이더 초기화
        timerSlider.maxValue = timer;
        timerSlider.value = timer;

        //Invoke("Timer", 4);
        InvokeRepeating("ReadyCounter", 0f, 1f);

        //PercentageTable_1에서 배열을 사용할게
        mainController2.data_Dialog = CSVReader.Read("PercentageTable");
    }

    public void Timer()
    {
        // 1초마다 타이머 업데이트
        InvokeRepeating("UpdateTimer", 0f, 1f);
    }

    public void ReadyCounter()
    {
        if (mainController2.isGamePaused)
            return;

        readyCount.gameObject.SetActive(true);  
        readyCount.text = readyCounter.ToString() + "초 후 시작합니다.";
        readyCounter -= 1f; // 타이머 감소

        // 슬라이더 값 갱신
        timerSlider.value = timer;

        if (readyCounter <= -1)
        {
            readyCounter = -1;            
            UpdateTimer();
        }
    }

    public void UpdateTimer()
    {
        if (mainController2.isGamePaused)
            return;
        if (mainController2.isGameRunnig == true)
        {
            readyCount.gameObject.SetActive(false);
            mainController2.Scoretxt.gameObject.SetActive(true);

            timeText.text = timer.ToString("F0");  // 1의 자리부터 표현
            timer -= 1f; // 타이머 감소

            // 슬라이더 값 갱신
            timerSlider.value = timer;

            if (timer <= -1)
            {
                timer = -1;
                TimeOver();
                mainController2.isGameRunnig = false;
            }
        }
    }
    
    public void TimeOver() // 시간이 다 되면 게임 오버 화면을 활성화
    {     
        // 초기화 세팅
        this.Player.transform.position = new Vector3(0, -5, 1);
        timer = 60f;
        mainController2.isGameRunnig = false;
        mainController2.Score();
        mainController2.ResultBG.gameObject.SetActive(true);
        mainController2.Main_BGM.Stop();

        // 어떤 컴포넌트에 배정할거임?
        mainController2.ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        mainController2.ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        mainController2.Restart = GameObject.Find("Restart").GetComponent<Button>();
        mainController2.HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        mainController2.UserScore = GameObject.Find("UserScoretxt").GetComponent<Text>();
    }

}
