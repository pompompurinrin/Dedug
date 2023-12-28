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
    // 표정 리스트
    public Sprite nomal;

    // 기본 투명 이미지
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

        // 공략캐릭터1
        if (data_Dialog[clickNum]["talkBG"].ToString() == "11")
        {
            tagetCharictor.sprite = nomal;
        }

    }
}