using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �켱 DontDestroyOnLoad�� Ȱ���ؼ� �� ��ȯ�� �߻����� �� �����͵��� �����ǰ� ����
// �ٸ� ��ũ��Ʈ������ �̱����� ����Ϸ��� �긦 Generic���� ����� �ٸ� ��ũ��Ʈ������ Ȱ���ؾ� ��
// Ŭ������<T> : MonoBehavior where T : MonoBehavior  �� �����ָ� �ϼ�
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindAnyObjectByType(typeof(T));  // intsatnce�� null T Ÿ���� ������Ʈ�� ã�� �־��
                if (instance == null) // ã�ƺôµ� ���� ������ null�� ��
                {
                    GameObject obj = new GameObject(typeof(T).Name, typeof(T)); // T Ÿ���� ������Ʈ�� ���� �����
                    instance = obj.GetComponent<T>(); // instace�� �־��
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        // DontDestroyOnLoad�� ������Ʈ�� ������ ���ԵǾ� �ִٸ� ����� �۵����� �ʴ� ��찡 ����
        if (transform.parent != null && transform.root != null) // ���� �θ� ������Ʈ�� �ְų� �ֻ����� ���� ������Ʈ�� �ִٸ�
        {
            DontDestroyOnLoad(this.transform.root.gameObject); // �� ���� ������Ʈ ��ü�� DontDestroy �ض�
        }
        else
        {
            DontDestroyOnLoad(this.gameObject); // �׷��� ������ �� �ڽ��� DontDestroyOnLoad �ض�
        }
        // �̷��� ���� ������ ���� Manager ������Ʈ���� ������ ����� �� ������Ʈ�� ��� ����� �ٵ� �̷��� �θ� ����� ����
    }
}