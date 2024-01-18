using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomePopupManager : MonoBehaviour
{
    int NowGold;
    int NowRank;
    public Text GamePopuptext;
    public Text GamePopuptext2;



    public GameObject GoodsBuy;
    public GameObject GamePopups;
    public Canvas GanbareBada;
    public Canvas CardGame;
    public GameObject GoldLack;
    public Canvas PopupCanvas;

    public AudioSource sfx1AudioSource;

    // CSV ������ �о���� ������ ����Ʈ
    private List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();
    private const string RankFileName = "RankTable";
    private char[] TRIM_CHARS = { ' ', '\"' };


   

    public void Save()
    {
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        PlayerPrefs.Save();
    }

    private void Awake()
    {
        DataManager.Instance.nowGold = PlayerPrefs.GetInt("NowGold");
        DataManager.Instance.nowRank = PlayerPrefs.GetInt("NowRank");
    }

    void Start()
    {
        data_Dialog = CSVReader.Read(RankFileName);
        
   
       
        GamePopuptext.text = "Start -" + data_Dialog[DataManager.Instance.nowRank]["TicketGold"].ToString();
        GamePopuptext2.text = "Start -" + data_Dialog[DataManager.Instance.nowRank]["TicketGold"].ToString();

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



  

    public void Click_GanbareBadaStart()
    {

        if (DataManager.Instance.nowRank == 0)
        {
            if (DataManager.Instance.nowGold >= 100)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 100;

                Save();
                SceneManager.LoadScene("YJMiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 100)
            {
                GoldLack.SetActive(true);
            }
        }

        else if (DataManager.Instance.nowRank == 1)
        {
            if (DataManager.Instance.nowGold >= 500)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 500;

                Save();
                SceneManager.LoadScene("YJMiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 500)
            {
                GoldLack.SetActive(true);
            }
        }

        else if (DataManager.Instance.nowRank == 2)
        {
            if (DataManager.Instance.nowGold >= 1000)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 1000;

                Save();
                SceneManager.LoadScene("YJMiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 1000)
            {
                GoldLack.SetActive(true);
            }
        }


        else if (DataManager.Instance.nowRank == 3)
        {
            if (DataManager.Instance.nowGold >= 1500)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 1500;

                Save();
                SceneManager.LoadScene("YJMiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 1500)
            {
                GoldLack.SetActive(true);
            }
        }

        else if (DataManager.Instance.nowRank == 4)
        {
            if (DataManager.Instance.nowGold >= 3000)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 3000;

                Save();
                SceneManager.LoadScene("YJMiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 3000)
            {
                GoldLack.SetActive(true);
            }
        }

    }

    public void Click_CardGameStart()
    {

        if (DataManager.Instance.nowRank == 0)
        {
            if (DataManager.Instance.nowGold >= 100)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 100;

                Save();
                SceneManager.LoadScene("HNMiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 100)
            {
                GoldLack.SetActive(true);
            }
        }

        else if (DataManager.Instance.nowRank == 1)
        {
            if (DataManager.Instance.nowGold >= 500)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 500;

                Save();
                SceneManager.LoadScene("HNMiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 500)
            {
                GoldLack.SetActive(true);
            }
        }

        else if (DataManager.Instance.nowRank == 2)
        {
            if (DataManager.Instance.nowGold >= 1000)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 1000;

                Save();
                SceneManager.LoadScene("HNMiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 1000)
            {
                GoldLack.SetActive(true);
            }
        }


        else if (DataManager.Instance.nowRank == 3)
        {
            if (DataManager.Instance.nowGold >= 1500)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 1500;

                Save();
                SceneManager.LoadScene("HNMiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 1500)
            {
                GoldLack.SetActive(true);
            }
        }

        else if (DataManager.Instance.nowRank == 4)
        {
            if (DataManager.Instance.nowGold >= 3000)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 3000;

                Save();
                SceneManager.LoadScene("HNMiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 3000)
            {
                GoldLack.SetActive(true);
            }
        }

    }

    public void Click_OffGoodsBuy()
    {
        GoodsBuy.SetActive(false);
    }
    public void Click_OffGoldLack()
    {
        GoldLack.SetActive(false);
    }
    public void OnButtonClick_OffGamePopup()
    {
        // ���� �˾� ��Ȱ��ȭ
        GamePopups.gameObject.SetActive(false);
        
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

    public void OnButtonClick_OnGanbare()
    {
        // ���ٷ� �ٴ�¯ �˾� Ȱ��ȭ
        GamePopups.gameObject.SetActive(true);
        GanbareBada.gameObject.SetActive(true);
        CardGame.gameObject.SetActive(false);

    }
    public void OnButtonClick_OnCardGame()
    {
        // ī�� ���� �˾� Ȱ��ȭ
        GamePopups.gameObject.SetActive(true);
        CardGame.gameObject.SetActive(true);
    }


    public void OnButtonClick_OffGoodsBuy()
    {
        // ���� ���� �˾� ��Ȱ��ȭ

        PopupCanvas.gameObject.SetActive(false);
        GoodsBuy.SetActive(false);
    }

}
