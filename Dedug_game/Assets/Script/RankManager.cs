using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;
using System.Collections;


public class RankManager : MonoBehaviour
{
    // UI 요소들
    public Image NowRankImage;
    public Text NowRankName;
    public Text NowRankName2;
    public Button RankUPBtn;

    public Image PopUPBG;
    public Image NextRankImage;
    public Text NextRankName;
    Image ResultChr;
    public Image ResultBG;

    int nextRank;
    public string NowimageFileName;
    public string NextimageFileName;

    public GameObject EffectPrefab;
    public GameObject _effectPrefab;

    // sprite 지정
    public Sprite Rank1;
    public Sprite Rank2;
    public Sprite Rank3;

    // 각종 효과 및 결과를 나타내는 텍스트들
    public Text PlusGuestState;
    
    public Text PlusFeverTime;
    public Text PlusGoods;
    public Text ResultPlusGuestState;
    
    public Text ResultPlusFeverTime;
    public Text ResultPlusGoods;
    public Text UnlockGoods;
    public Text SpendGoldText;
    int NowGold;

    public AudioSource bgm1AudioSource;
    public AudioSource bgm2AudioSource;
    public AudioSource sfx1AudioSource;
    public AudioSource sfx2AudioSource;

    // 게임 오브젝트 및 캔버스 관련 변수
    private GameObject RankPopUP;
    private Image RankPopUPBG;
    private Canvas Unlock;
    private Canvas Result;

    // 팝업 텍스트 및 애니메이션
    public Text PopUPText;
    public Text PopUPNotice;
    public Animator anim;

    // CSV 파일을 읽어들일 데이터 리스트
    private List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();
    private const string RankFileName = "RankTable";
    private char[] TRIM_CHARS = { ' ', '\"' };

    private void Awake()
    {
        DataManager.Instance.nowGold = PlayerPrefs.GetInt("NowGold");
        DataManager.Instance.nowRank = PlayerPrefs.GetInt("NowRank");
        DataManager.Instance.goods1011 = PlayerPrefs.GetInt("Goods1011");
        DataManager.Instance.goods2022 = PlayerPrefs.GetInt("Goods2022");
        DataManager.Instance.goods3031 = PlayerPrefs.GetInt("Goods3031");
        DataManager.Instance.goods2042 = PlayerPrefs.GetInt("Goods2042");
        DataManager.Instance.storyID = PlayerPrefs.GetInt("StoryID");
    }
    private void Start()
    {
        Debug.Log("승급:" + DataManager.Instance.goods1011);
        // 초기화 및 필요한 게임 데이터 로드
        nextRank = DataManager.Instance.nowRank + 1;
        NowRankImage = GameObject.Find("NowRankImage").GetComponent<Image>();
        NextRankImage = GameObject.Find("NextRankImage").GetComponent<Image>();
        RankPopUPBG = GameObject.Find("RankPopUPBG").GetComponent<Image>();
        Unlock = GameObject.Find("UnlockCanvas").GetComponent<Canvas>();
        Result = GameObject.Find("ResultCanvas").GetComponent<Canvas>();
        RankUPBtn = GameObject.Find("RankUPBtn").GetComponent<Button>();
        anim = GameObject.Find("RankPopUPGroup").GetComponent<Animator>();
        ResultChr = Result.transform.Find("ResultCharacter").GetComponent<Image>();
        

        RankPopUPBG.gameObject.SetActive(false);
        Unlock.gameObject.SetActive(false);
        Result.gameObject.SetActive(false);
        ClickTouchBtn.gameObject.SetActive(false);
        _effectPrefab.gameObject.SetActive(false);
        // CSV 파일에서 데이터 읽기
        data_Dialog = CSVReader.Read(RankFileName);

        bgm1AudioSource.loop = true;
        bgm1AudioSource.Play();

        // BGM2 중지
        bgm2AudioSource.Stop();
        sfx1AudioSource.Stop();
        sfx2AudioSource.Stop();


        // 랭크 정보 설정 및 언락 확인
        SetupRankInfo();
        UnlockCheck();

    }
    public void PlaySFX1()
    {
        sfx1AudioSource.Play();
    }

