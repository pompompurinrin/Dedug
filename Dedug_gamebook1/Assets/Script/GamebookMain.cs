using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamebookManager : MonoBehaviour
{
    public Image exitPopup; // 이미지 참조 변수
   
    void Start()
    {
        // 나가기 버튼에 클릭 이벤트 등록
        Button exitButton = transform.Find("exitBtn").GetComponent<Button>();
        exitButton.onClick.AddListener(ShowPopup);

        // 버튼에 클릭 이벤트 리스너 추가
        bgmButton.onClick.AddListener(OnBGMButtonClicked);
        bgmButton = transform.Find("musicBtn").GetComponent<Button>();

        exitPopup.gameObject.SetActive(false);
        // 버튼의 텍스트 업데이트
        UpdateButton();
        
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
