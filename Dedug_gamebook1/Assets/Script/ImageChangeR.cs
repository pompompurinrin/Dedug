using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class ImageChangeR : MonoBehaviour
{
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
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("DMiyeonsi");

        // ����ĳ����1
        if (data_Dialog[clickNum]["chrR"].ToString() == "11")
        {
            tagetCharictor.sprite = nomal11;
        }

        if (data_Dialog[clickNum]["chrR"].ToString() == "12")
        {
            tagetCharictor.sprite = fun12;
        }

        if (data_Dialog[clickNum]["chrR"].ToString() == "13")
        {
            tagetCharictor.sprite = sad13;
        }

        if (data_Dialog[clickNum]["chrR"].ToString() == "14")
        {
            tagetCharictor.sprite = surprise14;
        }

        if (data_Dialog[clickNum]["chrR"].ToString() == "15")
        {
            tagetCharictor.sprite = shy15;
        }

        if (data_Dialog[clickNum]["chrR"].ToString() == "16")
        {
            tagetCharictor.sprite = angry16;
        }

        // ����ĳ����2
        if (data_Dialog[clickNum]["chrR"].ToString() == "21")
        {
            tagetCharictor.sprite = nomal21;
        }

        if (data_Dialog[clickNum]["chrR"].ToString() == "22")
        {
            tagetCharictor.sprite = fun22;
        }

        if (data_Dialog[clickNum]["chrR"].ToString() == "23")
        {
            tagetCharictor.sprite = sad23;
        }

        if (data_Dialog[clickNum]["chrR"].ToString() == "24")
        {
            tagetCharictor.sprite = surprise24;
        }

        if (data_Dialog[clickNum]["chrR"].ToString() == "25")
        {
            tagetCharictor.sprite = shy25;
        }

        if (data_Dialog[clickNum]["chrR"].ToString() == "26")
        {
            tagetCharictor.sprite = angry26;
        }

        // ����ĳ����3
        if (data_Dialog[clickNum]["chrR"].ToString() == "31")
        {
            tagetCharictor.sprite = nomal31;
        }

        if (data_Dialog[clickNum]["chrR"].ToString() == "32")
        {
            tagetCharictor.sprite = fun32;
        }

        if (data_Dialog[clickNum]["chrR"].ToString() == "33")
        {
            tagetCharictor.sprite = sad33;
        }

        if (data_Dialog[clickNum]["chrR"].ToString() == "34")
        {
            tagetCharictor.sprite = surprise34;
        }

        if (data_Dialog[clickNum]["chrR"].ToString() == "35")
        {
            tagetCharictor.sprite = shy35;
        }

        if (data_Dialog[clickNum]["chrR"].ToString() == "36")
        {
            tagetCharictor.sprite = angry36;
        }

    }
}

// ������ �ʴ� ĳ���� ��Ӱ� ó��

/*        if (data_Dialog[clickNum]["name"].ToString() == "������")
        {
            GameObject chr02 = GameObject.Find("chr02");
            Color color = chr02.GetComponent<Image>().color;
            color.a = 0.5f;
            chr02.GetComponent<Image>().color = color;
        }

        if (data_Dialog[clickNum]["name"].ToString() != "������")
        {
            GameObject chr02 = GameObject.Find("chr02");
            Color color = chr02.GetComponent<Image>().color;
            color.a = 1f;
            chr02.GetComponent<Image>().color = color;
        }*/

// ��Ȱ��ȭ�Ǿ� �ִ� ������Ʈ �� ��
// GameObject.Find("chr").transform.Find("chr02").gameObject.SetActive(true);