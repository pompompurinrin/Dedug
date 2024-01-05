using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 우선 DontDestroyOnLoad를 활용해서 씬 전환이 발생했을 때 데이터들이 유지되게 해줌
// 다른 스크립트에서도 싱글톤을 사용하려면 얘를 Generic으로 만들고 다른 스크립트에서도 활용해야 함
// 클래스명<T> : MonoBehavior where T : MonoBehavior  로 적어주면 완성
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindAnyObjectByType(typeof(T));  // intsatnce가 null T 타입의 오브젝트를 찾아 넣어라
                if (instance == null) // 찾아봤는데 없고 여전히 null일 떼
                {
                    GameObject obj = new GameObject(typeof(T).Name, typeof(T)); // T 타입의 오브젝트를 새로 만들고
                    instance = obj.GetComponent<T>(); // instace에 넣어라
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        // DontDestroyOnLoad가 오브젝트의 하위로 포함되어 있다면 제대로 작동되지 않는 경우가 있음
        if (transform.parent != null && transform.root != null) // 만약 부모 오브젝트가 있거나 최상위에 무언가 오브젝트가 있다면
        {
            DontDestroyOnLoad(this.transform.root.gameObject); // 그 상위 오브젝트 전체를 DontDestroy 해라
        }
        else
        {
            DontDestroyOnLoad(this.gameObject); // 그렇지 않으면 내 자신을 DontDestroyOnLoad 해라
        }
        // 이렇게 쓰는 이유는 각종 Manager 오브젝트들을 여러개 만들고 빈 오브젝트로 묶어서 사용할 텐데 이러면 부모가 생기기 때문
    }
}