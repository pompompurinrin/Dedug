using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HJYJMinigameManager : MonoBehaviour
{
    // UI 요소들
    public Text scoreText;
    public Image suaChar;
    public Slider magicTimerSlider;
    public Slider timerSlider;

    public GameObject magicBookImg01;
    public GameObject magicBookImg02;
    public GameObject magicBookImg03;
    public GameObject magicBookImg04;

    public GameObject[] magicBook;

    public GameObject SouceImage01;
    public GameObject SouceImage02;
    public GameObject SouceImage03;
    public GameObject SouceImage04;

    public Button recipe01;
    public Button recipe02;
    public Button recipe03;
    public Button recipe04;

    public GameObject clickImg01;
    public GameObject clickImg02;
    public GameObject clickImg03;
    public GameObject clickImg04;

    // 클릭된 재료를 저장할 리스트
    List<GameObject> clickList = new List<GameObject>();

    // 게임 관련 변수들
    public int score;
    public int timer;
    public int magicTimer;

    // 게임 대기시간 카운트
    public Text beforeCountText;
    public Image beforeImg;

    // 타이머 및 점수
    public int beforeCount;

    // 성공 실패 판정
    public Image successImg;
    public Image failImg;

    void Start()
    {

        // 게임 시작 시 호출
        StartGame();

    }

    public void StartGame()
    {
        recipe01.GetComponent<Image>().sprite = SouceImage01.GetComponent<Image>().sprite;
        recipe02.GetComponent<Image>().sprite = SouceImage02.GetComponent<Image>().sprite;
        recipe03.GetComponent<Image>().sprite = SouceImage03.GetComponent<Image>().sprite;
        recipe04.GetComponent<Image>().sprite = SouceImage04.GetComponent<Image>().sprite;

        // 게임 대기시간 초기화 및 대기시간 UI 활성화
        beforeCount = 3;
        beforeCountText.gameObject.SetActive(true);
        beforeImg.gameObject.SetActive(true);

        // 게임 시간, 점수 초기화
        timer = 60;
        magicTimer = 10;
        score = 0;

        // 1초마다 CountDownBeforeGame 메소드 호출
        InvokeRepeating("CountDownBeforeGame", 1.0f, 1.0f);
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

            // 게임 스타트 함수
            GameStart();
        }
        else
        {
            // 대기시간 텍스트 갱신
            beforeCountText.text = beforeCount.ToString();
        }
    }

    public void StartRealTimeGame()
    {

        // 1초마다 UpdateUITimer 메소드 호출
        InvokeRepeating("UpdateUITimer", 1.0f, 1.0f);

    }

    void UpdateUITimer()
    {
        // 타이머 카운트다운
        timer -= 1;
        timerSlider.value = timer;

        if (timer == 0)
        {
            Endgame();
        }

        // 레시피 타이머 카운트다운
        magicTimer -= 1;
        magicTimerSlider.value = magicTimer;

        // 레시피 타이머가 0이 되면 실패 처리
        if (magicTimer == 0)
        {
            Fail();
        }
    }

    void GameStart()
    {
        successImg.gameObject.SetActive(false);
        failImg.gameObject.SetActive(false);

        clickImg01.gameObject.SetActive(false);
        clickImg02.gameObject.SetActive(false);
        clickImg03.gameObject.SetActive(false);
        clickImg04.gameObject.SetActive(false);

        // 게임 시작 시 호출
        clickList.Clear(); // 리스트 초기화

        // 매직북 선언
        magicBook = new GameObject[] { SouceImage01, SouceImage02, SouceImage03, SouceImage04 };

        // magicBook 배열을 랜덤으로 섞음
        ShuffleArray(magicBook);

        // 각 magicBookImg에 랜덤하게 magicBook 할당
        magicBookImg01.GetComponent<Image>().sprite = magicBook[0].GetComponent<Image>().sprite;
        magicBookImg02.GetComponent<Image>().sprite = magicBook[1].GetComponent<Image>().sprite;
        magicBookImg03.GetComponent<Image>().sprite = magicBook[2].GetComponent<Image>().sprite;
        magicBookImg04.GetComponent<Image>().sprite = magicBook[3].GetComponent<Image>().sprite;

        // 레시피 타이머 초기화
        magicTimer = 10;
        magicTimerSlider.value = magicTimer;
    }

    void ListUpdate()
    {
        // clickList의 길이에 따라 동작 수행
        int clickListLength = clickList.Count;
        GameObject currentClickImg = clickList[clickListLength - 1];

        if (clickListLength == 1)
        {
            if (currentClickImg.GetComponent<Image>().sprite == magicBook[0].GetComponent<Image>().sprite)
            {
                clickImg01.GetComponent<Image>().sprite = currentClickImg.GetComponent<Image>().sprite;
                clickImg01.gameObject.SetActive(true);
            }

            if (currentClickImg.GetComponent<Image>().sprite != magicBook[0].GetComponent<Image>().sprite)
            {
                Fail();
            }
        }

        if (clickListLength == 2)
        {
            if (currentClickImg.GetComponent<Image>().sprite == magicBook[1].GetComponent<Image>().sprite)
            {
                clickImg02.GetComponent<Image>().sprite = currentClickImg.GetComponent<Image>().sprite;
                clickImg02.gameObject.SetActive(true);
            }

            if (currentClickImg.GetComponent<Image>().sprite != magicBook[1].GetComponent<Image>().sprite)
            {
                Fail();
            }
        }

        if (clickListLength == 3)
        {
            if (currentClickImg.GetComponent<Image>().sprite == magicBook[2].GetComponent<Image>().sprite)
            {
                clickImg03.GetComponent<Image>().sprite = currentClickImg.GetComponent<Image>().sprite;
                clickImg03.gameObject.SetActive(true);
            }

            if (currentClickImg.GetComponent<Image>().sprite != magicBook[2].GetComponent<Image>().sprite)
            {
                Fail();
            }
        }

        // 4번째 재료를 클릭했을 때 성공 또는 실패 처리
        if (clickListLength == 4)
        {
            if (clickList[3].GetComponent<Image>().sprite == magicBook[3].GetComponent<Image>().sprite)
            {
                clickImg04.GetComponent<Image>().sprite = currentClickImg.GetComponent<Image>().sprite;
                clickImg04.gameObject.SetActive(true);

                Success();
            }

            if (currentClickImg.GetComponent<Image>().sprite != magicBook[3].GetComponent<Image>().sprite)
            {
                Fail();
            }
        }
    }


    void ShuffleArray(GameObject[] array)
    {
        // 배열을 랜덤하게 섞음
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            GameObject temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

    public void ButtonClick01()
    {
        // 버튼 클릭 시 호출
        clickList.Add(SouceImage01);
        ListUpdate();
    }

    public void ButtonClick02()
    {
        // 버튼 클릭 시 호출
        clickList.Add(SouceImage02);
        ListUpdate();
    }

    public void ButtonClick03()
    {
        // 버튼 클릭 시 호출
        clickList.Add(SouceImage03);
        ListUpdate();
    }

    public void ButtonClick04()
    {
        // 버튼 클릭 시 호출
        clickList.Add(SouceImage04);
        ListUpdate();
    }

    public void Success()
    {
        score++;
        scoreText.text = score.ToString();
        successImg.gameObject.SetActive(true);
        if(score == 8)
        {
            Endgame();
        }

        Invoke("GameStart", 1f);
    }

    public void Fail()
    {
        score--;
        scoreText.text = score.ToString();
        failImg.gameObject.SetActive(true);

        if (score < 0)
        {
            scoreText.text = "0";
        }

        Invoke("GameStart", 1f);
    }

    public void Endgame()
    {
        // 게임 종료 처리
    }

}
