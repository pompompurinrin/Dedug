using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public List<Dictionary<string, object>> DataTable;
    public int nowRank, nowGold, goods1, goods2, goods4, goods5, feverNum;
    public string goods3;
    //DataManager.instance.DataTable?

    void Awake()
    {
        DataLoad();
        if (PlayerPrefs.HasKey("NowGold"))
        {
           
           
        }
        else
        {
            Clear();
        }    
    }
    
    public void Clear()
    {

        nowRank = 0;
        nowGold = 0;
        goods1 = 0;
        goods2 = 0;
        goods3 = "";
        goods4 = 0;
        goods5 = 0;
        feverNum = 0;
    }

    private void DataLoad()
    {
        DataTable = CSVReader.Read("RankSample");
    }


}