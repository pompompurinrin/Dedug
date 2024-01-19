using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.VisualScripting.Dependencies.Sqlite.SQLite3;

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
    public Text goldText;

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
        feverNum = PlayerPrefs.GetInt("FeverNum");
    }

    private void Start()
    {
        Debug.Log("������Ʈ:" + DataManager.Instance.goods1011);
        // �ٸ� ������ ������ �ε�
        DataManager.Instance.nowGold = NowGold;
        DataManager.Instance.nowRank = NowRank;
        DataManager.Instance.feverNum = feverNum;

        // ��ũ ������ ������Ʈ
        rankText.text = DataManager.Instance.nowRank.ToString();

        // charictorImg ������Ʈ�� �ִ� Animator ������Ʈ ��������
        GoldAnimator = GameObject.Find("getGold").GetComponent<Animator>();
        DrawAnimator = GameObject.Find("charictorImg").GetComponent<Animator>();
        goldText.text = DataManager.Instance.nowGold.ToString();

        comitionBGM.Play();
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
                goldValue = Random.Range(15, 45);
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
                goldValue = Random.Range(75, 225);
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
                goldValue = Random.Range(150, 450);
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
                goldValue = Random.Range(300, 600);
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
                goldValue = Random.Range(600, 1200);
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
            rareImage.sprite = Resources.Load<Sprite>("customerType2");
            cosBtn.sprite = Resources.Load<Sprite>("customerType2Btn");

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
        PlayerPrefs.Save();
    }

    // ��ư Ŭ�� ȣ�� �Լ�
    public void OnRequestButtonClick(GameObject clickedButton, int goldValue)
    {
        
        // ��� ȹ�� �ִϸ��̼� ���
        StartCoroutine(PlayGetGoldAnimationAndSwitchToIdle());
        getGoldText.gameObject.SetActive(true);
        Invoke("GetGoldTextfalse", 2f);

        int goldValueType = clickedButton.GetComponent<RequestPrefabScript>().GetgoldValuetype();
        getGoldText.text = goldValueType.ToString();

        // �ִϸ��̼��� ������ �� DrawIdle �ִϸ��̼����� ��ȯ
        StartCoroutine(PlayDAnimationAndSwitchToI());

        // GoldNum ������Ʈ
        DataManager.Instance.nowGold += int.Parse(clickedButton.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text);
        goldText.text = DataManager.Instance.nowGold.ToString();
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
            requestPrefabCount--;

            // �����̵� �ִϸ��̼� ����
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

        // ���� ����
        Destroy(request);
        requestList.Remove(request);

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