    private void SetupRankInfo()
    {
        data_Dialog = CSVReader.Read(RankFileName);

        if (DataManager.Instance.nowRank == 4)
        {
            // 현재 랭크와 다음 랭크의 정보 설정
            NowRankName.text = data_Dialog[DataManager.Instance.nowRank]["RankName"].ToString();
            NextRankName.text = "오닥구";

            // 각종 효과 및 비용 텍스트 설정
            PlusGuestState.text = "축하합니다!";
            PlusFeverTime.text = "당신은 오타쿠의";
            PlusGoods.text = "경지에 올랐습니다!";

            NowimageFileName = data_Dialog[DataManager.Instance.nowRank]["MainImage"].ToString();
            NextimageFileName = data_Dialog[nextRank]["MainImage"].ToString();
            NowRankImage.sprite = Resources.Load<Sprite>(NowimageFileName);
            NextRankImage.sprite = Resources.Load<Sprite>(NextimageFileName);

        }
        else if (DataManager.Instance.nowRank >= 0 && DataManager.Instance.nowRank < data_Dialog.Count)
        {
            // 현재 랭크와 다음 랭크의 정보 설정
            NowRankName.text = data_Dialog[DataManager.Instance.nowRank]["RankName"].ToString();
            NextRankName.text = data_Dialog[nextRank]["RankName"].ToString();

            // 각종 효과 및 비용 텍스트 설정
            PlusGuestState.text = "커미션 등장 손님 " + data_Dialog[nextRank]["GuestPlus"].ToString() + "종 상승";
            PlusFeverTime.text = $"피버타임 제한시간 " + data_Dialog[nextRank]["GuestPlus"].ToString()+ "초 상승";
            PlusGoods.text = $"좋은 굿즈 획득 확률 상승";

            NowimageFileName = data_Dialog[DataManager.Instance.nowRank]["MainImage"].ToString();
            NextimageFileName = data_Dialog[nextRank]["MainImage"].ToString();
            NowRankImage.sprite = Resources.Load<Sprite>(NowimageFileName);
            NextRankImage.sprite = Resources.Load<Sprite>(NextimageFileName);

        }

    }

    private int GetIntValue(string key)
    {
        // CSV 데이터에서 특정 키의 정수값을 가져오는 메서드
        if (DataManager.Instance.nowRank >= 0 && DataManager.Instance.nowRank < data_Dialog.Count)
        {
            string value = data_Dialog[DataManager.Instance.nowRank][key]?.ToString();
            if (value != null)
            {
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                if (int.TryParse(value, out int intValue))
                {
                    return intValue;
                }

            }
        }

        // 기본값 반환
        return 0;
    }

    public void UnlockCheck()
    {
        //여기서 데이터매니저에게 검사하는 방법이 뭔지 모르겠음... 굿즈 테이블에 따라 바뀔 것 같음
        if (DataManager.Instance.nowRank == 0)
        {
            if (DataManager.Instance.goods1011 == 0)
            {
                //UnlockGoods.text = "굿즈" + data_Dialog[nextRank]["Ranktest"].ToString() + "을 획득하면 해금됩니다.";
                UnlockGoods.text = "굿즈 '수아 컵홀더'를 획득하면 해금됩니다.";
                Unlock.gameObject.SetActive(true);
            }
            else if(DataManager.Instance.goods1011 >= 1 )
            {
                Unlock.gameObject.SetActive(false);
            }
        }

        else if (DataManager.Instance.nowRank == 1)
        {
            if (DataManager.Instance.goods2022 == 0)
            {
                UnlockGoods.text = "굿즈 '바다 L홀더'를 획득하면 해금됩니다.";
                Unlock.gameObject.SetActive(true);
            }
            else if (DataManager.Instance.goods2022 >= 1)
            {
                Unlock.gameObject.SetActive(false);
            }
        }
        else if (DataManager.Instance.nowRank == 2)
        {
            if (DataManager.Instance.goods3031 == 0)
            {
                UnlockGoods.text = "굿즈 '초롱 아크릴 스탠드'를 획득하면 해금됩니다.";
                Unlock.gameObject.SetActive(true);
            }
            else if (DataManager.Instance.goods3031 >= 1)
            {
                Unlock.gameObject.SetActive(false);
            }
        }
        else if (DataManager.Instance.nowRank == 3)
        {
            if (DataManager.Instance.goods2042 == 0)
            {
                UnlockGoods.text = "굿즈 '바다 태피스트리'를 획득하면 해금됩니다.";
                Unlock.gameObject.SetActive(true);
            }
            else if (DataManager.Instance.goods2042 >= 1)
            {
                Unlock.gameObject.SetActive(false);
            }
        }
        else
        {
            Unlock.gameObject.SetActive(false);
        }


        if (DataManager.Instance.nowGold >= Convert.ToInt32(data_Dialog[nextRank]["RankGold"]))
        {
            SpendGoldText.text = $"{DataManager.Instance.nowGold}/{data_Dialog[nextRank]["RankGold"]}";
            SpendGoldText.color = Color.black;
            RankUPBtn.interactable = true;  // 버튼 활성화
        }
        else
        {
            SpendGoldText.text = $"{DataManager.Instance.nowGold}/{data_Dialog[nextRank]["RankGold"]}";
            SpendGoldText.color = Color.red;
            RankUPBtn.interactable = false;  // 버튼 비활성화
        }

        if (DataManager.Instance.nowRank >= 4)
        {
            SpendGoldText.text = $"최고 등급 달성!";
            SpendGoldText.color = Color.red;
            RankUPBtn.interactable = false;
        }

    }

