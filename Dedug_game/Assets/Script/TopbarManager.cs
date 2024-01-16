 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopbarManager : MonoBehaviour
{

    int NowGold;
    int NowRank;
    string Goods3;
    int FeverNum;

    public Text GoldAmountText;
    public Text NowRankName;
    public Image NowRankImage;

    public GameObject SettingPopCanvas;
    public GameObject MenuUI;
    public GameObject GoodsBuy;
    public GameObject GamePopups;
    public GameObject GanbareBada;
    public GameObject GoldLack;

    public AudioSource bgm1AudioSource;
    public AudioSource sfx1AudioSource;

    public string NowimageFileName;




    Dictionary<int, Sprite> rankDic = new Dictionary<int, Sprite>();
    public Sprite[] rankImg;
    

    // CSV ������ �о���� ������ ����Ʈ
    private List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();
    private const string RankFileName = "RankTable";
    private char[] TRIM_CHARS = { ' ', '\"' };

    public void TopBar()
    {
        if (GoldAmountText != null)
        {

            GoldAmountText.text = DataManager.Instance.nowGold.ToString();
        }
        if (NowRankName != null)
        {

            NowRankName.text = data_Dialog[DataManager.Instance.nowRank]["RankName"].ToString();
        }

        if (NowRankImage != null)
        {

            NowRankImage.sprite = rankDic[NowRank];
        }

    }

    public void Save()
    {
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        PlayerPrefs.Save();
    }

    private void Awake()
    {
        DataManager.Instance.nowGold = PlayerPrefs.GetInt("NowGold");
        DataManager.Instance.nowRank = PlayerPrefs.GetInt("NowRank");
        NowRankImage = GameObject.Find("GradeImg").GetComponent<Image>();
        

    }

    private void Update()
    {
        GoldAmountText.text = DataManager.Instance.nowGold.ToString();
        NowRankName.text = data_Dialog[DataManager.Instance.nowRank]["RankName"].ToString();
        NowimageFileName = data_Dialog[DataManager.Instance.nowRank]["MainImage"].ToString();
        NowRankImage.sprite = Resources.Load<Sprite>(NowimageFileName);
       
        
    }

    void Start()
    {
       
        

        RankImage();
        RankSetupInfo();

        GameObject MenuUI = GameObject.Find("MenuUI");
        GameObject SettingPopupCanvas = GameObject.Find("SettingPopupCanvas");
        GameObject GamePopups = GameObject.Find("GamePopups");
        GameObject GoldLack = GameObject.Find("GoldLack");


        if (MenuUI != null)
        {
            if (MenuUI.activeSelf)
            {
                MenuUI.SetActive(false);
            }

        }

        if (SettingPopupCanvas != null)
        {
            if (SettingPopupCanvas.activeSelf)
            {
                SettingPopupCanvas.SetActive(false);
            }


        }

        if (GamePopups != null)
        {
            if (GamePopups.activeSelf)
            {
                GamePopups.SetActive(false);
            }


        }

        if (GoldLack != null)
        {
            if (GoldLack.activeSelf)
            {
                GoldLack.SetActive(false);
            }


        }



    }

    public void PlaySFX1()
    {
        sfx1AudioSource.Play();
    }
    public void StopBGM1()
    {
        bgm1AudioSource.Stop();
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

    void RankSetupInfo()
    {
        data_Dialog = CSVReader.Read(RankFileName);

        TopBar();
    }

    
    // Start is called before the first frame update
    public void RankImage()
    {

        for (int i = 0; i < rankImg.Length; i++)
        {
            rankDic.Add(i, rankImg[i]);

        }

    }

    public void OnButtonClick_SettingPopup()
    {
        // ���� �˾��� Ȱ��ȭ

        SettingPopCanvas.SetActive(true);
    }

    public void OnButtonClick_OffSettingPopup()
    {
        //���� �˾��� ��Ȱ��ȭ

        SettingPopCanvas.SetActive(false);
    }
    public void OnButtonClick_MenuUI()
    {
        // �޴� �˾��� Ȱ��ȭ

        MenuUI.SetActive(true);
    }

    public void OnButtonClick_OffMenuUI()
    {
        // �޴� �˾��� ��Ȱ��ȭ

        MenuUI.SetActive(false);
    }

    public void OnButtonClick_OffGoodsBuy()
    {
        // ���� ���� �˾� ��Ȱ��ȭ
        GoodsBuy.SetActive(false);
    }

    public void OnButtonClick_OnGanbare()
    {
        // ���ٷ� �ٴ�¯ �˾� Ȱ��ȭ
         GamePopups.SetActive(true);
         GanbareBada.SetActive(true);
    }

    public void OnButtonClick_OffGanbare()
    {
        // ���ٷ� �ٴ�¯ �˾� ��Ȱ��ȭ
        GamePopups.SetActive(false);
        GanbareBada.SetActive(false);
    }
    
    public void Click_GanbareBadaStart()
    {
        if (DataManager.Instance.nowGold >= 100)
        {
            DataManager.Instance.nowGold = DataManager.Instance.nowGold -100;
            TopBar();
            Save();
            SceneManager.LoadScene("YJMiniGameScene");
        }
       else if (DataManager.Instance.nowGold < 100)
        {
            GoldLack.SetActive(true);
        }
    }
    public void Click_OffGoldLack()
    {
        GoldLack.SetActive(false);
    }
    
    public void Click_Commision()
    {
        Save();
        SceneManager.LoadScene("RequestScene");
    }
    
    public void Click_Collection()
    {
        Save();
        SceneManager.LoadScene("DG_Scene");
    }

    public void Click_RankUP()
    {
        Save();
        SceneManager.LoadScene("RankScene");
    }
    public void Click_Home()
    {
        Save();
        SceneManager.LoadScene("HomeScene");
    }

}


