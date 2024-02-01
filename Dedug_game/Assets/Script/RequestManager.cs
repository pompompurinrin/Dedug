using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RequestManager : MonoBehaviour
{

    // 커미션 프리팹
    public GameObject requestPrefab;
    private float requestTimer = 0f;
    public float requestTimeLimit = 2f;

    // 커미션 프리팹 부모 객체
    public Transform requestParentObject;

    // 최대 커미션 리스트 생성 제항
    private int maxRequestPrefabCount = 5;
    private int requestPrefabCount = 0;

    // 골드 획득 변수
    int NowGold;
    //public Text goldText;

    // 골드 획득 연출 텍스트
    public Text getGoldText;

    // 피버타임
    public static float countdownTime;

    // 피버타임 큰 손 손님 누적 수령 변수
    int feverNum;

    // 커미션 간 간격
    public float requestListSpacing = 1f;

    private List<GameObject> requestList = new List<GameObject>(); // 커미션을 관리할 리스트

    // DrawAnimator 컴포넌트를 저장할 변수
    private Animator DrawAnimator;

    // GoldAnimator 컴포넌트를 저장할 변수
    private Animator GoldAnimator;

    // 커미션 프리팹 슬라이드로 사라지게 하는 변수 할당
    public float slideDuration = 0.5f;
    private bool isDeleting = false;

    public GameObject feverBefore;

    //혜린: 현재 랭크
    int NowRank;

    // 랭크 출력 텍스트
    public Text rankText;

    public GameObject feverStart;
    public GameObject feverBg;

    public AudioSource coin01;
    public AudioSource coin02;

    public AudioSource comitionBGM;
    public AudioSource feverBGM;

    public AudioSource feverBeforeSFX;

    // 피버 이펙트
    public GameObject feverBeforeEffect;

    // 큰 손 손님 이펙트
    public GameObject customer2Prefab; // 클릭 이펙트 프리팹
    public Transform effectSpawnPoint;    // 이펙트 생성 위치
    public Transform customer2ParentObject; // 이펙트 생성 부모 객체

    public Slider FeverSlider;
    private List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();
    private const string RankFileName = "RankTable";
    private char[] TRIM_CHARS = { ' ', '\"' };

    // 애니메이션 트리거, bool의 상태를 나타내는 열거형
    private enum DrawAnimationState
    {
        DrawIdle,
        Drawing,
        getcha,
        nothing
    }

    private DrawAnimationState currentAnimationState = DrawAnimationState.DrawIdle;

    private void Awake()
    {
        // 혜린: 공용 변수 설정 및 데이터 로드
        NowGold = PlayerPrefs.GetInt("NowGold");
        NowRank = PlayerPrefs.GetInt("NowRank");
        DataManager.Instance.firstRequest = PlayerPrefs.GetInt("FirstRequest");
        DataManager. Instance.feverNum = PlayerPrefs.GetInt("FeverNum");
    }

    private void Start()
    {
        data_Dialog = CSVReader.Read(RankFileName);
        Debug.Log("리퀘스트:" + DataManager.Instance.goods1011);
        // 다른 씬에서 데이터 로드
        DataManager.Instance.nowGold = NowGold;
        DataManager.Instance.nowRank = NowRank;
        if (DataManager.Instance.firstRequest == 0)
        {
            TutorialCanvas.gameObject.SetActive(true);

            ClickTutorial();
            TutorialImg.sprite = TutorialImage1;

        }
        else
        {
            TutorialCanvas.gameObject.SetActive(false);
        }
        // 랭크 데이터 업데이트
        // rankText.text = DataManager.Instance.nowRank.ToString();

        // charictorImg 오브젝트에 있는 Animator 컴포넌트 가져오기
        GoldAnimator = GameObject.Find("getGold").GetComponent<Animator>();
        DrawAnimator = GameObject.Find("charictorImg").GetComponent<Animator>();
        //goldText.text = DataManager.Instance.nowGold.ToString();

        comitionBGM.Play();
        
        if(DataManager.Instance.nowRank == 0)
        {
            FeverSlider.maxValue = 10;
        }
        else if (DataManager.Instance.nowRank == 1)
        {
            FeverSlider.maxValue = 15;
        }
        else if (DataManager.Instance.nowRank == 2)
        {
            FeverSlider.maxValue = 20;
        }
        else if (DataManager.Instance.nowRank == 3)
        {
            FeverSlider.maxValue = 23;
        }
        else if (DataManager.Instance.nowRank == 4)
        {
            FeverSlider.maxValue = 25;
        }
    }

    void Update()
    {
        // 2초마다 requestPrefab 생성
        requestTimer += Time.deltaTime;
        if (requestTimer >= requestTimeLimit && requestPrefabCount < maxRequestPrefabCount)
        {
            CreateRequestPrefab();
            requestTimer = 0f;
        }
        
        FeverSlider.value = DataManager.Instance.feverNum;


        if (requestPrefabCount > 0)
        {
            GameObject.Find("nullBg").transform.Find("nullSysText").gameObject.SetActive(false);
        }

        if (requestPrefabCount == 0)
        {
            GameObject.Find("nullBg").transform.Find("nullSysText").gameObject.SetActive(true);
        }


    }
    int TutorialClickNum = 0;
    public Canvas TutorialCanvas;
    public Image TutorialImg;

    public Sprite TutorialImage1;
    public Sprite TutorialImage2;
    public Sprite TutorialImage3;
    public Sprite TutorialImage4;
    public Sprite TutorialImage5;
    public Sprite TutorialImage6;
    public Sprite TutorialImage7;
    public Sprite TutorialImage8;
    public Sprite TutorialImage9;
    public Sprite TutorialImage10;
    public Sprite TutorialImage11;
    public Sprite TutorialImage12;
    public Sprite TutorialImage13;
    public Sprite TutorialImage14;
    public Sprite TutorialImage15;
    public Sprite TutorialImage16;
    public Sprite TutorialImage17;
    public Sprite TutorialImage18;
    public Sprite TutorialImage19;

    public void ClickTutorial()
    {    

        if (TutorialClickNum == 1)
        {
            TutorialImg.sprite = TutorialImage2;
        }
        else if (TutorialClickNum == 2)
        {
            TutorialImg.sprite = TutorialImage3;
        }
        else if (TutorialClickNum == 3)
        {
            TutorialImg.sprite = TutorialImage4;
        }
        else if (TutorialClickNum == 4)
        {
            TutorialImg.sprite = TutorialImage5;
        }
        else if (TutorialClickNum == 5)
        {
            TutorialImg.sprite = TutorialImage6;
        }
        else if (TutorialClickNum == 6)
        {
            TutorialImg.sprite = TutorialImage7;
        }
        else if (TutorialClickNum == 7)
        {
            TutorialImg.sprite = TutorialImage8;
        }
        else if (TutorialClickNum == 8)
        {
            TutorialImg.sprite = TutorialImage9;
        }
        else if (TutorialClickNum == 9)
        {
            TutorialImg.sprite = TutorialImage10;
        }
        else if (TutorialClickNum == 10)
        {
            TutorialImg.sprite = TutorialImage11;
        }
        else if (TutorialClickNum == 11)
        {
            TutorialImg.sprite = TutorialImage12;
        }
        else if (TutorialClickNum == 12)
        {
            TutorialImg.sprite = TutorialImage13;
        }
        else if (TutorialClickNum == 13)
        {
            TutorialImg.sprite = TutorialImage14;
        }
        else if (TutorialClickNum == 14)
        {
            TutorialImg.sprite = TutorialImage15;
        }
        else if (TutorialClickNum == 15)
        {
            TutorialImg.sprite = TutorialImage16;
        }
        else if (TutorialClickNum == 16)
        {
            TutorialImg.sprite = TutorialImage17;
        }
        else if (TutorialClickNum == 17)
        {
            TutorialImg.sprite = TutorialImage18;
        }
        else if (TutorialClickNum == 18)
        {
            TutorialImg.sprite = TutorialImage19;
        }
        else if (TutorialClickNum == 19)
        {
            DataManager.Instance.firstRequest = 1;
            Save();
            TutorialCanvas.gameObject.SetActive(false);
        }
        
        TutorialClickNum++;
    }


    void CreateRequestPrefab()
    {
        // CustomerCSV 파일에서 랜덤한 행 가져오기
        List<Dictionary<string, string>> csvData = RequestCSVReader.Read("CustomerCSV");

        // NowRank에 따라 불러올 수 있는 Grade 값의 범위를 설정
        int minGradeValue = 1;
        int maxGradeValue = NowRank + 1;

        // CSV에서 랜덤한 행 중에서 조건에 맞는 행을 선택
        List<Dictionary<string, string>> filteredData = csvData
            .Where(row => int.TryParse(row["Grade"], out int grade) && grade >= minGradeValue && grade <= maxGradeValue)
            .ToList();

        Dictionary<string, string> randomRow = filteredData[Random.Range(0, filteredData.Count)];

        // requestPrefab 생성
        GameObject newRequest = Instantiate(requestPrefab, requestParentObject);
        requestPrefabCount++;

        if (requestPrefabCount > 0)
        {
            GameObject.Find("nullBg").transform.Find("nullSysText").gameObject.SetActive(false);
        }

        // 이미지, 텍스트 설정 및 goldNum 업데이트
        Image imageComponent = newRequest.transform.Find("cosImg").GetComponent<Image>();
        Text nameText = newRequest.transform.Find("cosName").GetComponent<Text>();
        Text messageText = newRequest.transform.Find("cosText").GetComponent<Text>();
        Image rareImage = newRequest.transform.Find("requestBg").GetComponent<Image>();

        Image cosBtn = newRequest.transform.Find("cosButton").GetComponent<Image>();

        // GoldNum 텍스트 설정
        Text goldButtonText = newRequest.GetComponentInChildren<Button>().GetComponentInChildren<Text>();

        // CSV 파일의 Customer 값에 따라서 랜덤한 Gold 범위를 지정
        int customerTypeGold = int.Parse(randomRow["Customer"]);
        int goldValue = 0;

        if (NowRank == 0)
        {
            if (customerTypeGold == 1) //일반
            {
                goldValue = Random.Range(10, 30);
            }
            else if (customerTypeGold == 2) //큰손
            {
                goldValue = Random.Range(32, 45);
            }
        }

        if (NowRank == 1)
        {
            if (customerTypeGold == 1)
            {
                goldValue = Random.Range(50, 150);
            }
            else if (customerTypeGold == 2)
            {
                goldValue = Random.Range(159, 225);
            }
        }

        if (NowRank == 2)
        {
            if (customerTypeGold == 1)
            {
                goldValue = Random.Range(100, 300);
            }
            else if (customerTypeGold == 2)
            {
                goldValue = Random.Range(318, 450);
            }
        }

        if (NowRank == 3)
        {
            if (customerTypeGold == 1)
            {
                goldValue = Random.Range(200, 400);
            }
            else if (customerTypeGold == 2)
            {
                goldValue = Random.Range(424, 600);
            }
        }

        if (NowRank == 4)
        {
            if (customerTypeGold == 1)
            {
                goldValue = Random.Range(400,800);
            }
            else if (customerTypeGold == 2)
            {
                goldValue = Random.Range(848, 1200);
            }
        }

        goldButtonText.text = goldValue.ToString();

        // 이미지 로드
        string imageFileName = "Customer" + randomRow["Img"];
        imageComponent.sprite = Resources.Load<Sprite>(imageFileName);

        nameText.text = randomRow["Name"];
        messageText.text = randomRow["Message"];

        // 랜덤힌 골드 값을 변수에 저장
        int goldValueType = goldValue;

        // "Customer" 열 값을 변수에 저장
        int customerType = int.Parse(randomRow["Customer"]);

        if(customerType == 2)
        {
            rareImage.sprite = Resources.Load<Sprite>("RequestBackBg2");
            //cosBtn.sprite = Resources.Load<Sprite>("requestBtn");
            nameText.GetComponent<Text>().color = Color.red;
                

        }




    /*        // 고객 값에 따라 색상 변경
            Color color = (customerType == 1) ? Color.white : Color.magenta;
            newRequest.GetComponent<Image>().color = color;*/

    


    // RequestPrefabScript 컴포넌트를 찾고, 없으면 추가
    RequestPrefabScript prefabScript = newRequest.GetComponent<RequestPrefabScript>();
        if (prefabScript == null)
        {
            prefabScript = newRequest.AddComponent<RequestPrefabScript>();
        }

        // 골드 값을 프리팹에 저장
        prefabScript.SetgoldValueType(goldValueType);

        // customerType 값을 프리팹에 저장
        prefabScript.SetCustomerType(customerType);

        // 리스트에 추가
        requestList.Insert(0, newRequest);

        // 커미션 리스트 재정렬
        RearrangeRequest();




        // 버튼 클릭 이벤트 추가
        Button button = newRequest.GetComponentInChildren<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => OnRequestButtonClick(newRequest, goldValue));
        }
    }

    public void Save()
    {
        // 혜린: PlayerPrefs에 현재 값 저장
        PlayerPrefs.SetInt("NowRank", DataManager.Instance.nowRank);
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        PlayerPrefs.SetInt("FeverNum", DataManager.Instance.feverNum);
        PlayerPrefs.SetInt("FirstRequest", DataManager.Instance.firstRequest);
        PlayerPrefs.Save();
    }

    // 버튼 클릭 호출 함수
    public void OnRequestButtonClick(GameObject clickedButton, int goldValue)
    {

        if (Input.touchCount > 1)
            return;

        if (requestPrefabCount == 0)
        {
            GameObject.Find("nullBg").transform.Find("nullSysText").gameObject.SetActive(true);
        }

        // 골드 획득 애니메이션 재생
        StartCoroutine(PlayGetGoldAnimationAndSwitchToIdle());
        getGoldText.gameObject.SetActive(true);
        Invoke("GetGoldTextfalse", 2f);

        int goldValueType = clickedButton.GetComponent<RequestPrefabScript>().GetgoldValuetype();
        getGoldText.text = "+" + goldValueType.ToString();

        // 애니메이션이 끝났을 때 DrawIdle 애니메이션으로 전환
        StartCoroutine(PlayDAnimationAndSwitchToI());

        // GoldNum 업데이트
        DataManager.Instance.nowGold += int.Parse(clickedButton.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text);
        //goldText.text = DataManager.Instance.nowGold.ToString();
        Save();

        // 프리팹에 저장된 customerType 값 가져오기
        int customerType = clickedButton.GetComponent<RequestPrefabScript>().GetCustomerType();


        if (customerType == 1)
        {
            coin01.Play();
        }

        // 피버 타임 발동 조건
        if (customerType == 2)
        {
            DataManager.Instance.feverNum++;
            Debug.Log(DataManager.Instance.feverNum);
            Save();
            coin02.Play();

            // 현재 마우스 좌표를 가져와서 World 좌표로 변환
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Z 축을 0으로 설정 (2D 게임의 경우)

            // 클릭 이펙트를 생성하고 feverParentObject를 부모로 설정
            GameObject clickEffect = Instantiate(customer2Prefab, mousePosition, Quaternion.identity, customer2ParentObject.transform);
            Destroy(clickEffect, 1f); // 1초 후에 이펙트 제거 (원하는 시간으로 조절 가능)

            if ((NowRank == 0 && DataManager.Instance.feverNum == 10) ||
            (NowRank == 1 && DataManager.Instance.feverNum == 15) ||
            (NowRank == 2 && DataManager.Instance.feverNum == 20) ||
            (NowRank == 3 && DataManager.Instance.feverNum == 23) ||
            (NowRank == 4 && DataManager.Instance.feverNum == 25))

            {
                
                // feverImg 오브젝트 활성화
                feverBefore.SetActive(true);
                feverBeforeEffect.SetActive(true);
                feverBeforeSFX.Play();

                // 2초 뒤에 feverBg 오브젝트 활성화
                StartCoroutine(ActivateFeverBgAfterDelay(2f));

                comitionBGM.Stop();

                DataManager.Instance.feverNum = 0;
                Save();
            }

            if (requestPrefabCount > 0)
            {
                GameObject.Find("nullBg").transform.Find("nullSysText").gameObject.SetActive(false);
            }
        }

        // 커미션 삭제 함수 호출
        DeleteRequest(clickedButton);

        if (requestPrefabCount == 0)
        {
            GameObject.Find("nullBg").transform.Find("nullSysText").gameObject.SetActive(true);
        }

        // 삭제 후 다시 생성 (현재 시간을 기준으로 다시 생성)
        if (requestPrefabCount < maxRequestPrefabCount)
        {
            requestTimer = Mathf.Max(requestTimeLimit - requestTimer, 0f);
        }
    }

    void GetGoldTextfalse()
    {
        getGoldText.gameObject.SetActive(false);
    }

    // 골드 획득 시 애니메이션
    private IEnumerator PlayGetGoldAnimationAndSwitchToIdle()
    {
        // getGold 애니메이션을 2초 동안 재생
        GoldAnimator.SetTrigger("getcha");

        yield return new WaitForSeconds(1f);

        GoldAnimator.SetTrigger("nothing");
    }

    // Drawing 애니메이션을 재생하고, 재생이 끝나면 DrawIdle 애니메이션으로 전환
    private IEnumerator PlayDAnimationAndSwitchToI()
    {
        // Drawing 애니메이션을 2초 동안 재생
        DrawAnimator.SetTrigger("Drawing");

        currentAnimationState = DrawAnimationState.Drawing;

        yield return new WaitForSeconds(2f);

        // 재생이 끝나면 DrawIdle 애니메이션으로 전환
        DrawAnimator.SetTrigger("DrawIdle");

        currentAnimationState = DrawAnimationState.DrawIdle;
    }

    // 커미션 삭제 함수
    public void DeleteRequest(GameObject request)
    {
        if (requestList.Contains(request))
        {
            // 슬라이딩 애니메이션 적용
            StartCoroutine(SlideAndDeleteRequest(request));
        }
    }

