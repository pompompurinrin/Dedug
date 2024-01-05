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

    private void SaveGame()
    {
        // ���� ���¸� �����ϴ� �ڵ� �ۼ�
        PlayerPrefs.SetInt("NowRank", DataManager.Instance.NowRank);
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.NowGold);
        

        // ��Ÿ �ʿ��� ������ ����
        // PlayerPrefs.SetString("KeyName", "Value");

        PlayerPrefs.Save();
    }
    private void Start()
    {
        LoadGame();
    }

    private void LoadGame()
    {
        // ����� �����Ͱ� �ִ��� Ȯ��
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            // ����� �����͸� �ҷ����� �ڵ� �ۼ�
            int NowGold = PlayerPrefs.GetInt("NowGold");
            int NowRank = PlayerPrefs.GetInt("NowRank");
            //float playerPositionX = PlayerPrefs.GetFloat("PlayerPositionX");
            // float playerPositionY = PlayerPrefs.GetFloat("PlayerPositionY");

            // ��Ÿ �ʿ��� ������ �ҷ�����
            // string value = PlayerPrefs.GetString("KeyName");

            // �ҷ��� �����͸� ���ӿ� ����
            DataManager.Instance.NowGold = NowGold;
            DataManager.Instance.NowRank = NowRank;
            // PlayerController.Instance.transform.position = new Vector2(playerPositionX, playerPositionY);
        }
    }
}

