using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public List<Dictionary<string, object>> DataTable;
    public int nowRank, nowGold, feverNum, goods1011, goods2011, goods3011, goods1012, goods2012, goods3012, goods1021, goods2021, goods3021, goods1022, goods2022, goods3022, goods1031, goods2031, goods3031, goods1032, goods2032, goods3032;
    public string goods3;
    //DataManager.instance.DataTable?

    public int[] HyeJingoodsNum = new int[70];

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
        feverNum = 0;
        goods1011 = 0;
        goods2011 = 0;
        goods3011 = 0;
        goods1012 = 0;
        goods2012 = 0;
        goods3012 = 0;
        goods1021 = 0;
        goods2021 = 0;
        goods3021 = 0;
        goods1022 = 0;
        goods2022 = 0;
        goods3022 = 0;
        goods1031 = 0;
        goods2031 = 0;
        goods3031 = 0;
        goods1032 = 0;
        goods2032 = 0;
        goods3032 = 0;

    }

    private void DataLoad()
    {
        DataTable = CSVReader.Read("RankSample");
    }


}