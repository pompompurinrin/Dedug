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

    // ������ 2�� �� ��
    public Text selectText4;
    public Text selectText5;

    public Text selectTextEnd1;
    public Text selectTextEnd2;
    public Text selectTextEnd3;

    // ������ ��ư
    public Button selectButton1;
    public Button selectButton2;
    public Button selectButton3;

    public Button selectButton4;
    public Button selectButton5;

    public Button selectButtonEnd1;
    public Button selectButtonEnd2;
    public Button selectButtonEnd3;

    public Button SaveBtn;

    // ������ ��� �� ���
    public Image talkblackBG;

    public static int evelove;
    public static int micalove;
    public static int woolove;
    // ������ ���� ����

    List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    private void Start()
    {
        data_Dialog = CSVReader.Read("DedugScript");
    }


    public void TextClick()
        {

        if (clickNum >= 0)
        {
            
            // CSV ���� �ε� �� ĳ���� �̸�, ��� ���
            talkText.text = data_Dialog[clickNum]["talkText"].ToString();
            nameText.text = data_Dialog[clickNum]["name"].ToString();

            // next ID�� ���� ���� ��� ������ ���ǹ� ���� �� ����
            object nextIDobject;
            bool hasNectID = data_Dialog[clickNum].TryGetValue("next ID", out nextIDobject);

            if (hasNectID && nextIDobject != null && !string.IsNullOrEmpty(nextIDobject.ToString()))
            {
                clickNum = (int)data_Dialog[clickNum]["next ID"];
            }

            // ������ selectID�� ���� ���� ��� ������ ���ǹ� ���� �� ����
            object selectIDObject;
            bool hasSelectID = data_Dialog[clickNum].TryGetValue("selectText1", out selectIDObject);


            if (hasSelectID && selectIDObject != null && !string.IsNullOrEmpty(selectIDObject.ToString()))
            {

                // ������ �� ��ư �ؽ�Ʈ ���
                selectText1.text = data_Dialog[clickNum]["selectText1"].ToString();
                selectText2.text = data_Dialog[clickNum]["selectText2"].ToString();
                selectText3.text = data_Dialog[clickNum]["selectText3"].ToString();

                selectText4.text = data_Dialog[clickNum]["selectText1"].ToString();
                selectText5.text = data_Dialog[clickNum]["selectText2"].ToString();

                selectTextEnd1.text = "�̺�";
                selectTextEnd2.text = "��ī��";
                selectTextEnd3.text = "���";

                // ������ ��ũ��Ʈ ������ ��ư ��� �Լ� ����
                GameObject selectInstance = new GameObject("selectInstance");
                Select script = selectInstance.AddComponent<Select>();
                script.SelectStart();
            }

            else
            {
                clickNum++; // clickNum 1�� ���
            }
        }
    }

    public void ClickSelectBtn1()
    {

        // ������ ������Ʈ ��Ȱ��ȭ
        talkblackBG.gameObject.SetActive(false);
        selectButton1.gameObject.SetActive(false);
        selectButton2.gameObject.SetActive(false);
        selectButton3.gameObject.SetActive(false);
        SaveBtn.gameObject.SetActive(false);

        // �������� ���� ��� ���
        talkText.text = data_Dialog[clickNum]["answerText1"].ToString();
        nameText.text = data_Dialog[clickNum]["answerName"].ToString();

        // ȣ���� ����
        evelove += (int)data_Dialog[clickNum]["evelove1"];
        micalove += (int)data_Dialog[clickNum]["micalove1"];
        woolove += (int)data_Dialog[clickNum]["woolove1"];

        // ������ ���� �̵�
        clickNum = (int)data_Dialog[clickNum]["next ID1"];

        clickNum++;
    }

    public void ClickSelectBtn2()
    {
        talkblackBG.gameObject.SetActive(false);
        selectButton1.gameObject.SetActive(false);
        selectButton2.gameObject.SetActive(false);
        selectButton3.gameObject.SetActive(false);
        SaveBtn.gameObject.SetActive(false);

        talkText.text = data_Dialog[clickNum]["answerText2"].ToString();
        nameText.text = data_Dialog[clickNum]["answerName"].ToString();

        evelove += (int)data_Dialog[clickNum]["evelove2"];
        micalove += (int)data_Dialog[clickNum]["micalove2"];
        woolove += (int)data_Dialog[clickNum]["woolove2"];

        clickNum = (int)data_Dialog[clickNum]["next ID2"];

    }

    public void ClickSelectBtn3()
    {
        talkblackBG.gameObject.SetActive(false);
        selectButton1.gameObject.SetActive(false);
        selectButton2.gameObject.SetActive(false);
        selectButton3.gameObject.SetActive(false);
        SaveBtn.gameObject.SetActive(false);

        talkText.text = data_Dialog[clickNum]["answerText3"].ToString();
        nameText.text = data_Dialog[clickNum]["answerName"].ToString();

        evelove += (int)data_Dialog[clickNum]["evelove3"];
        micalove += (int)data_Dialog[clickNum]["micalove3"];
        woolove += (int)data_Dialog[clickNum]["woolove3"];

        clickNum = (int)data_Dialog[clickNum]["next ID3"];

    }

    public void ClickSelectBtn4()
    {
        // ������ ������Ʈ ��Ȱ��ȭ
        talkblackBG.gameObject.SetActive(false);
        selectButton4.gameObject.SetActive(false);
        selectButton5.gameObject.SetActive(false);


        // �������� ���� ��� ���
        talkText.text = data_Dialog[clickNum]["answerText1"].ToString();
        nameText.text = data_Dialog[clickNum]["answerName"].ToString();

        // ȣ���� ����
        evelove += (int)data_Dialog[clickNum]["evelove1"];
        micalove += (int)data_Dialog[clickNum]["micalove1"];
        woolove += (int)data_Dialog[clickNum]["woolove1"];

        // ������ ���� �̵�
        clickNum = (int)data_Dialog[clickNum]["next ID1"];

    }

    public void ClickSelectBtn5()
    {
        talkblackBG.gameObject.SetActive(false);
        selectButton4.gameObject.SetActive(false);
        selectButton5.gameObject.SetActive(false);

        talkText.text = data_Dialog[clickNum]["answerText2"].ToString();
        nameText.text = data_Dialog[clickNum]["answerName"].ToString();

        evelove += (int)data_Dialog[clickNum]["evelove2"];
        micalove += (int)data_Dialog[clickNum]["micalove2"];
        woolove += (int)data_Dialog[clickNum]["woolove2"];

        clickNum = (int)data_Dialog[clickNum]["next ID2"];

    }


    // ���� ���Ǻб� ��ũ��Ʈ

    public void ClickSelectBtnEnd1()
    {
        talkblackBG.gameObject.SetActive(false);
        selectButtonEnd1.gameObject.SetActive(false);
        selectButtonEnd2.gameObject.SetActive(false);
        selectButtonEnd3.gameObject.SetActive(false);

        talkText.text = data_Dialog[clickNum]["answerText1"].ToString();
        nameText.text = "�̺�";

        if (evelove >= 3)
        {
            clickNum = 168;
        }

        if (evelove == 3)
        {
            clickNum = 157;
        }

        if (micalove >= 2)
        {
            clickNum = 360;
        }

        if (woolove >= 2)
        {
            clickNum = 535;
        }

        if (evelove <= 1 && micalove <= 1 && woolove <= 1)
        {
            clickNum = 552;
        }



    }

    public void ClickSelectBtnEnd2()
    {
        talkblackBG.gameObject.SetActive(false);
        selectButtonEnd1.gameObject.SetActive(false);
        selectButtonEnd2.gameObject.SetActive(false);
        selectButtonEnd3.gameObject.SetActive(false);

        talkText.text = data_Dialog[clickNum]["answerText2"].ToString();
        nameText.text = "��ī��";

        if (evelove >= 3)
        {
            clickNum = 168;
        }

        if (evelove == 3)
        {
            clickNum = 157;
        }

        if (micalove >= 2)
        {
            clickNum = 360;
        }

        if (woolove >= 2)
        {
            clickNum = 535;
        }

        if (evelove <= 1 && micalove <= 1 && woolove <= 1)
        {
            clickNum = 552;
        }

    }

    public void ClickSelectBtnEnd3()
    {
        talkblackBG.gameObject.SetActive(false);
        selectButtonEnd1.gameObject.SetActive(false);
        selectButtonEnd2.gameObject.SetActive(false);
        selectButtonEnd3.gameObject.SetActive(false);

        talkText.text = data_Dialog[clickNum]["answerText3"].ToString();
        nameText.text = "���";

        if (evelove >= 3)
        {
            clickNum = 168;
        }

        if (evelove == 3)
        {
            clickNum = 157;
        }

        if (micalove >= 2)
        {
            clickNum = 360;
        }

        if (woolove >= 2)
        {
            clickNum = 535;
        }

        if (evelove <= 1 && micalove <= 1 && woolove <= 1)
        {
            clickNum = 552;
        }
    }

}