using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Slider timerSlider; // UI 슬라이더 연결
    public float timer = 30f; // 30초 설정
    public Text timeText; // 시간을 텍스트로 출력하기 위해 


  

    public void Start()
    {
        // 슬라이더 초기화
        timerSlider.maxValue = timer;
        timerSlider.value = timer;

        // 1초마다 타이머 업데이트
        
        Invoke("Timer", 3);
    }

    public void Timer()
    {
        InvokeRepeating("UpdateTimer", 0f, 1f);
    }



    public void UpdateTimer()
    {

        timeText.text = timer.ToString("F0");  // 1의 자리부터 표현
                                               // 타이머 감소
        timer -= 1f;

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
