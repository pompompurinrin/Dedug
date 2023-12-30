using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamebookManager : MonoBehaviour
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

        Image mainblackBG = GameObject.Find("mainblackBG").GetComponent<Image>();

        loadBtn.gameObject.SetActive(false);
        startBtn.gameObject.SetActive(false);
        mainblackBG.gameObject.SetActive(false);

        Button mainBtn = GameObject.Find("mainBtn").GetComponent<Button>();
        mainBtn.onClick.AddListener(ShowPopup);

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
        MainController.evelove = PlayerPrefs.GetInt("evelove", 0);
        MainController.micalove = PlayerPrefs.GetInt("micalove", 0);
        MainController.woolove = PlayerPrefs.GetInt("woolove", 0);
        MainController.clickNum = 36;
        SceneManager.LoadScene("TalkScene");

    }

    void startBtnClick()
    {
        MainController.evelove = 0;
        MainController.micalove = 0;
        MainController.woolove = 0;

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
