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

    public Button slotBtn1;
    public Button slotBtn2;
    public Button slotBtn3;

    void Start()
    {
        // ��ư�� Ŭ�� �̺�Ʈ ������ �߰�
        bgmButton.onClick.AddListener(OnBGMButtonClicked);
        bgmButton = transform.Find("musicBtn").GetComponent<Button>();

        loadBtn.gameObject.SetActive(false);
        startBtn.gameObject.SetActive(false);
        mainblackBG.gameObject.SetActive(false);
        slotBtn1.gameObject.SetActive(false);
        slotBtn2.gameObject.SetActive(false);
        slotBtn3.gameObject.SetActive(false);
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

    public void StartClick()
    {
        SceneManager.LoadScene("TalkScene");
    }

    public void LoadClick()
    {
        loadBtn.gameObject.SetActive(false);
        startBtn.gameObject.SetActive(false);
        

        slotBtn1.gameObject.SetActive(true);
        slotBtn2.gameObject.SetActive(true);
        slotBtn3.gameObject.SetActive(true);

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
