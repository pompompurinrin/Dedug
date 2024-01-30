using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    GameObject Player;          // �÷��̾� ������Ʈ�� �����ϱ� ���� ����
    public float span;          // ������Ʈ �����Ǵ� �ֱ�

    void Start()
    {
        // �÷��̾� ������Ʈ�� ã�Ƽ� ������ �Ҵ�
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        // ���ڰ� Ŀ������ ������
        // �����Ӹ��� ������� ���Ͻ�Ų�� 
        transform.Translate(0, -0.15f, 0);
        // ���� �ֱ�
        // ���ڰ� Ŀ������ �ֱⰡ ª���� (���� ����).
        span = 0.8f;

        // ȭ�� ������ ������ ������Ʈ�� �Ҹ��Ų��
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        if (Player.transform.position == null)
        {
            Destroy(gameObject);
        }

        // �浹 ����
        Vector2 p1 = Player.transform.position;       // �÷��̾��� �߽� ��ǥ
        Vector2 p2 = transform.position;              // ���� ������Ʈ�� �߽� ��ǥ

        // �÷��̾��� �߽� ��ǥ�� ���纸�� ���� ���� ����
        p1.y += 0.7f;

        // ���� ������Ʈ�� �߽� ��ǥ�� ���纸�� ���� �Ʒ��� ����
        p2.y -= 0.4f;

        Vector2 dir = p1 - p2;
        float d = dir.magnitude;  // �� ��ǥ �� �Ÿ�
        float r1 = 0.3f;  // ���� ������Ʈ�� �ݰ�
        float r2 = 0.6f;  // �÷��̾��� �ݰ�
        float distance = Vector2.Distance(p1, p2);  // �� ��ǥ �� �Ÿ� ���

        GameObject director = GameObject.Find("MainController2");

        if (d < r1 + r2)
        {
            if (director != null) 
            { 
                director.GetComponent<MainController2>().CountDown(); 
            }
            Destroy(gameObject);  // ���� ������Ʈ�� �����
        }
        
        if(director == null)
        {
            Destroy(gameObject);
        }
    }
}
