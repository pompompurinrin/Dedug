using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
    public Button RequestBtn;
    public Button RankBtn;
    public Button CollectBtn;
    public Button GoodsBuyBtn;
    int NowGold;
    int NowRank;
    string Goods3;
    public void Start()
    {
        NowGold = PlayerPrefs.GetInt("nowGold");
        NowRank = PlayerPrefs.GetInt("nowRank");
        Goods3 = PlayerPrefs.GetString("goods3");
        DataManager.Instance.nowGold = NowGold;
        DataManager.Instance.nowRank = NowRank;
    }
    public void ClickRequestBtn()
    {
        SceneManager.LoadScene("RequestScene");
    }

    public void ClickRankBtn()
    {
        SceneManager.LoadScene("RankScene");
    }
    public void ClickGoodsBtn()
    {
        SceneManager.LoadScene("GoodsSBuycene");
    }

}
