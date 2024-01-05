using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame_01_Manager : MonoBehaviour
{
    // �÷��̾� ���� ������ ��Ÿ���� ������ GameObject
    GameObject goodsCountBar;
    GameObject Player;
    // ���� ���� ȭ���� ��Ÿ���� GameObject
    public GameObject gameover;
    public GameObject gameRestart;
    public GameObject gamePlay;
    public Text time;

    // ���� �ð��� ��Ÿ���� Ÿ�̸�
    public float timer = 30f;

    private void Awake()
    {
        this.goodsCountBar = GameObject.Find("goodsCountBar");
        this.goodsCountBar.GetComponent<Image>().fillAmount = 0f;
        this.Player = GameObject.Find("Player");
    }
    void Start()
    {
        // ���� �� goodsCountBar�� ã�Ƽ� �Ҵ�
        
    }

    // ���� ���� ���� �޼���
    public void GoodsCountUP()
    {
        // goodsCountBar�� fillAmount �Ӽ��� �������� ���� ���� ���� ǥ��
        this.goodsCountBar.GetComponent<Image>().fillAmount += 0.5f;
       

        // ���� ��� ������ ������ŭ ������ ���� ���� ȭ���� Ȱ��ȭ�ϰ� �ð��� ������Ŵ
        if (goodsCountBar.GetComponent<Image>().fillAmount >= 1)
        {
          
            gameover.SetActive(true);
            gameRestart.SetActive(false);
            gamePlay.SetActive(false);
            timer = 0f;
        }
    }

    public void GoodsCountDown()
    {
        // goodsCountBar�� fillAmount �Ӽ��� �������� ���� ���� ���� ǥ��
        this.goodsCountBar.GetComponent<Image>().fillAmount -= 0.5f;


        // ���� ��� ������ ������ŭ ������ ���� ���� ȭ���� Ȱ��ȭ�ϰ� �ð��� ������Ŵ
        if (goodsCountBar.GetComponent<Image>().fillAmount >= 1)
        {

            gameover.SetActive(true);
            gameRestart.SetActive(false);
            gamePlay.SetActive(false);
            timer = 0f;
        }
    }

    // �ֱ������� ȣ��Ǵ� ������Ʈ �޼���
    public void Update()
    {
        // Ÿ�̸� ���� �ؽ�Ʈ�� ǥ��
        time.text = timer.ToString("F0");  // 1�� �ڸ����� ǥ��
        timer -= Time.deltaTime;

        // �ð��� �� �Ǹ� ���� ���� ȭ���� Ȱ��ȭ
        if (timer <= 0)
        {
            gameover.SetActive(true);
            gameRestart.SetActive(false);
            gamePlay.SetActive(false);
        }
    }

    // ���� ����� �޼���
    public void Restart()
    {
        // goodsCountBar�� �ʱ� ���·� �ǵ����� ���� ���� ȭ���� ��Ȱ��ȭ�ϸ� �ð��� �ٽ� ����
        this.goodsCountBar.GetComponent<Image>().fillAmount = 0;
        this.Player.transform.position = new Vector3(0, -5, 1);
        gameover.SetActive(false);
        gamePlay.SetActive(true);
        timer = 30f;
    }
}
