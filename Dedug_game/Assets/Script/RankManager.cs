using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System;


public class RankManager : MonoBehaviour
{
    // UI 요소들
    public Image NowRankImage;
    public Text NowRankName;
    public Button RankUPBtn;
    public Image PopUPBG;
    public Image NextRankImage;
    public Text NextRankName;
    Image ResultChr;
    public Image ResultBG;
    public GameObject effectPrefab;
    int nextRank;
    public string imageFileName;

    // sprite 지정
    public Sprite Rank1;
    public Sprite Rank2;
    public Sprite Rank3;

    // 각종 효과 및 결과를 나타내는 텍스트들
    public Text PlusGuestState;
    public Text PlusGoldState;
    public Text PlusFeverTime;
    public Text PlusGoods;
    public Text ResultPlusGuestState;
    public Text ResultPlusGoldState;
    public Text ResultPlusFeverTime;
    public Text ResultPlusGoods;
    public Text UnlockGoods;
    public Text SpendGoldText;
    int NowGold;

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
    private const string RankSampleFileName = "RankSample";
    private char[] TRIM_CHARS = { ' ', '\"' };
    
    private void Awake()
    {
        DataManager.Instance.nowGold = PlayerPrefs.GetInt("NowGold");
        DataManager.Instance.nowRank = PlayerPrefs.GetInt("NowRank");
        DataManager.Instance.goods3011 = PlayerPrefs.GetInt("Goods3011");
       
    }
    private void Start()
    {
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


        // CSV 파일에서 데이터 읽기
        data_Dialog = CSVReader.Read(RankSampleFileName);

        // 랭크 정보 설정 및 언락 확인
        SetupRankInfo();
        UnlockCheck();

    }

    private void SetupRankInfo()
    {
        if (DataManager.Instance.nowRank >= 0 && DataManager.Instance.nowRank < data_Dialog.Count)
        {
            // 현재 랭크와 다음 랭크의 정보 설정
            NowRankName.text = data_Dialog[DataManager.Instance.nowRank]["rank"].ToString();
            NextRankName.text = data_Dialog[nextRank]["rank"].ToString();

            // 각종 효과 및 비용 텍스트 설정
            PlusGuestState.text = $"커미션 등장 손님 {GetIntValue("guest")}종 상승";
            PlusGoldState.text = $"커미션 1회당 {GetIntValue("goldplus")}골드 상승";
            PlusFeverTime.text = $"피버타임 제한시간 {GetIntValue("time")}초 상승";
            PlusGoods.text = $"굿즈 {GetIntValue("goods")}개 해금";

        }
        else
        {
            // 현재 랭크와 다음 랭크의 정보 설정
            NowRankName.text = data_Dialog[DataManager.Instance.nowRank]["rank"].ToString();
            NextRankName.text = " 당신은 이미 정상입니다 ";

            // 각종 효과 및 비용 텍스트 설정
            PlusGuestState.text = "축하합니다!";
            PlusGoldState.text = "당신은 오타쿠의";
            PlusFeverTime.text = "경지에 올랐습니다!";
            PlusGoods.text = "이미 최고 등급에 도달했습니다!";
            NowRankImage.sprite = Rank1;
            
        }

        if (Convert.ToInt32(data_Dialog[DataManager.Instance.nowRank]["level"]) == 1)
        {
            NowRankImage.sprite = Rank1;
            NextRankImage.sprite = Rank2;
        }
        else if (Convert.ToInt32(data_Dialog[DataManager.Instance.nowRank]["level"]) == 2)
        {
            NowRankImage.sprite = Rank2;
            NextRankImage.sprite = Rank3;
        }
        else if (Convert.ToInt32(data_Dialog[DataManager.Instance.nowRank]["level"]) == 3)
        {
            NowRankImage.sprite = Rank3;
            NextRankImage.sprite = Rank1;
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
            if (DataManager.Instance.goods3011 == 0)
            {
                UnlockGoods.text = "굿즈" + data_Dialog[nextRank]["GoodsName"].ToString() + "을 획득하면 해금됩니다.";
                Unlock.gameObject.SetActive(true);
            }
            else
            {
                Unlock.gameObject.SetActive(false);
            }
        }

        else if (DataManager.Instance.nowRank == 1)
        {
            if (DataManager.Instance.goods3021 == 0)
            {
                UnlockGoods.text = "굿즈" + data_Dialog[nextRank]["GoodsName"].ToString() + "을 획득하면 해금됩니다.";
                Unlock.gameObject.SetActive(true);
            }
            else
            {
                Unlock.gameObject.SetActive(false);
            }
        }
        else
        {
            Unlock.gameObject.SetActive(false);
        }

        if (DataManager.Instance.nowGold >= Convert.ToInt32(data_Dialog[nextRank]["rank_gold"]))
            {
                SpendGoldText.text = $"{DataManager.Instance.nowGold}/{data_Dialog[nextRank]["rank_gold"]}";
                SpendGoldText.color = Color.black;
                RankUPBtn.interactable = true;  // 버튼 활성화
            }
            else
            {
                SpendGoldText.text = $"{DataManager.Instance.nowGold}/{data_Dialog[nextRank]["rank_gold"]}";
                SpendGoldText.color = Color.red;
                RankUPBtn.interactable = false;  // 버튼 비활성화
            }
        
    }

