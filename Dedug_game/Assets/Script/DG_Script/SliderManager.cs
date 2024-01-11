using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
   

    public Slider Goods1011num;
    public Slider Goods1012num;
    public Slider Goods1013num;
    public Slider Goods1014num;
    public Slider Goods1015num;
    public Slider Goods1016num;

    private void Awake()
    {
        DataManager.Instance.goods1011 = PlayerPrefs.GetInt("goods1011");
        DataManager.Instance.goods1012 = PlayerPrefs.GetInt("goods1012");
    }

    void Start()
    {
        Goods1011num.value = DataManager.Instance.goods1011;
        Goods1012num.value = DataManager.Instance.goods1012;
        // ... 다른 슬라이더도 설정
    }

    /*private void Update()
    {
        // DataManager의 값이 변경되었는지 확인합니다.
        if (DataManager.Instance.goods1011 != Goods1011num.value)
        {
            // 값이 변경된 경우 슬라이더를 업데이트합니다.
            Goods1011num.value = DataManager.Instance.goods1011;
        }
    }*/
}

