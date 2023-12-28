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

public class ImageChangeL : MonoBehaviour
{
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

    void Update()
    {
        ChangeCharictorImage();
    }

    public void ChangeCharictorImage()
    {

        int clickNum = MainController.clickNum;
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("DedugScript");

        if (data_Dialog[clickNum]["action"].ToString() == "11")
        {
            // 크기 증가
            tagetCharictor.transform.DOScale(targetScale, 3).SetEase(ease);
        }

        if (data_Dialog[clickNum]["action"].ToString() == "12")
        {
            // 크기 증가
            tagetCharictor.transform.DOShakeRotation(3);
        }

        // 공략캐릭터1
        if (data_Dialog[clickNum]["chrL"].ToString() == "11")
        {
            tagetCharictor.sprite = nomal11;
        }

        if (data_Dialog[clickNum]["chrL"].ToString() == "12")
        {
            tagetCharictor.sprite = fun12;
        }

        if (data_Dialog[clickNum]["chrL"].ToString() == "13")
        {
            tagetCharictor.sprite = sad13;
        }

        if (data_Dialog[clickNum]["chrL"].ToString() == "14")
        {
            tagetCharictor.sprite = surprise14;
        }

        if (data_Dialog[clickNum]["chrL"].ToString() == "15")
        {
            tagetCharictor.sprite = shy15;
        }

        if (data_Dialog[clickNum]["chrL"].ToString() == "16")
        {
            tagetCharictor.sprite = angry16;
        }

        // 공략캐릭터2
        if (data_Dialog[clickNum]["chrL"].ToString() == "21")
        {
            tagetCharictor.sprite = nomal21;
        }

        if (data_Dialog[clickNum]["chrL"].ToString() == "22")
        {
            tagetCharictor.sprite = fun22;
        }

        if (data_Dialog[clickNum]["chrL"].ToString() == "23")
        {
            tagetCharictor.sprite = sad23;
        }

        if (data_Dialog[clickNum]["chrL"].ToString() == "24")
        {
            tagetCharictor.sprite = surprise24;
        }

        if (data_Dialog[clickNum]["chrL"].ToString() == "25")
        {
            tagetCharictor.sprite = shy25;
        }

        if (data_Dialog[clickNum]["chrL"].ToString() == "26")
        {
            tagetCharictor.sprite = angry26;
        }

        // 공략캐릭터3
        if (data_Dialog[clickNum]["chrL"].ToString() == "31")
        {
            tagetCharictor.sprite = nomal31;
        }

        if (data_Dialog[clickNum]["chrL"].ToString() == "32")
        {
            tagetCharictor.sprite = fun32;
        }

        if (data_Dialog[clickNum]["chrL"].ToString() == "33")
        {
            tagetCharictor.sprite = sad33;
        }

        if (data_Dialog[clickNum]["chrL"].ToString() == "34")
        {
            tagetCharictor.sprite = surprise34;
        }

        if (data_Dialog[clickNum]["chrL"].ToString() == "35")
        {
            tagetCharictor.sprite = shy35;
        }

        if (data_Dialog[clickNum]["chrL"].ToString() == "36")
        {
            tagetCharictor.sprite = angry36;
        }

    }
}

// 말하지 않는 캐릭터 어둡게 처리

/*        if (data_Dialog[clickNum]["name"].ToString() == "버섯몬")
        {
            GameObject chr02 = GameObject.Find("chr02");
            Color color = chr02.GetComponent<Image>().color;
            color.a = 0.5f;
            chr02.GetComponent<Image>().color = color;
        }

        if (data_Dialog[clickNum]["name"].ToString() != "버섯몬")
        {
            GameObject chr02 = GameObject.Find("chr02");
            Color color = chr02.GetComponent<Image>().color;
            color.a = 1f;
            chr02.GetComponent<Image>().color = color;
        }*/

// 비활성화되어 있는 오브젝트 켤 때
// GameObject.Find("chr").transform.Find("chr02").gameObject.SetActive(true);