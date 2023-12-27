using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamebookMain : MonoBehaviour
{
    public Button loadBtn;
    public Button startBtn;
    public Image mainblackBG;
    
 

    void Start()
    {
        // ��ư�� Ŭ�� �̺�Ʈ ������ �߰�
        bgmButton.onClick.AddListener(OnBGMButtonClicked);
        bgmButton = transform.Find("musicBtn").GetComponent<Button>();
        Button startBtn = GameObject.Find("startBtn").GetComponent<Button>();
        startBtn.onClick.AddListener(startBtnClick);

        Button loadBtn = GameObject.Find("loadBtn").GetComponent<Button>();
        loadBtn.onClick.AddListener(loadBtnClick);

        loadBtn.gameObject.SetActive(false);
        startBtn.gameObject.SetActive(false);
        mainblackBG.gameObject.SetActive(false);



        // ��ư�� �ؽ�Ʈ ������Ʈ
        UpdateButton();
        
    }

    public void ShowPopup()
    {
        // �̹��� Ȱ��ȭ
        loadBtn.gameObject.SetActive(true);
        startBtn.gameObject.SetActive(true);
        mainblackBG.gameObject.SetActive(true);

      
    }
    void loadBtnClick()
    {
        MainController.love01 = PlayerPrefs.GetInt("love1", 0);
        MainController.love02 = PlayerPrefs.GetInt("love2", 0);
        MainController.love03 = PlayerPrefs.GetInt("love3", 0);
        //MainController.clickNum = ������ �б� ID;
        SceneManager.LoadScene("TalkScene");

    }

    void startBtnClick()
    {
        MainController.love01 = 0;
        MainController.love02 = 0;
        MainController.love03 = 0;

        MainController.clickNum = 0;

        SceneManager.LoadScene("TalkScene");

    }



    public AudioSource bgmAudioSource; // ��� ������ ����ϴ� AudioSource
    public Button bgmButton; // BGM On/Off�� �����ϴ� ��ư
    
    public Sprite bgmOn;
    public Sprite bgmOff;

    // BGM On/Off ��ư Ŭ���� ���� �̺�Ʈ �ڵ鷯
    void OnBGMButtonClicked()
    {
        if (bgmAudioSource.isPlaying)
        {
            // BGM�� ��� ���̸� ����
            bgmAudioSource.Pause();
            bgmButton.image.sprite = bgmOff;
        }
        else
        {
            // BGM�� ���� ���̸� ���
            bgmAudioSource.Play();
            bgmButton.image.sprite = bgmOn;
        }

        // ��ư �ؽ�Ʈ ������Ʈ
        UpdateButton();
    }

    // ��ư �ؽ�Ʈ ������Ʈ �޼���
    void UpdateButton()
    {
        bgmButton.image.sprite = bgmAudioSource.isPlaying ? bgmOn : bgmOff;
    }
}
