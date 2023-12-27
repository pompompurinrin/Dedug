using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamebookManager : MonoBehaviour
{
    public Image exitPopup; // �̹��� ���� ����
    public Button SaveBtn;
    public Image savePopup;

    void Start()
    {
        // ������ ��ư�� Ŭ�� �̺�Ʈ ���
        Button exitButton = transform.Find("exitBtn").GetComponent<Button>();
        exitButton.onClick.AddListener(ShowPopup);

        // ��ư�� Ŭ�� �̺�Ʈ ������ �߰�
        bgmButton.onClick.AddListener(OnBGMButtonClicked);
        bgmButton = transform.Find("musicBtn").GetComponent<Button>();

        SaveBtn = transform.Find("SaveBtn").GetComponent<Button>();
        SaveBtn.onClick.AddListener(SaveButtonClicked);

        SaveBtn.gameObject.SetActive(false);
        exitPopup.gameObject.SetActive(false);
        savePopup.gameObject.SetActive(false);
        
        // ��ư�� �ؽ�Ʈ ������Ʈ
        UpdateButton();
    }
    void SaveButtonClicked()
    {
        savePopup.gameObject.SetActive(true);
        Button saveButton = transform.Find("saveBtn").GetComponent<Button>();
        saveButton.onClick.AddListener(realSave);

        Button closeButton = savePopup.transform.Find("cancelBtn").GetComponent<Button>();
        closeButton.onClick.AddListener(HidePopup);

    }
    
    void realSave()
    {
        int love1 = MainController.love01;
        int love2 = MainController.love02;
        int love3 = MainController.love03;

        PlayerPrefs.SetInt("love1", love1);
        PlayerPrefs.SetInt("love2", love2);
        PlayerPrefs.SetInt("love3", love3);
        
        //clickNum = �ش� �б��� ID;
        PlayerPrefs.Save();

    }

    void ShowPopup()
    {
        // �̹��� Ȱ��ȭ
        exitPopup.gameObject.SetActive(true);

        // �˾��� ��ư�� Ŭ�� �̺�Ʈ ���
        Button closeButton = exitPopup.transform.Find("cancelBtn").GetComponent<Button>();
        closeButton.onClick.AddListener(HidePopup);

        Button exitButton = exitPopup.transform.Find("exitBtn").GetComponent<Button>();
        exitButton.onClick.AddListener(ChangeMainScene);

    }

    void ChangeMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    void HidePopup()
    {
        // �̹��� ��Ȱ��ȭ
        exitPopup.gameObject.SetActive(false);
        savePopup.gameObject.SetActive(false);
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
