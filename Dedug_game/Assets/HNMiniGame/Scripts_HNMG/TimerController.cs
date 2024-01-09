using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Slider timerSlider; // UI �����̴� ����
    public float timer = 30f; // 30�� ����
    public Text timeText; // �ð��� �ؽ�Ʈ�� ����ϱ� ���� 


  

    public void Start()
    {
        // �����̴� �ʱ�ȭ
        timerSlider.maxValue = timer;
        timerSlider.value = timer;

        // 1�ʸ��� Ÿ�̸� ������Ʈ
        
        Invoke("Timer", 3);
    }

    public void Timer()
    {
        InvokeRepeating("UpdateTimer", 0f, 1f);
    }



    public void UpdateTimer()
    {

        timeText.text = timer.ToString("F0");  // 1�� �ڸ����� ǥ��
                                               // Ÿ�̸� ����
        timer -= 1f;

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
