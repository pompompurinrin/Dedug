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

    public Text charDialogue;
    public Text charName;
    int nextDia;

    private int diaIndex;
    // CSV 파일을 읽어들일 데이터 리스트

    
    // CSV 파일을 읽어들일 데이터 리스트
    private List<Dictionary<string, object>> homeDiaSample = new List<Dictionary<string, object>>();
    private const string homeDiaSampleFileName = "HomeDiaSample";

    public Canvas TutorialCanvas;


    List<string> suaList = new List<string>();
    List<string> badaList = new List<string>();
    List<string> cholongList = new List<string>();

    List<string> nameList = new List<string>();

    public void Awake()
    {
        DataManager.Instance.firstHome = PlayerPrefs.GetInt("FirstHome");
    }


    public void Start()
    {
        if (DataManager.Instance.firstHome == 0)
        {
            TutorialCanvas.gameObject.SetActive(true);

            Debug.Log("퍼홈" + DataManager.Instance.firstHome.ToString());

            ClickTutorial();
        }
        else
        {
            TutorialCanvas.gameObject.SetActive(false);
        }
        Debug.Log("홈:" + DataManager.Instance.goods1011);
        GameObject ChangeCharPopup = GameObject.Find("ChangeCharPopup");
        GameObject MenuUI = GameObject.Find("MenuUI");
        PopupCanvas = GameObject.Find("PopupCanvas").GetComponent<Canvas>();
        GameObject GoodsBuy = GameObject.Find("GoodsBuy");

        if(DataManager.Instance.nowRank == 0)
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
            if (GoodsNumManager.SpecialGoodsGauge == 40)
            {
                PurposeBtnCompleteText.gameObject.SetActive(true);
            }
            else
            {
                PurposeBtnCompleteText.gameObject.SetActive(false);
            }
        }


        homeDiaSample = CSVReader.Read(homeDiaSampleFileName);

        bgm1AudioSource.Play();
        bgm1AudioSource.loop = true;

        CharHomeList();
        CharNameList();

        charDialogue.text = suaList[nextDia];
        nextDia++;
        if (nextDia == suaList.Count)
        {
            nextDia = 0;
        }
        homeImg.sprite = homeImgs[0];
        charName.text = nameList[0];
        
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
    public void ClickTutorial()
    {
        if (TutorialClickNum == 0)
        {
            TutorialImg.sprite = TutorialImage1;
        }
        else if (TutorialClickNum == 1)
        {
            TutorialImg.sprite = TutorialImage2;
        }
        else if (TutorialClickNum == 2)
        {
            TutorialImg.sprite = TutorialImage2;
        }
        else if (TutorialClickNum == 3)
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
        SceneManager.LoadScene("RequestScene");
    }

    public void ClickRankBtn()
    {
        SceneManager.LoadScene("RankScene");
    }


    public void ClickCollectionBtn()
    {
        SceneManager.LoadScene("DG_Scene");
    }

 
    public void OnButtonClick_ChangeCharPopup()
    {
        // 캐릭터 교체 팝업을 활성화

        ChangeCharPopup.SetActive(true);
    }

    public void OnButtonClick_OffChangeCharPopup()
    {
        // 캐릭터 교체 팝업을 비활성화

        ChangeCharPopup.SetActive(false);
    }

    public void OnButtonClick_OnGoodsBuy()
    {
        // 굿즈 구매 팝업 활성화
        PopupCanvas.gameObject.SetActive(true);
        GoodsBuy.gameObject.SetActive(true);
    }



    public void OnClickChange(int ImgNumber)
    {
        homeImg.sprite = homeImgs[ImgNumber];
        diaIndex = ImgNumber;
        nextDia = 0;

        charName.text = nameList[ImgNumber];
        OnClickCharDialogue();
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
    public void OnClickCharDialogue()
    {


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


    }



}

