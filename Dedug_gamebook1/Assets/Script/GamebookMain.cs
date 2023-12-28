using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GamebookMain : MonoBehaviour
{
    public Image exitPopup; // �̹��� ���� ����
    public Button SaveBtn;
    public Image savePopup;
    public Text saveSystemText;

    // FadeOut
    public Color targetColor = Color.red;
    public float fadeDuration = 2f;

    void Start()
    {
        // ������ ��ư�� Ŭ�� �̺�Ʈ ���
        Button exitButton = transform.Find("exitBtn").GetComponent<Button>();
        exitButton.onClick.AddListener(ShowPopup);

        // ��ư�� Ŭ�� �̺�Ʈ ������ �߰�
        bgmButton.onClick.AddListener(OnBGMButtonClicked);
        bgmButton = transform.Find("musicBtn").GetComponent<Button>();

        SaveBtn = GameObject.Find("select").transform.Find("SaveBtn").GetComponent<Button>();
        SaveBtn.onClick.AddListener(SaveButtonClicked);

        Button saveButton = savePopup.transform.Find("saveBtn").GetComponent<Button>();
        saveButton.onClick.AddListener(realSave);

        Button closeButton = savePopup.transform.Find("cancelBtn").GetComponent<Button>();
        closeButton.onClick.AddListener(HidePopupup);

        // �׽�Ʈ�ϰ� �ٽ� Ȱ��ȭ�ϱ�
        SaveBtn.gameObject.SetActive(false);
        exitPopup.gameObject.SetActive(false);
        GameObject.Find("saveSystemText").gameObject.SetActive(false);
        GameObject.Find("savePopup").gameObject.SetActive(false);

        // ��ư�� �ؽ�Ʈ ������Ʈ
        UpdateButton();
    }


    // �����ϱ� ������ �� ���� �˾� ����
    void SaveButtonClicked()
    {
        savePopup.gameObject.SetActive(true);
        Button saveButton = savePopup.transform.Find("saveBtn").GetComponent<Button>();
        saveButton.onClick.AddListener(realSave);

        Button closeButton = savePopup.transform.Find("cancelBtn").GetComponent<Button>();
        closeButton.onClick.AddListener(HidePopupup);

    }
    
    // �����ϱ��� �����ϱ� ������ �� ����Ǵ°�
    void realSave()
    {
        int evelove = MainController.evelove;
        int micalove = MainController.micalove;
        int woolove = MainController.woolove;

        PlayerPrefs.SetInt("evelove", evelove);
        PlayerPrefs.SetInt("micalove", micalove);
        PlayerPrefs.SetInt("woolove", woolove);
        
        //clickNum = �ش� �б��� ID;
        PlayerPrefs.Save();

        savePopup.gameObject.SetActive(false);

        saveSystemText.gameObject.SetActive(true);
        //text ���̵�ƿ� �ִϸ��̼� ���� �ؾ� �˴ϴ�.
    }

    // ������ �˾� ����
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

    // ������ ��ư�� �ڷΰ��� ������ �� ������ �˾� �ݱ�
    void HidePopup()
    {
        // �̹��� ��Ȱ��ȭ
        exitPopup.gameObject.SetActive(false);
    }

    // �����˾� �ڷΰ��� ������ �� �ݱ�
    void HidePopupup()
    {
        // �̹��� ��Ȱ��ȭ

        savePopup.gameObject.SetActive(false);

    }

    public AudioSource bgmAudioSource; // ��� ������ ����ϴ� AudioSource
    public AudioSource FXAudioSource;
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
            FXAudioSource.Pause();
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
