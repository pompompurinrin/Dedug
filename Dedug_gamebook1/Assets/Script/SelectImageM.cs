using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;
using Unity.VisualScripting;

public class SelectImageM : MonoBehaviour
{

    //기본 투명 이미지
    public Sprite chrictorNomal;

    // 표정 리스트
    public Sprite nomal11;
    public Sprite fun12;
    public Sprite sad13;
    public Sprite surprise14;
    public Sprite shy15;
    public Sprite angry16;

    public Sprite nomal21;
    public Sprite fun22;
    public Sprite sad23;
    public Sprite surprise24;
    public Sprite shy25;
    public Sprite angry26;

    public Sprite nomal31;
    public Sprite fun32;
    public Sprite sad33;
    public Sprite surprise34;
    public Sprite shy35;
    public Sprite angry36;

    public Sprite nomal41;
    public Sprite fun42;
    public Sprite sad43;
    public Sprite surprise44;
    public Sprite shy45;
    public Sprite angry46;

    public Sprite nomal51;

    public Sprite nomal61;

    // 기본 투명 이미지
    public Image tagetCharictor;

    // 애니메이션
    public Text text;
    public Vector3 targetScale = new Vector3(2, 2, 2);
    public Ease ease = Ease.OutQuad;
    public Color targetColor = Color.red;
    public float targetFadeValue = 0;

    void Start()
    {
        tagetCharictor = GetComponent<Image>();
    }

    public void SelectImageChangeM()
    {

        int clickNum = MainController.clickNum;
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("DedugScript");

        // 선택지 클릭 시 이미지 변환
        if (data_Dialog[clickNum]["selectText1"].ToString() == "의심한다.")
        {
            tagetCharictor.sprite = fun42;
        }

        if (data_Dialog[clickNum]["selectText2"].ToString() == "의심하지 않는다.")
        {
            tagetCharictor.sprite = sad43;
        }

        if (data_Dialog[clickNum]["selectText1"].ToString() == "따라가자.")
        {
            tagetCharictor.sprite = fun42;
        }

        if (data_Dialog[clickNum]["selectText2"].ToString() == "거절하자.")
        {
            tagetCharictor.sprite = nomal41;
        }



        if (data_Dialog[clickNum]["selectText1"].ToString() == "이브")
        {
            tagetCharictor.sprite = sad13;
        }

        if (data_Dialog[clickNum]["selectText2"].ToString() == "미카엘")
        {
            tagetCharictor.sprite = surprise24;
        }

        if (data_Dialog[clickNum]["selectText3"].ToString() == "우디")
        {
            tagetCharictor.sprite = angry36;
        }


        if (data_Dialog[clickNum]["selectText1"].ToString() == "좀 더 같이 있는다.")
        {
            tagetCharictor.sprite = fun42;
        }

        if (data_Dialog[clickNum]["selectText2"].ToString() == "거절한다.(처음으로)")
        {
            tagetCharictor.sprite = nomal41;
        }

    }
}