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

    // CSV 파일을 읽어들일 데이터 리스트
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
            
            Debug.Log("퍼홈" + DataManager.Instance.firstHome.ToString());
            
            ClickTutorial();
            TutorialImg.sprite = TutorialImage1;
            TutorialClickNum++;
        }
        else
        {
            TutorialCanvas.gameObject.SetActive(false);
        }
        Debug.Log("퍼홈" + DataManager.Instance.firstHome.ToString());

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
        // 게임 팝업 비활성화
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
        // 간바레 바다짱 팝업 활성화
        GamePopups.gameObject.SetActive(true);
        GanbareBada.gameObject.SetActive(true);
        

    }
    public void OnButtonClick_OnCardGame()
    {
        PlaySFX1();
        // 카드 게임 팝업 활성화
        GamePopups.gameObject.SetActive(true);
        CardGame.gameObject.SetActive(true);
    }
    public void OnButtonClick_OnBestSua()
    {
        PlaySFX1();
        // 카드 게임 팝업 활성화
        GamePopups.gameObject.SetActive(true);
        BestSua.gameObject.SetActive(true);
    }
    public void OnButtonClick_OnHelpChorong()
    {
        PlaySFX1();
        // 카드 게임 팝업 활성화
        GamePopups.gameObject.SetActive(true);
        HelpChorong.gameObject.SetActive(true);
    }
    public void OnButtonClick_OnMagicPortion()
    {
        PlaySFX1();
        // 카드 게임 팝업 활성화
        GamePopups.gameObject.SetActive(true);
        MagicPortion.gameObject.SetActive(true);
    }

    public void OnButtonClick_OffGoodsBuy()
    {
        PlaySFX1();
        // 굿즈 구매 팝업 비활성화
        PopupCanvas.gameObject.SetActive(false);
        GoodsBuy.SetActive(false);
    }

    //혜린: 각 미니게임 도움말 구현
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
    public Sprite GanbareHowToImage8;
    public void GanbareHowToExplain()
    {
        if (GanbareClickNum == 0)
        {
            GanbareHowToText.text = "빛나라! 바다쨩!은 바다의 콘서트에서 나오는 불빛에 맞춰서 응원봉을 휘둘러 바다를 응원하는 게임입니다.";
            GanbareHowToImage.sprite = GanbareHowToImage1;
        }
        else if (GanbareClickNum == 1)
        {
            GanbareHowToText.text = "화면에 보이는 콘서트장 불빛의 색을 기억합니다.";
            GanbareHowToImage.sprite = GanbareHowToImage2;
        }
        else if (GanbareClickNum == 2)
        {
            GanbareHowToText.text = "응원봉 색이 켜지면 방금 기억했던 색과 같은 색의 응원봉을 순서대로 터치합니다.";
            GanbareHowToImage.sprite = GanbareHowToImage3;
        }
        else if (GanbareClickNum == 3)
        {
            GanbareHowToText.text = "응원봉 색이 켜져 있는 동안 같은 색의 응원봉을 순서대로 터치하면 1점을 얻습니다.";
            GanbareHowToImage.sprite = GanbareHowToImage4;
        }
        else if (GanbareClickNum == 4)
        {
            GanbareHowToText.text = "응원봉 색이 켜져 있는 동안 아무 응원봉도 터치하지 않거나 틀린 색의 응원봉을 터치하면 1점을 잃습니다.";
            GanbareHowToImage.sprite = GanbareHowToImage5;
        }
        else if (GanbareClickNum == 5)
        {
            GanbareHowToText.text = "60초의 제한시간이 지나거나 8점을 획득하면 게임은 종료됩니다.";
            GanbareHowToImage.sprite = GanbareHowToImage6;
        }
        else if (GanbareClickNum == 6)
        {
            GanbareHowToText.text = "'응원해', '최고야' 버튼을 클릭하면 바다쨩이 기뻐할지도…? (점수 획득은 없습니다)";
            GanbareHowToImage.sprite = GanbareHowToImage7;
        }
        else if (GanbareClickNum == 7)
        {
            GanbareHowToText.text = "8점은 굿즈 3개, 4 ~ 7점은 2개, 3점 이하는 1개를 획득합니다.";
            GanbareHowToImage.sprite = GanbareHowToImage8;
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
            GanbareClickNum = 7;
        }
        GanbareHowToExplain();
    }
    public void GanbareHowToRclick()
    {
        PlaySFX1();
        GanbareClickNum++;
        if (GanbareClickNum > 7)
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
            CardHowToText.text = "시크릿!! 카드 걸즈는 흩어진 포토카드를 정리하는 게임입니다.";
            CardHowToImage.sprite = CardHowToImage1;
}
        else if (CardClickNum == 1)
        {
            CardHowToText.text = "3초 동안 카드의 그림과 위치를 기억합니다.";
            CardHowToImage.sprite = CardHowToImage2;
        }
        else if (CardClickNum == 2)
        {
            CardHowToText.text = "카드가 뒷면이 되면 같은 그림의 카드를 클릭합니다.";
            CardHowToImage.sprite = CardHowToImage3;
        }
        else if (CardClickNum == 3)
        {
            CardHowToText.text = "뒤집은 두 장의 카드의 그림이 같으면 1점을 획득합니다.";
            CardHowToImage.sprite = CardHowToImage4;
        }
        else if (CardClickNum == 4)
        {
            CardHowToText.text = "그림이 다르면 카드는 다시 뒤집히게 됩니다.";
            CardHowToImage.sprite = CardHowToImage5;
        }
        else if (CardClickNum == 5)
        {
            CardHowToText.text = "모든 카드를 뒤집거나 제한시간이 지나면 게임은 종료됩니다.";
            CardHowToImage.sprite = CardHowToImage6;
        }
        else if (CardClickNum == 6)
        {
            CardHowToText.text = "10점은 굿즈 3개, 3 ~ 9점은 2개, 2점 이하는 1개를 획득할 수 있습니다.";
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

    public GameObject BestSuaHowTo;
    int BestSuaClickNum = 0;
    public Text BestSuaHowToText;
    public Image BestSuaHowToImage;
    public Sprite BestSuaHowToImage1;
    public Sprite BestSuaHowToImage2;
    public Sprite BestSuaHowToImage3;
    public Sprite BestSuaHowToImage4;
    public Sprite BestSuaHowToImage5;
    public Sprite BestSuaHowToImage6;
    public Sprite BestSuaHowToImage7;
    public Sprite BestSuaHowToImage8;
    public void BestSuaHowToExplain()
    {
        if (BestSuaClickNum == 0)
        {
            BestSuaHowToText.text = "극장판 최애의 수아가 개봉했습니다. 최애의 수아는 버튼을 연타해 수아의 모험을 도와주는 게임입니다.";
            BestSuaHowToImage.sprite = BestSuaHowToImage1;
        }
        else if (BestSuaClickNum == 1)
        {
            BestSuaHowToText.text = "버튼을 클릭하면 마법 머신이 돌아가기 시작합니다.";
            BestSuaHowToImage.sprite = BestSuaHowToImage2;
        }
        else if (BestSuaClickNum == 2)
        {
            BestSuaHowToText.text = "마법 머신이 돌아갈 때 버튼을 계속 클릭해 연타하면 마법 머신이 더 빠르게 돌아갑니다.";
            BestSuaHowToImage.sprite = BestSuaHowToImage3;
        }
        else if (BestSuaClickNum == 3)
        {
            BestSuaHowToText.text = "버튼 위에 보이는 바가 왼쪽으로 모두 줄어들면 아이콘 3개가 나타납니다.";
            BestSuaHowToImage.sprite = BestSuaHowToImage4;
        }
        else if (BestSuaClickNum == 4)
        {
            BestSuaHowToText.text = "화면에 보이는 아이콘과 같은 아이콘을 2개 이상 띄우게 되면 1점을 얻고 화면의 아이콘은 다음 아이콘으로 교체됩니다.";
            BestSuaHowToImage.sprite = BestSuaHowToImage5;
        }
        else if (BestSuaClickNum == 5)
        {
            BestSuaHowToText.text = "화면에 보이는 제한 시간 내에 같은 아이콘을 2개 이상 띄우지 못하면 1점을 잃고 화면의 아이콘은 다음 아이콘으로 교체됩니다.";
            BestSuaHowToImage.sprite = BestSuaHowToImage6;
        }
        else if (BestSuaClickNum == 6)
        {
            BestSuaHowToText.text = "60초의 제한시간이 지나거나 8점을 획득하면 게임은 종료됩니다. 제한 시간 안에 최대한 버튼을 연타해 더 많은 점수를 얻어보세요!";
            BestSuaHowToImage.sprite = BestSuaHowToImage7;
        }
        else if (BestSuaClickNum == 7)
        {
            BestSuaHowToText.text = "8점은 굿즈 3개, 4 ~ 7점은 2개, 3점 이하는 1개를 획득합니다.";
            BestSuaHowToImage.sprite = BestSuaHowToImage8;
        }

    }


    public void BestSuaHowToClick()
    {
        PlaySFX1();
        BestSuaClickNum = 0;
        BestSuaHowToExplain();
        BestSuaHowTo.gameObject.SetActive(true);

    }
    public void BestSuaHowToExit()
    {
        PlaySFX1();
        BestSuaHowTo.gameObject.SetActive(false);
    }
    public void BestSuaHowToLclick()
    {
        PlaySFX1();
        BestSuaClickNum--;
        if (BestSuaClickNum < 0)
        {
            BestSuaClickNum = 7;
        }
        BestSuaHowToExplain();
    }
    public void BestSuaHowToRclick()
    {
        PlaySFX1();
        BestSuaClickNum++;
        if (BestSuaClickNum > 7)
        {
            BestSuaClickNum = 0;
        }
        BestSuaHowToExplain();
    }

}
