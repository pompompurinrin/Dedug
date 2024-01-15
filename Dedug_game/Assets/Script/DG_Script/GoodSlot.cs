using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GoodSlot : MonoBehaviour
{
    public int CSVNum;
    public int GoodId;
    public string GoodsName;
    public string GoodsDesc;
    public Image GoodsImg;


    public bool IsSlotOpen;

    public bool isRedDotVisible;
    public bool isInfoPanelVisible;

    public GameObject redDot;
    public GameObject infoPanel;


    public static List<int> ReadGoodIdsFromCSV(string csvFilePath)
    {
        List<int> goodIds = new List<int>();

        try
        {
            // CSV 파일 읽기
            using (StreamReader reader = new StreamReader(csvFilePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    foreach (string value in values)
                    {
                        // 굿즈 아이디를 정수로 변환하여 리스트에 추가
                        if (int.TryParse(value, out int goodId))
                        {
                            goodIds.Add(goodId);
                        }
                    }
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error reading CSV file: " + e.Message);
        }

        return goodIds;
    }


    public void AcquireGood(int goodId)
    {
        // 얻은 굿즈의 값을 저장
        GoodId = goodId;

        // 슬롯 열기
        OpenSlot();

        // 초기 상태에서는 레드닷 표시
        ShowRedDot();
    }

    private void OpenSlot()
    {
        IsSlotOpen = true;
    }

    private void ShowRedDot()
    {
        // 레드닷 보이기
        isRedDotVisible = true; 
       // RedDot3011.gameObject.SetActive(false);
    }

    private void HideRedDot()
    {
        // 레드닷 삭제 로직 구현
        if (redDot != null)
        {
            Destroy(redDot);
            isRedDotVisible = false;
        }
    }

    private void ShowInfoPanel()
    {
        // 굿즈 정보창 띄우기 로직 구현
       
        isInfoPanelVisible = true;
    }

    private void HideInfoPanel()
    {
        // 굿즈 정보창 닫기 로직 구현
        if (infoPanel != null)
        {
            Destroy(infoPanel);
            isInfoPanelVisible = false;
        }
    }

    public void OnSlotClick()
    {
        // 슬롯이 열려있을 때만 동작
        if (IsSlotOpen)
        {
            if (isRedDotVisible)
            {
                // 레드닷이 보이는 상태에서 슬롯 클릭 시
                HideRedDot();
                ShowInfoPanel();
            }
            else if (isInfoPanelVisible)
            {
                // 정보창이 보이는 상태에서 슬롯 클릭 시
                HideInfoPanel();
            }
        }
    }
}