using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class TimerController: MonoBehaviour
{
    public MainController mainController;

    public Slider timerSlider;           // ���� �ð� UI �����̴� ����
    public float timer = 30f;            // ���� �ð� 30�� ����
    public float readyCounter = 3f;      // ��� �ð� 3�� ����
    public float showCounter = 3f;       // ���� �ð� 3�� ����
    public Text timerText;               // ���� �ð� ���
    public Text readyCount;              // ��� �ð� ���
    public Text showMessage;             // ���� �޼��� ���
    public Image readyCountBG;           // ��� �ð� BG
    public AudioSource readyCount_SFX;   // ��� �ð� ȿ����

    
    public void Start()
    {
        // �ʱ�ȭ
        timer = 30f;
        readyCounter = 3f;
        showCounter = 4f;
        timerSlider.maxValue = timer;
        timerSlider.value = timer;

        readyCount_SFX.Stop();

        // ���� ī��Ʈ�� 1�� �ڿ� 1�ʸ��� ����
        InvokeRepeating("ReadyCounter", 0, 1f);                
       
    }

    public void ReadyCounter()
    {
        // ������ �Ͻ� ���� ���� ��� ��ȯ
        if (mainController.isGamePaused)
            return;
       
        readyCounter -= 1f; // Ÿ�̸� ����
        readyCountBG.gameObject.SetActive(true);              
        readyCount.text = readyCounter.ToString();
        readyCount_SFX.Play();

        // �����̴� �� ����
        timerSlider.value = timer;

        if (readyCounter < 0)
        {
            readyCounter = 0;
            readyCount_SFX.Stop();
            readyCountBG.gameObject.SetActive(false);

            ShowCounter();
        }
    }

    public void ShowCounter()
    {
        showCounter -= 1f;
        showMessage.gameObject.SetActive(true);
        showMessage.text = showCounter.ToString() + "�� �� �̹����� ������ϴ�.";


        if (showCounter <= 0)
        {
            showMessage.gameObject.SetActive(false);
            showCounter = 0;
            UpdateTimer();

        }
    }
    public void UpdateTimer()
    {
        // ������ �Ͻ� ���� ���� ��� ��ȯ
        if (mainController.isGamePaused)
            return;

        // ������ �������� ���
        if (mainController.isGameRunnig == true)
        {
            timerText.text = timer.ToString("F0");  // 1�� �ڸ����� ǥ��
            timer -= 1f; // Ÿ�̸� ����

            // �����̴� �� ����
            timerSlider.value = timer;

            // Ÿ�̸Ӱ� ������ (0���� ���� ���� -1�� ����)
            if (timer <= -1)
            {
                timer = -1;
                TimeOver();
                mainController.isGameRunnig = false;
            }
        }
    } 

    // �ð��� �� �Ǹ� ���� ���� ȭ���� Ȱ��ȭ
    public void TimeOver()
    {
        mainController.Score();
        mainController.Main_BGM2.Stop();
        mainController.isGameRunnig = false;
        mainController.ResultBGBG.gameObject.SetActive(true);
        mainController.pauseBG.gameObject.SetActive(true);

        // � ������Ʈ�� �����Ұ���?
        mainController.ResultBGBG = GameObject.Find("ResultBGBG").GetComponent<Image>();
        mainController.ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        mainController.Restart = GameObject.Find("Restart").GetComponent<Button>();
        mainController.HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        mainController.UserScore = GameObject.Find("UserScoretxt").GetComponent<Text>();
    }




}
