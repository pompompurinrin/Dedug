using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class TimerController: MonoBehaviour
{
    public Slider timerSlider; // UI 슬라이더 연결
    public float timer = 30f; // 제한 시간 30초 설정
    public Text timeText; // 시간 출력
    public float readyCounter = 3f; //대기 시간 3초 설정
    public Text readyCount; // 대기 시간 출력

    [SerializeField] private MainController mainController;
    
    public void Start()
    {
        // 슬라이더 초기화
        timerSlider.maxValue = timer;
        timerSlider.value = timer;

        InvokeRepeating("ReadyCounter", 0f, 1f);                
       
    }

    public void ReadyCounter()
    {

        if (mainController.isGamePaused)
            return;
        
        readyCount.gameObject.SetActive(true);  
        readyCount.text = readyCounter.ToString() + "초 후 이미지가 사라집니다.";
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
        if (mainController.isGamePaused)
            return;

        if(mainController.isGameRunnig == true)
        {
            readyCount.gameObject.SetActive(false);
            mainController.Scoretxt.gameObject.SetActive(true);


            timeText.text = timer.ToString("F0");  // 1의 자리부터 표현
            timer -= 1f; // 타이머 감소

            // 슬라이더 값 갱신
            timerSlider.value = timer;

            if (timer <= -1)
            {

                timer = -1;
                TimeOver();
                mainController.isGameRunnig = false;
                

            }
        }
       
    }


  

    // 시간이 다 되면 게임 오버 화면을 활성화
    public void TimeOver()
    {
        mainController.Score();
        mainController.isGameRunnig = false;
        timer = 30;
        mainController.ResultBG.gameObject.SetActive(true);

        // 어떤 컴포넌트에 배정할거임?
        mainController.ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        mainController.ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        mainController.Restart = GameObject.Find("Restart").GetComponent<Button>();
        mainController.HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        mainController.UserScore = GameObject.Find("UserScoretxt").GetComponent<Text>();
        mainController.Main_BGM2.Stop();
    }




}
