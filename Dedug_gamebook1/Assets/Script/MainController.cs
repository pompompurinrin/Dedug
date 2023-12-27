using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{

    public Text nameText; // ĳ���͸� �ؽ�Ʈ
    public Text talkText; // ��� �ؽ�Ʈ
    public Button talkBtn; // ��� �ѱ�� ��ư

    // ������ UI
    public Canvas choice;

    // ��� �ѱ�� ���� ����
    public static int clickNum;

    public Text selectText1;
    public Text selectText2;
    public Text selectText3;

    // ������ ��ư
    public Button selectButton1;
    public Button selectButton2;
    public Button selectButton3;

    public static int love01;
    public static int love02;
    public static int love03;
    // ������ ���� ����

    List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    private void Start()
    {
        data_Dialog = CSVReader.Read("DMiyeonsi");
    }


    public void TextClick()
        {

        if (clickNum >= 0)
        {
            
            // CSV ���� �ε� �� ĳ���� �̸�, ��� ���
            talkText.text = data_Dialog[clickNum]["talkText"].ToString();
            nameText.text = data_Dialog[clickNum]["name"].ToString();

            // ������ selectID�� ���� ���� ��� ������ ���ǹ� ���� �� ����
            object selectIDObject;
            bool hasSelectID = data_Dialog[clickNum].TryGetValue("selectID", out selectIDObject);


            if (hasSelectID && selectIDObject != null && !string.IsNullOrEmpty(selectIDObject.ToString()))
            {

                // ������ �� ��ư �ؽ�Ʈ ���
                selectText1.text = data_Dialog[clickNum]["selectText1"].ToString();
                selectText2.text = data_Dialog[clickNum]["selectText2"].ToString();
                selectText3.text = data_Dialog[clickNum]["selectText3"].ToString();

                // ������ ��ũ��Ʈ ������ ��ư ��� �Լ� ����
                GameObject selectInstance = new GameObject("selectInstance");
                Select script = selectInstance.AddComponent<Select>();
                /*                Select selectInstance = new Select();*/
                script.SelectStart();
            }

            else
            {
                clickNum++; // clickNum 1�� ���
            }

            // ���� �б���
            if (love01 > 10)
            {
                clickNum = 5;
            }
        }
    }

    public void ClickSelectBtn1()
    {

        // ������ ������Ʈ ��Ȱ��ȭ
        selectButton1.gameObject.SetActive(false);
        selectButton2.gameObject.SetActive(false);
        selectButton3.gameObject.SetActive(false);

        // �������� ���� ��� ���
        talkText.text = data_Dialog[clickNum]["answerText1"].ToString();
        nameText.text = data_Dialog[clickNum]["name"].ToString();

        // ȣ���� ����
        love01 += (int)data_Dialog[clickNum]["love1"];

        // ������ ���� �̵�
        clickNum = (int)data_Dialog[clickNum]["next ID1"];

        if (data_Dialog[clickNum]["next ID2"].ToString() == "0")
        {
            clickNum++;
        }
    }

    public void ClickSelectBtn2()
    {
        selectButton1.gameObject.SetActive(false);
        selectButton2.gameObject.SetActive(false);
        selectButton3.gameObject.SetActive(false);

        talkText.text = data_Dialog[clickNum]["answerText2"].ToString();
        nameText.text = data_Dialog[clickNum]["name"].ToString();

        love02 += (int)data_Dialog[clickNum]["love2"];

        clickNum = (int)data_Dialog[clickNum]["next ID2"];

        if (data_Dialog[clickNum]["next ID2"].ToString() == "0")
        {
            clickNum++;
        }

    }

    public void ClickSelectBtn3()
    {
        selectButton1.gameObject.SetActive(false);
        selectButton2.gameObject.SetActive(false);
        selectButton3.gameObject.SetActive(false);

        talkText.text = data_Dialog[clickNum]["answerText3"].ToString();
        nameText.text = data_Dialog[clickNum]["name"].ToString();

        love03 += (int)data_Dialog[clickNum]["love3"];

        clickNum = (int)data_Dialog[clickNum]["next ID3"];

        if (data_Dialog[clickNum]["next ID3"].ToString() == "0")
        {
            clickNum++;
        }
    }
}