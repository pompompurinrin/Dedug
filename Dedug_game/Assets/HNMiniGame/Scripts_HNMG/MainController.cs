using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.SocialPlatforms.Impl;
using UnityEditor;




public class MainController : MonoBehaviour
{   
    // ���ھ� �ʱⰪ
    public int score = 0;

    // Ÿ�̸�
    public float gameTimer = 30f;        // ���� �ð� 30�� ����
    public float readyCounter = 3f;      // ��� �ð� 3�� ����
    public float showCounter = 3f;       // ���� �ð� 3�� ����
    public Slider gameTimerSlider;       // ���� �ð� UI �����̴� ����
    public Text gameTimerText;           // ���� �ð� ���
    public Text readyCount;              // ��� �ð� ���
    public Text showMessage;             // ���� �޼��� ���
    public Image readyCountBG;           // ��� �ð� BG

    // ����
    public AudioSource Main_BGM2;        // ���� BGM
    public AudioSource correct_sfx;      // ��Ī ���� ����
    public AudioSource error_sfx;        // ��Ī ���� ����
    public AudioSource readyCount_SFX;   // ��� �ð� ȿ����

    // ����Ʈ
    public GameObject correct_fx;        // ��Ī ���� ȿ��
    public GameObject error_fx;          // ��Ī ���� ȿ��

    // ���� ������ ���� ���� ��
    public const int columns = 4;
    public const int rows = 5;

    // �̹����� ��ġ�� �θ� ��ü
    public Transform parent;

    // �̹��� ������ ���� ����
    public const float Xspace = 260f;
    public const float Yspace = -310f;
    
    // ���� ���� �̹��� �� ���� ��������Ʈ �迭
    public MainImageScript mainImageScript;
    public Sprite[] images;

    public Button Card_Front;
    
    // UI ��ҵ�
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

    public AudioSource Result_SFX;



    // ������ ����Ʈ ������ ���⼭ ��Ŵ
    public List<Image> RewardsImage = new List<Image>();
    public List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();


    // ��ġ�� �������� ���� �Լ�
    private int[] Randomiser(int[] locations)
    {
        int[] array = locations.Clone() as int[];
        for (int i = 0; i < array.Length; i++)
        {
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }
        return array;
    }

    public void Awake()
    {
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

        StartGame();

        Main_BGM2.Play();    // ���� BGM ���
        correct_sfx.Stop();  // correct_sfx ����
        error_sfx.Stop();    // correct_sfx ����

        //PercentageTable_1���� �迭�� ����Ұ�
        data_Dialog = CSVReader.Read("PercentageTable");

        // �̰� ������ �𸣰ڴµ� ������� �ؼ� �ϴ� ����
        RewardsImage.Add(Reward1);
        RewardsImage.Add(Reward2);
        RewardsImage.Add(Reward3);

        Input.multiTouchEnabled = false;

        Setting();

        // �ʱ�ȭ
        gameTimer = 30f;
        readyCounter = 3f;
        showCounter = 4f;
        gameTimerSlider.maxValue = gameTimer;
        gameTimerSlider.value = gameTimer;

        readyCount_SFX.Stop();

        // ���� ī��Ʈ�� 1�� �ڿ� 1�ʸ��� ����
        InvokeRepeating("ReadyCounter", 0, 1f);
        Input.multiTouchEnabled = false;

    }

