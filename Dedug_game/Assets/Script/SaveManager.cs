using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
   private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveGame();
        }
    }

    public static void SaveGame()
    {
        // ���� ���¸� �����ϴ� �ڵ� �ۼ�
        PlayerPrefs.SetInt("NowRank", DataManager.Instance.nowRank);
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        PlayerPrefs.SetInt("Goods1011", DataManager.Instance.goods1011);
        PlayerPrefs.SetInt("Goods2011", DataManager.Instance.goods2011);
        PlayerPrefs.SetInt("Goods3011", DataManager.Instance.goods3011);
       
        PlayerPrefs.Save();
    }
    private void Start()
    {
        LoadGame();
    }

    public static void LoadGame()
    {
        // ����� �����Ͱ� �ִ��� Ȯ��
        if (PlayerPrefs.HasKey("NowGold"))
        {
            // ����� �����͸� �ҷ����� �ڵ� �ۼ�
            //NowGold = PlayerPrefs.GetInt("nowGold");
            //NowRank = PlayerPrefs.GetInt("nowRank");
           // FeverNum = PlayerPrefs.GetInt("feverNum");
            //float playerPositionX = PlayerPrefs.GetFloat("PlayerPositionX");
            // float playerPositionY = PlayerPrefs.GetFloat("PlayerPositionY");

            // ��Ÿ �ʿ��� ������ �ҷ�����
            // string value = PlayerPrefs.GetString("KeyName");

            // �ҷ��� �����͸� ���ӿ� ����
           // DataManager.Instance.nowGold = NowGold;
           // DataManager.Instance.nowRank = NowRank;
            // PlayerController.Instance.transform.position = new Vector2(playerPositionX, playerPositionY);
        }
    }
}

