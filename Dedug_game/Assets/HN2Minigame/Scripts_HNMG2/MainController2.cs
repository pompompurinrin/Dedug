using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainController2 : MonoBehaviour
{

    public int score = 0;                // ���ھ� �ʱⰪ

    int _count = 0;                      // � �� �� �����ϴ� ����
    int randPrefab;                      // �������� ������Ʈ ���� ����
    public float span;                   // �������� ������Ʈ �����Ǵ� �ֱ�

    // Ÿ�̸�
    public float gameTimer = 60;         // ���� �ð� 60�� ����
    public float readyCounter = 4;       // ��� �ð� 3�� ����
    public Slider gameTimerSlider;       // ���� �ð� UI �����̴� ����
    public Text gameTimerText;           // ���� �ð� ���
    public Text readyCount;              // ��� �ð� ���
    public Image readyCountBG;           // ��� �ð� BG
    
    // ����
    public AudioSource Main_BGM;         // ���� BGM
    public AudioSource heal_sfx;         // ��Ī ���� ����
    public AudioSource hit_sfx;          // ��Ī ���� ����
    public AudioSource readyCount_SFX;   // ��� �ð� ȿ����

    // ����Ʈ
    public GameObject heal_fx;           // �� ȿ��
    public GameObject hit_fx;            // �ǰ� ȿ��

    // ���â UI
    public Image ResultBGBG;
    public Image ScoreBG;
    public Text Scoretxt;
    public Text UserScore;
    public Text Rewardtxt;
    public Button Restart;
    public Button HomeBtn;
    public GameObject RestartPopup;
    public GameObject GoldlackPopup;
    public Text RestartGoldText;

    // ���� ȿ�� �� ����� ��Ÿ���� �ؽ�Ʈ��
    public Text UserScoretxt; //��� ���ӿ��� ���� �� ���� ������ �ҷ��� ����!! 
    public string imageFileName; // ��� CSV���� Goods���� ���ڸ� �����ͼ� �̹����� �̾Ƴ�����!!

    // ������ ����
    public Image Reward1;
    public Image Reward2;
    public Image Reward3;

    // ������ ��� ����
    public Image Reward1BG;
    public Image Reward2BG;
    public Image Reward3BG;

    // �Ͻ����� ���� ����   
    public Image pauseBG;
    public Image stopBg;
    public Button stop;
    public Button keepGoing;
    public Button goTitle;

    public Image realStopBg;
    public Button stopOk;
    public Button stopNo;

    // ������ ����Ʈ ������ ���⼭ ��Ŵ
    public List<Image> RewardsImage = new List<Image>();
    public List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    public List<Sprite> rewardGoods = new List<Sprite>();
    public List<Sprite> goodsSprites = new List<Sprite>();

    public List<int> gatchIdList;
    public List<int> gatchPerList;
    public List<int> rewards; // �� �ֵ�

    public bool isGameRunnig = false;

    public GameObject MagicalGirlsPrefab;  // ������ �������� ���� ������
    public GameObject ObstaclePrefab;
    public GameObject StudentPrefab;
    public Sprite[] MagicalGirlsSprites;
    public Sprite[] ObstacleSprites;
    public Sprite[] StudentSprites;
    int randomMagicalGirlsImage;
    int randomObstacleImage;
    int randomStudentImage;

    public void Awake()
    {
        // ��Ƽ��ġ ����
        Input.multiTouchEnabled = false;

        DataManager.Instance.goods1011 = PlayerPrefs.GetInt("Goods1011");
        DataManager.Instance.goods1012 = PlayerPrefs.GetInt("Goods1012");
        DataManager.Instance.goods1021 = PlayerPrefs.GetInt("Goods1021");
        DataManager.Instance.goods1022 = PlayerPrefs.GetInt("Goods1022");
        DataManager.Instance.goods1031 = PlayerPrefs.GetInt("Goods1031");
        DataManager.Instance.goods1032 = PlayerPrefs.GetInt("Goods1032");
        DataManager.Instance.goods1041 = PlayerPrefs.GetInt("Goods1041");
        DataManager.Instance.goods1042 = PlayerPrefs.GetInt("Goods1042");
        DataManager.Instance.goods1051 = PlayerPrefs.GetInt("Goods1051");
        DataManager.Instance.goods1052 = PlayerPrefs.GetInt("Goods1052");

        DataManager.Instance.goods2011 = PlayerPrefs.GetInt("Goods2011");
        DataManager.Instance.goods2012 = PlayerPrefs.GetInt("Goods2012");
        DataManager.Instance.goods2021 = PlayerPrefs.GetInt("Goods2021");
        DataManager.Instance.goods2022 = PlayerPrefs.GetInt("Goods2022");
        DataManager.Instance.goods2031 = PlayerPrefs.GetInt("Goods2031");
        DataManager.Instance.goods2032 = PlayerPrefs.GetInt("Goods2032");
        DataManager.Instance.goods2041 = PlayerPrefs.GetInt("Goods2041");
        DataManager.Instance.goods2042 = PlayerPrefs.GetInt("Goods2042");
        DataManager.Instance.goods2051 = PlayerPrefs.GetInt("Goods2051");
        DataManager.Instance.goods2052 = PlayerPrefs.GetInt("Goods2052");

        DataManager.Instance.goods3011 = PlayerPrefs.GetInt("Goods3011");
        DataManager.Instance.goods3012 = PlayerPrefs.GetInt("Goods3012");
        DataManager.Instance.goods3021 = PlayerPrefs.GetInt("Goods3021");
        DataManager.Instance.goods3022 = PlayerPrefs.GetInt("Goods3022");
        DataManager.Instance.goods3031 = PlayerPrefs.GetInt("Goods3031");
        DataManager.Instance.goods3032 = PlayerPrefs.GetInt("Goods3032");
        DataManager.Instance.goods3041 = PlayerPrefs.GetInt("Goods3041");
        DataManager.Instance.goods3042 = PlayerPrefs.GetInt("Goods3042");
        DataManager.Instance.goods3051 = PlayerPrefs.GetInt("Goods3051");
        DataManager.Instance.goods3052 = PlayerPrefs.GetInt("Goods3052");

        DataManager.Instance.goods4051 = PlayerPrefs.GetInt("Goods4051");
        DataManager.Instance.goods4052 = PlayerPrefs.GetInt("Goods4052");
        DataManager.Instance.goods4053 = PlayerPrefs.GetInt("Goods4053");
        DataManager.Instance.goods4054 = PlayerPrefs.GetInt("Goods4054");
        DataManager.Instance.goods4055 = PlayerPrefs.GetInt("Goods4055");
        DataManager.Instance.goods4056 = PlayerPrefs.GetInt("Goods4056");
        DataManager.Instance.goods4057 = PlayerPrefs.GetInt("Goods4057");
        DataManager.Instance.goods4058 = PlayerPrefs.GetInt("Goods4058");
        DataManager.Instance.goods4059 = PlayerPrefs.GetInt("Goods4059");
        DataManager.Instance.goods4060 = PlayerPrefs.GetInt("Goods4060");

        DataManager.Instance.nowGold = PlayerPrefs.GetInt("NowGold");
        DataManager.Instance.nowRank = PlayerPrefs.GetInt("NowRank");
    }
   
    private void Start()
    {
        Debug.Log("��ŸƮ");
        Debug.Log("�ʱ�ȭ");

        //�ʱ�ȭ
        score = 0;

        Main_BGM.Play();                        // ���� BGM ���
        hit_fx.gameObject.SetActive(false);     // hit_fx ����
        heal_fx.gameObject.SetActive(false);    // heal_fx ����

        gameTimer = 60f;
        readyCounter = 4f;

        gameTimerSlider.maxValue = gameTimer;
        gameTimerSlider.value = gameTimer;

        // ���� ī��Ʈ�� 1�� �ڿ� 1�ʸ��� ����
        InvokeRepeating("ReadyCounter", 0, 1);

        //------------------------------------------------//

        //PercentageTable_1���� �迭�� ����Ұ�
        data_Dialog = CSVReader.Read("PercentageTable");

        // �̰� ������ �𸣰ڴµ� ������� �ؼ� �ϴ� ����
        RewardsImage.Add(Reward1);
        RewardsImage.Add(Reward2);
        RewardsImage.Add(Reward3);

        Setting();

        //------------------------------------------------//
    }

    public void ReadyCounter()
    {
        Debug.Log("ReadyCounter");

        // ������ �Ͻ� ���� ���� ��� ��ȯ
        if (isGamePaused)
            return;

        readyCounter -= 1f;                             // ��� �ð� 1�ʾ� ����
        readyCountBG.gameObject.SetActive(true);        // ��� �ð� BG ���
        readyCount.text = readyCounter.ToString();      // ��� �ð� ���
        readyCount_SFX.Play();                          // ��� �ð� ȿ���� �־�

        if (readyCounter == 0)
        {
            readyCounter = 0;                           // ��� �ð� 0
            readyCount_SFX.Stop();                      // ��� �ð� ȿ���� ����
            readyCountBG.gameObject.SetActive(false);   // ��� �ð� BG ����
            CancelInvoke("ReadyCounter");

            // Ÿ�̸Ӹ� 1�� �ڿ� 1�ʸ��� ����
            InvokeRepeating("GamePlay", 0, 1);           

        }
    }

    public void GamePlay()
    {
        // ���� ����!
        isGameRunnig = true;

        Debug.Log("GamePlay");

        // ������ �Ͻ� ���� ���� ��� ��ȯ
        if (isGamePaused)
            return;

        span = 3f;
 
        gameTimer -= 1f;                                 // Ÿ�̸� ����
        gameTimerText.text = gameTimer.ToString("F0");   // 1�� �ڸ����� ǥ�� 
        gameTimerSlider.value = gameTimer;

        randPrefab = UnityEngine.Random.Range(0, 3);

        if (randPrefab == 0)
        {
            randomStudentImage = UnityEngine.Random.Range(0, StudentSprites.Length);
            GameObject go = Instantiate(StudentPrefab);
            go.GetComponent<SpriteRenderer>().sprite = StudentSprites[randomStudentImage];

            int px = UnityEngine.Random.Range(-2, 2);
            go.transform.position = new Vector3(px, 4, 9);

            Transform healFxTransform = go.transform.Find("heal_fx");
            if (healFxTransform != null)
            {
                healFxTransform.gameObject.SetActive(true);
            }
        }
        else if (randPrefab == 1)
        {
            randomObstacleImage = UnityEngine.Random.Range(0, ObstacleSprites.Length);
            GameObject go2 = Instantiate(ObstaclePrefab);
            go2.GetComponent<SpriteRenderer>().sprite = ObstacleSprites[randomObstacleImage];
            int px = UnityEngine.Random.Range(-2, 2);
            go2.transform.position = new Vector3(px, 4, 9);

            Transform hitfxTransform = go2.transform.Find("hit_fx");
            if (hitfxTransform != null)
            {
                hitfxTransform.gameObject.SetActive(true);
            }
        }

        else
        {
            randomMagicalGirlsImage = UnityEngine.Random.Range(0, MagicalGirlsSprites.Length);
            GameObject go3 = Instantiate(MagicalGirlsPrefab);
            go3.GetComponent<SpriteRenderer>().sprite = MagicalGirlsSprites[randomMagicalGirlsImage];
            int px = UnityEngine.Random.Range(-2, 2);
            go3.transform.position = new Vector3(px, 4, 9);
            Transform healFxTransform = go3.transform.Find("heal_fx");
            if (healFxTransform != null)
            {
                healFxTransform.gameObject.SetActive(true);
            }
        }

        // Ÿ�̸Ӱ� ������ (0���� ���� ���� -1�� ����)
        if (gameTimer <= -1)
        {
            gameTimer = -1;
            CancelInvoke("GamePlay");
            TimeOver();
            
        }

    }

    // �ð��� �� �Ǹ� ���� ���� ȭ���� Ȱ��ȭ
    public void TimeOver()
    {
        // ���� ��!
        isGameRunnig = false;

        Debug.Log("Ÿ�� ����");

        Score();
        Main_BGM.Stop();

        pauseBG.gameObject.SetActive(true);
        ResultBGBG.gameObject.SetActive(true);

        // � ������Ʈ�� �����Ұ���?
        ResultBGBG = GameObject.Find("ResultBGBG").GetComponent<Image>();
        ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        Restart = GameObject.Find("Restart").GetComponent<Button>();
        HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        UserScore = GameObject.Find("UserScoretxt").GetComponent<Text>();
    }


    // ����ŸƮ �˾� Ȱ��ȭ
    public void OnRestartPopup() 
    {
        GoldText();
        RestartPopup.gameObject.SetActive(true);
    }

    // ����ŸƮ �˾� ��Ȱ��ȭ
    public void OffRestartPopup() 
    {
        RestartPopup.gameObject.SetActive(false);
    }

    // ��� ���� �˾� ��Ȱ��ȭ
    public void OffGoldlack() 
    {
        GoldlackPopup.gameObject.SetActive(false);
    }

    // ����: ���󸮽�ŸƮ Ŭ�� �� ���� ��ũ�� ���߾� �׿� �ش��ϴ� ��带 �Ҹ��ϴ� ��ũ��Ʈ
    public void RestartClick() 
    {

        if (DataManager.Instance.nowRank == 0)
        {
            if (DataManager.Instance.nowGold >= 100)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 100;

                Save();
                SceneManager.LoadScene("HN2MiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 100)
            {

                GoldlackPopup.SetActive(true);
            }
        }

        else if (DataManager.Instance.nowRank == 1)
        {
            if (DataManager.Instance.nowGold >= 500)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 500;

                Save();
                SceneManager.LoadScene("HN2MiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 500)
            {
                GoldlackPopup.SetActive(true);
            }
        }

        else if (DataManager.Instance.nowRank == 2)
        {
            if (DataManager.Instance.nowGold >= 1000)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 1000;

                Save();
                SceneManager.LoadScene("HN2MiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 1000)
            {
                GoldlackPopup.SetActive(true);
            }
        }

        else if (DataManager.Instance.nowRank == 3)
        {
            if (DataManager.Instance.nowGold >= 1500)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 1500;

                Save();

                SceneManager.LoadScene("HN2MiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 1500)
            {
                GoldlackPopup.SetActive(true);
            }
        }

        else if (DataManager.Instance.nowRank == 4)
        {
            if (DataManager.Instance.nowGold >= 3000)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 3000;

                Save();
                SceneManager.LoadScene("HN2MiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 3000)
            {
                GoldlackPopup.SetActive(true);
            }
        }
    }

    // �ٽ� ���� �˾����� �ʿ��� ��差�� ��Ÿ���� ��ũ��Ʈ
    public void GoldText() 
    {
        if (DataManager.Instance.nowRank == 0)
        {
            RestartGoldText.text = "�ٽ� �õ��� ��� 100��尡 �Ҹ�˴ϴ�.";
        }

        else if (DataManager.Instance.nowRank == 1)
        {
            RestartGoldText.text = "�ٽ� �õ��� ��� 500��尡 �Ҹ�˴ϴ�.";
        }

        else if (DataManager.Instance.nowRank == 2)
        {
            RestartGoldText.text = "�ٽ� �õ��� ��� 1000��尡 �Ҹ�˴ϴ�.";
        }


        else if (DataManager.Instance.nowRank == 3)
        {
            RestartGoldText.text = "�ٽ� �õ��� ��� 1500��尡 �Ҹ�˴ϴ�.";
        }

        else if (DataManager.Instance.nowRank == 4)
        {
            RestartGoldText.text = "�ٽ� �õ��� ��� 3000��尡 �Ҹ�˴ϴ�.";
        }
    }

    // ȨŬ��
    public void HomeClick()
    {
        SceneManager.LoadScene("HomeScene");
    }

    // ����� Ŭ��
    public void RequestClick()
    {
        SceneManager.LoadScene("RequestScene");
    }

    // ���� �Ͻ����� ���¸� ��Ÿ���� ����
    public bool isGamePaused = false;

    // ���� �Ͻ����� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void StopButtonClick()
    {
        if (!isGamePaused)
        {
            // ���� �Ͻ�����
            PauseGame();
        }
        else if (isGamePaused)
        {
            // ���� �簳
            Time.timeScale = 1;
            pauseBG.gameObject.SetActive(false);
            stopBg.gameObject.SetActive(false);
            realStopBg.gameObject.SetActive(false);
            isGamePaused = false;
            Main_BGM.Play();
        }
    }

    // ���� �Ͻ����� ó��
    private void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0;
        // ���� �Ͻ����� UI Ȱ��ȭ
        pauseBG.gameObject.SetActive(true);
        stopBg.gameObject.SetActive(true);
        Main_BGM.Pause();
    }

    // �������� ���ư��� ��ư �Լ�
    public void keepGoingClick()
    {
        // ���� �簳
        Time.timeScale = 1;
        pauseBG.gameObject.SetActive(false);
        stopBg.gameObject.SetActive(false);
        realStopBg.gameObject.SetActive(false);
        isGamePaused = false;
        Main_BGM.Play();
    }

    // ����ŷ� ���ư��� ��ư �Լ�
    public void goTitleClick()
    {
        // ���� �Ͻ����� UI ��Ȱ��ȭ
        pauseBG.gameObject.SetActive(false);
        stopBg.gameObject.SetActive(false);

        // ������Bg Ȱ��ȭ
        pauseBG.gameObject.SetActive(true);
        realStopBg.gameObject.SetActive(true);

    }

    // �������� ���ư��� ��ư �Լ�
    public void stopNoClick()
    {
        // ���� �簳
        Time.timeScale = 1;
        pauseBG.gameObject.SetActive(false);
        stopBg.gameObject.SetActive(false);
        realStopBg.gameObject.SetActive(false);
        isGamePaused = false;
        Main_BGM.Play();
    }

    // Ȩ���� ��ư �Լ�
    public void stopOkClick()
    {
        Time.timeScale = 1;
        isGamePaused = false;
        SceneManager.LoadScene("HomeScene");
        //homeManager.OnButtonClick_OnGoodsBuy();
    }

    // ���� ���� ���� �޼���
    public void CountUP()
    {
        score++;
        Scoretxt.text = "Score : " + score.ToString();
        Debug.Log("CountUP");
        heal_sfx.Play();
        heal_fx.gameObject.SetActive(true);
        hit_fx.gameObject.SetActive(false);
    }

    public void DoubleCountUP()
    {
        score += 2;
        Scoretxt.text = "Score : " + score.ToString();
        Debug.Log("DoubleCountUP");
        heal_sfx.Play();
        heal_fx.gameObject.SetActive(true);
        hit_fx.gameObject.SetActive(false);
    }

    public void CountDown()
    {
        score--;
        if (score < 0)
        {
            score = 0;
        }
        Scoretxt.text = "Score : " + score.ToString();
        Debug.Log("CountDown");

        hit_sfx.Play();
        hit_fx.gameObject.SetActive(true);
        heal_fx.gameObject.SetActive(false);
    }

    void Setting() // �� ���ڸ��� �ѹ� �ϸ� ��
    {
        gatchPerList = new List<int>();
        gatchIdList = new List<int>();
        goodsSprites = new List<Sprite>();
        int rank = DataManager.Instance.nowRank;

        if (rank == 0)
        {
            for (int i = 0; i < data_Dialog.Count; i++)
            {
                if ((int)data_Dialog[i]["Nowrank"] == rank)
                {
                    gatchPerList.Add((int)data_Dialog[i]["Percentage"]);
                    gatchIdList.Add((int)data_Dialog[i]["Goods"]);
                    string imageString = "reward_Goods" + data_Dialog[i]["Goods"].ToString();
                    goodsSprites.Add(Resources.Load<Sprite>(imageString));

                    Debug.Log("rank" + rank);
                }
            }
        }

        else if (rank == 1)
        {
            for (int i = 1; i < data_Dialog.Count; i++)
            {
                if ((int)data_Dialog[i]["Nowrank"] == rank)
                {
                    gatchPerList.Add((int)data_Dialog[i]["Percentage"]);
                    gatchIdList.Add((int)data_Dialog[i]["Goods"]);
                    string imageString = "reward_Goods" + data_Dialog[i]["Goods"].ToString();
                    goodsSprites.Add(Resources.Load<Sprite>(imageString));

                    Debug.Log("rank" + rank);
                }
            }
        }

        else if (rank == 2)
        {
            for (int i = 2; i < data_Dialog.Count; i++)
            {
                if ((int)data_Dialog[i]["Nowrank"] == rank)
                {
                    gatchPerList.Add((int)data_Dialog[i]["Percentage"]);
                    gatchIdList.Add((int)data_Dialog[i]["Goods"]);
                    string imageString = "reward_Goods" + data_Dialog[i]["Goods"].ToString();
                    goodsSprites.Add(Resources.Load<Sprite>(imageString));

                    Debug.Log("rank" + rank);
                }
            }
        }

        else if (rank == 3)
        {
            for (int i = 3; i < data_Dialog.Count; i++)
            {
                if ((int)data_Dialog[i]["Nowrank"] == rank)
                {
                    gatchPerList.Add((int)data_Dialog[i]["Percentage"]);
                    gatchIdList.Add((int)data_Dialog[i]["Goods"]);
                    string imageString = "reward_Goods" + data_Dialog[i]["Goods"].ToString();
                    goodsSprites.Add(Resources.Load<Sprite>(imageString));

                    Debug.Log("rank" + rank);
                }
            }
        }

        else if (rank == 4)
        {
            for (int i = 4; i < data_Dialog.Count; i++)
            {
                if ((int)data_Dialog[i]["Nowrank"] == rank)
                {
                    gatchPerList.Add((int)data_Dialog[i]["Percentage"]);
                    gatchIdList.Add((int)data_Dialog[i]["Goods"]);
                    string imageString = "reward_Goods" + data_Dialog[i]["Goods"].ToString();
                    goodsSprites.Add(Resources.Load<Sprite>(imageString));

                    Debug.Log("rank" + rank);
                }
            }
        }

    }

    public void GetGoods(int _count) // ���� ��í�� �ϴ� �κ�. count���� �̰� ���� ���� �ֱ�
    {

        if (data_Dialog.Count == 0)
        {
            data_Dialog = CSVReader.Read("PercentageTable");
        }

        for (int i = 0; i < RewardsImage.Count; i++)
        {
            RewardsImage[i].gameObject.SetActive(false); // �� �� ��
        }

        int randMaxValue = 0; // ��� ����ġ ���� ���ϱ� ���� ����. �޸� ���� ���� ��
        for (int i = 0; i < gatchPerList.Count; i++)
        {
            randMaxValue += gatchPerList[i]; // ����ġ �� �� ���ϱ�. 999, 1001 ����
        }

        for (int i = 0; i < _count; i++) // ���
        {
            GetItems(randMaxValue); // �̱�

            RewardsImage[i].sprite = rewardGoods[i];
            RewardsImage[i].gameObject.SetActive(true); // �ٲ������ �Ѷ�
        }
        Save();
    }

    void GetItems(int maxValue)
    {
        int randValue = UnityEngine.Random.Range(0, maxValue);
        Debug.Log("Random Value: " + randValue);

        int checkUpper = 0;
        int checkLower = 0;

        for (int i = 0; i < gatchIdList.Count; i++)
        {
            checkUpper += gatchPerList[i];
            Debug.Log("Check Upper: " + checkUpper);

            if (i == 0)
            {
                if (randValue < checkUpper)
                {
                    rewards.Add(gatchIdList[i]);
                    rewardGoods.Add(goodsSprites[i]);
                    Debug.Log("Reward Added: " + gatchIdList[i]);
                    break;
                }
            }
            else
            {
                if (randValue >= checkLower && randValue < checkUpper)
                {
                    rewards.Add(gatchIdList[i]);
                    rewardGoods.Add(goodsSprites[i]);
                    Debug.Log("Reward Added: " + gatchIdList[i]);
                    break;
                }
            }

            checkLower = checkUpper;
        }
    }

    public void Score() // �̸� �ٲ�. => ������ ���� ��í ���� ���� �ϴ� �κ��̶�
    {
        UserScoretxt.text = "0" + score.ToString();      // ���� ���� ���ھ� �ؽ�Ʈ�� ���


        //���� ����
        if (score >= 110) // �ٲ�
        {
            _count = 3;
            Reward1BG.gameObject.SetActive(true);
            Reward2BG.gameObject.SetActive(true);
            Reward3BG.gameObject.SetActive(true);
        }
        else if (score < 110 && score >= 90)
        {
            _count = 2;
            Reward1BG.gameObject.SetActive(true);
            Reward2BG.gameObject.SetActive(true);
            Reward3BG.gameObject.SetActive(false);
        }
        else if (score < 90 && score >= 0)
        {
            _count = 1;
            Reward1BG.gameObject.SetActive(true);
            Reward2BG.gameObject.SetActive(false);
            Reward3BG.gameObject.SetActive(false);
        }

        else
        {
            score = 0;
        }

        GetGoods(_count);
    }

    public void Save()
    {
        for (int i = 0; i < rewards.Count; i++)
        {
            int rewardId = rewards[i];
            Debug.Log("������ ���̵� " + rewardId);

            // ������ ID�� ���� DataManager.Instance�� ����
            switch (rewardId)
            {
                case 1011:
                    DataManager.Instance.goods1011++;
                    PlayerPrefs.SetInt("Goods1011", DataManager.Instance.goods1011);
                    break;
                case 1012:
                    DataManager.Instance.goods1012++;
                    PlayerPrefs.SetInt("Goods1012", DataManager.Instance.goods1012);
                    break;
                case 1021:
                    DataManager.Instance.goods1021++;
                    PlayerPrefs.SetInt("Goods1021", DataManager.Instance.goods1021);
                    break;
                case 1022:
                    DataManager.Instance.goods1022++;
                    PlayerPrefs.SetInt("Goods1022", DataManager.Instance.goods1022);
                    break;
                case 1031:
                    DataManager.Instance.goods1031++;
                    PlayerPrefs.SetInt("Goods1031", DataManager.Instance.goods1031);
                    break;
                case 1032:
                    DataManager.Instance.goods1032++;
                    PlayerPrefs.SetInt("Goods1032", DataManager.Instance.goods1032);
                    break;
                case 1041:
                    DataManager.Instance.goods1041++;
                    PlayerPrefs.SetInt("Goods1041", DataManager.Instance.goods1041);
                    break;
                case 1042:
                    DataManager.Instance.goods1042++;
                    PlayerPrefs.SetInt("Goods1042", DataManager.Instance.goods1042);
                    break;
                case 1051:
                    DataManager.Instance.goods1051++;
                    PlayerPrefs.SetInt("Goods1051", DataManager.Instance.goods1051);
                    break;
                case 1052:
                    DataManager.Instance.goods1052++;
                    PlayerPrefs.SetInt("Goods1052", DataManager.Instance.goods1052);
                    break;
                case 2011:
                    DataManager.Instance.goods2011++;
                    PlayerPrefs.SetInt("Goods2011", DataManager.Instance.goods2011);
                    break;
                case 2012:
                    DataManager.Instance.goods2012++;
                    PlayerPrefs.SetInt("Goods2012", DataManager.Instance.goods2012);
                    break;
                case 2021:
                    DataManager.Instance.goods2021++;
                    PlayerPrefs.SetInt("Goods2021", DataManager.Instance.goods2021);
                    break;
                case 2022:
                    DataManager.Instance.goods2022++;
                    PlayerPrefs.SetInt("Goods2022", DataManager.Instance.goods2022);
                    break;
                case 2031:
                    DataManager.Instance.goods2031++;
                    PlayerPrefs.SetInt("Goods2031", DataManager.Instance.goods2031);
                    break;
                case 2032:
                    DataManager.Instance.goods2032++;
                    PlayerPrefs.SetInt("Goods2032", DataManager.Instance.goods2032);
                    break;
                case 2041:
                    DataManager.Instance.goods2041++;
                    PlayerPrefs.SetInt("Goods2041", DataManager.Instance.goods2041);
                    break;
                case 2042:
                    DataManager.Instance.goods2042++;
                    PlayerPrefs.SetInt("Goods2042", DataManager.Instance.goods2042);
                    break;
                case 2051:
                    DataManager.Instance.goods2051++;
                    PlayerPrefs.SetInt("Goods2051", DataManager.Instance.goods2051);
                    break;
                case 2052:
                    DataManager.Instance.goods2052++;
                    PlayerPrefs.SetInt("Goods2052", DataManager.Instance.goods2052);
                    break;
                case 3011:
                    DataManager.Instance.goods3011++;
                    PlayerPrefs.SetInt("Goods3011", DataManager.Instance.goods3011);
                    break;
                case 3012:
                    DataManager.Instance.goods3012++;
                    PlayerPrefs.SetInt("Goods3012", DataManager.Instance.goods3012);
                    break;
                case 3021:
                    DataManager.Instance.goods3021++;
                    PlayerPrefs.SetInt("Goods3021", DataManager.Instance.goods3021);
                    break;
                case 3022:
                    DataManager.Instance.goods3022++;
                    PlayerPrefs.SetInt("Goods3022", DataManager.Instance.goods3022);
                    break;
                case 3031:
                    DataManager.Instance.goods3031++;
                    PlayerPrefs.SetInt("Goods3031", DataManager.Instance.goods3031);
                    break;
                case 3032:
                    DataManager.Instance.goods3032++;
                    PlayerPrefs.SetInt("Goods3032", DataManager.Instance.goods3032);
                    break;
                case 3041:
                    DataManager.Instance.goods3041++;
                    PlayerPrefs.SetInt("Goods3041", DataManager.Instance.goods3041);
                    break;
                case 3042:
                    DataManager.Instance.goods3042++;
                    PlayerPrefs.SetInt("Goods3042", DataManager.Instance.goods3042);
                    break;
                case 3051:
                    DataManager.Instance.goods3051++;
                    PlayerPrefs.SetInt("Goods3051", DataManager.Instance.goods3051);
                    break;
                case 3052:
                    DataManager.Instance.goods3052++;
                    PlayerPrefs.SetInt("Goods3052", DataManager.Instance.goods3052);
                    break;

                case 4051:
                    DataManager.Instance.goods4051++;
                    PlayerPrefs.SetInt("Goods4051", DataManager.Instance.goods4051);
                    break;
                case 4052:
                    DataManager.Instance.goods4052++;
                    PlayerPrefs.SetInt("Goods4052", DataManager.Instance.goods4052);
                    break;
                case 4053:
                    DataManager.Instance.goods4053++;
                    PlayerPrefs.SetInt("Goods4053", DataManager.Instance.goods4053);
                    break;
                case 4054:
                    DataManager.Instance.goods4054++;
                    PlayerPrefs.SetInt("Goods4054", DataManager.Instance.goods4054);
                    break;
                case 4055:
                    DataManager.Instance.goods4055++;
                    PlayerPrefs.SetInt("Goods4055", DataManager.Instance.goods4055);
                    break;
                case 4056:
                    DataManager.Instance.goods4056++;
                    PlayerPrefs.SetInt("Goods4056", DataManager.Instance.goods4056);
                    break;
                case 4057:
                    DataManager.Instance.goods4057++;
                    PlayerPrefs.SetInt("Goods4057", DataManager.Instance.goods4057);
                    break;
                case 4058:
                    DataManager.Instance.goods4058++;
                    PlayerPrefs.SetInt("Goods4058", DataManager.Instance.goods4058);
                    break;
                case 4059:
                    DataManager.Instance.goods4059++;
                    PlayerPrefs.SetInt("Goods4059", DataManager.Instance.goods4059);
                    break;
                case 4060:
                    DataManager.Instance.goods4060++;
                    PlayerPrefs.SetInt("Goods4060", DataManager.Instance.goods4060);
                    break;

                default:
                    break;

                    // �ٸ� ���� ID�� ���� ���̽� �߰�...
            }

        }

        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        // PlayerPrefs�� ���� �� ����
        PlayerPrefs.Save();

        /*
        Debug.Log("�̴ϰ��� ���:" +  DataManager.Instance.goods1011); //Ư�� ���� ���� üũ��
        Debug.Log(DataManager.Instance.goods1011);
        Debug.Log(DataManager.Instance.goods1012);
        Debug.Log(DataManager.Instance.goods2011);
        Debug.Log(DataManager.Instance.goods2012);
        Debug.Log(DataManager.Instance.goods3011);
        Debug.Log(DataManager.Instance.goods3012);
        Debug.Log(DataManager.Instance.goods1021);
        Debug.Log(DataManager.Instance.goods1022);
        Debug.Log(DataManager.Instance.goods2021);
        Debug.Log(DataManager.Instance.goods2022);
        Debug.Log(DataManager.Instance.goods3021);
        Debug.Log(DataManager.Instance.goods3022);
        Debug.Log(DataManager.Instance.goods1031);
        Debug.Log(DataManager.Instance.goods1032);
        Debug.Log(DataManager.Instance.goods2031);
        Debug.Log(DataManager.Instance.goods2032);
        Debug.Log(DataManager.Instance.goods3031);
        Debug.Log(DataManager.Instance.goods3032);
        Debug.Log(DataManager.Instance.goods1041);
        Debug.Log(DataManager.Instance.goods1042);
        Debug.Log(DataManager.Instance.goods2041);
        Debug.Log(DataManager.Instance.goods2042);
        Debug.Log(DataManager.Instance.goods3041);
        Debug.Log(DataManager.Instance.goods3042);
        Debug.Log(DataManager.Instance.goods1051);
        Debug.Log(DataManager.Instance.goods1052);
        Debug.Log(DataManager.Instance.goods2051);
        Debug.Log(DataManager.Instance.goods2052);
        Debug.Log(DataManager.Instance.goods3051);
        Debug.Log(DataManager.Instance.goods3052);
        Debug.Log(DataManager.Instance.goods4051);
        Debug.Log(DataManager.Instance.goods4052);
        Debug.Log(DataManager.Instance.goods4053);
        Debug.Log(DataManager.Instance.goods4054);
        Debug.Log(DataManager.Instance.goods4055);
        Debug.Log(DataManager.Instance.goods4056);
        Debug.Log(DataManager.Instance.goods4057);
        Debug.Log(DataManager.Instance.goods4058);
        Debug.Log(DataManager.Instance.goods4059);
        Debug.Log(DataManager.Instance.goods4060);
        */

    }

}
