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
        this.Player = GameObject.Find("Player");
    }

    public void Start()
    {
        // �ʱ�ȭ
        Debug.Log("�ʱ�ȭ");
        timer = 60f;
        readyCounter = 3f;
        timerSlider.maxValue = timer;
        timerSlider.value = timer;
        //this.Player.transform.position = new Vector3(0, -5, 1);

        readyCount_SFX.Stop();

        // ���� ī��Ʈ�� 1�� �ڿ� 1�ʸ��� ����
        InvokeRepeating("ReadyCounter", 0f, 1f);

        // ������Ʈ Ȱ��ȭ ( �̰� �� �߰� �Ǿ����� Ȯ�� �ʿ� )
        mainController2.MagicalGirlsPrefab.gameObject.SetActive(true);
        Debug.Log("ù ���۽� ���� �ҳ� ��ȯ");
        mainController2.ObstaclePrefab.gameObject.SetActive(true);
        Debug.Log("ù ���۽� ��ֹ� ��ȯ");
        mainController2.StudentPrefab.gameObject.SetActive(true);
        Debug.Log("ù ���۽� �Ϲ� �л� ��ȯ");
    }

    public void ReadyCounter()
    {
        // ������ �Ͻ� ���� ���� ��� ��ȯ
        if (mainController2.isGamePaused)
            return;

        readyCountBG.gameObject.SetActive(true);
        readyCount.text = readyCounter.ToString();
        readyCounter -= 1f; // Ÿ�̸� ����
        readyCount_SFX.Play();

        // �����̴� �� ����
        timerSlider.value = timer;

        if (readyCounter < 0)
        {
            readyCountBG.gameObject.SetActive(false);
            readyCount_SFX.Stop();
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
            readyCounter = 0;
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
        
        //Player.gameObject.SetActive(false);
        //mainController2.MagicalGirlsPrefab.gameObject.SetActive(false);
        //mainController2.ObstaclePrefab.gameObject.SetActive(false);
        //mainController2.StudentPrefab.gameObject.SetActive(false);

        // ������ ������ ��ƼŬ ����Ʈ ������ >> �ٸ� ��� ���� ��
        mainController2.heal_fx.transform.position = new Vector3(0, -5000, 1);
        Debug.Log("mainController2.heal_fx.transform.position = new Vector3(0, -5000, 1);");
        mainController2.hit_fx.transform.position = new Vector3(0, -5000, 1);
        Debug.Log("mainController2.hit_fx.transform.position = new Vector3(0, -5000, 1);");

        mainController2.Score();
        mainController2.ResultBG.gameObject.SetActive(true);
        mainController2.pauseBG.gameObject.SetActive(true);
        mainController2.pauseBG1.gameObject.SetActive(true);
        mainController2.Main_BGM.Stop();
        mainController2.isGameRunnig = false;

        // � ������Ʈ�� �����Ұ���?
        mainController2.ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        mainController2.ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        mainController2.Restart = GameObject.Find("Restart").GetComponent<Button>();
        mainController2.HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        mainController2.UserScoretxt = GameObject.Find("UserScoretxt").GetComponent<Text>();
    }
}
