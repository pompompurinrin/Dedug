using UnityEngine;

public class ClickEffect : MonoBehaviour
{
    public GameObject touchEffectPrefab;
    public float effectDuration = 1.5f; // 이펙트의 지속 시간
    public float scaleFactor = 0.5f; // 이펙트의 크기 비율


    void Update()
    {
        // 터치 입력 감지
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // 터치 시작 시
            if (touch.phase == TouchPhase.Began)
            {
                // 터치한 위치로 이펙트 생성
                CreateTouchEffect(touch.position);
            }
        }
    }

    void CreateTouchEffect(Vector2 position)
    {
        // 터치한 위치를 2D 좌표로 변환
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, 10f));



        // 이펙트 생성
        GameObject effectObject = Instantiate(touchEffectPrefab, touchPosition, Quaternion.identity);

        // 크기 조절
        effectObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);



        // 지정된 지속 시간 후에 이펙트를 파괴
        Destroy(effectObject, effectDuration);
    }
}

