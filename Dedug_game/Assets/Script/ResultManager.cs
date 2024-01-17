using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;

public class ResultManager : MonoBehaviour
{

    // �̰� ���â�ε� �켱 ���� �ִ� canvas�� �̴ϰ��� canvas �ȿ� ����
    // ��ũ��Ʈ�� ���� �̴ϰ��� ��ũ��Ʈ�� ����, 160�� Test ���� �κа� ���� �κи� �ڽ��� ���ھ� ������ ����
    // �ڽ��� ���� �����ϴ� �Լ� �ȿ� Score(); �Լ� ����
    // 46��° �� Start�� � ������Ʈ�� �����Ұ���? �̰� ��ü �Űܾ� �� -> �ڽ��� ���� �����ϴ� �Լ� ��, ���â ������Ʈ Ȱ��ȭ �ٷ� �ؿ� ������ (�۷� �����ϱ� ������� ���� ����� �� �������� ��� ��)


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

    int score;
    int test;

    // ������ ����Ʈ ������ ���⼭ ��Ŵ
    public List<Image> RewardsImage = new List<Image>();

    public List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    void Start()
    {
        //PercentageTable_1���� �迭�� ����Ұ�
        data_Dialog = CSVReader.Read("PercentageTable");

        //� ������Ʈ�� �����Ұ���?
        ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        Restart = GameObject.Find("Restart").GetComponent<Button>();
        HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        //UserScore = GameObject.Find("UserScoretxt").GetComponent<Text>();  //�־ȵǴ°����Ф�

        // �̰� ������ �𸣰ڴµ� ������� �ؼ� �ϴ� ����
        RewardsImage.Add(Reward1);
        RewardsImage.Add(Reward2);
        RewardsImage.Add(Reward3);

        Setting();
    }

    public List<Sprite> goodsSprites = new List<Sprite>();

    public List<int> gatchIdList;
    public List<int> gatchPerList;
    public List<int> rewards; // �� �ֵ�



    void Setting() // �� ���ڸ��� �ѹ� �ϸ� ��
    {
        gatchPerList = new List<int>();
        gatchIdList = new List<int>();
        goodsSprites = new List<Sprite>();
        int rank = DataManager.Instance.nowRank;

        for (int i = 0; i < data_Dialog.Count; i++)
        {
            if ((int)data_Dialog[i]["Nowrank"] == rank)
            {
                gatchPerList.Add((int)data_Dialog[i]["Percentage"]);
                gatchIdList.Add((int)data_Dialog[i]["Goods"]);
                string imageString = "Goods" + data_Dialog[i]["Goods"].ToString();
                goodsSprites.Add(Resources.Load<Sprite>(imageString));

            }
        }

    }

    public void GetGoods(int _count) // ���� ��í�� �ϴ� �κ�. count���� �̰� ���� ���� �ֱ�
    {

        if (data_Dialog.Count == 0)
        {
            data_Dialog = CSVReader.Read("PercentageTable");
        }

        for (int i = 0; i < RewardsImage.Count; i++)
        {
            RewardsImage[i].gameObject.SetActive(false); // �� �� ��
        }

        int randMaxValue = 0; // ��� ����ġ ���� ���ϱ� ���� ����. �޸� ���� ���� ��
        for (int i = 0; i < gatchPerList.Count; i++)
        {
            randMaxValue += gatchPerList[i]; // ����ġ �� �� ���ϱ�. 999, 1001 ����
        }

        for (int i = 0; i < _count; i++) // ���
        {
            GetItems(randMaxValue); // �̱�

            RewardsImage[i].sprite = rewardGoods[i];
            RewardsImage[i].gameObject.SetActive(true); // �ٲ������ �Ѷ�
        }

        Save();
    }

    void GetItems(int maxValue)
    {
        int randValue = UnityEngine.Random.Range(0, maxValue);
        Debug.Log("Random Value: " + randValue);

        int checkUpper = 0;
        int checkLower = 0;

        for (int i = 0; i < gatchIdList.Count; i++)
        {
            checkUpper += gatchPerList[i];
            Debug.Log("Check Upper: " + checkUpper);

            if (i == 0)
            {
                if (randValue < checkUpper)
                {
                    rewards.Add(gatchIdList[i]);
                    rewardGoods.Add(goodsSprites[i]);
                    Debug.Log("Reward Added: " + gatchIdList[i]);
                    break;
                }
            }
            else
            {
                if (randValue >= checkLower && randValue < checkUpper)
                {
                    rewards.Add(gatchIdList[i]);
                    rewardGoods.Add(goodsSprites[i]);
                    Debug.Log("Reward Added: " + gatchIdList[i]);
                    break;
                }
            }

            checkLower = checkUpper;
        }
    }


    public List<Sprite> rewardGoods = new List<Sprite>();

