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

    // �ǹ�Ÿ�� ������ ��ư
    public Button endFever;

    // ��� ����� ������Ʈ��
    public Text endText;
    public Text endTitle;
    public Text endGold;
    public Image endImg;

    private float countdownTime = 10f;


    List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    void Start()
    {
        feverButton.onClick.AddListener(OnClickFeverButton);
        UpdateFeverTimeText();
        data_Dialog = CSVReader.Read("FeverCSV");
    }

    void Update()
    {
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
                }

                if (feverGauge >= 11 && feverGauge <= 25)
                {
                    endText.text = data_Dialog[1]["ResultExplain"].ToString();
                    endTitle.text = data_Dialog[1]["ResultGrade"].ToString();
                    endGold.text = data_Dialog[1]["FeverGold"].ToString();

                    SetImageFromResultImg(data_Dialog[1]["ResultImg"].ToString());

                    endBg.SetActive(true);
                }

                if (feverGauge >= 26)
                {
                    endText.text = data_Dialog[2]["ResultExplain"].ToString();
                    endTitle.text = data_Dialog[2]["ResultGrade"].ToString();
                    endGold.text = data_Dialog[2]["FeverGold"].ToString();

                    SetImageFromResultImg(data_Dialog[2]["ResultImg"].ToString());

                    endBg.SetActive(true);
                }
            }
        }
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
            // feverButton Ŭ�� �� feverGauge ���� �� feverSlider �̵�
            feverGauge++;
            feverSlider.value = feverGauge;
        }
    }

    void UpdateFeverTimeText()
    {
        // feverTime �ؽ�Ʈ ������Ʈ
        feverTime.text = Mathf.CeilToInt(countdownTime).ToString();
    }

    public void EndFiver()
    {
        countdownTime = 10;
        feverSlider.value = 0;
        feverGauge = 0;
        endBg.SetActive(false);
    }
}