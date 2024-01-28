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
        // �����Ӹ��� ������� ���Ͻ�Ų�� 
        transform.Translate(0, -0.05f, 0);

        // ���� �ֱ�
        span = 0.2f;

        // ȭ�� ������ ������ ������Ʈ�� �Ҹ��Ų��.
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        if (Player.transform.position == null)
        {
            Destroy(gameObject);
        }

        // �浹 ����
        Vector2 p1 = transform.position;              // ���� ������Ʈ�� �߽� ��ǥ
        Vector2 p2 = Player.transform.position;  // �÷��̾��� �߽� ��ǥ
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;  // �� ��ǥ �� �Ÿ�
        float r1 = 0.25f;  // ���� ������Ʈ�� �ݰ�
        float r2 = 0.25f;  // �÷��̾��� �ݰ�
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
