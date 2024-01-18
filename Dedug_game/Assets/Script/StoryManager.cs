using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StoryManager : MonoBehaviour
{
    public Text NameText;
    public Text TalkText;
    public Button TalkBtn;
    public Image TalkBG;
    public Image ChrL;
    public Image ChrR;
    public Image ChrM;
    public string ChrLName;
    public string ChrRName;
    public string ChrMName;

    public Button SkipBtn;
    public Button PopUPCancelBtn;
    public Button PopUPSkipBtn;
    public Image SkipImg;

    public int ClickNum;

    private List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();
    private const string StoryFileName = "StoryTable";
    private char[] TRIM_CHARS = { ' ', '\"' };

    private void Awake()
    {
        DataManager.Instance.storyID = PlayerPrefs.GetInt("StoryID");
        
    }

    private void Start()
    {


        SkipImg.gameObject.SetActive(false);
        data_Dialog = CSVReader.Read(StoryFileName);

        if (DataManager.Instance.storyID == 11)
        {
            ClickNum = 69;
            
            //이건 클릭한 스토리의 시작을 어디서부터 하는지 정해주는 작업, 추후 완성 테이블 기반으로 ClickNum에 해당 열로 수정
        }
        else if (DataManager.Instance.storyID == 12)
        {
            ClickNum = 93;
            
        }
        else if (DataManager.Instance.storyID == 13)
        {
            ClickNum = 0;
           

        }
        else if (DataManager.Instance.storyID == 21)
        {
            ClickNum = 0;
            
        }
        else if (DataManager.Instance.storyID == 22)
        {
            ClickNum = 0;
            
        }
        else if (DataManager.Instance.storyID == 23)
        {
            ClickNum = 0;
            
        }
        else if (DataManager.Instance.storyID == 31)
        {
            ClickNum = 0;
            
        }
        else if (DataManager.Instance.storyID == 32)
        {
            ClickNum = 0;
            
        }
        else if (DataManager.Instance.storyID == 32)
        {
            ClickNum = 0;
            
        }
        else if (DataManager.Instance.storyID == 41)
        {
            ClickNum = 0;
            
        }
        else if (DataManager.Instance.storyID == 42)
        {
            ClickNum = 18;
            
        }
        else if (DataManager.Instance.storyID == 43)
        {
            ClickNum = 39;
            
        }
        

        Debug.Log(DataManager.Instance.storyID);
        TalkText.text = data_Dialog[ClickNum]["TalkText"].ToString();
        NameText.text = data_Dialog[ClickNum]["ChaName"].ToString();

        ChrLName = data_Dialog[ClickNum]["ChrL"].ToString();
        ChrL.sprite = Resources.Load<Sprite>(ChrLName);
        ChrRName = data_Dialog[ClickNum]["ChrR"].ToString();
        ChrR.sprite = Resources.Load<Sprite>(ChrRName);
        ChrMName = data_Dialog[ClickNum]["ChrM"].ToString();
        ChrM.sprite = Resources.Load<Sprite>(ChrMName);
    }

    public void TextClick()
    {
       

        TalkText.text = data_Dialog[ClickNum]["TalkText"].ToString();
        NameText.text = data_Dialog[ClickNum]["ChaName"].ToString();

        ChrLName = data_Dialog[ClickNum]["ChrL"].ToString();
        ChrL.sprite = Resources.Load<Sprite>(ChrLName);
        ChrRName = data_Dialog[ClickNum]["ChrR"].ToString();
        ChrR.sprite = Resources.Load<Sprite>(ChrRName);
        ChrMName = data_Dialog[ClickNum]["ChrM"].ToString();
        ChrM.sprite = Resources.Load<Sprite>(ChrMName);

        object EndID;
        bool hasEndID = data_Dialog[ClickNum].TryGetValue("End", out EndID);
        if (hasEndID && EndID != null && !string.IsNullOrEmpty(EndID.ToString()))
        {
            SceneManager.LoadScene("DG_Scene");
        }

        ClickNum++;


    }    

    public void SkipBtnClick()
    {
        SkipImg.gameObject.SetActive(true);
    }

    public void PopUPSkipBtnClick()
    {
        
        SceneManager.LoadScene("DG_Scene");
    }

    public void PopUPCancelBtnClick()
    {
        SkipImg.gameObject.SetActive(false);
    }

    public AudioSource BGM;
    public AudioClip Bgm1; 
    public void ChangeBGM()
    {
        //BGM개수에 따라서 해당부분 늘리면 된다.
        if (data_Dialog[ClickNum]["BGM"].ToString() == "0")
        {
            BGM.Stop();
        }
        else if(data_Dialog[ClickNum]["BGM"].ToString() == "1")
        {
            BGM.clip = Bgm1;
            BGM.Play();
        }
    }
    
}
