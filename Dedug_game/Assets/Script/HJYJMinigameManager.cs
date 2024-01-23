using System.Collections;
using System.Collections.Generic;
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
    public int beforeCount;

    void Start()
    {
        // ������ ����
        magicBook = new GameObject[] { magicBookImg01, magicBookImg02, magicBookImg03, magicBookImg04 };

        // ���� ���� �� ȣ��
        GameStart();
    }

    void Update()
    {
        // �ֱ������� UI ������Ʈ
        UpdateUI();
    }

    void UpdateUI()
    {
        // ������ Ÿ�̸� ī��Ʈ�ٿ�
        timer -= 1;
        timerSlider.value = timer;

        // ������ Ÿ�̸Ӱ� 0�� �Ǹ� ���� ó��
        if (timer <= 0)
        {
            Fail();
        }
    }

    void GameStart()
    {
        // ���� ���� �� ȣ��
        clickList.Clear(); // ����Ʈ �ʱ�ȭ

        // magicBook �迭�� �������� ����
        ShuffleArray(magicBook);

        // �� magicBookImg�� �����ϰ� magicBook �Ҵ�
        magicBookImg01.GetComponent<Image>().sprite = magicBook[0].GetComponent<Image>().sprite;
        magicBookImg02.GetComponent<Image>().sprite = magicBook[1].GetComponent<Image>().sprite;
        magicBookImg03.GetComponent<Image>().sprite = magicBook[2].GetComponent<Image>().sprite;
        magicBookImg04.GetComponent<Image>().sprite = magicBook[3].GetComponent<Image>().sprite;

        // ������ Ÿ�̸� �ʱ�ȭ
        timer = 10;
        timerSlider.maxValue = timer;
        timerSlider.value = timer;
    }

    void ListUpdate()
    {
        // clickList�� ���̿� ���� ���� ����
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

            // �ش� ������ �̹��� ��� �� ���� ����
            currentClickImg.SetActive(true);

            // 4��° ��Ḧ Ŭ������ �� ���� �Ǵ� ���� ó��
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
                // 1~3��° ��Ḧ Ŭ������ �� ���� ó��
                if (clickList[clickListLength - 1] != magicBook[clickListLength - 1])
                {
                    Fail();
                }
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
        clickList.Add(magicBookImg01);
        ListUpdate();
    }

    public void ButtonClick02()
    {
        // ��ư Ŭ�� �� ȣ��
        clickList.Add(magicBookImg02);
        ListUpdate();
    }

    // ButtonClick03, ButtonClick04�� �����ϰ� �ۼ� ����

    public void Success()
    {

    }

    public void Fail()
    {

    }

}
