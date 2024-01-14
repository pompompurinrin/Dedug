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
    public Text Goods2011Num;
    public Text Goods2012Num;
    public Text Goods2021Num;
    public Text Goods2022Num;
    public Text Goods2031Num;
    public Text Goods2032Num;
    public Text Goods3011Num;
    public Text Goods3012Num;
    public Text Goods3021Num;
    public Text Goods3022Num;
    public Text Goods3031Num;
    public Text Goods3032Num;

    public Image UnlockBG1011;
    public Image UnlockBG1012;
    public Image UnlockBG1021;
    public Image UnlockBG1022;
    public Image UnlockBG1031;
    public Image UnlockBG1032;
    public Image UnlockBG2011;
    public Image UnlockBG2012;
    public Image UnlockBG2021;
    public Image UnlockBG2022;
    public Image UnlockBG2031;
    public Image UnlockBG2032;
    public Image UnlockBG3011;
    public Image UnlockBG3012;
    public Image UnlockBG3021;
    public Image UnlockBG3022;
    public Image UnlockBG3031;
    public Image UnlockBG3032;

    public Image RedDot1011;
    public Image RedDot1012;
    public Image RedDot1021;
    public Image RedDot1022;
    public Image RedDot1031;
    public Image RedDot1032;
    public Image RedDot2011;
    public Image RedDot2012;
    public Image RedDot2021;
    public Image RedDot2022;
    public Image RedDot2031;
    public Image RedDot2032;
    public Image RedDot3011;
    public Image RedDot3012;
    public Image RedDot3021;
    public Image RedDot3022;
    public Image RedDot3031;
    public Image RedDot3032;

  /*  private bool isFirstCha_1_1011_BtnClick = true;
    private bool isFirstCha_1_1012_BtnClick = true;
    private bool isFirstCha_1_1021_BtnClick = true;
    private bool isFirstCha_1_1022_BtnClick = true;
    private bool isFirstCha_1_1031_BtnClick = true;
    private bool isFirstCha_1_1032_BtnClick = true;
    private bool isFirstCha_2_2011_BtnClick = true;
    private bool isFirstCha_2_2012_BtnClick = true;
    private bool isFirstCha_2_2021_BtnClick = true;
    private bool isFirstCha_2_2022_BtnClick = true;
    private bool isFirstCha_2_2031_BtnClick = true;
    private bool isFirstCha_2_2032_BtnClick = true;
    private bool isFirstCha_3_3011_BtnClick = true;
    private bool isFirstCha_3_3012_BtnClick = true;
    private bool isFirstCha_3_3021_BtnClick = true;
    private bool isFirstCha_3_3022_BtnClick = true;
    private bool isFirstCha_3_3031_BtnClick = true;
    private bool isFirstCha_3_3032_BtnClick = true;*/



    public Button testGoods1021;
    private void Awake()
    {
        DataManager.Instance.goods1011 = PlayerPrefs.GetInt("Goods1011");
        DataManager.Instance.goods1012 = PlayerPrefs.GetInt("Goods1012");
        DataManager.Instance.goods1021 = PlayerPrefs.GetInt("Goods1021");
        DataManager.Instance.goods1022 = PlayerPrefs.GetInt("Goods1022");
        DataManager.Instance.goods1031 = PlayerPrefs.GetInt("Goods1031");
        DataManager.Instance.goods1032 = PlayerPrefs.GetInt("Goods1032");
        DataManager.Instance.goods2011 = PlayerPrefs.GetInt("Goods2011");
        DataManager.Instance.goods2012 = PlayerPrefs.GetInt("Goods2012");
        DataManager.Instance.goods2021 = PlayerPrefs.GetInt("Goods2021");
        DataManager.Instance.goods2022 = PlayerPrefs.GetInt("Goods2022");
        DataManager.Instance.goods2031 = PlayerPrefs.GetInt("Goods2031");
        DataManager.Instance.goods2032 = PlayerPrefs.GetInt("Goods2032");
        DataManager.Instance.goods3011 = PlayerPrefs.GetInt("Goods3011");
        DataManager.Instance.goods3012 = PlayerPrefs.GetInt("Goods3012");
        DataManager.Instance.goods3021 = PlayerPrefs.GetInt("Goods3021");
        DataManager.Instance.goods3022 = PlayerPrefs.GetInt("Goods3022");
        DataManager.Instance.goods3031 = PlayerPrefs.GetInt("Goods3031");
        DataManager.Instance.goods3032 = PlayerPrefs.GetInt("Goods3032");
    }



    public void OnEnable()
    {
        //GoodsNum.text = 데이터매니저에서 개수 가져오기
        Goods1011Num.text = "X" + DataManager.Instance.goods1011.ToString();
        Goods1012Num.text = "X" + DataManager.Instance.goods1012.ToString();
        Goods1021Num.text = "X" + DataManager.Instance.goods1021.ToString();
        Goods1022Num.text = "X" + DataManager.Instance.goods1022.ToString();
        Goods1031Num.text = "X" + DataManager.Instance.goods1031.ToString();
        Goods1032Num.text = "X" + DataManager.Instance.goods1032.ToString();
        Goods2011Num.text = "X" + DataManager.Instance.goods2011.ToString();
        Goods2012Num.text = "X" + DataManager.Instance.goods2012.ToString();
        Goods2021Num.text = "X" + DataManager.Instance.goods2021.ToString();
        Goods2022Num.text = "X" + DataManager.Instance.goods2022.ToString();
        Goods2031Num.text = "X" + DataManager.Instance.goods2031.ToString();
        Goods2032Num.text = "X" + DataManager.Instance.goods2032.ToString();
        Goods3011Num.text = "X" + DataManager.Instance.goods3011.ToString();
        Goods3012Num.text = "X" + DataManager.Instance.goods3012.ToString();
        Goods3021Num.text = "X" + DataManager.Instance.goods3021.ToString();
        Goods3022Num.text = "X" + DataManager.Instance.goods3022.ToString();
        Goods3031Num.text = "X" + DataManager.Instance.goods3031.ToString();
        Goods3032Num.text = "X" + DataManager.Instance.goods3032.ToString();

        RedDot1011.gameObject.SetActive(false);
        RedDot1012.gameObject.SetActive(false);
        RedDot1021.gameObject.SetActive(false);
        RedDot1022.gameObject.SetActive(false);
        RedDot1031.gameObject.SetActive(false);
        RedDot1032.gameObject.SetActive(false);
        RedDot2032.gameObject.SetActive(false);
        RedDot2011.gameObject.SetActive(false);
        RedDot2012.gameObject.SetActive(false);
        RedDot2021.gameObject.SetActive(false);
        RedDot2022.gameObject.SetActive(false);
        RedDot2031.gameObject.SetActive(false);
        RedDot2032.gameObject.SetActive(false);
        RedDot3011.gameObject.SetActive(false);
        RedDot3012.gameObject.SetActive(false);
        RedDot3021.gameObject.SetActive(false);
        RedDot3022.gameObject.SetActive(false);
        RedDot3031.gameObject.SetActive(false);
        RedDot3032.gameObject.SetActive(false);

        if (DataManager.Instance.goods1011 == 0)
        {
            UnlockBG1011.gameObject.SetActive(true);
        }
        else
        {
            UnlockBG1011.gameObject.SetActive(false);
            RedDot1011.gameObject.gameObject.SetActive(true);
           // isFirstCha_1_1011_BtnClick = false;
        }

        if (DataManager.Instance.goods1012 == 0)
        {
            UnlockBG1012.gameObject.SetActive(true);
        }
        else
        {
            UnlockBG1012.gameObject.SetActive(false);
            RedDot1012.gameObject.gameObject.SetActive(true);
           // isFirstCha_1_1012_BtnClick = false;
        }

        if (DataManager.Instance.goods1021 == 0)
        {
            UnlockBG1021.gameObject.SetActive(true);
        }
        else
        {
            UnlockBG1021.gameObject.SetActive(false);
            RedDot1021.gameObject.gameObject.SetActive(true);
           // isFirstCha_1_1021_BtnClick = false;
        }

        if (DataManager.Instance.goods1022 == 0)
        {
            UnlockBG1022.gameObject.SetActive(true);
        }
        else
        {
            UnlockBG1022.gameObject.SetActive(false);
            RedDot1022.gameObject.gameObject.SetActive(true);
         //   isFirstCha_1_1022_BtnClick = false;
        }

        if (DataManager.Instance.goods1031 == 0)
        {
            UnlockBG1031.gameObject.SetActive(true);
        }
        else
        {
            UnlockBG1031.gameObject.SetActive(false);
            RedDot1031.gameObject.gameObject.SetActive(true);
          //  isFirstCha_1_1031_BtnClick = false;
        }

        if (DataManager.Instance.goods1032 == 0)
        {
            UnlockBG1032.gameObject.SetActive(true);
        }
        else
        {
            UnlockBG1032.gameObject.SetActive(false);
            RedDot1032.gameObject.gameObject.SetActive(true);
          // isFirstCha_1_1032_BtnClick = false;
        }

        if (DataManager.Instance.goods2011 == 0)
        {
            UnlockBG2011.gameObject.SetActive(true);
        }
        else
        {
            UnlockBG2011.gameObject.SetActive(false);
            RedDot2011.gameObject.gameObject.SetActive(true);
          // isFirstCha_2_2011_BtnClick = false;
        }

        if (DataManager.Instance.goods2012 == 0)
        {
            UnlockBG2012.gameObject.SetActive(true);
        }
        else
        {
            UnlockBG2012.gameObject.SetActive(false);
            RedDot2012.gameObject.gameObject.SetActive(true);
          //  isFirstCha_2_2012_BtnClick = false;
        }

        if (DataManager.Instance.goods2021 == 0)
        {
            UnlockBG2021.gameObject.SetActive(true);
        }
        else
        {
            UnlockBG2021.gameObject.SetActive(false);
            RedDot2021.gameObject.gameObject.SetActive(true);
          //  isFirstCha_2_2021_BtnClick = false;
        }

        if (DataManager.Instance.goods2022 == 0)
        {
            UnlockBG2022.gameObject.SetActive(true);
        }
        else
        {
            UnlockBG2022.gameObject.SetActive(false);
            RedDot2022.gameObject.gameObject.SetActive(true);
         //  isFirstCha_2_2022_BtnClick = false;
        }

        if (DataManager.Instance.goods2031 == 0)
        {
            UnlockBG2031.gameObject.SetActive(true);
        }
        else
        {
            UnlockBG2031.gameObject.SetActive(false);
            RedDot2031.gameObject.gameObject.SetActive(true);
           // isFirstCha_2_2031_BtnClick = false;
        }

        if (DataManager.Instance.goods2032 == 0)
        {
            UnlockBG2032.gameObject.SetActive(true);
        }
        else
        {
            UnlockBG2032.gameObject.SetActive(false);
            RedDot2032.gameObject.gameObject.SetActive(true);
           // isFirstCha_2_2032_BtnClick = false;
        }

        if (DataManager.Instance.goods3011 == 0)
        {
            UnlockBG3011.gameObject.SetActive(true);
        }
        else
        {
            UnlockBG3011.gameObject.SetActive(false);
            RedDot3011.gameObject.gameObject.SetActive(true);
           // isFirstCha_3_3011_BtnClick = false;
        }

        if (DataManager.Instance.goods3012 == 0)
        {
            UnlockBG3012.gameObject.SetActive(true);
        }
        else
        {
            UnlockBG3012.gameObject.SetActive(false);
            RedDot3012.gameObject.gameObject.SetActive(true);
         //   isFirstCha_3_3012_BtnClick = false;
        }

        if (DataManager.Instance.goods3021 == 0)
        {
            UnlockBG3021.gameObject.SetActive(true);
        }
        else
        {
            UnlockBG3021.gameObject.SetActive(false);
            RedDot3021.gameObject.gameObject.SetActive(true);
           // isFirstCha_3_3021_BtnClick = false;
        }

        if (DataManager.Instance.goods3022 == 0)
        {
            UnlockBG3022.gameObject.SetActive(true);
        }
        else
        {
            UnlockBG3022.gameObject.SetActive(false);
            RedDot3022.gameObject.gameObject.SetActive(true);
           // isFirstCha_3_3022_BtnClick = false;
        }

        if (DataManager.Instance.goods3031 == 0)
        {
            UnlockBG3031.gameObject.SetActive(true);
        }
        else
        {
            UnlockBG3031.gameObject.SetActive(false);
            RedDot3031.gameObject.gameObject.SetActive(true);
            //isFirstCha_3_3031_BtnClick = false;
        }

        if (DataManager.Instance.goods3032 == 0)
        {
            UnlockBG3032.gameObject.SetActive(true);
        }
        else
        {
            UnlockBG3032.gameObject.SetActive(false);
            RedDot3032.gameObject.gameObject.SetActive(true);
            //isFirstCha_3_3032_BtnClick = false;
        }
    }

   
}