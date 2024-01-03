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

    // 최대 커미션 리스트 생성 제항
    private int maxRequestPrefabCount = 5;
    private int requestPrefabCount = 0;

    // 골드 획득 변수
    int goldNum = 0;
    public Text goldText;

    // 피버타임 큰 손 손님 누적 수령 변수
    int feverNum = 0;

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

        // Customer 값에 따라 색상 변경
        int customerType = int.Parse(randomRow["Customer"]);
        Color color = (customerType == 1) ? Color.white : Color.magenta;
        newRequest.GetComponent<Image>().color = color;

        // 버튼 클릭한 프리팹의 "Customer" 값 확인
        int customerTypeFever = int.Parse(randomRow["Customer"]);

        // "Customer" 값이 2인 경우 feverImg 오브젝트 활성화
        if (customerTypeFever == 2)
        {
            feverNum++;
        }

            // 기존 프리팹들의 위치 조정
            for (int i = 0; i < requestParentObject.childCount - 1; i++)
        {
            RectTransform child = requestParentObject.GetChild(i) as RectTransform;
            RectTransform nextChild = requestParentObject.GetChild(i + 1) as RectTransform;

            // 새로운 프리팹의 높이만큼 기존 프리팹을 아래로 이동
            Vector2 newPosition = new Vector2(child.anchoredPosition.x, child.anchoredPosition.y - newRequest.GetComponent<RectTransform>().rect.height);
            child.anchoredPosition = newPosition;
        }

        // 새로운 프리팹을 맨 위로 이동
        newRequest.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        // 버튼 클릭 이벤트 추가
        Button button = newRequest.GetComponentInChildren<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => OnRequestButtonClick(newRequest, int.Parse(randomRow["Gold"])));
        }
    }

    public void OnRequestButtonClick(GameObject clickedButton, int goldValue)
    {
        // GoldNum 업데이트
        goldNum += goldValue;
        goldText.text = goldNum.ToString();

        // 피버 타임 발동 조건
        if (feverNum == 2)
        {
            // feverImg 오브젝트 활성화
            GameObject.Find("nullBg").transform.Find("feverImg").gameObject.SetActive(true);

            // 2초 뒤에 feverBg 오브젝트 활성화
            StartCoroutine(ActivateFeverBgAfterDelay(2f));
        }

        // 버튼 클릭시 해당 프리팹 삭제 및 아래 프리팹들 정렬
        requestPrefabCount--;
        Destroy(clickedButton);

        if (requestPrefabCount == 0)
        {
            GameObject.Find("nullBg").transform.Find("nullSysText").gameObject.SetActive(true);
        }

        // 커미션 리스트 재정렬

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

        // 삭제 후 다시 생성 (현재 시간을 기준으로 다시 생성)
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
        // 2초 뒤에 feverBg 오브젝트를 활성화
        GameObject.Find("feverStart").transform.Find("feverBg").gameObject.SetActive(true);


    }

}