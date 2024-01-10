using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class ResultManager : MonoBehaviour
{
    public string gameName;


    // UI 요소들
    public Image ResultBG;
    public Image ScoreBG;
    public Text Scoretxt;
    public Text Rewardtxt;
    public Button Restart;
    public Button HomeBtn;

    // 각종 효과 및 결과를 나타내는 텍스트들
    public Text UserScoreText;
    int UserScore;

    // 게임 오브젝트 및 캔버스 관련 변수
    private Image Reward1, Reward2, Reward3;

    //CSV 파일에서 뽑아 올 내용
    private List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();
    private const string ResultTableFileName = "ResultTable";
    private char[] TRIM_CHARS = { ' ', '\"' };

    //숫자값 가져올거
    int Result1;
    int Result2;
    int Result3;


     //스트링값 가져올거
   
         private void Awake()
     {
         DataManager.Instance.nowGold = PlayerPrefs.GetInt("NowGold");
         DataManager.Instance.nowRank = PlayerPrefs.GetInt("NowRank");
         DataManager.Instance.goods3011 = PlayerPrefs.GetInt("Goods3011");

     }
     
    


    private void Start()
    {


        //어떤 컴포넌트에 배정할거임?
        ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        Restart = GameObject.Find("Restart").GetComponent<Button>();
        HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        UserScoreText = GameObject.Find("UserScore").GetComponent<Text>();

        // Reward 이미지들 찾기
        Reward1 = GameObject.Find("Reward1").GetComponent<Image>();
        Reward2 = GameObject.Find("Reward2").GetComponent<Image>();
        Reward3 = GameObject.Find("Reward3").GetComponent<Image>();
        CheckRewards();
        GatchaSetting();
    }

    List<int> gatchaList = new List<int>();

    void GatchaSetting()
    {
        // CustomerCSV 파일에서 랜덤한 행 가져오기
        List<Dictionary<string, string>> csvData = RequestCSVReader.Read("ResultTable");

        // NowRank에 따라 불러올 수 있는 Grade 값의 범위를 설정
        int minRankValue = 0;
        int maxRankValue = DataManager.Instance.nowRank;

        // CSV에서 랜덤한 행 중에서 조건에 맞는 행을 선택
        List<Dictionary<string, string>> filteredData = csvData
            .Where(row => int.TryParse(row["rank"], out int rank) && rank >= minRankValue && rank <= maxRankValue)
            .ToList();

        Dictionary<string, string> randomRow = filteredData[UnityEngine.Random.Range(0, filteredData.Count)];

        string imageFileName = "Goods" + randomRow["goodsID"];

        Reward1.sprite = Resources.Load<Sprite>(imageFileName);



        // CustomerCSV 파일에서 랜덤한 행 가져오기
        List<Dictionary<string, string>> csvData2 = RequestCSVReader.Read("ResultTable");

        // CSV에서 랜덤한 행 중에서 조건에 맞는 행을 선택
        List<Dictionary<string, string>> filteredData2 = csvData2
            .Where(row => int.TryParse(row["rank"], out int rank) && rank >= minRankValue && rank <= maxRankValue)
            .ToList();

        Dictionary<string, string> randomRow2 = filteredData2[UnityEngine.Random.Range(0, filteredData2.Count)];

        string imageFileName2 = "Goods" + randomRow2["goodsID"];

        Reward2.sprite = Resources.Load<Sprite>(imageFileName);



        // CustomerCSV 파일에서 랜덤한 행 가져오기
        List<Dictionary<string, string>> csvData3 = RequestCSVReader.Read("ResultTable");

        // CSV에서 랜덤한 행 중에서 조건에 맞는 행을 선택
        List<Dictionary<string, string>> filteredData3 = csvData3
            .Where(row => int.TryParse(row["rank"], out int rank) && rank >= minRankValue && rank <= maxRankValue)
            .ToList();

        Dictionary<string, string> randomRow3 = filteredData3[UnityEngine.Random.Range(0, filteredData3.Count)];

        string imageFileName3 = "Goods" + randomRow3["goodsID"];


        Reward3.sprite = Resources.Load<Sprite>(imageFileName);



        if (Result1 >= UserScore)
        {
            Reward1.gameObject.SetActive(true);
            int UserGoods1 = int.Parse(randomRow["goodsID"]);
        }

        if (Result2 >= UserScore && UserScore > Result1)
        {
            Reward1.gameObject.SetActive(true);
            Reward2.gameObject.SetActive(true);

            int UserGoods1 = int.Parse(randomRow["goodsID"]);
            int UserGoods2 = int.Parse(randomRow2["goodsID"]);
        }
        
        if (Result3 <= UserScore)
        {
            Reward1.gameObject.SetActive(true);
            Reward2.gameObject.SetActive(true);
            Reward3.gameObject.SetActive(true);

            int UserGoods1 = int.Parse(randomRow["goodsID"]);
            int UserGoods2 = int.Parse(randomRow2["goodsID"]);
            int UserGoods3 = int.Parse(randomRow3["goodsID"]);

        }
    }

    int GameYJ = 0;
    int GameHR = 1;
    int GameHN = 2;

    //자신 게임 이니셜을 적어주세요!
    string GameName = "YJ";

    void CheckRewards()
    {
        if(data_Dialog[GameYJ]["GameName"].ToString() == GameName)
        {
            Result1 = Convert.ToInt32(data_Dialog[0]["Result1"]);
            Result2 = Convert.ToInt32(data_Dialog[0]["Result2"]);
            Result3 = Convert.ToInt32(data_Dialog[0]["Result3"]);
        }

    }


    /*
    public void Save()
    {
        
        // PlayerPrefs에 현재 값 저장
        PlayerPrefs.SetInt("UserGoods1", DataManager.Instance.User);
        PlayerPrefs.Save();
        
    }*/




    public void RestartClick()
    {
        SceneManager.LoadScene("GoodsBuyScene");
    }

    public void HomeClick()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
