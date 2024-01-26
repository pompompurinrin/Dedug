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
    public Text NowRankNum;
    public Image NowRankImage;

    public Text PopupRankName;
    public Text PopupRankNum;
    public Image PopupRankImage;


    public GameObject SettingPopCanvas;
    public GameObject Credit;
    public GameObject MenuUI;
    public GameObject HelpUI;
    public GameObject HelpPopup;
    public GameObject ProfilePopup;
    
    //���� ���� �˾�
    public GameObject HomePopup;
    public GameObject CollectionPopup;
    public GameObject CommisionPopup;
    public GameObject OtakuPopup;
    public GameObject RankupPopup;

    //���� �˾�
    public GameObject SpecificPopup;

    public GameObject HelpTopbarPopup;
    public GameObject HelpMenuPopup;
    public GameObject HelpCharacterPopup;
    public GameObject HelpGoodsPopup;
    public GameObject HelpStoryPopup;
    public GameObject HelpUserImgPopup;
    public GameObject HelpCustomerPopup;
    public GameObject HelpFevertimePopup;
    public GameObject HelpHelpPopup;
    public GameObject HelpMinigamePopup;
    public GameObject HelpGradeinfoPopup;
    public GameObject HelpGradeconditonPopup;

    public AudioSource sfx1AudioSource;
    public AudioSource bgm1AudioSource;



    public string NowimageFileName;




    Dictionary<int, Sprite> rankDic = new Dictionary<int, Sprite>();
    public Sprite[] rankImg;
    

    // CSV ������ �о���� ������ ����Ʈ
    private List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();
    private const string RankFileName = "RankTable";
    private char[] TRIM_CHARS = { ' ', '\"' };
    
    public void Awake()
    {
        DataManager.Instance.goods1011 = PlayerPrefs.GetInt("Goods1011");
        DataManager.Instance.goods1012 = PlayerPrefs.GetInt("Goods1012");
        DataManager.Instance.goods1021 = PlayerPrefs.GetInt("Goods1021");
        DataManager.Instance.goods1022 = PlayerPrefs.GetInt("Goods1022");
        DataManager.Instance.goods1031 = PlayerPrefs.GetInt("Goods1031");
        DataManager.Instance.goods1032 = PlayerPrefs.GetInt("Goods1032");
        DataManager.Instance.goods1041 = PlayerPrefs.GetInt("Goods1041");
        DataManager.Instance.goods1042 = PlayerPrefs.GetInt("Goods1042");
        DataManager.Instance.goods1051 = PlayerPrefs.GetInt("Goods1051");
        DataManager.Instance.goods1052 = PlayerPrefs.GetInt("Goods1052");

        DataManager.Instance.goods2011 = PlayerPrefs.GetInt("Goods2011");
        DataManager.Instance.goods2012 = PlayerPrefs.GetInt("Goods2012");
        DataManager.Instance.goods2021 = PlayerPrefs.GetInt("Goods2021");
        DataManager.Instance.goods2022 = PlayerPrefs.GetInt("Goods2022");
        DataManager.Instance.goods2031 = PlayerPrefs.GetInt("Goods2031");
        DataManager.Instance.goods2032 = PlayerPrefs.GetInt("Goods2032");
        DataManager.Instance.goods2041 = PlayerPrefs.GetInt("Goods2041");
        DataManager.Instance.goods2042 = PlayerPrefs.GetInt("Goods2042");
        DataManager.Instance.goods2051 = PlayerPrefs.GetInt("Goods2051");
        DataManager.Instance.goods2052 = PlayerPrefs.GetInt("Goods2052");

        DataManager.Instance.goods3011 = PlayerPrefs.GetInt("Goods3011");
        DataManager.Instance.goods3012 = PlayerPrefs.GetInt("Goods3012");
        DataManager.Instance.goods3021 = PlayerPrefs.GetInt("Goods3021");
        DataManager.Instance.goods3022 = PlayerPrefs.GetInt("Goods3022");
        DataManager.Instance.goods3031 = PlayerPrefs.GetInt("Goods3031");
        DataManager.Instance.goods3032 = PlayerPrefs.GetInt("Goods3032");
        DataManager.Instance.goods3041 = PlayerPrefs.GetInt("Goods3041");
        DataManager.Instance.goods3042 = PlayerPrefs.GetInt("Goods3042");
        DataManager.Instance.goods3051 = PlayerPrefs.GetInt("Goods3051");
        DataManager.Instance.goods3052 = PlayerPrefs.GetInt("Goods3052");

        DataManager.Instance.goods4051 = PlayerPrefs.GetInt("Goods4051");
        DataManager.Instance.goods4052 = PlayerPrefs.GetInt("Goods4052");
        DataManager.Instance.goods4053 = PlayerPrefs.GetInt("Goods4053");
        DataManager.Instance.goods4054 = PlayerPrefs.GetInt("Goods4054");
        DataManager.Instance.goods4055 = PlayerPrefs.GetInt("Goods4055");
        DataManager.Instance.goods4056 = PlayerPrefs.GetInt("Goods4056");
        DataManager.Instance.goods4057 = PlayerPrefs.GetInt("Goods4057");
        DataManager.Instance.goods4058 = PlayerPrefs.GetInt("Goods4058");
        DataManager.Instance.goods4059 = PlayerPrefs.GetInt("Goods4059");
        DataManager.Instance.goods4060 = PlayerPrefs.GetInt("Goods4060");

        DataManager.Instance.nowRank = PlayerPrefs.GetInt("NowRank");
        DataManager.Instance.nowGold = PlayerPrefs.GetInt("NowGold");
        DataManager.Instance.feverNum = PlayerPrefs.GetInt("FeverNum");
        DataManager.Instance.storyID = PlayerPrefs.GetInt("StoryID");
        DataManager.Instance.first = PlayerPrefs.GetInt("First");

        DataManager.Instance.bgm = PlayerPrefs.GetInt("BGM");
        DataManager.Instance.sfx = PlayerPrefs.GetInt("SFX");

        NowRankImage = GameObject.Find("GradeImg").GetComponent<Image>();
    }
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

        if (PopupRankName != null)
        {
            PopupRankName.text = data_Dialog[DataManager.Instance.nowRank]["RankName"].ToString();
        }

        if (PopupRankImage != null)
        {
            PopupRankImage.sprite = rankDic[NowRank];
        }

    }




    private void Update()
    {
        GoldAmountText.text = DataManager.Instance.nowGold.ToString();
        NowRankName.text = data_Dialog[DataManager.Instance.nowRank]["RankName"].ToString();
        NowimageFileName = data_Dialog[DataManager.Instance.nowRank]["MainImage"].ToString();
        NowRankImage.sprite = Resources.Load<Sprite>(NowimageFileName);
        NowRankNum.text = "Rank. " + data_Dialog[DataManager.Instance.nowRank]["RankNum"].ToString();
        
        PopupRankName.text = data_Dialog[DataManager.Instance.nowRank]["RankName"].ToString();
        PopupRankImage.sprite = Resources.Load<Sprite>(NowimageFileName);
        PopupRankNum.text = "Rank. " + data_Dialog[DataManager.Instance.nowRank]["RankNum"].ToString();
    }

    void Start()
    {
       
        
        data_Dialog = CSVReader.Read(RankFileName);
        RankImage();
        RankSetupInfo();
        
         GameObject MenuUI = GameObject.Find("MenuUI");
        GameObject SettingPopupCanvas = GameObject.Find("SettingPopupCanvas");
        GameObject HelpUI = GameObject.Find("HelpUI");
        GameObject PopupCanvas = GameObject.Find("PopupCanvas");

        if (DataManager.Instance.sfx == 0)
        {
            
            sfxOff.gameObject.SetActive(false);
        }
        else if (DataManager.Instance.sfx == 1)
        {
            sfxOff.gameObject.SetActive(true);
        }

        if (DataManager.Instance.bgm == 0)
        {

            bgmOff.gameObject.SetActive(false);
        }
        else if (DataManager.Instance.bgm == 1)
        {
            bgmOff.gameObject.SetActive(true);
        }

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

        if (HelpUI != null)
        {
            if (HelpUI.activeSelf)
            {
                HelpUI.SetActive(false);
            }


        }

        if (PopupCanvas != null)
        {
            if (PopupCanvas.activeSelf)
            {
                PopupCanvas.SetActive(false);
            }


        }

    }

    public GameObject sfxOff;
    public GameObject bgmOff;

    public AudioManager audioManager;

    public bool isSoundPlaying = false;

    public void ClickSFX()
    {
        sfx1AudioSource.Play();
    }
    public void PlaySFX()
    {
        ClickSFX();
        if (DataManager.Instance.sfx == 0)
        {
            DataManager.Instance.sfx = 1;
            sfxOff.gameObject.SetActive(true);
        }
        else if(DataManager.Instance.sfx == 1)
        {
            DataManager.Instance.sfx = 0;
            sfxOff.gameObject.SetActive(false);
        }
        Save();

    }
    public void PlayBGM()
    {
        ClickSFX();
        if (DataManager.Instance.bgm == 0)
        {
            DataManager.Instance.bgm = 1;
            bgmOff.gameObject.SetActive(true);
        } 

        else if (DataManager.Instance.bgm == 1)        
        {
            DataManager.Instance.bgm = 0;
            bgmOff.gameObject.SetActive(false);
        }
        Save();
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
        ClickSFX();
        // ���� �˾��� Ȱ��ȭ
        SettingPopCanvas.SetActive(true);
    }

    public void OnButtonClick_OffSettingPopup()
    {
        ClickSFX();
        //���� �˾��� ��Ȱ��ȭ
        SettingPopCanvas.SetActive(false);
    }
    public void OnButtonClick_MenuUI()
    {
        ClickSFX();
        // �޴� �˾��� Ȱ��ȭ
        MenuUI.SetActive(true);
    }

    public void OnButtonClick_OffMenuUI()
    {
        ClickSFX();
        // �޴� �˾��� ��Ȱ��ȭ
        MenuUI.SetActive(false);
    }

    public void OnButtonClick_OnHelpUI()
    {
        ClickSFX();
        // ���� UI Ȱ��ȭ
        HelpUI.SetActive(true);
    }
    public void OnButtonClick_OffHelpUI()
    {
        ClickSFX();
        // ���� UI ��Ȱ��ȭ
        HelpUI.SetActive(false);
    }
    public void OnButtonClick_OnCredit()
    {
        ClickSFX();
        // ���� UI Ȱ��ȭ
        Credit.SetActive(true);
    }
    public void OnButtonClick_OffCredit()
    {
        ClickSFX();
        // ���� UI ��Ȱ��ȭ
        Credit.SetActive(false);
    }

    public void OnButtonClick_OnProfilePopup()
    {
        ClickSFX();
        //������ �˾� Ȱ��ȭ
        ProfilePopup.SetActive(true);
    }


    public void OnButtonClick_OffProfilePopup()
    {
        ClickSFX();
        //������ �˾� ��Ȱ��ȭ
        ProfilePopup.SetActive(false);
    }
    // ���� ���� �˾�

    public void OnButtonClick_OnHomePopup()
    {
        ClickSFX();
        // Ȩ �˾� Ȱ��ȭ
        HomePopup.SetActive(true);    
    }

    public void OnButtonClick_OffHomePopup()
    {
        ClickSFX();
        // Ȩ �˾� ��Ȱ��ȭ
        HomePopup.SetActive(false);
    }

    public void OnButtonClick_OnCollectionPopup()
    {
        ClickSFX();
        // ���� �˾� Ȱ��ȭ
        CollectionPopup.SetActive(true);
    }

    public void OnButtonClick_OffCollectionPopup()
    {
        ClickSFX();
        // ���� �˾� ��Ȱ��ȭ
        CollectionPopup.SetActive(false);
    }

    public void OnButtonClick_OnCommisionPopup()
    {
        ClickSFX();
        // Ŀ�̼� �˾� Ȱ��ȭ
        CommisionPopup.SetActive(true);
    }

    public void OnButtonClick_OffCommisionPopup()
    {
        ClickSFX();
        // Ŀ�̼� �˾� ��Ȱ��ȭ
        CommisionPopup.SetActive(false);
    }

    public void OnButtonClick_OnOtakuPopup()
    {
        ClickSFX();
        // ���� �˾� Ȱ��ȭ
        OtakuPopup.SetActive(true);
    }

    public void OnButtonClick_OffOtakuPopup()
    {
        ClickSFX();
        // ���� �˾� ��Ȱ��ȭ
        OtakuPopup.SetActive(false);
    }

    public void OnButtonClick_OnRankupPopup()
    {
        ClickSFX();
        // ���� �˾� Ȱ��ȭ
        RankupPopup.SetActive(true);
    }

    public void OnButtonClick_OffRankupPopup()
    {
        ClickSFX();
        // ���� �˾� ��Ȱ��ȭ
        RankupPopup.SetActive(false);
    }

    

    public void OnButtonClick_OffAllMenuPopup()
    {
        ClickSFX();
        HelpUI.SetActive(false);
        HomePopup.SetActive(false);
        CollectionPopup.SetActive(false);
        CommisionPopup.SetActive(false);
        OtakuPopup.SetActive(false);
        RankupPopup.SetActive(false);
    }

    //���� �˾�
    public void OnButtonClick_OnHelpTopbarPopup()
    {
        ClickSFX();
        // ž�� ���� �˾� Ȱ��ȭ
        SpecificPopup.SetActive(true);
        HelpTopbarPopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpTopbarPopup()
    {
        ClickSFX();
        // ž�� ���� �˾� ��Ȱ��ȭ
        SpecificPopup.SetActive(false);
        HelpTopbarPopup.SetActive(false);
    }

    public void OnButtonClick_OnHelpMenuPopup()
    {
        ClickSFX();
        // �޴� ���� �˾� Ȱ��ȭ
        SpecificPopup.SetActive(true);
        HelpMenuPopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpMenuPopup()
    {
        ClickSFX();
        // �޴� ���� �˾� ��Ȱ��ȭ
        SpecificPopup.SetActive(false);
        HelpMenuPopup.SetActive(false);
    }

    public void OnButtonClick_OnHelpCharacterPopup()
    {
        ClickSFX();
        // ĳ���� ���� �˾� Ȱ��ȭ
        SpecificPopup.SetActive(true);
        HelpCharacterPopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpCharacterPopup()
    {
        ClickSFX();
        // ĳ���� ���� �˾� ��Ȱ��ȭ
        SpecificPopup.SetActive(false);
        HelpCharacterPopup.SetActive(false);
    }

    public void OnButtonClick_OnHelpGoodsPopup()
    {
        ClickSFX();
        // ���� ���� �˾� Ȱ��ȭ
        SpecificPopup.SetActive(true);
        HelpGoodsPopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpGoodsPopup()
    {
        ClickSFX();
        // ���� ���� �˾� ��Ȱ��ȭ
        SpecificPopup.SetActive(false);
        HelpGoodsPopup.SetActive(false);
    }

    public void OnButtonClick_OnHelpStoryPopup()
    {
        ClickSFX();
        // ���丮 ���� �˾� Ȱ��ȭ
        SpecificPopup.SetActive(true);
        HelpStoryPopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpStoryPopup()
    {
        ClickSFX();
        // ���丮 ���� �˾� ��Ȱ��ȭ
        SpecificPopup.SetActive(false);
        HelpStoryPopup.SetActive(false);
    }

    public void OnButtonClick_OnHelpUserImgPopup()
    {
        ClickSFX();
        // ���� �̹��� ���� �˾� Ȱ��ȭ
        SpecificPopup.SetActive(true);
        HelpUserImgPopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpUserImgPopup()
    {
        ClickSFX();
        // ���� �̹��� ���� �˾� ��Ȱ��ȭ
        SpecificPopup.SetActive(false);
        HelpUserImgPopup.SetActive(false);
    }

    public void OnButtonClick_OnHelpCustomerPopup()
    {
        ClickSFX();
        // �մ� ���� �˾� Ȱ��ȭ
        SpecificPopup.SetActive(true);
        HelpCustomerPopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpCustomerPopup()
    {
        ClickSFX();
        // �մ� ���� �˾� ��Ȱ��ȭ
        SpecificPopup.SetActive(false);
        HelpCustomerPopup.SetActive(false);
    }

    public void OnButtonClick_OnHelpFevertimePopup()
    {
        ClickSFX();
        // �ǹ� Ÿ�� ���� �˾� Ȱ��ȭ
        SpecificPopup.SetActive(true);
        HelpFevertimePopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpFevertimePopup()
    {
        ClickSFX();
        // �ǹ� Ÿ�� ���� �˾� ��Ȱ��ȭ
        SpecificPopup.SetActive(false);
        HelpFevertimePopup.SetActive(false);
    }

    public void OnButtonClick_OnHelpHelpPopup()
    {
        ClickSFX();
        // ���� ���� �˾� Ȱ��ȭ
        SpecificPopup.SetActive(true);
        HelpHelpPopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpHelpPopup()
    {
        ClickSFX();
        // ���� ���� �˾� ��Ȱ��ȭ
        SpecificPopup.SetActive(false);
        HelpHelpPopup.SetActive(false);
    }

    public void OnButtonClick_OnHelpMinigamePopup()
    {
        ClickSFX();
        // �̴ϰ��� ���� �˾� Ȱ��ȭ
        SpecificPopup.SetActive(true);
        HelpMinigamePopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpMinigamePopup()
    {
        ClickSFX();
        // �̴ϰ��� ���� �˾� ��Ȱ��ȭ
        SpecificPopup.SetActive(false);
        HelpMinigamePopup.SetActive(false);
    }

    public void OnButtonClick_OnHelpGradeinfoPopup()
    {
        ClickSFX();
        // ��� �ȳ� ���� �˾� Ȱ��ȭ
        SpecificPopup.SetActive(true);
        HelpGradeinfoPopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpGradeinfoPopup()
    {
        ClickSFX();
        // ��� �ȳ� ���� �˾� ��Ȱ��ȭ
        SpecificPopup.SetActive(false);
        HelpGradeinfoPopup.SetActive(false);
    }

    public void OnButtonClick_OnHelpGradeconditonPopup()
    {
        ClickSFX();
        // �±� ���� ���� �˾� Ȱ��ȭ
        SpecificPopup.SetActive(true);
        HelpGradeconditonPopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpGradeconditonPopup()
    {
        ClickSFX();
        // �±� ���� ���� �˾� ��Ȱ��ȭ
        SpecificPopup.SetActive(false);
        HelpGradeconditonPopup.SetActive(false);
    }

    /*public void OnButtonClick_OnHelpHomePopup()
    {
        // ���� Ȩ �˾� Ȱ��ȭ
        HelpPopup.SetActive(true);
        HelpHomePopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpHomePopup()
    {
        // ���� Ȩ �˾� ��Ȱ��ȭ
        HelpHomePopup.SetActive(false);
    }
    

    public void OnButtonClick_OnHelpCollectionPopup()
    {
        // ���� �ݷ��� �˾� Ȱ��ȭ
        HelpPopup.SetActive(true);
        HelpCollectionPopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpCollectionPopup()
    {
        // ���� �ݷ��� �˾� ��Ȱ��ȭ
        HelpCollectionPopup.SetActive(false);
    }

    public void OnButtonClick_OnHelpCommisionPopup()
    {
        // ���� Ŀ�̼� �˾� Ȱ��ȭ
        HelpPopup.SetActive(true);
        HelpCommisionPopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpCommisionPopup()
    {
        // ���� Ŀ�̼� �˾� ��Ȱ��ȭ
        HelpCommisionPopup.SetActive(false);
    }

    public void OnButtonClick_OnHelpOtakuPopup()
    {
        // ���� ��Ÿ�� �˾� Ȱ��ȭ
        HelpPopup.SetActive(true);
        HelpOtakuPopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpCOtakuPopup()
    {
        // ���� ��Ÿ�� �˾� ��Ȱ��ȭ
        HelpOtakuPopup.SetActive(false);
    }

    public void OnButtonClick_OnHelpRankUPPopup()
    {
        // ���� ��ũ �� �˾� Ȱ��ȭ
        HelpPopup.SetActive(true);
        HelpRankUPPopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpRankUPPopup()
    {
        // ���� ��ũ �� �˾� ��Ȱ��ȭ
        HelpRankUPPopup.SetActive(false);
    }
    */

    public void HomeClick()
    {
        ClickSFX();
        SceneManager.LoadScene("HomeScene");
    }
    
    public void Clear()
    {
        ClickSFX();
        DataManager.Instance.nowRank = 0;
        DataManager.Instance.nowGold = 0;
        DataManager.Instance.feverNum = 0;
        DataManager.Instance.goods1011 = 0;
        DataManager.Instance.goods2011 = 0;
        DataManager.Instance.goods3011 = 0;
        DataManager.Instance.goods1012 = 0;
        DataManager.Instance.goods2012 = 0;
        DataManager.Instance.goods3012 = 0;
        DataManager.Instance.goods1021 = 0;
        DataManager.Instance.goods2021 = 0;
        DataManager.Instance.goods3021 = 0;
        DataManager.Instance.goods1022 = 0;
        DataManager.Instance.goods2022 = 0;
        DataManager.Instance.goods3022 = 0;
        DataManager.Instance.goods1031 = 0;
        DataManager.Instance.goods2031 = 0;
        DataManager.Instance.goods3031 = 0;
        DataManager.Instance.goods1032 = 0;
        DataManager.Instance.goods2032 = 0;
        DataManager.Instance.goods3032 = 0;
        DataManager.Instance.goods1041 = 0;
        DataManager.Instance.goods2041 = 0;
        DataManager.Instance.goods3041 = 0;
        DataManager.Instance.goods1042 = 0;
        DataManager.Instance.goods2042 = 0;
        DataManager.Instance.goods3042 = 0;
        DataManager.Instance.goods1041 = 0;
        DataManager.Instance.goods2041 = 0;
        DataManager.Instance.goods3041 = 0;
        DataManager.Instance.goods1051 = 0;
        DataManager.Instance.goods2051 = 0;
        DataManager.Instance.goods3051 = 0;
        DataManager.Instance.goods1052 = 0;
        DataManager.Instance.goods2052 = 0;
        DataManager.Instance.goods3052 = 0;
        DataManager.Instance.goods4051 = 0;
        DataManager.Instance.goods4052 = 0;
        DataManager.Instance.goods4053 = 0;
        DataManager.Instance.goods4054 = 0;
        DataManager.Instance.goods4055 = 0;
        DataManager.Instance.goods4056 = 0;
        DataManager.Instance.goods4057 = 0;
        DataManager.Instance.goods4058 = 0;
        DataManager.Instance.goods4059 = 0;
        DataManager.Instance.goods4060 = 0;
        DataManager.Instance.story1_1 = 0;
        DataManager.Instance.story1_2 = 0;
        DataManager.Instance.story1_3 = 0;
        DataManager.Instance.story2_1 = 0;
        DataManager.Instance.story2_2 = 0;
        DataManager.Instance.story2_3 = 0;
        DataManager.Instance.story3_1 = 0;
        DataManager.Instance.story3_2 = 0;
        DataManager.Instance.story3_3 = 0;
        DataManager.Instance.story4_1 = 0;
        DataManager.Instance.story4_2 = 0;
        DataManager.Instance.story4_3 = 0;
        DataManager.Instance.storyID = 0;
        DataManager.Instance.first = 0;
        DataManager.Instance.firstHome = 0;
        DataManager.Instance.firstDG = 0;
        DataManager.Instance.firstGoodsBuy = 0;
        DataManager.Instance.firstRequest = 0;
        DataManager.Instance.firstRank = 0;
        DataManager.Instance.ending = 0;
        DataManager.Instance.ending1 = 0;
        DataManager.Instance.sfx = 0;
        DataManager.Instance.bgm = 0;
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        PlayerPrefs.SetInt("NowRank", DataManager.Instance.nowRank);
        PlayerPrefs.SetInt("FeverNum", DataManager.Instance.feverNum);
        PlayerPrefs.SetInt("StoryID", DataManager.Instance.storyID);
        PlayerPrefs.SetInt("Story1_1", DataManager.Instance.story1_1);
        PlayerPrefs.SetInt("Story1_2", DataManager.Instance.story1_2);
        PlayerPrefs.SetInt("Story1_3", DataManager.Instance.story1_2);
        PlayerPrefs.SetInt("Story2_1", DataManager.Instance.story2_1);
        PlayerPrefs.SetInt("Story2_2", DataManager.Instance.story2_2);
        PlayerPrefs.SetInt("Story2_3", DataManager.Instance.story2_2);
        PlayerPrefs.SetInt("Story3_1", DataManager.Instance.story3_1);
        PlayerPrefs.SetInt("Story3_2", DataManager.Instance.story3_2);
        PlayerPrefs.SetInt("Story3_3", DataManager.Instance.story3_3);
        PlayerPrefs.SetInt("Story4_1", DataManager.Instance.story4_1);
        PlayerPrefs.SetInt("Story4_2", DataManager.Instance.story4_2);
        PlayerPrefs.SetInt("Story4_3", DataManager.Instance.story4_3);
        PlayerPrefs.SetInt("Goods1011", DataManager.Instance.goods1011);
        PlayerPrefs.SetInt("Goods1012", DataManager.Instance.goods1012);
        PlayerPrefs.SetInt("Goods1021", DataManager.Instance.goods1021);
        PlayerPrefs.SetInt("Goods1022", DataManager.Instance.goods1022);
        PlayerPrefs.SetInt("Goods1031", DataManager.Instance.goods1031);
        PlayerPrefs.SetInt("Goods1032", DataManager.Instance.goods1032);
        PlayerPrefs.SetInt("Goods1041", DataManager.Instance.goods1041);
        PlayerPrefs.SetInt("Goods1042", DataManager.Instance.goods1042);
        PlayerPrefs.SetInt("Goods1051", DataManager.Instance.goods1051);
        PlayerPrefs.SetInt("Goods1052", DataManager.Instance.goods1052);
        PlayerPrefs.SetInt("Goods2011", DataManager.Instance.goods2011);
        PlayerPrefs.SetInt("Goods2012", DataManager.Instance.goods2012);
        PlayerPrefs.SetInt("Goods2021", DataManager.Instance.goods2021);
        PlayerPrefs.SetInt("Goods2022", DataManager.Instance.goods2022);
        PlayerPrefs.SetInt("Goods2031", DataManager.Instance.goods2031);
        PlayerPrefs.SetInt("Goods2032", DataManager.Instance.goods2032);
        PlayerPrefs.SetInt("Goods2041", DataManager.Instance.goods2041);
        PlayerPrefs.SetInt("Goods2042", DataManager.Instance.goods2042);
        PlayerPrefs.SetInt("Goods2051", DataManager.Instance.goods2051);
        PlayerPrefs.SetInt("Goods2052", DataManager.Instance.goods2052);
        PlayerPrefs.SetInt("Goods3011", DataManager.Instance.goods3011);
        PlayerPrefs.SetInt("Goods3012", DataManager.Instance.goods3012);
        PlayerPrefs.SetInt("Goods3021", DataManager.Instance.goods3021);
        PlayerPrefs.SetInt("Goods3022", DataManager.Instance.goods3022);
        PlayerPrefs.SetInt("Goods3031", DataManager.Instance.goods3031);
        PlayerPrefs.SetInt("Goods3032", DataManager.Instance.goods3032);
        PlayerPrefs.SetInt("Goods3041", DataManager.Instance.goods3041);
        PlayerPrefs.SetInt("Goods3042", DataManager.Instance.goods3042);
        PlayerPrefs.SetInt("Goods3051", DataManager.Instance.goods3051);
        PlayerPrefs.SetInt("Goods3052", DataManager.Instance.goods3052);

        PlayerPrefs.SetInt("Goods4051", DataManager.Instance.goods4051);
        PlayerPrefs.SetInt("Goods4052", DataManager.Instance.goods4052);
        PlayerPrefs.SetInt("Goods4053", DataManager.Instance.goods4053);
        PlayerPrefs.SetInt("Goods4054", DataManager.Instance.goods4054);
        PlayerPrefs.SetInt("Goods4055", DataManager.Instance.goods4055);
        PlayerPrefs.SetInt("Goods4056", DataManager.Instance.goods4056);
        PlayerPrefs.SetInt("Goods4057", DataManager.Instance.goods4057);
        PlayerPrefs.SetInt("Goods4058", DataManager.Instance.goods4058);
        PlayerPrefs.SetInt("Goods4059", DataManager.Instance.goods4059);
        PlayerPrefs.SetInt("Goods4060", DataManager.Instance.goods4060);

        PlayerPrefs.SetInt("First", DataManager.Instance.first);
        PlayerPrefs.SetInt("FirstDG", DataManager.Instance.firstDG);
        PlayerPrefs.SetInt("FirstHome", DataManager.Instance.firstHome);
        PlayerPrefs.SetInt("FirstGoodsBuy", DataManager.Instance.firstGoodsBuy);
        PlayerPrefs.SetInt("FirstRequest", DataManager.Instance.firstRequest);
        PlayerPrefs.SetInt("FirstRank", DataManager.Instance.firstRank);
        PlayerPrefs.SetInt("Ending", DataManager.Instance.ending);
        PlayerPrefs.SetInt("Ending1", DataManager.Instance.ending1);
        PlayerPrefs.SetInt("BGM", DataManager.Instance.bgm);
        PlayerPrefs.SetInt("SFX", DataManager.Instance.sfx);

        
        PlayerPrefs.Save();
    }


}


