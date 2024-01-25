using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HJYJMinigameManager : MonoBehaviour
{
    // UI 요소들
    public Text scoreText;
    public Image suaChar;
    public Slider magicTimerSlider;
    public Slider timerSlider;

    public GameObject magicBookImg01;
    public GameObject magicBookImg02;
    public GameObject magicBookImg03;
    public GameObject magicBookImg04;

    public GameObject[] magicBook;

    public GameObject SouceImage01;
    public GameObject SouceImage02;
    public GameObject SouceImage03;
    public GameObject SouceImage04;

    public Image recipe01;
    public Image recipe02;
    public Image recipe03;
    public Image recipe04;

    public GameObject clickImg01;
    public GameObject clickImg02;
    public GameObject clickImg03;
    public GameObject clickImg04;

    // 클릭된 재료를 저장할 리스트
    List<GameObject> clickList = new List<GameObject>();

    // 게임 관련 변수들
    public int score;
    public int timer;
    public int magicTimer;

    // 게임 대기시간 카운트
    public Text beforeCountText;
    public Image beforeImg;

    // 타이머 및 점수
    public int beforeCount;

    // 성공 실패 판정
    public Image successImg;
    public Image failImg;

    // 게임 컨트롤
    public bool isGameRunning;


    // 일시정지 수정
    public bool isPuse = false;

    // 게임 일시정지 관련 변수
    public Image stopBg;
    public Button stop;
    public Button keepGoing;
    public Button goTitle;

    public Image realStopBg;
    public Button stopOk;
    public Button stopNo;


    // 결과 연결

    // UI 요소들
    public Image ResultBG;
    public Image ScoreBG;
    public Text Scoretxt;
    public Text UserScore;
    public Text Rewardtxt;
    public Button Restart;
    public Button HomeBtn;

    // 각종 효과 및 결과를 나타내는 텍스트들
    public Text UserScoretxt; //얘는 게임에서 저장 된 유저 점수를 불러올 것임!! 
    public string imageFileName; // 얘는 CSV에서 Goods열의 숫자를 가져와서 이미지로 뽑아낼거임!!

    // 게임 오브젝트 및 캔버스 관련 변수
    public Image Reward1;
    public Image Reward2;
    public Image Reward3;


    // 리워드 리스트 선언을 여기서 시킴
    public List<Image> RewardsImage = new List<Image>();

    public List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    public List<Sprite> goodsSprites = new List<Sprite>();

    public List<int> gatchIdList;
    public List<int> gatchPerList;
    public List<int> rewards; // 줄 애들

    public GameObject ResultCanvas;



    // 연출

    float time;

    public GameObject successEffect;

    public AudioSource success;
    public AudioSource fail;
    public AudioSource clickSuccess;
    public AudioSource sua_BGM;


    // 게임 결과 아이템 배경
    public Image reward1BG;
    public Image reward2BG;
    public Image reward3BG;

    // 타이머 텍스트
    public Text timerText;

    // 일시정지 뒷배경
    public Image PauseBG;

    // 성공 실패 뒷배경
    public Image feedBackBg;


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

        DataManager.Instance.nowRank = PlayerPrefs.GetInt("NowRank");
    }

    void Start()
    {
        //PercentageTable_1에서 배열을 사용할게
        data_Dialog = CSVReader.Read("PercentageTable");


        // 게임 시작 시 호출
        StartGame();

        // 이건 왜인지 모르겠는데 넣으라고 해서 일단 넣음
        RewardsImage.Add(Reward1);
        RewardsImage.Add(Reward2);
        RewardsImage.Add(Reward3);

        Setting();
    }

    public void StartGame()
    {

        recipe01.GetComponent<Image>().sprite = SouceImage01.GetComponent<Image>().sprite;
        recipe02.GetComponent<Image>().sprite = SouceImage02.GetComponent<Image>().sprite;
        recipe03.GetComponent<Image>().sprite = SouceImage03.GetComponent<Image>().sprite;
        recipe04.GetComponent<Image>().sprite = SouceImage04.GetComponent<Image>().sprite;

        // 게임 대기시간 초기화 및 대기시간 UI 활성화
        beforeCount = 3;
        beforeCountText.gameObject.SetActive(true);
        beforeImg.gameObject.SetActive(true);

        // 게임 시간, 점수 초기화
        timer = 60;
        magicTimer = 10;
        score = 0;

        // 1초마다 CountDownBeforeGame 메소드 호출
        InvokeRepeating("CountDownBeforeGame", 1.0f, 1.0f);
    }

    // 게임 대기시간 관련
    private void CountDownBeforeGame()
    {

        // 게임 대기시간 카운트 다운
        beforeCount--;

        if (beforeCount == 0)
        {
            // 게임 대기시간 종료 후 숨김
            beforeCountText.gameObject.SetActive(false);
            beforeImg.gameObject.SetActive(false);
            // CountDownBeforeGame 호출 중단
            CancelInvoke("CountDownBeforeGame");

            // 실제 게임 시작
            StartRealTimeGame();

            // 게임 스타트 함수
            GameStart();
        }
        else
        {
            // 대기시간 텍스트 갱신
            beforeCountText.text = beforeCount.ToString();
        }
    }

    public void StartRealTimeGame()
    {
        sua_BGM.Play();

        // 실제 게임 시작
        isGameRunning = true;

        // 1초마다 UpdateUITimer 메소드 호출
        InvokeRepeating("UpdateUITimer", 1.0f, 1.0f);

    }

    void UpdateUITimer()
    {

        if (isGameRunning)
        {
            // 타이머 카운트다운
            timer -= 1;
            timerSlider.value = timer;
            timerText.text = timer.ToString();

            if (timer == 0)
            {
                Endgame();
            }

            // 레시피 타이머 카운트다운
            magicTimer -= 1;
            magicTimerSlider.value = magicTimer;

            // 레시피 타이머가 0이 되면 실패 처리
            if (magicTimer == 0)
            {
                Fail();
            }

            if (score == 8)
            {
                Endgame();
            }
        }

    }

    void GameStart()
    {
        // 게임 시작 시 호출
        clickList.Clear(); // 리스트 초기화

        feedBackBg.gameObject.SetActive(false);
        successImg.gameObject.SetActive(false);
        failImg.gameObject.SetActive(false);

        clickImg01.gameObject.SetActive(false);
        clickImg02.gameObject.SetActive(false);
        clickImg03.gameObject.SetActive(false);
        clickImg04.gameObject.SetActive(false);

        // 매직북 선언
        magicBook = new GameObject[] { SouceImage01, SouceImage02, SouceImage03, SouceImage04 };

        // magicBook 배열을 랜덤으로 섞음
        ShuffleArray(magicBook);

        // 각 magicBookImg에 랜덤하게 magicBook 할당
        magicBookImg01.GetComponent<Image>().sprite = magicBook[0].GetComponent<Image>().sprite;
        magicBookImg02.GetComponent<Image>().sprite = magicBook[1].GetComponent<Image>().sprite;
        magicBookImg03.GetComponent<Image>().sprite = magicBook[2].GetComponent<Image>().sprite;
        magicBookImg04.GetComponent<Image>().sprite = magicBook[3].GetComponent<Image>().sprite;

        // 레시피 타이머 초기화
        magicTimer = 10;
        magicTimerSlider.value = magicTimer;
    }

    void ListUpdate()
    {
        // clickList의 길이에 따라 동작 수행
        int clickListLength = clickList.Count;
        GameObject currentClickImg = clickList[clickListLength - 1];

        if (clickListLength == 1)
        {
            if (currentClickImg.GetComponent<Image>().sprite == magicBook[0].GetComponent<Image>().sprite)
            {
                clickImg01.GetComponent<Image>().sprite = currentClickImg.GetComponent<Image>().sprite;
                clickImg01.gameObject.SetActive(true);

                clickSuccess.Play();

                successEffect.gameObject.SetActive(true);
                Invoke("SetSuccessEffect", 1f);
            }

            if (currentClickImg.GetComponent<Image>().sprite != magicBook[0].GetComponent<Image>().sprite)
            {
                Fail();

                clickList.Clear(); // 리스트 초기화
            }
        }

        if (clickListLength == 2)
        {
            if (currentClickImg.GetComponent<Image>().sprite == magicBook[1].GetComponent<Image>().sprite)
            {
                clickImg02.GetComponent<Image>().sprite = currentClickImg.GetComponent<Image>().sprite;
                clickImg02.gameObject.SetActive(true);

                clickSuccess.Play();

                successEffect.gameObject.SetActive(true);
                Invoke("SetSuccessEffect", 1f);
            }

            if (currentClickImg.GetComponent<Image>().sprite != magicBook[1].GetComponent<Image>().sprite)
            {
                Fail();

                clickList.Clear(); // 리스트 초기화
            }
        }

        if (clickListLength == 3)
        {
            if (currentClickImg.GetComponent<Image>().sprite == magicBook[2].GetComponent<Image>().sprite)
            {
                clickImg03.GetComponent<Image>().sprite = currentClickImg.GetComponent<Image>().sprite;
                clickImg03.gameObject.SetActive(true);

                clickSuccess.Play();

                successEffect.gameObject.SetActive(true);
                Invoke("SetSuccessEffect", 1f);
            }

            if (currentClickImg.GetComponent<Image>().sprite != magicBook[2].GetComponent<Image>().sprite)
            {
                Fail();

                clickList.Clear(); // 리스트 초기화
            }
        }

        // 4번째 재료를 클릭했을 때 성공 또는 실패 처리
        if (clickListLength == 4)
        {
            if (clickList[3].GetComponent<Image>().sprite == magicBook[3].GetComponent<Image>().sprite)
            {
                clickImg04.GetComponent<Image>().sprite = currentClickImg.GetComponent<Image>().sprite;
                clickImg04.gameObject.SetActive(true);

                successEffect.gameObject.SetActive(true);
                Invoke("SetSuccessEffect", 1f);

                Success();
            }

            if (currentClickImg.GetComponent<Image>().sprite != magicBook[3].GetComponent<Image>().sprite)
            {
                Fail();

                clickList.Clear(); // 리스트 초기화
            }
        }
    }

    public void SetSuccessEffect()
    {
        successEffect.gameObject.SetActive(false);
    }

    void ShuffleArray(GameObject[] array)
    {
        // 배열을 랜덤하게 섞음
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            GameObject temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

    public void ButtonClick01()
    {
        // 버튼 클릭 시 호출
        clickList.Add(SouceImage01);
        ListUpdate();
    }

    public void ButtonClick02()
    {
        // 버튼 클릭 시 호출
        clickList.Add(SouceImage02);
        ListUpdate();
    }

    public void ButtonClick03()
    {
        // 버튼 클릭 시 호출
        clickList.Add(SouceImage03);
        ListUpdate();
    }

    public void ButtonClick04()
    {
        // 버튼 클릭 시 호출
        clickList.Add(SouceImage04);
        ListUpdate();
    }

    public void Success()
    {
        success.Play();

        magicTimer = 10;
        magicTimerSlider.value = magicTimer;
        magicTimer++;

        score++;
        scoreText.text = score.ToString();
        feedBackBg.gameObject.SetActive(true);
        successImg.gameObject.SetActive(true);

        Invoke("GameStart", 1f);
    }

    public void Fail()
    {
        fail.Play();

        score--;

        if (score < 0)
        {
            score = 0;
        }

        scoreText.text = score.ToString();
        feedBackBg.gameObject.SetActive(true);
        failImg.gameObject.SetActive(true);

        Invoke("GameStart", 1f);
    }

    public void Endgame()
    {
        // 중복 호출 방지
        if (!isGameRunning)
        {
            return;
        }

        isGameRunning = false;

        // 게임 종료 처리

        Score();

        ResultCanvas.SetActive(true);

        //어떤 컴포넌트에 배정할거임?
        ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        Restart = GameObject.Find("Restart").GetComponent<Button>();
        HomeBtn = GameObject.Find("Home").GetComponent<Button>();
    }

    void Setting() // 씬 들어가자마자 한번 하면 됨
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
                    string imageString = "Goods" + data_Dialog[i]["Goods"].ToString();
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
                    string imageString = "Goods" + data_Dialog[i]["Goods"].ToString();
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
                    string imageString = "Goods" + data_Dialog[i]["Goods"].ToString();
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
                    string imageString = "Goods" + data_Dialog[i]["Goods"].ToString();
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
                    string imageString = "Goods" + data_Dialog[i]["Goods"].ToString();
                    goodsSprites.Add(Resources.Load<Sprite>(imageString));

                    Debug.Log("rank" + rank);
                }
            }
        }

    }

    public void GetGoods(int _count) // 실제 가챠를 하는 부분. count에는 뽑고 싶은 수량 넣기
    {

        if (data_Dialog.Count == 0)
        {
            data_Dialog = CSVReader.Read("PercentageTable");
        }

        for (int i = 0; i < RewardsImage.Count; i++)
        {
            RewardsImage[i].gameObject.SetActive(false); // 싹 다 꺼
        }

        int randMaxValue = 0; // 모든 가중치 값을 더하기 위한 변수. 휴먼 에러 방지 용
        for (int i = 0; i < gatchPerList.Count; i++)
        {
            randMaxValue += gatchPerList[i]; // 가중치 싹 다 더하기. 999, 1001 방지
        }

        for (int i = 0; i < _count; i++) // 몇번
        {
            GetItems(randMaxValue); // 뽑기

            RewardsImage[i].sprite = rewardGoods[i];
            RewardsImage[i].gameObject.SetActive(true); // 바뀌었으니 켜라
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

    public int _count = 0;// 몇개 줄 지 설정하는 변수
    void Score() // 이름 바꿔. => 점수에 따라 가챠 수량 설정 하는 부분이라서
    {
        Scoretxt.text = score.ToString();

        //굿즈 지급
        if (score >= 8) // 바꿔
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

            // 보상을 ID에 따라 DataManager.Instance에 매핑
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

                    // 다른 보상 ID에 대한 케이스 추가...
            }

        }
        // PlayerPrefs에 현재 값 저장

        PlayerPrefs.Save();

        Debug.Log("미니게임 결과:" + DataManager.Instance.goods1011);




    }

    public void RestartClick()
    {
        SceneManager.LoadScene("DG_Scene"); //일단은 도감으로 연결해뒀던거라 다시 시작할 거면 이 부분 바꿔주어야 함
    }

    public void HomeClick()
    {
        SceneManager.LoadScene("HomeScene");
    }


    // 게임 일시정지 버튼 클릭 시 호출되는 함수
    public void StopButtonClick()
    {
        if (!isPuse)
        {
            isPuse = true;
            Time.timeScale = 0;
            // 게임 일시정지 UI 활성화
            stopBg.gameObject.SetActive(true);
            PauseBG.gameObject.SetActive(true);
        }
    }

    // 게임으로 돌아가기 버튼 함수
    public void keepGoingClick()
    {
        if (isPuse)
        {
            isPuse = false;
            Time.timeScale = 1;
        }

        // 게임 일시정지 UI 비활성화
        stopBg.gameObject.SetActive(false);
        PauseBG.gameObject.SetActive(false);
    }

    // 굿즈구매로 돌아가기 버튼 함수
    public void goTitleClick()
    {
        // 게임 일시정지 UI 비활성화
        stopBg.gameObject.SetActive(false);

        // 리얼스톱Bg 활성화
        realStopBg.gameObject.SetActive(true);
    }

    // 게임으로 돌아가기 버튼 함수
    public void stopNoClick()
    {
        if (isPuse)
        {
            isPuse = false;
            Time.timeScale = 1;
        }

        // 리얼스톱Bg 활성화
        realStopBg.gameObject.SetActive(false);
        PauseBG.gameObject.SetActive(false);
    }

    // 도감으로 돌아가기 처리
    public void RealStopClick()
    {
        SceneManager.LoadScene("HomeScene");
    }

}
