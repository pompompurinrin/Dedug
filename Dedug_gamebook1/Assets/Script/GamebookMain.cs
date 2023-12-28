using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamebookMain : MonoBehaviour
{
    public Image exitPopup; // 이미지 참조 변수
    public Button SaveBtn;
    public Image savePopup;
    public Text saveSystemText;
    void Start()
    {
        // 나가기 버튼에 클릭 이벤트 등록
        Button exitButton = transform.Find("exitBtn").GetComponent<Button>();
        exitButton.onClick.AddListener(ShowPopup);

        // 버튼에 클릭 이벤트 리스너 추가
        bgmButton.onClick.AddListener(OnBGMButtonClicked);
        bgmButton = transform.Find("musicBtn").GetComponent<Button>();

        SaveBtn = GameObject.Find("select").transform.Find("SaveBtn").GetComponent<Button>();
        SaveBtn.onClick.AddListener(SaveButtonClicked);

        Button saveButton = savePopup.transform.Find("saveBtn").GetComponent<Button>();
        saveButton.onClick.AddListener(realSave);

        Button closeButton = savePopup.transform.Find("cancelBtn").GetComponent<Button>();
        closeButton.onClick.AddListener(HidePopupup);

        SaveBtn.gameObject.SetActive(false);
        exitPopup.gameObject.SetActive(false);
        GameObject.Find("saveSystemText").gameObject.SetActive(false);
        GameObject.Find("savePopup").gameObject.SetActive(false);

        // 버튼의 텍스트 업데이트
        UpdateButton();
    }


    void SaveButtonClicked()
    {
        savePopup.gameObject.SetActive(true);
        Button saveButton = savePopup.transform.Find("saveBtn").GetComponent<Button>();
        saveButton.onClick.AddListener(realSave);

        Button closeButton = savePopup.transform.Find("cancelBtn").GetComponent<Button>();
        closeButton.onClick.AddListener(HidePopupup);

    }
    
    void realSave()
    {
        int love1 = MainController.love01;
        int love2 = MainController.love02;
        int love3 = MainController.love03;

        PlayerPrefs.SetInt("love1", love1);
        PlayerPrefs.SetInt("love2", love2);
        PlayerPrefs.SetInt("love3", love3);
        
        //clickNum = 해당 분기점 ID;
        PlayerPrefs.Save();

        savePopup.gameObject.SetActive(false);

        saveSystemText.gameObject.SetActive(true);
        //text 페이드아웃 애니메이션 삽입 해야 됩니다.
    }

    void ShowPopup()
    {
        // 이미지 활성화
        exitPopup.gameObject.SetActive(true);

        // 팝업의 버튼에 클릭 이벤트 등록
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
        // 이미지 비활성화
        exitPopup.gameObject.SetActive(false);
    }
    void HidePopupup()
    {
        // 이미지 비활성화
        
        savePopup.gameObject.SetActive(false);
    }

    public AudioSource bgmAudioSource; // 배경 음악을 재생하는 AudioSource
    public Button bgmButton; // BGM On/Off를 제어하는 버튼
    
    public Sprite bgmOn;
    public Sprite bgmOff;

    // BGM On/Off 버튼 클릭에 대한 이벤트 핸들러
    void OnBGMButtonClicked()
    {
        if (bgmAudioSource.isPlaying)
        {
            // BGM이 재생 중이면 정지
            bgmAudioSource.Pause();
            bgmButton.image.sprite = bgmOff;
        }
        else
        {
            // BGM이 정지 중이면 재생
            bgmAudioSource.Play();
            bgmButton.image.sprite = bgmOn;
        }

        // 버튼 텍스트 업데이트
        UpdateButton();
    }

    // 버튼 텍스트 업데이트 메서드
    void UpdateButton()
    {
        bgmButton.image.sprite = bgmAudioSource.isPlaying ? bgmOn : bgmOff;
    }
}
