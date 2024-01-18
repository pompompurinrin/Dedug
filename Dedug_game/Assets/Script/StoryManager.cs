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

    private void Start()
    {


        SkipImg.gameObject.SetActive(false);
        data_Dialog = CSVReader.Read(StoryFileName);

        if (DataManager.Instance.storyID == 11)
        {
            ClickNum = 69;
            DataManager.Instance.story1_1 = 1;
            //이건 클릭한 스토리의 시작을 어디서부터 하는지 정해주는 작업, 추후 완성 테이블 기반으로 ClickNum에 해당 열로 수정
        }
        else if (DataManager.Instance.storyID == 12)
        {
            ClickNum = 93;
            DataManager.Instance.story1_2 = 1;
        }
        else if (DataManager.Instance.storyID == 13)
        {
            ClickNum = 0;
            DataManager.Instance.story1_3 = 1;

        }
        else if (DataManager.Instance.storyID == 21)
        {
            ClickNum = 0;
            DataManager.Instance.story2_1 = 1;
        }
        else if (DataManager.Instance.storyID == 22)
        {
            ClickNum = 0;
            DataManager.Instance.story2_2 = 1;
        }
        else if (DataManager.Instance.storyID == 23)
        {
            ClickNum = 0;
            DataManager.Instance.story2_3 = 1;
        }
        else if (DataManager.Instance.storyID == 31)
        {
            ClickNum = 0;
            DataManager.Instance.story3_1 = 1;
        }
        else if (DataManager.Instance.storyID == 32)
        {
            ClickNum = 0;
            DataManager.Instance.story3_2 = 1;
        }
        else if (DataManager.Instance.storyID == 32)
        {
            ClickNum = 0;
            DataManager.Instance.story3_3 = 1;
        }
        else if (DataManager.Instance.storyID == 41)
        {
            ClickNum = 0;
            DataManager.Instance.story4_1 = 1;
        }
        else if (DataManager.Instance.storyID == 42)
        {
            ClickNum = 18;
            DataManager.Instance.story4_2 = 1;
        }
        else if (DataManager.Instance.storyID == 43)
        {
            ClickNum = 39;
            DataManager.Instance.story4_3 = 1;
        }
        Save();
        Debug.Log(DataManager.Instance.story1_1);
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
        if (DataManager.Instance.storyID == 11)
        {
            DataManager.Instance.story1_1 = 1;
            //이건 클릭한 스토리의 시작을 어디서부터 하는지 정해주는 작업, 추후 완성 테이블 기반으로 ClickNum에 해당 열로 수정
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
        else if (DataManager.Instance.storyID == 32)
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
}
