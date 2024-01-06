using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame_01_Manager : MonoBehaviour
{
    // 플레이어 굿즈 개수를 나타내는 게이지 GameObject
    GameObject goodsCountBar;
    GameObject Player;
    // 게임 오버 화면을 나타내는 GameObject
    public GameObject gameover;
    public GameObject gameRestart;
    public GameObject gamePlay;
    public Text time;
    public Text getscore;

    // 남은 시간을 나타내는 타이머
    public float timer = 30f;
    // 얻은 굿즈 개수
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

    // 굿즈 개수 증가 메서드
    public void GoodsCountUP()
    {

        Debug.Log("GoodsCountUP");
        // goodsCountBar의 fillAmount 속성을 증가시켜 받은 굿즈 개수 표현
        this.goodsCountBar.GetComponent<Image>().fillAmount += 0.5f;
        getScore++;
        getscore.text = getScore.ToString();

        
    }

    public void GoodsCountDown()
    {


        Debug.Log("GoodsCountDown");
        // goodsCountBar의 fillAmount 속성을 감소시켜 받은 굿즈 개수 표현
        this.goodsCountBar.GetComponent<Image>().fillAmount -= 0.5f;
        getScore--;
        getscore.text = getScore.ToString();

       
    }

    // 주기적으로 호출되는 업데이트 메서드
    public void Update()
    {

        // 타이머 값을 텍스트로 표시
        time.text = timer.ToString("F0");  // 1의 자리부터 표현
        timer -= Time.deltaTime;

        // 시간이 다 되면 게임 오버 화면을 활성화
        if (timer <= 0)
        {

            Debug.Log("timer <= 0");
            gameover.SetActive(true);
            gameRestart.SetActive(false);
            gamePlay.SetActive(false);
        }

        // 만약 굿즈를 지정된 개수만큼 모으면 게임 오버 화면을 활성화하고 시간을 정지시킴
        else if (goodsCountBar.GetComponent<Image>().fillAmount >= 1)   
        {

            Debug.Log("goodsCountBar.GetComponent<Image>().fillAmount >= 1");
            gameover.SetActive(true);
            gameRestart.SetActive(false);
            gamePlay.SetActive(false);
            
        }
    }

    // 게임 재시작 메서드
    public void Restart()
    {
        // goodsCountBar를 초기 상태로 되돌리고 게임 오버 화면을 비활성화하며 시간을 다시 시작

        
        this.goodsCountBar.GetComponent<Image>().fillAmount = 0;
        this.Player.transform.position = new Vector3(0, -5, 1);
        gameover.SetActive(false);
        gamePlay.SetActive(true);
        timer = 30f;
   

        Debug.Log("Restart");
    }
}
