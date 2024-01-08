using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopbarManager : MonoBehaviour
{
   
    int NowGold;
    int NowRank;

    public Text GoldAmountText;
    public Text NowRankName;

    public Button Setting;

    public GameObject SettingPopCanvas;
    

    // CSV 파일을 읽어들일 데이터 리스트
    private List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();
    private const string RankSampleFileName = "RankSample";
    private char[] TRIM_CHARS = { ' ', '\"' };

   
    void Start()
    {
     
        
        //데이터 매니저에서 골드값과 랭크값 찾기
        DataManager.Instance.nowGold = PlayerPrefs.GetInt("NowGold");
        DataManager.Instance.nowRank = PlayerPrefs.GetInt("NowRank");

        GameObject SettingPopupCanvas = GameObject.Find("SettingPopupCanvas");

        //시작 시 팝업을 비활성화
        SettingPopupCanvas.SetActive(false);

        // CSV 파일에서 데이터 읽기
        data_Dialog = CSVReader.Read(RankSampleFileName);

        RankSetupInfo();

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
        data_Dialog = CSVReader.Read(RankSampleFileName);
        
        TopBar();
    }



    // Update is called once per frame
    public void TopBar()
    {
        if (GoldAmountText != null) 
        { 
        
            GoldAmountText.text = DataManager.Instance.nowGold.ToString();
        }
        if (NowRankName !=null)
        {

            NowRankName.text = data_Dialog[DataManager.Instance.nowRank]["rank"].ToString();
        }
    }
    public void OnButtonClick_SettingPopup()
    {
        // 팝업을 활성화
       
        SettingPopCanvas.SetActive(true);
    }

}
