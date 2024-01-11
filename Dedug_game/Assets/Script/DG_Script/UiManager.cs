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
    public Text GoodsNum;

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
    public Button Cha_2_2011_Btn;
    public Button Cha_2_2012_Btn;
    public Button Cha_2_2013_Btn;
    public Button Cha_2_2014_Btn;
    public Button Cha_2_2015_Btn;
    public Button Cha_2_2016_Btn;
    public Button Cha_2_Story1_Btn;
    public Button Cha_2_Story2_Btn;
    public Button Cha_2_Story3_Btn;
    public Button Cha_3_3011_Btn;
    public Button Cha_3_3012_Btn;
    public Button Cha_3_3013_Btn;
    public Button Cha_3_3014_Btn;
    public Button Cha_3_3015_Btn;
    public Button Cha_3_3016_Btn;
    public Button Cha_3_Story1_Btn;
    public Button Cha_3_Story2_Btn;
    public Button Cha_3_Story3_Btn;



    //�˾�â �ٸ��� �ϱ� ���ؼ�, ó�� �� ��ư�� �������� Ȯ���ϴ� �۾��� ���� �غ�
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

    // CSV ������ �о���� ������ ����Ʈ
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
         BG_Cha3.gameObject.SetActive(false);
         BG_Cha2.gameObject.SetActive(false);
         PopUpBG_GoodsInfo.gameObject.SetActive(false);
         BG_Cha1_Story.gameObject.SetActive(false);
         BG_Cha2_Story.gameObject.SetActive(false);
         BG_Cha2_Story.gameObject.SetActive(false);


        // CSV ���Ͽ��� ������ �б�
        data_Dialog = CSVReader.Read("GoodsCSV");

    }
   
