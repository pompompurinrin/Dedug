using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.SocialPlatforms.Impl;




public class MainController2 : MonoBehaviour
{
    
    
    // 스코어 초기값
    public int score = 0;

    // 메인 BGM
    public AudioSource Main_BGM;
    public AudioSource heal_sfx;     // 매칭 성공 사운드
    public AudioSource hit_sfx;       // 매칭 에러 사운드

    public GameObject heal_fx;    // 힐 효과
    public GameObject hit_fx;     // 피격 효과


    // UI 요소들
    public Image ResultBG;
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

    // 리워드 리스트 선언을 여기서 시킴
    public List<Image> RewardsImage = new List<Image>();
    public List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    public bool isGameRunnig = false;

    public GameObject MagicalGirlsPrefab;  // 생성할 떨어지는 굿즈 프리팹
    public GameObject ObstaclePrefab;
    public GameObject StudentPrefab;
    public Sprite[] MagicalGirlsSprites;
    public Sprite[] ObstacleSprites;
    public Sprite[] StudentSprites;
    int randomMagicalGirlsImage;
    int randomObstacleImage;
    int randomStudentImage;

    public float span = 4;  // 굿즈가 생성되는 주기
    public float delta = 0;
    int randPrefab = 0;


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

        DataManager.Instance.nowRank = PlayerPrefs.GetInt("NowGold");
        DataManager.Instance.nowGold = PlayerPrefs.GetInt("NowRank");
    }
   
    private void Start()
    {
        Debug.Log("초롱아 도와줘 게임 시작");
        
        
        StartGame(); // 게임 시작

        Main_BGM.Play();    // 메인 BGM 재생
        heal_sfx.Stop();  // correct_sfx 정지
        hit_sfx.Stop();    // correct_sfx 정지

        span = 4;

        //PercentageTable_1에서 배열을 사용할게
        data_Dialog = CSVReader.Read("PercentageTable");

        // 이건 왜인지 모르겠는데 넣으라고 해서 일단 넣음
        RewardsImage.Add(Reward1);
        RewardsImage.Add(Reward2);
        RewardsImage.Add(Reward3);

        Setting();

    }

    // 게임이 시작될 때 호출되는 함수
    private void StartGame()
    {
        if (isGamePaused)
            return;

       

        else
        {
            Debug.Log("초롱아 도와줘 게임 진짜 시작");
            isGameRunnig = true;

        }

    }

    void Update()
    {
        if (isGamePaused || !isGameRunnig)
            return;

        this.delta += Time.deltaTime;
        

        if (this.delta > this.span)
        {
            this.delta = 0;
            randPrefab = Random.Range(0, 3);

            if (this.delta == 3)
            {
                span = 0.1f;
            }

            if (randPrefab == 0)
            {
                span = 0.5f;
                randomStudentImage = Random.Range(0, StudentSprites.Length);
                GameObject go = Instantiate(StudentPrefab);
                go.GetComponent<SpriteRenderer>().sprite = StudentSprites[randomStudentImage];
                int px = Random.Range(-2, 2);
                go.transform.position = new Vector3(px, 4, 1);
                Transform healFxTransform = go.transform.Find("heal_fx");
                if (healFxTransform != null)
                {
                    healFxTransform.gameObject.SetActive(true);
                }
            }
            else if (randPrefab == 1)
            {
                span = 0.2f;
                randomObstacleImage = Random.Range(0, ObstacleSprites.Length);
                GameObject go2 = Instantiate(ObstaclePrefab);
                go2.GetComponent<SpriteRenderer>().sprite = ObstacleSprites[randomObstacleImage];
                int px = Random.Range(-2, 2);
                go2.transform.position = new Vector3(px, 4, 1);
                Transform hitfxTransform = go2.transform.Find("hit_fx");
                if (hitfxTransform != null)
                {
                    hitfxTransform.gameObject.SetActive(true);
                }
            }

            else
            {
                span = 0.3f;
                randomMagicalGirlsImage = Random.Range(0, MagicalGirlsSprites.Length);
                GameObject go3 = Instantiate(MagicalGirlsPrefab);
                go3.GetComponent<SpriteRenderer>().sprite = MagicalGirlsSprites[randomMagicalGirlsImage];
                int px = Random.Range(-2, 2);
                go3.transform.position = new Vector3(px, 4, 1);
                Transform healFxTransform = go3.transform.Find("heal_fx");
                if (healFxTransform != null)
                {
                    healFxTransform.gameObject.SetActive(true);
                }
            }


        }

        else if (this.delta >= 3)
        {
            span = 1;
        }
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
                StartGame();
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
                StartGame();


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
                StartGame();
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
                StartGame();
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
                StartGame();
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

    /*public void RestartClick() 
    {
        SceneManager.LoadScene("DG_Scene"); //일단은 도감으로 연결해뒀던거라 다시 시작할 거면 이 부분 바꿔주어야 함
    }*/

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
    public Image pauseBG1;
    public Image stopBg;
    public Button stop;
    public Button keepGoing;
    public Button goTitle;

    public Image realStopBg;
    public Button stopOk;
    public Button stopNo;

    [SerializeField] private TimeController2 timeController2;

    // 게임 일시정지 상태를 나타내는 변수
    public bool isGamePaused = false;

    // 게임 일시정지 버튼 클릭 시 호출되는 함수
    public void StopButtonClick()
    {
        if (!isGamePaused)
        {
            // 게임 일시정지
            PauseGame();
        }
        else if (isGamePaused)
        {

            // 게임 재개
            Time.timeScale = 1;
            pauseBG.gameObject.SetActive(false);
            stopBg.gameObject.SetActive(false);
            realStopBg.gameObject.SetActive(false);
            isGamePaused = false;
            Main_BGM.Play();
        }
    }

    // 게임 일시정지 처리
    private void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0;
        // 게임 일시정지 UI 활성화
        pauseBG.gameObject.SetActive(true);
        stopBg.gameObject.SetActive(true);
        Main_BGM.Pause();


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
        Main_BGM.Play();
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
        Main_BGM.Play();
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
        Main_BGM.Play();
    }

    // 굿즈 개수 증가 메서드
    public void CountUP()
    {
        score++;
        Scoretxt.text = "Score : " + score.ToString();
        heal_sfx.Play();
        heal_fx.gameObject.SetActive(true);
        hit_fx.gameObject.SetActive(false);
    }

    public void DoubleCountUP()
    {
        score += 2;
        Scoretxt.text = "Score : " + score.ToString();
        heal_sfx.Play();
        heal_fx.gameObject.SetActive(true);
        hit_fx.gameObject.SetActive(false);
    }

    public void CountDown()
    {
        score--;
        Scoretxt.text = score.ToString();
        hit_sfx.Play();
        hit_fx.gameObject.SetActive(true);
        heal_fx.gameObject.SetActive(false);
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
            data_Dialog = CSVReader.Read("PercentageTable_real");
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
    public Text goodsCount;// 몇개 줄 지 설정하는 변수
    
    public void Score() // 이름 바꿔. => 점수에 따라 가챠 수량 설정 하는 부분이라서
    {
        UserScoretxt.text = score.ToString();      // 최종 유저 스코어 텍스트로 출력

        

        //굿즈 지급
        if (score >= 100) // 바꿔
        {
            _count = 3;
            Reward1BG.gameObject.SetActive(true);
            Reward2BG.gameObject.SetActive(true);
            Reward3BG.gameObject.SetActive(true);
            //goodsCount.text = "Goods : " + _count.ToString() +"개 !!";


        }
        else if (score < 100 && score >= 90)
        {
            _count = 2;
            Reward1BG.gameObject.SetActive(true);
            Reward2BG.gameObject.SetActive(true);
            Reward3BG.gameObject.SetActive(false);
            //goodsCount.text = "Goods : " + _count.ToString() + "개 !!";
        }
        else if (score < 90 )
        {
            _count = 1;
            Reward1BG.gameObject.SetActive(true);
            Reward2BG.gameObject.SetActive(false);
            Reward3BG.gameObject.SetActive(false);
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
