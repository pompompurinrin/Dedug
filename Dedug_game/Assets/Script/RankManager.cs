using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankManager : MonoBehaviour
{
    public Image NowRankImage;
    public Text NowRankName;
    public static int NowRank = 0;
    public Image PopUPBG;
    public Image NextRankImage;
    public Text NextRankName;
    public int nextRank = NowRank + 1;

    public Text PlusGuestState;
    public Text PlusGoldState;
    public Text PlusFeverTime;
    public Text PlusGoods;
    public Text ResultPlusGuestState;
    public Text ResultPlusGoldState;
    public Text ResultPlusFeverTime;
    public Text ResultPlusGoods;

    public Text SpendGoldText;
    public static int NowGold;

    private GameObject RankPopUP;
    private Image RankPopUPBG;
    private Canvas Unlock;
    private Canvas Result;
    
    public Text PopUPText;
    public Text PopUPNotice;
    

    public Animator anim;

    private List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();
    private const string RankSampleFileName = "RankSample";
    private char[] TRIM_CHARS = { ' ', '\"' };

 

    private void Start()
    {
       
        RankPopUPBG = GameObject.Find("RankPopUPBG").GetComponent<Image>();
        Unlock = GameObject.Find("UnlockCanvas").GetComponent<Canvas>();
        Result = GameObject.Find("ResultCanvas").GetComponent<Canvas>();

        anim = GameObject.Find("RankPopUPGroup").GetComponent<Animator>();

        RankPopUPBG.gameObject.SetActive(false);
        Unlock.gameObject.SetActive(false);
        Result.gameObject.SetActive(false);

        data_Dialog = CSVReader.Read(RankSampleFileName);

        SetupRankInfo();
        UnlockCheck();
    }

    private void SetupRankInfo()
    {
        NowRankName.text = data_Dialog[NowRank]["rank"].ToString();
        NextRankName.text = data_Dialog[nextRank]["rank"].ToString();

        PlusGuestState.text = $"커미션 등장 손님 {GetIntValue("guest")}종 상승";
        PlusGoldState.text = $"커미션 1회당 {GetIntValue("goldplus")}골드 상승";
        PlusFeverTime.text = $"피버타임 제한시간 {GetIntValue("time")}초 상승";
        PlusGoods.text = $"굿즈 {GetIntValue("goods")}개 해금";
        SpendGoldText.text = NowGold.ToString() + "/" + data_Dialog[NowRank]["rank_gold"].ToString();
    }


    private int GetIntValue(string key)
    {
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


    }

    public void RankPopUPClick()
    {
        PopUPText.text = "정말 " + data_Dialog[nextRank]["rank"].ToString() + "(으)로 승급하시겠습니까?";
        PopUPNotice.text = "승급시" + data_Dialog[nextRank]["rank_gold"].ToString() + "골드가 소모됩니다.";
        RankPopUPBG.gameObject.SetActive(true);
        anim.SetTrigger("DoShow");
    }

    public void RankPopUPClickConfirm()
    {
        NowGold -= GetIntValue("rank_gold");

        NowRank++;
        nextRank++;
        //현재만 잠시 쓰임(데이터값이 더이상 없어!)
        if (nextRank >= data_Dialog.Count)
        {
            nextRank = 0; // 또는 다른 초기값으로 설정 가능
        }

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
        anim.SetTrigger("DoHide");
        RankPopUPBG.gameObject.SetActive(false);
    }

    public void ResultExitClick()
    {
        Result.gameObject.SetActive(false);
        RankPopUPBG.gameObject.SetActive(false);
        
    }
    
}
