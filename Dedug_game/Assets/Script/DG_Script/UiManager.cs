using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    void Start()
    {
        BG_Home = GameObject.Find("BG_Home").GetComponent<Canvas>();
        BG_MainStory = GameObject.Find("GameObjectManager").transform.Find("BG_MainStory").GetComponent<Canvas>(); 

        PopUpBG_MainStory = GameObject.Find("GameObjectManager").transform.Find("PopUpBG_MainStory").GetComponent<Canvas>();
        PopUpBG_Goldplus = GameObject.Find("GameObjectManager").transform.Find("PopUpBG_Goldplus").GetComponent<Canvas>();
        Test = GameObject.Find("GameObjectManager").transform.Find("Test").GetComponent<Canvas>();
        BG_Cha1 = GameObject.Find("GameObjectManager").transform.Find("BG_Cha1").GetComponent<Canvas>();
        PopUpBG_GoodsInfo = GameObject.Find("GameObjectManager").transform.Find("PopUpBG_GoodsInfo").GetComponent<Canvas>();
        BG_Cha1_Story = GameObject.Find("GameObjectManager").transform.Find("BG_Cha1_Story").GetComponent<Canvas>();

        BG_MainStory.gameObject.SetActive(false); //GameObject.Find("GameObjectManager").transform.Find("BG_MainStory").gameObject.SetActive(true);
        PopUpBG_MainStory.gameObject.SetActive(false);
        PopUpBG_Goldplus.gameObject.SetActive(false);
        Test.gameObject.SetActive(false);
        BG_Cha1.gameObject.SetActive(false);
        PopUpBG_GoodsInfo.gameObject.SetActive(false);
        BG_Cha1_Story.gameObject.SetActive(false);
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

    public void MainStory_1_BtnClick()
    {
        PopUpBG_MainStory.gameObject.SetActive(true);
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
       
    }

    public void OnMainStoryNo_BtnClick()
    {
        PopUpBG_MainStory.gameObject.SetActive(false);
    }

    public void OnCha_1_Story_BtnClick()
    {
        BG_Cha1_Story.gameObject.SetActive(true); 
    }

    public void OnCha_1_Story1_BtnClick()
    {
        PopUpBG_MainStory.gameObject.SetActive(true);
    }


    public void OnBack2Cha_1_btnClick()
    {
        BG_Cha1_Story.gameObject.SetActive(false);
    }

    public void OnCha_1_1011_BtnClick()
    {
        PopUpBG_GoodsInfo.gameObject.SetActive(true);
    }

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