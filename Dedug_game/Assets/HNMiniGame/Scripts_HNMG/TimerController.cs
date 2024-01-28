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

    // 게임 일시정지 상태를 나타내는 변수
    public bool isGamePaused = false;


    public void Start()
    {
        // 초기화
        timer = 30f;
        readyCounter = 4f;
        showCounter = 4f;
        timerSlider.maxValue = timer;
        timerSlider.value = timer;

        mainController.Main_BGM2.Play();         // 메인 BGM 재생
        mainController.correct_sfx.Stop();       // correct_sfx 정지
        mainController.error_sfx.Stop();         // error_sfx 정지
        mainController.Result_SFX.Stop();        // Result_SFX 정지
        mainController.readyCount_SFX.Stop();    // readyCount_SFX 정지
        readyCount_SFX.Stop();

        // 레디 카운트를 1초 뒤에 1초마다 실행
        InvokeRepeating("ReadyCounter", 0, 1f);
        Input.multiTouchEnabled = false;
    }

    public void ReadyCounter()
    {
        Debug.Log("ReadyCounter");

        // 게임이 일시 정지 중일 경우 반환
        if (isGamePaused)
            return;

        readyCounter -= 1f;                             // 대기 시간 1초씩 감소
        readyCountBG.gameObject.SetActive(true);        // 대기 시간 BG 띄워
        readyCount.text = readyCounter.ToString();      // 대기 시간 출력
        readyCount_SFX.Play();                          // 대기 시간 효과음 넣어

        if (readyCounter == 0)
        {
            readyCounter = 0;                           // 대기 시간 0
            readyCount_SFX.Stop();                      // 대기 시간 효과음 멈춰
            readyCountBG.gameObject.SetActive(false);   // 대기 시간 BG 내려
            CancelInvoke("ReadyCounter");

            // 타이머를 1초 뒤에 1초마다 실행
            InvokeRepeating("GamePlay", 0, 1);
        }
    }

    public void ShowCounter()
    {
        showCounter -= 1f;
        showMessage.gameObject.SetActive(true);
        showMessage.text = showCounter.ToString() + "초 후 이미지가 사라집니다.";


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
        mainController.Main_BGM2.Stop();
        mainController.Result_SFX.Play();

        mainController.isGameRunnig = false;
        mainController.ResultBGBG.gameObject.SetActive(true);
        mainController.pauseBG.gameObject.SetActive(true);

        // 어떤 컴포넌트에 배정할거임?
        mainController.ResultBGBG = GameObject.Find("ResultBGBG").GetComponent<Image>();
        mainController.ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        mainController.Restart = GameObject.Find("Restart").GetComponent<Button>();
        mainController.HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        mainController.UserScore = GameObject.Find("UserScoretxt").GetComponent<Text>();
    }




}
