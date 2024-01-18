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

    // 파티클 관련
    public Image result;
    public GameObject shinePinkParticle;

    // 엔드 화면 파티클
    public GameObject basic;
    public GameObject happy;

    public AudioSource EndSFX01;
    public AudioSource EndSFX02;
    public AudioSource EndSFX03;
    public AudioSource resultSFX;

    public AudioSource comitionBGM;

    public AudioSource feverBGM;

    public AudioSource feverClickSFX;


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
    }

    public void OnEnable()
    {
        feverButton.onClick.AddListener(OnClickFeverButton);
        UpdateFeverTimeText();
        data_Dialog = CSVReader.Read("FeverCSV");

        // 랭크에 따라 countdownTime 초기화
        if (NowRank == 0)
        {
            countdownTime = 10f;
        }
        else if (NowRank == 1)
        {
            countdownTime = 13f;
        }
        else if (NowRank == 2)
        {
            countdownTime = 16f;
        }
        else if (NowRank == 3)
        {
            countdownTime = 23f;
        }
        else if (NowRank == 4)
        {
            countdownTime = 30f;
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

            if (countdownTime <= 0)
            {
                
                // 카운트 다운이 0이 되면 feverBg를 비활성화하고 endBg를 활성화한다.
                feverBg.SetActive(false);

                // feverGauge 검사
                if (feverGauge >= 1 && feverGauge <= 10)
                {
                    feverBGM.Stop();
                    // result와 Shine_pink 파티클 오브젝트를 활성화
                    result.gameObject.SetActive(true);
                    shinePinkParticle.SetActive(true);
                    resultSFX.Play();

                    StartCoroutine(DeactivateParticlesAfterDelay(2f)); // 2초 후에 파티클 비활성화


                }

                if (feverGauge >= 11 && feverGauge <= 25)
                {
                    feverBGM.Stop();
                    // result와 Shine_pink 파티클 오브젝트를 활성화
                    result.gameObject.SetActive(true);
                    shinePinkParticle.SetActive(true);
                    resultSFX.Play();

                    StartCoroutine(DeactivateParticlesAfterDelay02(2f)); // 2초 후에 파티클 비활성화




                }

                if (feverGauge >= 26)
                {
                    feverBGM.Stop();
                    // result와 Shine_pink 파티클 오브젝트를 활성화
                    result.gameObject.SetActive(true);
                    shinePinkParticle.SetActive(true);
                    resultSFX.Play();

                    StartCoroutine(DeactivateParticlesAfterDelay03(2f)); // 2초 후에 파티클 비활성화


                }
            }
        }

    }

    IEnumerator DeactivateParticlesAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        shinePinkParticle.SetActive(false);

        endText.text = data_Dialog[0]["ResultExplain"].ToString();
        endTitle.text = data_Dialog[0]["ResultGrade"].ToString();
        endGold.text = data_Dialog[0]["FeverGold"].ToString();

        SetImageFromResultImg(data_Dialog[0]["ResultImg"].ToString());

        DataManager.Instance.nowGold += 20;
        Save();

        endBg.SetActive(true);

        // endBg를 작게 가운데서부터 페이드인
        endBg.SetActive(true);
        endBg.transform.localScale = Vector3.zero; // 초기 크기를 0으로 설정

        // DOTween을 사용하여 페이드인 애니메이션 적용
        endBg.transform.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutBounce); // 원래 크기로 1.5초 동안 페이드인
        EndSFX01.Play();

    }

    IEnumerator DeactivateParticlesAfterDelay02(float delay)
    {
        yield return new WaitForSeconds(delay);

        shinePinkParticle.SetActive(false);

        endText.text = data_Dialog[1]["ResultExplain"].ToString();
        endTitle.text = data_Dialog[1]["ResultGrade"].ToString();
        endGold.text = data_Dialog[1]["FeverGold"].ToString();

        SetImageFromResultImg(data_Dialog[1]["ResultImg"].ToString());

        DataManager.Instance.nowGold += 50;
        Save();

        // endBg를 작게 가운데서부터 페이드인
        endBg.SetActive(true);
        endBg.transform.localScale = Vector3.zero; // 초기 크기를 0으로 설정

        // DOTween을 사용하여 페이드인 애니메이션 적용
        endBg.transform.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutBounce); // 원래 크기로 1.5초 동안 페이드인
        basic.gameObject.SetActive(true);
        EndSFX02.Play();

    }

    IEnumerator DeactivateParticlesAfterDelay03(float delay)
    {
        yield return new WaitForSeconds(delay);

        shinePinkParticle.SetActive(false);

        endText.text = data_Dialog[2]["ResultExplain"].ToString();
        endTitle.text = data_Dialog[2]["ResultGrade"].ToString();
        endGold.text = data_Dialog[2]["FeverGold"].ToString();

        SetImageFromResultImg(data_Dialog[2]["ResultImg"].ToString());

        DataManager.Instance.nowGold += 80;
        Save();

        // endBg를 작게 가운데서부터 페이드인
        endBg.SetActive(true);
        endBg.transform.localScale = Vector3.zero; // 초기 크기를 0으로 설정

        // DOTween을 사용하여 페이드인 애니메이션 적용
        endBg.transform.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutBounce); // 원래 크기로 1.5초 동안 페이드인
        happy.gameObject.SetActive(true);
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
        goldText.text = DataManager.Instance.nowGold.ToString();

        // result와 Shine_pink 파티클 오브젝트를 비활성화
        result.gameObject.SetActive(false);
        endBg.SetActive(false);
        basic.gameObject.SetActive(false);
        feverStart.gameObject.SetActive(false);

        comitionBGM.Play();

    }

}