    public int _count = 0;// � �� �� �����ϴ� ����
    void Score() // �̸� �ٲ�. => ������ ���� ��í ���� ���� �ϴ� �κ��̶�
    {
        Scoretxt.text = score.ToString();

        //���� ����
        if (score >= 10) // �ٲ�
        {
            _count = 3;

        }
        else if (score < 10 && score >= 5)
        {
            _count = 2;
        }
        else
        {
            _count = 1;
        }

        GetGoods(_count);


    }


    public void Save()
    {
        for (int i = 0; i < rewards.Count; i++)
        {
            int rewardId = rewards[i];

            // ������ ID�� ���� DataManager.Instance�� ����
            switch (rewardId)
            {
                case 1011:
                    DataManager.Instance.goods1011++;
                    break;
                case 1012:
                    DataManager.Instance.goods1012++;
                    break;
                case 1021:
                    DataManager.Instance.goods1021++;
                    break;
                case 1022:
                    DataManager.Instance.goods1022++;
                    break;
                case 1031:
                    DataManager.Instance.goods1031++;
                    break;
                case 1032:
                    DataManager.Instance.goods1032++;
                    break;
                case 1041:
                    DataManager.Instance.goods1041++;
                    break;
                case 1042:
                    DataManager.Instance.goods1042++;
                    break;
                case 1051:
                    DataManager.Instance.goods1051++;
                    break;
                case 1052:
                    DataManager.Instance.goods1052++;
                    break;
                case 2011:
                    DataManager.Instance.goods2011++;
                    break;
                case 2012:
                    DataManager.Instance.goods2012++;
                    break;
                case 2022:
                    DataManager.Instance.goods2022++;
                    break;
                case 2031:
                    DataManager.Instance.goods2031++;
                    break;
                case 2041:
                    DataManager.Instance.goods2041++;
                    break;
                case 2042:
                    DataManager.Instance.goods2042++;
                    break;
                case 2051:
                    DataManager.Instance.goods2051++;
                    break;
                case 2052:
                    DataManager.Instance.goods2052++;
                    break;
                case 3011:
                    DataManager.Instance.goods3011++;
                    break;
                case 3012:
                    DataManager.Instance.goods3012++;
                    break;
                case 3021:
                    DataManager.Instance.goods3021++;
                    break;
                case 3022:
                    DataManager.Instance.goods3022++;
                    break;
                case 3031:
                    DataManager.Instance.goods3031++;
                    break;
                case 3032:
                    DataManager.Instance.goods3032++;
                    break;
                case 3041:
                    DataManager.Instance.goods3041++;
                    break;
                case 3042:
                    DataManager.Instance.goods3042++;
                    break;
                case 3051:
                    DataManager.Instance.goods3051++;
                    break;
                case 4051:
                    DataManager.Instance.goods4051++;
                    break;
                case 4052:
                    DataManager.Instance.goods4052++;
                    break;
                case 4053:
                    DataManager.Instance.goods4053++;
                    break;
                case 4054:
                    DataManager.Instance.goods4054++;
                    break;
                case 4055:
                    DataManager.Instance.goods4055++;
                    break;
                case 4056:
                    DataManager.Instance.goods4056++;
                    break;
                case 4057:
                    DataManager.Instance.goods4057++;
                    break;
                case 4058:
                    DataManager.Instance.goods4058++;
                    break;
                case 4059:
                    DataManager.Instance.goods4059++;
                    break;
                case 4060:
                    DataManager.Instance.goods4060++;
                    break;

                default:
                    break;

                    // �ٸ� ���� ID�� ���� ���̽� �߰�...
            }

        }
        // PlayerPrefs�� ���� �� ����
        PlayerPrefs.SetInt("Goods1011", DataManager.Instance.goods1011);
        PlayerPrefs.SetInt("Goods1012", DataManager.Instance.goods1012);
        PlayerPrefs.SetInt("Goods1021", DataManager.Instance.goods1021);
        PlayerPrefs.SetInt("Goods1022", DataManager.Instance.goods1022);
        PlayerPrefs.SetInt("Goods1031", DataManager.Instance.goods1031);
        PlayerPrefs.SetInt("Goods1032", DataManager.Instance.goods1032);
        PlayerPrefs.SetInt("Goods1041", DataManager.Instance.goods1041);
        PlayerPrefs.SetInt("Goods1042", DataManager.Instance.goods1042);
        PlayerPrefs.SetInt("Goods1051", DataManager.Instance.goods1051);
        PlayerPrefs.SetInt("Goods1052", DataManager.Instance.goods1052);

        PlayerPrefs.SetInt("Goods2011", DataManager.Instance.goods2011);
        PlayerPrefs.SetInt("Goods2012", DataManager.Instance.goods2012);
        PlayerPrefs.SetInt("Goods2021", DataManager.Instance.goods2021);
        PlayerPrefs.SetInt("Goods2022", DataManager.Instance.goods2022);
        PlayerPrefs.SetInt("Goods2031", DataManager.Instance.goods2031);
        PlayerPrefs.SetInt("Goods2032", DataManager.Instance.goods2032);
        PlayerPrefs.SetInt("Goods2041", DataManager.Instance.goods2041);
        PlayerPrefs.SetInt("Goods2042", DataManager.Instance.goods2042);
        PlayerPrefs.SetInt("Goods2051", DataManager.Instance.goods2051);
        PlayerPrefs.SetInt("Goods2052", DataManager.Instance.goods2052);

        PlayerPrefs.SetInt("Goods3011", DataManager.Instance.goods3011);
        PlayerPrefs.SetInt("Goods3012", DataManager.Instance.goods3012);
        PlayerPrefs.SetInt("Goods3021", DataManager.Instance.goods3021);
        PlayerPrefs.SetInt("Goods3022", DataManager.Instance.goods3022);
        PlayerPrefs.SetInt("Goods3031", DataManager.Instance.goods3031);
        PlayerPrefs.SetInt("Goods3032", DataManager.Instance.goods3032);
        PlayerPrefs.SetInt("Goods3041", DataManager.Instance.goods3041);
        PlayerPrefs.SetInt("Goods3042", DataManager.Instance.goods3042);
        PlayerPrefs.SetInt("Goods3051", DataManager.Instance.goods3051);
        PlayerPrefs.SetInt("Goods3052", DataManager.Instance.goods3052);

        PlayerPrefs.SetInt("Goods4051", DataManager.Instance.goods4051);
        PlayerPrefs.SetInt("Goods4052", DataManager.Instance.goods4052);
        PlayerPrefs.SetInt("Goods4053", DataManager.Instance.goods4053);
        PlayerPrefs.SetInt("Goods4054", DataManager.Instance.goods4054);
        PlayerPrefs.SetInt("Goods4055", DataManager.Instance.goods4055);
        PlayerPrefs.SetInt("Goods4056", DataManager.Instance.goods4056);
        PlayerPrefs.SetInt("Goods4057", DataManager.Instance.goods4057);
        PlayerPrefs.SetInt("Goods4058", DataManager.Instance.goods4058);
        PlayerPrefs.SetInt("Goods4059", DataManager.Instance.goods4059);
        PlayerPrefs.SetInt("Goods4060", DataManager.Instance.goods4060);

        PlayerPrefs.Save();

        Debug.Log(DataManager.Instance.goods1011);
        Debug.Log(DataManager.Instance.goods1012);
        Debug.Log(DataManager.Instance.goods2011);
        Debug.Log(DataManager.Instance.goods2012);
        Debug.Log(DataManager.Instance.goods3011);
        Debug.Log(DataManager.Instance.goods3012);
        Debug.Log(DataManager.Instance.goods1021);
        Debug.Log(DataManager.Instance.goods1022);
        Debug.Log(DataManager.Instance.goods2021);
        Debug.Log(DataManager.Instance.goods2022);
        Debug.Log(DataManager.Instance.goods3021);
        Debug.Log(DataManager.Instance.goods3022);
        Debug.Log(DataManager.Instance.goods1031);
        Debug.Log(DataManager.Instance.goods1032);
        Debug.Log(DataManager.Instance.goods2031);
        Debug.Log(DataManager.Instance.goods2032);
        Debug.Log(DataManager.Instance.goods3031);
        Debug.Log(DataManager.Instance.goods3032);
        Debug.Log(DataManager.Instance.goods1041);
        Debug.Log(DataManager.Instance.goods1042);
        Debug.Log(DataManager.Instance.goods2041);
        Debug.Log(DataManager.Instance.goods2042);
        Debug.Log(DataManager.Instance.goods3041);
        Debug.Log(DataManager.Instance.goods3042);
        Debug.Log(DataManager.Instance.goods1051);
        Debug.Log(DataManager.Instance.goods1052);
        Debug.Log(DataManager.Instance.goods2051);
        Debug.Log(DataManager.Instance.goods2052);
        Debug.Log(DataManager.Instance.goods3051);
        Debug.Log(DataManager.Instance.goods3052);
        Debug.Log(DataManager.Instance.goods4051);
        Debug.Log(DataManager.Instance.goods4052);
        Debug.Log(DataManager.Instance.goods4053);
        Debug.Log(DataManager.Instance.goods4054);
        Debug.Log(DataManager.Instance.goods4055);
        Debug.Log(DataManager.Instance.goods4056);
        Debug.Log(DataManager.Instance.goods4057);
        Debug.Log(DataManager.Instance.goods4058);
        Debug.Log(DataManager.Instance.goods4059);
        Debug.Log(DataManager.Instance.goods4060);



    }

    public void RestartClick()
    {
        Start();
    }

    public void HomeClick()
    {
        SceneManager.LoadScene("HomeScene");
    }

}