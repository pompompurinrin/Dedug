using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GoodsBuyManager : MonoBehaviour
{

    public Image startPopup;
    public Image payMessagePopup;
    public Image gamePlayBG;
    public Image resultPopup;
    public Image mainBG;



    public void Start()
    {
        mainBG.gameObject.SetActive(true);
        startPopup.gameObject.SetActive(false);
        payMessagePopup.gameObject.SetActive(false);
        gamePlayBG.gameObject.SetActive(false);
        resultPopup.gameObject.SetActive(false);

        Debug.Log("미니게임첫화면");
    }



    public void GoodsBuyBtnClick()
    {

        startPopup.gameObject.SetActive(true);
        

    }


    public void GameStartClick()
    {
        payMessagePopup.gameObject.SetActive(true);
    }

    public void Pay()
    {
        
        startPopup.gameObject.SetActive(false);
        payMessagePopup.gameObject.SetActive(false);
        mainBG.gameObject.SetActive(false);
        gamePlayBG.gameObject.SetActive(true);
        gamePlayBG.GetComponent<Minigame_01_Manager>().Restart();
        Debug.Log("게임재시작");
    }

    public void NoPay()
    {

        payMessagePopup.gameObject.SetActive(false);
        Debug.Log("게임참여취소"); 

    }

}
