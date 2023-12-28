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
        int evelove = MainController.evelove;
        int micalove = MainController.micalove;
        int woolove = MainController.woolove;

        int clickNum = MainController.clickNum;
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("DedugScript");

        // ó�� 3�� ��� �������� ��
        if (data_Dialog[clickNum]["textID"].ToString() == "36")
        {
            if (evelove >= 1)
            {
                GameObject.Find("select").transform.Find("talkblackBG").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("selctBtn2").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("selctBtn3").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("SaveBtn").gameObject.SetActive(true);
            }

            if (micalove >= 1)
            {
                GameObject.Find("select").transform.Find("talkblackBG").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("selctBtn1").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("selctBtn3").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("SaveBtn").gameObject.SetActive(true);
            }

            if (woolove >= 1)
            {
                GameObject.Find("select").transform.Find("talkblackBG").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("selctBtn1").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("selctBtn2").gameObject.SetActive(true);
                GameObject.Find("select").transform.Find("SaveBtn").gameObject.SetActive(true);
            }

            if (evelove >= 1 && micalove >= 1 && woolove >= 1)
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

        // ������ 2���� ��
        if(data_Dialog[clickNum]["selectText3"].ToString() == "0")
        {
            GameObject.Find("select").transform.Find("talkblackBG").gameObject.SetActive(true);
            GameObject.Find("select").transform.Find("selctBtn4").gameObject.SetActive(true);
            GameObject.Find("select").transform.Find("selctBtn5").gameObject.SetActive(true);
        }

        // ������ 3���� ��
        else
        {
            // ��Ȱ��ȭ ������ ������Ʈ Ȱ��ȭ
            GameObject.Find("select").transform.Find("talkblackBG").gameObject.SetActive(true);
            GameObject.Find("select").transform.Find("selctBtn1").gameObject.SetActive(true);
            GameObject.Find("select").transform.Find("selctBtn2").gameObject.SetActive(true);
            GameObject.Find("select").transform.Find("selctBtn3").gameObject.SetActive(true);
        }
    }


}