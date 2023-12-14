using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // 루아는 따로 정의 안하면 글로벌(아무데서나 접근). 지역 변수(local) 따로 해줬을거임
    // Start is called before the first frame update
    [HideInInspector]
    public int TestValue = 1;

    public Image BG;

    [SerializeField]
    TextMeshProUGUI _text;
   

    [SerializeField]
    Color _color;
    bool isChanged;

    Sprite DefaltBG;//기본
    [SerializeField]
    Sprite ChangeBG;//바꿀거

    private void Start()
    {
        DefaltBG = BG.sprite;
        //Debug.Log(TestValue);
    }

    // color를 바꿔주는 기능
    public void ColorChange()
    {
        if(!isChanged)
        {
            BG.sprite = ChangeBG;
            _text.text = "daiski";
            isChanged = true;
        }
        else
        {
            BG.sprite = DefaltBG;
            _text.text = "Miku";
            isChanged = false;
        }


    }

}
