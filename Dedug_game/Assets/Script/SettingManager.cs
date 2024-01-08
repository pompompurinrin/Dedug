using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public Button OffSetting;
    GameObject SettingPopupCanvas;

    public void OnButtonClick_OffSettingPopup()
    {
        if(SettingPopupCanvas == null)
        {
            SettingPopupCanvas = FindObjectOfType<SettingManager>().gameObject;
        }

        // 팝업을 비활성화
        SettingPopupCanvas.SetActive(false);
    }
}
