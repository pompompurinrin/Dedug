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
    public Canvas SkipCanvas;

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
        SkipCanvas.gameObject.SetActive(false);
        data_Dialog = CSVReader.Read(StoryFileName);

    }

    public void TextClick()
    {
        if (DataManager.Instance.storyID == 11)
        {
            //ClickNum = 0;
            //이건 클릭한 스토리의 시작을 어디서부터 하는지 정해주는 작업, 추후 완성 테이블 기반으로 ClickNum에 해당 열로 수정
        }
        else if (DataManager.Instance.storyID == 12)
        {
            //ClickNum = 0;
        }
        else if (DataManager.Instance.storyID == 13)
        {
            //ClickNum = 0;
        }
        else if (DataManager.Instance.storyID == 21)
        {
            //ClickNum = 0;
        }
        else if (DataManager.Instance.storyID == 22)
        {
            //ClickNum = 0;
        }
        else if (DataManager.Instance.storyID == 23)
        {
            //ClickNum = 0;
        }
        else if (DataManager.Instance.storyID == 31)
        {
            //ClickNum = 0;
        }
        else if (DataManager.Instance.storyID == 41)
        {
            //ClickNum = 0;
        }
        else if (DataManager.Instance.storyID == 42)
        {
            //ClickNum = 0;
        }
        else if(DataManager.Instance.storyID == 43)
        {
            //ClickNum = 0;
        }

        TalkText.text = data_Dialog[ClickNum]["TalkText"].ToString();
        NameText.text = data_Dialog[ClickNum]["ChaName"].ToString();

        ChrLName = data_Dialog[ClickNum]["ChrL"].ToString();
        ChrL.sprite = Resources.Load<Sprite>(ChrLName);
        ChrRName = data_Dialog[ClickNum]["ChrR"].ToString();
        ChrR.sprite = Resources.Load<Sprite>(ChrRName);
        ChrMName = data_Dialog[ClickNum]["ChrM"].ToString();
        ChrM.sprite = Resources.Load<Sprite>(ChrMName);

        object EndID;
        bool hasEndID = data_Dialog[ClickNum].TryGetValue("next ID", out EndID);
        if (hasEndID && EndID != null && !string.IsNullOrEmpty(EndID.ToString()))
        {
            SceneManager.LoadScene("DG_Scene");
        }

        ClickNum++;


    }    

    public void SkipBtnClick()
    {
        SkipCanvas.gameObject.SetActive(true);
    }

    public void PopUPSkipBtnClick()
    {
        SceneManager.LoadScene("DG_Scene");
    }

    public void PopUPCancelBtnClick()
    {
        SkipCanvas.gameObject.SetActive(false);
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
        else if(data_Dialog[ClickNum]["BGM"].ToString() == "2")
        {
            BGM.clip = Bgm1;
            BGM.Play();
        }
    }

}
