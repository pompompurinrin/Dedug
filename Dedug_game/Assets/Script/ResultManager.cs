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

public class ResultManager : MonoBehaviour
{

    //�̰� ���â�ε� �켱 ���� �ִ� canvas�� �̴ϰ��� canvas �ȿ� ����
    //��ũ��Ʈ�� ������ �����ſ� �����ϸ� �� �� �����ϴ�! �ؿ� 68~70 �ٿ� �ִ� �͸� ���ӿ� ���缭 �������ּ���!


    // UI ��ҵ�
    public Image ResultBG;
    public Image ScoreBG;
    public Text Scoretxt;
    public Text Rewardtxt;
    public Button Restart;
    public Button HomeBtn;

    // ���� ȿ�� �� ����� ��Ÿ���� �ؽ�Ʈ��
    public Text UserScoretxt; //��� ���ӿ��� ���� �� ���� ������ �ҷ��� ����!! 
    public string imageFileName; // ��� CSV���� Goods���� ���ڸ� �����ͼ� �̹����� �̾Ƴ�����!!

    // ���� ������Ʈ �� ĵ���� ���� ����
    public Image Reward1;
    public Image Reward2;
    public Image Reward3;

    //���ڰ� �����ð�
    int Result1;
    int Result2;
    int UserScore;


    // ������ ����Ʈ ������ ���⼭ ��Ŵ
    public List<Image> Rewards = new List<Image>();

    List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    void Start()
    {
        //PercentageTable_1���� �迭�� ����Ұ�
        data_Dialog = CSVReader.Read("PercentageTable_real");

        //� ������Ʈ�� �����Ұ���?
        ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        Restart = GameObject.Find("Restart").GetComponent<Button>();
        HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        //UserScore = GameObject.Find("UserScoretxt").GetComponent<Text>();  //�־ȵǴ°����Ф�

        // �̰� ������ �𸣰ڴµ� ������� �ؼ� �ϴ� ����
        Rewards.Add(Reward1);
        Rewards.Add(Reward2);
        Rewards.Add(Reward3);


        // �׽�Ʈ�� ���� ���̶� ������
        Setting();

        // UserScore �������� ���� (����: ���� �� ����)
        UserScore = UnityEngine.Random.Range(1, 10);//�̺κ��� ���� ���ھ��. ���� ���ھ� �ؽ�Ʈ�� �������ָ� �� �� �����ϴ�! ������ ���ǰ� �־����� ����� ������!
        Result2 = 3;//�̰� ���� ���� ���â���� ��� 3�� �ִ� ������ �����ִ� �ſ���. int���Դϴ�!
        Result1 = 1;//�̰� ���� ���� ���â���� ��� 2�� �ִ� ������ �����ִ� �ſ���. int���Դϴ�!
        Score();
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
            if ((int)data_Dialog[i]["Nowrank"] == rank)
            {
                gatchPerList.Add((int)data_Dialog[i]["Percentage"]);
                gatchIdList.Add((int)data_Dialog[i]["Percentage"]);
            }
        }
        
    }

    public void GetGoods(int _count) // ���� ��í�� �ϴ� �κ�. count���� �̰� ���� ���� �ֱ�
    {


        // ���� �� �� ������ ����Ʈ �ʱ�ȭ
        rewards = new List<int>(); // rewards ����Ʈ �ʱ�ȭ

        for (int i = 0; i < Rewards.Count; i++)
        {
            Rewards[i].gameObject.SetActive(false); // �� �� ��
        }

        int randMaxValue = 0; // ��� ����ġ ���� ���ϱ� ���� ����. �޸� ���� ���� ��
        for(int i = 0; i < gatchPerList.Count; i++)
        {
            randMaxValue += gatchPerList[i]; // ����ġ �� �� ���ϱ�. 999, 1001 ����
        }

        for(int i = 0; i < _count; i++) // ���
        {
            GetItems(randMaxValue); // �̱�

                string imageFileName = data_Dialog[i]["Goods"].ToString();
                Rewards[i].sprite = Resources.Load<Sprite>("Goods" + imageFileName);
            
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


    public int _count = 0; // � �� �� �����ϴ� ����
    void Score() // �̸� �ٲ�. => ������ ���� ��í ���� ���� �ϴ� �κ��̶�
    {

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
