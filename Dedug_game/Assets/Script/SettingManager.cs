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

        // �˾��� ��Ȱ��ȭ
        SettingPopupCanvas.SetActive(false);
    }
}
