using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FeverManager : MonoBehaviour
{
    public Button feverButton;
    public Text feverTime;
    public int feverGauge;

    public Slider feverSlider;
    public GameObject feverBg;
    public GameObject endBg;

    int NowGold;

    // �ǹ�Ÿ�� ������ ��ư
    public Button endFever;

    // ��� ����� ������Ʈ��
    public Text endText;
    public Text endTitle;
    public Text endGold;
    public Image endImg;

    private float countdownTime = 10f;

    // ����Ʈ ���� ����
    public GameObject feverEffectPrefab; // Ŭ�� ����Ʈ ������
    public Transform effectSpawnPoint;    // ����Ʈ ���� ��ġ
    public Transform feverParentObject; // ����Ʈ ���� �θ� ��ü


    // �ִϸ��̼� ���� ����
    public Animator feverAnimator;
    private bool isRunning = false;
    private int clicksInSecond = 0;
    private float clickTimer = 0f;


    List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    void Start()
    {
        // ���� ���� ����
        NowGold = DataManager.Instance.nowGold;

        feverButton.onClick.AddListener(OnClickFeverButton);
        UpdateFeverTimeText();
        data_Dialog = CSVReader.Read("FeverCSV");
    }

    void Update()
    {

        // Ŭ�� Ƚ���� �ʴ� �ʱ�ȭ
        clickTimer += Time.deltaTime;
        if (clickTimer >= 1f)
        {
            clicksInSecond = 0;
            clickTimer = 0f;
        }

        if (feverBg.activeSelf && countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            UpdateFeverTimeText();

            if (countdownTime <= 0)
            {
                // ī��Ʈ �ٿ��� 0�� �Ǹ� feverBg�� ��Ȱ��ȭ�ϰ� endBg�� Ȱ��ȭ�Ѵ�.
                feverBg.SetActive(false);

                // feverGauge �˻�
                if (feverGauge >= 1 && feverGauge <= 10)
                {
                    endText.text = data_Dialog[0]["ResultExplain"].ToString();
                    endTitle.text = data_Dialog[0]["ResultGrade"].ToString();
                    endGold.text = data_Dialog[0]["FeverGold"].ToString();

                    SetImageFromResultImg(data_Dialog[0]["ResultImg"].ToString());

                    endBg.SetActive(true);

                    DataManager.Instance.nowGold += 20;
                    Save();

                }

                if (feverGauge >= 11 && feverGauge <= 25)
                {
                    endText.text = data_Dialog[1]["ResultExplain"].ToString();
                    endTitle.text = data_Dialog[1]["ResultGrade"].ToString();
                    endGold.text = data_Dialog[1]["FeverGold"].ToString();

                    SetImageFromResultImg(data_Dialog[1]["ResultImg"].ToString());

                    endBg.SetActive(true);

                    DataManager.Instance.nowGold += 50;
                    Save();
                }

                if (feverGauge >= 26)
                {
                    endText.text = data_Dialog[2]["ResultExplain"].ToString();
                    endTitle.text = data_Dialog[2]["ResultGrade"].ToString();
                    endGold.text = data_Dialog[2]["FeverGold"].ToString();

                    SetImageFromResultImg(data_Dialog[2]["ResultImg"].ToString());

                    endBg.SetActive(true);

                    DataManager.Instance.nowGold += 80;
                    Save();
                }
            }
        }

        // �ִϸ��̼� ������Ʈ
        UpdateAnimation();

    }
    public void Save()
    {
        // ����: PlayerPrefs�� ���� �� ����
        PlayerPrefs.SetInt("NowRank", DataManager.Instance.nowRank);
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        PlayerPrefs.SetInt("FeverNum", DataManager.Instance.feverNum);
        PlayerPrefs.Save();
    }

    void SetImageFromResultImg(string resultImgValue)
    {
        // ����: "FeverImg1" ���� ���� �̹����� ����
        if (resultImgValue == "1")
        {
            endImg.sprite = Resources.Load<Sprite>("FeverImg1");
        }

        else if (resultImgValue == "2")
        {
            endImg.sprite = Resources.Load<Sprite>("FeverImg2");
        }

        else if (resultImgValue == "3")
        {
            endImg.sprite = Resources.Load<Sprite>("FeverImg3");
        }


        // ���� ó��: "ResultImg" ���� ���� �������� ���� ���� ���
        else
        {
            Debug.LogError("Unexpected ResultImg value: " + resultImgValue);
        }
    }


    void OnClickFeverButton()
    {
        if (countdownTime > 0)
        {
            // Ŭ�� ����Ʈ �Լ� ȣ��
            CreateClickEffect();
            // feverButton Ŭ�� �� feverGauge ���� �� feverSlider �̵�
            feverGauge++;
            feverSlider.value = feverGauge;

            // Ŭ�� Ƚ�� ����
            clicksInSecond++;
        }
    }

    void CreateClickEffect()
    {
        if (feverEffectPrefab != null && feverParentObject != null)
        {
            // ���� ���콺 ��ǥ�� �����ͼ� World ��ǥ�� ��ȯ
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Z ���� 0���� ���� (2D ������ ���)

            // Ŭ�� ����Ʈ�� �����ϰ� feverParentObject�� �θ�� ����
            GameObject clickEffect = Instantiate(feverEffectPrefab, mousePosition, Quaternion.identity, feverParentObject.transform);
            Destroy(clickEffect, 1f); // 1�� �Ŀ� ����Ʈ ���� (���ϴ� �ð����� ���� ����)
        }
    }

    void UpdateFeverTimeText()
    {
        // feverTime �ؽ�Ʈ ������Ʈ
        feverTime.text = Mathf.CeilToInt(countdownTime).ToString();
    }

    void UpdateAnimation()
    {
        // Ŭ�� Ƚ���� 2�� �̻��� ��� feverRun �ִϸ��̼� ���
        // �׷��� ������ feverIdle �ִϸ��̼� ���
        isRunning = clicksInSecond >= 2;
        feverAnimator.SetBool("Run", isRunning);
    }

    public void EndFiver()
    {
        countdownTime = 10;
        feverSlider.value = 0;
        feverGauge = 0;
        endBg.SetActive(false);
    }
}