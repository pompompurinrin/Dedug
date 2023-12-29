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

public class SelectImageR : MonoBehaviour
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

    public void SelectImageChangeR()
    {

        int clickNum = MainController.clickNum;
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("DedugScript");

        if (data_Dialog[clickNum]["selectText1"].ToString() == "들어도 재미 없을텐데?")
        {
            tagetCharictor.sprite = fun12;
        }

        if (data_Dialog[clickNum]["selectText2"].ToString() == "글쎄.. 말 해줄까 말까?")
        {
            tagetCharictor.sprite = nomal11;
        }

        if (data_Dialog[clickNum]["selectText3"].ToString() == "내 일이야 신경쓰지마.")
        {
            tagetCharictor.sprite = sad13;
        }

        if (data_Dialog[clickNum]["selectText1"].ToString() == "못 본 사이에 매너가 늘었네?")
        {
            tagetCharictor.sprite = nomal11;
        }

        if (data_Dialog[clickNum]["selectText2"].ToString() == "어떻게 에스코트 해 줄건데?")
        {
            tagetCharictor.sprite = fun12;
        }

        if (data_Dialog[clickNum]["selectText3"].ToString() == "조금 귀찮을 것 같은데…")
        {
            tagetCharictor.sprite = sad13;
        }


        if (data_Dialog[clickNum]["selectText1"].ToString() == "그러게 누가 와 달라고 했어?")
        {
            tagetCharictor.sprite = sad13;
        }

        if (data_Dialog[clickNum]["selectText2"].ToString() == "귀한 시간 내 주셔서 감사합니다.")
        {
            tagetCharictor.sprite = nomal11;
        }

        if (data_Dialog[clickNum]["selectText3"].ToString() == "내 생각 해줘서 고마워.")
        {
            tagetCharictor.sprite = fun12;
        }



        if (data_Dialog[clickNum]["selectText1"].ToString() == "그냥 귀여워서 나도 모르게 봤어.")
        {
            tagetCharictor.sprite = shy35;
        }

        if (data_Dialog[clickNum]["selectText2"].ToString() == "그냥 본거야.")
        {
            tagetCharictor.sprite = surprise34;
        }

        if (data_Dialog[clickNum]["selectText3"].ToString() == "이제 오해한 걸 사과했으면 좋겠어.")
        {
            tagetCharictor.sprite = angry36;
        }


    }
}