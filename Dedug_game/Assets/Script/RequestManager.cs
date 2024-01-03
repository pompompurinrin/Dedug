using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor.PackageManager.Requests;

public class RequestManager : MonoBehaviour
{
    // 커미션 리스트 프리팹 및 타이머 변수 설정
    public GameObject requestPrefab;
    private float requestTimer = 0f;
    public float requestTimeLimit = 2f; // 일단 빠르게 실험하기 위해 2초에 한 번씩 생성

    // 커미션 리스트 프리팹 부모 오브젝트 설정
    public Transform requestParentObject;

    // 커미션 리스트 최대치 설정
    private int maxRequestPrefabCount = 5;
    private int requestPrefabCount = 0;


    void Update()
    {
        // 타이머 업
        requestTimer += Time.deltaTime;

        // 해당 조건 충족 시 커미션 리스트 생성
        if (requestTimer > requestTimeLimit && requestPrefabCount < maxRequestPrefabCount)
        {
            StartCoroutine(NextRequest());
            requestTimer = 0f;
        }
    }

    IEnumerator NextRequest()
    {
        // 일정 시간 후에 NewRequest 함수 호출
        yield return new WaitForSeconds(1f);

        NewRequest();
    }

    void NewRequest()
    {
        // 커미션 리스트 생성
        GameObject newRequest = Instantiate(requestPrefab, requestParentObject);

        // 버튼 클릭 이벤트 추가
        Button button = newRequest.GetComponentInChildren<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => OnButtonClick(newRequest));
        }

        // 커미션 리스트 오브젝트 이름 설정
        newRequest.name = "RequestPrefab_" + requestPrefabCount;

        // 커미션 리스트 위치 조절
        RectTransform requestTransform = newRequest.GetComponent<RectTransform>();
        float yOffset = requestTransform.rect.height * requestPrefabCount;
        requestTransform.anchoredPosition = new Vector2(requestTransform.anchoredPosition.x, -yOffset);

        requestPrefabCount++;

        RearrangeRequests();
    }

    void OnButtonClick(GameObject clickedRequest)
    {
        // 클릭된 커미션 리스트 비활성화
        clickedRequest.SetActive(false);

        // 클릭된 커미션 리스트 삭제
        Destroy(clickedRequest);

        // 커미션 리스트 삭제 후 재정렬
        RearrangeRequests();

        // 다음 커미션 리스트 생성 딜레이 시작
        StartCoroutine(NextRequest());
    }

    void RearrangeRequests()
    {
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
    }
}