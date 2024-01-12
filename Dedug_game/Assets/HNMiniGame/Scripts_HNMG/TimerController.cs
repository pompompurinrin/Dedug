using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Slider timerSlider; // UI �����̴� ����
    public float timer = 30f; // ���� �ð� 30�� ����
    public Text timeText; // �ð� ���
    public float readyCounter = 3f; //��� �ð� 3�� ����
    public Text readyCount; // ��� �ð� ���

    [SerializeField] private GameControllerScript scoreText;


    public void Start()
    {
        // �����̴� �ʱ�ȭ
        timerSlider.maxValue = timer;
        timerSlider.value = timer;

        Invoke("Timer", 4);
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
        

        readyCount.text = readyCounter.ToString("0"+ "�� �� �̹����� ������ϴ�.");
        readyCounter -= 1f; // Ÿ�̸� ����

        // �����̴� �� ����
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
        timeText.text = timer.ToString("F0");  // 1�� �ڸ����� ǥ��
        timer -= 1f; // Ÿ�̸� ����

        // �����̴� �� ����
        timerSlider.value = timer;

        if (timer <= 0)
        {

            timer = 0;
            TimeOver();
        }
    }


    public Button restartBtn;
    public Image MainBG;

    // �ð��� �� �Ǹ� ���� ���� ȭ���� Ȱ��ȭ
    public void TimeOver()
    {
        restartBtn.gameObject.SetActive(true);
        MainBG.gameObject.SetActive(false);

    }

    
    

}
