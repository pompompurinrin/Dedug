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