    public void RankPopUPClick()
    {
        // 랭크 팝업 클릭 시 호출되는 메서드
        PopUPText.text = "정말 " + data_Dialog[nextRank]["rank"].ToString() + "(으)로 승급하시겠습니까?";
        PopUPNotice.text = "승급시" + data_Dialog[nextRank]["rank_gold"].ToString() + "골드가 소모됩니다.";
        RankPopUPBG.gameObject.SetActive(true);
        anim.SetTrigger("DoShow");
    }

    public void RankPopUPClickConfirm()
    {
        // 랭크 팝업 확인 클릭 시 호출되는 메서드
        DataManager.Instance.nowGold -= Convert.ToInt32(data_Dialog[DataManager.Instance.nowRank]["rank_gold"]);

        DataManager.Instance.nowRank++;
        nextRank++;

        if (nextRank >= data_Dialog.Count)
        {
            nextRank = 0; // 또는 다른 초기값으로 설정 가능
        }

        Save();
        // 랭크 정보 및 결과 텍스트 업데이트
        SetupRankInfo();
        SpendGoldText.text = DataManager.Instance.nowGold.ToString() + "/" + data_Dialog[DataManager.Instance.nowRank]["rank_gold"].ToString();
        
        imageFileName = data_Dialog[DataManager.Instance.nowRank]["ResultImg"].ToString();
        ResultChr.sprite = Resources.Load<Sprite>(imageFileName);

        //GameObject effectInstance = Instantiate(effectPrefab, ResultChr.transform.position, Quaternion.identity);

        // Vector3 newPosition = effectPrefab.transform.position;
         //  newPosition.z = 2f;
        //effectPrefab.transform.position = newPosition;

        // 프리팹 크기 설정
        // Vector3 desiredScale = new Vector3(0.9f, 0.9f, 0.9f);  
        //effectInstance.transform.localScale = desiredScale;

        ResultPlusGuestState.text = $"커미션 등장 손님 {GetIntValue("guest")}종 상승";
        ResultPlusGoldState.text = $"커미션 1회당 {GetIntValue("goldplus")}골드 상승";
        ResultPlusFeverTime.text = $"피버타임 제한시간 {GetIntValue("time")}초 상승";
        ResultPlusGoods.text = $"굿즈 {GetIntValue("goods")}개 해금";
        PopUPText.text = "정말 " + data_Dialog[nextRank]["rank"].ToString() + "(으)로 승급하시겠습니까?";
        PopUPNotice.text = "승급시" + data_Dialog[nextRank]["rank_gold"].ToString() + "골드가 소모됩니다.";
        anim.SetTrigger("DoHide");
        RankPopUPBG.gameObject.SetActive(false);
        Result.gameObject.SetActive(true);
        UnlockCheck();
        

    }

    public void RankPopUPExitClick()
    {
        // 랭크 팝업 종료 클릭 시 호출되는 메서드
        anim.SetTrigger("DoHide");
        RankPopUPBG.gameObject.SetActive(false);
    }

    public void ResultExitClick()
    {
        // 결과 창 종료 클릭 시 호출되는 메서드
        Result.gameObject.SetActive(false);
        RankPopUPBG.gameObject.SetActive(false);
    }

    public void Save()
    {
        // PlayerPrefs에 현재 값 저장
        PlayerPrefs.SetInt("NowRank", DataManager.Instance.nowRank);
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        PlayerPrefs.SetInt("Goods3011", DataManager.Instance.goods3011);
        PlayerPrefs.Save();
    }

    public void HomeClick()
    {
        Save();
        SceneManager.LoadScene("HomeScene");
    }
    public void testGoods3011()
    {
        DataManager.Instance.goods3011 = 1;
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
        DataManager.Instance. nowGold = 0;
        DataManager.Instance.goods3011 = 0;
        SetupRankInfo();
        UnlockCheck();

    }
}