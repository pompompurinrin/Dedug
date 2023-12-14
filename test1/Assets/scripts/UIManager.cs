using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // ��ƴ� ���� ���� ���ϸ� �۷ι�(�ƹ������� ����). ���� ����(local) ���� ����������
    // Start is called before the first frame update
    [HideInInspector]
    public int TestValue = 1;

    public Image BG;

    [SerializeField]
    TextMeshProUGUI _text;
   

    [SerializeField]
    Color _color;
    bool isChanged;

    Sprite DefaltBG;//�⺻
    [SerializeField]
    Sprite ChangeBG;//�ٲܰ�

    private void Start()
    {
        DefaltBG = BG.sprite;
        //Debug.Log(TestValue);
    }

    // color�� �ٲ��ִ� ���
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
