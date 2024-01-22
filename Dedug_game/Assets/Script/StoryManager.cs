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
    public Image StoryBG;

    public Sprite Story_BG1;
    public Sprite Story_BG2;
    public Sprite Story_BG3;
    public Sprite Story_BG4;
    public Sprite Story_BG5;
    public Sprite Story_BG6;
    public Sprite Story_BG7;
    public Sprite Story_BG8;
    public Sprite Story_BG9;
    public Sprite Story_BG10;

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

        BGM = transform.GetComponentInChildren<AudioSource>();
        SkipImg.gameObject.SetActive(false);
        data_Dialog = CSVReader.Read(StoryFileName);
        if (DataManager.Instance.storyID == 0)
        {
            ClickNum = 514;
            DataManager.Instance.first = 1;
            PlayerPrefs.SetInt("First", DataManager.Instance.first);
        }
        else if (DataManager.Instance.storyID ==11)
        {
            ClickNum = 86;
            
            //이건 클릭한 스토리의 시작을 어디서부터 하는지 정해주는 작업, 추후 완성 테이블 기반으로 ClickNum에 해당 열로 수정
        }
        else if (DataManager.Instance.storyID == 12)
        {
            ClickNum = 130;
            
        }
        else if (DataManager.Instance.storyID == 13)
        {
            ClickNum = 189;
           

        }
        else if (DataManager.Instance.storyID == 21)
        {
            ClickNum = 242;
            
        }
        else if (DataManager.Instance.storyID == 22)
        {
            ClickNum = 286;
            
        }
        else if (DataManager.Instance.storyID == 23)
        {
            ClickNum = 337;
            
        }
        else if (DataManager.Instance.storyID == 31)
        {
            ClickNum = 386;
            
        }
        else if (DataManager.Instance.storyID == 32)
        {
            ClickNum = 425;
            
        }
        else if (DataManager.Instance.storyID == 33)
        {
            ClickNum = 476;
            
        }
        else if (DataManager.Instance.storyID == 41)
        {
            ClickNum = 0;
            
        }
        else if (DataManager.Instance.storyID == 42)
        {
            ClickNum = 31;
            
        }
        else if (DataManager.Instance.storyID == 43)
        {
            ClickNum = 53;
            
        }
        else if (DataManager.Instance.storyID == 99)
        {
            ClickNum = 561;

            
        }

        Debug.Log(DataManager.Instance.storyID);
        TalkText.text = data_Dialog[ClickNum]["TalkText"].ToString();
        NameText.text = data_Dialog[ClickNum]["ChaName"].ToString();
        ChangeBG();
        ChangeBGM();
        ChrLName = data_Dialog[ClickNum]["ChrL"].ToString();
        ChrL.sprite = Resources.Load<Sprite>(ChrLName);
        ChrRName = data_Dialog[ClickNum]["ChrR"].ToString();
        ChrR.sprite = Resources.Load<Sprite>(ChrRName);
        ChrMName = data_Dialog[ClickNum]["ChrM"].ToString();
        ChrM.sprite = Resources.Load<Sprite>(ChrMName);
        ClickNum++;
    }

    public void ChangeBG()
    {
        if(data_Dialog[ClickNum]["TalkBG"].ToString() == "1")
        {
            StoryBG.sprite = Story_BG1;
        }
        else if (data_Dialog[ClickNum]["TalkBG"].ToString() == "2")
        {
            StoryBG.sprite = Story_BG2;
        }
        else if (data_Dialog[ClickNum]["TalkBG"].ToString() == "3")
        {
            StoryBG.sprite = Story_BG3;
        }
        else if (data_Dialog[ClickNum]["TalkBG"].ToString() == "4")
        {
            StoryBG.sprite = Story_BG4;
        }
        else if (data_Dialog[ClickNum]["TalkBG"].ToString() == "5")
        {
            StoryBG.sprite = Story_BG5;
        }
        else if (data_Dialog[ClickNum]["TalkBG"].ToString() == "6")
        {
            StoryBG.sprite = Story_BG6;
        }
        else if (data_Dialog[ClickNum]["TalkBG"].ToString() == "7")
        {
            StoryBG.sprite = Story_BG7;
        }
        else if (data_Dialog[ClickNum]["TalkBG"].ToString() == "8")
        {
            StoryBG.sprite = Story_BG8;
        }
        else if (data_Dialog[ClickNum]["TalkBG"].ToString() == "9")
        {
            StoryBG.sprite = Story_BG9;
        }
        else if (data_Dialog[ClickNum]["TalkBG"].ToString() == "10")
        {
            StoryBG.sprite = Story_BG10;
        }

    }

    public void TextClick()
    {
       

        TalkText.text = data_Dialog[ClickNum]["TalkText"].ToString();
        NameText.text = data_Dialog[ClickNum]["ChaName"].ToString();
        ChangeBG();
        ChangeBGM();
        ChrLName = data_Dialog[ClickNum]["ChrL"].ToString();
        ChrL.sprite = Resources.Load<Sprite>(ChrLName);
        ChrRName = data_Dialog[ClickNum]["ChrR"].ToString();
        ChrR.sprite = Resources.Load<Sprite>(ChrRName);
        ChrMName = data_Dialog[ClickNum]["ChrM"].ToString();
        ChrM.sprite = Resources.Load<Sprite>(ChrMName);

        object EndID;
        bool hasEndID = data_Dialog[ClickNum].TryGetValue("End", out EndID);
        if (hasEndID && EndID != null && !string.IsNullOrEmpty(EndID.ToString()) && DataManager.Instance.storyID == 0)
        {
            SceneManager.LoadScene("HomeScene");
        }
        else if (hasEndID && EndID != null && !string.IsNullOrEmpty(EndID.ToString()) && DataManager.Instance.storyID == 99)
        {
            SceneManager.LoadScene("StartScene");
        }
        else if (hasEndID && EndID != null && !string.IsNullOrEmpty(EndID.ToString()))
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
        if (DataManager.Instance.storyID == 99)
        {
            SceneManager.LoadScene("StartScene");
        }
        else
        {
            SceneManager.LoadScene("DG_Scene");
        }
    }

    public void PopUPCancelBtnClick()
    {
        SkipImg.gameObject.SetActive(false);
    }

    public AudioSource BGM;
    public AudioClip Bgm1;
    public AudioClip Bgm2;
    public AudioClip Bgm3;
    public AudioClip Bgm4;
    public AudioClip Bgm5;
    public AudioClip Bgm6;
    public AudioClip Bgm7;
    public AudioClip Bgm8;
    public void ChangeBGM()
    {
        //BGM개수에 따라서 해당부분 늘리면 된다.
        if (data_Dialog[ClickNum]["Bgm"].ToString() == "0")
        {
            BGM.Stop();
        }
        else if(data_Dialog[ClickNum]["Bgm"].ToString() == "1")
        {
            BGM.clip = Bgm1;
            BGM.Play();
        }
        else if (data_Dialog[ClickNum]["Bgm"].ToString() == "2")
        {
            BGM.clip = Bgm2;
            BGM.Play();
        }
        else if (data_Dialog[ClickNum]["Bgm"].ToString() == "3")
        {
            BGM.clip = Bgm3;
            BGM.Play();
        }
        else if (data_Dialog[ClickNum]["Bgm"].ToString() == "4")
        {
            BGM.clip = Bgm4;
            BGM.Play();
        }
        else if (data_Dialog[ClickNum]["Bgm"].ToString() == "5")
        {
            BGM.clip = Bgm5;
            BGM.Play();

        }
        else if (data_Dialog[ClickNum]["Bgm"].ToString() == "6")
        {
            BGM.clip = Bgm6;
            BGM.Play();
        }
        else if (data_Dialog[ClickNum]["Bgm"].ToString() == "7")
        {
            BGM.clip = Bgm7;
            BGM.Play();
        }
        else if (data_Dialog[ClickNum]["Bgm"].ToString() == "8")
        {
            BGM.clip = Bgm8;
            BGM.Play();
        }
    }
    
}
