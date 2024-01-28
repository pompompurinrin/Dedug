using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
    
   

    public GameObject ChangeCharPopup;
    public GameObject GoodsBuy;
    public Sprite[] homeImgs;
    public Image homeImg;
    public Canvas PopupCanvas;
    public AudioSource bgm1AudioSource;
    public AudioSource sfx1AudioSource;
    public Text PurposeBtnText;
    public Text PurposeBtnCompleteText;
    public GameObject LockChar4Btn;
    public GameObject UpdatePopup;

    public Text charDialogue;
    public Text charName;
    int nextDia;
    // CSV 파일을 읽어들일 데이터 리스트

    
    // CSV 파일을 읽어들일 데이터 리스트
    private List<Dictionary<string, object>> homeDiaSample = new List<Dictionary<string, object>>();
    private const string homeDiaSampleFileName = "HomeDiaSample";

    public Canvas TutorialCanvas;


    List<string> suaList = new List<string>();
    List<string> badaList = new List<string>();
    List<string> cholongList = new List<string>();
    List<string> konggeList = new List<string>();
    List<string> nameList = new List<string>();

    public void Awake()
    {
        DataManager.Instance.firstHome = PlayerPrefs.GetInt("FirstHome");
        DataManager.Instance.ending = PlayerPrefs.GetInt("Ending");
    }


    public void Start()
    {
        

        if (DataManager.Instance.firstHome == 0)
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
        Debug.Log("홈:" + DataManager.Instance.goods1011);
        GameObject ChangeCharPopup = GameObject.Find("ChangeCharPopup");
        GameObject MenuUI = GameObject.Find("MenuUI");
        GameObject GoodsBuy = GameObject.Find("GoodsBuy");

        if (DataManager.Instance.ending <= 0 && DataManager.Instance.nowRank == 4)
        {
            DataManager.Instance.storyID = 99;
            DataManager.Instance.ending = 1;
            PlayerPrefs.SetInt("Ending", DataManager.Instance.ending);
            PlayerPrefs.SetInt("StoryID", DataManager.Instance.storyID);
            PlayerPrefs.Save();
            SceneManager.LoadScene("StoryScene");
        }

        if (DataManager.Instance.nowRank == 0)
        {
            PurposeBtnText.text = "수아 컵홀더 획득하기";
            if(DataManager.Instance.goods1011 > 0)
            {
                PurposeBtnCompleteText.gameObject.SetActive(true);
            }
            else
            {
                PurposeBtnCompleteText.gameObject.SetActive(false);
            }
        }
        else if (DataManager.Instance.nowRank == 1)
        {
            PurposeBtnText.text = "바다 L 홀더 획득하기";
            if (DataManager.Instance.goods2022 > 0)
            {
                PurposeBtnCompleteText.gameObject.SetActive(true);
            }
            else
            {
                PurposeBtnCompleteText.gameObject.SetActive(false);
            }
        }
        else if (DataManager.Instance.nowRank == 2)
        {
            PurposeBtnText.text = "초롱 아크릴스탠드 획득하기";
            if (DataManager.Instance.goods3031 > 0)
            {
                PurposeBtnCompleteText.gameObject.SetActive(true);
            }
            else
            {
                PurposeBtnCompleteText.gameObject.SetActive(false);
            }
        }
        else if (DataManager.Instance.nowRank == 3)
        {
            PurposeBtnText.text = "바다 태피스트리 획득하기";
            if (DataManager.Instance.goods2042 > 0)
            {
                PurposeBtnCompleteText.gameObject.SetActive(true);
            }
            else
            {
                PurposeBtnCompleteText.gameObject.SetActive(false);
            }
        }
        else if (DataManager.Instance.nowRank == 4)
        {
            PurposeBtnText.text = "모든 굿즈 획득하기";
            if (GoodsNumManager.MainGoodsGauge == 40)
            {
                PurposeBtnCompleteText.gameObject.SetActive(true);
            }
            else
            {
                PurposeBtnCompleteText.gameObject.SetActive(false);
            }
        }

        if (DataManager.Instance.nowRank == 4)
        {
            LockChar4Btn.SetActive(false);
        }

        homeDiaSample = CSVReader.Read(homeDiaSampleFileName);

        bgm1AudioSource.Play();
        bgm1AudioSource.loop = true;

        CharHomeList();
        CharNameList();
        SpriteChange();



        //시작 시 팝업을 비활성화

        if (ChangeCharPopup != null)
        {
            if (ChangeCharPopup.activeSelf)
            {
                ChangeCharPopup.SetActive(false);
            }

        }

        if (MenuUI != null)
        {
            if (MenuUI.activeSelf)
            {
                MenuUI.SetActive(false);
            }
        }

        if (GoodsBuy != null)
        {
            if (GoodsBuy.activeSelf)
            {
                GoodsBuy.SetActive(false);
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
    public Sprite TutorialImage10;
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
            TutorialImg.sprite = TutorialImage9;
        }
        else if (TutorialClickNum == 9)
        {
            TutorialImg.sprite = TutorialImage10;
        }
        else if (TutorialClickNum == 10)
        {
            DataManager.Instance.firstHome = 1;
            PlayerPrefs.SetInt("FirstHome", DataManager.Instance.firstHome);
            TutorialCanvas.gameObject.SetActive(false);
        }

        TutorialClickNum++;
    }

    
    public void PlaySFX1()
    {
        sfx1AudioSource.Play();
        
    }
    public void StopBGM1()
    {
        bgm1AudioSource.Stop();
    }
    public void ClickRequestBtn()
    {
        PlaySFX1();
        SceneManager.LoadScene("RequestScene");
    }

    public void ClickRankBtn()
    {
        PlaySFX1();
        SceneManager.LoadScene("RankScene");
    }


    public void ClickCollectionBtn()
    {
        PlaySFX1();
        SceneManager.LoadScene("DG_Scene");
    }

 
    public void OnButtonClick_ChangeCharPopup()
    {
        // 캐릭터 교체 팝업을 활성화
        PlaySFX1();
        ChangeCharPopup.SetActive(true);
    }

    public void OnButtonClick_OffChangeCharPopup()
    {
        // 캐릭터 교체 팝업을 비활성화
        PlaySFX1();
        ChangeCharPopup.SetActive(false);
    }

    public void OnButtonClick_OnGoodsBuy()
    {
        // 굿즈 구매 팝업 활성화
        PlaySFX1();
        PopupCanvas.gameObject.SetActive(true);
        GoodsBuy.gameObject.SetActive(true);
    }

    public void OnButtonClick_OnUpdate()
    {
        // 추후 업데이트 예정 팝업 활성화
        PlaySFX1();
        UpdatePopup.gameObject.SetActive(true);
    }

    public void OnButtonClick_OffUpdate()
    {
        // 추후 업데이트 예정 팝업 비활성화
        PlaySFX1();
        UpdatePopup.gameObject.SetActive(false);
    }

    public void SpriteChange()
    {
        
        DataManager.Instance.homeChr = PlayerPrefs.GetInt("HomeChr");
        homeImg.sprite = homeImgs[DataManager.Instance.homeChr];
        charName.text = nameList[DataManager.Instance.homeChr];
        TextChange();
    }

    public void TextChange()
    {
        OnClickCharDialogue(DataManager.Instance.homeChr);
    }
    public void OnClickChange(int ImgNumber)
    {
        PlaySFX1();
        PlayerPrefs.SetInt("HomeChr", ImgNumber);

        SpriteChange();
        nextDia = 0;
        
        OnClickCharDialogue(ImgNumber);
        PlayerPrefs.Save();
    }
    
    private void CharHomeList()
    {
            for (int i = 0; i < homeDiaSample.Count; i++)
            {
                if ((int)homeDiaSample[i]["Index"] == 1)
                {
                    suaList.Add(homeDiaSample[i]["Dialogue"].ToString());
                }

                else if ((int)homeDiaSample[i]["Index"] == 2)
                {
                    badaList.Add(homeDiaSample[i]["Dialogue"].ToString());
                }

                else if ((int)homeDiaSample[i]["Index"] == 3)
                {
                    cholongList.Add(homeDiaSample[i]["Dialogue"].ToString());
                }

                else if ((int)homeDiaSample[i]["Index"] == 4)
                {
                    konggeList.Add(homeDiaSample[i]["Dialogue"].ToString());
                }

        }
     }

    private void CharNameList()
    {
      foreach ( Dictionary<string, object > info in homeDiaSample)
        {
            if (!nameList.Contains(info["CharName"].ToString()))
            {
                nameList.Add(info["CharName"].ToString());
            }
        }

    }
    public void OnClickCharDialogue(int diaIndex)
    {

        PlaySFX1();
        if (diaIndex == 0)
        {
           
            charDialogue.text = suaList[nextDia];
            nextDia++;
            if (nextDia == suaList.Count)
            {
                nextDia = 0;
            }
            
        }

        else if (diaIndex == 1)
        {
            
            charDialogue.text = badaList[nextDia];
            nextDia++;
            if (nextDia == badaList.Count)
            {
                nextDia = 0;
            }

        }

        else if (diaIndex == 2)
        {
            charDialogue.text = cholongList[nextDia];
            nextDia++;
            if (nextDia == cholongList.Count)
            {
                nextDia = 0;
            }

        }
        else if (diaIndex == 3)
        {
            charDialogue.text = konggeList[nextDia];
            nextDia++;
            if (nextDia == konggeList.Count)
            {
                nextDia = 0;
            }

        }


    }



}

