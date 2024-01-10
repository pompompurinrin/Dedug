using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class ResultManager : MonoBehaviour
{
    public string gameName;


    // UI ��ҵ�
    public Image ResultBG;
    public Image ScoreBG;
    public Text Scoretxt;
    public Text Rewardtxt;
    public Button Restart;
    public Button HomeBtn;

    // ���� ȿ�� �� ����� ��Ÿ���� �ؽ�Ʈ��
    public Text UserScoreText;
    int UserScore;

    // ���� ������Ʈ �� ĵ���� ���� ����
    private Image Reward1, Reward2, Reward3;

    //CSV ���Ͽ��� �̾� �� ����
    private List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();
    private const string ResultTableFileName = "ResultTable";
    private char[] TRIM_CHARS = { ' ', '\"' };

    //���ڰ� �����ð�
    int Result1;
    int Result2;
    int Result3;


     //��Ʈ���� �����ð�
   
         private void Awake()
     {
         DataManager.Instance.nowGold = PlayerPrefs.GetInt("NowGold");
         DataManager.Instance.nowRank = PlayerPrefs.GetInt("NowRank");
         DataManager.Instance.goods3011 = PlayerPrefs.GetInt("Goods3011");

     }
     
    


    private void Start()
    {


        //� ������Ʈ�� �����Ұ���?
        ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        Restart = GameObject.Find("Restart").GetComponent<Button>();
        HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        UserScoreText = GameObject.Find("UserScore").GetComponent<Text>();

        // Reward �̹����� ã��
        Reward1 = GameObject.Find("Reward1").GetComponent<Image>();
        Reward2 = GameObject.Find("Reward2").GetComponent<Image>();
        Reward3 = GameObject.Find("Reward3").GetComponent<Image>();
        CheckRewards();
        GatchaSetting();
    }

    List<int> gatchaList = new List<int>();

    void GatchaSetting()
    {
        // CustomerCSV ���Ͽ��� ������ �� ��������
        List<Dictionary<string, string>> csvData = RequestCSVReader.Read("ResultTable");

        // NowRank�� ���� �ҷ��� �� �ִ� Grade ���� ������ ����
        int minRankValue = 0;
        int maxRankValue = DataManager.Instance.nowRank;

        // CSV���� ������ �� �߿��� ���ǿ� �´� ���� ����
        List<Dictionary<string, string>> filteredData = csvData
            .Where(row => int.TryParse(row["rank"], out int rank) && rank >= minRankValue && rank <= maxRankValue)
            .ToList();

        Dictionary<string, string> randomRow = filteredData[UnityEngine.Random.Range(0, filteredData.Count)];

        string imageFileName = "Goods" + randomRow["goodsID"];

        Reward1.sprite = Resources.Load<Sprite>(imageFileName);



        // CustomerCSV ���Ͽ��� ������ �� ��������
        List<Dictionary<string, string>> csvData2 = RequestCSVReader.Read("ResultTable");

        // CSV���� ������ �� �߿��� ���ǿ� �´� ���� ����
        List<Dictionary<string, string>> filteredData2 = csvData2
            .Where(row => int.TryParse(row["rank"], out int rank) && rank >= minRankValue && rank <= maxRankValue)
            .ToList();

        Dictionary<string, string> randomRow2 = filteredData2[UnityEngine.Random.Range(0, filteredData2.Count)];

        string imageFileName2 = "Goods" + randomRow2["goodsID"];

        Reward2.sprite = Resources.Load<Sprite>(imageFileName);



        // CustomerCSV ���Ͽ��� ������ �� ��������
        List<Dictionary<string, string>> csvData3 = RequestCSVReader.Read("ResultTable");

        // CSV���� ������ �� �߿��� ���ǿ� �´� ���� ����
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

    //�ڽ� ���� �̴ϼ��� �����ּ���!
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
        
        // PlayerPrefs�� ���� �� ����
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
