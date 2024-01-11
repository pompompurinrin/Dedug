using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System;


public class RankManager : MonoBehaviour
{
    // UI ��ҵ�
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

    // sprite ����
    public Sprite Rank1;
    public Sprite Rank2;
    public Sprite Rank3;

    // ���� ȿ�� �� ����� ��Ÿ���� �ؽ�Ʈ��
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
    
    private void Awake()
    {
        DataManager.Instance.nowGold = PlayerPrefs.GetInt("NowGold");
        DataManager.Instance.nowRank = PlayerPrefs.GetInt("NowRank");
        DataManager.Instance.goods3011 = PlayerPrefs.GetInt("Goods3011");
       
    }
    private void Start()
    {
        // �ʱ�ȭ �� �ʿ��� ���� ������ �ε�
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


        // CSV ���Ͽ��� ������ �б�
        data_Dialog = CSVReader.Read(RankSampleFileName);

        // ��ũ ���� ���� �� ��� Ȯ��
        SetupRankInfo();
        UnlockCheck();

    }

    private void SetupRankInfo()
    {
        if (DataManager.Instance.nowRank >= 0 && DataManager.Instance.nowRank < data_Dialog.Count)
        {
            // ���� ��ũ�� ���� ��ũ�� ���� ����
            NowRankName.text = data_Dialog[DataManager.Instance.nowRank]["rank"].ToString();
            NextRankName.text = data_Dialog[nextRank]["rank"].ToString();

            // ���� ȿ�� �� ��� �ؽ�Ʈ ����
            PlusGuestState.text = $"Ŀ�̼� ���� �մ� {GetIntValue("guest")}�� ���";
            PlusGoldState.text = $"Ŀ�̼� 1ȸ�� {GetIntValue("goldplus")}��� ���";
            PlusFeverTime.text = $"�ǹ�Ÿ�� ���ѽð� {GetIntValue("time")}�� ���";
            PlusGoods.text = $"���� {GetIntValue("goods")}�� �ر�";

        }
        else
        {
            // ���� ��ũ�� ���� ��ũ�� ���� ����
            NowRankName.text = data_Dialog[DataManager.Instance.nowRank]["rank"].ToString();
            NextRankName.text = " ����� �̹� �����Դϴ� ";

            // ���� ȿ�� �� ��� �ؽ�Ʈ ����
            PlusGuestState.text = "�����մϴ�!";
            PlusGoldState.text = "����� ��Ÿ����";
            PlusFeverTime.text = "������ �ö����ϴ�!";
            PlusGoods.text = "�̹� �ְ� ��޿� �����߽��ϴ�!";
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
        // CSV �����Ϳ��� Ư�� Ű�� �������� �������� �޼���
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

        // �⺻�� ��ȯ
        return 0;
    }

    public void UnlockCheck()
    {
        //���⼭ �����͸Ŵ������� �˻��ϴ� ����� ���� �𸣰���... ���� ���̺� ���� �ٲ� �� ����
        if (DataManager.Instance.nowRank == 0)
        {
            if (DataManager.Instance.goods3011 == 0)
            {
                UnlockGoods.text = "����" + data_Dialog[nextRank]["GoodsName"].ToString() + "�� ȹ���ϸ� �رݵ˴ϴ�.";
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
                UnlockGoods.text = "����" + data_Dialog[nextRank]["GoodsName"].ToString() + "�� ȹ���ϸ� �رݵ˴ϴ�.";
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
                RankUPBtn.interactable = true;  // ��ư Ȱ��ȭ
            }
            else
            {
                SpendGoldText.text = $"{DataManager.Instance.nowGold}/{data_Dialog[nextRank]["rank_gold"]}";
                SpendGoldText.color = Color.red;
                RankUPBtn.interactable = false;  // ��ư ��Ȱ��ȭ
            }
        
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
        DataManager.Instance.nowGold -= Convert.ToInt32(data_Dialog[DataManager.Instance.nowRank]["rank_gold"]);

        DataManager.Instance.nowRank++;
        nextRank++;

        if (nextRank >= data_Dialog.Count)
        {
            nextRank = 0; // �Ǵ� �ٸ� �ʱⰪ���� ���� ����
        }

        Save();
        // ��ũ ���� �� ��� �ؽ�Ʈ ������Ʈ
        SetupRankInfo();
        SpendGoldText.text = DataManager.Instance.nowGold.ToString() + "/" + data_Dialog[DataManager.Instance.nowRank]["rank_gold"].ToString();
        
        imageFileName = data_Dialog[DataManager.Instance.nowRank]["ResultImg"].ToString();
        ResultChr.sprite = Resources.Load<Sprite>(imageFileName);

        //GameObject effectInstance = Instantiate(effectPrefab, ResultChr.transform.position, Quaternion.identity);

        // Vector3 newPosition = effectPrefab.transform.position;
         //  newPosition.z = 2f;
        //effectPrefab.transform.position = newPosition;

        // ������ ũ�� ����
        // Vector3 desiredScale = new Vector3(0.9f, 0.9f, 0.9f);  
        //effectInstance.transform.localScale = desiredScale;

        ResultPlusGuestState.text = $"Ŀ�̼� ���� �մ� {GetIntValue("guest")}�� ���";
        ResultPlusGoldState.text = $"Ŀ�̼� 1ȸ�� {GetIntValue("goldplus")}��� ���";
        ResultPlusFeverTime.text = $"�ǹ�Ÿ�� ���ѽð� {GetIntValue("time")}�� ���";
        ResultPlusGoods.text = $"���� {GetIntValue("goods")}�� �ر�";
        PopUPText.text = "���� " + data_Dialog[nextRank]["rank"].ToString() + "(��)�� �±��Ͻðڽ��ϱ�?";
        PopUPNotice.text = "�±޽�" + data_Dialog[nextRank]["rank_gold"].ToString() + "��尡 �Ҹ�˴ϴ�.";
        anim.SetTrigger("DoHide");
        RankPopUPBG.gameObject.SetActive(false);
        Result.gameObject.SetActive(true);
        UnlockCheck();
        

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

    public void Save()
    {
        // PlayerPrefs�� ���� �� ����
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