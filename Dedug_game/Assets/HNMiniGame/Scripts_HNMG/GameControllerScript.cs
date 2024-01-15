using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.SocialPlatforms.Impl;




public class GameControllerScript : MonoBehaviour
{
    
    // ���� ������ ���� ���� ��
    public const int columns = 4;
    public const int rows = 5;

    // �̹����� ��ġ�� �θ� ��ü
    public Transform parent;

    // �̹��� ������ ���� ����
    public const float Xspace = 260f;
    public const float Yspace = -300f;

    // ���� ���� �̹��� �� ���� ��������Ʈ �迭
    [SerializeField] private MainImageScript startObject;
    [SerializeField] private Sprite[] images;

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


    public int score = 0;
   // ���ھ� �ʱⰪ


    public AudioSource Main_BGM2;

    // UI ��ҵ�
    public Image ResultBG;
    public Image ScoreBG;
    public Text Scoretxt;
    public Text UserScore;
    public Text Rewardtxt;
    public Button Restart;
    public Button HomeBtn;

    // ���� ȿ�� �� ����� ��Ÿ���� �ؽ�Ʈ��
    public Text UserScoretxt; //��� ���ӿ��� ���� �� ���� ������ �ҷ��� ����!! 
    public string imageFileName; // ��� CSV���� Goods���� ���ڸ� �����ͼ� �̹����� �̾Ƴ�����!!

    // ���� ������Ʈ �� ĵ���� ���� ����
    public Image Reward1;
    public Image Reward2;
    public Image Reward3;

    int test;

    // ������ ����Ʈ ������ ���⼭ ��Ŵ
    public List<Image> RewardsImage = new List<Image>();

