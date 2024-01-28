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

    // ���� �Ͻ����� ���¸� ��Ÿ���� ����
    public bool isGamePaused = false;


    public void Start()
    {
        // �ʱ�ȭ
        timer = 30f;
        readyCounter = 4f;
        showCounter = 4f;
        timerSlider.maxValue = timer;
        timerSlider.value = timer;

        mainController.Main_BGM2.Play();         // ���� BGM ���
        mainController.correct_sfx.Stop();       // correct_sfx ����
        mainController.error_sfx.Stop();         // error_sfx ����
        mainController.Result_SFX.Stop();        // Result_SFX ����
        mainController.readyCount_SFX.Stop();    // readyCount_SFX ����
        readyCount_SFX.Stop();

        // ���� ī��Ʈ�� 1�� �ڿ� 1�ʸ��� ����
        InvokeRepeating("ReadyCounter", 0, 1f);
        Input.multiTouchEnabled = false;
    }

    public void ReadyCounter()
    {
        Debug.Log("ReadyCounter");

        // ������ �Ͻ� ���� ���� ��� ��ȯ
        if (isGamePaused)
            return;

        readyCounter -= 1f;                             // ��� �ð� 1�ʾ� ����
        readyCountBG.gameObject.SetActive(true);        // ��� �ð� BG ���
        readyCount.text = readyCounter.ToString();      // ��� �ð� ���
        readyCount_SFX.Play();                          // ��� �ð� ȿ���� �־�

        if (readyCounter == 0)
        {
            readyCounter = 0;                           // ��� �ð� 0
            readyCount_SFX.Stop();                      // ��� �ð� ȿ���� ����
            readyCountBG.gameObject.SetActive(false);   // ��� �ð� BG ����
            CancelInvoke("ReadyCounter");

            // Ÿ�̸Ӹ� 1�� �ڿ� 1�ʸ��� ����
            InvokeRepeating("GamePlay", 0, 1);
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
        mainController.Result_SFX.Play();

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