    public void RankPopUPClick()
    {
        // 랭크 팝업 클릭 시 호출되는 메서드
        PopUPText.text = "정말 " + data_Dialog[nextRank]["RankName"].ToString() + "(으)로 승급하시겠습니까?";
        PopUPNotice.text = "승급시" + data_Dialog[nextRank]["RankGold"].ToString() + "골드가 소모됩니다.";
        RankPopUPBG.gameObject.SetActive(true);
        anim.SetTrigger("DoShow");
    }
    

    public void RankPopUPClickConfirm()
    {
        // BGM1 Pause
        bgm1AudioSource.Pause();

        // BGM2 플레이
        bgm2AudioSource.loop = true;
        bgm2AudioSource.Play();

        // 랭크 팝업 확인 클릭 시 호출되는 메서드
        DataManager.Instance.nowGold -= Convert.ToInt32(data_Dialog[nextRank]["RankGold"]);

        DataManager.Instance.nowRank++;
        nextRank++;


        Save();
        // 랭크 정보 및 결과 텍스트 업데이트
        SetupRankInfo();
        SpendGoldText.text = DataManager.Instance.nowGold.ToString() + "/" + data_Dialog[DataManager.Instance.nowRank]["RankGold"].ToString();

        NowimageFileName = data_Dialog[DataManager.Instance.nowRank]["MainImage"].ToString();
        ResultChr.sprite = Resources.Load<Sprite>(NowimageFileName);


        //GameObject effectInstance = Instantiate(effectPrefab, ResultChr.transform.position, Quaternion.identity);

        // Vector3 newPosition = effectPrefab.transform.position;
        //  newPosition.z = 2f;
        //effectPrefab.transform.position = newPosition;

        // 프리팹 크기 설정
        // Vector3 desiredScale = new Vector3(0.9f, 0.9f, 0.9f);  
        //effectInstance.transform.localScale = desiredScale;
        NowRankName2.text = data_Dialog[DataManager.Instance.nowRank]["RankName"].ToString();

        ResultPlusGuestState.text = $"커미션 등장 손님 {GetIntValue("GuestPlus")}종 상승";
       
        ResultPlusFeverTime.text = $"피버타임 제한시간 {GetIntValue("FeverTimePlus")}초 상승";
        ResultPlusGoods.text = $"좋은 굿즈 획득 확률 상승";
        PopUPText.text = "정말 " + data_Dialog[nextRank]["RankName"].ToString() + "(으)로 승급하시겠습니까?";
        PopUPNotice.text = "승급시" + data_Dialog[nextRank]["RankGold"].ToString() + "골드가 소모됩니다.";
        anim.SetTrigger("DoHide");

        NowimageFileName = data_Dialog[DataManager.Instance.nowRank]["MainImage"].ToString();
        NextimageFileName = data_Dialog[nextRank]["MainImage"].ToString();
        NowRankImage.sprite = Resources.Load<Sprite>(NowimageFileName);
        NextRankImage.sprite = Resources.Load<Sprite>(NextimageFileName);

        _effectPrefab.gameObject.SetActive(true);
        ClickTouchBtn.gameObject.SetActive(true);

        
        RankPopUPBG.gameObject.SetActive(false);
        Result.gameObject.SetActive(true);
        UnlockCheck();
        
        

    }
    public Button ClickTouchBtn;
    public void ClickTouch()
    {
        // SFX2 플레이
        sfx2AudioSource.Play();

        Sequence buttonSequence = DOTween.Sequence();

        // 버튼에 대한 스케일 및 페이딩 애니메이션 추가
        ClickTouchBtn.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f);
        ClickTouchBtn.image.DOFade(0f, 2f);

