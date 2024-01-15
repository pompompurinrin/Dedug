using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.SocialPlatforms.Impl;




public class GameControllerScript : MonoBehaviour
{
    
    // 게임 보드의 열과 행의 수
    public const int columns = 4;
    public const int rows = 5;

    // 이미지를 배치할 부모 객체
    public Transform parent;

    // 이미지 사이의 간격 설정
    public const float Xspace = 260f;
    public const float Yspace = -300f;

    // 게임 시작 이미지 및 사용될 스프라이트 배열
    [SerializeField] private MainImageScript startObject;
    [SerializeField] private Sprite[] images;

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


    public int score = 0;
   // 스코어 초기값


    public AudioSource Main_BGM2;

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

    int test;

    // 리워드 리스트 선언을 여기서 시킴
    public List<Image> RewardsImage = new List<Image>();

    public List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();


    
    private void Start()
    {
        // 게임 시작 시 호출되는 함수
        StartGame();

        Main_BGM2.Play();  // 재생
        correct_sfx.Stop();
        error_sfx.Stop();

        //PercentageTable_1에서 배열을 사용할게
        data_Dialog = CSVReader.Read("PercentageTable_real");

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
            // 이미지 위치를 무작위로 섞음
            int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };

            locations = Randomiser(locations);

            Vector3 startPosition = startObject.transform.position;

            // 게임 보드에 이미지 배치
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    MainImageScript gameImage;
                    if (i == 0 && j == 0)
                    {
                        // 시작 이미지는 따로 처리
                        gameImage = startObject;
                    }
                    else
                    {
                        // 나머지 이미지는 복제하여 사용
                        gameImage = Instantiate(startObject) as MainImageScript;
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
    public void imageOpened(MainImageScript startObject)
    {
        if (firstOpen == null)
        {
            // 첫 번째 이미지 열림
            firstOpen = startObject;
        }
        else
        {
            // 두 번째 이미지 열림 후 일치 여부 확인
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }
    }





    // -------------------------------------------------------------------

  
    public AudioSource correct_sfx;     // 매칭 성공 사운드
    public AudioSource error_sfx;       // 매칭 에러 사운드


    public GameObject correct_fx;    // 매칭 성공 효과
    public GameObject error_fx;      // 매칭 에러 효과


   
    // 이미지 일치 여부를 확인하고 처리하는 코루틴
    private IEnumerator CheckGuessed()
    {
        if (firstOpen.spriteId == secondOpen.spriteId) // 두 이미지의 스프라이트 ID 비교
        {
            
            score++; // 일치하면 점수 증가
            Scoretxt.text= "Score : " + score.ToString() ;
            UserScoretxt.text = "0" + score.ToString() ;
          
            correct_sfx.Play();
           

            Vector3 originalScale = new Vector3(1, 1, 1);
            Vector3 targetScale = new Vector3(1.5f, 1.5f, 1.5f);

            MainImageScript card1 = firstOpen;
            
            card1.transform.DOScale(targetScale, 0.2f).OnComplete(() => // 람다식
            {
                card1.transform.DOScale(originalScale, 0.2f);
                card1.correct_fx.gameObject.SetActive(true);
            });
            
            MainImageScript card2 = secondOpen;
            
            card2.transform.DOScale(targetScale, 0.2f).OnComplete(() => // 람다식
            {
                card2.transform.DOScale(originalScale, 0.2f);
                card2.correct_fx.gameObject.SetActive(true);
                secondOpen = null;  // 변수 초기화 추가
            });

            if (score == 10) 
            {
                Score();
                ResultBG.gameObject.SetActive(true);
                Main_BGM2.Stop();
                
                

                //어떤 컴포넌트에 배정할거임?
                ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
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
    }

    void GetItems(int maxValue) // 뽑기. 랜덤 최대값 받기
    {
        int randValue = UnityEngine.Random.Range(0, maxValue); // 뽑을 애의 해당 가중치량
        int checkUpper = 0; // 가중치 체크용
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

    public int _count = 0;// 몇개 줄 지 설정하는 변수
   public void Score() // 이름 바꿔. => 점수에 따라 가챠 수량 설정 하는 부분이라서
    {
        //Scoretxt.text = score.ToString();

        PauseGame();
        //굿즈 지급
        if (score >= 10) // 바꿔
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
        // PlayerPrefs에 현재 값 저장
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
    // 게임 재시작 함수
    public void RestartClick()
    {
        Debug.Log("Restart");

        SceneManager.LoadScene("HNMiniGameScene");
    }
    // 게임 홈으로 가는 함수
    public void HomeClick()
    {
        SceneManager.LoadScene("HomeScene");
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
            pauseBG.gameObject.SetActive(false);
            stopBg.gameObject.SetActive(false);
            realStopBg.gameObject.SetActive(false);
            isGamePaused = false;
            Main_BGM2.Play();
        }
    }

    // 게임 일시정지 처리
    private void PauseGame()
    {
        isGamePaused = true;
        // 게임 일시정지 UI 활성화
        pauseBG.gameObject.SetActive(true);
        stopBg.gameObject.SetActive(true);
        Main_BGM2.Pause();


    }
   


    // 게임으로 돌아가기 버튼 함수
    public void keepGoingClick()
    {
        // 게임 일시정지 UI 비활성화
        pauseBG.gameObject.SetActive(false);
        stopBg.gameObject.SetActive(false);
        ResumeGame();
    }

    // 굿즈구매로 돌아가기 버튼 함수
    public void goTitleClick()
    {
        // 게임 일시정지 UI 비활성화
        pauseBG.gameObject.SetActive(false);
        stopBg.gameObject.SetActive(false);
        Main_BGM2.Play();

        // 리얼스톱Bg 활성화
        pauseBG.gameObject.SetActive(true);
        realStopBg.gameObject.SetActive(true);
    }

    // 게임으로 돌아가기 버튼 함수
    public void stopNoClick()
    {
        // 리얼스톱Bg 활성화
        pauseBG.gameObject.SetActive(false);
        realStopBg.gameObject.SetActive(false);
        ResumeGame();
    }

    // 홈으로 버튼 함수
    public void stopOkClick()
    {
        pauseBG.gameObject.SetActive(false);
    }


    // 게임 재개 처리
    private void ResumeGame()
    {
        isGamePaused = false;
        Main_BGM2.Play();
    }



}
