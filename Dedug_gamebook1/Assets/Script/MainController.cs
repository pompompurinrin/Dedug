using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{

    public Text nameText; // 캐릭터명 텍스트
    public Text talkText; // 대사 텍스트
    public Button talkBtn; // 대사 넘기는 버튼

    // 선택지 UI
    public Canvas choice;

    // 대사 넘기는 변수 선언
    public static int clickNum;

    public Text selectText1;
    public Text selectText2;
    public Text selectText3;

    // 선택지 2개 뜰 때
    public Text selectText4;
    public Text selectText5;

    // 선택지 버튼
    public Button selectButton1;
    public Button selectButton2;
    public Button selectButton3;

    public Button selectButton4;
    public Button selectButton5;

    public Button selectButtonEnd1;
    public Button selectButtonEnd2;
    public Button selectButtonEnd3;

    public Button SaveBtn;

    // 선택지 출력 시 배경
    public Image talkblackBG;

    public static int evelove;
    public static int micalove;
    public static int woolove;
    // 선택지 조건 변수

    List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    private void Start()
    {
        data_Dialog = CSVReader.Read("DedugScript");
    }


    public void TextClick()
        {

        if (clickNum >= 0)
        {
            
            // CSV 파일 로드 및 캐릭터 이름, 대사 출력
            talkText.text = data_Dialog[clickNum]["talkText"].ToString();
            nameText.text = data_Dialog[clickNum]["name"].ToString();

            // next ID에 값이 있을 경우 다음의 조건문 충족 및 실행
            object nextIDobject;
            bool hasNectID = data_Dialog[clickNum].TryGetValue("next ID", out nextIDobject);

            if (hasNectID && nextIDobject != null && !string.IsNullOrEmpty(nextIDobject.ToString()))
            {
                clickNum = (int)data_Dialog[clickNum]["next ID"];
            }

            // 선택지 selectID에 값이 있을 경우 다음의 조건문 충족 및 실행
            object selectIDObject;
            bool hasSelectID = data_Dialog[clickNum].TryGetValue("selectText1", out selectIDObject);


            if (hasSelectID && selectIDObject != null && !string.IsNullOrEmpty(selectIDObject.ToString()))
            {

                // 선택지 별 버튼 텍스트 출력
                selectText1.text = data_Dialog[clickNum]["selectText1"].ToString();
                selectText2.text = data_Dialog[clickNum]["selectText2"].ToString();
                selectText3.text = data_Dialog[clickNum]["selectText3"].ToString();

                selectText4.text = data_Dialog[clickNum]["selectText1"].ToString();
                selectText5.text = data_Dialog[clickNum]["selectText2"].ToString();

                // 선택지 스크립트 선택지 버튼 출력 함수 실행
                GameObject selectInstance = new GameObject("selectInstance");
                Select script = selectInstance.AddComponent<Select>();
                script.SelectStart();
            }

            else
            {
                clickNum++; // clickNum 1씩 상승
            }
        }
    }

    public void ClickSelectBtn1()
    {

        // 선택지 오브젝트 비활성화
        talkblackBG.gameObject.SetActive(false);
        selectButton1.gameObject.SetActive(false);
        selectButton2.gameObject.SetActive(false);
        selectButton3.gameObject.SetActive(false);
        SaveBtn.gameObject.SetActive(false);

        // 선택지에 따른 대사 출력
        talkText.text = data_Dialog[clickNum]["answerText1"].ToString();
        nameText.text = data_Dialog[clickNum]["answerName"].ToString();

        // 호감도 변경
        evelove += (int)data_Dialog[clickNum]["evelove1"];
        micalove += (int)data_Dialog[clickNum]["micalove1"];
        woolove += (int)data_Dialog[clickNum]["woolove1"];

        // 다음의 대사로 이동
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
        // 선택지 오브젝트 비활성화
        talkblackBG.gameObject.SetActive(false);
        selectButton4.gameObject.SetActive(false);
        selectButton5.gameObject.SetActive(false);


        // 선택지에 따른 대사 출력
        talkText.text = data_Dialog[clickNum]["answerText1"].ToString();
        nameText.text = data_Dialog[clickNum]["answerName"].ToString();

        // 호감도 변경
        evelove += (int)data_Dialog[clickNum]["evelove1"];
        micalove += (int)data_Dialog[clickNum]["micalove1"];
        woolove += (int)data_Dialog[clickNum]["woolove1"];

        // 다음의 대사로 이동
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


    // 엔딩 조건분기 스크립트

    public void ClickSelectBtnEnd1()
    {
        talkblackBG.gameObject.SetActive(false);
        selectButtonEnd1.gameObject.SetActive(false);
        selectButtonEnd2.gameObject.SetActive(false);
        selectButtonEnd3.gameObject.SetActive(false);

        talkText.text = data_Dialog[clickNum]["answerText1"].ToString();
        nameText.text = "이브";

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
        nameText.text = "미카엘";

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
        nameText.text = "우디";

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