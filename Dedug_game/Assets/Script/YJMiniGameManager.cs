using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class YJMiniGameManager : MonoBehaviour
{
    // 미니게임 시작 및 끝 부모 객체
    public GameObject endBg;
    public GameObject startBg;

    // 메시지 출력 이미지 부모 객체
    public GameObject messageBg;

    // 메시지 타임 출력 텍스트 및 이펙트
    public Text messageText;
    public Image loveEffect;

    // 응원봉 타이밍 판정 이미지
    public Image success;
    public Image fail;

    // 게임 대기시간 카운트
    public Text beforeCount;

    // 미니게임 탑 바 관련 변수 (점수, 제한시간)
    public Text costText;
    public Text countDown;

    // 마법소녀 캐릭터 및 관객(주인공) 애니메이션 이미지
    public Image badaChar;
    public Image meChar;

    // 게임 버튼
    public Button message01;
    public Button message02;
    public Button bong01;
    public Button bong02;
    public Button bong03;

    // 응원봉 타임 안내 이펙트
    public Image colorEffect01;
    public Image colorEffect02;
    public Image colorEffect03;

    // 점수 및 제한시간, 대기시간 변수
    int score;
    int gameTime;
    int beforeGameTime;

    private bool isGameRunning = false;
    private float bongTime = 2.0f;
    private bool isBongTimeActive = false;

    private void Start()
    {
        // 게임 시작 시 호출되는 함수
        StartGame();
    }

    private void StartGame()
    {
        // 게임 대기시간 초기화
        beforeGameTime = 3;
        beforeCount.gameObject.SetActive(true);
        // 1초마다 CountDownBeforeGame 메소드 호출
        InvokeRepeating("CountDownBeforeGame", 1.0f, 1.0f);
    }

    private void CountDownBeforeGame()
    {
        // 게임 대기시간 카운트 다운
        beforeGameTime--;

        if (beforeGameTime == 0)
        {
            // 게임 대기시간 종료 후 숨김
            beforeCount.gameObject.SetActive(false);
            // CountDownBeforeGame 호출 중단
            CancelInvoke("CountDownBeforeGame");

            // 실제 게임 시작
            StartRealTimeGame();
        }
        else
        {
            // 대기시간 텍스트 갱신
            beforeCount.text = beforeGameTime.ToString();
        }
    }

    private void StartRealTimeGame()
    {
        // 실제 게임 시작
        isGameRunning = true;
        // 초기 제한시간 설정
        gameTime = 90;
        countDown.text = gameTime.ToString();
        // 1초마다 UpdateGame 메소드 호출
        InvokeRepeating("UpdateGame", 1.0f, 1.0f);
        // BGM 재생 등 게임 시작 관련 설정 추가 필요

    }


    private void UpdateGame()
    {
        // 0. 제한시간이 종료된 경우
        if (gameTime <= 0)
        {
            // 게임 종료 처리
            EndGame();
            return;
        }

        // 1. 실시간 카운트다운 갱신 및 BGM 재생
        countDown.text = gameTime.ToString();
        gameTime--;

        // 2. bongTime 동안 랜덤한 colorEffect 활성화
        if (gameTime >= 60 && gameTime % 6 == 0)
        {
            ActivateRandomColorEffect();
            isBongTimeActive = true;

            // bongTime 초 후에 아무 버튼도 클릭하지 않았을 때 처리를 위해 Invoke 호출
            Invoke("HandleButtonClick", bongTime);
        }

        // 3. 게임 버튼 클릭 처리
        if (Input.GetMouseButtonDown(0))
        {
            HandleButtonClick();
        }
    }

    private void ActivateRandomColorEffect()
    {
        // 랜덤한 colorEffect 활성화 및 일정 시간 후에 비활성화
        Image randomColorEffect = GetRandomColorEffect();
        randomColorEffect.gameObject.SetActive(true);
        Invoke("DeactivateColorEffect", bongTime);
    }

    private Image GetRandomColorEffect()
    {
        // 랜덤한 colorEffect 반환
        int randomIndex = Random.Range(1, 4);
        switch (randomIndex)
        {
            case 1:
                return colorEffect01;
            case 2:
                return colorEffect02;
            case 3:
                return colorEffect03;
            default:
                return colorEffect01;
        }
    }

    private void DeactivateColorEffect()
    {
        // 모든 colorEffect 비활성화
        colorEffect01.gameObject.SetActive(false);
        colorEffect02.gameObject.SetActive(false);
        colorEffect03.gameObject.SetActive(false);
    }

    private void HandleButtonClick()
    {
        // 클릭된 버튼에 따라 처리
        if (EventSystem.current.currentSelectedGameObject == bong01.gameObject)
        {
            OnBongButtonClick(bong01);
        }
        else if (EventSystem.current.currentSelectedGameObject == bong02.gameObject)
        {
            OnBongButtonClick(bong02);
        }
        else if (EventSystem.current.currentSelectedGameObject == bong03.gameObject)
        {
            OnBongButtonClick(bong03);
        }
        else if (EventSystem.current.currentSelectedGameObject == message01.gameObject)
        {
            OnMessage01ButtonClick();
        }
        else if (EventSystem.current.currentSelectedGameObject == message02.gameObject)
        {
            OnMessage02ButtonClick();
        }

        // 게임 종료 체크
        CheckGameEnd();
    }

    public void OnBongButtonClick(Button bongButton)
    {
        // bongTime이 진행 중일 때만 처리
        if (isBongTimeActive == true)
        {
            // 활성화된 colorEffect와 대응되는 bong 버튼인지 확인
            if (IsMatchingBongButton(bongButton))
            {
                // 정답인 경우
                score++;
                costText.text = score.ToString();

                // 정답 이미지 활성화
                success.gameObject.SetActive(true);
                Invoke("DeactivateSuccessImage", 2.0f);
            }
            else
            {
                // 오답인 경우
                score--;
                costText.text = score.ToString();

                // 오답 이미지 활성화
                fail.gameObject.SetActive(true);
                Invoke("DeactivateFailImage", 2.0f);
            }

            // UI 업데이트
            UpdateUI();

            // colorEffect 비활성화
            DeactivateColorEffect();

            // bongTime 동안 클릭 여부 추적 변수 초기화
            isBongTimeActive = false;
        }
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

    private bool IsBongTimeActive()
    {
        // bongTime이 진행 중인지 여부 반환
        return isGameRunning;
    }

    private bool IsMatchingBongButton(Button bongButton)
    {
        // 활성화된 colorEffect와 대응되는 bong 버튼인지 확인
        Image activeColorEffect = GetActiveColorEffect();

        if (bongButton == bong01 && activeColorEffect == colorEffect01)
        {
            return true;
        }
        else if (bongButton == bong02 && activeColorEffect == colorEffect02)
        {
            return true;
        }
        else if (bongButton == bong03 && activeColorEffect == colorEffect03)
        {
            return true;
        }

        return false;
    }

    private Image GetActiveColorEffect()
    {
        // 활성화된 colorEffect 반환
        if (colorEffect01.gameObject.activeSelf)
        {
            return colorEffect01;
        }
        else if (colorEffect02.gameObject.activeSelf)
        {
            return colorEffect02;
        }
        else if (colorEffect03.gameObject.activeSelf)
        {
            return colorEffect03;
        }

        return null;
    }

    private void UpdateUI()
    {
        // UI 업데이트 (제한시간, 점수)
        countDown.text = gameTime.ToString();
        costText.text = "Score: " + score.ToString();
    }

    private void CheckGameEnd()
    {
        // 제한시간이 종료되면 게임 종료
        if (gameTime <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        // 게임 종료 시 호출되는 함수
        endBg.SetActive(true);
        isGameRunning = false;
    }

    public void OnMessage01ButtonClick()
    {
        // message01 버튼 클릭 시 호출되는 함수
        StartCoroutine(DisplayMessage("message01"));
    }

    public void OnMessage02ButtonClick()
    {
        // message02 버튼 클릭 시 호출되는 함수
        StartCoroutine(DisplayMessage("message02"));
    }

    private IEnumerator DisplayMessage(string message)
    {
        // 메시지 출력 및 일정 시간 후에 숨김
        messageBg.SetActive(true);
        messageText.text = message;
        loveEffect.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        messageBg.SetActive(false);
        messageText.text = "";
        loveEffect.gameObject.SetActive(false);
    }
}
