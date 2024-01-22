using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;
using System.Collections;


public class RankManager : MonoBehaviour
{
    // UI ��ҵ�
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

    // sprite ����
    public Sprite Rank1;
    public Sprite Rank2;
    public Sprite Rank3;

    // ���� ȿ�� �� ����� ��Ÿ���� �ؽ�Ʈ��
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
        Debug.Log("�±�:" + DataManager.Instance.goods1011);
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
        ClickTouchBtn.gameObject.SetActive(false);
        _effectPrefab.gameObject.SetActive(false);
        // CSV ���Ͽ��� ������ �б�
        data_Dialog = CSVReader.Read(RankFileName);

        bgm1AudioSource.loop = true;
        bgm1AudioSource.Play();

        // BGM2 ����
        bgm2AudioSource.Stop();
        sfx1AudioSource.Stop();
        sfx2AudioSource.Stop();


        // ��ũ ���� ���� �� ��� Ȯ��
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
            // ���� ��ũ�� ���� ��ũ�� ���� ����
            NowRankName.text = data_Dialog[DataManager.Instance.nowRank]["RankName"].ToString();
            NextRankName.text = "���ڱ�";

            // ���� ȿ�� �� ��� �ؽ�Ʈ ����
            PlusGuestState.text = "�����մϴ�!";
            PlusFeverTime.text = "����� ��Ÿ����";
            PlusGoods.text = "������ �ö����ϴ�!";

