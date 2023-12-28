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

public class ImageChangeM : MonoBehaviour
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

    void Update()
    {
        ChangeCharictorImage();
    }

    public void ChangeCharictorImage()
    {

        int clickNum = MainController.clickNum;
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("DedugScript");

        /*        if (data_Dialog[clickNum]["action"].ToString() == "11")
                {
                    // 크기 증가
                    tagetCharictor.transform.DOScale(targetScale, 3).SetEase(ease);
                }*/


        // 캐릭터 다시 투명화
        if (data_Dialog[clickNum]["chrM"].ToString() == "0")
        {
            tagetCharictor.sprite = chrictorNomal;
        }


        // 공략캐릭터1
        if (data_Dialog[clickNum]["chrM"].ToString() == "11")
        {
            tagetCharictor.sprite = nomal11;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "12")
        {
            tagetCharictor.sprite = fun12;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "13")
        {
            tagetCharictor.sprite = sad13;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "14")
        {
            tagetCharictor.sprite = surprise14;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "15")
        {
            tagetCharictor.sprite = shy15;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "16")
        {
            tagetCharictor.sprite = angry16;
        }

        // 공략캐릭터2
        if (data_Dialog[clickNum]["chrM"].ToString() == "21")
        {
            tagetCharictor.sprite = nomal21;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "22")
        {
            tagetCharictor.sprite = fun22;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "23")
        {
            tagetCharictor.sprite = sad23;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "24")
        {
            tagetCharictor.sprite = surprise24;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "25")
        {
            tagetCharictor.sprite = shy25;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "26")
        {
            tagetCharictor.sprite = angry26;
        }

        // 공략캐릭터3
        if (data_Dialog[clickNum]["chrM"].ToString() == "31")
        {
            tagetCharictor.sprite = nomal31;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "32")
        {
            tagetCharictor.sprite = fun32;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "33")
        {
            tagetCharictor.sprite = sad33;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "34")
        {
            tagetCharictor.sprite = surprise34;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "35")
        {
            tagetCharictor.sprite = shy35;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "36")
        {
            tagetCharictor.sprite = angry36;
        }

        // 헤일리
        if (data_Dialog[clickNum]["chrM"].ToString() == "41")
        {
            tagetCharictor.sprite = nomal41;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "42")
        {
            tagetCharictor.sprite = fun42;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "43")
        {
            tagetCharictor.sprite = sad43;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "44")
        {
            tagetCharictor.sprite = surprise44;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "45")
        {
            tagetCharictor.sprite = shy45;
        }

        if (data_Dialog[clickNum]["chrM"].ToString() == "46")
        {
            tagetCharictor.sprite = angry46;
        }

        // 그 외
        if (data_Dialog[clickNum]["chrM"].ToString() == "51")
        {
            tagetCharictor.sprite = nomal51;
        }

        // 그 외
        if (data_Dialog[clickNum]["chrM"].ToString() == "61")
        {
            tagetCharictor.sprite = nomal61;
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