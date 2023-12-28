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
    // 배경 리스트
    public Sprite bg1;
    public Sprite bg2;
    public Sprite bg3;
    public Sprite bg4;
    public Sprite bg5;
    public Sprite bg6;
    public Sprite bg7;
    public Sprite bg8;
    public Sprite bg9;
    public Sprite bg10;
    public Sprite bg11;

    // 기본 투명 이미지
    public Image tagetBG;


    void Start()
    {
        tagetBG = GetComponent<Image>();
    }

    void Update()
    {
        ChangeBGImage();
    }

    public void ChangeBGImage()
    {

        int clickNum = MainController.clickNum;
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("DedugScript");

        // 배경 이미지 변경
        if (data_Dialog[clickNum]["talkBG"].ToString() == "1")
        {
            tagetBG.sprite = bg1;
        }

        if (data_Dialog[clickNum]["talkBG"].ToString() == "2")
        {
            tagetBG.sprite = bg2;
        }

        if (data_Dialog[clickNum]["talkBG"].ToString() == "3")
        {
            tagetBG.sprite = bg3;
        }

        if (data_Dialog[clickNum]["talkBG"].ToString() == "4")
        {
            tagetBG.sprite = bg4;
        }

        if (data_Dialog[clickNum]["talkBG"].ToString() == "5")
        {
            tagetBG.sprite = bg5;
        }

        if (data_Dialog[clickNum]["talkBG"].ToString() == "6")
        {
            tagetBG.sprite = bg6;
        }

        if (data_Dialog[clickNum]["talkBG"].ToString() == "7")
        {
            tagetBG.sprite = bg7;
        }

        if (data_Dialog[clickNum]["talkBG"].ToString() == "8")
        {
            tagetBG.sprite = bg8;
        }

        if (data_Dialog[clickNum]["talkBG"].ToString() == "9")
        {
            tagetBG.sprite = bg9;
        }

        if (data_Dialog[clickNum]["talkBG"].ToString() == "10")
        {
            tagetBG.sprite = bg10;
        }

        if (data_Dialog[clickNum]["talkBG"].ToString() == "11")
        {
            tagetBG.sprite = bg11;
        }

    }
}