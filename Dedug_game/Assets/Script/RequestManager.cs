using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RequestManager : MonoBehaviour
{

    // Ŀ�̼� ������
    public GameObject requestPrefab;
    private float requestTimer = 0f;
    public float requestTimeLimit = 2f;

    // Ŀ�̼� ������ �θ� ��ü
    public Transform requestParentObject;

    // �ִ� Ŀ�̼� ����Ʈ ���� ����
    private int maxRequestPrefabCount = 5;
    private int requestPrefabCount = 0;

    // ��� ȹ�� ����
    int NowGold;
    //public Text goldText;

    // ��� ȹ�� ���� �ؽ�Ʈ
    public Text getGoldText;

    // �ǹ�Ÿ��
    public static float countdownTime;

    // �ǹ�Ÿ�� ū �� �մ� ���� ���� ����
    int feverNum;

    // Ŀ�̼� �� ����
    public float requestListSpacing = 1f;

    private List<GameObject> requestList = new List<GameObject>(); // Ŀ�̼��� ������ ����Ʈ

    // DrawAnimator ������Ʈ�� ������ ����
    private Animator DrawAnimator;

    // GoldAnimator ������Ʈ�� ������ ����
    private Animator GoldAnimator;

    // Ŀ�̼� ������ �����̵�� ������� �ϴ� ���� �Ҵ�
    public float slideDuration = 0.5f;
    private bool isDeleting = false;

    public GameObject feverBefore;

    //����: ���� ��ũ
    int NowRank;

    // ��ũ ��� �ؽ�Ʈ
    public Text rankText;

    public GameObject feverStart;
    public GameObject feverBg;

    public AudioSource coin01;
    public AudioSource coin02;

    public AudioSource comitionBGM;
    public AudioSource feverBGM;

    public AudioSource feverBeforeSFX;

    // �ǹ� ����Ʈ
    public GameObject feverBeforeEffect;

    // ū �� �մ� ����Ʈ
    public GameObject customer2Prefab; // Ŭ�� ����Ʈ ������
    public Transform effectSpawnPoint;    // ����Ʈ ���� ��ġ
    public Transform customer2ParentObject; // ����Ʈ ���� �θ� ��ü

    public Slider FeverSlider;
    private List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();
    private const string RankFileName = "RankTable";
    private char[] TRIM_CHARS = { ' ', '\"' };

    // �ִϸ��̼� Ʈ����, bool�� ���¸� ��Ÿ���� ������
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
        // ����: ���� ���� ���� �� ������ �ε�
        NowGold = PlayerPrefs.GetInt("NowGold");
        NowRank = PlayerPrefs.GetInt("NowRank");
        DataManager.Instance.firstRequest = PlayerPrefs.GetInt("FirstRequest");
        DataManager. Instance.feverNum = PlayerPrefs.GetInt("FeverNum");
    }

    private void Start()
    {
        data_Dialog = CSVReader.Read(RankFileName);
        Debug.Log("������Ʈ:" + DataManager.Instance.goods1011);
        // �ٸ� ������ ������ �ε�
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
        // ��ũ ������ ������Ʈ
        // rankText.text = DataManager.Instance.nowRank.ToString();

        // charictorImg ������Ʈ�� �ִ� Animator ������Ʈ ��������
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
        // 2�ʸ��� requestPrefab ����
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
        // CustomerCSV ���Ͽ��� ������ �� ��������
        List<Dictionary<string, string>> csvData = RequestCSVReader.Read("CustomerCSV");

        // NowRank�� ���� �ҷ��� �� �ִ� Grade ���� ������ ����
        int minGradeValue = 1;
        int maxGradeValue = NowRank + 1;

        // CSV���� ������ �� �߿��� ���ǿ� �´� ���� ����
        List<Dictionary<string, string>> filteredData = csvData
            .Where(row => int.TryParse(row["Grade"], out int grade) && grade >= minGradeValue && grade <= maxGradeValue)
            .ToList();

        Dictionary<string, string> randomRow = filteredData[Random.Range(0, filteredData.Count)];

        // requestPrefab ����
        GameObject newRequest = Instantiate(requestPrefab, requestParentObject);
        requestPrefabCount++;

        if (requestPrefabCount > 0)
        {
            GameObject.Find("nullBg").transform.Find("nullSysText").gameObject.SetActive(false);
        }

        // �̹���, �ؽ�Ʈ ���� �� goldNum ������Ʈ
        Image imageComponent = newRequest.transform.Find("cosImg").GetComponent<Image>();
        Text nameText = newRequest.transform.Find("cosName").GetComponent<Text>();
        Text messageText = newRequest.transform.Find("cosText").GetComponent<Text>();
        Image rareImage = newRequest.transform.Find("requestBg").GetComponent<Image>();

        Image cosBtn = newRequest.transform.Find("cosButton").GetComponent<Image>();

        // GoldNum �ؽ�Ʈ ����
        Text goldButtonText = newRequest.GetComponentInChildren<Button>().GetComponentInChildren<Text>();

        // CSV ������ Customer ���� ���� ������ Gold ������ ����
        int customerTypeGold = int.Parse(randomRow["Customer"]);
        int goldValue = 0;

        if (NowRank == 0)
        {
            if (customerTypeGold == 1) //�Ϲ�
            {
                goldValue = Random.Range(10, 30);
            }
            else if (customerTypeGold == 2) //ū��
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

        // �̹��� �ε�
        string imageFileName = "Customer" + randomRow["Img"];
        imageComponent.sprite = Resources.Load<Sprite>(imageFileName);

        nameText.text = randomRow["Name"];
        messageText.text = randomRow["Message"];

        // ������ ��� ���� ������ ����
        int goldValueType = goldValue;

        // "Customer" �� ���� ������ ����
        int customerType = int.Parse(randomRow["Customer"]);

        if(customerType == 2)
        {
            rareImage.sprite = Resources.Load<Sprite>("RequestBackBg2");
            //cosBtn.sprite = Resources.Load<Sprite>("requestBtn");
            nameText.GetComponent<Text>().color = Color.red;
                

        }




    /*        // �� ���� ���� ���� ����
            Color color = (customerType == 1) ? Color.white : Color.magenta;
            newRequest.GetComponent<Image>().color = color;*/

    


    // RequestPrefabScript ������Ʈ�� ã��, ������ �߰�
    RequestPrefabScript prefabScript = newRequest.GetComponent<RequestPrefabScript>();
        if (prefabScript == null)
        {
            prefabScript = newRequest.AddComponent<RequestPrefabScript>();
        }

        // ��� ���� �����տ� ����
        prefabScript.SetgoldValueType(goldValueType);

        // customerType ���� �����տ� ����
        prefabScript.SetCustomerType(customerType);

        // ����Ʈ�� �߰�
        requestList.Insert(0, newRequest);

        // Ŀ�̼� ����Ʈ ������
        RearrangeRequest();




        // ��ư Ŭ�� �̺�Ʈ �߰�
        Button button = newRequest.GetComponentInChildren<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => OnRequestButtonClick(newRequest, goldValue));
        }
    }

    public void Save()
    {
        // ����: PlayerPrefs�� ���� �� ����
        PlayerPrefs.SetInt("NowRank", DataManager.Instance.nowRank);
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        PlayerPrefs.SetInt("FeverNum", DataManager.Instance.feverNum);
        PlayerPrefs.SetInt("FirstRequest", DataManager.Instance.firstRequest);
        PlayerPrefs.Save();
    }

    // ��ư Ŭ�� ȣ�� �Լ�
    public void OnRequestButtonClick(GameObject clickedButton, int goldValue)
    {

        if (Input.touchCount > 1)
            return;

        if (requestPrefabCount == 0)
        {
            GameObject.Find("nullBg").transform.Find("nullSysText").gameObject.SetActive(true);
        }

        // ��� ȹ�� �ִϸ��̼� ���
        StartCoroutine(PlayGetGoldAnimationAndSwitchToIdle());
        getGoldText.gameObject.SetActive(true);
        Invoke("GetGoldTextfalse", 2f);

        int goldValueType = clickedButton.GetComponent<RequestPrefabScript>().GetgoldValuetype();
        getGoldText.text = "+" + goldValueType.ToString();

        // �ִϸ��̼��� ������ �� DrawIdle �ִϸ��̼����� ��ȯ
        StartCoroutine(PlayDAnimationAndSwitchToI());

        // GoldNum ������Ʈ
        DataManager.Instance.nowGold += int.Parse(clickedButton.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text);
        //goldText.text = DataManager.Instance.nowGold.ToString();
        Save();

        // �����տ� ����� customerType �� ��������
        int customerType = clickedButton.GetComponent<RequestPrefabScript>().GetCustomerType();


        if (customerType == 1)
        {
            coin01.Play();
        }

        // �ǹ� Ÿ�� �ߵ� ����
        if (customerType == 2)
        {
            DataManager.Instance.feverNum++;
            Debug.Log(DataManager.Instance.feverNum);
            Save();
            coin02.Play();

            // ���� ���콺 ��ǥ�� �����ͼ� World ��ǥ�� ��ȯ
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Z ���� 0���� ���� (2D ������ ���)

            // Ŭ�� ����Ʈ�� �����ϰ� feverParentObject�� �θ�� ����
            GameObject clickEffect = Instantiate(customer2Prefab, mousePosition, Quaternion.identity, customer2ParentObject.transform);
            Destroy(clickEffect, 1f); // 1�� �Ŀ� ����Ʈ ���� (���ϴ� �ð����� ���� ����)

            if ((NowRank == 0 && DataManager.Instance.feverNum == 10) ||
            (NowRank == 1 && DataManager.Instance.feverNum == 15) ||
            (NowRank == 2 && DataManager.Instance.feverNum == 20) ||
            (NowRank == 3 && DataManager.Instance.feverNum == 23) ||
            (NowRank == 4 && DataManager.Instance.feverNum == 25))

            {
                
                // feverImg ������Ʈ Ȱ��ȭ
                feverBefore.SetActive(true);
                feverBeforeEffect.SetActive(true);
                feverBeforeSFX.Play();

                // 2�� �ڿ� feverBg ������Ʈ Ȱ��ȭ
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

        // Ŀ�̼� ���� �Լ� ȣ��
        DeleteRequest(clickedButton);

        if (requestPrefabCount == 0)
        {
            GameObject.Find("nullBg").transform.Find("nullSysText").gameObject.SetActive(true);
        }

        // ���� �� �ٽ� ���� (���� �ð��� �������� �ٽ� ����)
        if (requestPrefabCount < maxRequestPrefabCount)
        {
            requestTimer = Mathf.Max(requestTimeLimit - requestTimer, 0f);
        }
    }

    void GetGoldTextfalse()
    {
        getGoldText.gameObject.SetActive(false);
    }

    // ��� ȹ�� �� �ִϸ��̼�
    private IEnumerator PlayGetGoldAnimationAndSwitchToIdle()
    {
        // getGold �ִϸ��̼��� 2�� ���� ���
        GoldAnimator.SetTrigger("getcha");

        yield return new WaitForSeconds(1f);

        GoldAnimator.SetTrigger("nothing");
    }

    // Drawing �ִϸ��̼��� ����ϰ�, ����� ������ DrawIdle �ִϸ��̼����� ��ȯ
    private IEnumerator PlayDAnimationAndSwitchToI()
    {
        // Drawing �ִϸ��̼��� 2�� ���� ���
        DrawAnimator.SetTrigger("Drawing");

        currentAnimationState = DrawAnimationState.Drawing;

        yield return new WaitForSeconds(2f);

        // ����� ������ DrawIdle �ִϸ��̼����� ��ȯ
        DrawAnimator.SetTrigger("DrawIdle");

        currentAnimationState = DrawAnimationState.DrawIdle;
    }

    // Ŀ�̼� ���� �Լ�
    public void DeleteRequest(GameObject request)
    {
        if (requestList.Contains(request))
        {
            // �����̵� �ִϸ��̼� ����
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
            // ���� ��ġ���� �������� �����̵� �ִϸ��̼� ����
            float newX = Mathf.Lerp(originalPosition.x, originalPosition.x - Screen.width, elapsedTime / slideDuration);
            rectTransform.anchoredPosition = new Vector2(newX, originalPosition.y); // Y�� �������� ������ �ʵ��� ����

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isDeleting = false;

        // ���� ����
        Destroy(request);
        requestList.Remove(request);

        RearrangeRequest();
    }*/

    private IEnumerator SlideAndDeleteRequest(GameObject request)
    {
        if (request == null)
        {
            yield break; // �̹� �ı��� ��ü�� ���� �ߴ�
        }

        isDeleting = true;

        RectTransform rectTransform = request.GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            yield break; // RectTransform�� ���� ��� �ߴ�
        }

        Vector2 originalPosition = rectTransform.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < slideDuration)
        {
            if (request == null)
            {
                yield break; // �ִϸ��̼� �߰��� ��ü�� �ı��� ��� �ߴ�
            }

            // ���� ��ġ���� �������� �����̵� �ִϸ��̼� ����
            float newX = Mathf.Lerp(originalPosition.x, originalPosition.x - Screen.width, elapsedTime / slideDuration);
            rectTransform.anchoredPosition = new Vector2(newX, originalPosition.y); // Y�� �������� ������ �ʵ��� ����

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isDeleting = false;

        // ���� ����
        Destroy(request);
        requestList.Remove(request);
        requestPrefabCount--;

        RearrangeRequest();
    }

    // Ŀ�̼� ������ �Լ�
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
        // 2�� �ڿ� feverBg ������Ʈ�� Ȱ��ȭ
        feverBGM.Play();
        feverStart.gameObject.SetActive(true);
        feverBg.gameObject.SetActive(true);


    }

    // RequestPrefabScript Ŭ������ �����տ� �߰��Ͽ� customerType ���� �����ϰ� ������ �� �ֵ��� ��
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