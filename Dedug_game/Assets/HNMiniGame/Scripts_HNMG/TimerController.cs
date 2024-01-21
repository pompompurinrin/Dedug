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

    [SerializeField] private MainController mainController;
    
    public void Start()
    {
        // �����̴� �ʱ�ȭ
        timerSlider.maxValue = timer;
        timerSlider.value = timer;

        InvokeRepeating("ReadyCounter", 0f, 1f);                
       
    }

    public void ReadyCounter()
    {

        if (mainController.isGamePaused)
            return;
        
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
        if (mainController.isGamePaused)
            return;

        if(mainController.isGameRunnig == true)
        {
            readyCount.gameObject.SetActive(false);
            mainController.Scoretxt.gameObject.SetActive(true);


            timeText.text = timer.ToString("F0");  // 1�� �ڸ����� ǥ��
            timer -= 1f; // Ÿ�̸� ����

            // �����̴� �� ����
            timerSlider.value = timer;

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
        mainController.isGameRunnig = false;
        timer = 30;
        mainController.ResultBG.gameObject.SetActive(true);

        // � ������Ʈ�� �����Ұ���?
        mainController.ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        mainController.ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        mainController.Restart = GameObject.Find("Restart").GetComponent<Button>();
        mainController.HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        mainController.UserScore = GameObject.Find("UserScoretxt").GetComponent<Text>();
        mainController.Main_BGM2.Stop();
    }




}
