using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentController : MonoBehaviour
{
    GameObject Player;  // �÷��̾� ������Ʈ�� �����ϱ� ���� ����

    void Start()
    {
        // �÷��̾� ������Ʈ�� ã�Ƽ� ������ �Ҵ�
        this.Player = GameObject.Find("Player");
    }

    void Update()
    {
        // �����Ӹ��� ������� ���Ͻ�Ų�� 
        transform.Translate(0, -0.01f, 0);

        // ȭ�� ������ ������ ������Ʈ�� �Ҹ��Ų��
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        if (this.Player.transform.position == null)
        {
            Destroy(gameObject);
        }
        // �浹 ����
        Vector2 p1 = transform.position;              // ���� ������Ʈ�� �߽� ��ǥ
        Vector2 p2 = this.Player.transform.position;  // �÷��̾��� �߽� ��ǥ
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;  // �� ��ǥ �� �Ÿ�
        float r1 = 0.5f;  // ���� ������Ʈ�� �ݰ�
        float r2 = 1f;  // �÷��̾��� �ݰ�
        float distance = Vector2.Distance(p1, p2);  // �� ��ǥ �� �Ÿ� ���
        GameObject director = GameObject.Find("MainBG");
        if (d < r1 + r2)
        {
            if (director != null) { director.GetComponent<GameControllerScript2>().GoodsCountDown(); }

            Destroy(gameObject);  // ���� ������Ʈ�� �����
        }
        
        if(director == null)
        {
            Destroy(gameObject);
        }
    }
}
