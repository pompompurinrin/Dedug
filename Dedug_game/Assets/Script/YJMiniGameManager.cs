using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YJMiniGameManager : MonoBehaviour
{
    // 미니게임 시작 및 끝 부모 객체
    public GameObject endBg;
    public GameObject startBg;

    // 메시지 출력 이미지 부모 객체
    public GameObject messageBg;
    public GameObject messageBg02;

    // 메시지 타임 출력 텍스트 및 이펙트
    public Image loveEffect;

    // 응원봉 타이밍 판정 이미지
    public Image success;
    public Image fail;

    // 게임 대기시간 카운트
    public Text beforeCount;
    public Image beforeImg;

    // 미니게임 탑 바 관련 변수 (점수, 제한시간)
    public Text costText;
    public Text countDown;

    // 마법소녀 캐릭터 및 관객(주인공) 애니메이션 이미지
    public Image badaChar;
    public Image meChar;
    public Image meChar01;
    public Image meChar02;
    public Image meChar03;
    public Image meChar04;

    // 게임 버튼
    public Button message01;
    public Button message02;
    public Button bong01;
    public Button bong02;
    public Button bong03;

    // 응원봉 타임 안내 이펙트
    public Image colorEffect01;
    public Image colorEffect02;
    public Image colorEffect03;

    // 점수 및 제한시간, 대기시간 변수
    public static int score;
    int gameTime;
    int beforeGameTime;

    // 응원봉 타임!
    private bool isGameRunning = false;
    // private float bongTime = 2.0f;
    private bool isBongTimeActive = false;

    // 하드 응원봉 타임!
    public Image hardStart;
    private float hardBongTimeNext = 3.0f;
    private bool isHardBongTimeActive = false;

    // 하드 응원봉 타임 순서대로 응원봉 출력 및 버튼 대응 저장
    private Queue<Image> activeColorEffects = new Queue<Image>();
    private Queue<Button> expectedBongButtons = new Queue<Button>();

    // 하드 응원봉 타임 동안 클릭 여부를 추적하는 변수
    private bool isHardBongTimeButtonClick = false;

    // 중복 컬러 방지를 위한 리스트 선언
    private List<Image> availableColorEffects = new List<Image>();

    // 게임 일시정지 관련 변수
    public Image stopBg;
    public Button stop;
    public Button keepGoing;
    public Button goTitle;

    public Image PauseBG;

    public Image realStopBg;
    public Button stopOk;
    public Button stopNo;

    // 관중 흔들림
    private float shakeRange = 0.2f;
    private float shakeSpeed = 2f;

    public AudioSource gameAudioSource;  // 게임 중 재생될 사운드

    public AudioSource badamessage01_SFX;

    public AudioSource badasucces_SFX;
    public AudioSource badafail_SFX;

    public AudioSource badacount_SFX;

    public AudioSource bongtime01;
    public AudioSource bongtime02;
    public AudioSource bongtime03;

    public AudioSource Result_SFX;

    // 게임 종료 시
    public GameObject ResultCanvas;
    public static bool badaResult;


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


    // 클릭 타이밍 개선
    public Image bongNomal01;
    public Image bongNomal02;
    public Image bongNomal03;

    public Image hardStartMessage;

    public Image NomalMessage;

    // 클릭 타이밍 일반 응원봉 타임 변수
    public bool nomalStart;

    // 일시정지 수정
    public bool isPuse = false;

    // 타이머 슬라이더 추가
    public Slider timerSlider;

    // 리워드 배경 변수
    public Image reward1BG;
    public Image reward2BG;
    public Image reward3BG;


    // 결과창 추가
    public GameObject RestartPopup;
    public GameObject GoldlackPopup;
    public Text RestartGoldText;

    public bool MessageGo;

    // 응원봉 불빛 안내 문구 추가
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
        // 게임 시작 시 호출되는 함수
        StartGame();

        gameAudioSource.loop = true;  // 반복 재생


        //PercentageTable_1에서 배열을 사용할게
        data_Dialog = CSVReader.Read("PercentageTable");


        //UserScore = GameObject.Find("UserScoretxt").GetComponent<Text>();  //왜안되는거지ㅠㅠ

        // 이건 왜인지 모르겠는데 넣으라고 해서 일단 넣음
        RewardsImage.Add(Reward1);
        RewardsImage.Add(Reward2);
        RewardsImage.Add(Reward3);

        Setting();

    }

    private void StartGame()
    {
        // 게임 대기시간 초기화 및 대기시간 UI 활성화
        beforeGameTime = 3;
        beforeCount.gameObject.SetActive(true);
        beforeImg.gameObject.SetActive(true);

        // 게임 시간, 점수 초기화
        gameTime = 60;
        score = 0;

        isHardBongTimeActive = false;
        nomalStart = false;


        // 게임 UI 업데이트
        UpdateUI();

        // 1초마다 CountDownBeforeGame 메소드 호출
        InvokeRepeating("CountDownBeforeGame", 1.0f, 1.0f);

    }

    // 게임 대기시간 관련
    private void CountDownBeforeGame()
    {

        // 게임 대기시간 카운트 다운
        beforeGameTime--;

        if (beforeGameTime == 0)
        {
            // 게임 대기시간 종료 후 숨김
            beforeCount.gameObject.SetActive(false);
            beforeImg.gameObject.SetActive(false);
            // CountDownBeforeGame 호출 중단
            CancelInvoke("CountDownBeforeGame");

            // 실제 게임 시작
            StartRealTimeGame();
        }
        else
        {
            // 대기시간 텍스트 갱신
            badacount_SFX.Play();
            beforeCount.text = beforeGameTime.ToString();

        }
    }

    // 게임 시작
    private void StartRealTimeGame()
    {
        // 실제 게임 시작
        isGameRunning = true;

        // 초기 제한시간 설정
        countDown.text = gameTime.ToString();

        touch01.gameObject.SetActive(true);
        touch02.gameObject.SetActive(true);

        Invoke("TouchSet", 3f);


        // 1초마다 UpdateGame 메소드 호출
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
        // 0. 제한시간이 종료된 경우
        if (gameTime <= 0 && isGameRunning)
        {
            countDown.text = "0";
            // 게임 종료 처리
            EndGame();
            return;
        }

        if (gameTime > 0 && isGameRunning)
        {
            // 1. 실시간 카운트다운 갱신 및 BGM 재생
            countDown.text = gameTime.ToString();
            gameTime--;
            timerSlider.value = gameTime;
        }

        // 2. bongTime 동안 랜덤한 colorEffect 활성화
        if (gameTime >= 49 && gameTime % 5 == 0)
        {
            // Coroutine을 시작
            StartCoroutine(ActivateNomalColorEffects());
        }

        if (gameTime == 45)
        {
            // Coroutine을 시작
            StartCoroutine(ActivatehardStartMessage());
        }

        // (5) countDown < 60일 경우
        if (gameTime > 27 && gameTime < 49 && gameTime % 7 == 0)
        {
            // 랜덤한 colorEffect를 2가지 이미지를 3초 동안 활성화 후 비활성화
            StartCoroutine(ActivateRandomColorEffects());
        }

        if (gameTime > 0 && gameTime <= 27 && gameTime % 10 == 0)
        {
            StartCoroutine(TooHardRandomColorEffects());
        }

        // 3. 게임 버튼 클릭 처리
        if (Input.GetMouseButtonDown(0))
        {
            HandleButtonClick();
        }

        // 4. 스코어가 0 미만으로 내려가지 않도록 확인
        if (score < 0)
        {
            score = 0;
            costText.text = "Score: " + score.ToString();
        }

        // meChar를 Y 축을 기준으로 왕복하도록 만드는 코드
        if (isGameRunning)
        {
            float yOffset = Mathf.PingPong(Time.time * shakeSpeed, shakeRange * 2) - shakeRange;
            Vector3 newPos = meChar.transform.position;
            newPos.y = yOffset;
            meChar.transform.position = newPos;
        }

        // meChar를 Y 축을 기준으로 왕복하도록 만드는 코드
        if (isGameRunning)
        {
            float yOffset = Mathf.PingPong(Time.time * shakeSpeed, shakeRange * 2) - shakeRange;
            Vector3 newPos = meChar01.transform.position;
            newPos.y = yOffset;
            meChar01.transform.position = newPos;
        }

        // meChar를 Y 축을 기준으로 왕복하도록 만드는 코드
        if (isGameRunning)
        {
            float yOffset = Mathf.PingPong(Time.time * shakeSpeed, shakeRange * 2) - shakeRange;
            Vector3 newPos = meChar02.transform.position;
            newPos.y = yOffset;
            meChar02.transform.position = newPos;
        }

        // meChar를 Y 축을 기준으로 왕복하도록 만드는 코드
        if (isGameRunning)
        {
            float yOffset = Mathf.PingPong(Time.time * shakeSpeed, shakeRange * 2) - shakeRange;
            Vector3 newPos = meChar03.transform.position;
            newPos.y = yOffset;
            meChar03.transform.position = newPos;
        }

        // meChar를 Y 축을 기준으로 왕복하도록 만드는 코드
        if (isGameRunning)
        {
            float yOffset = Mathf.PingPong(Time.time * shakeSpeed, shakeRange * 2) - shakeRange;
            Vector3 newPos = meChar04.transform.position;
            newPos.y = yOffset;
            meChar04.transform.position = newPos;
        }

        // 바다쨩 좌우로 흔들리게 만드는 코드
        if (isGameRunning)
        {
            ShakeObject(badaChar, shakeRange, shakeSpeed);
        }


        // 클릭 타이밍 개선
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
        // 이미지 활성화
        hardStartMessage.gameObject.SetActive(true);

        // 2초 기다림
        yield return new WaitForSeconds(2f);

        // 이미지 비활성화
        hardStartMessage.gameObject.SetActive(false);
    }

    // 바다쨩 흔들 함수
    private void ShakeObject(Image obj, float range, float speed)
    {
        float xOffset = Mathf.PingPong(Time.time * speed, range * 2) - range;
        Vector3 newPos = obj.transform.position;
        newPos.x = xOffset;
        obj.transform.position = newPos;
    }

    // 투 하드 봉타임 진행

    private IEnumerator TooHardRandomColorEffects()
    {
        expectedBongButtons.Clear(); // 기존에 저장된 버튼 초기화

        for (int i = 0; i < 3; i++)
        {
            // 랜덤한 colorEffect를 가져와서 큐에 추가
            Image randomColorEffect = GetRandomColorEffect();
            activeColorEffects.Enqueue(randomColorEffect);

            // 1.5초 동안 활성화
            randomColorEffect.gameObject.SetActive(true);
            
            // 효과음 재생
            PlayColorEffectSound(randomColorEffect);

            yield return new WaitForSeconds(1f);

            // 대응하는 bong 버튼을 tooExpectedBongButtons에 저장
            expectedBongButtons.Enqueue(GetMatchingBongButton(randomColorEffect));

            // 비활성화
            randomColorEffect.gameObject.SetActive(false);
        }

        // (5)번에 설명한 대로 3초 동안만 hardBongTimeNext이 진행됨
        isHardBongTimeActive = true;
        isHardBongTimeButtonClick = true;
        Invoke("DeactivateHardBongTime", hardBongTimeNext);

        yield return new WaitForSeconds(hardBongTimeNext);

        // hardBongTimeNext가 끝날 때 isHardBongTimeActive = false로 하고 동시에 hardStart를 비활성화
        isHardBongTimeActive = false;
        hardStart.gameObject.SetActive(false);

        // hardBongTime이 종료되면 다시 activeColorEffects를 비움
        activeColorEffects.Clear();
    }

    // 하드 봉타임 진행
    private IEnumerator ActivateRandomColorEffects()
    {
        expectedBongButtons.Clear(); // 기존에 저장된 버튼 초기화

        for (int i = 0; i < 2; i++)
        {
            // 랜덤한 colorEffect를 가져와서 큐에 추가
            Image randomColorEffect = GetRandomColorEffect();
            activeColorEffects.Enqueue(randomColorEffect);

            // 1.5초 동안 활성화
            randomColorEffect.gameObject.SetActive(true);

            // 효과음 재생
            PlayColorEffectSound(randomColorEffect);

            yield return new WaitForSeconds(1.5f);

            // 대응하는 bong 버튼을 expectedBongButtons에 저장
            expectedBongButtons.Enqueue(GetMatchingBongButton(randomColorEffect));

            // 비활성화
            randomColorEffect.gameObject.SetActive(false);
        }

        // (5)번에 설명한 대로 3초 동안만 hardBongTimeNext이 진행됨
        isHardBongTimeActive = true;
        isHardBongTimeButtonClick = true;
        Invoke("DeactivateHardBongTime", hardBongTimeNext);

        yield return new WaitForSeconds(hardBongTimeNext);

        // hardBongTimeNext가 끝날 때 isHardBongTimeActive = false로 하고 동시에 hardStart를 비활성화
        isHardBongTimeActive = false;
        hardStart.gameObject.SetActive(false);

        // hardBongTime이 종료되면 다시 activeColorEffects를 비움
        activeColorEffects.Clear();
    }

    // 하드 봉타임 진행
    private IEnumerator ActivateNomalColorEffects()
    {
        expectedBongButtons.Clear(); // 기존에 저장된 버튼 초기화

        for (int i = 0; i < 1; i++)
        {
            // 랜덤한 colorEffect를 가져와서 큐에 추가
            Image randomColorEffect = GetRandomColorEffect();
            activeColorEffects.Enqueue(randomColorEffect);

            // 1.5초 동안 활성화
            randomColorEffect.gameObject.SetActive(true);

            // 효과음 재생
            PlayColorEffectSound(randomColorEffect);

            yield return new WaitForSeconds(1.5f);

            // 대응하는 bong 버튼을 expectedBongButtons에 저장
            expectedBongButtons.Enqueue(GetMatchingBongButton(randomColorEffect));

            // 비활성화
            randomColorEffect.gameObject.SetActive(false);
        }

        // (5)번에 설명한 대로 3초 동안만 hardBongTimeNext이 진행됨
        nomalStart = true;
        isHardBongTimeButtonClick = true;
        Invoke("DeactivateHardBongTime", hardBongTimeNext);

        yield return new WaitForSeconds(hardBongTimeNext);

        // hardBongTimeNext가 끝날 때 isHardBongTimeActive = false로 하고 동시에 hardStart를 비활성화
        nomalStart = false;
        NomalMessage.gameObject.SetActive(false);

        // hardBongTime이 종료되면 다시 activeColorEffects를 비움
        activeColorEffects.Clear();
    }

    // 효과음 재생 메소드
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

    // 하드 봉 타임 이후 처리
    private void DeactivateHardBongTime()
    {
        isHardBongTimeActive = false;
        nomalStart = false;
        // 하드 봉 타임 동안 버튼이 클릭되지 않았을 경우 score를 -1 감소
        if (isHardBongTimeButtonClick == true || nomalStart == true)
        {
            score--;
            if (score < 0)
            {
                score = 0;
                costText.text = "Score: " + score.ToString();
            }
            costText.text = "Score: " + score.ToString();

            // 오답 이미지 활성화
            fail.gameObject.SetActive(true);
            badafail_SFX.Play();
            Invoke("DeactivateFailImage", 2.0f);
        }
        // hardBongTime이 종료되면 다시 activeColorEffects를 비움
        activeColorEffects.Clear();
    }

    // 응원봉과 이펙트 컬러 대응
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

    // 컬러 이펙트 랜덤 뽑기
    private Image GetRandomColorEffect()
    {
        // 랜덤한 colorEffect 반환
        if (availableColorEffects.Count == 0)
        {
            // 사용 가능한 컬러 이펙트가 없으면 모든 컬러 이펙트를 다시 추가
            availableColorEffects.AddRange(new List<Image> { colorEffect01, colorEffect02, colorEffect03 });
        }

        // 랜덤한 컬러 이펙트 반환 및 사용 목록에서 제거
        int randomIndex = UnityEngine.Random.Range(0, availableColorEffects.Count);
        Image randomColorEffect = availableColorEffects[randomIndex];
        availableColorEffects.RemoveAt(randomIndex);

        return randomColorEffect;
    }

    private void DeactivateColorEffect()
    {
        // 모든 colorEffect 비활성화
        colorEffect01.gameObject.SetActive(false);
        colorEffect02.gameObject.SetActive(false);
        colorEffect03.gameObject.SetActive(false);
    }

    // 응원봉 클릭 검사
    public void HandleButtonClick()
    {

        // 하드 응원봉 타임일 때 추가된 부분
        if (isHardBongTimeActive == true)
        {
            // 유저가 버튼을 클릭했을 때 조건 검사
            CheckUserInput();

        }

        if (nomalStart == true)
        {
            // 유저가 버튼을 클릭했을 때 조건 검사
            CheckUserInput();
        }

        // bongTime이 끝났을 때 추가된 부분
        if (isBongTimeActive)
        {
            // bong 버튼이 하나도 클릭되지 않았을 때 처리
            if (expectedBongButtons.Count == 0)
            {
                // 버튼이 클릭되지 않았을 때의 처리
                score--;  // 스코어 감소

                if (score < 0)
                {
                    score = 0;
                    costText.text = "Score: " + score.ToString();
                }

                costText.text = "Score: " + score.ToString();  // UI 업데이트
                isBongTimeActive = false;  // bongTime 동안 클릭 여부 추적 변수 초기화
                DeactivateColorEffect();  // colorEffect 비활성화

                // 오답 이미지 활성화
                fail.gameObject.SetActive(true);
                badafail_SFX.Play();
                Invoke("DeactivateFailImage", 2.0f);
            }
        }

        if (isGameRunning)
        {
            // 게임 종료 체크
            CheckGameEnd();
        }

    }

    // 하드 응원봉 타임 버튼 클릭 함수
    private void CheckUserInput()
    {
        if (expectedBongButtons.Count > 0)
        {
            Button expectedButton = expectedBongButtons.Dequeue(); // 큐에서 버튼을 순서대로 가져옴

            if (EventSystem.current.currentSelectedGameObject == expectedButton.gameObject)
            {
                // 이미 실행 중인 Invoke 중지
                CancelInvoke("DeactivateSuccessImage");

                // 이미지 초기화
                success.gameObject.SetActive(false);
                badasucces_SFX.Stop();

                // 버튼이 올바른 순서로 클릭되었을 때
                score++;
                costText.text = "Score: " + score.ToString();

                // 정답 이미지 활성화
                success.gameObject.SetActive(true);
                badasucces_SFX.Play();
                Invoke("DeactivateSuccessImage", 0.5f);
            }
            else
            {
                // 이미 실행 중인 Invoke 중지
                CancelInvoke("DeactivateFailImage");

                // 이미지 초기화
                fail.gameObject.SetActive(false);
                badafail_SFX.Stop();

                // 버튼이 잘못 클릭되었을 때
                score--;

                if (score < 0)
                {
                    score = 0;
                    costText.text = "Score: " + score.ToString();
                }
                
                costText.text = "Score: " + score.ToString();

                // 오답 이미지 활성화
                fail.gameObject.SetActive(true);
                badafail_SFX.Play();
                Invoke("DeactivateFailImage", 0.5f);
            }

            // UI 업데이트
            UpdateUI();

            // 클릭 여부 변수 초기화
            isHardBongTimeButtonClick = false;
        }
    }

    private void DeactivateSuccessImage()
    {
        // 정답 이미지 비활성화
        success.gameObject.SetActive(false);
    }

    private void DeactivateFailImage()
    {
        // 오답 이미지 비활성화
        fail.gameObject.SetActive(false);
    }

    private void UpdateUI()
    {
        // UI 업데이트 (제한시간, 점수)
        countDown.text = gameTime.ToString();
        timerSlider.value = gameTime;
        costText.text = "Score: " + score.ToString();
    }

    private void CheckGameEnd()
    {
        // 제한시간이 종료되면 게임 종료
        if (gameTime <= 0 && isGameRunning)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        // 게임 종료 시 사운드 중지
        gameAudioSource.Stop();

        isGameRunning = false;

        // 게임 종료 시 호출되는 함수
        // badaResult = true;
        Score();
        Result_SFX.Play();
        ResultCanvas.SetActive(true);

        //어떤 컴포넌트에 배정할거임?
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
            // message01 버튼 클릭 시 호출되는 함수
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
            // message02 버튼 클릭 시 호출되는 함수
            StartCoroutine(DisplayMessage02());
        }
    }

    private IEnumerator DisplayMessage01()
    {
        // 메시지 출력 및 일정 시간 후에 숨김
        messageBg.SetActive(true);
        loveEffect.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        messageBg.SetActive(false);
        loveEffect.gameObject.SetActive(false);
    }


    private IEnumerator DisplayMessage02()
    {
        // 메시지 출력 및 일정 시간 후에 숨김
        messageBg02.SetActive(true);
        loveEffect.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        messageBg02.SetActive(false);
        loveEffect.gameObject.SetActive(false);
    }

    // 게임 일시정지 버튼 클릭 시 호출되는 함수
    public void StopButtonClick()
    {
        if (!isPuse)
        {
            isPuse = true;
            Time.timeScale = 0;

            gameAudioSource.Pause();

            // 게임 일시정지 UI 활성화
            stopBg.gameObject.SetActive(true);
            PauseBG.gameObject.SetActive(true);
        }
    }

    // 게임으로 돌아가기 버튼 함수
    public void keepGoingClick()
    {
        if(isPuse)
        {
            isPuse = false;
            Time.timeScale = 1;
        }

        gameAudioSource.Play();

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

        gameAudioSource.Play();

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
        Scoretxt.text = "0" + score.ToString();

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
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        // PlayerPrefs에 현재 값 저장
        PlayerPrefs.Save();

        Debug.Log("미니게임 결과:" +  DataManager.Instance.goods1011);
       
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

    public void Click_OnDGPopup() //도감 팝업 비활성화
    {
        DGPopup.gameObject.SetActive(true);
    }

    public void Click_OffDGPopup() //도감 팝업 비활성화
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
