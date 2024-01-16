using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public List<Dictionary<string, object>> DataTable;
    public int nowRank, nowGold, feverNum, goods1011, goods2011, goods3011, goods1012, goods2012, goods3012, goods1021, goods2021, goods3021, goods1022, goods2022, goods3022, goods1031, goods2031, goods3031, goods1032, goods2032, goods3032, goods1041, goods2041, goods3041, goods1042, goods2042, goods3042, goods1051, goods2051, goods3051, goods1052, goods2052, goods3052, goods4051, goods4052, goods4053, goods4054, goods4055, goods4056, goods4057, goods4058, goods4059, goods4060;

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
        goods1041 = 0;
        goods2041 = 0;
        goods3041 = 0;
        goods1042 = 0;
        goods2042 = 0;
        goods3042 = 0;
        goods1041 = 0;
        goods2041 = 0;
        goods3041 = 0;
        goods1052 = 0;
        goods2052 = 0;
        goods3052 = 0;
        goods4051 = 0;
        goods4052 = 0;
        goods4053 = 0;
        goods4054 = 0;
        goods4055 = 0;
        goods4056 = 0;
        goods4057 = 0;
        goods4058 = 0;
        goods4059 = 0;
        goods4060 = 0;


    }

    private void DataLoad()
    {
        DataTable = CSVReader.Read("RankTable");
    }


}