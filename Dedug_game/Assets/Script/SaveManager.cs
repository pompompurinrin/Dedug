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
        // 게임 상태를 저장하는 코드 작성
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
        // 저장된 데이터가 있는지 확인
        if (PlayerPrefs.HasKey("NowGold"))
        {
            // 저장된 데이터를 불러오는 코드 작성
            //NowGold = PlayerPrefs.GetInt("nowGold");
            //NowRank = PlayerPrefs.GetInt("nowRank");
           // FeverNum = PlayerPrefs.GetInt("feverNum");
            //float playerPositionX = PlayerPrefs.GetFloat("PlayerPositionX");
            // float playerPositionY = PlayerPrefs.GetFloat("PlayerPositionY");

            // 기타 필요한 데이터 불러오기
            // string value = PlayerPrefs.GetString("KeyName");

            // 불러온 데이터를 게임에 적용
           // DataManager.Instance.nowGold = NowGold;
           // DataManager.Instance.nowRank = NowRank;
            // PlayerController.Instance.transform.position = new Vector2(playerPositionX, playerPositionY);
        }
    }
}

