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
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("DMiyeonsi");
        Debug.Log("Click Number: " + clickNum);

        if (data_Dialog[clickNum]["talkID"].ToString() == "2")
        {
            if (love01 >= 1)
            {
                GameObject.Find("sel").transform.Find("selctBtn2").gameObject.SetActive(true);
                GameObject.Find("sel").transform.Find("selctBtn3").gameObject.SetActive(true);
            }

            if (love02 >= 1)
            {
                GameObject.Find("sel").transform.Find("selctBtn1").gameObject.SetActive(true);
                GameObject.Find("sel").transform.Find("selctBtn3").gameObject.SetActive(true);
            }

            if(love03 >= 1)
            {
                GameObject.Find("sel").transform.Find("selctBtn1").gameObject.SetActive(true);
                GameObject.Find("sel").transform.Find("selctBtn2").gameObject.SetActive(true);
            }

            if (love01 >= 1 && love02 >= 1 && love03 >= 1)
            {
                GameObject.Find("sel").transform.Find("selctBtnEnd").gameObject.SetActive(true);
            }

            else
            {
                // 비활성화 선택지 오브젝트 활성화
                GameObject.Find("sel").transform.Find("selctBtn1").gameObject.SetActive(true);
                GameObject.Find("sel").transform.Find("selctBtn2").gameObject.SetActive(true);
                GameObject.Find("sel").transform.Find("selctBtn3").gameObject.SetActive(true);
            }
        }

        if(data_Dialog[clickNum]["selectText3"].ToString() == "0")
        {
            GameObject.Find("sel").transform.Find("selctBtn1").gameObject.SetActive(true);
            GameObject.Find("sel").transform.Find("selctBtn2").gameObject.SetActive(true);
        }

        else
        {   
            // 비활성화 선택지 오브젝트 활성화
            GameObject.Find("sel").transform.Find("selctBtn1").gameObject.SetActive(true);
            GameObject.Find("sel").transform.Find("selctBtn2").gameObject.SetActive(true);
            GameObject.Find("sel").transform.Find("selctBtn3").gameObject.SetActive(true);
        }
    }


}