// Ȩȭ�鿡�� ���� �� �ִ� ��ư��
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

    //Ȩ ȭ������ ���� ��ư
    public void Back2Home_btnClick()
    {
        BG_MainStory.gameObject.SetActive(false);
        BG_Cha1.gameObject.SetActive(false);
        BG_Cha2.gameObject.SetActive(false);
        BG_Cha3.gameObject.SetActive(false);   
    }

    //BG_MainStory���� ���� �� �ִ� ��ư��
    public void MainStory_1_BtnClick()   //���� Ŭ����, �� ���� Ŭ���� �̹��� ���� �ϴ� ���, ��� no��ư, ���丮üũ ��ư�� �ݿ������ ��
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

    //���� ���丮(ó��) ����? �˾�
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

    //�̰Ŵ� ���丮 �ڸ���. �׽�Ʈ ������ ���� �̹���+ ��ư 
    public void Test_BtnClick()
    {
        Test.gameObject.SetActive(false);
        PopUpBG_Goldplus.gameObject.SetActive(true);
    }

    //�̹� �� ���丮 �� ����? �˾����� �ߴ� ��ư��. �̶� no��ư�� ó�� �� ���丮 �˾��� �����ϴ�
    public void StoryCheck_BtnClick()
    {
       
        PopUpBG_MainStory.gameObject.SetActive(false);
        PopUpBG_Goldplus.gameObject.SetActive(false);
        Test.gameObject.SetActive(false);
        PopUpBG_MainStoryCheck.gameObject.SetActive(false);

    }

    //ĳ���� 1 ���丮 â���� ���� �� �ִ� ��ư��

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

    public GameObject[] sooA = new GameObject[20];
    public GameObject[] bada = new GameObject[20];
    public GameObject[] choLong = new GameObject[20];
    //ĳ���� 1â���� ���� �� �ִ� ��ư��
    public void OnCha_1_Story_BtnClick()
    {
        BG_Cha1_Story.gameObject.SetActive(true);
    }

    public void OnCha_1_1011_BtnClick()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < sooA.Length; i++)
        {
            if (selectGoods == sooA[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[0]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[0]["GoodsDesc"].ToString();
                GoodsName.text = data_Dialog[0]["GoodsName"].ToString();
                //GoodsNum.text = �����͸Ŵ������� ���� ��������
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
    }
        public void OnCha_1_1012_BtnClick()
        {
            GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
            for (int i = 0; i < sooA.Length; i++)
            {
                if (selectGoods == sooA[i])
                {
                    string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                    GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                    GoodsNameText.text = data_Dialog[1]["GoodsName"].ToString();
                    GoodsDesc.text = data_Dialog[1]["GoodsDesc"].ToString();
                GoodsName.text = data_Dialog[1]["GoodsName"].ToString();
                //GoodsNum.text = �����͸Ŵ������� ���� ��������
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
                }
            }
        }

    public void OnCha_1_1013_BtnClick()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < sooA.Length; i++)
        {
            if (selectGoods == sooA[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[2]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[2]["GoodsDesc"].ToString();
                GoodsName.text = data_Dialog[2]["GoodsName"].ToString();
                //GoodsNum.text = �����͸Ŵ������� ���� ��������
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
    }

    public void OnCha_1_1014_BtnClick()
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
                GoodsName.text = data_Dialog[3]["GoodsName"].ToString();
                //GoodsNum.text = �����͸Ŵ������� ���� ��������
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
    }

    public void OnCha_1_1015_BtnClick()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < sooA.Length; i++)
        {
            if (selectGoods == sooA[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[4]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[4]["GoodsDesc"].ToString();
                GoodsName.text = data_Dialog[4]["GoodsName"].ToString();
                //GoodsNum.text = �����͸Ŵ������� ���� ��������
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
    }
    public void OnCha_1_1016_BtnClick()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < sooA.Length; i++)
        {
            if (selectGoods == sooA[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[5]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[5]["GoodsDesc"].ToString();
                GoodsName.text = data_Dialog[5]["GoodsName"].ToString();
                //GoodsNum.text = �����͸Ŵ������� ���� ��������
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
    }

    //ĳ���� 2 ���丮 ȭ�鿡�� ���� �� �ִ� ��ư
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


    //ĳ���� â 2���� ���� �� �ִ� ��ư��
    public void OnCha_2_Story_BtnClick()
    {
        BG_Cha2_Story.gameObject.SetActive(true);
    }

    public void OnCha_2_2011_BtnClick()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < bada.Length; i++)
        {
            if (selectGoods == bada[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[20]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[20]["GoodsDesc"].ToString();
                GoodsName.text = data_Dialog[20]["GoodsName"].ToString();
                //GoodsNum.text = �����͸Ŵ������� ���� ��������
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
    }

    public void OnCha_2_2012_BtnClick()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < bada.Length; i++)
        {
            if (selectGoods == bada[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[21]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[21]["GoodsDesc"].ToString();
                GoodsName.text = data_Dialog[21]["GoodsName"].ToString();
                //GoodsNum.text = �����͸Ŵ������� ���� ��������
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
    }

    public void OnCha_2_2013_BtnClick()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < bada.Length; i++)
        {
            if (selectGoods == bada[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[22]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[22]["GoodsDesc"].ToString();
                GoodsName.text = data_Dialog[22]["GoodsName"].ToString();
                //GoodsNum.text = �����͸Ŵ������� ���� ��������
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
    }

    public void OnCha_2_2014_BtnClick()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < sooA.Length; i++)
        {
            if (selectGoods == sooA[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[23]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[23]["GoodsDesc"].ToString();
                GoodsName.text = data_Dialog[23]["GoodsName"].ToString();
                //GoodsNum.text = �����͸Ŵ������� ���� ��������
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
    }

    public void OnCha_2_2015_BtnClick()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < bada.Length; i++)
        {
            if (selectGoods == bada[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[24]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[24]["GoodsDesc"].ToString();
                GoodsName.text = data_Dialog[24]["GoodsName"].ToString();
                //GoodsNum.text = �����͸Ŵ������� ���� ��������
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
    }
    public void OnCha_2_2016_BtnClick()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < bada.Length; i++)
        {
            if (selectGoods == bada[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[25]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[25]["GoodsDesc"].ToString();
                GoodsName.text = data_Dialog[25]["GoodsName"].ToString();
                //GoodsNum.text = �����͸Ŵ������� ���� ��������
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
    }

    //ĳ���� 3 ���丮 ȭ�鿡�� ���� �� �ִ� ��ư
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

    //ĳ���� 3 ȭ�鿡�� ���� �� �ִ� ��ư��
    public void OnCha_3_Story_BtnClick()
    {
        BG_Cha3_Story.gameObject.SetActive(true);
    }

    public void OnCha_3_3011_BtnClick()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < choLong.Length; i++)
        {
            if (selectGoods == choLong[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[30]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[30]["GoodsDesc"].ToString();
                GoodsName.text = data_Dialog[30]["GoodsName"].ToString();
                //GoodsNum.text = �����͸Ŵ������� ���� ��������
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
    }
    public void OnCha_3_3012_BtnClick()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < choLong.Length; i++)
        {
            if (selectGoods == choLong[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[31]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[31]["GoodsDesc"].ToString();
                GoodsName.text = data_Dialog[31]["GoodsName"].ToString();
                //GoodsNum.text = �����͸Ŵ������� ���� ��������
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
    }

    public void OnCha_3_3013_BtnClick()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < choLong.Length; i++)
        {
            if (selectGoods == choLong[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[32]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[32]["GoodsDesc"].ToString();
                GoodsName.text = data_Dialog[32]["GoodsName"].ToString();
                //GoodsNum.text = �����͸Ŵ������� ���� ��������
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
    }

    public void OnCha_3_3014_BtnClick()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < choLong.Length; i++)
        {
            if (selectGoods == choLong[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[33]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[33]["GoodsDesc"].ToString();
                GoodsName.text = data_Dialog[33]["GoodsName"].ToString();
                //GoodsNum.text = �����͸Ŵ������� ���� ��������
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
    }

    public void OnCha_3_3015_BtnClick()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < choLong.Length; i++)
        {
            if (selectGoods == choLong[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[34]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[34]["GoodsDesc"].ToString();
                GoodsName.text = data_Dialog[34]["GoodsName"].ToString();
                //GoodsNum.text = �����͸Ŵ������� ���� ��������
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
    }
    public void OnCha_3_3016_BtnClick()
    {
        GameObject selectGoods = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < choLong.Length; i++)
        {
            if (selectGoods == choLong[i])
            {
                string imageFileName = data_Dialog[i]["GoodsID"].ToString();
                GoodsImage.sprite = Resources.Load<Sprite>("Goods" + imageFileName);
                GoodsNameText.text = data_Dialog[35]["GoodsName"].ToString();
                GoodsDesc.text = data_Dialog[35]["GoodsDesc"].ToString();
                GoodsName.text = data_Dialog[35]["GoodsName"].ToString();
                //GoodsNum.text = �����͸Ŵ������� ���� ��������
                PopUpBG_GoodsInfo.gameObject.SetActive(true);
            }
        }
    }

    //ĳ���� 1â���� ���ư��� ��ư
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
    //PopUpBG_GoodsInfo ������ ��ư
    public void OnPopUpExit_BtnClick()
    {
        PopUpBG_GoodsInfo.gameObject.SetActive(false);
    }





    //string imageFileName = "Goods1011";
    //Debug.Log(imageFileName);
    //GoodsImage.sprite = Resources.Load<Sprite>(imageFileName); 


    //GoodsNameText.text = data_Dialog[0]["GoodsName"].ToString();
    //GoodsDesc.text = data_Dialog[0]["GoodsDesc"].ToString();

    //PopUpBG_GoodsInfo.gameObject.SetActive(true);



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




    //string imageFileName = data_Dialog[3]["GoodsID"].ToString();
    //GoodsImage.sprite = Resources.Load<Sprite>("Goods"+imageFileName);

    //GoodsNameText.text = data_Dialog[3]["GoodsName"].ToString();
    //GoodsDesc.text = data_Dialog[3]["GoodsDesc"].ToString();
    //PopUpBG_GoodsInfo.gameObject.SetActive(true);





}