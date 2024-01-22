using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class HJMinigameManager : MonoBehaviour
{

    public Slider fighrGaugeObj;
    public Text congCharScoreText;
    public Text doCharScoreText;
    public Text timerText;

    public Image roundBg;
    public Text roundText;

    public int fighrGauge;
    
    public int congScore;
    public int doScore;

    public float timer;
    public int roundCount = 0;

    public bool round;

    public Button go;



    public void Start()
    {
        // 게임 시작 시 첫 번째 라운드 활성화
        StartRound();
    }

    public void Update()
    {
        // 라운드가 활성화된 경우 타이머 감소
        if (round == true)
        {
            UpdateTimer();
        }
    }

    void UpdateTimer()
    {
        timer -= Time.deltaTime; // 프레임당 감소된 시간을 빼줌

        // 타이머가 0 이하로 내려갔을 때
        if (timer <= 0)
        {
            // 라운드 종료 처리
            EndRound();
            timer = 0;

        }

        // 1초에 한 번씩 fiverGauge를 감소시킴
        int currentSecond = Mathf.FloorToInt(timer);
        if (currentSecond < Mathf.FloorToInt(timer + Time.deltaTime))
        {
            FighrValue();
        }

        // UI에 타이머 값 업데이트
        timerText.text = timer.ToString();
    }

    void StartRound()
    {
        // 라운드 시작 시 초기화
        timer = 10;

        // fiverGauge 초기화
        fighrGauge = 0;
        fighrGaugeObj.value = fighrGauge;

        congCharScoreText.text = congScore.ToString();
        doCharScoreText.text = doScore.ToString();

        round = true;
    }

    public void ClickButton()
    {
        fighrGauge++;
        fighrGaugeObj.value = fighrGauge;

        if (fighrGauge == 10)
        {
            EndRound();
        }
    }


    void FighrValue()
    {
        fighrGauge--;
        fighrGaugeObj.value = fighrGauge;

    }

    void EndRound()
    {

        if(roundCount == 1)
        {
            roundText.text = "라운드 2!";
        }

        if(roundCount == 2)
        {
            roundText.text = "라운드 3!";
        }

        if (fighrGauge >= 5)
        {
            congScore++;
        }

        if(fighrGauge < 5)
        {
            doScore++;
        }

        // 3라운드가 끝났을 때 게임 종료
        if (roundCount == 2)
        {
            EndGame();
        }

        // 라운드 종료 시 처리
        round = false;
        roundCount++;

        roundBg.gameObject.SetActive(true);

        Invoke("Nextround", 1f);
    }

    void Nextround()
    {
        roundBg.gameObject.SetActive(false);

        // 다음 라운드 시작
        StartRound();
    }

    void EndGame()
    {
        // 게임 종료 처리
        Debug.Log("Game Over");
        // 여기에 게임 종료에 관련된 처리를 추가할 수 있습니다.
    }
}
