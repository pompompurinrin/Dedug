using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_02 : MonoBehaviour
{
    GameObject Player;

    void Start()
    {
       
    }

    // ���� ��ư�� ������ �� ȣ��Ǵ� �Լ�
    public void LButtonDown()
    {
        if (transform.position.x < -1.5f)
        {
            transform.Translate(0, 0, 0);  // �÷��̾� �̵� ����.
        }

        else 
        {
            transform.Translate(-1.1f, 0, 0);  // �÷��̾ �������� 1��ŭ �̵�
        }
    }

    // ������ ��ư�� ������ �� ȣ��Ǵ� �Լ�
    public void RButtonDown()
    {
        if (transform.position.x > 1.5f )
        {
            transform.Translate(0, 0, 0);  // �÷��̾� �̵� ����.
        }

        else
        {
            transform.Translate(1.1f, 0, 0);  // �÷��̾ �������� 1��ŭ �̵�
        }
    }
}

