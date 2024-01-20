using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class TimerController2: MonoBehaviour
{
    public GameControllerScript2 gameController2;

    public Slider timerSlider; // UI �����̴� ����
    public float timer = 60f; // ���� �ð� 30�� ����
    public Text timeText; // �ð� ���

    public float readyCounter = 3f; //��� �ð� 3�� ����
    public Text readyCount; // ��� �ð� ���

    GameObject Player;

    private void Awake()
    {
        this.Player = GameObject.Find("Player");
    }

    public void Start()
    {
        Debug.Log("�ʱ�ȭ");

        // �����̴� �ʱ�ȭ
        timerSlider.maxValue = timer;
        timerSlider.value = timer;

        //Invoke("Timer", 4);
        InvokeRepeating("ReadyCounter", 0f, 1f);

        //PercentageTable_1���� �迭�� ����Ұ�
        gameController2.data_Dialog = CSVReader.Read("PercentageTable");
    }

    public void Timer()
    {
        // 1�ʸ��� Ÿ�̸� ������Ʈ
        InvokeRepeating("UpdateTimer", 0f, 1f);
    }

    public void ReadyCounter()
    {
        if (gameController2.isGamePaused)
            return;

        readyCount.gameObject.SetActive(true);  
        readyCount.text = readyCounter.ToString() + "�� �� �����մϴ�.";
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
        if (gameController2.isGamePaused)
            return;

        readyCount.gameObject.SetActive(false);
        gameController2.Scoretxt.gameObject.SetActive(true);

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
    
    public void TimeOver() // �ð��� �� �Ǹ� ���� ���� ȭ���� Ȱ��ȭ
    {     
        // �ʱ�ȭ ����
        this.Player.transform.position = new Vector3(0, -5, 1);
        timer = 60f;
        gameController2.Score();
        gameController2.ResultBG.gameObject.SetActive(true);
        // gameController2.Main_BGM2.Stop();

        // � ������Ʈ�� �����Ұ���?
        gameController2.ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        gameController2.ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        gameController2.Restart = GameObject.Find("Restart").GetComponent<Button>();
        gameController2.HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        gameController2.UserScore = GameObject.Find("UserScoretxt").GetComponent<Text>();
    }

}
