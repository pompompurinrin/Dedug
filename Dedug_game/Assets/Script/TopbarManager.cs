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
    

    // CSV ������ �о���� ������ ����Ʈ
    private List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();
    private const string RankSampleFileName = "RankSample";
    private char[] TRIM_CHARS = { ' ', '\"' };

   
    void Start()
    {
     
        
        //������ �Ŵ������� ��尪�� ��ũ�� ã��
        DataManager.Instance.nowGold = PlayerPrefs.GetInt("NowGold");
        DataManager.Instance.nowRank = PlayerPrefs.GetInt("NowRank");

        GameObject SettingPopupCanvas = GameObject.Find("SettingPopupCanvas");

        //���� �� �˾��� ��Ȱ��ȭ
        SettingPopupCanvas.SetActive(false);

        // CSV ���Ͽ��� ������ �б�
        data_Dialog = CSVReader.Read(RankSampleFileName);

        RankSetupInfo();

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
        // �˾��� Ȱ��ȭ
       
        SettingPopCanvas.SetActive(true);
    }

}
