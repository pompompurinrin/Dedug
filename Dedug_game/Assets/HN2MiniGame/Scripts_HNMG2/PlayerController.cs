using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // 왼쪽 버튼을 눌렀을 때 호출되는 함수
    public void LButtonDown()
    {
        if (transform.position.x < -1.5f) // 플레이어가 화면 왼른쪽으로 벗어나면
        {
            transform.Translate(0, 0, 0);  // 플레이어 이동 없음.
        }

        else 
        {
            transform.Translate(-1.1f, 0, 0);  // 플레이어를 왼쪽으로 1만큼 이동
        }
    }

    // 오른쪽 버튼을 눌렀을 때 호출되는 함수
    public void RButtonDown()
    {
        if (transform.position.x > 1.5f ) // 플레이어가 화면 오른쪽으로 벗어나면
        {
            transform.Translate(0, 0, 0);  // 플레이어 이동 없음.
        }

        else
        {
            transform.Translate(1.1f, 0, 0);  // 플레이어를 왼쪽으로 1만큼 이동
        }
    }
}

