using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public class UiManager : MonoBehaviour
{
    public Canvas BG_Home;
    public Canvas BG_MainStory;
    public Canvas PopUpBG_MainStory;
    public Canvas PopUpBG_Goldplus;
    public Canvas Test;
    public Canvas BG_Cha1;
    public Canvas PopUpBG_GoodsInfo;
    public Canvas BG_Cha1_Story;
    public Canvas PopUpBG_MainStoryCheck;


    public Text GoodsNameText;
    public Text GoodsDesc;

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
    public Button Cha_1_1013_Btn;
    public Button Cha_1_1014_Btn;
    public Button Cha_1_1015_Btn;
    public Button Cha_1_1016_Btn;
    public Button PopUpExit_Btn;
    public Button Cha_1_Story1_Btn;
    public Button Cha_1_Story2_Btn;
    public Button Cha_1_Story3_Btn;
    public Button Back2Cha_1_btn;

   

   //팝업창 다르게 하기 위해서, 처음 각 버튼을 눌렀는지 확인하는 작업을 위한 준비
    private bool isFirstMainStory1BtnClick = true;
    private bool isFirstMainStory2BtnClick = true;
    private bool isFirstMainStory3BtnClick = true;
    private bool isFirstCha1_Story1BtnClick = true;
    private bool isFirstCha1_Story2BtnClick = true;
    private bool isFirstCha1_Story3BtnClick = true;

    // CSV 파일을 읽어들일 데이터 리스트
    List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();
/*    private const string GoodsCSV = "GoodsCSV";
    private char[] TRIM_CHARS = { ' ', '\"' };*/



    void Start()
     {
         //BG_Home = GameObject.Find("BG_Home").GetComponent<Canvas>();
         //BG_MainStory = GameObject.Find("GameObjectManager").transform.Find("BG_MainStory").GetComponent<Canvas>(); 

         //PopUpBG_MainStory = GameObject.Find("GameObjectManager").transform.Find("PopUpBG_MainStory").GetComponent<Canvas>();
         //PopUpBG_Goldplus = GameObject.Find("GameObjectManager").transform.Find("PopUpBG_Goldplus").GetComponent<Canvas>();
         //Test = GameObject.Find("GameObjectManager").transform.Find("Test").GetComponent<Canvas>();
         //BG_Cha1 = GameObject.Find("GameObjectManager").transform.Find("BG_Cha1").GetComponent<Canvas>();
         //PopUpBG_GoodsInfo = GameObject.Find("GameObjectManager").transform.Find("PopUpBG_GoodsInfo").GetComponent<Canvas>();
         //BG_Cha1_Story = GameObject.Find("GameObjectManager").transform.Find("BG_Cha1_Story").GetComponent<Canvas>();
         //PopUpBG_MainStoryCheck = GameObject.Find("GameObjectManager").transform.Find("PopUpBG_MainStoryCheck").GetComponent<Canvas>();

         BG_MainStory.gameObject.SetActive(false); //GameObject.Find("GameObjectManager").transform.Find("BG_MainStory").gameObject.SetActive(true);
         PopUpBG_MainStory.gameObject.SetActive(false);
         PopUpBG_Goldplus.gameObject.SetActive(false);
         Test.gameObject.SetActive(false);
         BG_Cha1.gameObject.SetActive(false);
         PopUpBG_GoodsInfo.gameObject.SetActive(false);
         BG_Cha1_Story.gameObject.SetActive(false);

        


        // CSV 파일에서 데이터 읽기
        data_Dialog = CSVReader.Read("GoodsCSV");

        

    }
   

    public void MainStory_BtnClick()
    { 
        BG_MainStory.gameObject.SetActive(true);
    }

    public void Cha_1_BtnClick()
    {
        BG_Cha1.gameObject.SetActive(true);
    }

    public void Back2Home_btnClick()
    {
        BG_MainStory.gameObject.SetActive(false);
        BG_Cha1.gameObject.SetActive(false);
        

    }

    public void MainStory_1_BtnClick()   //최초 클릭시, 그 이후 클릭시 이미지 변경 하는 방법, 대신 no버튼, 스토리체크 버튼에 반영해줘야 함
    {
        if (isFirstMainStory1BtnClick)
        {
            PopUpBG_MainStory.gameObject.SetActive(true);
            isFirstMainStory1BtnClick = false;
        }
        else
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }

    public void MainStory_2_BtnClick()   
    {
        if (isFirstMainStory2BtnClick)
        {
            PopUpBG_MainStory.gameObject.SetActive(true);
            isFirstMainStory2BtnClick = false;
        }
        else
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }

    public void MainStory_3_BtnClick()
    {
        if (isFirstMainStory3BtnClick)
        {
            PopUpBG_MainStory.gameObject.SetActive(true);
            isFirstMainStory3BtnClick = false;
        }
        else
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }

    public void MainStoryYes_BtnClick()
    {
        PopUpBG_Goldplus.gameObject.SetActive(false);
        Test.gameObject.SetActive(true);
    }

    public void Test_BtnClick()
    {
        Test.gameObject.SetActive(false);
        PopUpBG_Goldplus.gameObject.SetActive(true);
    }

    public void StoryCheck_BtnClick()
    {
       
        PopUpBG_MainStory.gameObject.SetActive(false);
        PopUpBG_Goldplus.gameObject.SetActive(false);
        Test.gameObject.SetActive(false);
        PopUpBG_MainStoryCheck.gameObject.SetActive(false);

    }

    public void OnMainStoryNo_BtnClick()
    {
        PopUpBG_MainStory.gameObject.SetActive(false);
        PopUpBG_MainStoryCheck.gameObject.SetActive(false);
    }

    public void OnCha_1_Story1_BtnClick()
    {
        if (isFirstCha1_Story1BtnClick)
        {
            PopUpBG_MainStory.gameObject.SetActive(true);
            isFirstCha1_Story1BtnClick = false;
        }
        else
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }

    public void OnCha_1_Story2_BtnClick()
    {
        if (isFirstCha1_Story2BtnClick)
        {
            PopUpBG_MainStory.gameObject.SetActive(true);
            isFirstCha1_Story2BtnClick = false;
        }
        else
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }

    public void OnCha_1_Story3_BtnClick()
    {
        if (isFirstCha1_Story3BtnClick)
        {
            PopUpBG_MainStory.gameObject.SetActive(true);
            isFirstCha1_Story3BtnClick = false;
        }
        else
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }

    public void OnCha_1_Story_BtnClick()
    {
        BG_Cha1_Story.gameObject.SetActive(true);
    }


    public void OnBack2Cha_1_btnClick()
    {
        BG_Cha1_Story.gameObject.SetActive(false);
    }


 
     public GameObject[] sooA = new GameObject[20];
     public GameObject[] bada = new GameObject[20];
     public GameObject[] choLong = new GameObject[20];

     public void OnCha_1_1011_BtnClick()
      {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < sooA.Length; i++)
        {
            if (selectGoods == sooA[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[3]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[3]["GoodsDesc"].ToString();
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
        //string imageFileName = "Goods1011";
        //Debug.Log(imageFileName);
        //GoodsImage.sprite = Resources.Load<Sprite>(imageFileName); 
        

        //GoodsNameText.text = data_Dialog[0]["GoodsName"].ToString();
        //GoodsDesc.text = data_Dialog[0]["GoodsDesc"].ToString();

        //PopUpBG_GoodsInfo.gameObject.SetActive(true);

    }

    /* public void OnCha_2_1011_BtnClick()
     {
         GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
         for (int i = 20; i < bada.Length + 40; i++)
         {
             if (selectGoods == bada[i])
             {
                 string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                 GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                 GoodsNameText.text = data_Dialog[3]["GoodsName"].ToString();
                 GoodsDesc.text = data_Dialog[3]["GoodsDesc"].ToString();
                 PopUpBG_GoodsInfo.gameObject.SetActive(true);
             }
         }
         //string imageFileName = "Goods1011";
         //Debug.Log(imageFileName);
         //GoodsImage.sprite = Resources.Load<Sprite>(imageFileName); 


         //GoodsNameText.text = data_Dialog[0]["GoodsName"].ToString();
         //GoodsDesc.text = data_Dialog[0]["GoodsDesc"].ToString();

         //PopUpBG_GoodsInfo.gameObject.SetActive(true);

     }*/



    public void OnCha_1_1012_BtnClick()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < sooA.Length; i++)
        {
            if (selectGoods == sooA[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[3]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[3]["GoodsDesc"].ToString();
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
        //string imageFileName = data_Dialog[3]["GoodsID"].ToString();
        //GoodsImage.sprite = Resources.Load<Sprite>("Goods"+imageFileName);

        //GoodsNameText.text = data_Dialog[3]["GoodsName"].ToString();
        //GoodsDesc.text = data_Dialog[3]["GoodsDesc"].ToString();
        //PopUpBG_GoodsInfo.gameObject.SetActive(true);
    }


    public void OnCha_1_1013_BtnClick()
    {
        GoodsNameText.text = data_Dialog[6]["GoodsName"].ToString();
        GoodsDesc.text = data_Dialog[6]["GoodsDesc"].ToString();
        PopUpBG_GoodsInfo.gameObject.SetActive(true);
    }

    public void OnCha_1_1014_BtnClick()
    {
        GoodsNameText.text = data_Dialog[9]["GoodsName"].ToString();
        GoodsDesc.text = data_Dialog[9]["GoodsDesc"].ToString();
        PopUpBG_GoodsInfo.gameObject.SetActive(true);
    }

    public void OnCha_1_1015_BtnClick()
    {
        GoodsNameText.text = data_Dialog[12]["GoodsName"].ToString();
        GoodsDesc.text = data_Dialog[12]["GoodsDesc"].ToString();
        PopUpBG_GoodsInfo.gameObject.SetActive(true);
    }

    public void OnCha_1_1016_BtnClick()
    {
        GoodsNameText.text = data_Dialog[15]["GoodsName"].ToString();
        GoodsDesc.text = data_Dialog[15]["GoodsDesc"].ToString();
        PopUpBG_GoodsInfo.gameObject.SetActive(true);
    }

    public void OnPopUpExit_BtnClick()
    {
        PopUpBG_GoodsInfo.gameObject.SetActive(false);
    }
}