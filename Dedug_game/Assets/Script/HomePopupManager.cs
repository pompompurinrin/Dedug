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
    public Text GamePopuptext3;
    public Text GamePopuptext4;
    public Text GamePopuptext5;




    public GameObject GoodsBuy;
    public GameObject GamePopups;
    public Canvas GanbareBada;
    public Canvas CardGame;
    public Canvas BestSua;
    public Canvas HelpChorong;
    public Canvas MagicPortion;
    public GameObject GoldLack;
    public Canvas PopupCanvas;

    public Canvas GanbareHowTo;
    public Canvas CardHowTo;
    public Canvas TutorialCanvas;
    public Button TutorialBtn;

    public AudioSource sfx1AudioSource;

    // CSV ������ �о���� ������ ����Ʈ
    private List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();
    private const string RankFileName = "RankTable";
    private char[] TRIM_CHARS = { ' ', '\"' };


   

    public void Save()
    {
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        PlayerPrefs.SetInt("FirstGoodsBuy", DataManager.Instance.firstGoodsBuy);
        PlayerPrefs.Save();
    }

    private void Awake()
    {
        DataManager.Instance.nowGold = PlayerPrefs.GetInt("NowGold");
        DataManager.Instance.nowRank = PlayerPrefs.GetInt("NowRank");
        DataManager.Instance.firstGoodsBuy = PlayerPrefs.GetInt("FirstGoodsBuy");
    }

    void Start()
    {
        data_Dialog = CSVReader.Read(RankFileName);
        if(DataManager.Instance.firstGoodsBuy == 0)
        {
            TutorialCanvas.gameObject.SetActive(true);
            
            Debug.Log("��Ȩ" + DataManager.Instance.firstHome.ToString());
            
            ClickTutorial();
            TutorialImg.sprite = TutorialImage1;
            TutorialClickNum++;
        }
        else
        {
            TutorialCanvas.gameObject.SetActive(false);
        }
        Debug.Log("��Ȩ" + DataManager.Instance.firstHome.ToString());

        GamePopuptext.text = "Start -" + data_Dialog[DataManager.Instance.nowRank]["TicketGold"].ToString() + "Gold";
        GamePopuptext2.text = "Start -" + data_Dialog[DataManager.Instance.nowRank]["TicketGold"].ToString() + "Gold";
        GamePopuptext3.text = "Start -" + data_Dialog[DataManager.Instance.nowRank]["TicketGold"].ToString() + "Gold";
        GamePopuptext4.text = "Start -" + data_Dialog[DataManager.Instance.nowRank]["TicketGold"].ToString() + "Gold";
        GamePopuptext5.text = "Start -" + data_Dialog[DataManager.Instance.nowRank]["TicketGold"].ToString() + "Gold";


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
    int TutorialClickNum = 0;

    public Image TutorialImg;

    public Sprite TutorialImage1;
    public Sprite TutorialImage2;
    public Sprite TutorialImage3;
    public Sprite TutorialImage4;
    public Sprite TutorialImage5;
    public Sprite TutorialImage6;
    public Sprite TutorialImage7;
    public Sprite TutorialImage8;
    public Sprite TutorialImage9;

    public void ClickTutorial()
    {
        
        if (TutorialClickNum == 1)
        {
            TutorialImg.sprite = TutorialImage2;
        }
        else if (TutorialClickNum == 2)
        {
            TutorialImg.sprite = TutorialImage3;
        }
        else if (TutorialClickNum == 3)
        {
            TutorialImg.sprite = TutorialImage4;
        }
        else if (TutorialClickNum == 4)
        {
            TutorialImg.sprite = TutorialImage5;
        }
        else if (TutorialClickNum == 5)
        {
            TutorialImg.sprite = TutorialImage6;
        }
        else if (TutorialClickNum == 6)
        {
            TutorialImg.sprite = TutorialImage7;
        }
        else if (TutorialClickNum == 7)
        {
            TutorialImg.sprite = TutorialImage8;
        }
        else if (TutorialClickNum == 8)
        {
            DataManager.Instance.firstGoodsBuy = 1;
            Save();
            TutorialCanvas.gameObject.SetActive(false);
        }

        TutorialClickNum++;
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

        PlaySFX1();
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
        PlaySFX1();
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
        PlaySFX1();
        GoodsBuy.SetActive(false);
    }
    public void Click_OffGoldLack()
    {
        PlaySFX1();
        GoldLack.SetActive(false);
    }
    public void OnButtonClick_OffGamePopup()
    {
        // ���� �˾� ��Ȱ��ȭ
        PlaySFX1();

        MagicPortion.gameObject.SetActive(false);
        GanbareBada.gameObject.SetActive(false);
        CardGame.gameObject.SetActive(false);
        BestSua.gameObject.SetActive(false);
        HelpChorong.gameObject.SetActive(false);

        GamePopups.gameObject.SetActive(false);
        
    }
    public void Click_BestSuaStart()
    {
        PlaySFX1();
        if (DataManager.Instance.nowRank == 0)
        {
            if (DataManager.Instance.nowGold >= 100)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 100;

                Save();
                SceneManager.LoadScene("YJ2MiniGameScene");
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
                SceneManager.LoadScene("YJ2MiniGameScene");
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
                SceneManager.LoadScene("YJ2MiniGameScene");
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
                SceneManager.LoadScene("YJ2MiniGameScene");
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
                SceneManager.LoadScene("YJ2MiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 3000)
            {
                GoldLack.SetActive(true);
            }
        }

    }
    public void Click_HelpChorongStart()
    {

        PlaySFX1();
        if (DataManager.Instance.nowRank == 0)
        {
            if (DataManager.Instance.nowGold >= 100)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 100;

                Save();
                SceneManager.LoadScene("HN2MiniGameScene");
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
                SceneManager.LoadScene("HN2MiniGameScene");
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
                SceneManager.LoadScene("HN2MiniGameScene");
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
                SceneManager.LoadScene("HN2MiniGameScene");
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
                SceneManager.LoadScene("HN2MiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 3000)
            {
                GoldLack.SetActive(true);
            }
        }

    }

    public void Click_MagicPortionStart()
    {

        PlaySFX1();
        if (DataManager.Instance.nowRank == 0)
        {
            if (DataManager.Instance.nowGold >= 100)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 100;

                Save();
                SceneManager.LoadScene("HJYJMiniGameScene");
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
                SceneManager.LoadScene("HJYJMiniGameScene");
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
                SceneManager.LoadScene("HJYJMiniGameScene");
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
                SceneManager.LoadScene("HJYJMiniGameScene");
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
                SceneManager.LoadScene("HJYJMiniGameScene");
            }
            else if (DataManager.Instance.nowGold < 3000)
            {
                GoldLack.SetActive(true);
            }
        }

    }

    public void Click_Commision()
    {
        PlaySFX1();
        Save();
        SceneManager.LoadScene("RequestScene");
    }

    public void Click_Collection()
    {
        PlaySFX1();
        Save();
        SceneManager.LoadScene("DG_Scene");
    }

    public void Click_RankUP()
    {
        PlaySFX1();
        Save();
        SceneManager.LoadScene("RankScene");
    }

    public void OnButtonClick_OnGanbare()
    {
        PlaySFX1();
        // ���ٷ� �ٴ�¯ �˾� Ȱ��ȭ
        GamePopups.gameObject.SetActive(true);
        GanbareBada.gameObject.SetActive(true);
        

    }
    public void OnButtonClick_OnCardGame()
    {
        PlaySFX1();
        // ī�� ���� �˾� Ȱ��ȭ
        GamePopups.gameObject.SetActive(true);
        CardGame.gameObject.SetActive(true);
    }
    public void OnButtonClick_OnBestSua()
    {
        PlaySFX1();
        // ī�� ���� �˾� Ȱ��ȭ
        GamePopups.gameObject.SetActive(true);
        BestSua.gameObject.SetActive(true);
    }
    public void OnButtonClick_OnHelpChorong()
    {
        PlaySFX1();
        // ī�� ���� �˾� Ȱ��ȭ
        GamePopups.gameObject.SetActive(true);
        HelpChorong.gameObject.SetActive(true);
    }
    public void OnButtonClick_OnMagicPortion()
    {
        PlaySFX1();
        // ī�� ���� �˾� Ȱ��ȭ
        GamePopups.gameObject.SetActive(true);
        MagicPortion.gameObject.SetActive(true);
    }

    public void OnButtonClick_OffGoodsBuy()
    {
        PlaySFX1();
        // ���� ���� �˾� ��Ȱ��ȭ
        PopupCanvas.gameObject.SetActive(false);
        GoodsBuy.SetActive(false);
    }

    //����: �� �̴ϰ��� ���� ����
    int GanbareClickNum = 0;
    public Text GanbareHowToText;
    public Image GanbareHowToImage;
    public Sprite GanbareHowToImage1;
    public Sprite GanbareHowToImage2;
    public Sprite GanbareHowToImage3;
    public Sprite GanbareHowToImage4;
    public Sprite GanbareHowToImage5;
    public Sprite GanbareHowToImage6;
    public Sprite GanbareHowToImage7;
    public void GanbareHowToExplain()
    {
        if (GanbareClickNum == 0)
        {
            GanbareHowToText.text = "���ٷ� �ٴ�¯!!�� �ٴ��� �ܼ�Ʈ���� ������ �Һ��� ���缭 �������� �ֵѷ� �ٴٸ� �����ϴ� �����Դϴ�.";
            GanbareHowToImage.sprite = GanbareHowToImage1;
        }
        else if (GanbareClickNum == 1)
        {
            GanbareHowToText.text = "�ܼ�Ʈ�� �Һ��� ���� ����մϴ�.";
            GanbareHowToImage.sprite = GanbareHowToImage2;
        }
        else if (GanbareClickNum == 2)
        {
            GanbareHowToText.text = "�������� ���� ������ ����ߴ� ���� �������� ������� Ŭ���մϴ�.";
            GanbareHowToImage.sprite = GanbareHowToImage3;
        }
        else if (GanbareClickNum == 3)
        {
            GanbareHowToText.text = "Ÿ�ֿ̹� ���� �ùٸ� ���� �������� Ŭ���ϸ� 1���� ����ϴ�. Ÿ�ֿ̹� ������ ���ϰų� �ٸ� ���� �������� Ŭ���ϸ� 1���� �ҽ��ϴ�.";
            GanbareHowToImage.sprite = GanbareHowToImage4;
        }
        else if (GanbareClickNum == 4)
        {
            GanbareHowToText.text = "60���� ���ѽð��� �����ų� 8���� ȹ���ϸ� ������ ����˴ϴ�.";
            GanbareHowToImage.sprite = GanbareHowToImage5;
        }
        else if (GanbareClickNum == 5)
        {
            GanbareHowToText.text = "'���ٷ�', 'ī����' ��ư�� Ŭ���ϸ� �ٴ�¯�� �⻵������..?";
            GanbareHowToImage.sprite = GanbareHowToImage6;
        }
        else if (GanbareClickNum == 6)
        {
            GanbareHowToText.text = "8���� ���� 3��, 4 ~ 7���� 2��, 3�� ���ϴ� 1���� ȹ���� �� �ֽ��ϴ�.";
            GanbareHowToImage.sprite = GanbareHowToImage7;
        }

    }


    public void GanbareHowToClick()
    {
        PlaySFX1();
        GanbareClickNum = 0;
        GanbareHowToExplain();
        GanbareHowTo.gameObject.SetActive(true);
        
    }
    public void GanbareHowToExit()
    {
        PlaySFX1();
        GanbareHowTo.gameObject.SetActive(false);
    }
    public void GanbareHowToLclick()
    {
        PlaySFX1();
        GanbareClickNum--;
        if(GanbareClickNum < 0)
        {
            GanbareClickNum = 6;
        }
        GanbareHowToExplain();
    }
    public void GanbareHowToRclick()
    {
        PlaySFX1();
        GanbareClickNum++;
        if (GanbareClickNum > 6)
        {
            GanbareClickNum = 0;
        }
        GanbareHowToExplain();
    }

    int CardClickNum = 0;
    public Text CardHowToText;
    public Image CardHowToImage;
    public Sprite CardHowToImage1;
    public Sprite CardHowToImage2;
    public Sprite CardHowToImage3;
    public Sprite CardHowToImage4;
    public Sprite CardHowToImage5;
    public Sprite CardHowToImage6;
    public Sprite CardHowToImage7;
    public void CardHowToExplain()
    {
        if (CardClickNum == 0)
        {
            CardHowToText.text = "��ũ��!! ī�� ����� ����� ����ī�带 �����ϴ� �����Դϴ�.";
            CardHowToImage.sprite = CardHowToImage1;
}
        else if (CardClickNum == 1)
        {
            CardHowToText.text = "3�� ���� ī���� �׸��� ��ġ�� ����մϴ�.";
            CardHowToImage.sprite = CardHowToImage2;
        }
        else if (CardClickNum == 2)
        {
            CardHowToText.text = "ī�尡 �޸��� �Ǹ� ���� �׸��� ī�带 Ŭ���մϴ�.";
            CardHowToImage.sprite = CardHowToImage3;
        }
        else if (CardClickNum == 3)
        {
            CardHowToText.text = "������ �� ���� ī���� �׸��� ������ 1���� ȹ���մϴ�.";
            CardHowToImage.sprite = CardHowToImage4;
        }
        else if (CardClickNum == 4)
        {
            CardHowToText.text = "�׸��� �ٸ��� ī��� �ٽ� �������� �˴ϴ�.";
            CardHowToImage.sprite = CardHowToImage5;
        }
        else if (CardClickNum == 5)
        {
            CardHowToText.text = "��� ī�带 �����ų� ���ѽð��� ������ ������ ����˴ϴ�.";
            CardHowToImage.sprite = CardHowToImage6;
        }
        else if (CardClickNum == 6)
        {
            CardHowToText.text = "10���� ���� 3��, 3 ~ 9���� 2��, 2�� ���ϴ� 1���� ȹ���� �� �ֽ��ϴ�.";
            CardHowToImage.sprite = CardHowToImage7;
        }
    }

    
    public void CardHowToClick()
    {
        PlaySFX1();
        CardClickNum = 0;
        CardHowToExplain();
        CardHowTo.gameObject.SetActive(true);

    }
    public void CardHowToExit()
    {
        PlaySFX1();
        CardHowTo.gameObject.SetActive(false);
    }
    public void CardHowToLclick()
    {
        CardClickNum--;
        if (CardClickNum < 0)
        {
            CardClickNum = 6;
        }
        CardHowToExplain();
    }
    public void CardHowToRclick()
    {
        CardClickNum++;
        if (CardClickNum > 6)
        {
            CardClickNum = 0;
        }
        CardHowToExplain();
    }

}
