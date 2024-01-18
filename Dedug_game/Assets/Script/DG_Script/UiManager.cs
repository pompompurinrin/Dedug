using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public Canvas BG_Home;
    public Canvas BG_MainStory;
    public Canvas PopUpBG_MainStory;
    public Canvas PopUpBG_Goldplus;
    public Canvas Test;
    public Canvas BG_Cha1;
    public Canvas BG_Cha2;
    public Canvas BG_Cha3;
    public Canvas PopUpBG_GoodsInfo;
    public Canvas BG_Cha1_Story;
    public Canvas BG_Cha2_Story;
    public Canvas BG_Cha3_Story;
    public Canvas PopUpBG_MainStoryCheck;
    public Canvas BG_SpecialGoods;



    public Text GoodsNameText;
    public Text GoodsDesc;
    public Text GoodsName;

    public Image GoodsImage;
   

    public Button MainStory_Btn;
    public Button Back2Home_btn;
    public Button MainStory_1_Btn;
    public Button Maintory_2_Btn;
    public Button Maintory_3_Btn;
    public Button MainStoryYes_Btn;
    public Button MainStoryNo_Btn;
    public Button StoryCheck_Btn;
    public Button Test_Btn;
    public Button Cha_1_Btn;
    public Button Cha_2_Btn;
    public Button Cha_3_Btn;
    public Button Cha_1_Story_Btn;
    public Button Cha_2_Story_Btn;
    public Button Cha_3_Story_Btn;
    public Button Cha_1_1011_Btn;
    public Button Cha_1_1012_Btn;
    public Button Cha_1_1021_Btn;
    public Button Cha_1_1022_Btn;
    public Button Cha_1_1031_Btn;
    public Button Cha_1_1032_Btn;
    public Button Cha_1_1041_Btn;
    public Button Cha_1_1042_Btn; 
    public Button Cha_1_1051_Btn;
    public Button Cha_1_1052_Btn;
    public Button PopUpExit_Btn;
    public Button Cha_1_Story1_Btn;
    public Button Cha_1_Story2_Btn;
    public Button Cha_1_Story3_Btn;
    public Button Back2Cha_1_btn;
    public Button Cha_2_2011_Btn;
    public Button Cha_2_2012_Btn;
    public Button Cha_2_2021_Btn;
    public Button Cha_2_2022_Btn;
    public Button Cha_2_2031_Btn;
    public Button Cha_2_2032_Btn;
    public Button Cha_2_2041_Btn;
    public Button Cha_2_2042_Btn;
    public Button Cha_2_2051_Btn;
    public Button Cha_2_2052_Btn;
    public Button Cha_2_Story1_Btn;
    public Button Cha_2_Story2_Btn;
    public Button Cha_2_Story3_Btn;
    public Button Cha_3_3011_Btn;
    public Button Cha_3_3012_Btn;
    public Button Cha_3_3021_Btn;
    public Button Cha_3_3022_Btn;
    public Button Cha_3_3031_Btn;
    public Button Cha_3_3032_Btn;
    public Button Cha_3_3041_Btn;
    public Button Cha_3_3042_Btn;
    public Button Cha_3_3051_Btn;
    public Button Cha_3_3052_Btn;
    public Button Cha_3_Story1_Btn;
    public Button Cha_3_Story2_Btn;
    public Button Cha_3_Story3_Btn;
    public Button Special_4051_Btn;
    public Button Special_4052_Btn;
    public Button Special_4053_Btn;
    public Button Special_4054_Btn;
    public Button Special_4055_Btn;
    public Button Special_4056_Btn;
    public Button Special_4057_Btn;
    public Button Special_4058_Btn;
    public Button Special_4059_Btn;
    public Button Special_4060_Btn;
    public Button SpecialGoods_Btn;


    //팝업창 다르게 하기 위해서, 처음 각 버튼을 눌렀는지 확인하는 작업을 위한 준비
    private bool isFirstMainStory1BtnClick = true;
    private bool isFirstMainStory2BtnClick = true;
    private bool isFirstMainStory3BtnClick = true;
    private bool isFirstCha1_Story1BtnClick = true;
    private bool isFirstCha1_Story2BtnClick = true;
    private bool isFirstCha1_Story3BtnClick = true;
    private bool isFirstCha2_Story1BtnClick = true;
    private bool isFirstCha2_Story2BtnClick = true;
    private bool isFirstCha2_Story3BtnClick = true;
    private bool isFirstCha3_Story1BtnClick = true;
    private bool isFirstCha3_Story2BtnClick = true;
    private bool isFirstCha3_Story3BtnClick = true;

    // CSV 파일을 읽어들일 데이터 리스트
   

    private List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();
    private const string GoodsFileName = "GoodsCSV";
    private char[] TRIM_CHARS = { ' ', '\"' };

    private void Awake()
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

        DataManager.Instance.nowGold = PlayerPrefs.GetInt("NowGold");

        DataManager.Instance.storyID = PlayerPrefs.GetInt("StoryID");
        DataManager.Instance.story1_1 = PlayerPrefs.GetInt("Story1_1");
        DataManager.Instance.story1_2 = PlayerPrefs.GetInt("Story1_2");
        DataManager.Instance.story1_3 = PlayerPrefs.GetInt("Story1_3");
        DataManager.Instance.story2_1 = PlayerPrefs.GetInt("Story2_1");
        DataManager.Instance.story2_2 = PlayerPrefs.GetInt("Story2_2");
        DataManager.Instance.story2_3 = PlayerPrefs.GetInt("Story2_3");
        DataManager.Instance.story3_1 = PlayerPrefs.GetInt("Story3_1");
        DataManager.Instance.story3_2 = PlayerPrefs.GetInt("Story3_2");
        DataManager.Instance.story3_3 = PlayerPrefs.GetInt("Story3_3");
        DataManager.Instance.story4_1 = PlayerPrefs.GetInt("Story4_1");
        DataManager.Instance.story4_2 = PlayerPrefs.GetInt("Story4_2");
        DataManager.Instance.story4_3 = PlayerPrefs.GetInt("Story4_3");

    }

    void Start()
    {
        BG_MainStory.gameObject.SetActive(false);
        PopUpBG_MainStory.gameObject.SetActive(false);
        Test.gameObject.SetActive(false);
        BG_Cha1.gameObject.SetActive(false);
        BG_Cha3.gameObject.SetActive(false);
        BG_Cha2.gameObject.SetActive(false);
        PopUpBG_GoodsInfo.gameObject.SetActive(false);
        BG_Cha1_Story.gameObject.SetActive(false);
        BG_Cha2_Story.gameObject.SetActive(false);
        BG_Cha2_Story.gameObject.SetActive(false);
        BG_SpecialGoods.gameObject.SetActive(false);

        if (DataManager.Instance.storyID == 11 && DataManager.Instance.story1_1 == 1)
        {
            PopUpBG_Goldplus.gameObject.SetActive(true);
        }
        else if(DataManager.Instance.storyID == 12 && DataManager.Instance.story1_2 == 1)
        {
            PopUpBG_Goldplus.gameObject.SetActive(true);
            
        }
        else if (DataManager.Instance.storyID == 13 && DataManager.Instance.story1_3 == 1)
        {
            PopUpBG_Goldplus.gameObject.SetActive(true);
       
        }
        else if (DataManager.Instance.storyID == 21 && DataManager.Instance.story2_1 == 1)
        {
            PopUpBG_Goldplus.gameObject.SetActive(true);
            
            
        }
        else if (DataManager.Instance.storyID == 22 && DataManager.Instance.story2_2 == 1)
        {
            PopUpBG_Goldplus.gameObject.SetActive(true);
            
        }
        else if (DataManager.Instance.storyID == 23 && DataManager.Instance.story2_3 == 1)
        {
            PopUpBG_Goldplus.gameObject.SetActive(true);
            
        }
        else if (DataManager.Instance.storyID == 31 && DataManager.Instance.story3_1 == 1)
        {
            PopUpBG_Goldplus.gameObject.SetActive(true);
                    }
        else if (DataManager.Instance.storyID == 32 && DataManager.Instance.story3_2 == 1)
        {
            PopUpBG_Goldplus.gameObject.SetActive(true);
            
        }
        else if (DataManager.Instance.storyID == 41 && DataManager.Instance.story4_1 == 1)
        {
            PopUpBG_Goldplus.gameObject.SetActive(true);
            
        }
        else if (DataManager.Instance.storyID == 42 && DataManager.Instance.story4_2 == 1)
        {
            PopUpBG_Goldplus.gameObject.SetActive(true);
            
        }
        else if (DataManager.Instance.storyID == 43 && DataManager.Instance.story4_3 == 1)
        {
            PopUpBG_Goldplus.gameObject.SetActive(true);
            
        }
        else
        {
            PopUpBG_Goldplus.gameObject.SetActive(false);
        }
        Debug.Log(DataManager.Instance.story1_1);
        Debug.Log(DataManager.Instance.storyID);
        // CSV 파일에서 데이터 읽기
        data_Dialog = CSVReader.Read(GoodsFileName);
    }

    public void GoodsNumInfo()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < Goods.Length; i++)
        {
            if (selectGoods == Goods[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[i]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[i]["GoodsDesc"].ToString();
                GoodsName.text = data_Dialog[i]["GoodsName"].ToString();
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
                

            }

        }
    }

    // 홈화면에서 누를 수 있는 버튼들
    public void MainStory_BtnClick()
    {
        BG_MainStory.gameObject.SetActive(true);
    }

    public void Cha_1_BtnClick()
    {
        BG_Cha1.gameObject.SetActive(true);

            }
    

    public void Cha_2_BtnClick()
    {
        BG_Cha2.gameObject.SetActive(true);
    }

    public void Cha_3_BtnClick()
    {
        BG_Cha3.gameObject.SetActive(true);
    }

    public void SpecialGoods_BtnClick()
    {
        BG_SpecialGoods.gameObject.SetActive(true);
    }

    //홈 화면으로 가는 버튼
    public void Back2Home_btnClick()
    {
        BG_MainStory.gameObject.SetActive(false);
        BG_Cha1.gameObject.SetActive(false);
        BG_Cha2.gameObject.SetActive(false);
        BG_Cha3.gameObject.SetActive(false);
        BG_SpecialGoods.gameObject.SetActive(false);
    }
    

    //BG_MainStory에서 누를 수 있는 버튼들, 스토리 버튼을 클릭하면 싱글톤에 각 번호를 부여해서 값을 부여해야 함
    public void MainStory_1_BtnClick()   //최초 클릭시, 그 이후 클릭시 이미지 변경 하는 방법, 대신 no버튼, 스토리체크 버튼에 반영해줘야 함
    {
        DataManager.Instance.storyID = 41;
        Save();
        if (DataManager.Instance.story4_1 == 0)
        {

            PopUpBG_MainStory.gameObject.SetActive(true);

        }
        else if (DataManager.Instance.story4_1 == 1)
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }

    public void MainStory_2_BtnClick()
    {
        DataManager.Instance.storyID = 42;
        Save();
        if (DataManager.Instance.story4_2 == 0)
        {

            PopUpBG_MainStory.gameObject.SetActive(true);

        }
        else if (DataManager.Instance.story4_2 == 1)
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }

    public void MainStory_3_BtnClick()
    {
        DataManager.Instance.storyID = 43;
        Save();
        if (DataManager.Instance.story4_3 == 0)
        {

            PopUpBG_MainStory.gameObject.SetActive(true);

        }
        else if (DataManager.Instance.story4_3 == 1)
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }

    //모든 스토리버튼을 처음 눌렀을 때 확인 버튼
    public void FirstStoryYes_BtnClick()
    {
        DataManager.Instance.nowGold += 200;
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        if(DataManager.Instance.storyID == 11)
        {
            DataManager.Instance.story1_1 = 1;
        }
        else if (DataManager.Instance.storyID == 12)
        {
            DataManager.Instance.story1_2 = 1;
        }
        else if (DataManager.Instance.storyID == 13)
        {
            DataManager.Instance.story1_3 = 1;
        }
        else if (DataManager.Instance.storyID == 21)
        {
            DataManager.Instance.story2_1 = 1;
        }
        else if (DataManager.Instance.storyID == 22)
        {
            DataManager.Instance.story2_2 = 1;
        }
        else if (DataManager.Instance.storyID == 23)
        {
            DataManager.Instance.story2_3 = 1;
        }
        else if (DataManager.Instance.storyID == 31)
        {
            DataManager.Instance.story3_1 = 1;
        }
        else if (DataManager.Instance.storyID == 32)
        {
            DataManager.Instance.story3_2 = 1;
        }
        else if (DataManager.Instance.storyID == 33)
        {
            DataManager.Instance.story3_3 = 1;
        }
        else if (DataManager.Instance.storyID == 41)
        {
            DataManager.Instance.story4_1 = 1;
        }
        else if (DataManager.Instance.storyID == 42)
        {
            DataManager.Instance.story4_2 = 1;
        }
        else if (DataManager.Instance.storyID == 43)
        {
            DataManager.Instance.story4_3 = 1;
        }
        Save();
        PopUpBG_Goldplus.gameObject.SetActive(false);
        SceneManager.LoadScene("StoryScene");
        
    }

    
    public void OnMainStoryNo_BtnClick()
    {

        PopUpBG_MainStory.gameObject.SetActive(false);
        PopUpBG_MainStoryCheck.gameObject.SetActive(false);
    }

    //이미 본 스토리는 이 버튼 할당
    public void AlreadyStoryYes_BtnClick()
    {
        
        PopUpBG_Goldplus.gameObject.SetActive(false);
        SceneManager.LoadScene("StoryScene");
        
    }

 

    //이미 본 스토리 또 볼래? 팝업에서 뜨는 버튼들. 이때 no버튼은 처음 본 스토리 팝업과 동일하다
    public void StoryCheck_BtnClick()
    {

        PopUpBG_MainStory.gameObject.SetActive(false);
        PopUpBG_Goldplus.gameObject.SetActive(false);
        Test.gameObject.SetActive(false);
        PopUpBG_MainStoryCheck.gameObject.SetActive(false);

    }

    //캐릭터 1 스토리 창에서 누를 수 있는 버튼들

    public void OnCha_1_Story1_BtnClick()
    {
        DataManager.Instance.storyID = 11;
        Save();
        if (DataManager.Instance.story1_1 == 0)
        {

            PopUpBG_MainStory.gameObject.SetActive(true);

        }
        else if (DataManager.Instance.story1_1 == 1)
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }


    public void OnCha_1_Story2_BtnClick()
    {
        DataManager.Instance.storyID = 12;
        Save();
        if (DataManager.Instance.story1_2 == 0)
        {

            PopUpBG_MainStory.gameObject.SetActive(true);

        }
        else if (DataManager.Instance.story1_2 == 1)
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }

    public void OnCha_1_Story3_BtnClick()
    {
        DataManager.Instance.storyID = 13;
        Save();
        if (DataManager.Instance.story1_3 == 0)
        {

            PopUpBG_MainStory.gameObject.SetActive(true);

        }
        else if (DataManager.Instance.story1_3 == 1)
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }

    public GameObject[] Goods = new GameObject[60];

    //캐릭터 1창에서 누를 수 있는 버튼들
    public void OnCha_1_Story_BtnClick()
    {
        BG_Cha1_Story.gameObject.SetActive(true);
    }
    
    public void OnCha_goods_BtnClick()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < Goods.Length; i++)
        {
            if (selectGoods == Goods[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();    //DataManager.Instance.goods3032 = PlayerPrefs.GetInt("Goods3032");
                
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[i]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[i]["GoodsDesc"].ToString();
                //GoodsNum.text = 데이터매니저에서 개수 가져오기
                PopUpBG_GoodsInfo.gameObject.SetActive(true);

               

            }
        }
    }


    //캐릭터 2 스토리 화면에서 누를 수 있는 버튼
    public void OnCha_2_Story1_BtnClick()
    {
        DataManager.Instance.storyID = 21;
        Save();
        if (DataManager.Instance.story2_1 == 0)
        {

            PopUpBG_MainStory.gameObject.SetActive(true);

        }
        else if (DataManager.Instance.story2_1 == 1)
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }


    public void OnCha_2_Story2_BtnClick()
    {
        DataManager.Instance.storyID = 22;
        Save();
        if (DataManager.Instance.story2_2 == 0)
        {

            PopUpBG_MainStory.gameObject.SetActive(true);

        }
        else if (DataManager.Instance.story2_2 == 1)
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }

    public void OnCha_2_Story3_BtnClick()
    {
        DataManager.Instance.storyID = 23;
        Save();
        if (DataManager.Instance.story2_3 == 0)
        {

            PopUpBG_MainStory.gameObject.SetActive(true);

        }
        else if (DataManager.Instance.story2_3 == 1)
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }


    //캐릭터 창 2에서 누를 수 있는 버튼들
    public void OnCha_2_Story_BtnClick()
    {
        BG_Cha2_Story.gameObject.SetActive(true);
    }




    //캐릭터 3 스토리 화면에서 누를 수 있는 버튼
    public void OnCha_3_Story1_BtnClick()
    {
        DataManager.Instance.storyID = 31;
        Save();
        if (DataManager.Instance.story3_1 == 0)
        {

            PopUpBG_MainStory.gameObject.SetActive(true);

        }
        else if (DataManager.Instance.story3_1 == 1)
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }


    public void OnCha_3_Story2_BtnClick()
    {
        DataManager.Instance.storyID = 32;
        Save();
        if (DataManager.Instance.story3_2 == 0)
        {

            PopUpBG_MainStory.gameObject.SetActive(true);

        }
        else if (DataManager.Instance.story3_2 == 1)
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }

    public void OnCha_3_Story3_BtnClick()
    {
        DataManager.Instance.storyID = 33;
        Save();
        if (DataManager.Instance.story3_3 == 0)
        {

            PopUpBG_MainStory.gameObject.SetActive(true);

        }
        else if (DataManager.Instance.story3_3 == 1)
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }

    //캐릭터 3 화면에서 누를 수 있는 버튼들
    public void OnCha_3_Story_BtnClick()
    {
        BG_Cha3_Story.gameObject.SetActive(true);
    }



    //캐릭터 1창으로 돌아가는 버튼
    public void OnBack2Cha_1_btnClick()
    {
        BG_Cha1_Story.gameObject.SetActive(false);
    }

    public void OnBack2Cha_2_btnClick()
    {
        BG_Cha2_Story.gameObject.SetActive(false);
    }

    public void OnBack2Cha_3_btnClick()
    {
        BG_Cha3_Story.gameObject.SetActive(false);
    }
    //PopUpBG_GoodsInfo 나가는 버튼
    public void OnPopUpExit_BtnClick()
    {
        PopUpBG_GoodsInfo.gameObject.SetActive(false);
        

    }

    public void Save()
    {
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
    }    
   
    public void Clear()
    {
        DataManager.Instance.storyID = 0;
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
        Save();
    }
}






