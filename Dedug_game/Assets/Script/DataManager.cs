using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public List<Dictionary<string, object>> DataTable;
    public int NowRank, NowGold, Goods1, Goods2, Goods3, Goods4, Goods5, FeverNum;
    
    //DataManager.instance.DataTable?

    void Awake()
    {
        DataRoad();
        //if 문으로 저장파일이 있는지 없는지 검사해야된다... 없으면 실행...
        Clear();
    }
    
    public void Clear()
    {

        NowRank = 0;
        NowGold = 0;
        Goods1 = 0;
        Goods2 = 0;
        Goods3 = 0;
        Goods4 = 0;
        Goods5 = 0;
        FeverNum = 0;
    }

    private void DataRoad()
    {
        DataTable = CSVReader.Read("RankSample");
    }


}