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
    public Canvas BG_Cha2;
    public Canvas BG_Cha3;
    public Canvas PopUpBG_GoodsInfo;
    public Canvas BG_Cha1_Story;
    public Canvas BG_Cha2_Story;
    public Canvas BG_Cha3_Story;
    public Canvas PopUpBG_MainStoryCheck;



    public Text GoodsNameText;
    public Text GoodsDesc;
    public Text GoodsName;

    public Image GoodsImage;
    public Image RedDot1011;
    public Image RedDot1012;
    public Image RedDot1021;
    public Image RedDot1022;
    public Image RedDot1031;
    public Image RedDot1032;
    public Image RedDot2011;
    public Image RedDot2012;
    public Image RedDot2021;
    public Image RedDot2022;
    public Image RedDot2031;
    public Image RedDot2032;
    public Image RedDot3011;
    public Image RedDot3012;
    public Image RedDot3021;
    public Image RedDot3022;
    public Image RedDot3031;
    public Image RedDot3032;


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
    public Button Cha_2_Story1_Btn;
    public Button Cha_2_Story2_Btn;
    public Button Cha_2_Story3_Btn;
    public Button Cha_3_3011_Btn;
    public Button Cha_3_3012_Btn;
    public Button Cha_3_3021_Btn;
    public Button Cha_3_3022_Btn;
    public Button Cha_3_3031_Btn;
    public Button Cha_3_3032_Btn;
    public Button Cha_3_Story1_Btn;
    public Button Cha_3_Story2_Btn;
    public Button Cha_3_Story3_Btn;


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
    List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();



    private void Awake()
    {
        DataManager.Instance.goods1011 = PlayerPrefs.GetInt("Goods1011");
        DataManager.Instance.goods1012 = PlayerPrefs.GetInt("Goods1012");
        DataManager.Instance.goods1021 = PlayerPrefs.GetInt("Goods1021");
        DataManager.Instance.goods1022 = PlayerPrefs.GetInt("Goods1022");
        DataManager.Instance.goods1031 = PlayerPrefs.GetInt("Goods1031");
        DataManager.Instance.goods1032 = PlayerPrefs.GetInt("Goods1032");
        DataManager.Instance.goods2011 = PlayerPrefs.GetInt("Goods2011");
        DataManager.Instance.goods2012 = PlayerPrefs.GetInt("Goods2012");
        DataManager.Instance.goods2021 = PlayerPrefs.GetInt("Goods2021");
        DataManager.Instance.goods2022 = PlayerPrefs.GetInt("Goods2022");
        DataManager.Instance.goods2031 = PlayerPrefs.GetInt("Goods2031");
        DataManager.Instance.goods2032 = PlayerPrefs.GetInt("Goods2032");
        DataManager.Instance.goods3011 = PlayerPrefs.GetInt("Goods3011");
        DataManager.Instance.goods3012 = PlayerPrefs.GetInt("Goods3012");
        DataManager.Instance.goods3021 = PlayerPrefs.GetInt("Goods3021");
        DataManager.Instance.goods3022 = PlayerPrefs.GetInt("Goods3022");
        DataManager.Instance.goods3031 = PlayerPrefs.GetInt("Goods3031");
        DataManager.Instance.goods3032 = PlayerPrefs.GetInt("Goods3032");


    }

    void Start()
    {
        BG_MainStory.gameObject.SetActive(false); 
        PopUpBG_MainStory.gameObject.SetActive(false);
        PopUpBG_Goldplus.gameObject.SetActive(false);
        Test.gameObject.SetActive(false);
        BG_Cha1.gameObject.SetActive(false);
        BG_Cha3.gameObject.SetActive(false);
        BG_Cha2.gameObject.SetActive(false);
        PopUpBG_GoodsInfo.gameObject.SetActive(false);
        BG_Cha1_Story.gameObject.SetActive(false);
        BG_Cha2_Story.gameObject.SetActive(false);
        BG_Cha2_Story.gameObject.SetActive(false);


        // CSV 파일에서 데이터 읽기
        data_Dialog = CSVReader.Read("GoodsTable_real");
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

    //홈 화면으로 가는 버튼
    public void Back2Home_btnClick()
    {
        BG_MainStory.gameObject.SetActive(false);
        BG_Cha1.gameObject.SetActive(false);
        BG_Cha2.gameObject.SetActive(false);
        BG_Cha3.gameObject.SetActive(false);
    }

    //BG_MainStory에서 누를 수 있는 버튼들
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

    //메인 스토리(처음) 볼래? 팝업
    public void MainStoryYes_BtnClick()
    {
        PopUpBG_Goldplus.gameObject.SetActive(false);
        Test.gameObject.SetActive(true);
    }

    public void OnMainStoryNo_BtnClick()
    {
        PopUpBG_MainStory.gameObject.SetActive(false);
        PopUpBG_MainStoryCheck.gameObject.SetActive(false);
    }

    //이거는 스토리 자리임. 테스트 용으로 만든 이미지+ 버튼 
    public void Test_BtnClick()
    {
        Test.gameObject.SetActive(false);
        PopUpBG_Goldplus.gameObject.SetActive(true);
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
                GoodsName.text = data_Dialog[i]["GoodsName"].ToString();


                

                //GoodsNum.text = data_Dialog[i][""].ToString();

                //GoodsNum.text = 데이터매니저에서 개수 가져오기
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            
            }
        }
    }


    //캐릭터 2 스토리 화면에서 누를 수 있는 버튼
    public void OnCha_2_Story1_BtnClick()
    {
        if (isFirstCha2_Story1BtnClick)
        {
            PopUpBG_MainStory.gameObject.SetActive(true);
            isFirstCha2_Story1BtnClick = false;
        }
        else
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }


    public void OnCha_2_Story2_BtnClick()
    {
        if (isFirstCha2_Story2BtnClick)
        {
            PopUpBG_MainStory.gameObject.SetActive(true);
            isFirstCha2_Story2BtnClick = false;
        }
        else
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }

    public void OnCha_2_Story3_BtnClick()
    {
        if (isFirstCha2_Story3BtnClick)
        {
            PopUpBG_MainStory.gameObject.SetActive(true);
            isFirstCha2_Story3BtnClick = false;
        }
        else
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
        if (isFirstCha3_Story1BtnClick)
        {
            PopUpBG_MainStory.gameObject.SetActive(true);
            isFirstCha3_Story1BtnClick = false;
        }
        else
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }


    public void OnCha_3_Story2_BtnClick()
    {
        if (isFirstCha3_Story2BtnClick)
        {
            PopUpBG_MainStory.gameObject.SetActive(true);
            isFirstCha3_Story2BtnClick = false;
        }
        else
        {
            PopUpBG_MainStoryCheck.gameObject.SetActive(true);
        }
    }

    public void OnCha_3_Story3_BtnClick()
    {
        if (isFirstCha3_Story3BtnClick)
        {
            PopUpBG_MainStory.gameObject.SetActive(true);
            isFirstCha3_Story3BtnClick = false;
        }
        else
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
        Destroy(RedDot1011.gameObject);
        Destroy(RedDot1012.gameObject);
        Destroy(RedDot1021.gameObject);
        Destroy(RedDot1022.gameObject);
        Destroy(RedDot1031.gameObject);
        Destroy(RedDot1032.gameObject);
        Destroy(RedDot2011.gameObject);
        Destroy(RedDot2012.gameObject);
        Destroy(RedDot2021.gameObject);
        Destroy(RedDot2022.gameObject);
        Destroy(RedDot2031.gameObject);
        Destroy(RedDot2032.gameObject);
        Destroy(RedDot3011.gameObject);
        Destroy(RedDot3012.gameObject);
        Destroy(RedDot3021.gameObject);
        Destroy(RedDot3022.gameObject);
        Destroy(RedDot3031.gameObject);
        Destroy(RedDot3032.gameObject);
    }

    public void OntestGoods2022Click()
    {
        DataManager.Instance.goods1031 = DataManager.Instance.goods1031 + 100;
    }

}





