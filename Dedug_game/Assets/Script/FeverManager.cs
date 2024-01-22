using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FeverManager : MonoBehaviour
{
    public GameObject feverStart;
    public Button feverButton;
    public Text feverTime;
    public int feverGauge;

    public Slider feverSlider;
    public GameObject feverBg;
    public GameObject endBg;

    public Text goldText;

    // 터치 횟수 텍스트
    public Text feverComboText;
    // 터치 횟수 카운트
    private int clickCount = 0;

    int NowGold;

    // 피버타임 끝내는 버튼
    public Button endFever;

    // 결과 출력할 오브젝트들
    public Text endText;
    public Text endTitle;
    public Text endGold;
    public Image endImg;

    float countdownTime;

    // 현재 랭크
    int NowRank;

    // 이펙트 관련 변수
    public GameObject feverEffectPrefab; // 클릭 이펙트 프리팹
    public Transform effectSpawnPoint;    // 이펙트 생성 위치
    public Transform feverParentObject; // 이펙트 생성 부모 객체


    // 애니메이션 관련 변수
    public Animator feverAnimator;
    private bool isRunning = false;
    private int clicksInSecond = 0;
    private float clickTimer = 0f;

    // 엔드 화면 파티클
    public GameObject basic;

    public AudioSource EndSFX01;
    public AudioSource EndSFX02;
    public AudioSource EndSFX03;

    public AudioSource comitionBGM;

    public AudioSource feverBGM;

    public AudioSource feverClickSFX;

    // 랭크 별 클릭 밸류
    public bool nowRank00;
    public bool nowRank01;
    public bool nowRank02;
    public bool nowRank03;
    public bool nowRank04;


    List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    private void Awake()
    {
        // 혜린: 공용 변수 설정 및 데이터 로드
        NowGold = PlayerPrefs.GetInt("NowGold");
        NowRank = PlayerPrefs.GetInt("NowRank");
    }

    public void Start()
    {
        // 공용 변수 설정
        DataManager.Instance.nowGold = NowGold;
        DataManager.Instance.nowRank = NowRank;
        UpdatefeverComboText();
    }
    public void OnButtonClick()
    {
        //버튼 클릭시 카운트 증가
        clickCount++;
        UpdatefeverComboText();
    }

    void UpdatefeverComboText()
    {
        //텍스트 업데이트
        feverComboText.text = "Combo\n" + clickCount.ToString();
        
    }


    public void OnEnable()
    {
        feverButton.onClick.RemoveAllListeners();  // 기존 이벤트 제거
        feverButton.onClick.AddListener(OnClickFeverButton);
        UpdateFeverTimeText();
        data_Dialog = CSVReader.Read("FeverCSV");

        nowRank00 = false;
        nowRank01 = false;
        nowRank02 = false;
        nowRank03 = false;
        nowRank04 = false;

        countdownTime = 5f;
        feverSlider.value = 0;
        feverGauge = 0;

        if (NowRank == 0)
        {
            nowRank00 = true;
        }

        if (NowRank == 1)
        {
            nowRank01 = true;
        }

        if (NowRank == 2)
        {
            nowRank02 = true;
        }

        if (NowRank == 3)
        {
            nowRank03 = true;
        }

        if (NowRank == 4)
        {
            nowRank04 = true;
        }
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

            // 애니메이션 업데이트
            UpdateAnimation();

            if (countdownTime <= 0 || feverGauge >= 50)
            {
                
                // 카운트 다운이 0이 되면 feverBg를 비활성화하고 endBg를 활성화한다.
                feverBg.SetActive(false);

                // feverGauge 검사
                if (feverGauge >= 0)
                {
                    feverBGM.Stop();

                    ResultFever01();
                
                        
                }

                if (feverGauge >= 25 && feverGauge < 50)
                {
                    feverBGM.Stop();

                    ResultFever02();
                }

                if (feverGauge >= 50)
                {
                    feverBGM.Stop();

                    ResultFever03();
                }
            }
        }

    }

    public void ResultFever01()
    {
        if(NowRank == 0)
        {
            endText.text = data_Dialog[0]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[0]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[0]["ResultImg"].ToString());
            endGold.text = data_Dialog[0]["FeverGold"].ToString() + "골드 획득!";
            int i = (int)data_Dialog[0]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 1)
        {
            endText.text = data_Dialog[3]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[3]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[3]["ResultImg"].ToString());
            endGold.text = data_Dialog[3]["FeverGold"].ToString() + "골드 획득!";
            int i = (int)data_Dialog[3]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 2)
        {
            endText.text = data_Dialog[6]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[6]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[6]["ResultImg"].ToString());
            endGold.text = data_Dialog[6]["FeverGold"].ToString() + "골드 획득!";
            int i = (int)data_Dialog[6]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 3)
        {
            endText.text = data_Dialog[9]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[9]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[9]["ResultImg"].ToString());
            endGold.text = data_Dialog[9]["FeverGold"].ToString() + "골드 획득!";
            int i = (int)data_Dialog[9]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 4)
        {
            endText.text = data_Dialog[12]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[12]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[12]["ResultImg"].ToString());
            endGold.text = data_Dialog[12]["FeverGold"].ToString() + "골드 획득!";
            int i = (int)data_Dialog[12]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        endBg.SetActive(true);

        // endBg를 작게 가운데서부터 페이드인
        endBg.SetActive(true);
        endBg.transform.localScale = Vector3.zero; // 초기 크기를 0으로 설정

        // DOTween을 사용하여 페이드인 애니메이션 적용
        endBg.transform.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutBounce); // 원래 크기로 1.5초 동안 페이드인
        EndSFX01.Play();

    }

    public void ResultFever02()
    {

        if (NowRank == 0)
        {
            endText.text = data_Dialog[1]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[1]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[1]["ResultImg"].ToString());
            endGold.text = data_Dialog[1]["FeverGold"].ToString() + "골드 획득!";
            int i = (int)data_Dialog[1]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 1)
        {
            endText.text = data_Dialog[4]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[4]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[4]["ResultImg"].ToString());
            endGold.text = data_Dialog[4]["FeverGold"].ToString() + "골드 획득!";
            int i = (int)data_Dialog[4]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 2)
        {
            endText.text = data_Dialog[7]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[7]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[7]["ResultImg"].ToString());
            endGold.text = data_Dialog[7]["FeverGold"].ToString() + "골드 획득!";
            int i = (int)data_Dialog[7]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 3)
        {
            endText.text = data_Dialog[10]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[10]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[10]["ResultImg"].ToString());
            endGold.text = data_Dialog[10]["FeverGold"].ToString() + "골드 획득!";
            int i = (int)data_Dialog[10]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 4)
        {
            endText.text = data_Dialog[13]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[13]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[13]["ResultImg"].ToString());
            endGold.text = data_Dialog[13]["FeverGold"].ToString() + "골드 획득!";
            int i = (int)data_Dialog[13]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }
        basic.gameObject.SetActive(true);

        // endBg를 작게 가운데서부터 페이드인
        endBg.SetActive(true);
        endBg.transform.localScale = Vector3.zero; // 초기 크기를 0으로 설정

        // DOTween을 사용하여 페이드인 애니메이션 적용
        endBg.transform.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutBounce); // 원래 크기로 1.5초 동안 페이드인
        basic.gameObject.SetActive(true);
        EndSFX02.Play();

    }

    public void ResultFever03()
    {
        if (NowRank == 0)
        {
            endText.text = data_Dialog[2]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[2]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[2]["ResultImg"].ToString());
            endGold.text = data_Dialog[2]["FeverGold"].ToString() + "골드 획득!";
            int i = (int)data_Dialog[2]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 1)
        {
            endText.text = data_Dialog[5]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[5]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[5]["ResultImg"].ToString());
            endGold.text = data_Dialog[5]["FeverGold"].ToString() + "골드 획득!";
            int i = (int)data_Dialog[5]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 2)
        {
            endText.text = data_Dialog[8]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[8]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[8]["ResultImg"].ToString());
            endGold.text = data_Dialog[8]["FeverGold"].ToString() + "골드 획득!";
            int i = (int)data_Dialog[8]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 3)
        {
            endText.text = data_Dialog[11]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[11]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[11]["ResultImg"].ToString());
            endGold.text = data_Dialog[11]["FeverGold"].ToString() + "골드 획득!";
            int i = (int)data_Dialog[11]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 4)
        {
            endText.text = data_Dialog[14]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[14]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[14]["ResultImg"].ToString());
            endGold.text = data_Dialog[14]["FeverGold"].ToString() + "골드 획득!";
            int i = (int)data_Dialog[14]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        basic.gameObject.SetActive(true);

        // endBg를 작게 가운데서부터 페이드인
        endBg.SetActive(true);
        endBg.transform.localScale = Vector3.zero; // 초기 크기를 0으로 설정

        // DOTween을 사용하여 페이드인 애니메이션 적용
        endBg.transform.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutBounce); // 원래 크기로 1.5초 동안 페이드인
        EndSFX03.Play();

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
            feverClickSFX.Play();

            if (nowRank00 == true)
            {
                feverGauge++;
            }

            else if (nowRank01 == true)
            {
                feverGauge += 2;
            }

            else if (nowRank02 == true)
            {
                feverGauge += 3;
            }

            else if (nowRank03 == true)
            {
                feverGauge += 4;
            }

            else if (nowRank04 == true)
            {
                feverGauge += 5;
            }

            Debug.Log(feverGauge);

            // feverButton 클릭 시 feverGauge 증가 및 feverSlider 이동
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
        goldText.text = DataManager.Instance.nowGold.ToString();

        EndSFX01.Stop();
        EndSFX02.Stop();
        EndSFX03.Stop();

        nowRank00 = false;
        nowRank01 = false;
        nowRank02 = false;
        nowRank03 = false;
        nowRank04 = false;

        //콤보 횟수 초기화
        clickCount = 0;
        UpdatefeverComboText();

        // result와 Shine_pink 파티클 오브젝트를 비활성화
        endBg.SetActive(false);
        basic.gameObject.SetActive(false);
        feverStart.gameObject.SetActive(false);

        comitionBGM.Play();

    }

}