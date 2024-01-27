using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleController : MonoBehaviour
{
    GameObject Player;  // 플레이어 오브젝트를 참조하기 위한 변수
    public float span;
    void Start()
    {
        // 플레이어 오브젝트를 찾아서 변수에 할당
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        // 프레임마다 등속으로 낙하시킨다 
        transform.Translate(0, -1f, 0);
        span = 1;
        // 화면 밖으로 나오면 오브젝트를 소멸시킨다
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        // 충돌 판정
        Vector2 p1 = transform.position;              // 현재 오브젝트의 중심 좌표
        Vector2 p2 = Player.transform.position;  // 플레이어의 중심 좌표
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;  // 두 좌표 간 거리
        float r1 = 0.25f;  // 현재 오브젝트의 반경
        float r2 = 0.25f;  // 플레이어의 반경
        float distance = Vector2.Distance(p1, p2);  // 두 좌표 간 거리 계산

        GameObject director = GameObject.Find("DropGoodsGenerator");

        if (d < r1 + r2)
        {
            if (director != null) { director.GetComponent<MainController2>().CountDown(); }
            Destroy(gameObject);  // 현재 오브젝트를 지운다
        }
        
        if(director == null)
        {
            Destroy(gameObject);
        }
    }
}
