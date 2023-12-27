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
        // 버튼에 클릭 이벤트 리스너 추가
        bgmButton.onClick.AddListener(OnBGMButtonClicked);
        bgmButton = transform.Find("musicBtn").GetComponent<Button>();

        loadBtn.gameObject.SetActive(false);
        startBtn.gameObject.SetActive(false);
        mainblackBG.gameObject.SetActive(false);
        slotBtn1.gameObject.SetActive(false);
        slotBtn2.gameObject.SetActive(false);
        slotBtn3.gameObject.SetActive(false);
        // 버튼의 텍스트 업데이트
        UpdateButton();
        
    }

    public void ShowPopup()
    {
        // 이미지 활성화
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
