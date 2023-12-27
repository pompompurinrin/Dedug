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

    // 선택지 버튼
    public Button selectButton1;
    public Button selectButton2;
    public Button selectButton3;

    public static int love01;
    public static int love02;
    public static int love03;
    // 선택지 조건 변수

    List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    private void Start()
    {
        data_Dialog = CSVReader.Read("DMiyeonsi");
    }


    public void TextClick()
        {

        if (clickNum >= 0)
        {
            
            // CSV 파일 로드 및 캐릭터 이름, 대사 출력
            talkText.text = data_Dialog[clickNum]["talkText"].ToString();
            nameText.text = data_Dialog[clickNum]["name"].ToString();

            // 선택지 selectID에 값이 있을 경우 다음의 조건문 충족 및 실행
            object selectIDObject;
            bool hasSelectID = data_Dialog[clickNum].TryGetValue("selectID", out selectIDObject);


            if (hasSelectID && selectIDObject != null && !string.IsNullOrEmpty(selectIDObject.ToString()))
            {

                // 선택지 별 버튼 텍스트 출력
                selectText1.text = data_Dialog[clickNum]["selectText1"].ToString();
                selectText2.text = data_Dialog[clickNum]["selectText2"].ToString();
                selectText3.text = data_Dialog[clickNum]["selectText3"].ToString();

                // 선택지 스크립트 선택지 버튼 출력 함수 실행
                GameObject selectInstance = new GameObject("selectInstance");
                Select script = selectInstance.AddComponent<Select>();
                /*                Select selectInstance = new Select();*/
                script.SelectStart();
            }

            else
            {
                clickNum++; // clickNum 1씩 상승
            }

            // 엔딩 분기점
            if (love01 > 10)
            {
                clickNum = 5;
            }
        }
    }

    public void ClickSelectBtn1()
    {

        // 선택지 오브젝트 비활성화
        selectButton1.gameObject.SetActive(false);
        selectButton2.gameObject.SetActive(false);
        selectButton3.gameObject.SetActive(false);

        // 선택지에 따른 대사 출력
        talkText.text = data_Dialog[clickNum]["answerText1"].ToString();
        nameText.text = data_Dialog[clickNum]["name"].ToString();

        // 호감도 변경
        love01 += (int)data_Dialog[clickNum]["love1"];

        // 다음의 대사로 이동
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