    public List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();


    
    private void Start()
    {
        // ���� ���� �� ȣ��Ǵ� �Լ�
        StartGame();

        Main_BGM2.Play();  // ���
        correct_sfx.Stop();
        error_sfx.Stop();

        //PercentageTable_1���� �迭�� ����Ұ�
        data_Dialog = CSVReader.Read("PercentageTable_real");

        // �̰� ������ �𸣰ڴµ� ������� �ؼ� �ϴ� ����
        RewardsImage.Add(Reward1);
        RewardsImage.Add(Reward2);
        RewardsImage.Add(Reward3);

        Setting();

    }
    // ������ ���۵� �� ȣ��Ǵ� �Լ�
    private void StartGame()
    {
        if (isGamePaused)
            return;

        else
        {
            // �̹��� ��ġ�� �������� ����
            int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };

            locations = Randomiser(locations);

            Vector3 startPosition = startObject.transform.position;

            // ���� ���忡 �̹��� ��ġ
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    MainImageScript gameImage;
                    if (i == 0 && j == 0)
                    {
                        // ���� �̹����� ���� ó��
                        gameImage = startObject;
                    }
                    else
                    {
                        // ������ �̹����� �����Ͽ� ���
                        gameImage = Instantiate(startObject) as MainImageScript;
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
    public void imageOpened(MainImageScript startObject)
    {
        if (firstOpen == null)
        {
            // ù ��° �̹��� ����
            firstOpen = startObject;
        }
        else
        {
            // �� ��° �̹��� ���� �� ��ġ ���� Ȯ��
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }
    }





    // -------------------------------------------------------------------

  
    public AudioSource correct_sfx;     // ��Ī ���� ����
    public AudioSource error_sfx;       // ��Ī ���� ����


    public GameObject correct_fx;    // ��Ī ���� ȿ��
    public GameObject error_fx;      // ��Ī ���� ȿ��


   
    // �̹��� ��ġ ���θ� Ȯ���ϰ� ó���ϴ� �ڷ�ƾ
    private IEnumerator CheckGuessed()
    {
        if (firstOpen.spriteId == secondOpen.spriteId) // �� �̹����� ��������Ʈ ID ��
        {
            
            score++; // ��ġ�ϸ� ���� ����
            Scoretxt.text= "Score : " + score.ToString() ;
            UserScoretxt.text = "0" + score.ToString() ;
          
            correct_sfx.Play();
           

            Vector3 originalScale = new Vector3(1, 1, 1);
            Vector3 targetScale = new Vector3(1.5f, 1.5f, 1.5f);

            MainImageScript card1 = firstOpen;
            
            card1.transform.DOScale(targetScale, 0.2f).OnComplete(() => // ���ٽ�
            {
                card1.transform.DOScale(originalScale, 0.2f);
                card1.correct_fx.gameObject.SetActive(true);
            });
            
            MainImageScript card2 = secondOpen;
            
            card2.transform.DOScale(targetScale, 0.2f).OnComplete(() => // ���ٽ�
            {
                card2.transform.DOScale(originalScale, 0.2f);
                card2.correct_fx.gameObject.SetActive(true);
                secondOpen = null;  // ���� �ʱ�ȭ �߰�
            });

            if (score == 10) 
            {
                Score();
                ResultBG.gameObject.SetActive(true);
                Main_BGM2.Stop();
                
                

                //� ������Ʈ�� �����Ұ���?
                ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
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

        for (int i = 0; i < data_Dialog.Count; i++)
        {
            if ((int)data_Dialog[i]["Nowrank"] == rank)
            {
                gatchPerList.Add((int)data_Dialog[i]["Percentage"]);
                gatchIdList.Add((int)data_Dialog[i]["Percentage"]);
                string imageString = "Goods" + data_Dialog[i]["Goods"].ToString();
                goodsSprites.Add(Resources.Load<Sprite>(imageString));

            }
        }

    }

    public void GetGoods(int _count) // ���� ��í�� �ϴ� �κ�. count���� �̰� ���� ���� �ֱ�
    {

        if (data_Dialog.Count == 0)
        {
            data_Dialog = CSVReader.Read("PercentageTable_real");
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
    }

    void GetItems(int maxValue) // �̱�. ���� �ִ밪 �ޱ�
    {
        int randValue = UnityEngine.Random.Range(0, maxValue); // ���� ���� �ش� ����ġ��
        int checkUpper = 0; // ����ġ üũ��
        int checkLower = 0;
        for (int i = 0; i < gatchIdList.Count; i++)
        {
            checkUpper += gatchPerList[i];
            if (i == 0)
            {
                checkUpper += gatchPerList[i];
                if (randValue < checkUpper)
                {
                    rewards.Add(gatchIdList[i]);
                    rewardGoods.Add(goodsSprites[i]);
                }
            }
            else
            {
                if (randValue >= checkLower && randValue < checkUpper)
                {
                    rewards.Add(gatchIdList[i]);
                    rewardGoods.Add(goodsSprites[i]);
                }
            }
            checkLower = checkUpper;

        }
    }


    public List<Sprite> rewardGoods = new List<Sprite>();

    public int _count = 0;// � �� �� �����ϴ� ����
   public void Score() // �̸� �ٲ�. => ������ ���� ��í ���� ���� �ϴ� �κ��̶�
    {
        //Scoretxt.text = score.ToString();

        PauseGame();
        //���� ����
        if (score >= 10) // �ٲ�
        {
            _count = 3;

        }
        else if (score < 10 && score >= 5)
        {
            _count = 2;
        }
        else if (score < 5 && score >= 0)
        {
            _count = 1;
        }

        else
        {
            
        }
       
        GetGoods(_count);

        Save();
    }


    public void Save()
    {
        // PlayerPrefs�� ���� �� ����
        PlayerPrefs.SetInt("Goods1011", DataManager.Instance.goods1011);
        PlayerPrefs.SetInt("Goods1012", DataManager.Instance.goods1012);
        PlayerPrefs.SetInt("Goods1021", DataManager.Instance.goods1021);
        PlayerPrefs.SetInt("Goods1022", DataManager.Instance.goods1022);
        PlayerPrefs.SetInt("Goods1031", DataManager.Instance.goods1031);
        PlayerPrefs.SetInt("Goods1032", DataManager.Instance.goods1032);

        PlayerPrefs.SetInt("Goods2011", DataManager.Instance.goods2011);
        PlayerPrefs.SetInt("Goods2012", DataManager.Instance.goods2012);
        PlayerPrefs.SetInt("Goods2021", DataManager.Instance.goods2021);
        PlayerPrefs.SetInt("Goods2022", DataManager.Instance.goods2022);
        PlayerPrefs.SetInt("Goods2031", DataManager.Instance.goods2031);
        PlayerPrefs.SetInt("Goods2032", DataManager.Instance.goods2032);

        PlayerPrefs.SetInt("Goods3011", DataManager.Instance.goods3011);
        PlayerPrefs.SetInt("Goods3012", DataManager.Instance.goods3012);
        PlayerPrefs.SetInt("Goods3021", DataManager.Instance.goods3021);
        PlayerPrefs.SetInt("Goods3022", DataManager.Instance.goods3022);
        PlayerPrefs.SetInt("Goods3031", DataManager.Instance.goods3031);
        PlayerPrefs.SetInt("Goods3032", DataManager.Instance.goods3032);
        PlayerPrefs.Save();

    }
    // ���� ����� �Լ�
    public void RestartClick()
    {
        Debug.Log("Restart");

        SceneManager.LoadScene("HNMiniGameScene");
    }
    // ���� Ȩ���� ���� �Լ�
    public void HomeClick()
    {
        SceneManager.LoadScene("HomeScene");
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
            pauseBG.gameObject.SetActive(false);
            stopBg.gameObject.SetActive(false);
            realStopBg.gameObject.SetActive(false);
            isGamePaused = false;
            Main_BGM2.Play();
        }
    }

    // ���� �Ͻ����� ó��
    private void PauseGame()
    {
        isGamePaused = true;
        // ���� �Ͻ����� UI Ȱ��ȭ
        pauseBG.gameObject.SetActive(true);
        stopBg.gameObject.SetActive(true);
        Main_BGM2.Pause();


    }
   


    // �������� ���ư��� ��ư �Լ�
    public void keepGoingClick()
    {
        // ���� �Ͻ����� UI ��Ȱ��ȭ
        pauseBG.gameObject.SetActive(false);
        stopBg.gameObject.SetActive(false);
        ResumeGame();
    }

    // ����ŷ� ���ư��� ��ư �Լ�
    public void goTitleClick()
    {
        // ���� �Ͻ����� UI ��Ȱ��ȭ
        pauseBG.gameObject.SetActive(false);
        stopBg.gameObject.SetActive(false);
        Main_BGM2.Play();

        // ������Bg Ȱ��ȭ
        pauseBG.gameObject.SetActive(true);
        realStopBg.gameObject.SetActive(true);
    }

    // �������� ���ư��� ��ư �Լ�
    public void stopNoClick()
    {
        // ������Bg Ȱ��ȭ
        pauseBG.gameObject.SetActive(false);
        realStopBg.gameObject.SetActive(false);
        ResumeGame();
    }

    // Ȩ���� ��ư �Լ�
    public void stopOkClick()
    {
        pauseBG.gameObject.SetActive(false);
    }


    // ���� �簳 ó��
    private void ResumeGame()
    {
        isGamePaused = false;
        Main_BGM2.Play();
    }



}
