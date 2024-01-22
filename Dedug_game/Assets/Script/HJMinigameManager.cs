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
        // ���� ���� �� ù ��° ���� Ȱ��ȭ
        StartRound();
    }

    public void Update()
    {
        // ���尡 Ȱ��ȭ�� ��� Ÿ�̸� ����
        if (round == true)
        {
            UpdateTimer();
        }
    }

    void UpdateTimer()
    {
        timer -= Time.deltaTime; // �����Ӵ� ���ҵ� �ð��� ����

        // Ÿ�̸Ӱ� 0 ���Ϸ� �������� ��
        if (timer <= 0)
        {
            // ���� ���� ó��
            EndRound();
            timer = 0;

        }

        // 1�ʿ� �� ���� fiverGauge�� ���ҽ�Ŵ
        int currentSecond = Mathf.FloorToInt(timer);
        if (currentSecond < Mathf.FloorToInt(timer + Time.deltaTime))
        {
            FighrValue();
        }

        // UI�� Ÿ�̸� �� ������Ʈ
        timerText.text = timer.ToString();
    }

    void StartRound()
    {
        // ���� ���� �� �ʱ�ȭ
        timer = 10;

        // fiverGauge �ʱ�ȭ
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
            roundText.text = "���� 2!";
        }

        if(roundCount == 2)
        {
            roundText.text = "���� 3!";
        }

        if (fighrGauge >= 5)
        {
            congScore++;
        }

        if(fighrGauge < 5)
        {
            doScore++;
        }

        // 3���尡 ������ �� ���� ����
        if (roundCount == 2)
        {
            EndGame();
        }

        // ���� ���� �� ó��
        round = false;
        roundCount++;

        roundBg.gameObject.SetActive(true);

        Invoke("Nextround", 1f);
    }

    void Nextround()
    {
        roundBg.gameObject.SetActive(false);

        // ���� ���� ����
        StartRound();
    }

    void EndGame()
    {
        // ���� ���� ó��
        Debug.Log("Game Over");
        // ���⿡ ���� ���ῡ ���õ� ó���� �߰��� �� �ֽ��ϴ�.
    }
}
