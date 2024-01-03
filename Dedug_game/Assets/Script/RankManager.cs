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

        PlusGuestState.text = $"Ŀ�̼� ���� �մ� {GetIntValue("guest")}�� ���";
        PlusGoldState.text = $"Ŀ�̼� 1ȸ�� {GetIntValue("goldplus")}��� ���";
        PlusFeverTime.text = $"�ǹ�Ÿ�� ���ѽð� {GetIntValue("time")}�� ���";
        PlusGoods.text = $"���� {GetIntValue("goods")}�� �ر�";
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

        // �⺻�� ��ȯ
        return 0;
    }

    public void UnlockCheck()
    {


    }

    public void RankPopUPClick()
    {
        PopUPText.text = "���� " + data_Dialog[nextRank]["rank"].ToString() + "(��)�� �±��Ͻðڽ��ϱ�?";
        PopUPNotice.text = "�±޽�" + data_Dialog[nextRank]["rank_gold"].ToString() + "��尡 �Ҹ�˴ϴ�.";
        RankPopUPBG.gameObject.SetActive(true);
        anim.SetTrigger("DoShow");
    }

    public void RankPopUPClickConfirm()
    {
        NowGold -= GetIntValue("rank_gold");

        NowRank++;
        nextRank++;
        //���縸 ��� ����(�����Ͱ��� ���̻� ����!)
        if (nextRank >= data_Dialog.Count)
        {
            nextRank = 0; // �Ǵ� �ٸ� �ʱⰪ���� ���� ����
        }

        NowRankName.text = data_Dialog[NowRank]["rank"].ToString();
        NextRankName.text = data_Dialog[nextRank]["rank"].ToString();
        SpendGoldText.text = NowGold.ToString() + "/" + data_Dialog[NowRank]["rank_gold"].ToString();

        ResultPlusGuestState.text = $"Ŀ�̼� ���� �մ� {GetIntValue("guest")}�� ���";
        ResultPlusGoldState.text = $"Ŀ�̼� 1ȸ�� {GetIntValue("goldplus")}��� ���";
        ResultPlusFeverTime.text = $"�ǹ�Ÿ�� ���ѽð� {GetIntValue("time")}�� ���";
        ResultPlusGoods.text = $"���� {GetIntValue("goods")}�� �ر�";
        PopUPText.text = "���� " + data_Dialog[nextRank]["rank"].ToString() + "(��)�� �±��Ͻðڽ��ϱ�?";
        PopUPNotice.text = "�±޽�" + data_Dialog[nextRank]["rank_gold"].ToString() + "��尡 �Ҹ�˴ϴ�.";
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
