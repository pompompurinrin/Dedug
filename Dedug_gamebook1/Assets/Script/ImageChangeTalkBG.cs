using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class ImageChangeTalkBG : MonoBehaviour
{
    // ǥ�� ����Ʈ
    public Sprite nomal;

    // �⺻ ���� �̹���
    public Image tagetCharictor;


    void Start()
    {
        tagetCharictor = GetComponent<Image>();
    }

    void Update()
    {
        ChangeCharictorImage();
    }

    public void ChangeCharictorImage()
    {

        int clickNum = MainController.clickNum;
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("DedugScript");

        // ����ĳ����1
        if (data_Dialog[clickNum]["talkBG"].ToString() == "11")
        {
            tagetCharictor.sprite = nomal;
        }

    }
}