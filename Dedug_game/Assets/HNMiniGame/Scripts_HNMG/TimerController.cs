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
    public MainController mainController;

    public Slider timerSlider;           // 게임 시간 UI 슬라이더 연결
    public float timer = 30f;            // 게임 시간 30초 설정
    public float readyCounter = 3f;      // 대기 시간 3초 설정
    public float showCounter = 3f;       // 쇼잉 시간 3초 설정
    public Text timerText;               // 게임 시간 출력
    public Text readyCount;              // 대기 시간 출력
    public Text showMessage;             // 쇼잉 메세지 출력
    public Image readyCountBG;           // 대기 시간 BG
    public AudioSource readyCount_SFX;   // 대기 시간 효과음

    
    public void Start()
    {
        // 초기화
        timer = 30f;
        readyCounter = 3f;
        showCounter = 4f;
        timerSlider.maxValue = timer;
        timerSlider.value = timer;

        readyCount_SFX.Stop();

        // 레디 카운트를 1초 뒤에 1초마다 실행
        InvokeRepeating("ReadyCounter", 0, 1f);                
       
    }

    public void ReadyCounter()
    {
        // 게임이 일시 정지 중일 경우 반환
        if (mainController.isGamePaused)
            return;
       
        readyCountBG.gameObject.SetActive(true);              
        readyCount.text = readyCounter.ToString();
        readyCounter -= 1f; // 타이머 감소
        readyCount_SFX.Play();

        // 슬라이더 값 갱신
        timerSlider.value = timer;

        if (readyCounter < 0)
        {
            readyCount_SFX.Stop();
            ShowCounter();
        }
    }

    public void ShowCounter()
    {
        showCounter -= 1f;
        showMessage.gameObject.SetActive(true);
        showMessage.text = showCounter.ToString() + "초 후 이미지가 사라집니다.";
        readyCountBG.gameObject.SetActive(false);

        if (showCounter <= 0)
        {
            showMessage.gameObject.SetActive(false);
            showCounter = 0;
            UpdateTimer();

        }
    }
    public void UpdateTimer()
    {
        // 게임이 일시 정지 중일 경우 반환
        if (mainController.isGamePaused)
            return;

        // 게임이 진행중일 경우
        if (mainController.isGameRunnig == true)
        {
            showCounter = 0f;
            timerText.text = timer.ToString("F0");  // 1의 자리부터 표현
            timer -= 1f; // 타이머 감소

            // 슬라이더 값 갱신
            timerSlider.value = timer;

            // 타이머가 끝나면 (0까지 보기 위해 -1로 설정)
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
        mainController.pauseBG.gameObject.SetActive(true);
        mainController.pauseBG1.gameObject.SetActive(true);
        mainController.Main_BGM2.Stop();
        mainController.isGameRunnig = false;

        // 어떤 컴포넌트에 배정할거임?
        mainController.ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        mainController.ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        mainController.Restart = GameObject.Find("Restart").GetComponent<Button>();
        mainController.HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        mainController.UserScore = GameObject.Find("UserScoretxt").GetComponent<Text>();
        mainController.Main_BGM2.Stop();
    }




}
