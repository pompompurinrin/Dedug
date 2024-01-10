using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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



    /* void Start()
     {
         BG_Home = GameObject.Find("BG_Home").GetComponent<Canvas>();
         BG_MainStory = GameObject.Find("GameObjectManager").transform.Find("BG_MainStory").GetComponent<Canvas>(); 

         PopUpBG_MainStory = GameObject.Find("PopUpBG_MainStory").GetComponent<Canvas>();
         PopUpBG_Goldplus = GameObject.Find("GameObjectManager").transform.Find("PopUpBG_Goldplus").GetComponent<Canvas>();
         Test = GameObject.Find("GameObjectManager").transform.Find("Test").GetComponent<Canvas>();
         BG_Cha1 = GameObject.Find("GameObjectManager").transform.Find("BG_Cha1").GetComponent<Canvas>();
         PopUpBG_GoodsInfo = GameObject.Find("GameObjectManager").transform.Find("PopUpBG_GoodsInfo").GetComponent<Canvas>();
         BG_Cha1_Story = GameObject.Find("GameObjectManager").transform.Find("BG_Cha1_Story").GetComponent<Canvas>();

        GoodsNameText = GameObject.Find("GameObjectManager").transform.Find("GoodsNameText").GetComponent<Text>();

        BG_MainStory.gameObject.SetActive(false); //GameObject.Find("GameObjectManager").transform.Find("BG_MainStory").gameObject.SetActive(true);
         PopUpBG_MainStory.gameObject.SetActive(false);
         PopUpBG_Goldplus.gameObject.SetActive(false);
         Test.gameObject.SetActive(false);
         BG_Cha1.gameObject.SetActive(false);
         PopUpBG_GoodsInfo.gameObject.SetActive(false);
         BG_Cha1_Story.gameObject.SetActive(false);
     }*/

    void Start()
    {
        FindAndAssignCanvas();
       }

    void FindAndAssignCanvas() //null 오류가 자꾸 떠서 어디에 뭐가 없는지 검사하는 것
    {
        FindAndAssignCanvas("BG_Home", ref BG_Home);
        FindAndAssignCanvas("BG_MainStory", ref BG_MainStory);
        FindAndAssignCanvas("PopUpBG_MainStory", ref PopUpBG_MainStory);
        FindAndAssignCanvas("PopUpBG_Goldplus", ref PopUpBG_Goldplus);
        FindAndAssignCanvas("Test", ref Test);
        FindAndAssignCanvas("BG_Cha1", ref BG_Cha1);
        FindAndAssignCanvas("PopUpBG_GoodsInfo", ref PopUpBG_GoodsInfo);
        FindAndAssignCanvas("BG_Cha1_Story", ref BG_Cha1_Story);
        FindAndAssignCanvas("PopUpBG_MainStoryCheck", ref PopUpBG_MainStoryCheck);
    }

    void FindAndAssignCanvas(string canvasName, ref Canvas canvasVariable)
    {
        Transform canvasTransform = GameObject.Find("GameObjectManager")?.transform.Find(canvasName);
        if (canvasTransform != null)
        {
            canvasVariable = canvasTransform.GetComponent<Canvas>();
            if (canvasVariable == null)
            {
                Debug.LogError($"{canvasName} Canvas component is missing.");
            }
        }
        else
        {
            Debug.LogError($"{canvasName} Canvas not found.");
        }

        GoodsNameText = GameObject.Find("GameObjectManager").transform.Find("GoodsNameText").GetComponent<Text>();
        if (GoodsNameText == null)
        {
            Debug.LogError("GoodsNameText Text component is missing.");
        }//여기까지가 검사
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


    /*public void GoodsPopUpMessage(int targetGoodsID)  //팝업 메세지 텍스트 다르게 띄우려던 것
    {
        List<Dictionary<string, object>> goodsData = CSVReader.Read("GoodsCSV");

        // 굿즈 아이디가 일치하는 행 찾기
        Dictionary<string, object> selectedGoods = goodsData.Find(goods =>
            goods.ContainsKey("GoodsID") &&
            goods["GoodsID"] is int && // 타입 체크를 통해 적절한 캐스팅이 가능한지 확인
            (int)goods["GoodsID"] == targetGoodsID);

        // 찾은 굿즈 정보를 PopUpBG_GoodsInfo에 반영
        if (selectedGoods != null)
        {
            // 예시: GoodsName을 Text로 표시
            Text goodsNameText = PopUpBG_GoodsInfo.transform.Find("GoodsNameText").GetComponent<Text>();
            goodsNameText.text = selectedGoods.ContainsKey("GoodsName") ? selectedGoods["GoodsName"].ToString() : "N/A";
        }

        // PopUpBG_GoodsInfo를 활성화
        PopUpBG_GoodsInfo.gameObject.SetActive(true);  
    }*/

  /*  public void OnCha_1_1011_BtnClick()
    {
        GoodsPopUpMessage(1011);
    }*/

   
    public void OnCha_1_1012_BtnClick()
    {
        PopUpBG_GoodsInfo.gameObject.SetActive(true);
    }


    public void OnCha_1_1013_BtnClick()
    {
        PopUpBG_GoodsInfo.gameObject.SetActive(true);
    }

    public void OnCha_1_1014_BtnClick()
    {
        PopUpBG_GoodsInfo.gameObject.SetActive(true);
    }

    public void OnCha_1_1015_BtnClick()
    {
        PopUpBG_GoodsInfo.gameObject.SetActive(true);
    }

    public void OnCha_1_1016_BtnClick()
    {
       
        PopUpBG_GoodsInfo.gameObject.SetActive(true);
    }

    public void OnPopUpExit_BtnClick()
    {
        PopUpBG_GoodsInfo.gameObject.SetActive(false);
    }
}