/*    private IEnumerator SlideAndDeleteRequest(GameObject request)
    {
        isDeleting = true;

        RectTransform rectTransform = request.GetComponent<RectTransform>();
        Vector2 originalPosition = rectTransform.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < slideDuration)
        {
            // 현재 위치에서 왼쪽으로 슬라이드 애니메이션 적용
            float newX = Mathf.Lerp(originalPosition.x, originalPosition.x - Screen.width, elapsedTime / slideDuration);
            rectTransform.anchoredPosition = new Vector2(newX, originalPosition.y); // Y축 기준으로 변하지 않도록 수정

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isDeleting = false;

        // 실제 삭제
        Destroy(request);
        requestList.Remove(request);

        RearrangeRequest();
    }*/

    private IEnumerator SlideAndDeleteRequest(GameObject request)
    {
        if (request == null)
        {
            yield break; // 이미 파괴된 객체에 대해 중단
        }

        isDeleting = true;

        RectTransform rectTransform = request.GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            yield break; // RectTransform이 없는 경우 중단
        }

        Vector2 originalPosition = rectTransform.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < slideDuration)
        {
            if (request == null)
            {
                yield break; // 애니메이션 중간에 객체가 파괴된 경우 중단
            }

            // 현재 위치에서 왼쪽으로 슬라이드 애니메이션 적용
            float newX = Mathf.Lerp(originalPosition.x, originalPosition.x - Screen.width, elapsedTime / slideDuration);
            rectTransform.anchoredPosition = new Vector2(newX, originalPosition.y); // Y축 기준으로 변하지 않도록 수정

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isDeleting = false;

        // 실제 삭제
        Destroy(request);
        requestList.Remove(request);
        requestPrefabCount--;

        RearrangeRequest();
    }

    // 커미션 재정렬 함수
    void RearrangeRequest()
    {
        float yOffset = 0f;

        for (int i = 0; i < requestList.Count; i++)
        {
            RectTransform requestTransform = requestList[i].GetComponent<RectTransform>();
            requestTransform.anchoredPosition = new Vector2(requestTransform.anchoredPosition.x, yOffset);
            yOffset -= requestTransform.rect.height + requestListSpacing;
        }
    }


    private IEnumerator ActivateFeverBgAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        feverBefore.gameObject.SetActive(false);
        feverBeforeEffect.gameObject.SetActive(false);
        // 2초 뒤에 feverBg 오브젝트를 활성화
        feverBGM.Play();
        feverStart.gameObject.SetActive(true);
        feverBg.gameObject.SetActive(true);


    }

    // RequestPrefabScript 클래스를 프리팹에 추가하여 customerType 값을 저장하고 가져올 수 있도록 함
    public class RequestPrefabScript : MonoBehaviour
    {
        private int goldValueType;

        public void SetgoldValueType(int goldValuetype)
        {
            goldValueType = goldValuetype;
        }

        public int GetgoldValuetype()
        {
            return goldValueType;
        }

        private int customerType;

        public void SetCustomerType(int type)
        {
            customerType = type;
        }

        public int GetCustomerType()
        {
            return customerType;
        }
    }

    public void homeRequest()
    {
        Save();
        SceneManager.LoadScene("HomeScene");
    }


}