using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkingText : MonoBehaviour
{
    public Text buttonText;
    private bool isBlinking = false;

    void Start()
    {
        StartCoroutine(BlinkText());
    }

    IEnumerator BlinkText()
    {
        while (true)
        {
            buttonText.enabled = !buttonText.enabled;
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void OnButtonPress()
    {
        StopCoroutine(BlinkText());
        buttonText.enabled = false; // ��ư�� ������ �ؽ�Ʈ�� ������� ����
    }
}