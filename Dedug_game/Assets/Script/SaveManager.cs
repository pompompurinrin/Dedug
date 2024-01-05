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
        // 게임 상태를 저장하는 코드 작성
        PlayerPrefs.SetInt("NowRank", DataManager.Instance.NowRank);
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.NowGold);
        

        // 기타 필요한 데이터 저장
        // PlayerPrefs.SetString("KeyName", "Value");

        PlayerPrefs.Save();
    }
    private void Start()
    {
        LoadGame();
    }

    private void LoadGame()
    {
        // 저장된 데이터가 있는지 확인
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            // 저장된 데이터를 불러오는 코드 작성
            int NowGold = PlayerPrefs.GetInt("NowGold");
            int NowRank = PlayerPrefs.GetInt("NowRank");
            //float playerPositionX = PlayerPrefs.GetFloat("PlayerPositionX");
            // float playerPositionY = PlayerPrefs.GetFloat("PlayerPositionY");

            // 기타 필요한 데이터 불러오기
            // string value = PlayerPrefs.GetString("KeyName");

            // 불러온 데이터를 게임에 적용
            DataManager.Instance.NowGold = NowGold;
            DataManager.Instance.NowRank = NowRank;
            // PlayerController.Instance.transform.position = new Vector2(playerPositionX, playerPositionY);
        }
    }
}

