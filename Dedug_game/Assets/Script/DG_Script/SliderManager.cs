using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public GameObject SUA_Goods;
    public GameObject BADA_Goods;
    public GameObject CHORONG_Goods;
    public GameObject SUA_Story;
    public GameObject BADA_Story;
    public GameObject CHORONG_Story;
    public GameObject Main_Story;
    int activeCha_1RedDotCnt;// 게이지바에 반영될 변수
    int activeCha_2RedDotCnt;
    int activeCha_3RedDotCnt;
    int activeC1_STORYRedDotCnt;
    int activeC2_STORYRedDotCnt;
    int activeC3_STORYRedDotCnt;
    int activeMainRedDotCnt;

    public Slider Cha_1_Goods;// Unity Inspector에서 Slider 컴포넌트를 할당하기 위한 변수
    public Slider Cha_2_Goods;
    public Slider Cha_3_Goods;
    public Slider Cha_1_Story;
    public Slider Cha_2_Story;
    public Slider Cha_3_Story;
    public Slider MainStory;

    public Text valueText1_G;
    public Text valueText2_G;
    public Text valueText3_G;
    public Text valueText1_S;
    public Text valueText2_S;
    public Text valueText3_S;
    public Text valueTextM_S;


    private void Awake()
    {
            Clear();

    }

    void Clear()
    {
        activeCha_1RedDotCnt = 0;
        activeCha_2RedDotCnt = 0;
        activeCha_3RedDotCnt = 0;
        activeC1_STORYRedDotCnt = 0;
        activeC2_STORYRedDotCnt = 0;
        activeC3_STORYRedDotCnt = 0;
        activeMainRedDotCnt = 0;
    }

    public void OnEnable()
    {
        activeCha_1RedDotCnt = SUA_Goods.gameObject.GetComponent<GoodsNumManager>().activeCha_1RedDotCnt;
        PlayerPrefs.SetInt("activeCha_1RedDotCnt", DataManager.Instance.activeCha_1RedDotCnt);
        // activeCha_1RedDotCnt 값이 변경될 때마다 Cha_1_Goods.value 업데이트
        if (Cha_1_Goods.value != activeCha_1RedDotCnt)
        {
            Cha_1_Goods.value = activeCha_1RedDotCnt;

            // 게이지바 업데이트 함수 호출
            SUA_GoodsGauge();
        }

        activeCha_2RedDotCnt = BADA_Goods.gameObject.GetComponent<GoodsNumManager>().activeCha_2RedDotCnt;
        PlayerPrefs.SetInt("activeCha_2RedDotCnt", DataManager.Instance.activeCha_2RedDotCnt);
        
        if (Cha_2_Goods.value != activeCha_2RedDotCnt)
        {
            Cha_2_Goods.value = activeCha_2RedDotCnt;

            BADA_GoodsGauge();
        }

        activeCha_3RedDotCnt = CHORONG_Goods.gameObject.GetComponent<GoodsNumManager>().activeCha_3RedDotCnt;
        PlayerPrefs.SetInt("activeCha_3RedDotCnt", DataManager.Instance.activeCha_3RedDotCnt);

        if (Cha_3_Goods.value != activeCha_3RedDotCnt)
        {
            Cha_3_Goods.value = activeCha_3RedDotCnt;

            CHORONG_GoodsGauge();
        }

        activeC1_STORYRedDotCnt = SUA_Story.gameObject.GetComponent<GoodsNumManager>().activeC1_STORYRedDotCnt;
        PlayerPrefs.SetInt("activeC1_STORYRedDotCnt", DataManager.Instance.activeC1_STORYRedDotCnt);

        if (Cha_1_Story.value != activeC1_STORYRedDotCnt)
        {
            Cha_1_Story.value = activeC1_STORYRedDotCnt;

            SUA_StoryGauge();
        }

        activeC2_STORYRedDotCnt = BADA_Story.gameObject.GetComponent<GoodsNumManager>().activeC2_STORYRedDotCnt;
        PlayerPrefs.SetInt("activeC2_STORYRedDotCnt", DataManager.Instance.activeC2_STORYRedDotCnt);

        if (Cha_2_Story.value != activeC2_STORYRedDotCnt)
        {
            Cha_2_Story.value = activeC2_STORYRedDotCnt;

            BADA_StoryGauge();
        }

        activeC3_STORYRedDotCnt = CHORONG_Story.gameObject.GetComponent<GoodsNumManager>().activeC3_STORYRedDotCnt;
        PlayerPrefs.SetInt(" activeC3_STORYRedDotCnt", DataManager.Instance.activeC3_STORYRedDotCnt);

        if (Cha_3_Story.value != activeC3_STORYRedDotCnt)
        {
            Cha_3_Story.value = activeC3_STORYRedDotCnt;

            CHORONG_StoryGauge();
        }

        activeMainRedDotCnt = MainStory.gameObject.GetComponent<GoodsNumManager>().activeMainRedDotCnt;
        PlayerPrefs.SetInt("activeMainRedDotCnt", DataManager.Instance.activeMainRedDotCnt);

        if (Cha_3_Story.value != activeMainRedDotCnt)
        {
            Cha_3_Story.value = activeMainRedDotCnt;

            Main_StoryGauge();
        }
    }

    void SUA_GoodsGauge()
    {
        // gaugeSlider.value를 최대값으로 나누어 fillAmount 계산
        float fillValue = Cha_1_Goods.value / Cha_1_Goods.maxValue;

        // 게이지바의 fillAmount 설정
        Cha_1_Goods.fillRect.GetComponent<Image>().fillAmount = fillValue;

        //현재 값 표시
        if (valueText1_G != null)
        {
            valueText1_G.text = Cha_1_Goods.value.ToString() + " / 6";
        }
    }

    void BADA_GoodsGauge()
    {
        float fillValue = Cha_2_Goods.value / Cha_2_Goods.maxValue;

        // 게이지바의 fillAmount 설정
        Cha_2_Goods.fillRect.GetComponent<Image>().fillAmount = fillValue;

        //현재 값 표시
        if (valueText2_G != null)
        {
            valueText2_G.text = Cha_2_Goods.value.ToString() + " / 6";
        }
    }

    void CHORONG_GoodsGauge()
    {
        float fillValue = Cha_3_Story.value / Cha_3_Story.maxValue;

        // 게이지바의 fillAmount 설정
        Cha_3_Story.fillRect.GetComponent<Image>().fillAmount = fillValue;

        //현재 값 표시
        if (valueText3_G != null)
        {
            valueText3_G.text = Cha_3_Story.value.ToString() + " / 6";
        }
    }

    void SUA_StoryGauge()
    {
        float fillValue = Cha_1_Story.value / Cha_1_Story.maxValue;

        // 게이지바의 fillAmount 설정
        Cha_1_Story.fillRect.GetComponent<Image>().fillAmount = fillValue;

        //현재 값 표시
        if (valueText1_S != null)
        {
            valueText1_S.text = Cha_1_Story.value.ToString() + " / 3";
        }
    }

    void BADA_StoryGauge()
    {
        float fillValue = Cha_2_Story.value / Cha_2_Story.maxValue;

        // 게이지바의 fillAmount 설정
        Cha_2_Story.fillRect.GetComponent<Image>().fillAmount = fillValue;

        //현재 값 표시
        if (valueText2_S != null)
        {
            valueText2_S.text = Cha_2_Story.value.ToString() + " / 3";
        }
    }

    void CHORONG_StoryGauge()
    {
        float fillValue = Cha_3_Story.value / Cha_3_Story.maxValue;

        // 게이지바의 fillAmount 설정
        Cha_3_Story.fillRect.GetComponent<Image>().fillAmount = fillValue;

        //현재 값 표시
        if (valueText3_S != null)
        {
            valueText3_S.text = Cha_3_Story.value.ToString() + " / 3";
        }
    }

    void Main_StoryGauge()
    {
        float fillValue = MainStory.value / MainStory.maxValue;

        // 게이지바의 fillAmount 설정
        MainStory.fillRect.GetComponent<Image>().fillAmount = fillValue;

        //현재 값 표시
        if (valueTextM_S != null)
        {
            valueTextM_S.text = MainStory.value.ToString() + " / 3";
        }
    }
}
