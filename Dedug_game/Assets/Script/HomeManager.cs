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
    // CSV ������ �о���� ������ ����Ʈ

    
    // CSV ������ �о���� ������ ����Ʈ
    private List<Dictionary<string, object>> homeDiaSample = new List<Dictionary<string, object>>();
    private const string homeDiaSampleFileName = "HomeDiaSample";
    


    
    List<string> suaList = new List<string>();
    List<string> badaList = new List<string>();
    List<string> cholongList = new List<string>();

    List<string> nameList = new List<string>();

    


    public void Start()
    {
        Debug.Log("Ȩ:" + DataManager.Instance.goods1011);
        GameObject ChangeCharPopup = GameObject.Find("ChangeCharPopup");
        GameObject MenuUI = GameObject.Find("MenuUI");
        PopupCanvas = GameObject.Find("PopupCanvas").GetComponent<Canvas>();
        GameObject GoodsBuy = GameObject.Find("GoodsBuy");

        if(DataManager.Instance.nowRank == 0)
        {
            PurposeBtnText.text = "���� ��Ȧ�� ȹ���ϱ�";
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
            PurposeBtnText.text = "�ٴ� L Ȧ�� ȹ���ϱ�";
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
            PurposeBtnText.text = "�ʷ� ��ũ�����ĵ� ȹ���ϱ�";
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
            PurposeBtnText.text = "�ٴ� ���ǽ�Ʈ�� ȹ���ϱ�";
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
            PurposeBtnText.text = "��� ���� ȹ���ϱ�";
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
        
        //���� �� �˾��� ��Ȱ��ȭ

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
        // ĳ���� ��ü �˾��� Ȱ��ȭ

        ChangeCharPopup.SetActive(true);
    }

    public void OnButtonClick_OffChangeCharPopup()
    {
        // ĳ���� ��ü �˾��� ��Ȱ��ȭ

        ChangeCharPopup.SetActive(false);
    }

    public void OnButtonClick_OnGoodsBuy()
    {
        // ���� ���� �˾� Ȱ��ȭ
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

