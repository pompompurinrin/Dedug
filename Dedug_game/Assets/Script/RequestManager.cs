using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor.PackageManager.Requests;
using System.Linq;

public class RequestManager : MonoBehaviour
{

    public GameObject requestPrefab;
    private float requestTimer = 0f;
    public float requestTimeLimit = 2f;

    public Transform requestParentObject;

    // �ִ� Ŀ�̼� ����Ʈ ���� ����
    private int maxRequestPrefabCount = 5;
    private int requestPrefabCount = 0;

    // ��� ȹ�� ����
    int goldNum = 0;
    public Text goldText;

    // �ǹ�Ÿ�� ū �� �մ� ���� ���� ����
    int feverNum = 0;

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
        Dictionary<string, string> randomRow = csvData[Random.Range(0, csvData.Count)];

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

        // Gold �ؽ�Ʈ ����
        Text goldButtonText = newRequest.GetComponentInChildren<Button>().GetComponentInChildren<Text>();
        goldButtonText.text = randomRow["Gold"]; // "Gold" ���� ���� ��ư �ؽ�Ʈ�� ����




        // �̹��� ���� �̸� �������� ����
        string imageFileName = "Image" + randomRow["Img"];
        imageComponent.sprite = Resources.Load<Sprite>(imageFileName);

        nameText.text = randomRow["Name"];
        messageText.text = randomRow["Message"];

        // Customer ���� ���� ���� ����
        int customerType = int.Parse(randomRow["Customer"]);
        Color color = (customerType == 1) ? Color.white : Color.magenta;
        newRequest.GetComponent<Image>().color = color;

        // ��ư Ŭ���� �������� "Customer" �� Ȯ��
        int customerTypeFever = int.Parse(randomRow["Customer"]);

        // "Customer" ���� 2�� ��� feverImg ������Ʈ Ȱ��ȭ
        if (customerTypeFever == 2)
        {
            feverNum++;
        }

            // ���� �����յ��� ��ġ ����
            for (int i = 0; i < requestParentObject.childCount - 1; i++)
        {
            RectTransform child = requestParentObject.GetChild(i) as RectTransform;
            RectTransform nextChild = requestParentObject.GetChild(i + 1) as RectTransform;

            // ���ο� �������� ���̸�ŭ ���� �������� �Ʒ��� �̵�
            Vector2 newPosition = new Vector2(child.anchoredPosition.x, child.anchoredPosition.y - newRequest.GetComponent<RectTransform>().rect.height);
            child.anchoredPosition = newPosition;
        }

        // ���ο� �������� �� ���� �̵�
        newRequest.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        // ��ư Ŭ�� �̺�Ʈ �߰�
        Button button = newRequest.GetComponentInChildren<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => OnRequestButtonClick(newRequest, int.Parse(randomRow["Gold"])));
        }
    }

    public void OnRequestButtonClick(GameObject clickedButton, int goldValue)
    {
        // GoldNum ������Ʈ
        goldNum += goldValue;
        goldText.text = goldNum.ToString();

        // �ǹ� Ÿ�� �ߵ� ����
        if (feverNum == 2)
        {
            // feverImg ������Ʈ Ȱ��ȭ
            GameObject.Find("nullBg").transform.Find("feverImg").gameObject.SetActive(true);

            // 2�� �ڿ� feverBg ������Ʈ Ȱ��ȭ
            StartCoroutine(ActivateFeverBgAfterDelay(2f));
        }

        // ��ư Ŭ���� �ش� ������ ���� �� �Ʒ� �����յ� ����
        requestPrefabCount--;
        Destroy(clickedButton);

        if (requestPrefabCount == 0)
        {
            GameObject.Find("nullBg").transform.Find("nullSysText").gameObject.SetActive(true);
        }

        // Ŀ�̼� ����Ʈ ������

        float yOffset = 0f;

        foreach (Transform child in requestParentObject)
        {
            if (child.gameObject.activeSelf)
            {
                RectTransform requestTransform = child.GetComponent<RectTransform>();
                requestTransform.anchoredPosition = new Vector2(requestTransform.anchoredPosition.x, -yOffset);
                yOffset += requestTransform.rect.height;
            }
        }

        // ���� �� �ٽ� ���� (���� �ð��� �������� �ٽ� ����)
        if (requestPrefabCount < maxRequestPrefabCount)
        {
            requestTimer = Mathf.Max(requestTimeLimit - requestTimer, 0f);
        }
    }
    private IEnumerator ActivateFeverBgAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        feverNum = 0;
        GameObject.Find("nullBg").transform.Find("feverImg").gameObject.SetActive(false);
        // 2�� �ڿ� feverBg ������Ʈ�� Ȱ��ȭ
        GameObject.Find("feverStart").transform.Find("feverBg").gameObject.SetActive(true);


    }

}