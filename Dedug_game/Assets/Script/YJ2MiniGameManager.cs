using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class YJ2MiniGameManager : MonoBehaviour
{
    // 배경 및 수아 이미지
    public Image suaChar;
    public Image gameBg;

    // 사건 이미지
    public GameObject eventMon;
    public GameObject eventHeal;
    public GameObject eventFan;

    // 사건 마법 이미지
    public GameObject eventIconMon;
    public GameObject eventIconHeal;
    public GameObject eventIconFan;

    // 사건 배경 이미지
    public GameObject MonBg;
    public GameObject HealBg;
    public GameObject FanBg;

    public GameObject[] eventIcons; // 이벤트 아이콘들을 배열로 관리
    public GameObject[] eventImage; // 이벤트 오브젝트들을 배열로 관리
    public GameObject[] eventBg; // 이벤트 배경들을 배열로 관리


    // 마법머신 아이콘 이미지
    public Image slotIcon01;
    public Image slotIcon02;
    public Image slotIcon03;
    public Sprite[] slotSprites; // slotIconMon, slotIconHeal, slotIconFan 스프라이트들을 배열로 관리

    // 마법머신 슬롯 애니메이션
    public Image slotAnimation01;
    public Image slotAnimation02;
    public Image slotAnimation03;

    // 스코어 판정 이미지
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
    bool slotStart = false;    // 슬롯 스타트
    bool eventStart = false;    // 이벤트 스타트

    // 게임 실행 조건
    bool isGameRunning;

    // 이벤트 타이머 조건
    bool isEventActive = false;

    // 득실점 판정 연출
    public GameObject monScore;
    public GameObject healScore;
    public GameObject fanScore;

    // 슬롯 딜레이
    public GameObject slotStop;

    // 확률 추가
    bool mon;
    bool heal;
    bool fan;

    // 성공 연출
    public GameObject successMon;

    // 실패 연출
    public GameObject slotFail01;
    public GameObject slotFail02;
    public GameObject slotFail03;


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

        // 이벤트 타임 시작
        eventStart = true;

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

            if (eventStart == true)
            {
                // 이벤트 타이머 슬라이더 업데이트
                UpdateEventSlider();

                // 이벤트 타이머 감소
                eventTimer--;
            }

            // UI 업데이트
            UpdateUI();

            // 타이머가 0이면 게임 종료
            if (timer == 0)
            {
                EndGame();
            }

            // 수아 흔들리는 애니메이션
            ShakeSuaCharacter();
        }
    }

    private void ShakeSuaCharacter()
    {
        // 수아 캐릭터를 x축을 기준으로 좌우로 흔들리는 애니메이션
        suaChar.rectTransform.DOPunchPosition(new Vector3(20f, 0f, 0f), 0.5f, 5, 1f);
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

        eventIcons = new GameObject[] { eventIconMon, eventIconHeal, eventIconFan };
        eventImage = new GameObject[] { eventMon, eventHeal, eventFan };
        eventBg = new GameObject[] { MonBg, HealBg, FanBg };

        // 슬라이드 애니메이션으로 활성화
        GameObject IconToSlide = eventIcons[randomIndex];
        IconToSlide.SetActive(true);
        IconToSlide.transform.DOMoveX(10f, 1.0f).From().SetEase(Ease.OutQuart);

        GameObject ImageToSlide = eventImage[randomIndex];
        ImageToSlide.SetActive(true);
        ImageToSlide.transform.DOMoveX(10f, 1.0f).From().SetEase(Ease.OutQuart);

        GameObject bgToSlide = eventBg[randomIndex];
        bgToSlide.SetActive(true);
        bgToSlide.transform.DOMoveX(10f, 1.0f).From().SetEase(Ease.OutQuart);

        if (randomIndex == 0)
        {
            mon = true;
        }

        if(randomIndex == 1)
        {
            heal = true;
        }

        if (randomIndex == 2)
        {
            fan = true;
        }

        // 이벤트 활성화 상태로 변경
        isEventActive = true;

        // eventTimer를 10으로 초기화
        eventTimer = 10;
    }

    private void DeactivateAllEvents()
    {
        mon = false;
        heal = false;
        fan = false;

        // 모든 이벤트 아이콘과 이벤트 비활성화
        foreach (var icon in eventIcons)
        {
            icon.SetActive(false);
        }

        foreach (var obj in eventImage)
        {
            obj.SetActive(false);
        }

        foreach (var Bg in eventBg)
        {
            Bg.SetActive(false);
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
            slotAnimation01.gameObject.SetActive(true);
            slotAnimation02.gameObject.SetActive(true);
            slotAnimation03.gameObject.SetActive(true);
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

            slotAnimation01.gameObject.SetActive(false);
            slotAnimation02.gameObject.SetActive(false);
            slotAnimation03.gameObject.SetActive(false);

            // 호출 중단
            CancelInvoke("SlotTimerCountdown");

            // slotStart를 false로 설정하여 더 이상 카운트다운을 하지 않도록 함
            slotStart = false;

            slotStop.gameObject.SetActive(true);

            // 랜덤으로 이미지 출력
            ActivateRandomSlotIcons();

            // 슬롯 아이콘과 이벤트 아이콘 비교하여 스코어 처리
            CompareIconsAndScore();

        }
    }

    private void ActivateRandomSlotIcons()
    {
        if (mon == true)
        {
            SetRandomSlotIcon(slotIcon01, 0.5f, 0.25f, 0.25f);
            SetRandomSlotIcon(slotIcon02, 0.5f, 0.25f, 0.25f);
            SetRandomSlotIcon(slotIcon03, 0.5f, 0.25f, 0.25f);
        }
        else if (heal == true)
        {
            SetRandomSlotIcon(slotIcon01, 0.25f, 0.5f, 0.25f);
            SetRandomSlotIcon(slotIcon02, 0.25f, 0.5f, 0.25f);
            SetRandomSlotIcon(slotIcon03, 0.25f, 0.5f, 0.25f);
        }
        else if (fan == true)
        {
            SetRandomSlotIcon(slotIcon01, 0.25f, 0.25f, 0.5f);
            SetRandomSlotIcon(slotIcon02, 0.25f, 0.25f, 0.5f);
            SetRandomSlotIcon(slotIcon03, 0.25f, 0.25f, 0.5f);
        }
    }

    // 슬롯 아이콘 이미지를 확률에 따라 설정하는 메소드
    private void SetRandomSlotIcon(Image slotIcon, float probability1, float probability2, float probability3)
    {
        
        float randomProbability = UnityEngine.Random.Range(0f, 1f);

        if (randomProbability < probability1)
        {
            slotIcon.sprite = slotSprites[0];
        }
        else if (randomProbability < probability1 + probability2)
        {
            slotIcon.sprite = slotSprites[1];
        }
        else
        {
            slotIcon.sprite = slotSprites[2];
        }

        slotIcon01.gameObject.SetActive(true);
        slotIcon02.gameObject.SetActive(true);
        slotIcon03.gameObject.SetActive(true);
    }


    // 스코어 처리
    private void CompareIconsAndScore()
    {
        int eventIconIndex = GetActiveEventIconIndex();

        // 이벤트 아이콘과 슬롯 아이콘 비교
        if (eventIconIndex != -1)
        {
            int matchingCount = CountMatchingIcons(eventIconIndex);

            if (matchingCount >= 0 && matchingCount < 2)
            {

                slotFail01.gameObject.SetActive(true);
                slotFail02.gameObject.SetActive(true);
                slotFail03.gameObject.SetActive(true);

                Invoke("FailSet", 1f);
            }

            if (matchingCount >= 2)
            {
                // 일치하면 스코어 증가
                score++;
                UpdateUI();

                // 일치하는 아이콘 종류 확인
                Sprite eventSprite = eventIcons[eventIconIndex].GetComponent<Image>().sprite;

                Vector3 originalScale = new Vector3(1, 1, 1);
                Vector3 targetScale = new Vector3(1.5f, 1.5f, 1.5f);

                eventIcons[eventIconIndex].transform.DOScale(targetScale, 0.2f).OnComplete(() => // 람다식
                {
                    eventIcons[eventIconIndex].transform.DOScale(originalScale, 0.2f);
                });

                // 일치하는 슬롯 아이콘 연출
                if (slotIcon01.sprite == eventSprite)
                {
                    slotIcon01.transform.DOScale(targetScale, 0.2f).OnComplete(() => // 람다식
                    {
                        slotIcon01.transform.DOScale(originalScale, 0.2f);
                    });
                }

                if (slotIcon02.sprite == eventSprite)
                {
                    slotIcon02.transform.DOScale(targetScale, 0.2f).OnComplete(() => // 람다식
                    {
                        slotIcon02.transform.DOScale(originalScale, 0.2f);
                    });
                }

                if(slotIcon03.sprite == eventSprite)
                {
                    slotIcon03.transform.DOScale(targetScale, 0.2f).OnComplete(() => // 람다식
                    {
                        slotIcon03.transform.DOScale(originalScale, 0.2f);
                    });
                }

                // 일치하는 아이콘에 따라 동작 수행
                if (eventSprite.name == "mon_Icon")
                {
                    StartCoroutine(ActivateAndDeactivateScore(monScore));
                }
                else if (eventSprite.name == "heal_Icon")
                {
                    StartCoroutine(ActivateAndDeactivateScore(healScore));
                }
                else if (eventSprite.name == "fan_Icon")
                {
                    StartCoroutine(ActivateAndDeactivateScore(fanScore));
                }
                
                eventStart = false;
                Invoke("EventRestart", 1f);
                Invoke("EventChange", 1f);
            }
        }

        Invoke("Slotfalse", 1f);
    }


    // 실패 연출 끄기
    public void FailSet()
    {
        slotFail01.gameObject.SetActive(false);
        slotFail02.gameObject.SetActive(false);
        slotFail03.gameObject.SetActive(false);
    }

    // 슬롯 아이콘 끄기
    public void Slotfalse()
    {
        slotIcon01.gameObject.SetActive(false);
        slotIcon02.gameObject.SetActive(false);
        slotIcon03.gameObject.SetActive(false);

        slotStop.gameObject.SetActive(false);
    }

    public void EventRestart()
    {
        eventStart = true;
    }

    // 코루틴을 이용하여 일정 시간 동안 GameObject를 활성화 후 비활성화
    private IEnumerator ActivateAndDeactivateScore(GameObject scoreObject)
    {
        scoreObject.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        scoreObject.SetActive(false);
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
        Sprite eventSprite = eventIcons[eventIconIndex].GetComponent<Image>().sprite;

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
