using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RankManger : MonoBehaviour
{
    //���� ���
    public Image NowRankImage;
    public Text NowRankName;
    int NowRank;

    //���� ���
    public Image NextRankImage;
    public Text NextRankName;

    //�ʿ� ���
    public Text SpendGoldText;
    int SpendGold;
    int NowGold;

    //�ر� ����
    string GoodsName;

    Canvas RankPopUP;
    Canvas Unlock;
    Canvas Result;

    List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    private void Start()
    {
        //�⺻
        RankPopUP = GameObject.Find("PopUPCanvas").GetComponent<Canvas>();
        Unlock = GameObject.Find("UnlockCanvas").GetComponent<Canvas>();
        Result = GameObject.Find("ResultCanvas").GetComponent<Canvas>();
        RankPopUP.gameObject.SetActive(false);
        Unlock.gameObject.SetActive(false);
        Result.gameObject.SetActive(false);
        data_Dialog = CSVReader.Read("RankSample");

        //���� ��ũ
        NowRankName.text = data_Dialog[NowRank]["rank"].ToString();


    }
    
    public void UnlockCheck()
    {
      

    }

    public void RankUPClick()
    {
        RankPopUP.gameObject.SetActive(true);
    }

    public void RankPopUPClick()
    {
        RankPopUP.gameObject.SetActive(false);
        Result.gameObject.SetActive(true);
    }

    public void RankPopUPExitClick()
    {
        RankPopUP.gameObject.SetActive(false);
    }

    public void ResultExitClick()
    {
        Result.gameObject.SetActive(false);
    }


}
