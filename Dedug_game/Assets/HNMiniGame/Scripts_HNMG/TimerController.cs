using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Slider timerSlider; // UI �����̴� ����
    public float timer = 30f; // ���� �ð� 30�� ����
    public Text timeText; // �ð� ���
    public float readyCounter = 10f; //��� �ð� 3�� ����
    public Text readyCount; // ��� �ð� ���


    [SerializeField] private GameControllerScript gameController;

    public void Start()
    {
        // �����̴� �ʱ�ȭ
        timerSlider.maxValue = timer;
        timerSlider.value = timer;

        //Invoke("Timer", 4);
        InvokeRepeating("ReadyCounter", 0f, 1f);
    }

    public void Timer()
    {
        // 1�ʸ��� Ÿ�̸� ������Ʈ
        InvokeRepeating("UpdateTimer", 0f, 1f);
    }

    public void ReadyCounter()
    {
        readyCount.gameObject.SetActive(true);  
        readyCount.text = readyCounter.ToString() + "�� �� �̹����� ������ϴ�.";
        readyCounter -= 1f; // Ÿ�̸� ����

        // �����̴� �� ����
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


        timeText.text = timer.ToString("F0");  // 1�� �ڸ����� ǥ��
        timer -= 1f; // Ÿ�̸� ����

        // �����̴� �� ����
        timerSlider.value = timer;

        if (timer <= -1)
        {

            timer = -1;
            TimeOver();
        }
    }


    public Image restartBG;
    public Image MainBG;

    // �ð��� �� �Ǹ� ���� ���� ȭ���� Ȱ��ȭ
    public void TimeOver()
    {
        restartBG.gameObject.SetActive(true);
        MainBG.gameObject.SetActive(false);

    }

    
    

}
