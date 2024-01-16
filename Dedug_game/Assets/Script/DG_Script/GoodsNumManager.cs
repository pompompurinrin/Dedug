using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class GoodsNumManager : MonoBehaviour
{


    public Text Goods1011Num;
    public Text Goods1012Num;
    public Text Goods1021Num;
    public Text Goods1022Num;
    public Text Goods1031Num;
    public Text Goods1032Num;
    public Text Goods1041Num;
    public Text Goods1042Num;
    public Text Goods1051Num;
    public Text Goods1052Num;

    public Text Goods2011Num;
    public Text Goods2012Num;
    public Text Goods2021Num;
    public Text Goods2022Num;
    public Text Goods2031Num;
    public Text Goods2032Num;
    public Text Goods2041Num;
    public Text Goods2042Num;
    public Text Goods2051Num;
    public Text Goods2052Num;

    public Text Goods3011Num;
    public Text Goods3012Num;
    public Text Goods3021Num;
    public Text Goods3022Num;
    public Text Goods3031Num;
    public Text Goods3032Num;
    public Text Goods3041Num;
    public Text Goods3042Num;
    public Text Goods3051Num;
    public Text Goods3052Num;


    public Image UnlockBG1011;
    public Image UnlockBG1012;
    public Image UnlockBG1021;
    public Image UnlockBG1022;
    public Image UnlockBG1031;
    public Image UnlockBG1032;
    public Image UnlockBG1041;
    public Image UnlockBG1042;
    public Image UnlockBG1051;
    public Image UnlockBG1052;

    public Image UnlockBG2011;
    public Image UnlockBG2012;
    public Image UnlockBG2021;
    public Image UnlockBG2022;
    public Image UnlockBG2031;
    public Image UnlockBG2032;
    public Image UnlockBG2041;
    public Image UnlockBG2042;
    public Image UnlockBG2051;
    public Image UnlockBG2052;

    public Image UnlockBG3011;
    public Image UnlockBG3012;
    public Image UnlockBG3021;
    public Image UnlockBG3022;
    public Image UnlockBG3031;
    public Image UnlockBG3032;
    public Image UnlockBG3041;
    public Image UnlockBG3042;
    public Image UnlockBG3051;
    public Image UnlockBG3052;




    public Slider MainStorySlider;
    public Slider SuaStorySlider;
    public Slider BadaStorySlider;
    public Slider ChorongStorySlider;
    public Slider SuaGoodsSlider;
    public Slider BadaGoodsSlider;
    public Slider ChorongGoodsSlider;


    /*public Button Cha_1_1011_Btn;
    public Button Cha_1_1012_Btn;
    public Button Cha_1_1021_Btn;
    public Button Cha_1_1022_Btn;
    public Button Cha_1_1031_Btn;
    public Button Cha_1_1032_Btn;*/


    public Button testGoods1021;
    private void Awake()
    {
        DataManager.Instance.goods1011 = PlayerPrefs.GetInt("Goods1011");
        DataManager.Instance.goods1012 = PlayerPrefs.GetInt("Goods1012");
        DataManager.Instance.goods1021 = PlayerPrefs.GetInt("Goods1021");
        DataManager.Instance.goods1022 = PlayerPrefs.GetInt("Goods1022");
        DataManager.Instance.goods1031 = PlayerPrefs.GetInt("Goods1031");
        DataManager.Instance.goods1032 = PlayerPrefs.GetInt("Goods1032");
        DataManager.Instance.goods1041 = PlayerPrefs.GetInt("Goods1041");
        DataManager.Instance.goods1042 = PlayerPrefs.GetInt("Goods1042");
        DataManager.Instance.goods1051 = PlayerPrefs.GetInt("Goods1051");
        DataManager.Instance.goods1052 = PlayerPrefs.GetInt("Goods1052");

        DataManager.Instance.goods2011 = PlayerPrefs.GetInt("Goods2011");
        DataManager.Instance.goods2012 = PlayerPrefs.GetInt("Goods2012");
        DataManager.Instance.goods2021 = PlayerPrefs.GetInt("Goods2021");
        DataManager.Instance.goods2022 = PlayerPrefs.GetInt("Goods2022");
        DataManager.Instance.goods2031 = PlayerPrefs.GetInt("Goods2031");
        DataManager.Instance.goods2032 = PlayerPrefs.GetInt("Goods2032");
        DataManager.Instance.goods2041 = PlayerPrefs.GetInt("Goods2041");
        DataManager.Instance.goods2042 = PlayerPrefs.GetInt("Goods2042");
        DataManager.Instance.goods2051 = PlayerPrefs.GetInt("Goods2051");
        DataManager.Instance.goods2052 = PlayerPrefs.GetInt("Goods2052");

        DataManager.Instance.goods3011 = PlayerPrefs.GetInt("Goods3011");
        DataManager.Instance.goods3012 = PlayerPrefs.GetInt("Goods3012");
        DataManager.Instance.goods3021 = PlayerPrefs.GetInt("Goods3021");
        DataManager.Instance.goods3022 = PlayerPrefs.GetInt("Goods3022");
        DataManager.Instance.goods3031 = PlayerPrefs.GetInt("Goods3031");
        DataManager.Instance.goods3032 = PlayerPrefs.GetInt("Goods3032");
        DataManager.Instance.goods3041 = PlayerPrefs.GetInt("Goods3041");
        DataManager.Instance.goods3042 = PlayerPrefs.GetInt("Goods3042");
        DataManager.Instance.goods3051 = PlayerPrefs.GetInt("Goods3051");
        DataManager.Instance.goods3052 = PlayerPrefs.GetInt("Goods3052");
    }

    public int MainStoryGauge;
    public int MainGoodsGauge;
    public int SuaStoryGauge;
    public int BadaStoryGauge;
    public int ChorongStoryGauge;
    public int SuaGoodsGauge;
    public int BadaGoodsGauge;
    public int ChorongGoodsGauge;


    private bool goods1011Applied = false;
    private bool goods1012Applied = false;
    private bool goods1021Applied = false;
    private bool goods1022Applied = false;
    private bool goods1031Applied = false;
    private bool goods1032Applied = false;
    private bool goods1041Applied = false;
    private bool goods1042Applied = false;
    private bool goods1051Applied = false;
    private bool goods1052Applied = false;
    private bool goods2011Applied = false;
    private bool goods2012Applied = false;
    private bool goods2021Applied = false;
    private bool goods2022Applied = false;
    private bool goods2031Applied = false;
    private bool goods2032Applied = false;
    private bool goods2041Applied = false;
    private bool goods2042Applied = false;
    private bool goods2051Applied = false;
    private bool goods2052Applied = false;
    private bool goods3011Applied = false;
    private bool goods3012Applied = false;
    private bool goods3021Applied = false;
    private bool goods3022Applied = false;
    private bool goods3031Applied = false;
    private bool goods3032Applied = false;
    private bool goods3041Applied = false;
    private bool goods3042Applied = false;
    private bool goods3051Applied = false;
    private bool goods3052Applied = false;

    public Image UnlockChr1_2;
    public Image UnlockChr1_3;
    public Image UnlockChr2_2;
    public Image UnlockChr2_3;
    public Image UnlockChr3_2;
    public Image UnlockChr3_3;
    public Image UnlockMain_2;
    public Image UnlockMain_3;
    // 이 메서드를 호출하여 MainStoryGauge를 업데이트합니다.
    public void UpdateMainStoryGauge()
    {
        // Goods1011이 0이 아니고 goods1011Applied가 false인 경우에만 1을 더함
        if (DataManager.Instance.goods1011 > 0 && !goods1011Applied)
        {
            MainStoryGauge++;
            goods1011Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods1012 > 0 && !goods1012Applied)
        {
            MainStoryGauge++;
            goods1012Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods1021 > 0 && !goods1021Applied)
        {
            MainStoryGauge++;
            goods1021Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods1022 > 0 && !goods1022Applied)
        {
            MainStoryGauge++;
            goods1022Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods1031 > 0 && !goods1031Applied)
        {
            MainStoryGauge++;
            goods1031Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods1032 > 0 && !goods1032Applied)
        {
            MainStoryGauge++;
            goods1032Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods1041 > 0 && !goods1041Applied)
        {
            MainStoryGauge++;
            goods1041Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods1042 > 0 && !goods1042Applied)
        {
            MainStoryGauge++;
            goods1042Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods1051 > 0 && !goods1051Applied)
        {
            MainStoryGauge++;
            goods1051Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods1052 > 0 && !goods1052Applied)
        {
            MainStoryGauge++;
            goods1052Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods3011 > 0 && !goods3011Applied)
        {
            MainStoryGauge++;
            goods3011Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods3012 > 0 && !goods3012Applied)
        {
            MainStoryGauge++;
            goods3012Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods3021 > 0 && !goods3021Applied)
        {
            MainStoryGauge++;
            goods3021Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods3022 > 0 && !goods3022Applied)
        {
            MainStoryGauge++;
            goods3022Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods3031 > 0 && !goods3031Applied)
        {
            MainStoryGauge++;
            goods3031Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods3032 > 0 && !goods3032Applied)
        {
            MainStoryGauge++;
            goods3032Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods3041 > 0 && !goods3041Applied)
        {
            MainStoryGauge++;
            goods3041Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods3042 > 0 && !goods3042Applied)
        {
            MainStoryGauge++;
            goods3042Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods3051 > 0 && !goods3051Applied)
        {
            MainStoryGauge++;
            goods3051Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods3052 > 0 && !goods3052Applied)
        {
            MainStoryGauge++;
            goods3052Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods2011 > 0 && !goods2011Applied)
        {
            MainStoryGauge++;
            goods2011Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods2012 > 0 && !goods2012Applied)
        {
            MainStoryGauge++;
            goods2012Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods2021 > 0 && !goods2021Applied)
        {
            MainStoryGauge++;
            goods2021Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods2022 > 0 && !goods2022Applied)
        {
            MainStoryGauge++;
            goods2022Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods2031 > 0 && !goods2031Applied)
        {
            MainStoryGauge++;
            goods2031Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods2032 > 0 && !goods2032Applied)
        {
            MainStoryGauge++;
            goods2032Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods2041 > 0 && !goods2041Applied)
        {
            MainStoryGauge++;
            goods2041Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods2042 > 0 && !goods2042Applied)
        {
            MainStoryGauge++;
            goods2042Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods2051 > 0 && !goods2051Applied)
        {
            MainStoryGauge++;
            goods2051Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }
        if (DataManager.Instance.goods2052 > 0 && !goods2052Applied)
        {
            MainStoryGauge++;
            goods2052Applied = true; // 1이 더해진 상태로 플래그 업데이트
        }

        if(MainStoryGauge == 30)
        {
            MainStorySlider.value = 3;
            UnlockMain_2.gameObject.SetActive(false);
            UnlockMain_3.gameObject.SetActive(false);
        }
        else if(MainStoryGauge >= 15)
        {
            MainStorySlider.value = 2;
            UnlockMain_2.gameObject.SetActive(false);
        }
        else
        {
            MainStorySlider.value = 1;
        }

    }
    public void UpdateSuaStoryGauge()
    {
        if (DataManager.Instance.goods1011 > 0 )
        {
            UnlockBG1011.gameObject.SetActive(true);

            if (goods1011Applied == false)
            {
                SuaGoodsGauge++;
                goods1011Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG1011.gameObject.SetActive(false);
        }

        if (DataManager.Instance.goods1012 > 0 && !goods1012Applied)
        {
            UnlockBG1011.gameObject.SetActive(true);
            if (goods1012Applied == false)
            {
                SuaGoodsGauge++;
                goods1012Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG1012.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods1021 > 0 && !goods1021Applied)
        {
            UnlockBG1021.gameObject.SetActive(true);
            if (goods1021Applied == false)
            {
                SuaGoodsGauge++;
                goods1021Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG1021.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods1022 > 0 && !goods1022Applied)
        {
            UnlockBG1022.gameObject.SetActive(true);
            if (goods1022Applied == false)
            {
                SuaGoodsGauge++;
                goods1022Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG1021.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods1031 > 0 && !goods1031Applied)
        {
            UnlockBG1031.gameObject.SetActive(true);
            if (goods1031Applied == false)
            {
                SuaGoodsGauge++;
                goods1031Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG1031.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods1032 > 0 && !goods1032Applied)
        {
            UnlockBG1032.gameObject.SetActive(true);
            if (goods1032Applied == false)
            {
                SuaGoodsGauge++;
                goods1032Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG1032.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods1041 > 0 && !goods1041Applied)
        {
            UnlockBG1041.gameObject.SetActive(true);
            if (goods1041Applied == false)
            {
                SuaGoodsGauge++;
                goods1041Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG1041.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods1042 > 0 && !goods1042Applied)
        {
            UnlockBG1042.gameObject.SetActive(true);
            if (goods1042Applied == false)
            {
                SuaGoodsGauge++;
                goods1042Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG1042.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods1051 > 0 && !goods1051Applied)
        {
            UnlockBG1051.gameObject.SetActive(true);
            if (goods1051Applied == false)
            {
                SuaGoodsGauge++;
                goods1051Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG1051.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods1052 > 0 && !goods1052Applied)
        {
            UnlockBG1011.gameObject.SetActive(true);
            if (goods1052Applied == false)
            {
                SuaGoodsGauge++;
                goods1052Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG1052.gameObject.SetActive(false);
        }

        SuaGoodsSlider.value = SuaGoodsGauge;

        if (SuaGoodsGauge == 10)
        {
            SuaStorySlider.value = 3;
            UnlockChr1_2.gameObject.SetActive(false);
            UnlockChr1_3.gameObject.SetActive(false);
        }
        else if (SuaGoodsGauge >= 5)
        {
            SuaStorySlider.value = 2;
            UnlockChr1_2.gameObject.SetActive(false);
        }
        else
        {
            SuaStorySlider.value = 1;
        }
    }

    public void UpdateBadaStoryGauge()
    {
        if (DataManager.Instance.goods2011 > 0 && !goods2011Applied)
        {
            UnlockBG2011.gameObject.SetActive(true);

            if (goods2011Applied == false)
            {
                BadaGoodsGauge++;
                goods2011Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG2011.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods2012 > 0 && !goods2012Applied)
        {
            UnlockBG2012.gameObject.SetActive(true);

            if (goods2012Applied == false)
            {
                BadaGoodsGauge++;
                goods2012Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG2012.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods2021 > 0 && !goods2021Applied)
        {
            UnlockBG2021.gameObject.SetActive(true);

            if (goods2021Applied == false)
            {
                BadaGoodsGauge++;
                goods2021Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG2021.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods2022 > 0 && !goods2022Applied)
        {
            UnlockBG2022.gameObject.SetActive(true);

            if (goods2022Applied == false)
            {
                BadaGoodsGauge++;
                goods2022Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG2022.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods2031 > 0 && !goods2031Applied)
        {
            UnlockBG2031.gameObject.SetActive(true);

            if (goods2031Applied == false)
            {
                BadaGoodsGauge++;
                goods2031Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG2031.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods2032 > 0 && !goods2032Applied)
        {
            UnlockBG2032.gameObject.SetActive(true);

            if (goods2032Applied == false)
            {
                BadaGoodsGauge++;
                goods2032Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG2032.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods2041 > 0 && !goods2041Applied)
        {
            UnlockBG2041.gameObject.SetActive(true);

            if (goods2041Applied == false)
            {
                BadaGoodsGauge++;
                goods2041Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG2041.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods2042 > 0 && !goods2042Applied)
        {
            UnlockBG2042.gameObject.SetActive(true);

            if (goods2042Applied == false)
            {
                BadaGoodsGauge++;
                goods2042Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG2042.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods2051 > 0 && !goods2051Applied)
        {
            UnlockBG2051.gameObject.SetActive(true);

            if (goods2051Applied == false)
            {
                BadaGoodsGauge++;
                goods2051Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG2051.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods2052 > 0 && !goods2052Applied)
        {
            UnlockBG2052.gameObject.SetActive(true);

            if (goods2052Applied == false)
            {
                BadaGoodsGauge++;
                goods2052Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG2052.gameObject.SetActive(false);
        }

        BadaGoodsSlider.value = BadaGoodsGauge;

        if (BadaGoodsGauge == 10)
        {
            BadaStorySlider.value = 3;
            UnlockChr2_2.gameObject.SetActive(false);
            UnlockChr2_3.gameObject.SetActive(false);
        }
        else if (BadaGoodsGauge >= 5)
        {
            BadaStorySlider.value = 2;
            UnlockChr2_2.gameObject.SetActive(false);
        }
        else
        {
            BadaStorySlider.value = 1;
        }


    }

    public void UpdateChorongStoryGauge()
    {
        if (DataManager.Instance.goods3011 > 0 && !goods3011Applied)
        {
            UnlockBG3011.gameObject.SetActive(true);

            if (goods3011Applied == false)
            {
                ChorongGoodsGauge++;
                goods3011Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG3011.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods3012 > 0 && !goods3012Applied)
        {
            UnlockBG3012.gameObject.SetActive(true);

            if (goods3012Applied == false)
            {
                ChorongGoodsGauge++;
                goods3012Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG3012.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods3021 > 0 && !goods3021Applied)
        {
            UnlockBG3021.gameObject.SetActive(true);

            if (goods3021Applied == false)
            {
                ChorongGoodsGauge++;
                goods3021Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG3021.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods3022 > 0 && !goods3022Applied)
        {
            UnlockBG3022.gameObject.SetActive(true);

            if (goods3022Applied == false)
            {
                ChorongGoodsGauge++;
                goods3022Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG3022.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods3031 > 0 && !goods3031Applied)
        {
            UnlockBG3031.gameObject.SetActive(true);

            if (goods3031Applied == false)
            {
                ChorongGoodsGauge++;
                goods3031Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG3031.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods3032 > 0 && !goods3032Applied)
        {
            UnlockBG3032.gameObject.SetActive(true);

            if (goods3032Applied == false)
            {
                ChorongGoodsGauge++;
                goods3032Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG3032.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods3041 > 0 && !goods3041Applied)
        {
            UnlockBG3041.gameObject.SetActive(true);

            if (goods3041Applied == false)
            {
                ChorongGoodsGauge++;
                goods3041Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG3041.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods3042 > 0 && !goods3042Applied)
        {
            UnlockBG3042.gameObject.SetActive(true);

            if (goods3042Applied == false)
            {
                ChorongGoodsGauge++;
                goods3042Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG3042.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods3051 > 0 && !goods3051Applied)
        {
            UnlockBG3051.gameObject.SetActive(true);

            if (goods3051Applied == false)
            {
                ChorongGoodsGauge++;
                goods3051Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG3051.gameObject.SetActive(false);
        }
        if (DataManager.Instance.goods3052 > 0 && !goods3052Applied)
        {
            UnlockBG3052.gameObject.SetActive(true);

            if (goods3052Applied == false)
            {
                ChorongGoodsGauge++;
                goods3052Applied = true; // 1이 더해진 상태로 플래그 업데이트
            }
        }
        else
        {
            UnlockBG3052.gameObject.SetActive(false);
        }

        ChorongGoodsSlider.value = ChorongGoodsGauge;

        if(ChorongGoodsGauge == 10)
        {
            ChorongStorySlider.value = 3;
            UnlockChr3_2.gameObject.SetActive(false);
            UnlockChr3_3.gameObject.SetActive(false);
        }
        else if(ChorongGoodsGauge >= 5 )
        {
            ChorongStorySlider.value = 2;
            UnlockChr3_2.gameObject.SetActive(false);
        }
        else
        {
            ChorongStorySlider.value = 1;
        }

    }


        public void Start()
    {

        UpdateMainStoryGauge();
        UpdateSuaStoryGauge();
        UpdateBadaStoryGauge();
        UpdateChorongStoryGauge();
        //GoodsNum.text = 데이터매니저에서 개수 가져오기
        Goods1011Num.text = "X" + DataManager.Instance.goods1011.ToString();
        Goods1012Num.text = "X" + DataManager.Instance.goods1012.ToString();
        Goods1021Num.text = "X" + DataManager.Instance.goods1021.ToString();
        Goods1022Num.text = "X" + DataManager.Instance.goods1022.ToString();
        Goods1031Num.text = "X" + DataManager.Instance.goods1031.ToString();
        Goods1032Num.text = "X" + DataManager.Instance.goods1032.ToString();
        Goods1041Num.text = "X" + DataManager.Instance.goods1041.ToString();
        Goods1042Num.text = "X" + DataManager.Instance.goods1042.ToString();
        Goods1051Num.text = "X" + DataManager.Instance.goods1051.ToString();
        Goods1052Num.text = "X" + DataManager.Instance.goods1052.ToString();

        Goods2011Num.text = "X" + DataManager.Instance.goods2011.ToString();
        Goods2012Num.text = "X" + DataManager.Instance.goods2012.ToString();
        Goods2021Num.text = "X" + DataManager.Instance.goods2021.ToString();
        Goods2022Num.text = "X" + DataManager.Instance.goods2022.ToString();
        Goods2031Num.text = "X" + DataManager.Instance.goods2031.ToString();
        Goods2032Num.text = "X" + DataManager.Instance.goods2032.ToString();
        Goods2041Num.text = "X" + DataManager.Instance.goods2041.ToString();
        Goods2042Num.text = "X" + DataManager.Instance.goods2042.ToString();
        Goods2051Num.text = "X" + DataManager.Instance.goods2051.ToString();
        Goods2052Num.text = "X" + DataManager.Instance.goods2052.ToString();

        Goods3011Num.text = "X" + DataManager.Instance.goods3011.ToString();
        Goods3012Num.text = "X" + DataManager.Instance.goods3012.ToString();
        Goods3021Num.text = "X" + DataManager.Instance.goods3021.ToString();
        Goods3022Num.text = "X" + DataManager.Instance.goods3022.ToString();
        Goods3031Num.text = "X" + DataManager.Instance.goods3031.ToString();
        Goods3032Num.text = "X" + DataManager.Instance.goods3032.ToString();
        Goods3041Num.text = "X" + DataManager.Instance.goods3041.ToString();
        Goods3042Num.text = "X" + DataManager.Instance.goods3042.ToString();
        Goods3051Num.text = "X" + DataManager.Instance.goods3051.ToString();
        Goods3052Num.text = "X" + DataManager.Instance.goods3052.ToString();


    }
}