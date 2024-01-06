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
    public Text getscore;

    // ���� �ð��� ��Ÿ���� Ÿ�̸�
    public float timer = 30f;
    // ���� ���� ����
    public static int getScore = 0;

    private void Awake()
    {
        this.goodsCountBar = GameObject.Find("goodsCountBar");
        this.goodsCountBar.GetComponent<Image>().fillAmount = 0f;
        this.Player = GameObject.Find("Player");
       
        Debug.Log("Awake");

    }
    void Start()
    {
        
    }

    // ���� ���� ���� �޼���
    public void GoodsCountUP()
    {

        Debug.Log("GoodsCountUP");
        // goodsCountBar�� fillAmount �Ӽ��� �������� ���� ���� ���� ǥ��
        this.goodsCountBar.GetComponent<Image>().fillAmount += 0.5f;
        getScore++;
        getscore.text = getScore.ToString();

        
    }

    public void GoodsCountDown()
    {


        Debug.Log("GoodsCountDown");
        // goodsCountBar�� fillAmount �Ӽ��� ���ҽ��� ���� ���� ���� ǥ��
        this.goodsCountBar.GetComponent<Image>().fillAmount -= 0.5f;
        getScore--;
        getscore.text = getScore.ToString();

       
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

            Debug.Log("timer <= 0");
            gameover.SetActive(true);
            gameRestart.SetActive(false);
            gamePlay.SetActive(false);
        }

        // ���� ��� ������ ������ŭ ������ ���� ���� ȭ���� Ȱ��ȭ�ϰ� �ð��� ������Ŵ
        else if (goodsCountBar.GetComponent<Image>().fillAmount >= 1)   
        {

            Debug.Log("goodsCountBar.GetComponent<Image>().fillAmount >= 1");
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
   

        Debug.Log("Restart");
    }
}
