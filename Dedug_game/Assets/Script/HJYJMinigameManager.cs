using System.Collections;
using System.Collections.Generic;
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
    public int beforeCount;

    void Start()
    {
        // 매직북 선언
        magicBook = new GameObject[] { magicBookImg01, magicBookImg02, magicBookImg03, magicBookImg04 };

        // 게임 시작 시 호출
        GameStart();
    }

    void Update()
    {
        // 주기적으로 UI 업데이트
        UpdateUI();
    }

    void UpdateUI()
    {
        // 레시피 타이머 카운트다운
        timer -= 1;
        timerSlider.value = timer;

        // 레시피 타이머가 0이 되면 실패 처리
        if (timer <= 0)
        {
            Fail();
        }
    }

    void GameStart()
    {
        // 게임 시작 시 호출
        clickList.Clear(); // 리스트 초기화

        // magicBook 배열을 랜덤으로 섞음
        ShuffleArray(magicBook);

        // 각 magicBookImg에 랜덤하게 magicBook 할당
        magicBookImg01.GetComponent<Image>().sprite = magicBook[0].GetComponent<Image>().sprite;
        magicBookImg02.GetComponent<Image>().sprite = magicBook[1].GetComponent<Image>().sprite;
        magicBookImg03.GetComponent<Image>().sprite = magicBook[2].GetComponent<Image>().sprite;
        magicBookImg04.GetComponent<Image>().sprite = magicBook[3].GetComponent<Image>().sprite;

        // 레시피 타이머 초기화
        timer = 10;
        timerSlider.maxValue = timer;
        timerSlider.value = timer;
    }

    void ListUpdate()
    {
        // clickList의 길이에 따라 동작 수행
        int clickListLength = clickList.Count;

        if (clickListLength >= 1 && clickListLength <= 4)
        {
            GameObject currentClickImg = null;

            switch (clickListLength)
            {
                case 1:
                    currentClickImg = clickImg01;
                    break;
                case 2:
                    currentClickImg = clickImg02;
                    break;
                case 3:
                    currentClickImg = clickImg03;
                    break;
                case 4:
                    currentClickImg = clickImg04;
                    break;
            }

            // 해당 순서의 이미지 출력 및 동작 수행
            currentClickImg.SetActive(true);

            // 4번째 재료를 클릭했을 때 성공 또는 실패 처리
            if (clickListLength == 4)
            {
                if (clickList[3] == magicBook[3])
                {
                    Success();
                }
                else
                {
                    Fail();
                }
            }
            else
            {
                // 1~3번째 재료를 클릭했을 때 실패 처리
                if (clickList[clickListLength - 1] != magicBook[clickListLength - 1])
                {
                    Fail();
                }
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
        clickList.Add(magicBookImg01);
        ListUpdate();
    }

    public void ButtonClick02()
    {
        // 버튼 클릭 시 호출
        clickList.Add(magicBookImg02);
        ListUpdate();
    }

    // ButtonClick03, ButtonClick04도 유사하게 작성 가능

    public void Success()
    {

    }

    public void Fail()
    {

    }

}
