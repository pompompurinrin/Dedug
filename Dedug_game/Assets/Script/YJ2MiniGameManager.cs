using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class YJ2MiniGameManager : MonoBehaviour
{
    // ��� �� ���� �̹���
    public Image suaChar;
    public Image gameBg;

    // ��� �̹���
    public GameObject eventMon;
    public GameObject eventHeal;
    public GameObject eventFan;

    // ��� ���� �̹���
    public GameObject eventIconMon;
    public GameObject eventIconHeal;
    public GameObject eventIconFan;

    // ��� ��� �̹���
    public GameObject MonBg;
    public GameObject HealBg;
    public GameObject FanBg;

    public GameObject[] eventIcons; // �̺�Ʈ �����ܵ��� �迭�� ����
    public GameObject[] eventImage; // �̺�Ʈ ������Ʈ���� �迭�� ����
    public GameObject[] eventBg; // �̺�Ʈ ������ �迭�� ����


    // �����ӽ� ������ �̹���
    public Image slotIcon01;
    public Image slotIcon02;
    public Image slotIcon03;
    public Sprite[] slotSprites; // slotIconMon, slotIconHeal, slotIconFan ��������Ʈ���� �迭�� ����

    // �����ӽ� ���� �ִϸ��̼�
    public Image slotAnimation01;
    public Image slotAnimation02;
    public Image slotAnimation03;

    // ���ھ� ���� �̹���
    public Image fail;
    public Image Success;

    // ���� ���ð� ī��Ʈ
    public Text beforeCountText;
    public Image beforeImg;

    // Ÿ�̸� �� ����
    int beforeCount;
    int score;
    int timer;
    int slotTimer;
    int eventTimer;

    public Text scoreText;
    public Text timerText;

    // Ÿ�̸� �����̴�
    public Slider eventTimeSlider;
    public Slider slotTimeSlider;

    // �����ӽ� ��ư
    public Button slotButton;

    // ���� ����
    bool slotStart = false;    // ���� ��ŸƮ
    bool eventStart = false;    // �̺�Ʈ ��ŸƮ

    // ���� ���� ����
    bool isGameRunning;

    // �̺�Ʈ Ÿ�̸� ����
    bool isEventActive = false;

    // ����� ���� ����
    public GameObject monScore;
    public GameObject healScore;
    public GameObject fanScore;

    // ���� ������
    public GameObject slotStop;

    // Ȯ�� �߰�
    bool mon;
    bool heal;
    bool fan;

    // ���� ����
    public GameObject slotFail01;
    public GameObject slotFail02;
    public GameObject slotFail03;


    // ����� �߰�
    public AudioSource sua_BGM;
    public AudioSource sloting_SFX; // ���� ���ư���
    public AudioSource slotResultFail_SFX;
    public AudioSource slotResulySuccess_SFX;
    public AudioSource slotStart_SFX;
    public AudioSource eventChange_SFX;
    public AudioSource fail_SFX;
    public AudioSource count_SFX;
    public AudioSource Result_SFX;

    // ���� ���� �ִϸ��̼�
    public Image fin;


    // ��� ����

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


    // ������ ����Ʈ ������ ���⼭ ��Ŵ
    public List<Image> RewardsImage = new List<Image>();

    public List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    public List<Sprite> goodsSprites = new List<Sprite>();

    public List<int> gatchIdList;
    public List<int> gatchPerList;
    public List<int> rewards; // �� �ֵ�

    public GameObject ResultCanvas;


    // �Ͻ����� ����
    public bool isPuse = false;

    // ���� �Ͻ����� ���� ����
    public Image stopBg;
    public Button stop;
    public Button keepGoing;
    public Button goTitle;

    public Image realStopBg;
    public Button stopOk;
    public Button stopNo;

    // ���â ������ ���
    public Image reward1BG;
    public Image reward2BG;
    public Image reward3BG;

    // �Ͻ����� ���
    public Image PauseBG;

    // �Ͻ����� �����̴�
    public Slider timerSlider;

    // ���â �߰�
    public GameObject RestartPopup;
    public GameObject GoldlackPopup;
    public Text RestartGoldText;

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
        //PercentageTable_1���� �迭�� ����Ұ�
        data_Dialog = CSVReader.Read("PercentageTable");

        // ���� ���� �� ȣ��Ǵ� �Լ�
        StartGame();

        // �̰� ������ �𸣰ڴµ� ������� �ؼ� �ϴ� ����
        RewardsImage.Add(Reward1);
        RewardsImage.Add(Reward2);
        RewardsImage.Add(Reward3);

        Setting();

    }

    public void StartGame()
    {
        // ���� ���ð� �ʱ�ȭ �� ���ð� UI Ȱ��ȭ
        beforeCount = 3;
        beforeCountText.gameObject.SetActive(true);
        beforeImg.gameObject.SetActive(true);

        // ���� �ð�, ���� �ʱ�ȭ
        timer = 60;
        score = 0;

        // ���� UI ������Ʈ
        UpdateUI();

        // 1�ʸ��� CountDownBeforeGame �޼ҵ� ȣ��
        InvokeRepeating("CountDownBeforeGame", 1.0f, 1.0f);
    }

    private void UpdateUI()
    {
        // UI ������Ʈ (���ѽð�, ����)
        timerText.text = timer.ToString();
        timerSlider.value = timer;
        scoreText.text = "Score: " + score.ToString();
    }

    // ���� ���ð� ����
    private void CountDownBeforeGame()
    {

        // ���� ���ð� ī��Ʈ �ٿ�
        beforeCount--;

        if (beforeCount == 0)
        {
            // ���� ���ð� ���� �� ����
            beforeCountText.gameObject.SetActive(false);
            beforeImg.gameObject.SetActive(false);
            // CountDownBeforeGame ȣ�� �ߴ�
            CancelInvoke("CountDownBeforeGame");

            // ���� ���� ����
            StartRealTimeGame();
        }
        else
        {
            count_SFX.Play();
            // ���ð� �ؽ�Ʈ ����
            beforeCountText.text = beforeCount.ToString();

        }
    }

    public void StartRealTimeGame()
    {



        // ���� ���� ����
        isGameRunning = true;

        // ������� ��� ����
        sua_BGM.Play();

        // �̺�Ʈ Ÿ�� ����
        eventStart = true;

        // �ʱ� ���ѽð� ����
        timerText.text = timer.ToString();

        // 1�ʸ��� UpdateGame �޼ҵ� ȣ��
        InvokeRepeating("UpdateGame", 1.0f, 1.0f);

        // ���� ���� �� �������� �̺�Ʈ ����
        ActivateRandomEvent();
    }


    public void UpdateGame()
    {
        if (isGameRunning)
        {
            // Ÿ�̸� ����
            timer--;
            timerSlider.value = timer;

            if (eventStart == true)
            {
                // �̺�Ʈ Ÿ�̸� �����̴� ������Ʈ
                UpdateEventSlider();

                // �̺�Ʈ Ÿ�̸� ����
                eventTimer--;
            }

            // UI ������Ʈ
            UpdateUI();

            // Ÿ�̸Ӱ� 0�̸� ���� ����
            if (timer == 0)
            {
                EndGame();
            }

            // ���ھ 8�̸� ���� ����
            if (score >= 8)
            {
                EndGame();
            }

            if (timer < 0)
            {
                timer = 0;
            }

            // ���� ��鸮�� �ִϸ��̼�
            ShakeSuaCharacter();
        }
    }

    private void ShakeSuaCharacter()
    {
        // ���� ĳ���͸� x���� �������� �¿�� ��鸮�� �ִϸ��̼�
        suaChar.rectTransform.DOPunchPosition(new Vector3(20f, 0f, 0f), 0.5f, 5, 1f);
    }

    public void UpdateEventSlider()
    {
        // �̺�Ʈ Ȱ��ȭ ���¿����� ������Ʈ
        if (isEventActive)
        {
            // �̺�Ʈ Ÿ�̸� �����̴� ������Ʈ
            eventTimeSlider.value = eventTimer;
        }

        if (eventTimer == 0)
        {
            fail_SFX.Play();

            score--;

            if (score < 0)
            {
                score = 0;
            }

            UpdateUI();
            
            fail.gameObject.SetActive(true);
            Invoke("DeactivateFailImage", 0.5f);

            EventChange();
        }

    }
    private void ActivateRandomEvent()
    {
        // ������ Ȱ��ȭ�Ǿ� �ִ� �̺�Ʈ ��Ȱ��ȭ
        DeactivateAllEvents();

        // ����� ���
        eventChange_SFX.Play();

        // �������� �̺�Ʈ �����ܰ� �̺�Ʈ Ȱ��ȭ
        int randomIndex = UnityEngine.Random.Range(0, eventIcons.Length);

        eventIcons = new GameObject[] { eventIconMon, eventIconHeal, eventIconFan };
        eventImage = new GameObject[] { eventMon, eventHeal, eventFan };
        eventBg = new GameObject[] { MonBg, HealBg, FanBg };

        // �����̵� �ִϸ��̼����� Ȱ��ȭ
        GameObject IconToSlide = eventIcons[randomIndex];
        IconToSlide.SetActive(true);
        IconToSlide.transform.DOMoveX(10f, 1.0f).From().SetEase(Ease.OutQuart);

        GameObject ImageToSlide = eventImage[randomIndex];
        ImageToSlide.SetActive(true);
        ImageToSlide.transform.DOMoveX(10f, 1.0f).From().SetEase(Ease.OutQuart);

        GameObject bgToSlide = eventBg[randomIndex];
        bgToSlide.SetActive(true);
        bgToSlide.transform.DOMoveX(10f, 1.0f).From().SetEase(Ease.OutQuart);

        if (randomIndex == 0)
        {
            mon = true;
        }

        if(randomIndex == 1)
        {
            heal = true;
        }

        if (randomIndex == 2)
        {
            fan = true;
        }

        // �̺�Ʈ Ȱ��ȭ ���·� ����
        isEventActive = true;

        // eventTimer�� 10���� �ʱ�ȭ
        eventTimer = 10;
    }

    private void DeactivateAllEvents()
    {
        mon = false;
        heal = false;
        fan = false;

        // ��� �̺�Ʈ �����ܰ� �̺�Ʈ ��Ȱ��ȭ
        foreach (var icon in eventIcons)
        {
            icon.SetActive(false);
        }

        foreach (var obj in eventImage)
        {
            obj.SetActive(false);
        }

        foreach (var Bg in eventBg)
        {
            Bg.SetActive(false);
        }

        // �̺�Ʈ ��Ȱ��ȭ ���·� ����
        isEventActive = false;
    }

    public void EventChange()
    {
        // �̺�Ʈ ���� �� �ٽ� �������� �̺�Ʈ ����
        ActivateRandomEvent();
    }

    public void SlotButtonClicked()
    {
        // ó�� Ŭ������ ���� slotTimer�� 8�ʷ� ����
        if (!slotStart)
        {
            slotTimer = 8;

            slotStart_SFX.Play();

            slotAnimation01.gameObject.SetActive(true);
            slotAnimation02.gameObject.SetActive(true);
            slotAnimation03.gameObject.SetActive(true);
        }

        if (slotStart == true)
        {
            slotTimer--;
            sloting_SFX.Play();
        }

        // slotButton Ŭ�� �� ����Ǵ� �޼ҵ�
        slotStart = true;

        // 1�ʸ��� SlotTimerCountdown �޼ҵ� ȣ��
        InvokeRepeating("SlotTimerCountdown", 1.0f, 1.0f);
    }


    private void SlotTimerCountdown()
    {
        // slotTimer ����
        slotTimer--;
        slotTimeSlider.value = slotTimer;

        if (slotTimer < 0)
        {
            slotTimer = 0;
        }

        // slotTimer�� 0�̸� ȣ�� �ߴ��ϰ� �̹��� ���
        if (slotTimer == 0)
        {

            slotAnimation01.gameObject.SetActive(false);
            slotAnimation02.gameObject.SetActive(false);
            slotAnimation03.gameObject.SetActive(false);

            // ȣ�� �ߴ�
            CancelInvoke("SlotTimerCountdown");

            // slotStart�� false�� �����Ͽ� �� �̻� ī��Ʈ�ٿ��� ���� �ʵ��� ��
            slotStart = false;

            slotStop.gameObject.SetActive(true);

            // �������� �̹��� ���
            ActivateRandomSlotIcons();

            // ���� �����ܰ� �̺�Ʈ ������ ���Ͽ� ���ھ� ó��
            CompareIconsAndScore();

        }
    }

    private void ActivateRandomSlotIcons()
    {
        if (mon == true)
        {
            SetRandomSlotIcon(slotIcon01, 0.5f, 0.25f, 0.25f);
            SetRandomSlotIcon(slotIcon02, 0.5f, 0.25f, 0.25f);
            SetRandomSlotIcon(slotIcon03, 0.5f, 0.25f, 0.25f);
        }
        else if (heal == true)
        {
            SetRandomSlotIcon(slotIcon01, 0.25f, 0.5f, 0.25f);
            SetRandomSlotIcon(slotIcon02, 0.25f, 0.5f, 0.25f);
            SetRandomSlotIcon(slotIcon03, 0.25f, 0.5f, 0.25f);
        }
        else if (fan == true)
        {
            SetRandomSlotIcon(slotIcon01, 0.25f, 0.25f, 0.5f);
            SetRandomSlotIcon(slotIcon02, 0.25f, 0.25f, 0.5f);
            SetRandomSlotIcon(slotIcon03, 0.25f, 0.25f, 0.5f);
        }
    }

    // ���� ������ �̹����� Ȯ���� ���� �����ϴ� �޼ҵ�
    private void SetRandomSlotIcon(Image slotIcon, float probability1, float probability2, float probability3)
    {
        
        float randomProbability = UnityEngine.Random.Range(0f, 1f);

        if (randomProbability < probability1)
        {
            slotIcon.sprite = slotSprites[0];
        }
        else if (randomProbability < probability1 + probability2)
        {
            slotIcon.sprite = slotSprites[1];
        }
        else
        {
            slotIcon.sprite = slotSprites[2];
        }

        slotIcon01.gameObject.SetActive(true);
        slotIcon02.gameObject.SetActive(true);
        slotIcon03.gameObject.SetActive(true);
    }


    // ���ھ� ó��
    private void CompareIconsAndScore()
    {
        int eventIconIndex = GetActiveEventIconIndex();

        // �̺�Ʈ �����ܰ� ���� ������ ��
        if (eventIconIndex != -1)
        {
            int matchingCount = CountMatchingIcons(eventIconIndex);

            if (matchingCount >= 0 && matchingCount < 2)
            {

                slotResultFail_SFX.Play();

                // ��ġ�ϴ� ������ ���� Ȯ��
                Sprite eventSprite = eventIcons[eventIconIndex].GetComponent<Image>().sprite;

                if (slotIcon01.sprite != eventSprite)
                {
                    slotFail01.gameObject.SetActive(true);
                }

                if (slotIcon02.sprite != eventSprite)
                {
                    slotFail02.gameObject.SetActive(true);
                }

                if(slotIcon03.sprite != eventSprite)
                {
                    slotFail03.gameObject.SetActive(true);
                }

                Invoke("FailSet", 1f);
            }

            if (matchingCount >= 2)
            {
                Success.gameObject.SetActive(true);
                Invoke("SuccessSet", 1f);

                // ��ġ�ϸ� ���ھ� ����
                score++;
                UpdateUI();

                slotResulySuccess_SFX.Play();

                // ��ġ�ϴ� ������ ���� Ȯ��
                Sprite eventSprite = eventIcons[eventIconIndex].GetComponent<Image>().sprite;

                Vector3 originalScale = new Vector3(1, 1, 1);
                Vector3 targetScale = new Vector3(1.5f, 1.5f, 1.5f);

                eventIcons[eventIconIndex].transform.DOScale(targetScale, 0.2f).OnComplete(() => // ���ٽ�
                {
                    eventIcons[eventIconIndex].transform.DOScale(originalScale, 0.2f);
                });

                // ��ġ�ϴ� ���� ������ ����
                if (slotIcon01.sprite == eventSprite)
                {
                    slotIcon01.transform.DOScale(targetScale, 0.2f).OnComplete(() => // ���ٽ�
                    {
                        slotIcon01.transform.DOScale(originalScale, 0.2f);
                    });
                }

                if (slotIcon02.sprite == eventSprite)
                {
                    slotIcon02.transform.DOScale(targetScale, 0.2f).OnComplete(() => // ���ٽ�
                    {
                        slotIcon02.transform.DOScale(originalScale, 0.2f);
                    });
                }

                if(slotIcon03.sprite == eventSprite)
                {
                    slotIcon03.transform.DOScale(targetScale, 0.2f).OnComplete(() => // ���ٽ�
                    {
                        slotIcon03.transform.DOScale(originalScale, 0.2f);
                    });
                }

                // ��ġ�ϴ� �����ܿ� ���� ���� ����
                if (eventSprite.name == "mon_Icon")
                {
                    StartCoroutine(ActivateAndDeactivateScore(monScore));
                }
                else if (eventSprite.name == "heal_Icon")
                {
                    StartCoroutine(ActivateAndDeactivateScore(healScore));
                }
                else if (eventSprite.name == "fan_Icon")
                {
                    StartCoroutine(ActivateAndDeactivateScore(fanScore));
                }
                
                eventStart = false;
                Invoke("EventRestart", 1f);
                Invoke("EventChange", 1f);
            }
        }

        Invoke("Slotfalse", 1f);
    }

    // ���� ���� ����
    public void SuccessSet()
    {
        Success.gameObject.SetActive(false);
    }

    // ���� ���� ����
    public void FailSet()
    {
        slotFail01.gameObject.SetActive(false);
        slotFail02.gameObject.SetActive(false);
        slotFail03.gameObject.SetActive(false);
    }

    // ���� ������ ����
    public void Slotfalse()
    {
        slotIcon01.gameObject.SetActive(false);
        slotIcon02.gameObject.SetActive(false);
        slotIcon03.gameObject.SetActive(false);

        slotStop.gameObject.SetActive(false);
    }

    public void EventRestart()
    {
        eventStart = true;
    }

    // �ڷ�ƾ�� �̿��Ͽ� ���� �ð� ���� GameObject�� Ȱ��ȭ �� ��Ȱ��ȭ
    private IEnumerator ActivateAndDeactivateScore(GameObject scoreObject)
    {
        scoreObject.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        scoreObject.SetActive(false);
    }

    private int GetActiveEventIconIndex()
    {
        for (int i = 0; i < eventIcons.Length; i++)
        {
            if (eventIcons[i].activeSelf)
            {
                return i;
            }
        }
        return -1;
    }

    private int CountMatchingIcons(int eventIconIndex)
    {
        Sprite eventSprite = eventIcons[eventIconIndex].GetComponent<Image>().sprite;

        int matchingCount = 0;

        // ���� �����ܵ�� ���Ͽ� ��ġ�ϴ� ���� ����
        if (slotIcon01.sprite == eventSprite)
        {
            matchingCount++;
        }

        if (slotIcon02.sprite == eventSprite)
        {
            matchingCount++;
        }

        if (slotIcon03.sprite == eventSprite)
        {
            matchingCount++;
        }

        return matchingCount;


    }
    private void DeactivateFailImage()
    {
        // ���� �̹��� ��Ȱ��ȭ
        fail.gameObject.SetActive(false);
    }

    private void EndGame()
    {
        // ���� ���� ó��

        // �ߺ� ȣ�� ����
        if (!isGameRunning)
        {
            return;
        }

        isGameRunning = false;

        sua_BGM.Stop();
        Score();
        Result_SFX.Play();
        ResultCanvas.SetActive(true);

        //� ������Ʈ�� �����Ұ���?
        ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        Restart = GameObject.Find("Restart").GetComponent<Button>();
        HomeBtn = GameObject.Find("Home").GetComponent<Button>();
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


    public List<Sprite> rewardGoods = new List<Sprite>();

    public int _count = 0;// � �� �� �����ϴ� ����
    void Score() // �̸� �ٲ�. => ������ ���� ��í ���� ���� �ϴ� �κ��̶�
    {
        Scoretxt.text = score.ToString();

        //���� ����
        if (score >= 8) // �ٲ�
        {
            _count = 3;
            reward1BG.gameObject.SetActive(true);
            reward2BG.gameObject.SetActive(true);
            reward3BG.gameObject.SetActive(true);

        }
        else if (score < 8 && score >= 4)
        {
            _count = 2;
            reward1BG.gameObject.SetActive(true);
            reward2BG.gameObject.SetActive(true);
            reward3BG.gameObject.SetActive(false);
        }
        else
        {
            _count = 1;
            reward1BG.gameObject.SetActive(true);
            reward2BG.gameObject.SetActive(false);
            reward3BG.gameObject.SetActive(false);
        }

            GetGoods(_count);


    }


    public void Save()
    {
        for (int i = 0; i < rewards.Count; i++)
        {
            int rewardId = rewards[i];

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
        // PlayerPrefs�� ���� �� ����

        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        PlayerPrefs.Save();

        Debug.Log("�̴ϰ��� ���:" + DataManager.Instance.goods1011);




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
                SceneManager.LoadScene("YJ2MiniGameScene");
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
                SceneManager.LoadScene("YJ2MiniGameScene");
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
                SceneManager.LoadScene("YJ2MiniGameScene");
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
                SceneManager.LoadScene("YJ2MiniGameScene");
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
                SceneManager.LoadScene("YJ2MiniGameScene");
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


    public void RequestClick()
    {
        SceneManager.LoadScene("RequestScene");
    }

    public void HomeClick()
    {
        SceneManager.LoadScene("HomeScene");
    }


    // ���� �Ͻ����� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void StopButtonClick()
    {
        if (!isPuse)
        {
            isPuse = true;
            Time.timeScale = 0;

            sua_BGM.Pause();

            // ���� �Ͻ����� UI Ȱ��ȭ
            stopBg.gameObject.SetActive(true);
            PauseBG.gameObject.SetActive(true);
        }
    }

    // �������� ���ư��� ��ư �Լ�
    public void keepGoingClick()
    {
        if (isPuse)
        {
            isPuse = false;
            Time.timeScale = 1;
        }

        sua_BGM.Play();

        // ���� �Ͻ����� UI ��Ȱ��ȭ
        stopBg.gameObject.SetActive(false);
        PauseBG.gameObject.SetActive(false);
    }

    // ����ŷ� ���ư��� ��ư �Լ�
    public void goTitleClick()
    {
        // ���� �Ͻ����� UI ��Ȱ��ȭ
        stopBg.gameObject.SetActive(false);

        // ������Bg Ȱ��ȭ
        realStopBg.gameObject.SetActive(true);
    }

    // �������� ���ư��� ��ư �Լ�
    public void stopNoClick()
    {
        if (isPuse)
        {
            isPuse = false;
            Time.timeScale = 1;
        }

        sua_BGM.Play();

        // ������Bg Ȱ��ȭ
        realStopBg.gameObject.SetActive(false);
        PauseBG.gameObject.SetActive(false);
    }

    // �������� ���ư��� ó��
    public void RealStopClick()
    {

        isPuse = false;
        Time.timeScale = 1;

        SceneManager.LoadScene("HomeScene");
    }

}
