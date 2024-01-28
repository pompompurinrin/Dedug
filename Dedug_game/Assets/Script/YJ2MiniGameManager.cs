using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class YJ2MiniGameManager : MonoBehaviour
{
    // 배경 및 수아 이미지
    public Image suaChar;
    public Image gameBg;

    // 사건 이미지
    public GameObject eventMon;
    public GameObject eventHeal;
    public GameObject eventFan;

    // 사건 마법 이미지
    public GameObject eventIconMon;
    public GameObject eventIconHeal;
    public GameObject eventIconFan;

    // 사건 배경 이미지
    public GameObject MonBg;
    public GameObject HealBg;
    public GameObject FanBg;

    public GameObject[] eventIcons; // 이벤트 아이콘들을 배열로 관리
    public GameObject[] eventImage; // 이벤트 오브젝트들을 배열로 관리
    public GameObject[] eventBg; // 이벤트 배경들을 배열로 관리


    // 마법머신 아이콘 이미지
    public Image slotIcon01;
    public Image slotIcon02;
    public Image slotIcon03;
    public Sprite[] slotSprites; // slotIconMon, slotIconHeal, slotIconFan 스프라이트들을 배열로 관리

    // 마법머신 슬롯 애니메이션
    public Image slotAnimation01;
    public Image slotAnimation02;
    public Image slotAnimation03;

    // 스코어 판정 이미지
    public Image fail;
    public Image Success;

    // 게임 대기시간 카운트
    public Text beforeCountText;
    public Image beforeImg;

    // 타이머 및 점수
    int beforeCount;
    int score;
    int timer;
    int slotTimer;
    int eventTimer;

    public Text scoreText;
    public Text timerText;

    // 타이머 슬라이더
    public Slider eventTimeSlider;
    public Slider slotTimeSlider;

    // 마법머신 버튼
    public Button slotButton;

    // 조건 선언
    bool slotStart = false;    // 슬롯 스타트
    bool eventStart = false;    // 이벤트 스타트

    // 게임 실행 조건
    bool isGameRunning;

    // 이벤트 타이머 조건
    bool isEventActive = false;

    // 득실점 판정 연출
    public GameObject monScore;
    public GameObject healScore;
    public GameObject fanScore;

    // 슬롯 딜레이
    public GameObject slotStop;

    // 확률 추가
    bool mon;
    bool heal;
    bool fan;

    // 실패 연출
    public GameObject slotFail01;
    public GameObject slotFail02;
    public GameObject slotFail03;


    // 오디오 추가
    public AudioSource sua_BGM;
    public AudioSource sloting_SFX; // 슬롯 돌아갈때
    public AudioSource slotResultFail_SFX;
    public AudioSource slotResulySuccess_SFX;
    public AudioSource slotStart_SFX;
    public AudioSource eventChange_SFX;
    public AudioSource fail_SFX;
    public AudioSource count_SFX;
    public AudioSource Result_SFX;

    // 게임 종료 애니메이션
    public Image fin;


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

    // 결과창 아이템 배경
    public Image reward1BG;
    public Image reward2BG;
    public Image reward3BG;

    // 일시정지 배경
    public Image PauseBG;

    // 일시정지 슬라이더
    public Slider timerSlider;

    // 결과창 추가
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
        //PercentageTable_1에서 배열을 사용할게
        data_Dialog = CSVReader.Read("PercentageTable");

        // 게임 시작 시 호출되는 함수
        StartGame();

        // 이건 왜인지 모르겠는데 넣으라고 해서 일단 넣음
        RewardsImage.Add(Reward1);
        RewardsImage.Add(Reward2);
        RewardsImage.Add(Reward3);

        Setting();

    }

    public void StartGame()
    {
        // 게임 대기시간 초기화 및 대기시간 UI 활성화
        beforeCount = 3;
        beforeCountText.gameObject.SetActive(true);
        beforeImg.gameObject.SetActive(true);

        // 게임 시간, 점수 초기화
        timer = 60;
        score = 0;

        // 게임 UI 업데이트
        UpdateUI();

        // 1초마다 CountDownBeforeGame 메소드 호출
        InvokeRepeating("CountDownBeforeGame", 1.0f, 1.0f);
    }

    private void UpdateUI()
    {
        // UI 업데이트 (제한시간, 점수)
        timerText.text = timer.ToString();
        timerSlider.value = timer;
        scoreText.text = "Score: " + score.ToString();
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
        }
        else
        {
            count_SFX.Play();
            // 대기시간 텍스트 갱신
            beforeCountText.text = beforeCount.ToString();

        }
    }

    public void StartRealTimeGame()
    {



        // 실제 게임 시작
        isGameRunning = true;

        // 배경음악 재생 시작
        sua_BGM.Play();

        // 이벤트 타임 시작
        eventStart = true;

        // 초기 제한시간 설정
        timerText.text = timer.ToString();

        // 1초마다 UpdateGame 메소드 호출
        InvokeRepeating("UpdateGame", 1.0f, 1.0f);

        // 게임 시작 시 랜덤으로 이벤트 선택
        ActivateRandomEvent();
    }


    public void UpdateGame()
    {
        if (isGameRunning)
        {
            // 타이머 감소
            timer--;
            timerSlider.value = timer;

            if (eventStart == true)
            {
                // 이벤트 타이머 슬라이더 업데이트
                UpdateEventSlider();

                // 이벤트 타이머 감소
                eventTimer--;
            }

            // UI 업데이트
            UpdateUI();

            // 타이머가 0이면 게임 종료
            if (timer == 0)
            {
                EndGame();
            }

            // 스코어가 8이면 게임 종료
            if (score >= 8)
            {
                EndGame();
            }

            if (timer < 0)
            {
                timer = 0;
            }

            // 수아 흔들리는 애니메이션
            ShakeSuaCharacter();
        }
    }

    private void ShakeSuaCharacter()
    {
        // 수아 캐릭터를 x축을 기준으로 좌우로 흔들리는 애니메이션
        suaChar.rectTransform.DOPunchPosition(new Vector3(20f, 0f, 0f), 0.5f, 5, 1f);
    }

    public void UpdateEventSlider()
    {
        // 이벤트 활성화 상태에서만 업데이트
        if (isEventActive)
        {
            // 이벤트 타이머 슬라이더 업데이트
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
        // 이전에 활성화되어 있던 이벤트 비활성화
        DeactivateAllEvents();

        // 오디오 재생
        eventChange_SFX.Play();

        // 랜덤으로 이벤트 아이콘과 이벤트 활성화
        int randomIndex = UnityEngine.Random.Range(0, eventIcons.Length);

        eventIcons = new GameObject[] { eventIconMon, eventIconHeal, eventIconFan };
        eventImage = new GameObject[] { eventMon, eventHeal, eventFan };
        eventBg = new GameObject[] { MonBg, HealBg, FanBg };

        // 슬라이드 애니메이션으로 활성화
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

        // 이벤트 활성화 상태로 변경
        isEventActive = true;

        // eventTimer를 10으로 초기화
        eventTimer = 10;
    }

    private void DeactivateAllEvents()
    {
        mon = false;
        heal = false;
        fan = false;

        // 모든 이벤트 아이콘과 이벤트 비활성화
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

        // 이벤트 비활성화 상태로 변경
        isEventActive = false;
    }

    public void EventChange()
    {
        // 이벤트 변경 시 다시 랜덤으로 이벤트 선택
        ActivateRandomEvent();
    }

    public void SlotButtonClicked()
    {
        // 처음 클릭했을 때만 slotTimer를 8초로 설정
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

        // slotButton 클릭 시 실행되는 메소드
        slotStart = true;

        // 1초마다 SlotTimerCountdown 메소드 호출
        InvokeRepeating("SlotTimerCountdown", 1.0f, 1.0f);
    }


    private void SlotTimerCountdown()
    {
        // slotTimer 감소
        slotTimer--;
        slotTimeSlider.value = slotTimer;

        if (slotTimer < 0)
        {
            slotTimer = 0;
        }

        // slotTimer가 0이면 호출 중단하고 이미지 출력
        if (slotTimer == 0)
        {

            slotAnimation01.gameObject.SetActive(false);
            slotAnimation02.gameObject.SetActive(false);
            slotAnimation03.gameObject.SetActive(false);

            // 호출 중단
            CancelInvoke("SlotTimerCountdown");

            // slotStart를 false로 설정하여 더 이상 카운트다운을 하지 않도록 함
            slotStart = false;

            slotStop.gameObject.SetActive(true);

            // 랜덤으로 이미지 출력
            ActivateRandomSlotIcons();

            // 슬롯 아이콘과 이벤트 아이콘 비교하여 스코어 처리
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

    // 슬롯 아이콘 이미지를 확률에 따라 설정하는 메소드
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


    // 스코어 처리
    private void CompareIconsAndScore()
    {
        int eventIconIndex = GetActiveEventIconIndex();

        // 이벤트 아이콘과 슬롯 아이콘 비교
        if (eventIconIndex != -1)
        {
            int matchingCount = CountMatchingIcons(eventIconIndex);

            if (matchingCount >= 0 && matchingCount < 2)
            {

                slotResultFail_SFX.Play();

                // 일치하는 아이콘 종류 확인
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

                // 일치하면 스코어 증가
                score++;
                UpdateUI();

                slotResulySuccess_SFX.Play();

                // 일치하는 아이콘 종류 확인
                Sprite eventSprite = eventIcons[eventIconIndex].GetComponent<Image>().sprite;

                Vector3 originalScale = new Vector3(1, 1, 1);
                Vector3 targetScale = new Vector3(1.5f, 1.5f, 1.5f);

                eventIcons[eventIconIndex].transform.DOScale(targetScale, 0.2f).OnComplete(() => // 람다식
                {
                    eventIcons[eventIconIndex].transform.DOScale(originalScale, 0.2f);
                });

                // 일치하는 슬롯 아이콘 연출
                if (slotIcon01.sprite == eventSprite)
                {
                    slotIcon01.transform.DOScale(targetScale, 0.2f).OnComplete(() => // 람다식
                    {
                        slotIcon01.transform.DOScale(originalScale, 0.2f);
                    });
                }

                if (slotIcon02.sprite == eventSprite)
                {
                    slotIcon02.transform.DOScale(targetScale, 0.2f).OnComplete(() => // 람다식
                    {
                        slotIcon02.transform.DOScale(originalScale, 0.2f);
                    });
                }

                if(slotIcon03.sprite == eventSprite)
                {
                    slotIcon03.transform.DOScale(targetScale, 0.2f).OnComplete(() => // 람다식
                    {
                        slotIcon03.transform.DOScale(originalScale, 0.2f);
                    });
                }

                // 일치하는 아이콘에 따라 동작 수행
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

    // 성공 문구 끄기
    public void SuccessSet()
    {
        Success.gameObject.SetActive(false);
    }

    // 실패 연출 끄기
    public void FailSet()
    {
        slotFail01.gameObject.SetActive(false);
        slotFail02.gameObject.SetActive(false);
        slotFail03.gameObject.SetActive(false);
    }

    // 슬롯 아이콘 끄기
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

    // 코루틴을 이용하여 일정 시간 동안 GameObject를 활성화 후 비활성화
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

        // 슬롯 아이콘들과 비교하여 일치하는 개수 세기
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
        // 오답 이미지 비활성화
        fail.gameObject.SetActive(false);
    }

    private void EndGame()
    {
        // 게임 종료 처리

        // 중복 호출 방지
        if (!isGameRunning)
        {
            return;
        }

        isGameRunning = false;

        sua_BGM.Stop();
        Score();
        Result_SFX.Play();
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

        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        PlayerPrefs.Save();

        Debug.Log("미니게임 결과:" + DataManager.Instance.goods1011);




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


    public void RequestClick()
    {
        SceneManager.LoadScene("RequestScene");
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

            sua_BGM.Pause();

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

        sua_BGM.Play();

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

        sua_BGM.Play();

        // 리얼스톱Bg 활성화
        realStopBg.gameObject.SetActive(false);
        PauseBG.gameObject.SetActive(false);
    }

    // 도감으로 돌아가기 처리
    public void RealStopClick()
    {

        isPuse = false;
        Time.timeScale = 1;

        SceneManager.LoadScene("HomeScene");
    }

}
