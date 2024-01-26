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

    public Slider timerSlider;           // 게임 시간 UI 슬라이더 연결
    public float timer = 30f;            // 게임 시간 30초 설정
    public float readyCounter = 3f;      // 대기 시간 3초 설정
    public Text timerText;               // 게임 시간 출력
    public Text readyCount;              // 대기 시간 출력
    public Image readyCountBG;           // 대기 시간 BG
    public AudioSource readyCount_SFX;   // 대기 시간 효과음

    GameObject Player;

    private void Awake()
    {
        Input.multiTouchEnabled = false;
        this.Player = GameObject.Find("Player");
    }

    public void Start()
    {
        Debug.Log("초기화");

        // 초기화
        timer = 60f;
        readyCounter = 3f;
        timerSlider.maxValue = timer;
        timerSlider.value = timer;

        readyCount_SFX.Stop();

        // 레디 카운트를 1초 뒤에 1초마다 실행
        InvokeRepeating("ReadyCounter", 0, 1f);

        mainController2.MagicalGirlsPrefab.gameObject.SetActive(true);
        Debug.Log("MagicalGirlsPrefab.gameObject.SetActive(true);");
        mainController2.ObstaclePrefab.gameObject.SetActive(true);
        Debug.Log("ObstaclePrefab.gameObject.SetActive(true);");
        mainController2.StudentPrefab.gameObject.SetActive(true);
        Debug.Log("StudentPrefab.gameObject.SetActive(true);");
      
    }

    public void ReadyCounter()
    {
        // 게임이 일시 정지 중일 경우 반환
        if (mainController2.isGamePaused)
            return;

        readyCounter -= 1f; // 타이머 감소
        readyCountBG.gameObject.SetActive(true);
        readyCount.text = readyCounter.ToString();
        readyCount_SFX.Play();

        // 슬라이더 값 갱신
        timerSlider.value = timer;

        if (readyCounter < 0)
        {
            readyCounter = 0;
            readyCount_SFX.Stop();
            readyCountBG.gameObject.SetActive(false);

            UpdateTimer();
        }
    }

    public void UpdateTimer()
    {
        // 게임이 일시 정지 중일 경우 반환
        if (mainController2.isGamePaused)
            return;

        if (mainController2.isGameRunnig == true)
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
                mainController2.isGameRunnig = false;
            }
        }
    }
    // 시간이 다 되면 게임 오버 화면을 활성화
    public void TimeOver() 
    {
        Debug.Log("타임 오버");

        mainController2.heal_fx.transform.position = new Vector3(0, -5000, 1);
        Debug.Log("힐 효과 날리기");
        mainController2.hit_fx.transform.position = new Vector3(0, -5000, 1);
        Debug.Log("피격 효과 날리기");

        mainController2.Score();
        mainController2.Main_BGM.Stop();

        mainController2.isGameRunnig = false;
        mainController2.ResultBGBG.gameObject.SetActive(true);
        mainController2.pauseBG.gameObject.SetActive(true);

        // 어떤 컴포넌트에 배정할거임?
        mainController2.ResultBGBG = GameObject.Find("ResultBGBG").GetComponent<Image>();
        mainController2.ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        mainController2.Restart = GameObject.Find("Restart").GetComponent<Button>();
        mainController2.HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        mainController2.UserScore = GameObject.Find("UserScoretxt").GetComponent<Text>();
    }

}
