using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    int descNum;
    public TextMeshProUGUI descTextName;
    public TextMeshProUGUI descTextTalk;
    public Button Btn1;
    public Sprite DefaultBG;
    public Sprite changeBG;
    public Image BG;

    public Image snow;
    public Image kawa;
    public Sprite snow1;
    public Sprite snow2;
    public Sprite kawa1;
    public Sprite kawa2;


    public void ChangeDesc()
    {
        if (descNum == 0)
        {
            BG.sprite = DefaultBG;
            descTextName.text = "카와이미쿠";
            descTextTalk.text = "왔구만";
            Btn1.gameObject.SetActive(true);
            kawa.sprite = kawa1;
            snow.sprite = snow1;
        }
        else if (descNum == 1)
        {
            descTextName.text = "스노우미쿠";
            descTextTalk.text = "그래 왔다";
            
        }
        else if (descNum == 2)
        {
            descTextName.text = "카와이미쿠";
            descTextTalk.text = "오늘 뭐하실?";
            kawa.sprite = kawa2;
        }
        else if (descNum == 3)
        {
            descTextName.text = "스노우미쿠";
            descTextTalk.text = "밥먹자리";
            
        }
        else if (descNum == 4)
        {
            descTextName.text = "카와이미쿠";
            descTextTalk.text = "ㅇㅋㅇㅋ";
            kawa.sprite = kawa1;
        }
        else if (descNum == 5)
        {
            descTextName.text = "카와이미쿠";
            descTextTalk.text = "뭐먹으실?";
            kawa.sprite = kawa2;
        }
        else if (descNum == 6)
        {
            descTextName.text = "카와이미쿠";
            descTextTalk.text = "마라탕 먹으실?";
            
        }
        else if (descNum == 7)
        {
            descTextName.text = "스노우미쿠";
            descTextTalk.text = "아;; 에바데스;;";
            snow.sprite = snow2;
        }
        else if (descNum == 8)
        {
            descTextName.text = "스노우미쿠";
            descTextTalk.text = "마라탕 개 극혐데스;;";
            
        }
        else if (descNum == 9)
        {
            descTextName.text = "카와이미쿠";
            descTextTalk.text = "ㄲㅂㄲㅂ";
            kawa.sprite = kawa1;
        }
        else if (descNum == 10)
        {
            descTextName.text = "카와이미쿠";
            descTextTalk.text = "그럼 뭐먹을건데 니가 정해";
            kawa.sprite = kawa2;
        }
        else if (descNum == 11)
        {
            descTextName.text = "스노우미쿠";
            descTextTalk.text = "음.. 엽떡 ㄱ?";
            snow.sprite = snow1;
        }
        else if (descNum == 12)
        {
            descTextName.text = "카와이미쿠";
            descTextTalk.text = "ㅇㅋㅇㅋ.";
            kawa.sprite = kawa1;
        }
        else if (descNum == 13)
        {
            descTextName.text = "스노우미쿠";
            descTextTalk.text = "엽떡엔 소주지";
            
        }
        else if (descNum == 14)
        {
            descTextName.text = "카와이미쿠";
            descTextTalk.text = "콜. 빨뚜 병나발 어떰?";
            kawa.sprite = kawa2;
        }
        else if (descNum == 15)
        {
            descTextName.text = "스노우미쿠";
            descTextTalk.text = "낫베드지";
            
        }
        else if (descNum == 16)
        {
            BG.sprite = changeBG;
            descTextName.text = "카와이미쿠";
            descTextTalk.text = "아 ㄹㅇ 취하네 ㅋㅋ";
            kawa.sprite = kawa1;
        }

        else if (descNum == 17)
        {
            descTextName.text = "카와이미쿠";
            descTextTalk.text = "술똥 조지러 가야겠다";
            
        }
        else if (descNum == 18)
        {
            descTextName.text = "스노우미쿠";
            descTextTalk.text = "더러운 새끼. 다녀오셈";
            snow.sprite = snow2;
        }
        else if (descNum == 19)
        {
            descTextName.text = "카와이미쿠";
            descTextTalk.text = "ㅇㅇ";
            
        }
        else
        {
            Btn1.gameObject.SetActive(true);
            
        }
        if (descNum == 19)
        {
            descNum = 0;
        }
        else
        {
            descNum++;
        }


    }
}
