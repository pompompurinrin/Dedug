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

    //�⺻ ���� �̹���
    public Sprite chrictorNomal;

    // ǥ�� ����Ʈ
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

    // �⺻ ���� �̹���
    public Image tagetCharictor;

    // �ִϸ��̼�
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

        if (data_Dialog[clickNum]["selectText1"].ToString() == "�� ��� �����ٵ�?")
        {
            tagetCharictor.sprite = fun12;
        }

        if (data_Dialog[clickNum]["selectText2"].ToString() == "�۽�.. �� ���ٱ� ����?")
        {
            tagetCharictor.sprite = nomal11;
        }

        if (data_Dialog[clickNum]["selectText3"].ToString() == "�� ���̾� �Ű澲����.")
        {
            tagetCharictor.sprite = sad13;
        }

        if (data_Dialog[clickNum]["selectText1"].ToString() == "�� �� ���̿� �ųʰ� �þ���?")
        {
            tagetCharictor.sprite = nomal11;
        }

        if (data_Dialog[clickNum]["selectText2"].ToString() == "��� ������Ʈ �� �ٰǵ�?")
        {
            tagetCharictor.sprite = fun12;
        }

        if (data_Dialog[clickNum]["selectText3"].ToString() == "���� ������ �� ��������")
        {
            tagetCharictor.sprite = sad13;
        }


        if (data_Dialog[clickNum]["selectText1"].ToString() == "�׷��� ���� �� �޶�� �߾�?")
        {
            tagetCharictor.sprite = sad13;
        }

        if (data_Dialog[clickNum]["selectText2"].ToString() == "���� �ð� �� �ּż� �����մϴ�.")
        {
            tagetCharictor.sprite = nomal11;
        }

        if (data_Dialog[clickNum]["selectText3"].ToString() == "�� ���� ���༭ ����.")
        {
            tagetCharictor.sprite = fun12;
        }



        if (data_Dialog[clickNum]["selectText1"].ToString() == "�׳� �Ϳ����� ���� �𸣰� �þ�.")
        {
            tagetCharictor.sprite = shy35;
        }

        if (data_Dialog[clickNum]["selectText2"].ToString() == "�׳� ���ž�.")
        {
            tagetCharictor.sprite = surprise34;
        }

        if (data_Dialog[clickNum]["selectText3"].ToString() == "���� ������ �� ��������� ���ھ�.")
        {
            tagetCharictor.sprite = angry36;
        }


    }
}