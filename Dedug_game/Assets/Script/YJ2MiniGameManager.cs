using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class YJ2MiniGameManager : MonoBehaviour
{
    // ��� �� ���� �̹���
    public Image suaChar;
    public Image gameBg;

    // ��� �̹���
    public GameObject eventMon;
    public GameObject eventHeal;
    public GameObject eventFan;

    // ��� ���� �̹���
    public GameObject eventIconMon;
    public GameObject eventIconHeal;
    public GameObject eventIconFan;

    public GameObject[] eventIcons; // �̺�Ʈ �����ܵ��� �迭�� ����
    public GameObject[] eventImage; // �̺�Ʈ ������Ʈ���� �迭�� ����


    // �����ӽ� ������ �̹���
    public Image slotIcon01;
    public Image slotIcon02;
    public Image slotIcon03;
    public Sprite[] slotSprites; // slotIconMon, slotIconHeal, slotIconFan ��������Ʈ���� �迭�� ����

    // ���ھ� ���� �̹���
    public Image success;
    public Image fail;

    // ���� ���ð� ī��Ʈ
    public Text beforeCountText;
    public Image beforeImg;

    // Ÿ�̸� �� ����
    int beforeCount;
    int score;
    int timer;
    int slotTimer;
    int eventTimer;

    public Text scoreText;
    public Text timerText;

    // Ÿ�̸� �����̴�
    public Slider eventTimeSlider;
    public Slider slotTimeSlider;

    // �����ӽ� ��ư
    public Button slotButton;

    // ���� ����
    bool mon;
    bool heal;
    bool fan;
    bool slotMon;
    bool slotHeal;
    bool slotFan;
    bool slotStart = false;
    bool eventStart = false;

    // ���� ���� ����
    bool isGameRunning;

    // �̺�Ʈ Ÿ�̸� ����
    bool isEventActive = false;

    // ����� ���� ����
    public GameObject monScore;
    public GameObject healScore;
    public GameObject fanScore;



    private void Start()
    {
        // ���� ���� �� ȣ��Ǵ� �Լ�
        StartGame();
    }

    public void StartGame()
    {
        // ���� ���ð� �ʱ�ȭ �� ���ð� UI Ȱ��ȭ
        beforeCount = 3;
        beforeCountText.gameObject.SetActive(true);
        beforeImg.gameObject.SetActive(true);

        // ���� �ð�, ���� �ʱ�ȭ
        timer = 60;
        score = 0;

        // ���� UI ������Ʈ
        UpdateUI();

        // 1�ʸ��� CountDownBeforeGame �޼ҵ� ȣ��
        InvokeRepeating("CountDownBeforeGame", 1.0f, 1.0f);
    }

    private void UpdateUI()
    {
        // UI ������Ʈ (���ѽð�, ����)
        timerText.text = timer.ToString();
        scoreText.text = "Score: " + score.ToString();
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
        }
        else
        {
            // ���ð� �ؽ�Ʈ ����
            beforeCountText.text = beforeCount.ToString();

        }
    }

    public void StartRealTimeGame()
    {



        // ���� ���� ����
        isGameRunning = true;

        // �̺�Ʈ Ÿ�� ����
        eventStart = true;

        // �ʱ� ���ѽð� ����
        timerText.text = timer.ToString();

        // 1�ʸ��� UpdateGame �޼ҵ� ȣ��
        InvokeRepeating("UpdateGame", 1.0f, 1.0f);

        // ���� ���� �� �������� �̺�Ʈ ����
        ActivateRandomEvent();
    }


    public void UpdateGame()
    {
        if (isGameRunning)
        {
            // Ÿ�̸� ����
            timer--;

            if (eventStart == true)
            {
                // �̺�Ʈ Ÿ�̸� �����̴� ������Ʈ
                UpdateEventSlider();

                // �̺�Ʈ Ÿ�̸� ����
                eventTimer--;
            }

            // UI ������Ʈ
            UpdateUI();

            // Ÿ�̸Ӱ� 0�̸� ���� ����
            if (timer == 0)
            {
                EndGame();
            }

            // ���� ��鸮�� �ִϸ��̼�
            ShakeSuaCharacter();
        }
    }

    private void ShakeSuaCharacter()
    {
        // ���� ĳ���͸� x���� �������� �¿�� ��鸮�� �ִϸ��̼�
        suaChar.rectTransform.DOPunchPosition(new Vector3(20f, 0f, 0f), 0.5f, 5, 1f);
    }

    public void UpdateEventSlider()
    {
        // �̺�Ʈ Ȱ��ȭ ���¿����� ������Ʈ
        if (isEventActive)
        {
            // �̺�Ʈ Ÿ�̸� �����̴� ������Ʈ
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
        // ������ Ȱ��ȭ�Ǿ� �ִ� �̺�Ʈ ��Ȱ��ȭ
        DeactivateAllEvents();

        // �������� �̺�Ʈ �����ܰ� �̺�Ʈ Ȱ��ȭ
        int randomIndex = UnityEngine.Random.Range(0, eventIcons.Length);

        eventIcons = new GameObject[] { eventIconMon, eventIconHeal, eventIconFan };
        eventImage = new GameObject[] { eventMon, eventHeal, eventFan };

        eventIcons[randomIndex].SetActive(true);
        eventImage[randomIndex].SetActive(true);

        // �̺�Ʈ Ȱ��ȭ ���·� ����
        isEventActive = true;

        // eventTimer�� 10���� �ʱ�ȭ
        eventTimer = 10;
    }

    private void DeactivateAllEvents()
    {
        // ��� �̺�Ʈ �����ܰ� �̺�Ʈ ��Ȱ��ȭ
        foreach (var icon in eventIcons)
        {
            icon.SetActive(false);
        }

        foreach (var obj in eventImage)
        {
            obj.SetActive(false);
        }

        // �̺�Ʈ ��Ȱ��ȭ ���·� ����
        isEventActive = false;
    }

    public void EventChange()
    {
        // �̺�Ʈ ���� �� �ٽ� �������� �̺�Ʈ ����
        ActivateRandomEvent();
    }

    public void SlotButtonClicked()
    {
        // ó�� Ŭ������ ���� slotTimer�� 8�ʷ� ����
        if (!slotStart)
        {
            slotTimer = 8;
        }

        if (slotStart == true)
        {
            slotTimer--;
        }

        // slotButton Ŭ�� �� ����Ǵ� �޼ҵ�
        slotStart = true;

        // 1�ʸ��� SlotTimerCountdown �޼ҵ� ȣ��
        InvokeRepeating("SlotTimerCountdown", 1.0f, 1.0f);
    }


    private void SlotTimerCountdown()
    {
        // slotTimer ����
        slotTimer--;
        slotTimeSlider.value = slotTimer;

        if (slotTimer < 0)
        {
            slotTimer = 0;
        }

        // slotTimer�� 0�̸� ȣ�� �ߴ��ϰ� �̹��� ���
        if (slotTimer == 0)
        {
            // ȣ�� �ߴ�
            CancelInvoke("SlotTimerCountdown");

            // slotStart�� false�� �����Ͽ� �� �̻� ī��Ʈ�ٿ��� ���� �ʵ��� ��
            slotStart = false;

            // �������� �̹��� ���
            ActivateRandomSlotIcons();

            // ���� �����ܰ� �̺�Ʈ ������ ���Ͽ� ���ھ� ó��
            CompareIconsAndScore();

        }
    }

    private void ActivateRandomSlotIcons()
    {
        // �������� ���� ������ �̹��� ����
        slotIcon01.sprite = slotSprites[UnityEngine.Random.Range(0, slotSprites.Length)];
        slotIcon02.sprite = slotSprites[UnityEngine.Random.Range(0, slotSprites.Length)];
        slotIcon03.sprite = slotSprites[UnityEngine.Random.Range(0, slotSprites.Length)];

        slotIcon01.gameObject.SetActive(true);
        slotIcon02.gameObject.SetActive(true);
        slotIcon03.gameObject.SetActive(true);
    }

    private void CompareIconsAndScore()
    {
        int eventIconIndex = GetActiveEventIconIndex();

        // �̺�Ʈ �����ܰ� ���� ������ ��
        if (eventIconIndex != -1)
        {
            int matchingCount = CountMatchingIcons(eventIconIndex);

            if (matchingCount >= 2)
            {
                // ��ġ�ϸ� ���ھ� ����
                score++;
                UpdateUI();

                // ��ġ�ϴ� ������ ���� Ȯ��
                Sprite eventSprite = eventIcons[eventIconIndex].GetComponent<Image>().sprite;

                Vector3 originalScale = new Vector3(1, 1, 1);
                Vector3 targetScale = new Vector3(1.5f, 1.5f, 1.5f);

                eventIcons[eventIconIndex].transform.DOScale(targetScale, 0.2f).OnComplete(() => // ���ٽ�
                {
                    eventIcons[eventIconIndex].transform.DOScale(originalScale, 0.2f);
                });

                // ��ġ�ϴ� ���� ������ ����
                if (slotIcon01.sprite == eventSprite)
                {
                    slotIcon01.transform.DOScale(targetScale, 0.2f).OnComplete(() => // ���ٽ�
                    {
                        slotIcon01.transform.DOScale(originalScale, 0.2f);
                    });
                }

                if (slotIcon02.sprite == eventSprite)
                {
                    slotIcon02.transform.DOScale(targetScale, 0.2f).OnComplete(() => // ���ٽ�
                    {
                        slotIcon02.transform.DOScale(originalScale, 0.2f);
                    });
                }

                if(slotIcon03.sprite == eventSprite)
                {
                    slotIcon03.transform.DOScale(targetScale, 0.2f).OnComplete(() => // ���ٽ�
                    {
                        slotIcon03.transform.DOScale(originalScale, 0.2f);
                    });
                }

                // ��ġ�ϴ� �����ܿ� ���� ���� ����
                if (eventSprite.name == "mon_Icon")
                {
                    StartCoroutine(ActivateAndDeactivateScore(monScore));
                }
                else if (eventSprite.name == "coin02")
                {
                    StartCoroutine(ActivateAndDeactivateScore(healScore));
                }
                else if (eventSprite.name == "heart3")
                {
                    StartCoroutine(ActivateAndDeactivateScore(fanScore));
                }

                success.gameObject.SetActive(true);
                Invoke("DeactivateSuccessImage", 0.5f);

                eventStart = false;
                Invoke("EventRestart", 1f);
                Invoke("EventChange", 1f);
            }
        }

        Invoke("Slotfalse", 1f);

    }

    public void Slotfalse()
    {
        slotIcon01.gameObject.SetActive(false);
        slotIcon02.gameObject.SetActive(false);
        slotIcon03.gameObject.SetActive(false);
    }

    public void EventRestart()
    {
        eventStart = true;
    }

    // �ڷ�ƾ�� �̿��Ͽ� ���� �ð� ���� GameObject�� Ȱ��ȭ �� ��Ȱ��ȭ
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

        // ���� �����ܵ�� ���Ͽ� ��ġ�ϴ� ���� ����
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
        // ���� �̹��� ��Ȱ��ȭ
        success.gameObject.SetActive(false);
    }

    private void DeactivateFailImage()
    {
        // ���� �̹��� ��Ȱ��ȭ
        fail.gameObject.SetActive(false);
    }

    private void EndGame()
    {
        // ���� ���� ó��

        // �ߺ� ȣ�� ����
        if (!isGameRunning)
        {
            return;
        }

        isGameRunning = false;

    }
}
