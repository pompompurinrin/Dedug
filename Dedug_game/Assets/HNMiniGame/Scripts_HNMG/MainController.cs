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
    // 스코어 초기값
    public int score = 0;

    // 타이머
    public float gameTimer = 30f;        // 게임 시간 30초 설정
    public float readyCounter = 3f;      // 대기 시간 3초 설정
    public float showCounter = 3f;       // 쇼잉 시간 3초 설정
    public Slider gameTimerSlider;       // 게임 시간 UI 슬라이더 연결
    public Text gameTimerText;           // 게임 시간 출력
    public Text readyCount;              // 대기 시간 출력
    public Text showMessage;             // 쇼잉 메세지 출력
    public Image readyCountBG;           // 대기 시간 BG

    // 사운드
    public AudioSource Main_BGM2;        // 메인 BGM
    public AudioSource correct_sfx;      // 매칭 성공 사운드
    public AudioSource error_sfx;        // 매칭 에러 사운드
    public AudioSource readyCount_SFX;   // 대기 시간 효과음

    // 이펙트
    public GameObject correct_fx;        // 매칭 성공 효과
    public GameObject error_fx;          // 매칭 에러 효과

    // 게임 보드의 열과 행의 수
    public const int columns = 4;
    public const int rows = 5;

    // 이미지를 배치할 부모 객체
    public Transform parent;

    // 이미지 사이의 간격 설정
    public const float Xspace = 260f;
    public const float Yspace = -310f;
    
    // 게임 시작 이미지 및 사용될 스프라이트 배열
    public MainImageScript mainImageScript;
    public Sprite[] images;

    public Button Card_Front;
    
    // UI 요소들
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

    // 각종 효과 및 결과를 나타내는 텍스트들
    public Text UserScoretxt; //얘는 게임에서 저장 된 유저 점수를 불러올 것임!! 
    public string imageFileName; // 얘는 CSV에서 Goods열의 숫자를 가져와서 이미지로 뽑아낼거임!!

    // 리워드 변수
    public Image Reward1;
    public Image Reward2;
    public Image Reward3;

    // 리워드 배경 변수
    public Image Reward1BG;
    public Image Reward2BG;
    public Image Reward3BG;

    public AudioSource Result_SFX;



    // 리워드 리스트 선언을 여기서 시킴
    public List<Image> RewardsImage = new List<Image>();
    public List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();


    // 위치를 무작위로 섞는 함수
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

        Main_BGM2.Play();    // 메인 BGM 재생
        correct_sfx.Stop();  // correct_sfx 정지
        error_sfx.Stop();    // correct_sfx 정지

        //PercentageTable_1에서 배열을 사용할게
        data_Dialog = CSVReader.Read("PercentageTable");

        // 이건 왜인지 모르겠는데 넣으라고 해서 일단 넣음
        RewardsImage.Add(Reward1);
        RewardsImage.Add(Reward2);
        RewardsImage.Add(Reward3);

        Input.multiTouchEnabled = false;

        Setting();

        // 초기화
        gameTimer = 30f;
        readyCounter = 3f;
        showCounter = 4f;
        gameTimerSlider.maxValue = gameTimer;
        gameTimerSlider.value = gameTimer;

        readyCount_SFX.Stop();

        // 레디 카운트를 1초 뒤에 1초마다 실행
        InvokeRepeating("ReadyCounter", 0, 1f);
        Input.multiTouchEnabled = false;

    }

    // 게임이 시작될 때 호출되는 함수
    private void StartGame()
    {
        // 게임이 일시 정지 중일 경우 반환
        if (isGamePaused)
        {
            return;
        }

        else
        {
            isGameRunnig = true;

            Debug.Log("시크릿 카드걸즈 게임 진짜 시작");

            // 이미지 위치를 무작위로 섞음
            int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };

            locations = Randomiser(locations);

            Vector3 startPosition = mainImageScript.transform.position;

            // 게임 보드에 이미지 배치
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    MainImageScript gameImage;
                    if (i == 0 && j == 0)
                    {
                        // 시작 이미지는 따로 처리
                        gameImage = mainImageScript;
                    }
                    else
                    {
                        // 나머지 이미지는 복제하여 사용
                        gameImage = Instantiate(mainImageScript) as MainImageScript;
                    }

                    int index = j * columns + i;

                    int id = locations[index];
                    gameImage.ChangeSprite(id, images[id]);

                    // 이미지의 위치 설정
                    float positionX = (Xspace * i) + startPosition.x;
                    float positionY = (Yspace * j) + startPosition.y;

                    gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
                    gameImage.transform.SetParent(parent, false);

                }
            }
        }
    }

    // 열려진 이미지를 추적하고, 맞는지 확인하는 함수
    private MainImageScript firstOpen;
    private MainImageScript secondOpen;

    // 두 번째 이미지를 열 수 있는지 여부를 반환하는 속성
    public bool canOpen
    {
        get { return secondOpen == null; }
    }

    // 이미지가 열렸을 때 호출되는 함수
    public void imageOpened(MainImageScript mainImageScript)
    {
        if (firstOpen == null)
        {
            // 첫 번째 이미지 열림
            firstOpen = mainImageScript;
        }
        else
        {
            // 두 번째 이미지 열림 후 일치 여부 확인
            secondOpen = mainImageScript;
            StartCoroutine(CheckGuessed());
        }
    }
  
    // 이미지 일치 여부를 확인하고 처리하는 코루틴
    private IEnumerator CheckGuessed()
    {
        if (firstOpen.spriteId == secondOpen.spriteId) // 두 이미지의 스프라이트 ID 비교
        {
            
            score++;                                         // 일치하면 점수 증가
            Scoretxt.text= "Score : " + score.ToString();    // 실시간 스코어 텍스트로 출력
            
            correct_sfx.Play();                              // correct_sfx 재생

            MainImageScript card1 = firstOpen;
            MainImageScript card2 = secondOpen;

            Vector3 originalScale = new Vector3(1, 1, 1);
            Vector3 targetScale = new Vector3(1.5f, 1.5f, 1.5f);

           
                    

                card1.transform.DOScale(targetScale, 0.2f).OnComplete(() => // 람다식
                {
                    card1.transform.DOScale(originalScale, 0.2f);
                    card1.correct_fx.gameObject.SetActive(true);
                                           
                });


                card2.transform.DOScale(targetScale, 0.2f).OnComplete(() => // 람다식
                {
                    card2.transform.DOScale(originalScale, 0.2f);
                    card2.correct_fx.gameObject.SetActive(true);
                    secondOpen = null;  // 변수 초기화 추가
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

                //어떤 컴포넌트에 배정할거임?
                ResultBGBG = GameObject.Find("ResultBG").GetComponent<Image>();
                ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
                Restart = GameObject.Find("Restart").GetComponent<Button>();
                HomeBtn = GameObject.Find("Home").GetComponent<Button>();
                UserScore = GameObject.Find("UserScoretxt").GetComponent<Text>();
               

            }
        }
        else
        {
            // 일치하지 않으면 0.5초 후에 이미지를 닫음
            yield return new WaitForSeconds(0.5f);

            firstOpen.Close();
            secondOpen.Close();
            error_sfx.Play();                        
        }

        // 열려진 이미지 변수 초기화
        firstOpen = null;
        secondOpen = null;
    }

    public void Click_OnRestartPopup() //리스타트 팝업 활성화
    {
        GoldText();
        RestartPopup.gameObject.SetActive(true);
    }

    public void Click_OffRestartPopup() //리스타트 팝업 비활성화
    {
        RestartPopup.gameObject.SetActive(false);
    }

    public void Click_OffGoldlack() //골드 부족 팝업 비활성화
    {
        GoldlackPopup.gameObject.SetActive(false);
    }
    public void RestartClick() //진수: 리스타트 클릭 시 현재 랭크에 맞추어 그에 해당하는 골드를 소모하는 스크립트
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

    public void GoldText() //다시 시작 팝업에서 필요한 골드량을 나타내는 스크립트
    {
        if (DataManager.Instance.nowRank == 0)
        {
            RestartGoldText.text = "다시 시도할 경우 100골드가 소모됩니다.";
        }

        else if (DataManager.Instance.nowRank == 1)
        {
            RestartGoldText.text = "다시 시도할 경우 500골드가 소모됩니다.";
        }

        else if (DataManager.Instance.nowRank == 2)
        {
            RestartGoldText.text = "다시 시도할 경우 1000골드가 소모됩니다.";
        }


        else if (DataManager.Instance.nowRank == 3)
        {
            RestartGoldText.text = "다시 시도할 경우 1500골드가 소모됩니다.";
        }

        else if (DataManager.Instance.nowRank == 4)
        {
            RestartGoldText.text = "다시 시도할 경우 3000골드가 소모됩니다.";
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


    // 게임 일시정지 관련 변수   
    public Image pauseBG;
    public Image stopBg;
    public Button stop;
    public Button keepGoing;
    public Button goTitle;

    public Image realStopBg;
    public Button stopOk;
    public Button stopNo;

    [SerializeField] private TimerController timerController;

    // 게임 일시정지 상태를 나타내는 변수
    public bool isGamePaused = false;


    // 게임 일시정지 상태를 나타내는 변수
    public bool isGameRunnig = false;

    // 게임 일시정지 버튼 클릭 시 호출되는 함수
    public void StopButtonClick()
    {
        if (!isGamePaused)
        {
            // 게임 일시정지
            PauseGame();
            Debug.Log("일시정지로 게임 중단");
        }
        else if (isGamePaused)
        {
            // 게임 재개
            Time.timeScale = 1;
            pauseBG.gameObject.SetActive(false);
            stopBg.gameObject.SetActive(false);
            realStopBg.gameObject.SetActive(false);
            isGamePaused = false;
            Main_BGM2.Play();
        }
    }
    public float timeScale;
    // 게임 일시정지 처리
    private void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0;

        // 게임 일시정지 UI 활성화
        pauseBG.gameObject.SetActive(true);
        stopBg.gameObject.SetActive(true);
        Main_BGM2.Pause();


    }

    // 게임으로 돌아가기 버튼 함수
    public void keepGoingClick()
    {
        // 게임 재개
        Time.timeScale = 1;
        pauseBG.gameObject.SetActive(false);
        stopBg.gameObject.SetActive(false);
        realStopBg.gameObject.SetActive(false);
        isGamePaused = false;
        Main_BGM2.Play();
    }

    // 굿즈구매로 돌아가기 버튼 함수
    public void goTitleClick()
    {
        // 게임 일시정지 UI 비활성화
        pauseBG.gameObject.SetActive(false);
        stopBg.gameObject.SetActive(false);


        // 리얼스톱Bg 활성화
        pauseBG.gameObject.SetActive(true);
        realStopBg.gameObject.SetActive(true);
    }

    // 게임으로 돌아가기 버튼 함수
    public void stopNoClick()
    {
        // 게임 재개
        Time.timeScale = 1;
        pauseBG.gameObject.SetActive(false);
        stopBg.gameObject.SetActive(false);
        realStopBg.gameObject.SetActive(false);
        isGamePaused = false;
        Main_BGM2.Play();
    }
    public HomeManager homeManager;
    // 굿즈구매로 버튼 함수
    public void stopOkClick()
    {
        Time.timeScale = 1;
        isGamePaused = false;

        SceneManager.LoadScene("HomeScene");
        //homeManager.OnButtonClick_OnGoodsBuy();
    }

    // 게임 재개 처리
    private void ResumeGame()
    {
        isGamePaused = false;
        Main_BGM2.Play();
    }

    public List<Sprite> goodsSprites = new List<Sprite>();

    public List<int> gatchIdList;
    public List<int> gatchPerList;
    public List<int> rewards; // 줄 애들

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
    public void Score() // 이름 바꿔. => 점수에 따라 가챠 수량 설정 하는 부분이라서
    {
        UserScoretxt.text = score.ToString("F0");      // 최종 유저 스코어 텍스트로 출력
        

        //굿즈 지급
        if (score >= 10) // 바꿔
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
            Debug.Log("리워드 아이디 " + rewardId);
            
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

        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        // PlayerPrefs에 현재 값 저장
        PlayerPrefs.Save();

        //Debug.Log("미니게임 결과:" +  DataManager.Instance.goods1011); //특정 굿즈 오류 체크용
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
