using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;


public class Animation : MonoBehaviour
{
    public Image targetImage;
    public Color targetColor = Color.red;
    public float fadeDuration = 3f;

    int clickNum = MainController.clickNum;

    List<Dictionary<string, object>> data_Dialog = CSVReader.Read("DedugScript");

    private void Update()
    {
        Fade();
    }

    public void Fade()
    {
        if (data_Dialog[clickNum]["action"].ToString() == "11")
        {
            // �ʱ� ���� ����
            Color initialColor = targetImage.color;

            // Fade In �ִϸ��̼�
            targetImage.DOColor(targetColor, fadeDuration);

            // Fade Out �ִϸ��̼�
            StartCoroutine(FadeOutAfterDelay(initialColor, fadeDuration, 5f));
        }
    }

    // ���� �� Fade Out �ִϸ��̼� ����
    IEnumerator FadeOutAfterDelay(Color initialColor, float duration, float delay)
    {
        yield return new WaitForSeconds(delay);
        targetImage.DOColor(initialColor, duration);
    }
}
