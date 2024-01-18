using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class TimerController2: MonoBehaviour
{
    public Slider timerSlider; // UI 슬라이더 연결
    public float timer = 60f; // 제한 시간 30초 설정
    public Text timeText; // 시간 출력
    public float readyCounter = 3f; //대기 시간 3초 설정
    public Text readyCount; // 대기 시간 출력


    [SerializeField] private MiniGame3Controller gameController2;
    


    public void Start()
    {
        // 슬라이더 초기화
        timerSlider.maxValue = timer;
        timerSlider.value = timer;

        //Invoke("Timer", 4);
        InvokeRepeating("ReadyCounter", 0f, 1f);

        //PercentageTable_1에서 배열을 사용할게
        gameController2.data_Dialog = CSVReader.Read("PercentageTable");
    }

    public void Timer()
    {
        // 1초마다 타이머 업데이트
        InvokeRepeating("UpdateTimer", 0f, 1f);
    }

    public void ReadyCounter()
    {

        if (gameController2.isGamePaused)
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
        if (gameController2.isGamePaused)
            return;

        readyCount.gameObject.SetActive(false);
        gameController2.getScoretxt.gameObject.SetActive(true);


        timeText.text = timer.ToString("F0");  // 1의 자리부터 표현
        timer -= 1f; // 타이머 감소

        // 슬라이더 값 갱신
        timerSlider.value = timer;

        if (timer <= -1)
        {

            timer = -1;
            TimeOver();

        }
    }


  

    // 시간이 다 되면 게임 오버 화면을 활성화
    public void TimeOver()
    {

        gameController2.Score();
        gameController2.ResultBG.gameObject.SetActive(true);
        // gameController2.Main_BGM2.Stop();
        // 어떤 컴포넌트에 배정할거임?
        gameController2.ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        gameController2.ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        gameController2.Restart = GameObject.Find("Restart").GetComponent<Button>();
        gameController2.HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        gameController2.getScoretxt = GameObject.Find("UserScoretxt").GetComponent<Text>();  //왜안되는거지ㅠㅠ
    }




}
