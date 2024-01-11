using UnityEngine;

public class ClickEffect : MonoBehaviour
{
    public GameObject touchEffectPrefab;
    public float effectDuration = 1.5f; // ����Ʈ�� ���� �ð�
    public float scaleFactor = 0.5f; // ����Ʈ�� ũ�� ����


    void Update()
    {
        // ��ġ �Է� ����
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // ��ġ ���� ��
            if (touch.phase == TouchPhase.Began)
            {
                // ��ġ�� ��ġ�� ����Ʈ ����
                CreateTouchEffect(touch.position);
            }
        }
    }

    void CreateTouchEffect(Vector2 position)
    {
        // ��ġ�� ��ġ�� 2D ��ǥ�� ��ȯ
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, 10f));



        // ����Ʈ ����
        GameObject effectObject = Instantiate(touchEffectPrefab, touchPosition, Quaternion.identity);

        // ũ�� ����
        effectObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);



        // ������ ���� �ð� �Ŀ� ����Ʈ�� �ı�
        Destroy(effectObject, effectDuration);
    }
}

