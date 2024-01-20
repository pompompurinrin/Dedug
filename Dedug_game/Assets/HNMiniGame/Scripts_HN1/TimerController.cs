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
    public Slider timerSlider; // UI �����̴� ����
    public float timer = 30f; // ���� �ð� 30�� ����
    public Text timeText; // �ð� ���
    public float readyCounter = 3f; //��� �ð� 3�� ����
    public Text readyCount; // ��� �ð� ���

    [SerializeField] private GameControllerScript gameController;

    // ���� �غ� ���¸� ��Ÿ���� ����
    public bool isReady = false;

    public void Start()
    {
        // �����̴� �ʱ�ȭ
        timerSlider.maxValue = timer;
        timerSlider.value = timer;

        //Invoke("Timer", 4);
        InvokeRepeating("ReadyCounter", 0f, 1f);

        //PercentageTable_1���� �迭�� ����Ұ�
        gameController.data_Dialog = CSVReader.Read("PercentageTable");
    }

    public void ReadyCounter()
    {       
        if (gameController.isGamePaused)
            return;

        isReady = true;
        readyCount.gameObject.SetActive(true);  
        readyCount.text = readyCounter.ToString() + "�� �� �̹����� ������ϴ�.";
        readyCounter -= 1f; // Ÿ�̸� ����

        // �����̴� �� ����
        timerSlider.value = timer;

        if (readyCounter <= -1)
        {

            readyCounter = -1;
            
            UpdateTimer();
        }
    }
    public void UpdateTimer()
    {
        
        if (gameController.isGamePaused)
            return;

        isReady = false;
        readyCount.gameObject.SetActive(false);
        gameController.Scoretxt.gameObject.SetActive(true);


        timeText.text = timer.ToString("F0");  // 1�� �ڸ����� ǥ��
        timer -= 1f; // Ÿ�̸� ����

        // �����̴� �� ����
        timerSlider.value = timer;

        if (timer <= -1)
        {

            timer = -1;
            TimeOver();

        }
    }


  

    // �ð��� �� �Ǹ� ���� ���� ȭ���� Ȱ��ȭ
    public void TimeOver()
    {

        gameController.Score();
        gameController.ResultBG.gameObject.SetActive(true);
        // gameController2.Main_BGM2.Stop();
        // � ������Ʈ�� �����Ұ���?
        gameController.ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        gameController.ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        gameController.Restart = GameObject.Find("Restart").GetComponent<Button>();
        gameController.HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        gameController.UserScore = GameObject.Find("UserScoretxt").GetComponent<Text>();  //�־ȵǴ°����Ф�
    }




}