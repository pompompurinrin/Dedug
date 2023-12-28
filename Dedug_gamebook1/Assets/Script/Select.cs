using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Select : MonoBehaviour
{

    public Text nameText;
    public Text talkText;


    public void SelectStart()
    {
        int love01 = MainController.love01;
        int love02 = MainController.love02;
        int love03 = MainController.love03;

        int clickNum = MainController.clickNum;
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("DedugScript");

        // 처음 3개 장소 선택지일 때
        if (data_Dialog[clickNum]["textID"].ToString() == "0")
        {
            if (love01 >= 1)
            {
                GameObject.Find("select").transform.Find("talkblackBG").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("selctBtn2").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("selctBtn3").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("SaveBtn").gameObject.SetActive(true);
            }

            if (love02 >= 1)
            {
                GameObject.Find("select").transform.Find("talkblackBG").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("selctBtn1").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("selctBtn3").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("SaveBtn").gameObject.SetActive(true);
            }

            if (love03 >= 1)
            {
                GameObject.Find("select").transform.Find("talkblackBG").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("selctBtn1").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("selctBtn2").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("SaveBtn").gameObject.SetActive(true);
            }

            if (love01 >= 1 && love02 >= 1 && love03 >= 1)
            {
                GameObject.Find("select").transform.Find("talkblackBG").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("selctBtnEnd").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("SaveBtn").gameObject.SetActive(true);
            }

            else
            {
                GameObject.Find("select").transform.Find("talkblackBG").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("selctBtn1").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("selctBtn2").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("selctBtn3").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("SaveBtn").gameObject.SetActive(true);
            }
        }

        // 선택지 2개일 때
        if(data_Dialog[clickNum]["selectText3"].ToString() == "0")
        {
            GameObject.Find("select").transform.Find("talkblackBG").gameObject.SetActive(true);
            GameObject.Find("select").transform.Find("selctBtn4").gameObject.SetActive(true);
            GameObject.Find("select").transform.Find("selctBtn5").gameObject.SetActive(true);
        }

        // 선택지 3개일 때
        else
        {
            // 비활성화 선택지 오브젝트 활성화
            GameObject.Find("select").transform.Find("talkblackBG").gameObject.SetActive(true);
            GameObject.Find("select").transform.Find("selctBtn1").gameObject.SetActive(true);
            GameObject.Find("select").transform.Find("selctBtn2").gameObject.SetActive(true);
            GameObject.Find("select").transform.Find("selctBtn3").gameObject.SetActive(true);
        }
    }


}