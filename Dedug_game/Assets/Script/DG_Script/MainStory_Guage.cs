using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainStory_Guage : MonoBehaviour
{
    // 게이지 바 UI Slider
    public Slider gaugeSlider;

    // 진척도를 나타내는 UI Text
    public Text progressText;

    // 해금된 종류의 개수
    public int unlockedCount = 0;
    //해금된 메인 스토리의 갯수를 0이라고 하자.

    // 종류가 해금될 때 호출되는 함수
    public void UnlockType()
    {
        // 종류가 하나 해금될 때마다 unlockedCount 증가
        unlockedCount++;

        // 게이지 바 및 텍스트 업데이트
        UpdateGauge();
    }

    // 게이지 바를 업데이트하는 함수
    public void UpdateGauge()
    {
        // 전체 종류에 대한 백분율 계산
        float percentage = (float)unlockedCount / 70f;
        //해금된 메인 스토리의 개수를 70으로 나눠 0~1 사이의 값이 되도록 조정
        //백분율을 알아보기 위해서 해금된 걸 전체인 70개로 나눈 것

        // 게이지 바 값 갱신
        gaugeSlider.value = percentage * gaugeSlider.maxValue;
        //이걸 다시 게이지바에 표시해야 하니까 70을 곱함
        //전체가 70이니까, (0*70)~(1*70) 그럼 0부터 70까지의 수로 게이지를 나타낼 수 있음

        // 진척도를 텍스트로 표시
        progressText.text = Mathf.RoundToInt(percentage * 100f) + "%";
    }
}
