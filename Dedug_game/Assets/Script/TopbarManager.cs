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
    public GameObject HelpUI;
    public GameObject HelpPopup;
    public GameObject HelpHomePopup;
    public GameObject HelpCollectionPopup;
    public GameObject HelpCommisionPopup;
    public GameObject HelpOtakuPopup;
    public GameObject HelpRankUPPopup;


    public AudioSource bgm1AudioSource;
    public AudioSource sfx1AudioSource;

    public string NowimageFileName;




    Dictionary<int, Sprite> rankDic = new Dictionary<int, Sprite>();
    public Sprite[] rankImg;
    

    // CSV 파일을 읽어들일 데이터 리스트
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
       
        
        data_Dialog = CSVReader.Read(RankFileName);
        RankImage();
        RankSetupInfo();

        GameObject MenuUI = GameObject.Find("MenuUI");
        GameObject SettingPopupCanvas = GameObject.Find("SettingPopupCanvas");
        GameObject HelpUI = GameObject.Find("HelpUI");
        GameObject HelpPopup = GameObject.Find("HelpPopup");
        GameObject HelpHomePopup = GameObject.Find("HelpHomePopup");
        GameObject HelpCollectionPopup = GameObject.Find("HelpCollectionPopup");
        GameObject HelpCommisionPopup = GameObject.Find("HelpCommisionPopup");
        GameObject HelpOtakuPopup = GameObject.Find("HelpOtakuPopup");
        GameObject HelpRankUPPopup = GameObject.Find("HelpRankUPPopup");



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
        // 세팅 팝업을 활성화

        SettingPopCanvas.SetActive(true);
    }

    public void OnButtonClick_OffSettingPopup()
    {
        //세팅 팝업을 비활성화

        SettingPopCanvas.SetActive(false);
    }
    public void OnButtonClick_MenuUI()
    {
        // 메뉴 팝업을 활성화

        MenuUI.SetActive(true);
    }

    public void OnButtonClick_OffMenuUI()
    {
        // 메뉴 팝업을 비활성화

        MenuUI.SetActive(false);
    }

    public void OnButtonClick_OnHelpUI()
    {
        // 헬프 팝업 활성화
        HelpUI.SetActive(true);
    }
    public void OnButtonClick_OffHelpUI()
    {
        // 헬프 팝업 비활성화
        HelpUI.SetActive(false);
    }

    public void OnButtonClick_OnHelpHomePopup()
    {
        // 헬프 홈 팝업 활성화
        HelpPopup.SetActive(true);
        HelpHomePopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpHomePopup()
    {
        // 헬프 홈 팝업 비활성화
        HelpHomePopup.SetActive(false);
    }

    public void OnButtonClick_OnHelpCollectionPopup()
    {
        // 헬프 콜렉션 팝업 활성화
        HelpPopup.SetActive(true);
        HelpCollectionPopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpCollectionPopup()
    {
        // 헬프 콜렉션 팝업 비활성화
        HelpCollectionPopup.SetActive(false);
    }

    public void OnButtonClick_OnHelpCommisionPopup()
    {
        // 헬프 커미션 팝업 활성화
        HelpPopup.SetActive(true);
        HelpCommisionPopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpCommisionPopup()
    {
        // 헬프 커미션 팝업 비활성화
        HelpCommisionPopup.SetActive(false);
    }

    public void OnButtonClick_OnHelpOtakuPopup()
    {
        // 헬프 오타쿠 팝업 활성화
        HelpPopup.SetActive(true);
        HelpOtakuPopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpCOtakuPopup()
    {
        // 헬프 오타쿠 팝업 비활성화
        HelpOtakuPopup.SetActive(false);
    }

    public void OnButtonClick_OnHelpRankUPPopup()
    {
        // 헬프 랭크 업 팝업 활성화
        HelpPopup.SetActive(true);
        HelpRankUPPopup.SetActive(true);
    }

    public void OnButtonClick_OffHelpRankUPPopup()
    {
        // 헬프 랭크 업 팝업 비활성화
        HelpRankUPPopup.SetActive(false);
    }

    public void HomeClick()
    {
        SceneManager.LoadScene("HomeScene");
    }
    
    public void Clear()
    {
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
        PlayerPrefs.SetInt("First", DataManager.Instance.first);
        PlayerPrefs.SetInt("FirstDG", DataManager.Instance.firstDG);
        PlayerPrefs.SetInt("FirstHome", DataManager.Instance.firstHome);
        PlayerPrefs.SetInt("FirstGoodsBuy", DataManager.Instance.firstGoodsBuy);
        PlayerPrefs.SetInt("FirstRequest", DataManager.Instance.firstRequest);
        PlayerPrefs.Save();
    }


}