        // 이펙트에 대한 스케일 및 페이딩 애니메이션 추가
        GameObject effectInstance = Instantiate(EffectPrefab, ClickTouchBtn.transform.position, Quaternion.identity);
        effectInstance.transform.SetParent(ClickTouchBtn.transform.parent);  // 이펙트의 부모를 버튼의 부모로 설정

        Sequence effectSequence = DOTween.Sequence();
        effectSequence.Append(effectInstance.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f));
        effectSequence.Join(effectInstance.GetComponent<Image>().DOFade(0f, 2f));

        // 버튼 및 이펙트 애니메이션 시퀀스 재생
        buttonSequence.Play();
        effectSequence.Play();
        _effectPrefab.gameObject.SetActive(false);

        // ResultCanvas를 오른쪽에서 왼쪽으로 0.2초 동안 부드럽게 이동
        RectTransform resultRectTransform = Result.GetComponent<RectTransform>();
        resultRectTransform.DOAnchorPosX(0f, 0.2f).OnComplete(() =>
        {
            // 애니메이션이 완료되면 실행될 코드
            // 클릭 버튼을 다시 초기 상태에서 FadeIn 및 원래 크기로 애니메이션
            ClickTouchBtn.image.DOFade(1f, 0f); // FadeIn
            ClickTouchBtn.transform.DOScale(Vector3.one, 0f); // 원래 크기로 설정

            // 2초 뒤에 ClickTouchBtn을 다시 클릭 가능하도록 설정
            DOVirtual.DelayedCall(2f, () =>
            {
                ClickTouchBtn.gameObject.SetActive(false);
                effectInstance.gameObject.SetActive(false);
            });
        });
    }


    public void RankPopUPExitClick()
    {
        // 랭크 팝업 종료 클릭 시 호출되는 메서드
        anim.SetTrigger("DoHide");
        RankPopUPBG.gameObject.SetActive(false);
        if(DataManager.Instance.nowRank == 4)
        {
            DataManager.Instance.storyID = 99;
            SceneManager.LoadScene("StoryScene");
        }
        
        
    }

    public void ResultExitClick()
    {
        // 결과 창 종료 클릭 시 호출되는 메서드
        Result.gameObject.SetActive(false);
        RankPopUPBG.gameObject.SetActive(false);
        
        bgm2AudioSource.Stop();
        // BGM1 플레이
        bgm1AudioSource.UnPause();

        // 여기서 이전 상태로 초기화 또는 다른 초기화 작업 수행
        // 예를 들어, ResultCanvas를 오른쪽에서 왼쪽으로 이동하는 애니메이션 초기화
        RectTransform resultRectTransform = Result.GetComponent<RectTransform>();
        resultRectTransform.anchoredPosition = new Vector2(Screen.width, 0);
        ClickTouchBtn.image.DOFade(1f, 0f); // FadeIn
        ClickTouchBtn.transform.DOScale(Vector3.one, 0f);

    }

    public void Save()
    {
        // PlayerPrefs에 현재 값 저장
        PlayerPrefs.SetInt("NowRank", DataManager.Instance.nowRank);
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        PlayerPrefs.SetInt("StoryID", DataManager.Instance.storyID);
        PlayerPrefs.Save();
    }

    public void HomeClick()
    {
        Save();
        SceneManager.LoadScene("HomeScene");
    }
    public void testGoods1011()
    {
        DataManager.Instance.goods1011++;
        UnlockCheck();
    }
    public void testGold()
    {
        DataManager.Instance.nowGold = DataManager.Instance.nowGold + 100;
        UnlockCheck();
    }

    public void Clear()
    {
        DataManager.Instance.nowRank = 0;
        DataManager.Instance.nowGold = 0;
        

        nextRank = 1;
        Save();
        SetupRankInfo();
        UnlockCheck();

    }
}