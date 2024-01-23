using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HJYJMinigameManager : MonoBehaviour
{
    // UI ��ҵ�
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

    // Ŭ���� ��Ḧ ������ ����Ʈ
    List<GameObject> clickList = new List<GameObject>();

    // ���� ���� ������
    public int score;
    public int timer;
    public int magicTimer;

    // ���� ���ð� ī��Ʈ
    public Text beforeCountText;
    public Image beforeImg;

    // Ÿ�̸� �� ����
    public int beforeCount;

    // ���� ���� ����
    public Image successImg;
    public Image failImg;

    void Start()
    {

        // ���� ���� �� ȣ��
        StartGame();

    }

    public void StartGame()
    {
        recipe01.GetComponent<Image>().sprite = SouceImage01.GetComponent<Image>().sprite;
        recipe02.GetComponent<Image>().sprite = SouceImage02.GetComponent<Image>().sprite;
        recipe03.GetComponent<Image>().sprite = SouceImage03.GetComponent<Image>().sprite;
        recipe04.GetComponent<Image>().sprite = SouceImage04.GetComponent<Image>().sprite;

        // ���� ���ð� �ʱ�ȭ �� ���ð� UI Ȱ��ȭ
        beforeCount = 3;
        beforeCountText.gameObject.SetActive(true);
        beforeImg.gameObject.SetActive(true);

        // ���� �ð�, ���� �ʱ�ȭ
        timer = 60;
        magicTimer = 10;
        score = 0;

        // 1�ʸ��� CountDownBeforeGame �޼ҵ� ȣ��
        InvokeRepeating("CountDownBeforeGame", 1.0f, 1.0f);
    }

    // ���� ���ð� ����
    private void CountDownBeforeGame()
    {

        // ���� ���ð� ī��Ʈ �ٿ�
        beforeCount--;

        if (beforeCount == 0)
        {
            // ���� ���ð� ���� �� ����
            beforeCountText.gameObject.SetActive(false);
            beforeImg.gameObject.SetActive(false);
            // CountDownBeforeGame ȣ�� �ߴ�
            CancelInvoke("CountDownBeforeGame");

            // ���� ���� ����
            StartRealTimeGame();

            // ���� ��ŸƮ �Լ�
            GameStart();
        }
        else
        {
            // ���ð� �ؽ�Ʈ ����
            beforeCountText.text = beforeCount.ToString();
        }
    }

    public void StartRealTimeGame()
    {

        // 1�ʸ��� UpdateUITimer �޼ҵ� ȣ��
        InvokeRepeating("UpdateUITimer", 1.0f, 1.0f);

    }

    void UpdateUITimer()
    {
        // Ÿ�̸� ī��Ʈ�ٿ�
        timer -= 1;
        timerSlider.value = timer;

        if (timer == 0)
        {
            Endgame();
        }

        // ������ Ÿ�̸� ī��Ʈ�ٿ�
        magicTimer -= 1;
        magicTimerSlider.value = magicTimer;

        // ������ Ÿ�̸Ӱ� 0�� �Ǹ� ���� ó��
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

        // ���� ���� �� ȣ��
        clickList.Clear(); // ����Ʈ �ʱ�ȭ

        // ������ ����
        magicBook = new GameObject[] { SouceImage01, SouceImage02, SouceImage03, SouceImage04 };

        // magicBook �迭�� �������� ����
        ShuffleArray(magicBook);

        // �� magicBookImg�� �����ϰ� magicBook �Ҵ�
        magicBookImg01.GetComponent<Image>().sprite = magicBook[0].GetComponent<Image>().sprite;
        magicBookImg02.GetComponent<Image>().sprite = magicBook[1].GetComponent<Image>().sprite;
        magicBookImg03.GetComponent<Image>().sprite = magicBook[2].GetComponent<Image>().sprite;
        magicBookImg04.GetComponent<Image>().sprite = magicBook[3].GetComponent<Image>().sprite;

        // ������ Ÿ�̸� �ʱ�ȭ
        magicTimer = 10;
        magicTimerSlider.value = magicTimer;
    }

    void ListUpdate()
    {
        // clickList�� ���̿� ���� ���� ����
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

        // 4��° ��Ḧ Ŭ������ �� ���� �Ǵ� ���� ó��
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
        // �迭�� �����ϰ� ����
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
        // ��ư Ŭ�� �� ȣ��
        clickList.Add(SouceImage01);
        ListUpdate();
    }

    public void ButtonClick02()
    {
        // ��ư Ŭ�� �� ȣ��
        clickList.Add(SouceImage02);
        ListUpdate();
    }

    public void ButtonClick03()
    {
        // ��ư Ŭ�� �� ȣ��
        clickList.Add(SouceImage03);
        ListUpdate();
    }

    public void ButtonClick04()
    {
        // ��ư Ŭ�� �� ȣ��
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
        // ���� ���� ó��
    }

}
