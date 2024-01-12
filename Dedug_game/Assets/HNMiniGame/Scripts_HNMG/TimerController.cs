using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Slider timerSlider; // UI 슬라이더 연결
    public float timer = 30f; // 제한 시간 30초 설정
    public Text timeText; // 시간 출력
    public float readyCounter = 3f; //대기 시간 3초 설정
    public Text readyCount; // 대기 시간 출력

    [SerializeField] private GameControllerScript scoreText;


    public void Start()
    {
        // 슬라이더 초기화
        timerSlider.maxValue = timer;
        timerSlider.value = timer;

        Invoke("Timer", 4);
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
        

        readyCount.text = readyCounter.ToString("0"+ "초 후 이미지가 사라집니다.");
        readyCounter -= 1f; // 타이머 감소

        // 슬라이더 값 갱신
        timerSlider.value = timer;

        if (readyCounter <= 0)
        {

            readyCounter = 0;
            
            UpdateTimer();
        }
    }
    public void UpdateTimer()
    {
        readyCount.gameObject.SetActive(false);
        timeText.text = timer.ToString("F0");  // 1의 자리부터 표현
        timer -= 1f; // 타이머 감소

        // 슬라이더 값 갱신
        timerSlider.value = timer;

        if (timer <= 0)
        {

            timer = 0;
            TimeOver();
        }
    }


    public Button restartBtn;
    public Image MainBG;

    // 시간이 다 되면 게임 오버 화면을 활성화
    public void TimeOver()
    {
        restartBtn.gameObject.SetActive(true);
        MainBG.gameObject.SetActive(false);

    }

    
    

}
