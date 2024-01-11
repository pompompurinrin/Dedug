using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    int HJGoodsId;

    public Slider Goods1011num;
    public Slider Goods1012num;
    public Slider Goods1013num;
    public Slider Goods1014num;
    public Slider Goods1015num;
    public Slider Goods1016num;

    void Start()
    { 

        DataManager.Instance.HyeJingoodsNum[HJGoodsId]++;
        if (DataManager.Instance.HyeJingoodsNum[HJGoodsId] < 5)
        {
            //
        }

        
    }

    private void OnEnable()
    {
        Goods1011num.value = DataManager.Instance.HyeJingoodsNum[HJGoodsId];
        Goods1012num.value = DataManager.Instance.HyeJingoodsNum[HJGoodsId];
        Goods1013num.value = DataManager.Instance.HyeJingoodsNum[HJGoodsId];
        Goods1014num.value = DataManager.Instance.HyeJingoodsNum[HJGoodsId];
        Goods1015num.value = DataManager.Instance.HyeJingoodsNum[HJGoodsId];
        Goods1016num.value = DataManager.Instance.HyeJingoodsNum[HJGoodsId];
    }


}
