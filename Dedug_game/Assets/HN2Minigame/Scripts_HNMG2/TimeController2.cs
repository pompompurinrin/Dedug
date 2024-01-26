using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class TimeController2 : MonoBehaviour
{
    public MainController2 mainController2;

    public Slider timerSlider;           // ���� �ð� UI �����̴� ����
    public float timer = 30f;            // ���� �ð� 30�� ����
    public float readyCounter = 3f;      // ��� �ð� 3�� ����
    public Text timerText;               // ���� �ð� ���
    public Text readyCount;              // ��� �ð� ���
    public Image readyCountBG;           // ��� �ð� BG
    public AudioSource readyCount_SFX;   // ��� �ð� ȿ����

    GameObject Player;

    private void Awake()
    {
        Input.multiTouchEnabled = false;
        this.Player = GameObject.Find("Player");
    }

    public void Start()
    {
        Debug.Log("�ʱ�ȭ");

        // �ʱ�ȭ
        timer = 60f;
        readyCounter = 3f;
        timerSlider.maxValue = timer;
        timerSlider.value = timer;

        readyCount_SFX.Stop();

        // ���� ī��Ʈ�� 1�� �ڿ� 1�ʸ��� ����
        InvokeRepeating("ReadyCounter", 0, 1f);

        mainController2.MagicalGirlsPrefab.gameObject.SetActive(true);
        Debug.Log("MagicalGirlsPrefab.gameObject.SetActive(true);");
        mainController2.ObstaclePrefab.gameObject.SetActive(true);
        Debug.Log("ObstaclePrefab.gameObject.SetActive(true);");
        mainController2.StudentPrefab.gameObject.SetActive(true);
        Debug.Log("StudentPrefab.gameObject.SetActive(true);");
      
    }

    public void ReadyCounter()
    {
        // ������ �Ͻ� ���� ���� ��� ��ȯ
        if (mainController2.isGamePaused)
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

            UpdateTimer();
        }
    }

    public void UpdateTimer()
    {
        // ������ �Ͻ� ���� ���� ��� ��ȯ
        if (mainController2.isGamePaused)
            return;

        if (mainController2.isGameRunnig == true)
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
                mainController2.isGameRunnig = false;
            }
        }
    }
    // �ð��� �� �Ǹ� ���� ���� ȭ���� Ȱ��ȭ
    public void TimeOver() 
    {
        Debug.Log("Ÿ�� ����");

        mainController2.heal_fx.transform.position = new Vector3(0, -5000, 1);
        Debug.Log("�� ȿ�� ������");
        mainController2.hit_fx.transform.position = new Vector3(0, -5000, 1);
        Debug.Log("�ǰ� ȿ�� ������");

        mainController2.Score();
        mainController2.Main_BGM.Stop();

        mainController2.isGameRunnig = false;
        mainController2.ResultBGBG.gameObject.SetActive(true);
        mainController2.pauseBG.gameObject.SetActive(true);

        // � ������Ʈ�� �����Ұ���?
        mainController2.ResultBGBG = GameObject.Find("ResultBGBG").GetComponent<Image>();
        mainController2.ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        mainController2.Restart = GameObject.Find("Restart").GetComponent<Button>();
        mainController2.HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        mainController2.UserScore = GameObject.Find("UserScoretxt").GetComponent<Text>();
    }

}