    // ������ ���۵� �� ȣ��Ǵ� �Լ�
    private void StartGame()
    {
        // ������ �Ͻ� ���� ���� ��� ��ȯ
        if (isGamePaused)
        {
            return;
        }

        else
        {
            isGameRunnig = true;

            Debug.Log("��ũ�� ī����� ���� ��¥ ����");

            // �̹��� ��ġ�� �������� ����
            int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };

            locations = Randomiser(locations);

            Vector3 startPosition = mainImageScript.transform.position;

            // ���� ���忡 �̹��� ��ġ
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    MainImageScript gameImage;
                    if (i == 0 && j == 0)
                    {
                        // ���� �̹����� ���� ó��
                        gameImage = mainImageScript;
                    }
                    else
                    {
                        // ������ �̹����� �����Ͽ� ���
                        gameImage = Instantiate(mainImageScript) as MainImageScript;
                    }

                    int index = j * columns + i;

                    int id = locations[index];
                    gameImage.ChangeSprite(id, images[id]);

                    // �̹����� ��ġ ����
                    float positionX = (Xspace * i) + startPosition.x;
                    float positionY = (Yspace * j) + startPosition.y;

                    gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
                    gameImage.transform.SetParent(parent, false);

                }
            }
        }
    }

    // ������ �̹����� �����ϰ�, �´��� Ȯ���ϴ� �Լ�
    private MainImageScript firstOpen;
    private MainImageScript secondOpen;

    // �� ��° �̹����� �� �� �ִ��� ���θ� ��ȯ�ϴ� �Ӽ�
    public bool canOpen
    {
        get { return secondOpen == null; }
    }

    // �̹����� ������ �� ȣ��Ǵ� �Լ�
    public void imageOpened(MainImageScript mainImageScript)
    {
        if (firstOpen == null)
        {
            // ù ��° �̹��� ����
            firstOpen = mainImageScript;
        }
        else
        {
            // �� ��° �̹��� ���� �� ��ġ ���� Ȯ��
            secondOpen = mainImageScript;
            StartCoroutine(CheckGuessed());
        }
    }
  
    // �̹��� ��ġ ���θ� Ȯ���ϰ� ó���ϴ� �ڷ�ƾ
    private IEnumerator CheckGuessed()
    {
        if (firstOpen.spriteId == secondOpen.spriteId) // �� �̹����� ��������Ʈ ID ��
        {
            
            score++;                                         // ��ġ�ϸ� ���� ����
            Scoretxt.text= "Score : " + score.ToString();    // �ǽð� ���ھ� �ؽ�Ʈ�� ���
            
            correct_sfx.Play();                              // correct_sfx ���

            MainImageScript card1 = firstOpen;
            MainImageScript card2 = secondOpen;

            Vector3 originalScale = new Vector3(1, 1, 1);
            Vector3 targetScale = new Vector3(1.5f, 1.5f, 1.5f);

           
                    

                card1.transform.DOScale(targetScale, 0.2f).OnComplete(() => // ���ٽ�
                {
                    card1.transform.DOScale(originalScale, 0.2f);
                    card1.correct_fx.gameObject.SetActive(true);
                                           
                });


                card2.transform.DOScale(targetScale, 0.2f).OnComplete(() => // ���ٽ�
                {
                    card2.transform.DOScale(originalScale, 0.2f);
                    card2.correct_fx.gameObject.SetActive(true);
                    secondOpen = null;  // ���� �ʱ�ȭ �߰�
                });

            
             
        if (score == 10) 
            {
                
                Score();
                isGameRunnig = false;
                score = 00;

                Result_SFX.Play();

                ResultBGBG.gameObject.SetActive(true);
                pauseBG.gameObject.SetActive(true);
                Main_BGM2.Stop();
                isGameRunnig = false;

                //� ������Ʈ�� �����Ұ���?
                ResultBGBG = GameObject.Find("ResultBG").GetComponent<Image>();
                ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
                Restart = GameObject.Find("Restart").GetComponent<Button>();
                HomeBtn = GameObject.Find("Home").GetComponent<Button>();
                UserScore = GameObject.Find("UserScoretxt").GetComponent<Text>();
               

            }
        }
        else
        {
            // ��ġ���� ������ 0.5�� �Ŀ� �̹����� ����
            yield return new WaitForSeconds(0.5f);

            firstOpen.Close();
            secondOpen.Close();
            error_sfx.Play();                        
        }

        // ������ �̹��� ���� �ʱ�ȭ
        firstOpen = null;
        secondOpen = null;
    }

    public void Click_OnRestartPopup() //����ŸƮ �˾� Ȱ��ȭ
    {
        GoldText();
        RestartPopup.gameObject.SetActive(true);
    }

    public void Click_OffRestartPopup() //����ŸƮ �˾� ��Ȱ��ȭ
    {
        RestartPopup.gameObject.SetActive(false);
    }

    public void Click_OffGoldlack() //��� ���� �˾� ��Ȱ��ȭ
    {
        GoldlackPopup.gameObject.SetActive(false);
    }
    public void RestartClick() //����: ����ŸƮ Ŭ�� �� ���� ��ũ�� ���߾� �׿� �ش��ϴ� ��带 �Ҹ��ϴ� ��ũ��Ʈ
    {

        if (DataManager.Instance.nowRank == 0)
        {
            if (DataManager.Instance.nowGold >= 100)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 100;

                Save();
               SceneManager.LoadScene("HNMiniGameScene");
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
               SceneManager.LoadScene("HNMiniGameScene");
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
               SceneManager.LoadScene("HNMiniGameScene");
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
               SceneManager.LoadScene("HNMiniGameScene");
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
               SceneManager.LoadScene("HNMiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 3000)
            {
                GoldlackPopup.SetActive(true);
            }
        }

    }

    public void GoldText() //�ٽ� ���� �˾����� �ʿ��� ��差�� ��Ÿ���� ��ũ��Ʈ
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

    public void HomeClick()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void RequestClick()
    {
        SceneManager.LoadScene("RequestScene");
    }


    // ���� �Ͻ����� ���� ����   
    public Image pauseBG;
    public Image stopBg;
    public Button stop;
    public Button keepGoing;
    public Button goTitle;

    public Image realStopBg;
    public Button stopOk;
    public Button stopNo;

    [SerializeField] private TimerController timerController;

    // ���� �Ͻ����� ���¸� ��Ÿ���� ����
    public bool isGamePaused = false;


    // ���� �Ͻ����� ���¸� ��Ÿ���� ����
    public bool isGameRunnig = false;

    // ���� �Ͻ����� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void StopButtonClick()
    {
        if (!isGamePaused)
        {
            // ���� �Ͻ�����
            PauseGame();
            Debug.Log("�Ͻ������� ���� �ߴ�");
        }
        else if (isGamePaused)
        {
            // ���� �簳
            Time.timeScale = 1;
            pauseBG.gameObject.SetActive(false);
            stopBg.gameObject.SetActive(false);
            realStopBg.gameObject.SetActive(false);
            isGamePaused = false;
            Main_BGM2.Play();
        }
    }
    public float timeScale;
    // ���� �Ͻ����� ó��
    private void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0;

        // ���� �Ͻ����� UI Ȱ��ȭ
        pauseBG.gameObject.SetActive(true);
        stopBg.gameObject.SetActive(true);
        Main_BGM2.Pause();


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
        Main_BGM2.Play();
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
        Main_BGM2.Play();
    }
    public HomeManager homeManager;
    // ����ŷ� ��ư �Լ�
    public void stopOkClick()
    {
        Time.timeScale = 1;
        isGamePaused = false;

        SceneManager.LoadScene("HomeScene");
        //homeManager.OnButtonClick_OnGoodsBuy();
    }

    // ���� �簳 ó��
    private void ResumeGame()
    {
        isGamePaused = false;
        Main_BGM2.Play();
    }

    public List<Sprite> goodsSprites = new List<Sprite>();

    public List<int> gatchIdList;
    public List<int> gatchPerList;
    public List<int> rewards; // �� �ֵ�

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

    public List<Sprite> rewardGoods = new List<Sprite>();

    public int _count = 0;// � �� �� �����ϴ� ����
    public void Score() // �̸� �ٲ�. => ������ ���� ��í ���� ���� �ϴ� �κ��̶�
    {
        UserScoretxt.text = score.ToString("F0");      // ���� ���� ���ھ� �ؽ�Ʈ�� ���
        

        //���� ����
        if (score >= 10) // �ٲ�
        {
            _count = 3;
            Reward1BG.gameObject.SetActive(true);
            Reward2BG.gameObject.SetActive(true);
            Reward3BG.gameObject.SetActive(true);
        }
        else if (score < 10 && score >= 3)
        {
            _count = 2;
            Reward1BG.gameObject.SetActive(true);
            Reward2BG.gameObject.SetActive(true);
            Reward3BG.gameObject.SetActive(false);
        }
        else if (score < 3 && score >= 0 )
        {
            _count = 1;
            Reward1BG.gameObject.SetActive(true);
            Reward2BG.gameObject.SetActive(false);
            Reward3BG.gameObject.SetActive(false);
            if (score == 0)
            {
                UserScoretxt.text = "0" + score.ToString("F0");
            }
        }

        else 
        {
           
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

        //Debug.Log("�̴ϰ��� ���:" +  DataManager.Instance.goods1011); //Ư�� ���� ���� üũ��
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

    }


}