            NowimageFileName = data_Dialog[DataManager.Instance.nowRank]["MainImage"].ToString();
            NextimageFileName = data_Dialog[nextRank]["MainImage"].ToString();
            NowRankImage.sprite = Resources.Load<Sprite>(NowimageFileName);
            NextRankImage.sprite = Resources.Load<Sprite>(NextimageFileName);

        }
        else if (DataManager.Instance.nowRank >= 0 && DataManager.Instance.nowRank < data_Dialog.Count)
        {
            // ���� ��ũ�� ���� ��ũ�� ���� ����
            NowRankName.text = data_Dialog[DataManager.Instance.nowRank]["RankName"].ToString();
            NextRankName.text = data_Dialog[nextRank]["RankName"].ToString();

            // ���� ȿ�� �� ��� �ؽ�Ʈ ����
            PlusGuestState.text = "Ŀ�̼� ���� �մ� " + data_Dialog[nextRank]["GuestPlus"].ToString() + "�� ���";
            PlusFeverTime.text = $"�ǹ�Ÿ�� ���ѽð� " + data_Dialog[nextRank]["GuestPlus"].ToString()+ "�� ���";
            PlusGoods.text = $"���� ���� ȹ�� Ȯ�� ���";

            NowimageFileName = data_Dialog[DataManager.Instance.nowRank]["MainImage"].ToString();
            NextimageFileName = data_Dialog[nextRank]["MainImage"].ToString();
            NowRankImage.sprite = Resources.Load<Sprite>(NowimageFileName);
            NextRankImage.sprite = Resources.Load<Sprite>(NextimageFileName);

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
            if (DataManager.Instance.goods1011 == 0)
            {
                //UnlockGoods.text = "����" + data_Dialog[nextRank]["Ranktest"].ToString() + "�� ȹ���ϸ� �رݵ˴ϴ�.";
                UnlockGoods.text = "���� '���� ��Ȧ��'�� ȹ���ϸ� �رݵ˴ϴ�.";
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
                UnlockGoods.text = "���� '�ٴ� LȦ��'�� ȹ���ϸ� �رݵ˴ϴ�.";
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
                UnlockGoods.text = "���� '�ʷ� ��ũ�� ���ĵ�'�� ȹ���ϸ� �رݵ˴ϴ�.";
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
                UnlockGoods.text = "���� '�ٴ� ���ǽ�Ʈ��'�� ȹ���ϸ� �رݵ˴ϴ�.";
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
            RankUPBtn.interactable = true;  // ��ư Ȱ��ȭ
        }
        else
        {
            SpendGoldText.text = $"{DataManager.Instance.nowGold}/{data_Dialog[nextRank]["RankGold"]}";
            SpendGoldText.color = Color.red;
            RankUPBtn.interactable = false;  // ��ư ��Ȱ��ȭ
        }

        if (DataManager.Instance.nowRank >= 4)
        {
            SpendGoldText.text = $"�ְ� ��� �޼�!";
            SpendGoldText.color = Color.red;
            RankUPBtn.interactable = false;
        }

    }

    public void RankPopUPClick()
    {
        // ��ũ �˾� Ŭ�� �� ȣ��Ǵ� �޼���
        PopUPText.text = "���� " + data_Dialog[nextRank]["RankName"].ToString() + "(��)�� �±��Ͻðڽ��ϱ�?";
        PopUPNotice.text = "�±޽�" + data_Dialog[nextRank]["RankGold"].ToString() + "��尡 �Ҹ�˴ϴ�.";
        RankPopUPBG.gameObject.SetActive(true);
        anim.SetTrigger("DoShow");
    }
    

    public void RankPopUPClickConfirm()
    {
        // BGM1 Pause
        bgm1AudioSource.Pause();

        // BGM2 �÷���
        bgm2AudioSource.loop = true;
        bgm2AudioSource.Play();

        // ��ũ �˾� Ȯ�� Ŭ�� �� ȣ��Ǵ� �޼���
        DataManager.Instance.nowGold -= Convert.ToInt32(data_Dialog[nextRank]["RankGold"]);

        DataManager.Instance.nowRank++;
        nextRank++;


        Save();
        // ��ũ ���� �� ��� �ؽ�Ʈ ������Ʈ
        SetupRankInfo();
        SpendGoldText.text = DataManager.Instance.nowGold.ToString() + "/" + data_Dialog[DataManager.Instance.nowRank]["RankGold"].ToString();

        NowimageFileName = data_Dialog[DataManager.Instance.nowRank]["MainImage"].ToString();
        ResultChr.sprite = Resources.Load<Sprite>(NowimageFileName);


        //GameObject effectInstance = Instantiate(effectPrefab, ResultChr.transform.position, Quaternion.identity);

        // Vector3 newPosition = effectPrefab.transform.position;
        //  newPosition.z = 2f;
        //effectPrefab.transform.position = newPosition;

        // ������ ũ�� ����
        // Vector3 desiredScale = new Vector3(0.9f, 0.9f, 0.9f);  
        //effectInstance.transform.localScale = desiredScale;
        NowRankName2.text = data_Dialog[DataManager.Instance.nowRank]["RankName"].ToString();

        ResultPlusGuestState.text = $"Ŀ�̼� ���� �մ� {GetIntValue("GuestPlus")}�� ���";
       
        ResultPlusFeverTime.text = $"�ǹ�Ÿ�� ���ѽð� {GetIntValue("FeverTimePlus")}�� ���";
        ResultPlusGoods.text = $"���� ���� ȹ�� Ȯ�� ���";
        PopUPText.text = "���� " + data_Dialog[nextRank]["RankName"].ToString() + "(��)�� �±��Ͻðڽ��ϱ�?";
        PopUPNotice.text = "�±޽�" + data_Dialog[nextRank]["RankGold"].ToString() + "��尡 �Ҹ�˴ϴ�.";
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
        // SFX2 �÷���
        sfx2AudioSource.Play();

        Sequence buttonSequence = DOTween.Sequence();

        // ��ư�� ���� ������ �� ���̵� �ִϸ��̼� �߰�
        ClickTouchBtn.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f);
        ClickTouchBtn.image.DOFade(0f, 2f);

        // ����Ʈ�� ���� ������ �� ���̵� �ִϸ��̼� �߰�
        GameObject effectInstance = Instantiate(EffectPrefab, ClickTouchBtn.transform.position, Quaternion.identity);
        effectInstance.transform.SetParent(ClickTouchBtn.transform.parent);  // ����Ʈ�� �θ� ��ư�� �θ�� ����

        Sequence effectSequence = DOTween.Sequence();
        effectSequence.Append(effectInstance.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f));
        effectSequence.Join(effectInstance.GetComponent<Image>().DOFade(0f, 2f));

        // ��ư �� ����Ʈ �ִϸ��̼� ������ ���
        buttonSequence.Play();
        effectSequence.Play();
        _effectPrefab.gameObject.SetActive(false);

        // ResultCanvas�� �����ʿ��� �������� 0.2�� ���� �ε巴�� �̵�
        RectTransform resultRectTransform = Result.GetComponent<RectTransform>();
        resultRectTransform.DOAnchorPosX(0f, 0.2f).OnComplete(() =>
        {
            // �ִϸ��̼��� �Ϸ�Ǹ� ����� �ڵ�
            // Ŭ�� ��ư�� �ٽ� �ʱ� ���¿��� FadeIn �� ���� ũ��� �ִϸ��̼�
            ClickTouchBtn.image.DOFade(1f, 0f); // FadeIn
            ClickTouchBtn.transform.DOScale(Vector3.one, 0f); // ���� ũ��� ����

            // 2�� �ڿ� ClickTouchBtn�� �ٽ� Ŭ�� �����ϵ��� ����
            DOVirtual.DelayedCall(2f, () =>
            {
                ClickTouchBtn.gameObject.SetActive(false);
                effectInstance.gameObject.SetActive(false);
            });
        });
    }


    public void RankPopUPExitClick()
    {
        // ��ũ �˾� ���� Ŭ�� �� ȣ��Ǵ� �޼���
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
        // ��� â ���� Ŭ�� �� ȣ��Ǵ� �޼���
        Result.gameObject.SetActive(false);
        RankPopUPBG.gameObject.SetActive(false);
        
        bgm2AudioSource.Stop();
        // BGM1 �÷���
        bgm1AudioSource.UnPause();

        // ���⼭ ���� ���·� �ʱ�ȭ �Ǵ� �ٸ� �ʱ�ȭ �۾� ����
        // ���� ���, ResultCanvas�� �����ʿ��� �������� �̵��ϴ� �ִϸ��̼� �ʱ�ȭ
        RectTransform resultRectTransform = Result.GetComponent<RectTransform>();
        resultRectTransform.anchoredPosition = new Vector2(Screen.width, 0);
        ClickTouchBtn.image.DOFade(1f, 0f); // FadeIn
        ClickTouchBtn.transform.DOScale(Vector3.one, 0f);

    }

    public void Save()
    {
        // PlayerPrefs�� ���� �� ����
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