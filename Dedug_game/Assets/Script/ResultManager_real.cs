using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using UnityEngine.EventSystems;
using System.Collections;
using Unity.VisualScripting;
using Unity.Mathematics;

public class ResultManager_real : MonoBehaviour
{

    // UI ��ҵ�
    public Image ResultBG;
    public Image ScoreBG;
    public Text Scoretxt;
    public Text Rewardtxt;
    public Button Restart;
    public Button HomeBtn;

    // ���� ȿ�� �� ����� ��Ÿ���� �ؽ�Ʈ��
    public Text UserScoreText; //��� ���ӿ��� ���� �� ���� ������ �ҷ��� ����!! 
   
    // ���� ������Ʈ �� ĵ���� ���� ����
    public Image Reward1;
    public Image Reward2;
    public Image Reward3;
    public Image GoodsImage;

    //���ڰ� �����ð�
    int Result1;
    int Result2;
    int UserScore;


    List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    void Start()
    {
        //PercentageTable_1���� �迭�� ����Ұ�
        data_Dialog = CSVReader.Read("PercentageTable_2");

        //� ������Ʈ�� �����Ұ���?
        ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        Restart = GameObject.Find("Restart").GetComponent<Button>();
        HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        UserScoreText = GameObject.Find("UserScore").GetComponent<Text>();

    }

    List<int> gatchIdList;
    List<int> gatchPerList;
    List<int> rewards; // �� �ֵ�

    void Setting() // �� ���ڸ��� �ѹ� �ϸ� ��
    {
        gatchPerList = new List<int>();
        gatchIdList = new List<int>();
        int rank = DataManager.Instance.nowRank;

        for (int i = 0; i < data_Dialog.Count; i++)
        {
            if ((int)data_Dialog[i]["nowrank"] == rank)
            {
                gatchPerList.Add((int)data_Dialog[i]["percentage"]);
                gatchIdList.Add((int)data_Dialog[i]["percentage"]);
            }
        }
        
    }

    public void GetGoods(int count) // ���� ��í�� �ϴ� �κ�. count���� �̰� ���� ���� �ֱ�
    {
        rewards.Clear();

        for (int i = 0; i < Rewards.Count; i++)
        {
            Rewards[i].gameObject.SetActive(false); // �� �� ��
        }

        int randMaxValue = 0; // ��� ����ġ ���� ���ϱ� ���� ����. �޸� ���� ���� ��
        for(int i = 0; i < gatchPerList.Count; i++)
        {
            randMaxValue += gatchPerList[i]; // ����ġ �� �� ���ϱ�. 999, 1001 ����
        }

        for(int i = 0; i < count; i++) // ���
        {
            GetItems(randMaxValue); // �̱�
            Rewards[i].sprite = Resources.Load<Sprite>("goods" + rewards[i]);
            Rewards[i].gameObject.SetActive(true); // �ٲ������ �Ѷ�
        }
    }

    void GetItems(int maxValue) // �̱�. ���� �ִ밪 �ޱ�
    {
        int randValue = UnityEngine.Random.Range(0, maxValue); // ���� ���� �ش� ����ġ��
        int checkRand = 0; // ����ġ üũ��
        for(int i = 0; i < gatchIdList.Count; i++)
        {
            checkRand += gatchPerList[i];
            if (randValue < checkRand)
            {
                rewards.Add(gatchIdList[i]);
            }
        }
    }


    public List<Image> Rewards = new List<Image>(); // 

    //public void Rank1RandomSetting() // Ȯ���� ���� id�� �̹����� ����Ұ� -> �����Ʈ ��ī�̺��...
    //{
    //    rankid_1 = UnityEngine.Random.Range(0, 18); 
    //    string imageFileName = data_Dialog[rankid_1]["goods"].ToString();
    //    percentage = (int)data_Dialog[rankid_1]["percentage"];

    //    Reward1.sprite = Resources.Load<Sprite>("goods" + imageFileName);
    //    Reward2.sprite = Resources.Load<Sprite>("goods" + imageFileName);
    //    Reward3.sprite = Resources.Load<Sprite>("goods" + imageFileName);

    //     //GoodsNum.text = �����͸Ŵ������� ���� ��������
    //    Reward1.gameObject.SetActive(true);
    //    Reward2.gameObject.SetActive(true);
    //    Reward3.gameObject.SetActive(true);
    //}

    //public void Rank2RandomSetting() 
    //{
    //    rankid_2 = UnityEngine.Random.Range(18, 36);
    //    string imageFileName = data_Dialog[rankid_2]["goods"].ToString();
    //    percentage = (int)data_Dialog[rankid_2]["percentage"];

    //    Reward1.sprite = Resources.Load<Sprite>("goods" + imageFileName);
    //    Reward2.sprite = Resources.Load<Sprite>("goods" + imageFileName);
    //    Reward3.sprite = Resources.Load<Sprite>("goods" + imageFileName);

    //    //GoodsNum.text = �����͸Ŵ������� ���� ��������
    //    Reward1.gameObject.SetActive(true);
    //    Reward2.gameObject.SetActive(true);
    //    Reward3.gameObject.SetActive(true);
    //}

    //public void Rank3RandomSetting()
    //{ 
    //    rankid_3 = UnityEngine.Random.Range(36, 54);
    //    string imageFileName = data_Dialog[rankid_3]["goods"].ToString();
    //    percentage = (int)data_Dialog[rankid_3]["Percentage"];

    //    Reward1.sprite = Resources.Load<Sprite>("goods" + imageFileName);
    //    Reward2.sprite = Resources.Load<Sprite>("goods" + imageFileName);
    //    Reward3.sprite = Resources.Load<Sprite>("goods" + imageFileName);

    //    //GoodsNum.text = �����͸Ŵ������� ���� ��������
    //    Reward1.gameObject.SetActive(true);
    //    Reward2.gameObject.SetActive(true);
    //    Reward3.gameObject.SetActive(true);
    //}

    void Score() // �̸� �ٲ�. => ������ ���� ��í ���� ���� �ϴ� �κ��̶�
    {
        int _count = 0; // � �� �� �����ϴ� ����

        //���� ����
        if (UserScore >= Result2) // �ٲ�
        {
            _count = 3;

        }
        else if(UserScore < Result2 && UserScore >= Result1)
        {
            _count = 2;
        }
        else
        {
            _count = 1;
        }

        GetGoods(_count);

        Save();
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
