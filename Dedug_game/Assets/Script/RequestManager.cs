using System.Collections;
using System.Collections.Generic;
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
    public Text goldText;

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

    //혜린: 현재 랭크
    int NowRank;

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
        feverNum = PlayerPrefs.GetInt("FeverNum");
    }

    private void Start()
    {
        // 다른 씬에서 데이터 로드
        DataManager.Instance.nowGold = NowGold;
        DataManager.Instance.nowRank = NowRank;
        DataManager.Instance.feverNum = feverNum;

        // charictorImg 오브젝트에 있는 Animator 컴포넌트 가져오기
        GoldAnimator = GameObject.Find("getGold").GetComponent<Animator>();
        DrawAnimator = GameObject.Find("charictorImg").GetComponent<Animator>();
        goldText.text = DataManager.Instance.nowGold.ToString();
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
        
    }

    void CreateRequestPrefab()
    {
        // CustomerCSV 파일에서 랜덤한 행 가져오기
        List<Dictionary<string, string>> csvData = RequestCSVReader.Read("CustomerCSV");
        Dictionary<string, string> randomRow = csvData[Random.Range(0, csvData.Count)];

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

        // Gold 텍스트 설정
        Text goldButtonText = newRequest.GetComponentInChildren<Button>().GetComponentInChildren<Text>();
        goldButtonText.text = randomRow["Gold"]; // "Gold" 열의 값을 버튼 텍스트에 설정

        // 이미지 파일 이름 동적으로 생성
        string imageFileName = "Image" + randomRow["Img"];
        imageComponent.sprite = Resources.Load<Sprite>(imageFileName);

        nameText.text = randomRow["Name"];
        messageText.text = randomRow["Message"];



        // "Customer" 열 값을 변수에 저장
        int customerType = int.Parse(randomRow["Customer"]);

        // 고객 값에 따라 색상 변경
        Color color = (customerType == 1) ? Color.white : Color.magenta;
        newRequest.GetComponent<Image>().color = color;

        // RequestPrefabScript 컴포넌트를 찾고, 없으면 추가
        RequestPrefabScript prefabScript = newRequest.GetComponent<RequestPrefabScript>();
        if (prefabScript == null)
        {
            prefabScript = newRequest.AddComponent<RequestPrefabScript>();
        }

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
            button.onClick.AddListener(() => OnRequestButtonClick(newRequest, int.Parse(randomRow["Gold"])));
        }
    }

    public void Save()
    {
        // 혜린: PlayerPrefs에 현재 값 저장
        PlayerPrefs.SetInt("NowRank", DataManager.Instance.nowRank);
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        PlayerPrefs.SetInt("FeverNum", DataManager.Instance.feverNum);
        PlayerPrefs.Save();
    }

    public void OnRequestButtonClick(GameObject clickedButton, int goldValue)
    {

        // 골드 획득 애니메이션 재생
        StartCoroutine(PlayGetGoldAnimationAndSwitchToIdle());

        // 애니메이션이 끝났을 때 DrawIdle 애니메이션으로 전환
        StartCoroutine(PlayDAnimationAndSwitchToI());

        // GoldNum 업데이트
        DataManager.Instance.nowGold += goldValue;
        goldText.text = DataManager.Instance.nowGold.ToString();
        Save();

        // 프리팹에 저장된 customerType 값 가져오기
        int customerType = clickedButton.GetComponent<RequestPrefabScript>().GetCustomerType();



        // 피버 타임 발동 조건
        if (customerType == 2)
        {
            DataManager.Instance.feverNum++;
            Save();

            if (DataManager.Instance.feverNum == 2)
            {
                // feverImg 오브젝트 활성화
                GameObject.Find("nullBg").transform.Find("feverImg").gameObject.SetActive(true);

                // 2초 뒤에 feverBg 오브젝트 활성화
                StartCoroutine(ActivateFeverBgAfterDelay(2f));

                DataManager.Instance.feverNum = 0;
                Save();
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
            requestPrefabCount--;

            // 슬라이딩 애니메이션 적용
            StartCoroutine(SlideAndDeleteRequest(request));
        }
    }

    private IEnumerator SlideAndDeleteRequest(GameObject request)
    {
        isDeleting = true;

        RectTransform rectTransform = request.GetComponent<RectTransform>();
        Vector2 originalPosition = rectTransform.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < slideDuration)
        {
            float newX = Mathf.Lerp(originalPosition.x, -Screen.width, elapsedTime / slideDuration);
            rectTransform.anchoredPosition = new Vector2(newX, 0f);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isDeleting = false;

        // 실제 삭제
        Destroy(request);
        requestList.Remove(request);

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

        GameObject.Find("nullBg").transform.Find("feverImg").gameObject.SetActive(false);
        // 2초 뒤에 feverBg 오브젝트를 활성화
        GameObject.Find("feverStart").transform.Find("feverBg").gameObject.SetActive(true);


    }


    // RequestPrefabScript 클래스를 프리팹에 추가하여 customerType 값을 저장하고 가져올 수 있도록 함
    public class RequestPrefabScript : MonoBehaviour
    {
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