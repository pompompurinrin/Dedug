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

    // 피버타임 끝내는 버튼
    public Button endFever;

    // 결과 출력할 오브젝트들
    public Text endText;
    public Text endTitle;
    public Text endGold;
    public Image endImg;

    private float countdownTime = 10f;

    // 이펙트 관련 변수
    public GameObject feverEffectPrefab; // 클릭 이펙트 프리팹
    public Transform effectSpawnPoint;    // 이펙트 생성 위치
    public Transform feverParentObject; // 이펙트 생성 부모 객체


    // 애니메이션 관련 변수
    public Animator feverAnimator;
    private bool isRunning = false;
    private int clicksInSecond = 0;
    private float clickTimer = 0f;


    List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    void Start()
    {
        // 공용 변수 설정
        NowGold = DataManager.Instance.nowGold;

        feverButton.onClick.AddListener(OnClickFeverButton);
        UpdateFeverTimeText();
        data_Dialog = CSVReader.Read("FeverCSV");
    }

    void Update()
    {

        // 클릭 횟수를 초당 초기화
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

        // 애니메이션 업데이트
        UpdateAnimation();

    }
    public void Save()
    {
        // 혜린: PlayerPrefs에 현재 값 저장
        PlayerPrefs.SetInt("NowRank", DataManager.Instance.nowRank);
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        PlayerPrefs.SetInt("FeverNum", DataManager.Instance.feverNum);
        PlayerPrefs.Save();
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
            // 클릭 이펙트 함수 호출
            CreateClickEffect();
            // feverButton 클릭 시 feverGauge 증가 및 feverSlider 이동
            feverGauge++;
            feverSlider.value = feverGauge;

            // 클릭 횟수 증가
            clicksInSecond++;
        }
    }

    void CreateClickEffect()
    {
        if (feverEffectPrefab != null && feverParentObject != null)
        {
            // 현재 마우스 좌표를 가져와서 World 좌표로 변환
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Z 축을 0으로 설정 (2D 게임의 경우)

            // 클릭 이펙트를 생성하고 feverParentObject를 부모로 설정
            GameObject clickEffect = Instantiate(feverEffectPrefab, mousePosition, Quaternion.identity, feverParentObject.transform);
            Destroy(clickEffect, 1f); // 1초 후에 이펙트 제거 (원하는 시간으로 조절 가능)
        }
    }

    void UpdateFeverTimeText()
    {
        // feverTime 텍스트 업데이트
        feverTime.text = Mathf.CeilToInt(countdownTime).ToString();
    }

    void UpdateAnimation()
    {
        // 클릭 횟수가 2번 이상인 경우 feverRun 애니메이션 재생
        // 그렇지 않으면 feverIdle 애니메이션 재생
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