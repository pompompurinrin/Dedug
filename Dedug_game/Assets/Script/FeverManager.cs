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

    // 피버타임 끝내는 버튼
    public Button endFever;

    // 결과 출력할 오브젝트들
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
                // 카운트 다운이 0이 되면 feverBg를 비활성화하고 endBg를 활성화한다.
                feverBg.SetActive(false);

                // feverGauge 검사
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
        // 예시: "FeverImg1" 값에 따라 이미지를 설정
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


        // 예외 처리: "ResultImg" 열의 값이 예상하지 못한 값인 경우
        else
        {
            Debug.LogError("Unexpected ResultImg value: " + resultImgValue);
        }
    }


    void OnClickFeverButton()
    {
        if (countdownTime > 0)
        {
            // feverButton 클릭 시 feverGauge 증가 및 feverSlider 이동
            feverGauge++;
            feverSlider.value = feverGauge;
        }
    }

    void UpdateFeverTimeText()
    {
        // feverTime 텍스트 업데이트
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