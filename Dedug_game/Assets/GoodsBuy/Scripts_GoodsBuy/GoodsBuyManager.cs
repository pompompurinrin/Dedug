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
    public Image MainBG;



    // Start is called before the first frame update
    public void Start()
    {
        MainBG.gameObject.SetActive(true);
        startPopup.gameObject.SetActive(false);
        payMessagePopup.gameObject.SetActive(false);
        gamePlayBG.gameObject.SetActive(false);
        resultPopup.gameObject.SetActive(false);
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
        MainBG.gameObject.SetActive(false);
        gamePlayBG.gameObject.SetActive(true);
        gamePlayBG.GetComponent<Minigame_01_Manager>().Restart();
    }

    public void NoPay()
    {

        payMessagePopup.gameObject.SetActive(false);

    }

}
