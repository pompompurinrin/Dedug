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
        this.Player = GameObject.Find("Player");
    }

    public void Start()
    {
        // 초기화
        Debug.Log("초기화");
        timer = 60f;
        readyCounter = 3f;
        timerSlider.maxValue = timer;
        timerSlider.value = timer;
        //this.Player.transform.position = new Vector3(0, -5, 1);

        readyCount_SFX.Stop();

        // 레디 카운트를 1초 뒤에 1초마다 실행
        InvokeRepeating("ReadyCounter", 0f, 1f);

        // 오브젝트 활성화 ( 이건 왜 추가 되었는지 확인 필요 )
        mainController2.MagicalGirlsPrefab.gameObject.SetActive(true);
        Debug.Log("첫 시작시 마법 소녀 소환");
        mainController2.ObstaclePrefab.gameObject.SetActive(true);
        Debug.Log("첫 시작시 장애물 소환");
        mainController2.StudentPrefab.gameObject.SetActive(true);
        Debug.Log("첫 시작시 일반 학생 소환");
    }

    public void ReadyCounter()
    {
        // 게임이 일시 정지 중일 경우 반환
        if (mainController2.isGamePaused)
            return;

        readyCountBG.gameObject.SetActive(true);
        readyCount.text = readyCounter.ToString();
        readyCounter -= 1f; // 타이머 감소
        readyCount_SFX.Play();

        // 슬라이더 값 갱신
        timerSlider.value = timer;

        if (readyCounter < 0)
        {
            readyCountBG.gameObject.SetActive(false);
            readyCount_SFX.Stop();
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
            readyCounter = 0;
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
        
        //Player.gameObject.SetActive(false);
        //mainController2.MagicalGirlsPrefab.gameObject.SetActive(false);
        //mainController2.ObstaclePrefab.gameObject.SetActive(false);
        //mainController2.StudentPrefab.gameObject.SetActive(false);

        // 게임이 끝나면 파티클 이펙트 날리기 >> 다른 방법 강구 중
        mainController2.heal_fx.transform.position = new Vector3(0, -5000, 1);
        Debug.Log("mainController2.heal_fx.transform.position = new Vector3(0, -5000, 1);");
        mainController2.hit_fx.transform.position = new Vector3(0, -5000, 1);
        Debug.Log("mainController2.hit_fx.transform.position = new Vector3(0, -5000, 1);");

        mainController2.Score();
        mainController2.ResultBG.gameObject.SetActive(true);
        mainController2.pauseBG.gameObject.SetActive(true);
        mainController2.pauseBG1.gameObject.SetActive(true);
        mainController2.Main_BGM.Stop();
        mainController2.isGameRunnig = false;

        // 어떤 컴포넌트에 배정할거임?
        mainController2.ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        mainController2.ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        mainController2.Restart = GameObject.Find("Restart").GetComponent<Button>();
        mainController2.HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        mainController2.UserScoretxt = GameObject.Find("UserScoretxt").GetComponent<Text>();
    }
}
