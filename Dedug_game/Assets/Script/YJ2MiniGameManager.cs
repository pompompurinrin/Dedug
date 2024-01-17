using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YJ2MiniGameManager : MonoBehaviour
{
    // 배경 및 수아 이미지
    public Image suaChar;
    public Image gameBg;

/*    // 사건 이미지
    public Image eventMon;
    public Image eventHeal;
    public Image eventFan;

    // 사건 마법 이미지
    public Image eventIconMon;
    public Image eventIconHeal;
    public Image eventIconFan;*/

    public GameObject[] eventIcons; // 이벤트 아이콘들을 배열로 관리
    public GameObject[] eventImage; // 이벤트 오브젝트들을 배열로 관리


    // 마법머신 아이콘 이미지
    public Image slotIcon01;
    public Image slotIcon02;
    public Image slotIcon03;
    public Sprite[] slotSprites; // slotIconMon, slotIconHeal, slotIconFan 스프라이트들을 배열로 관리

    // 스코어 판정 이미지
    public Image success;
    public Image fail;

    // 게임 대기시간 카운트
    public Text beforeCountText;
    public Image beforeImg;

    // 타이머 및 점수
    int beforeCount;
    int score;
    int timer;
    int slotTimer;
    int eventTimer;

    public Text scoreText;
    public Text timerText;

    // 타이머 슬라이더
    public Slider eventTimeSlider;
    public Slider slotTimeSlider;

    // 마법머신 버튼
    public Button slotButton;

    // 조건 선언
    bool mon;
    bool heal;
    bool fan;
    bool slotMon;
    bool slotHeal;
    bool slotFan;
    bool slotStart = false;

    // 게임 실행 조건
    bool isGameRunning;

    // 이벤트 타이머 조건
    bool isEventActive = false;



    private void Start()
    {
        // 게임 시작 시 호출되는 함수
        StartGame();
    }

    public void StartGame()
    {
        // 게임 대기시간 초기화 및 대기시간 UI 활성화
        beforeCount = 3;
        beforeCountText.gameObject.SetActive(true);
        beforeImg.gameObject.SetActive(true);

        // 게임 시간, 점수 초기화
        timer = 60;
        score = 0;

        // 게임 UI 업데이트
        UpdateUI();

        // 1초마다 CountDownBeforeGame 메소드 호출
        InvokeRepeating("CountDownBeforeGame", 1.0f, 1.0f);
    }

    private void UpdateUI()
    {
        // UI 업데이트 (제한시간, 점수)
        timerText.text = timer.ToString();
        scoreText.text = "Score: " + score.ToString();
    }

    // 게임 대기시간 관련
    private void CountDownBeforeGame()
    {

        // 게임 대기시간 카운트 다운
        beforeCount--;

        if (beforeCount == 0)
        {
            // 게임 대기시간 종료 후 숨김
            beforeCountText.gameObject.SetActive(false);
            beforeImg.gameObject.SetActive(false);
            // CountDownBeforeGame 호출 중단
            CancelInvoke("CountDownBeforeGame");

            // 실제 게임 시작
            StartRealTimeGame();
        }
        else
        {
            // 대기시간 텍스트 갱신
            beforeCountText.text = beforeCount.ToString();

        }
    }

    public void StartRealTimeGame()
    {
        // 실제 게임 시작
        isGameRunning = true;

        // 초기 제한시간 설정
        timerText.text = timer.ToString();

        // 1초마다 UpdateGame 메소드 호출
        InvokeRepeating("UpdateGame", 1.0f, 1.0f);

        // 게임 시작 시 랜덤으로 이벤트 선택
        ActivateRandomEvent();
    }


    public void UpdateGame()
    {
        if (isGameRunning)
        {
            // 타이머 감소
            timer--;

            // 이벤트 타이머 감소
            eventTimer--;

            // UI 업데이트
            UpdateUI();

            // 이벤트 타이머 슬라이더 업데이트
            UpdateEventSlider();

            // 타이머가 0이면 게임 종료
            if (timer == 0)
            {
                EndGame();
            }
        }
    }

    public void UpdateEventSlider()
    {
        // 이벤트 활성화 상태에서만 업데이트
        if (isEventActive)
        {
            // 이벤트 타이머 슬라이더 업데이트
            eventTimeSlider.value = eventTimer;
        }

        if (eventTimer == 0)
        {
            score--;
            UpdateUI();
            
            fail.gameObject.SetActive(true);
            Invoke("DeactivateFailImage", 0.5f);

            EventChange();
        }

    }
    private void ActivateRandomEvent()
    {
        // 이전에 활성화되어 있던 이벤트 비활성화
        DeactivateAllEvents();

        // 랜덤으로 이벤트 아이콘과 이벤트 활성화
        int randomIndex = UnityEngine.Random.Range(0, eventIcons.Length);
        eventIcons[randomIndex].SetActive(true);
        eventImage[randomIndex].SetActive(true);

        // 이벤트 활성화 상태로 변경
        isEventActive = true;

        // eventTimer를 10으로 초기화
        eventTimer = 10;
    }

    private void DeactivateAllEvents()
    {
        // 모든 이벤트 아이콘과 이벤트 비활성화
        foreach (var icon in eventIcons)
        {
            icon.SetActive(false);
        }

        foreach (var obj in eventImage)
        {
            obj.SetActive(false);
        }

        // 이벤트 비활성화 상태로 변경
        isEventActive = false;
    }

    public void EventChange()
    {
        // 이벤트 변경 시 다시 랜덤으로 이벤트 선택
        ActivateRandomEvent();
    }

    public void SlotButtonClicked()
    {
        // 처음 클릭했을 때만 slotTimer를 8초로 설정
        if (!slotStart)
        {
            slotTimer = 8;
        }

        if (slotStart == true)
        {
            slotTimer--;
        }

        // slotButton 클릭 시 실행되는 메소드
        slotStart = true;

        // 1초마다 SlotTimerCountdown 메소드 호출
        InvokeRepeating("SlotTimerCountdown", 1.0f, 1.0f);
    }


    private void SlotTimerCountdown()
    {
        // slotTimer 감소
        slotTimer--;
        slotTimeSlider.value = slotTimer;

        if (slotTimer < 0)
        {
            slotTimer = 0;
        }

        // slotTimer가 0이면 호출 중단하고 이미지 출력
        if (slotTimer == 0)
        {
            // 호출 중단
            CancelInvoke("SlotTimerCountdown");

            // slotStart를 false로 설정하여 더 이상 카운트다운을 하지 않도록 함
            slotStart = false;

            // 랜덤으로 이미지 출력
            ActivateRandomSlotIcons();

            // 슬롯 아이콘과 이벤트 아이콘 비교하여 스코어 처리
            CompareIconsAndScore();

        }
    }

    private void ActivateRandomSlotIcons()
    {
        // 랜덤으로 슬롯 아이콘 이미지 설정
        slotIcon01.sprite = slotSprites[UnityEngine.Random.Range(0, slotSprites.Length)];
        slotIcon02.sprite = slotSprites[UnityEngine.Random.Range(0, slotSprites.Length)];
        slotIcon03.sprite = slotSprites[UnityEngine.Random.Range(0, slotSprites.Length)];
    }

    private void CompareIconsAndScore()
    {
        int eventIconIndex = GetActiveEventIconIndex();

        // 이벤트 아이콘과 슬롯 아이콘 비교
        if (eventIconIndex != -1)
        {
            int matchingCount = CountMatchingIcons(eventIconIndex);

            if (matchingCount >= 2)
            {
                // 일치하면 스코어 증가
                score++;
                UpdateUI();

                success.gameObject.SetActive(true);
                Invoke("DeactivateSuccessImage", 0.5f);

                EventChange();
            }
        }
    }

    private int GetActiveEventIconIndex()
    {
        for (int i = 0; i < eventIcons.Length; i++)
        {
            if (eventIcons[i].activeSelf)
            {
                return i;
            }
        }
        return -1;
    }

    private int CountMatchingIcons(int eventIconIndex)
    {
        Sprite eventSprite = eventImage[eventIconIndex].GetComponent<Image>().sprite;

        int matchingCount = 0;

        // 슬롯 아이콘들과 비교하여 일치하는 개수 세기
        if (slotIcon01.sprite == eventSprite)
        {
            matchingCount++;
        }

        if (slotIcon02.sprite == eventSprite)
        {
            matchingCount++;
        }

        if (slotIcon03.sprite == eventSprite)
        {
            matchingCount++;
        }

        return matchingCount;


    }

    private void DeactivateSuccessImage()
    {
        // 정답 이미지 비활성화
        success.gameObject.SetActive(false);
    }

    private void DeactivateFailImage()
    {
        // 오답 이미지 비활성화
        fail.gameObject.SetActive(false);
    }

    private void EndGame()
    {
        // 게임 종료 처리

        // 중복 호출 방지
        if (!isGameRunning)
        {
            return;
        }

        isGameRunning = false;

    }
}
