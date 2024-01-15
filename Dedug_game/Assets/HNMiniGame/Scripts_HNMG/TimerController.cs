using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Slider timerSlider; // UI 슬라이더 연결
    public float timer = 30f; // 제한 시간 30초 설정
    public Text timeText; // 시간 출력
    public float readyCounter = 10f; //대기 시간 3초 설정
    public Text readyCount; // 대기 시간 출력


    [SerializeField] private GameControllerScript gameController;

    public void Start()
    {
        // 슬라이더 초기화
        timerSlider.maxValue = timer;
        timerSlider.value = timer;

        //Invoke("Timer", 4);
        InvokeRepeating("ReadyCounter", 0f, 1f);
    }

    public void Timer()
    {
        // 1초마다 타이머 업데이트
        InvokeRepeating("UpdateTimer", 0f, 1f);
    }

    public void ReadyCounter()
    {
        readyCount.gameObject.SetActive(true);  
        readyCount.text = readyCounter.ToString() + "초 후 이미지가 사라집니다.";
        readyCounter -= 1f; // 타이머 감소

        // 슬라이더 값 갱신
        timerSlider.value = timer;

        if (readyCounter <= -1)
        {

            readyCounter = -1;
            
            UpdateTimer();
        }
    }
    public void UpdateTimer()
    {
        readyCount.gameObject.SetActive(false);
        gameController.scoreText.gameObject.SetActive(true);


        timeText.text = timer.ToString("F0");  // 1의 자리부터 표현
        timer -= 1f; // 타이머 감소

        // 슬라이더 값 갱신
        timerSlider.value = timer;

        if (timer <= -1)
        {

            timer = -1;
            TimeOver();
        }
    }


    public Image restartBG;
    public Image MainBG;

    // 시간이 다 되면 게임 오버 화면을 활성화
    public void TimeOver()
    {
        restartBG.gameObject.SetActive(true);
        MainBG.gameObject.SetActive(false);

    }

    
    

}
