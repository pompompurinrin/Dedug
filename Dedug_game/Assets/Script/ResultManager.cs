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
    public Image Reward1, Reward2, Reward3;

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
        Reward1 = Reward1.gameObject.GetComponent<Image>();
        Reward2 = Reward2.gameObject.GetComponent<Image>();
        Reward3 = Reward3.gameObject.GetComponent<Image>();

        CheckRewards();
        GatchaSetting();
    }

    List<int> gatchaList = new List<int>();


    void GatchaSetting()
    {   //CSV���� ���� �� ��� ��ũ�� �´� ���������� Ȯ��

        List<Dictionary<string, string>> csvData = RequestCSVReader.Read("ResultTable");
        int minRankValue = 0;
        int maxRankValue = DataManager.Instance.nowRank;



        //������1 �����̱�
        List<Dictionary<string, string>> filteredData = csvData
              .Where(row => int.TryParse(row["rank"], out int rank) && rank >= minRankValue && rank <= maxRankValue)
              .ToList();
        Dictionary<string, string> randomRow = filteredData[UnityEngine.Random.Range(0, filteredData.Count)];

        //������2 �����̱�
        List<Dictionary<string, string>> csvData2 = RequestCSVReader.Read("ResultTable");
        List<Dictionary<string, string>> filteredData2 = csvData2
            .Where(row => int.TryParse(row["rank"], out int rank) && rank >= minRankValue && rank <= maxRankValue)
            .ToList();
        Dictionary<string, string> randomRow2 = filteredData2[UnityEngine.Random.Range(0, filteredData2.Count)];

        //������3 �����̱�
        List<Dictionary<string, string>> csvData3 = RequestCSVReader.Read("ResultTable");
        List<Dictionary<string, string>> filteredData3 = csvData3
            .Where(row => int.TryParse(row["rank"], out int rank) && rank >= minRankValue && rank <= maxRankValue)
            .ToList();
        Dictionary<string, string> randomRow3 = filteredData3[UnityEngine.Random.Range(0, filteredData3.Count)];


        //������� ��������Ʈ ���
        string imageFileName = "Goods" + randomRow["goodsID"];
        Reward1.sprite = Resources.Load<Sprite>(imageFileName);

        string imageFileName2 = "Goods" + randomRow2["goodsID"];
        Reward2.sprite = Resources.Load<Sprite>(imageFileName);

        string imageFileName3 = "Goods" + randomRow3["goodsID"];
        Reward3.sprite = Resources.Load<Sprite>(imageFileName);

        //���� ����
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

    //�ڽ� ���� �̴ϼ��� �����ּ���!
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
        // PlayerPrefs�� ���� �� ����
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