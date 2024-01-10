using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainStory_Guage : MonoBehaviour
{
    // ������ �� UI Slider
    public Slider gaugeSlider;

    // ��ô���� ��Ÿ���� UI Text
    public Text progressText;

    // �رݵ� ������ ����
    public int unlockedCount = 0;
    //�رݵ� ���� ���丮�� ������ 0�̶�� ����.

    // ������ �رݵ� �� ȣ��Ǵ� �Լ�
    public void UnlockType()
    {
        // ������ �ϳ� �رݵ� ������ unlockedCount ����
        unlockedCount++;

        // ������ �� �� �ؽ�Ʈ ������Ʈ
        UpdateGauge();
    }

    // ������ �ٸ� ������Ʈ�ϴ� �Լ�
    public void UpdateGauge()
    {
        // ��ü ������ ���� ����� ���
        float percentage = (float)unlockedCount / 70f;
        //�رݵ� ���� ���丮�� ������ 70���� ���� 0~1 ������ ���� �ǵ��� ����
        //������� �˾ƺ��� ���ؼ� �رݵ� �� ��ü�� 70���� ���� ��

        // ������ �� �� ����
        gaugeSlider.value = percentage * gaugeSlider.maxValue;
        //�̰� �ٽ� �������ٿ� ǥ���ؾ� �ϴϱ� 70�� ����
        //��ü�� 70�̴ϱ�, (0*70)~(1*70) �׷� 0���� 70������ ���� �������� ��Ÿ�� �� ����

        // ��ô���� �ؽ�Ʈ�� ǥ��
        progressText.text = Mathf.RoundToInt(percentage * 100f) + "%";
    }
}
