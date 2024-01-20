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

    public Canvas GanbareHowTo;
    public Canvas CardHowTo;

    public AudioSource sfx1AudioSource;

    // CSV 파일을 읽어들일 데이터 리스트
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
        
   
       
        GamePopuptext.text = "Start -" + data_Dialog[DataManager.Instance.nowRank]["TicketGold"].ToString() + "Gold";
        GamePopuptext2.text = "Start -" + data_Dialog[DataManager.Instance.nowRank]["TicketGold"].ToString() + "Gold";

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
        // 게임 팝업 비활성화
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
        // 간바레 바다짱 팝업 활성화
        GamePopups.gameObject.SetActive(true);
        GanbareBada.gameObject.SetActive(true);
        CardGame.gameObject.SetActive(false);

    }
    public void OnButtonClick_OnCardGame()
    {
        // 카드 게임 팝업 활성화
        GamePopups.gameObject.SetActive(true);
        CardGame.gameObject.SetActive(true);
    }


    public void OnButtonClick_OffGoodsBuy()
    {
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
    public void GanbareHowToExplain()
    {
        if (GanbareClickNum == 0)
        {
            GanbareHowToText.text = "간바레 바다짱!!은 바다의 콘서트에서 나오는 불빛에 맞춰서 응원봉을 휘둘러 바다를 응원하는 게임입니다.";
            GanbareHowToImage.sprite = GanbareHowToImage1;
        }
        else if (GanbareClickNum == 1)
        {
            GanbareHowToText.text = "콘서트장 불빛의 색을 기억합니다.";
            GanbareHowToImage.sprite = GanbareHowToImage2;
        }
        else if (GanbareClickNum == 2)
        {
            GanbareHowToText.text = "응원봉에 불이 켜지면 기억했던 색의 응원봉을 순서대로 클릭합니다.";
            GanbareHowToImage.sprite = GanbareHowToImage3;
        }
        else if (GanbareClickNum == 3)
        {
            GanbareHowToText.text = "타이밍에 맞춰 올바른 색의 응원봉을 클릭하면 1점을 얻습니다. 타이밍에 맞추지 못하거나 다른 색의 응원봉을 클릭하면 1점을 잃습니다.";
            GanbareHowToImage.sprite = GanbareHowToImage4;
        }
        else if (GanbareClickNum == 4)
        {
            GanbareHowToText.text = "60초의 제한시간이 지나거나 8점을 획득하면 게임이 종료됩니다.";
            GanbareHowToImage.sprite = GanbareHowToImage5;
        }
        else if (GanbareClickNum == 5)
        {
            GanbareHowToText.text = "'간바레', '카와이' 버튼을 클릭하면 바다짱이 기뻐할지도..?";
            GanbareHowToImage.sprite = GanbareHowToImage6;
        }
        else if (GanbareClickNum == 6)
        {
            GanbareHowToText.text = "8점은 굿즈 3개, 4 ~ 7점은 2개, 3점 이하는 1개를 획득할 수 있습니다.";
            GanbareHowToImage.sprite = GanbareHowToImage7;
        }

    }


    public void GanbareHowToClick()
    {
        GanbareClickNum = 0;
        GanbareHowToExplain();
        GanbareHowTo.gameObject.SetActive(true);
        
    }
    public void GanbareHowToExit()
    {
        GanbareHowTo.gameObject.SetActive(false);
    }
    public void GanbareHowToLclick()
    {
        GanbareClickNum--;
        if(GanbareClickNum < 0)
        {
            GanbareClickNum = 6;
        }
        GanbareHowToExplain();
    }
    public void GanbareHowToRclick()
    {
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
        CardClickNum = 0;
        CardHowToExplain();
        CardHowTo.gameObject.SetActive(true);

    }
    public void CardHowToExit()
    {
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
