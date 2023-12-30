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
        // 버튼에 클릭 이벤트 리스너 추가
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
