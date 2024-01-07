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
    public Text goldText;

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

    //����: ���� ��ũ
    int NowRank;

    // ��ũ ��� �ؽ�Ʈ
    public Text rankText;


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

        // GoldNum �ؽ�Ʈ ����
        Text goldButtonText = newRequest.GetComponentInChildren<Button>().GetComponentInChildren<Text>();

        // CSV ������ Customer ���� ���� ������ Gold ������ ����
        int customerTypeGold = int.Parse(randomRow["Customer"]);
        int goldValue = 0;

        if (NowRank == 0)
        {
            if (customerTypeGold == 1)
            {
                goldValue = Random.Range(10, 21);
            }
            else if (customerTypeGold == 2)
            {
                goldValue = Random.Range(40, 51);
            }
        }

        if (NowRank == 1)
        {
            if (customerTypeGold == 1)
            {
                goldValue = Random.Range(20, 31);
            }
            else if (customerTypeGold == 2)
            {
                goldValue = Random.Range(50, 61);
            }
        }

        if (NowRank == 2)
        {
            if (customerTypeGold == 1)
            {
                goldValue = Random.Range(30, 41);
            }
            else if (customerTypeGold == 2)
            {
                goldValue = Random.Range(60, 71);
            }
        }

        goldButtonText.text = goldValue.ToString();


        // �̹��� ���� �̸� �������� ����
        string imageFileName = "Image" + randomRow["Img"];
        imageComponent.sprite = Resources.Load<Sprite>(imageFileName);

        nameText.text = randomRow["Name"];
        messageText.text = randomRow["Message"];



        // "Customer" �� ���� ������ ����
        int customerType = int.Parse(randomRow["Customer"]);

        // �� ���� ���� ���� ����
        Color color = (customerType == 1) ? Color.white : Color.magenta;
        newRequest.GetComponent<Image>().color = color;

        // RequestPrefabScript ������Ʈ�� ã��, ������ �߰�
        RequestPrefabScript prefabScript = newRequest.GetComponent<RequestPrefabScript>();
        if (prefabScript == null)
        {
            prefabScript = newRequest.AddComponent<RequestPrefabScript>();
        }

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

        // �ִϸ��̼��� ������ �� DrawIdle �ִϸ��̼����� ��ȯ
        StartCoroutine(PlayDAnimationAndSwitchToI());

        // GoldNum ������Ʈ
        DataManager.Instance.nowGold += int.Parse(clickedButton.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text);
        goldText.text = DataManager.Instance.nowGold.ToString();
        Save();

        // �����տ� ����� customerType �� ��������
        int customerType = clickedButton.GetComponent<RequestPrefabScript>().GetCustomerType();



        // �ǹ� Ÿ�� �ߵ� ����
        if (customerType == 2)
        {
            DataManager.Instance.feverNum++;
            Save();

            if ((NowRank == 0 && DataManager.Instance.feverNum == 2) ||
            (NowRank == 1 && DataManager.Instance.feverNum == 4) ||
            (NowRank == 2 && DataManager.Instance.feverNum == 6))

            {
                // feverImg ������Ʈ Ȱ��ȭ
                GameObject.Find("nullBg").transform.Find("feverImg").gameObject.SetActive(true);

                // 2�� �ڿ� feverBg ������Ʈ Ȱ��ȭ
                StartCoroutine(ActivateFeverBgAfterDelay(2f));

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

        GameObject.Find("nullBg").transform.Find("feverImg").gameObject.SetActive(false);
        // 2�� �ڿ� feverBg ������Ʈ�� Ȱ��ȭ
        GameObject.Find("feverStart").transform.Find("feverBg").gameObject.SetActive(true);


    }


    // RequestPrefabScript Ŭ������ �����տ� �߰��Ͽ� customerType ���� �����ϰ� ������ �� �ֵ��� ��
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