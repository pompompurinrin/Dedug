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
            descTextName.text = "ī���̹���";
            descTextTalk.text = "�Ա���";
            Btn1.gameObject.SetActive(true);
            kawa.sprite = kawa1;
            snow.sprite = snow1;
        }
        else if (descNum == 1)
        {
            descTextName.text = "��������";
            descTextTalk.text = "�׷� �Դ�";
            
        }
        else if (descNum == 2)
        {
            descTextName.text = "ī���̹���";
            descTextTalk.text = "���� ���Ͻ�?";
            kawa.sprite = kawa2;
        }
        else if (descNum == 3)
        {
            descTextName.text = "��������";
            descTextTalk.text = "����ڸ�";
            
        }
        else if (descNum == 4)
        {
            descTextName.text = "ī���̹���";
            descTextTalk.text = "��������";
            kawa.sprite = kawa1;
        }
        else if (descNum == 5)
        {
            descTextName.text = "ī���̹���";
            descTextTalk.text = "��������?";
            kawa.sprite = kawa2;
        }
        else if (descNum == 6)
        {
            descTextName.text = "ī���̹���";
            descTextTalk.text = "������ ������?";
            
        }
        else if (descNum == 7)
        {
            descTextName.text = "��������";
            descTextTalk.text = "��;; ���ٵ���;;";
            snow.sprite = snow2;
        }
        else if (descNum == 8)
        {
            descTextName.text = "��������";
            descTextTalk.text = "������ �� ��������;;";
            
        }
        else if (descNum == 9)
        {
            descTextName.text = "ī���̹���";
            descTextTalk.text = "��������";
            kawa.sprite = kawa1;
        }
        else if (descNum == 10)
        {
            descTextName.text = "ī���̹���";
            descTextTalk.text = "�׷� �������ǵ� �ϰ� ����";
            kawa.sprite = kawa2;
        }
        else if (descNum == 11)
        {
            descTextName.text = "��������";
            descTextTalk.text = "��.. ���� ��?";
            snow.sprite = snow1;
        }
        else if (descNum == 12)
        {
            descTextName.text = "ī���̹���";
            descTextTalk.text = "��������.";
            kawa.sprite = kawa1;
        }
        else if (descNum == 13)
        {
            descTextName.text = "��������";
            descTextTalk.text = "������ ������";
            
        }
        else if (descNum == 14)
        {
            descTextName.text = "ī���̹���";
            descTextTalk.text = "��. ���� ������ �?";
            kawa.sprite = kawa2;
        }
        else if (descNum == 15)
        {
            descTextName.text = "��������";
            descTextTalk.text = "��������";
            
        }
        else if (descNum == 16)
        {
            BG.sprite = changeBG;
            descTextName.text = "ī���̹���";
            descTextTalk.text = "�� ���� ���ϳ� ����";
            kawa.sprite = kawa1;
        }

        else if (descNum == 17)
        {
            descTextName.text = "ī���̹���";
            descTextTalk.text = "���� ������ ���߰ڴ�";
            
        }
        else if (descNum == 18)
        {
            descTextName.text = "��������";
            descTextTalk.text = "������ ����. �ٳ����";
            snow.sprite = snow2;
        }
        else if (descNum == 19)
        {
            descTextName.text = "ī���̹���";
            descTextTalk.text = "����";
            
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
