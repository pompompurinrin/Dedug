using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GamebookMain : MonoBehaviour
{
    public Image exitPopup; // 이미지 참조 변수
    public Button SaveBtn;
    public Image savePopup;
    public Text saveSystemText;

    // FadeOut
    public Color targetColor = Color.red;
    public float fadeDuration = 2f;

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

        // 테스트하고 다시 활성화하기
        SaveBtn.gameObject.SetActive(false);
        exitPopup.gameObject.SetActive(false);
        GameObject.Find("saveSystemText").gameObject.SetActive(false);
        GameObject.Find("savePopup").gameObject.SetActive(false);

        // 버튼의 텍스트 업데이트
        UpdateButton();
    }


    // 저장하기 눌렀을 때 저장 팝업 띄우기
    void SaveButtonClicked()
    {
        savePopup.gameObject.SetActive(true);
        Button saveButton = savePopup.transform.Find("saveBtn").GetComponent<Button>();
        saveButton.onClick.AddListener(realSave);

        Button closeButton = savePopup.transform.Find("cancelBtn").GetComponent<Button>();
        closeButton.onClick.AddListener(HidePopupup);

    }
    
    // 저장하기의 저장하기 눌렀을 때 저장되는거
    void realSave()
    {
        int evelove = MainController.evelove;
        int micalove = MainController.micalove;
        int woolove = MainController.woolove;

        PlayerPrefs.SetInt("evelove", evelove);
        PlayerPrefs.SetInt("micalove", micalove);
        PlayerPrefs.SetInt("woolove", woolove);
        
        //clickNum = 해당 분기점 ID;
        PlayerPrefs.Save();

        savePopup.gameObject.SetActive(false);

        saveSystemText.gameObject.SetActive(true);
        //text 페이드아웃 애니메이션 삽입 해야 됩니다.
    }

    // 나가기 팝업 띄우기
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

    // 나가기 버튼의 뒤로가기 눌렀을 때 나가기 팝업 닫기
    void HidePopup()
    {
        // 이미지 비활성화
        exitPopup.gameObject.SetActive(false);
    }

    // 저장팝업 뒤로가기 눌렀을 때 닫기
    void HidePopupup()
    {
        // 이미지 비활성화

        savePopup.gameObject.SetActive(false);

    }

    public AudioSource bgmAudioSource; // 배경 음악을 재생하는 AudioSource
    public AudioSource FXAudioSource;
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
            FXAudioSource.Pause();
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
