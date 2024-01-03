using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor.PackageManager.Requests;

public class RequestManager : MonoBehaviour
{
    // Ŀ�̼� ����Ʈ ������ �� Ÿ�̸� ���� ����
    public GameObject requestPrefab;
    private float requestTimer = 0f;
    public float requestTimeLimit = 2f; // �ϴ� ������ �����ϱ� ���� 2�ʿ� �� ���� ����

    // Ŀ�̼� ����Ʈ ������ �θ� ������Ʈ ����
    public Transform requestParentObject;

    // Ŀ�̼� ����Ʈ �ִ�ġ ����
    private int maxRequestPrefabCount = 5;
    private int requestPrefabCount = 0;


    void Update()
    {
        // Ÿ�̸� ��
        requestTimer += Time.deltaTime;

        // �ش� ���� ���� �� Ŀ�̼� ����Ʈ ����
        if (requestTimer > requestTimeLimit && requestPrefabCount < maxRequestPrefabCount)
        {
            StartCoroutine(NextRequest());
            requestTimer = 0f;
        }
    }

    IEnumerator NextRequest()
    {
        // ���� �ð� �Ŀ� NewRequest �Լ� ȣ��
        yield return new WaitForSeconds(1f);

        NewRequest();
    }

    void NewRequest()
    {
        // Ŀ�̼� ����Ʈ ����
        GameObject newRequest = Instantiate(requestPrefab, requestParentObject);

        // ��ư Ŭ�� �̺�Ʈ �߰�
        Button button = newRequest.GetComponentInChildren<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => OnButtonClick(newRequest));
        }

        // Ŀ�̼� ����Ʈ ������Ʈ �̸� ����
        newRequest.name = "RequestPrefab_" + requestPrefabCount;

        // Ŀ�̼� ����Ʈ ��ġ ����
        RectTransform requestTransform = newRequest.GetComponent<RectTransform>();
        float yOffset = requestTransform.rect.height * requestPrefabCount;
        requestTransform.anchoredPosition = new Vector2(requestTransform.anchoredPosition.x, -yOffset);

        requestPrefabCount++;

        RearrangeRequests();
    }

    void OnButtonClick(GameObject clickedRequest)
    {
        // Ŭ���� Ŀ�̼� ����Ʈ ��Ȱ��ȭ
        clickedRequest.SetActive(false);

        // Ŭ���� Ŀ�̼� ����Ʈ ����
        Destroy(clickedRequest);

        // Ŀ�̼� ����Ʈ ���� �� ������
        RearrangeRequests();

        // ���� Ŀ�̼� ����Ʈ ���� ������ ����
        StartCoroutine(NextRequest());
    }

    void RearrangeRequests()
    {
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
    }
}