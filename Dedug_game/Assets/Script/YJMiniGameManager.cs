using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YJMiniGameManager : MonoBehaviour
{
    // �̴ϰ��� ���� �� �� �θ� ��ü
    public GameObject endBg;
    public GameObject startBg;

    // �޽��� ��� �̹��� �θ� ��ü
    public GameObject messageBg;
    public GameObject messageBg02;

    // �޽��� Ÿ�� ��� �ؽ�Ʈ �� ����Ʈ
    public Image loveEffect;

    // ������ Ÿ�̹� ���� �̹���
    public Image success;
    public Image fail;

    // ���� ���ð� ī��Ʈ
    public Text beforeCount;
    public Image beforeImg;

    // �̴ϰ��� ž �� ���� ���� (����, ���ѽð�)
    public Text costText;
    public Text countDown;

    // �����ҳ� ĳ���� �� ����(���ΰ�) �ִϸ��̼� �̹���
    public Image badaChar;
    public Image meChar;
    public Image meChar01;
    public Image meChar02;
    public Image meChar03;
    public Image meChar04;

    // ���� ��ư
    public Button message01;
    public Button message02;
    public Button bong01;
    public Button bong02;
    public Button bong03;

    // ������ Ÿ�� �ȳ� ����Ʈ
    public Image colorEffect01;
    public Image colorEffect02;
    public Image colorEffect03;

    // ���� �� ���ѽð�, ���ð� ����
    public static int score;
    int gameTime;
    int beforeGameTime;

    // ������ Ÿ��!
    private bool isGameRunning = false;
    // private float bongTime = 2.0f;
    private bool isBongTimeActive = false;

    // �ϵ� ������ Ÿ��!
    public Image hardStart;
    private float hardBongTimeNext = 3.0f;
    private bool isHardBongTimeActive = false;

    // �ϵ� ������ Ÿ�� ������� ������ ��� �� ��ư ���� ����
    private Queue<Image> activeColorEffects = new Queue<Image>();
    private Queue<Button> expectedBongButtons = new Queue<Button>();

    // �ϵ� ������ Ÿ�� ���� Ŭ�� ���θ� �����ϴ� ����
    private bool isHardBongTimeButtonClick = false;

    // �ߺ� �÷� ������ ���� ����Ʈ ����
    private List<Image> availableColorEffects = new List<Image>();

    // ���� �Ͻ����� ���� ����
    public Image stopBg;
    public Button stop;
    public Button keepGoing;
    public Button goTitle;

    public Image PauseBG;

    public Image realStopBg;
    public Button stopOk;
    public Button stopNo;

    // ���� ��鸲
    private float shakeRange = 0.2f;
    private float shakeSpeed = 2f;

    public AudioSource gameAudioSource;  // ���� �� ����� ����

    public AudioSource badamessage01_SFX;

    public AudioSource badasucces_SFX;
    public AudioSource badafail_SFX;

    public AudioSource badacount_SFX;

    public AudioSource bongtime01;
    public AudioSource bongtime02;
    public AudioSource bongtime03;

    public AudioSource Result_SFX;

    // ���� ���� ��
    public GameObject ResultCanvas;
    public static bool badaResult;


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


    // Ŭ�� Ÿ�̹� ����
    public Image bongNomal01;
    public Image bongNomal02;
    public Image bongNomal03;

    public Image hardStartMessage;

    public Image NomalMessage;

    // Ŭ�� Ÿ�̹� �Ϲ� ������ Ÿ�� ����
    public bool nomalStart;

    // �Ͻ����� ����
    public bool isPuse = false;

    // Ÿ�̸� �����̴� �߰�
    public Slider timerSlider;

    // ������ ��� ����
    public Image reward1BG;
    public Image reward2BG;
    public Image reward3BG;


    // ���â �߰�
    public GameObject RestartPopup;
    public GameObject GoldlackPopup;
    public Text RestartGoldText;

    public bool MessageGo;

    // ������ �Һ� �ȳ� ���� �߰�
    public Image touch01;
    public Image touch02;

    public GameObject DGPopup;

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
        // ���� ���� �� ȣ��Ǵ� �Լ�
        StartGame();

        gameAudioSource.loop = true;  // �ݺ� ���


        //PercentageTable_1���� �迭�� ����Ұ�
        data_Dialog = CSVReader.Read("PercentageTable");


        //UserScore = GameObject.Find("UserScoretxt").GetComponent<Text>();  //�־ȵǴ°����Ф�

        // �̰� ������ �𸣰ڴµ� ������� �ؼ� �ϴ� ����
        RewardsImage.Add(Reward1);
        RewardsImage.Add(Reward2);
        RewardsImage.Add(Reward3);

        Setting();

    }

    private void StartGame()
    {
        // ���� ���ð� �ʱ�ȭ �� ���ð� UI Ȱ��ȭ
        beforeGameTime = 3;
        beforeCount.gameObject.SetActive(true);
        beforeImg.gameObject.SetActive(true);

        // ���� �ð�, ���� �ʱ�ȭ
        gameTime = 60;
        score = 0;

        isHardBongTimeActive = false;
        nomalStart = false;


        // ���� UI ������Ʈ
        UpdateUI();

        // 1�ʸ��� CountDownBeforeGame �޼ҵ� ȣ��
        InvokeRepeating("CountDownBeforeGame", 1.0f, 1.0f);

    }

    // ���� ���ð� ����
    private void CountDownBeforeGame()
    {

        // ���� ���ð� ī��Ʈ �ٿ�
        beforeGameTime--;

        if (beforeGameTime == 0)
        {
            // ���� ���ð� ���� �� ����
            beforeCount.gameObject.SetActive(false);
            beforeImg.gameObject.SetActive(false);
            // CountDownBeforeGame ȣ�� �ߴ�
            CancelInvoke("CountDownBeforeGame");

            // ���� ���� ����
            StartRealTimeGame();
        }
        else
        {
            // ���ð� �ؽ�Ʈ ����
            badacount_SFX.Play();
            beforeCount.text = beforeGameTime.ToString();

        }
    }

    // ���� ����
    private void StartRealTimeGame()
    {
        // ���� ���� ����
        isGameRunning = true;

        // �ʱ� ���ѽð� ����
        countDown.text = gameTime.ToString();

        touch01.gameObject.SetActive(true);
        touch02.gameObject.SetActive(true);

        Invoke("TouchSet", 3f);


        // 1�ʸ��� UpdateGame �޼ҵ� ȣ��
        InvokeRepeating("UpdateGame", 1.0f, 1.0f);

        gameAudioSource.Play();


    }


    public void TouchSet()
    {
        touch01.gameObject.SetActive(false);
        touch02.gameObject.SetActive(false);
    }


    private void UpdateGame()
    {
        // 0. ���ѽð��� ����� ���
        if (gameTime <= 0 && isGameRunning)
        {
            countDown.text = "0";
            // ���� ���� ó��
            EndGame();
            return;
        }

        if (gameTime > 0 && isGameRunning)
        {
            // 1. �ǽð� ī��Ʈ�ٿ� ���� �� BGM ���
            countDown.text = gameTime.ToString();
            gameTime--;
            timerSlider.value = gameTime;
        }

        // 2. bongTime ���� ������ colorEffect Ȱ��ȭ
        if (gameTime >= 49 && gameTime % 5 == 0)
        {
            // Coroutine�� ����
            StartCoroutine(ActivateNomalColorEffects());
        }

        if (gameTime == 45)
        {
            // Coroutine�� ����
            StartCoroutine(ActivatehardStartMessage());
        }

        // (5) countDown < 60�� ���
        if (gameTime > 27 && gameTime < 49 && gameTime % 7 == 0)
        {
            // ������ colorEffect�� 2���� �̹����� 3�� ���� Ȱ��ȭ �� ��Ȱ��ȭ
            StartCoroutine(ActivateRandomColorEffects());
        }

        if (gameTime > 0 && gameTime <= 27 && gameTime % 10 == 0)
        {
            StartCoroutine(TooHardRandomColorEffects());
        }

        // 3. ���� ��ư Ŭ�� ó��
        if (Input.GetMouseButtonDown(0))
        {
            HandleButtonClick();
        }

        // 4. ���ھ 0 �̸����� �������� �ʵ��� Ȯ��
        if (score < 0)
        {
            score = 0;
            costText.text = "Score: " + score.ToString();
        }

        // meChar�� Y ���� �������� �պ��ϵ��� ����� �ڵ�
        if (isGameRunning)
        {
            float yOffset = Mathf.PingPong(Time.time * shakeSpeed, shakeRange * 2) - shakeRange;
            Vector3 newPos = meChar.transform.position;
            newPos.y = yOffset;
            meChar.transform.position = newPos;
        }

        // meChar�� Y ���� �������� �պ��ϵ��� ����� �ڵ�
        if (isGameRunning)
        {
            float yOffset = Mathf.PingPong(Time.time * shakeSpeed, shakeRange * 2) - shakeRange;
            Vector3 newPos = meChar01.transform.position;
            newPos.y = yOffset;
            meChar01.transform.position = newPos;
        }

        // meChar�� Y ���� �������� �պ��ϵ��� ����� �ڵ�
        if (isGameRunning)
        {
            float yOffset = Mathf.PingPong(Time.time * shakeSpeed, shakeRange * 2) - shakeRange;
            Vector3 newPos = meChar02.transform.position;
            newPos.y = yOffset;
            meChar02.transform.position = newPos;
        }

        // meChar�� Y ���� �������� �պ��ϵ��� ����� �ڵ�
        if (isGameRunning)
        {
            float yOffset = Mathf.PingPong(Time.time * shakeSpeed, shakeRange * 2) - shakeRange;
            Vector3 newPos = meChar03.transform.position;
            newPos.y = yOffset;
            meChar03.transform.position = newPos;
        }

        // meChar�� Y ���� �������� �պ��ϵ��� ����� �ڵ�
        if (isGameRunning)
        {
            float yOffset = Mathf.PingPong(Time.time * shakeSpeed, shakeRange * 2) - shakeRange;
            Vector3 newPos = meChar04.transform.position;
            newPos.y = yOffset;
            meChar04.transform.position = newPos;
        }

        // �ٴ�» �¿�� ��鸮�� ����� �ڵ�
        if (isGameRunning)
        {
            ShakeObject(badaChar, shakeRange, shakeSpeed);
        }


        // Ŭ�� Ÿ�̹� ����
        if(isHardBongTimeActive == false || nomalStart == false)
        {
            bongNomal01.gameObject.SetActive(true);
            bongNomal02.gameObject.SetActive(true);
            bongNomal03.gameObject.SetActive(true);
        }

        if(isHardBongTimeActive == true)
        {
            bongNomal01.gameObject.SetActive(false);
            bongNomal02.gameObject.SetActive(false);
            bongNomal03.gameObject.SetActive(false);
            hardStart.gameObject.SetActive(true);
        }

        if (nomalStart == true)
        {
            bongNomal01.gameObject.SetActive(false);
            bongNomal02.gameObject.SetActive(false);
            bongNomal03.gameObject.SetActive(false);
            NomalMessage.gameObject.SetActive(true);
        }

        if (score == 8)
        {
            EndGame();
            score = 0;
        }

    }

    IEnumerator ActivatehardStartMessage()
    {
        // �̹��� Ȱ��ȭ
        hardStartMessage.gameObject.SetActive(true);

        // 2�� ��ٸ�
        yield return new WaitForSeconds(2f);

        // �̹��� ��Ȱ��ȭ
        hardStartMessage.gameObject.SetActive(false);
    }

    // �ٴ�» ��� �Լ�
    private void ShakeObject(Image obj, float range, float speed)
    {
        float xOffset = Mathf.PingPong(Time.time * speed, range * 2) - range;
        Vector3 newPos = obj.transform.position;
        newPos.x = xOffset;
        obj.transform.position = newPos;
    }

    // �� �ϵ� ��Ÿ�� ����

    private IEnumerator TooHardRandomColorEffects()
    {
        expectedBongButtons.Clear(); // ������ ����� ��ư �ʱ�ȭ

        for (int i = 0; i < 3; i++)
        {
            // ������ colorEffect�� �����ͼ� ť�� �߰�
            Image randomColorEffect = GetRandomColorEffect();
            activeColorEffects.Enqueue(randomColorEffect);

            // 1.5�� ���� Ȱ��ȭ
            randomColorEffect.gameObject.SetActive(true);
            
            // ȿ���� ���
            PlayColorEffectSound(randomColorEffect);

            yield return new WaitForSeconds(1f);

            // �����ϴ� bong ��ư�� tooExpectedBongButtons�� ����
            expectedBongButtons.Enqueue(GetMatchingBongButton(randomColorEffect));

            // ��Ȱ��ȭ
            randomColorEffect.gameObject.SetActive(false);
        }

        // (5)���� ������ ��� 3�� ���ȸ� hardBongTimeNext�� �����
        isHardBongTimeActive = true;
        isHardBongTimeButtonClick = true;
        Invoke("DeactivateHardBongTime", hardBongTimeNext);

        yield return new WaitForSeconds(hardBongTimeNext);

        // hardBongTimeNext�� ���� �� isHardBongTimeActive = false�� �ϰ� ���ÿ� hardStart�� ��Ȱ��ȭ
        isHardBongTimeActive = false;
        hardStart.gameObject.SetActive(false);

        // hardBongTime�� ����Ǹ� �ٽ� activeColorEffects�� ���
        activeColorEffects.Clear();
    }

    // �ϵ� ��Ÿ�� ����
    private IEnumerator ActivateRandomColorEffects()
    {
        expectedBongButtons.Clear(); // ������ ����� ��ư �ʱ�ȭ

        for (int i = 0; i < 2; i++)
        {
            // ������ colorEffect�� �����ͼ� ť�� �߰�
            Image randomColorEffect = GetRandomColorEffect();
            activeColorEffects.Enqueue(randomColorEffect);

            // 1.5�� ���� Ȱ��ȭ
            randomColorEffect.gameObject.SetActive(true);

            // ȿ���� ���
            PlayColorEffectSound(randomColorEffect);

            yield return new WaitForSeconds(1.5f);

            // �����ϴ� bong ��ư�� expectedBongButtons�� ����
            expectedBongButtons.Enqueue(GetMatchingBongButton(randomColorEffect));

            // ��Ȱ��ȭ
            randomColorEffect.gameObject.SetActive(false);
        }

        // (5)���� ������ ��� 3�� ���ȸ� hardBongTimeNext�� �����
        isHardBongTimeActive = true;
        isHardBongTimeButtonClick = true;
        Invoke("DeactivateHardBongTime", hardBongTimeNext);

        yield return new WaitForSeconds(hardBongTimeNext);

        // hardBongTimeNext�� ���� �� isHardBongTimeActive = false�� �ϰ� ���ÿ� hardStart�� ��Ȱ��ȭ
        isHardBongTimeActive = false;
        hardStart.gameObject.SetActive(false);

        // hardBongTime�� ����Ǹ� �ٽ� activeColorEffects�� ���
        activeColorEffects.Clear();
    }

    // �ϵ� ��Ÿ�� ����
    private IEnumerator ActivateNomalColorEffects()
    {
        expectedBongButtons.Clear(); // ������ ����� ��ư �ʱ�ȭ

        for (int i = 0; i < 1; i++)
        {
            // ������ colorEffect�� �����ͼ� ť�� �߰�
            Image randomColorEffect = GetRandomColorEffect();
            activeColorEffects.Enqueue(randomColorEffect);

            // 1.5�� ���� Ȱ��ȭ
            randomColorEffect.gameObject.SetActive(true);

            // ȿ���� ���
            PlayColorEffectSound(randomColorEffect);

            yield return new WaitForSeconds(1.5f);

            // �����ϴ� bong ��ư�� expectedBongButtons�� ����
            expectedBongButtons.Enqueue(GetMatchingBongButton(randomColorEffect));

            // ��Ȱ��ȭ
            randomColorEffect.gameObject.SetActive(false);
        }

        // (5)���� ������ ��� 3�� ���ȸ� hardBongTimeNext�� �����
        nomalStart = true;
        isHardBongTimeButtonClick = true;
        Invoke("DeactivateHardBongTime", hardBongTimeNext);

        yield return new WaitForSeconds(hardBongTimeNext);

        // hardBongTimeNext�� ���� �� isHardBongTimeActive = false�� �ϰ� ���ÿ� hardStart�� ��Ȱ��ȭ
        nomalStart = false;
        NomalMessage.gameObject.SetActive(false);

        // hardBongTime�� ����Ǹ� �ٽ� activeColorEffects�� ���
        activeColorEffects.Clear();
    }

    // ȿ���� ��� �޼ҵ�
    private void PlayColorEffectSound(Image colorEffect)
    {
        if (colorEffect == colorEffect01)
        {
            bongtime01.Play();
        }

        else if (colorEffect == colorEffect02)
        {
            bongtime02.Play();
        }

        else if (colorEffect == colorEffect03)
        {
            bongtime03.Play();
        }
    }

    // �ϵ� �� Ÿ�� ���� ó��
    private void DeactivateHardBongTime()
    {
        isHardBongTimeActive = false;
        nomalStart = false;
        // �ϵ� �� Ÿ�� ���� ��ư�� Ŭ������ �ʾ��� ��� score�� -1 ����
        if (isHardBongTimeButtonClick == true || nomalStart == true)
        {
            score--;
            if (score < 0)
            {
                score = 0;
                costText.text = "Score: " + score.ToString();
            }
            costText.text = "Score: " + score.ToString();

            // ���� �̹��� Ȱ��ȭ
            fail.gameObject.SetActive(true);
            badafail_SFX.Play();
            Invoke("DeactivateFailImage", 2.0f);
        }
        // hardBongTime�� ����Ǹ� �ٽ� activeColorEffects�� ���
        activeColorEffects.Clear();
    }

    // �������� ����Ʈ �÷� ����
    private Button GetMatchingBongButton(Image colorEffect)
    {
        if (colorEffect == colorEffect01)
        {
            return bong01;
        }
        else if (colorEffect == colorEffect02)
        {
            return bong02;
        }
        else if (colorEffect == colorEffect03)
        {
            return bong03;
        }

        return null;
    }

    // �÷� ����Ʈ ���� �̱�
    private Image GetRandomColorEffect()
    {
        // ������ colorEffect ��ȯ
        if (availableColorEffects.Count == 0)
        {
            // ��� ������ �÷� ����Ʈ�� ������ ��� �÷� ����Ʈ�� �ٽ� �߰�
            availableColorEffects.AddRange(new List<Image> { colorEffect01, colorEffect02, colorEffect03 });
        }

        // ������ �÷� ����Ʈ ��ȯ �� ��� ��Ͽ��� ����
        int randomIndex = UnityEngine.Random.Range(0, availableColorEffects.Count);
        Image randomColorEffect = availableColorEffects[randomIndex];
        availableColorEffects.RemoveAt(randomIndex);

        return randomColorEffect;
    }

    private void DeactivateColorEffect()
    {
        // ��� colorEffect ��Ȱ��ȭ
        colorEffect01.gameObject.SetActive(false);
        colorEffect02.gameObject.SetActive(false);
        colorEffect03.gameObject.SetActive(false);
    }

    // ������ Ŭ�� �˻�
    public void HandleButtonClick()
    {

        // �ϵ� ������ Ÿ���� �� �߰��� �κ�
        if (isHardBongTimeActive == true)
        {
            // ������ ��ư�� Ŭ������ �� ���� �˻�
            CheckUserInput();

        }

        if (nomalStart == true)
        {
            // ������ ��ư�� Ŭ������ �� ���� �˻�
            CheckUserInput();
        }

        // bongTime�� ������ �� �߰��� �κ�
        if (isBongTimeActive)
        {
            // bong ��ư�� �ϳ��� Ŭ������ �ʾ��� �� ó��
            if (expectedBongButtons.Count == 0)
            {
                // ��ư�� Ŭ������ �ʾ��� ���� ó��
                score--;  // ���ھ� ����

                if (score < 0)
                {
                    score = 0;
                    costText.text = "Score: " + score.ToString();
                }

                costText.text = "Score: " + score.ToString();  // UI ������Ʈ
                isBongTimeActive = false;  // bongTime ���� Ŭ�� ���� ���� ���� �ʱ�ȭ
                DeactivateColorEffect();  // colorEffect ��Ȱ��ȭ

                // ���� �̹��� Ȱ��ȭ
                fail.gameObject.SetActive(true);
                badafail_SFX.Play();
                Invoke("DeactivateFailImage", 2.0f);
            }
        }

        if (isGameRunning)
        {
            // ���� ���� üũ
            CheckGameEnd();
        }

    }

    // �ϵ� ������ Ÿ�� ��ư Ŭ�� �Լ�
    private void CheckUserInput()
    {
        if (expectedBongButtons.Count > 0)
        {
            Button expectedButton = expectedBongButtons.Dequeue(); // ť���� ��ư�� ������� ������

            if (EventSystem.current.currentSelectedGameObject == expectedButton.gameObject)
            {
                // �̹� ���� ���� Invoke ����
                CancelInvoke("DeactivateSuccessImage");

                // �̹��� �ʱ�ȭ
                success.gameObject.SetActive(false);
                badasucces_SFX.Stop();

                // ��ư�� �ùٸ� ������ Ŭ���Ǿ��� ��
                score++;
                costText.text = "Score: " + score.ToString();

                // ���� �̹��� Ȱ��ȭ
                success.gameObject.SetActive(true);
                badasucces_SFX.Play();
                Invoke("DeactivateSuccessImage", 0.5f);
            }
            else
            {
                // �̹� ���� ���� Invoke ����
                CancelInvoke("DeactivateFailImage");

                // �̹��� �ʱ�ȭ
                fail.gameObject.SetActive(false);
                badafail_SFX.Stop();

                // ��ư�� �߸� Ŭ���Ǿ��� ��
                score--;

                if (score < 0)
                {
                    score = 0;
                    costText.text = "Score: " + score.ToString();
                }
                
                costText.text = "Score: " + score.ToString();

                // ���� �̹��� Ȱ��ȭ
                fail.gameObject.SetActive(true);
                badafail_SFX.Play();
                Invoke("DeactivateFailImage", 0.5f);
            }

            // UI ������Ʈ
            UpdateUI();

            // Ŭ�� ���� ���� �ʱ�ȭ
            isHardBongTimeButtonClick = false;
        }
    }

    private void DeactivateSuccessImage()
    {
        // ���� �̹��� ��Ȱ��ȭ
        success.gameObject.SetActive(false);
    }

    private void DeactivateFailImage()
    {
        // ���� �̹��� ��Ȱ��ȭ
        fail.gameObject.SetActive(false);
    }

    private void UpdateUI()
    {
        // UI ������Ʈ (���ѽð�, ����)
        countDown.text = gameTime.ToString();
        timerSlider.value = gameTime;
        costText.text = "Score: " + score.ToString();
    }

    private void CheckGameEnd()
    {
        // ���ѽð��� ����Ǹ� ���� ����
        if (gameTime <= 0 && isGameRunning)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        // ���� ���� �� ���� ����
        gameAudioSource.Stop();

        isGameRunning = false;

        // ���� ���� �� ȣ��Ǵ� �Լ�
        // badaResult = true;
        Score();
        Result_SFX.Play();
        ResultCanvas.SetActive(true);

        //� ������Ʈ�� �����Ұ���?
        ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        Restart = GameObject.Find("Restart").GetComponent<Button>();
        HomeBtn = GameObject.Find("Home").GetComponent<Button>();

    }

    public void OnMessage01ButtonClick()
    {

        if (isHardBongTimeActive == true || nomalStart == true)
        {
            return;
        }

            if (nomalStart == false && isGameRunning == true || isHardBongTimeActive == false && isGameRunning == true)
        {
            badamessage01_SFX.Play();
            // message01 ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
            StartCoroutine(DisplayMessage01());
        }
    }

    public void OnMessage02ButtonClick02()
    {

        if (isHardBongTimeActive == true || nomalStart == true)
        {
            return;
        }

        if (nomalStart == false && isGameRunning == true || isHardBongTimeActive == false && isGameRunning == true)
        {
            badamessage01_SFX.Play();
            // message02 ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
            StartCoroutine(DisplayMessage02());
        }
    }

    private IEnumerator DisplayMessage01()
    {
        // �޽��� ��� �� ���� �ð� �Ŀ� ����
        messageBg.SetActive(true);
        loveEffect.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        messageBg.SetActive(false);
        loveEffect.gameObject.SetActive(false);
    }


    private IEnumerator DisplayMessage02()
    {
        // �޽��� ��� �� ���� �ð� �Ŀ� ����
        messageBg02.SetActive(true);
        loveEffect.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        messageBg02.SetActive(false);
        loveEffect.gameObject.SetActive(false);
    }

    // ���� �Ͻ����� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void StopButtonClick()
    {
        if (!isPuse)
        {
            isPuse = true;
            Time.timeScale = 0;

            gameAudioSource.Pause();

            // ���� �Ͻ����� UI Ȱ��ȭ
            stopBg.gameObject.SetActive(true);
            PauseBG.gameObject.SetActive(true);
        }
    }

    // �������� ���ư��� ��ư �Լ�
    public void keepGoingClick()
    {
        if(isPuse)
        {
            isPuse = false;
            Time.timeScale = 1;
        }

        gameAudioSource.Play();

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

        gameAudioSource.Play();

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
        Scoretxt.text = "0" + score.ToString();

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
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        // PlayerPrefs�� ���� �� ����
        PlayerPrefs.Save();

        Debug.Log("�̴ϰ��� ���:" +  DataManager.Instance.goods1011);
       
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
                SceneManager.LoadScene("YJMiniGameScene");
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
                SceneManager.LoadScene("YJMiniGameScene");
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
                SceneManager.LoadScene("YJMiniGameScene");
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
                SceneManager.LoadScene("YJMiniGameScene");
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
                SceneManager.LoadScene("YJMiniGameScene");
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

    public void Click_OnDGPopup() //���� �˾� ��Ȱ��ȭ
    {
        DGPopup.gameObject.SetActive(true);
    }

    public void Click_OffDGPopup() //���� �˾� ��Ȱ��ȭ
    {
        DGPopup.gameObject.SetActive(false);
    }

    public void RequestClick()
    {
        SceneManager.LoadScene("RequestScene");
    }

    public void HomeClick()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void DGClick()
    {
        SceneManager.LoadScene("DG_Scene");
    }

}
