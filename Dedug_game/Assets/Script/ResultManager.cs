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
    public Image Reward1, Reward2, Reward3;

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
        Reward1 = Reward1.gameObject.GetComponent<Image>();
        Reward2 = Reward2.gameObject.GetComponent<Image>();
        Reward3 = Reward3.gameObject.GetComponent<Image>();

        CheckRewards();
        GatchaSetting();
    }

    List<int> gatchaList = new List<int>();


    void GatchaSetting()
    {   //CSV에서 지급 할 굿즈가 랭크에 맞는 굿즈인지를 확인

        List<Dictionary<string, string>> csvData = RequestCSVReader.Read("ResultTable");
        int minRankValue = 0;
        int maxRankValue = DataManager.Instance.nowRank;



        //리워드1 랜덤뽑기
        List<Dictionary<string, string>> filteredData = csvData
              .Where(row => int.TryParse(row["rank"], out int rank) && rank >= minRankValue && rank <= maxRankValue)
              .ToList();
        Dictionary<string, string> randomRow = filteredData[UnityEngine.Random.Range(0, filteredData.Count)];

        //리워드2 랜덤뽑기
        List<Dictionary<string, string>> csvData2 = RequestCSVReader.Read("ResultTable");
        List<Dictionary<string, string>> filteredData2 = csvData2
            .Where(row => int.TryParse(row["rank"], out int rank) && rank >= minRankValue && rank <= maxRankValue)
            .ToList();
        Dictionary<string, string> randomRow2 = filteredData2[UnityEngine.Random.Range(0, filteredData2.Count)];

        //리워드3 랜덤뽑기
        List<Dictionary<string, string>> csvData3 = RequestCSVReader.Read("ResultTable");
        List<Dictionary<string, string>> filteredData3 = csvData3
            .Where(row => int.TryParse(row["rank"], out int rank) && rank >= minRankValue && rank <= maxRankValue)
            .ToList();
        Dictionary<string, string> randomRow3 = filteredData3[UnityEngine.Random.Range(0, filteredData3.Count)];


        //리워드들 스프라이트 출력
        string imageFileName = "Goods" + randomRow["goodsID"];
        Reward1.sprite = Resources.Load<Sprite>(imageFileName);

        string imageFileName2 = "Goods" + randomRow2["goodsID"];
        Reward2.sprite = Resources.Load<Sprite>(imageFileName);

        string imageFileName3 = "Goods" + randomRow3["goodsID"];
        Reward3.sprite = Resources.Load<Sprite>(imageFileName);

        //굿즈 지급
        if (Result1 >= UserScore)
        {
            Reward1.gameObject.SetActive(true);
            int UserGoods1 = int.Parse(randomRow["goodsID"]);
            Save();
        }

        if (Result2 >= UserScore && UserScore > Result1)
        {
            Reward1.gameObject.SetActive(true);
            Reward2.gameObject.SetActive(true);

            int UserGoods1 = int.Parse(randomRow["goodsID"]);
            int UserGoods2 = int.Parse(randomRow2["goodsID"]);
            Save();
        }

        if (Result3 <= UserScore)
        {
            Reward1.gameObject.SetActive(true);
            Reward2.gameObject.SetActive(true);
            Reward3.gameObject.SetActive(true);

            int UserGoods1 = int.Parse(randomRow["goodsID"]);
            int UserGoods2 = int.Parse(randomRow2["goodsID"]);
            int UserGoods3 = int.Parse(randomRow3["goodsID"]);
            Save();
        }

    }




    int GameYJ = 0;
    int GameHR = 1;
    int GameHN = 2;

    //자신 게임 이니셜을 적어주세요!
    string GameName = "YJ";

    void CheckRewards()
    {
        if (data_Dialog[GameYJ]["GameName"].ToString() == GameName)
        {
            Result1 = Convert.ToInt32(data_Dialog[0]["Result1"]);
            Result2 = Convert.ToInt32(data_Dialog[0]["Result2"]);
            Result3 = Convert.ToInt32(data_Dialog[0]["Result3"]);
        }

    }

    public void Save()
    {
        // PlayerPrefs에 현재 값 저장
        PlayerPrefs.SetInt("Goods1011", DataManager.Instance.goods1011);
        PlayerPrefs.SetInt("Goods1012", DataManager.Instance.goods1012);
        PlayerPrefs.SetInt("Goods1021", DataManager.Instance.goods1021);
        PlayerPrefs.SetInt("Goods1022", DataManager.Instance.goods1022);
        PlayerPrefs.SetInt("Goods1031", DataManager.Instance.goods1031);
        PlayerPrefs.SetInt("Goods1032", DataManager.Instance.goods1032);

        PlayerPrefs.SetInt("Goods2011", DataManager.Instance.goods2011);
        PlayerPrefs.SetInt("Goods2012", DataManager.Instance.goods2012);
        PlayerPrefs.SetInt("Goods2021", DataManager.Instance.goods2021);
        PlayerPrefs.SetInt("Goods2022", DataManager.Instance.goods2022);
        PlayerPrefs.SetInt("Goods2031", DataManager.Instance.goods2031);
        PlayerPrefs.SetInt("Goods2032", DataManager.Instance.goods2032);

        PlayerPrefs.SetInt("Goods3011", DataManager.Instance.goods3011);
        PlayerPrefs.SetInt("Goods3012", DataManager.Instance.goods3012);
        PlayerPrefs.SetInt("Goods3021", DataManager.Instance.goods3021);
        PlayerPrefs.SetInt("Goods3022", DataManager.Instance.goods3022);
        PlayerPrefs.SetInt("Goods3031", DataManager.Instance.goods3031);
        PlayerPrefs.SetInt("Goods3032", DataManager.Instance.goods3032);
        PlayerPrefs.Save();

    }


    public void RestartClick()
    {
        SceneManager.LoadScene("GoodsBuyScene");
    }

    public void HomeClick()
    {
        SceneManager.LoadScene("HomeScene");
    }



}