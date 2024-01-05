using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankManager : MonoBehaviour
{
    // UI 요소들
    public Image NowRankImage;
    public Text NowRankName;

    public Image PopUPBG;
    public Image NextRankImage;
    public Text NextRankName;
    public int nextRank;

    // 각종 효과 및 결과를 나타내는 텍스트들
    public Text PlusGuestState;
    public Text PlusGoldState;
    public Text PlusFeverTime;
    public Text PlusGoods;
    public Text ResultPlusGuestState;
    public Text ResultPlusGoldState;
    public Text ResultPlusFeverTime;
    public Text ResultPlusGoods;

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
    int NowRank;

    private void Start()
    {
        // 초기화 및 필요한 게임 데이터 로드
        NowGold = DataManager.Instance.NowGold;
        NowRank = DataManager.Instance.NowRank;
        RankPopUPBG = GameObject.Find("RankPopUPBG").GetComponent<Image>();
        Unlock = GameObject.Find("UnlockCanvas").GetComponent<Canvas>();
        Result = GameObject.Find("ResultCanvas").GetComponent<Canvas>();

        anim = GameObject.Find("RankPopUPGroup").GetComponent<Animator>();

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
        // 현재 랭크와 다음 랭크의 정보 설정
        NowRankName.text = data_Dialog[NowRank]["rank"].ToString();
        NextRankName.text = data_Dialog[nextRank]["rank"].ToString();

        // 각종 효과 및 비용 텍스트 설정
        PlusGuestState.text = $"커미션 등장 손님 {GetIntValue("guest")}종 상승";
        PlusGoldState.text = $"커미션 1회당 {GetIntValue("goldplus")}골드 상승";
        PlusFeverTime.text = $"피버타임 제한시간 {GetIntValue("time")}초 상승";
        PlusGoods.text = $"굿즈 {GetIntValue("goods")}개 해금";
        SpendGoldText.text = NowGold.ToString() + "/" + data_Dialog[NowRank]["rank_gold"].ToString();
    }

    private int GetIntValue(string key)
    {
        // CSV 데이터에서 특정 키의 정수값을 가져오는 메서드
        if (NowRank >= 0 && NowRank < data_Dialog.Count)
        {
            string value = data_Dialog[NowRank][key]?.ToString();
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
        // 언락 여부 확인하는 메서드 (아직 구현되지 않음)
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
        NowGold -= GetIntValue("rank_gold");

        NowRank++;
        nextRank++;

        if (nextRank >= data_Dialog.Count)
        {
            nextRank = 0; // 또는 다른 초기값으로 설정 가능
        }

        // 랭크 정보 및 결과 텍스트 업데이트
        NowRankName.text = data_Dialog[NowRank]["rank"].ToString();
        NextRankName.text = data_Dialog[nextRank]["rank"].ToString();
        SpendGoldText.text = NowGold.ToString() + "/" + data_Dialog[NowRank]["rank_gold"].ToString();

        ResultPlusGuestState.text = $"커미션 등장 손님 {GetIntValue("guest")}종 상승";
        ResultPlusGoldState.text = $"커미션 1회당 {GetIntValue("goldplus")}골드 상승";
        ResultPlusFeverTime.text = $"피버타임 제한시간 {GetIntValue("time")}초 상승";
        ResultPlusGoods.text = $"굿즈 {GetIntValue("goods")}개 해금";
        PopUPText.text = "정말 " + data_Dialog[nextRank]["rank"].ToString() + "(으)로 승급하시겠습니까?";
        PopUPNotice.text = "승급시" + data_Dialog[nextRank]["rank_gold"].ToString() + "골드가 소모됩니다.";
        anim.SetTrigger("DoHide");
        RankPopUPBG.gameObject.SetActive(false);
        Result.gameObject.SetActive(true);

        NowRankName.text = data_Dialog[NowRank]["rank"].ToString();
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
    
}