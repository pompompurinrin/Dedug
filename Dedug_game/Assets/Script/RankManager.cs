using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankManager : MonoBehaviour
{
    // UI ��ҵ�
    public Image NowRankImage;
    public Text NowRankName;

    public Image PopUPBG;
    public Image NextRankImage;
    public Text NextRankName;
    public int nextRank;

    // ���� ȿ�� �� ����� ��Ÿ���� �ؽ�Ʈ��
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

    // ���� ������Ʈ �� ĵ���� ���� ����
    private GameObject RankPopUP;
    private Image RankPopUPBG;
    private Canvas Unlock;
    private Canvas Result;

    // �˾� �ؽ�Ʈ �� �ִϸ��̼�
    public Text PopUPText;
    public Text PopUPNotice;
    public Animator anim;

    // CSV ������ �о���� ������ ����Ʈ
    private List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();
    private const string RankSampleFileName = "RankSample";
    private char[] TRIM_CHARS = { ' ', '\"' };
    int NowRank;

    private void Start()
    {
        // �ʱ�ȭ �� �ʿ��� ���� ������ �ε�
        NowGold = DataManager.Instance.NowGold;
        NowRank = DataManager.Instance.NowRank;
        RankPopUPBG = GameObject.Find("RankPopUPBG").GetComponent<Image>();
        Unlock = GameObject.Find("UnlockCanvas").GetComponent<Canvas>();
        Result = GameObject.Find("ResultCanvas").GetComponent<Canvas>();

        anim = GameObject.Find("RankPopUPGroup").GetComponent<Animator>();

        RankPopUPBG.gameObject.SetActive(false);
        Unlock.gameObject.SetActive(false);
        Result.gameObject.SetActive(false);

       
        // CSV ���Ͽ��� ������ �б�
        data_Dialog = CSVReader.Read(RankSampleFileName);

        // ��ũ ���� ���� �� ��� Ȯ��
        SetupRankInfo();
        UnlockCheck();
        
    }

    private void SetupRankInfo()
    {
        // ���� ��ũ�� ���� ��ũ�� ���� ����
        NowRankName.text = data_Dialog[NowRank]["rank"].ToString();
        NextRankName.text = data_Dialog[nextRank]["rank"].ToString();

        // ���� ȿ�� �� ��� �ؽ�Ʈ ����
        PlusGuestState.text = $"Ŀ�̼� ���� �մ� {GetIntValue("guest")}�� ���";
        PlusGoldState.text = $"Ŀ�̼� 1ȸ�� {GetIntValue("goldplus")}��� ���";
        PlusFeverTime.text = $"�ǹ�Ÿ�� ���ѽð� {GetIntValue("time")}�� ���";
        PlusGoods.text = $"���� {GetIntValue("goods")}�� �ر�";
        SpendGoldText.text = NowGold.ToString() + "/" + data_Dialog[NowRank]["rank_gold"].ToString();
    }

    private int GetIntValue(string key)
    {
        // CSV �����Ϳ��� Ư�� Ű�� �������� �������� �޼���
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
        // ��� ���� Ȯ���ϴ� �޼��� (���� �������� ����)
    }

    public void RankPopUPClick()
    {
        // ��ũ �˾� Ŭ�� �� ȣ��Ǵ� �޼���
        PopUPText.text = "���� " + data_Dialog[nextRank]["rank"].ToString() + "(��)�� �±��Ͻðڽ��ϱ�?";
        PopUPNotice.text = "�±޽�" + data_Dialog[nextRank]["rank_gold"].ToString() + "��尡 �Ҹ�˴ϴ�.";
        RankPopUPBG.gameObject.SetActive(true);
        anim.SetTrigger("DoShow");
    }

    public void RankPopUPClickConfirm()
    {
        // ��ũ �˾� Ȯ�� Ŭ�� �� ȣ��Ǵ� �޼���
        NowGold -= GetIntValue("rank_gold");

        NowRank++;
        nextRank++;

        if (nextRank >= data_Dialog.Count)
        {
            nextRank = 0; // �Ǵ� �ٸ� �ʱⰪ���� ���� ����
        }

        // ��ũ ���� �� ��� �ؽ�Ʈ ������Ʈ
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
        // ��ũ �˾� ���� Ŭ�� �� ȣ��Ǵ� �޼���
        anim.SetTrigger("DoHide");
        RankPopUPBG.gameObject.SetActive(false);
    }

    public void ResultExitClick()
    {
        // ��� â ���� Ŭ�� �� ȣ��Ǵ� �޼���
        Result.gameObject.SetActive(false);
        RankPopUPBG.gameObject.SetActive(false);
    }
    
}