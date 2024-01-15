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
            // CSV ���� �б�
            using (StreamReader reader = new StreamReader(csvFilePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    foreach (string value in values)
                    {
                        // ���� ���̵� ������ ��ȯ�Ͽ� ����Ʈ�� �߰�
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
        // ���� ������ ���� ����
        GoodId = goodId;

        // ���� ����
        OpenSlot();

        // �ʱ� ���¿����� ����� ǥ��
        ShowRedDot();
    }

    private void OpenSlot()
    {
        IsSlotOpen = true;
    }

    private void ShowRedDot()
    {
        // ����� ���̱�
        isRedDotVisible = true; 
       // RedDot3011.gameObject.SetActive(false);
    }

    private void HideRedDot()
    {
        // ����� ���� ���� ����
        if (redDot != null)
        {
            Destroy(redDot);
            isRedDotVisible = false;
        }
    }

    private void ShowInfoPanel()
    {
        // ���� ����â ���� ���� ����
       
        isInfoPanelVisible = true;
    }

    private void HideInfoPanel()
    {
        // ���� ����â �ݱ� ���� ����
        if (infoPanel != null)
        {
            Destroy(infoPanel);
            isInfoPanelVisible = false;
        }
    }

    public void OnSlotClick()
    {
        // ������ �������� ���� ����
        if (IsSlotOpen)
        {
            if (isRedDotVisible)
            {
                // ������� ���̴� ���¿��� ���� Ŭ�� ��
                HideRedDot();
                ShowInfoPanel();
            }
            else if (isInfoPanelVisible)
            {
                // ����â�� ���̴� ���¿��� ���� Ŭ�� ��
                HideInfoPanel();
            }
        }
    }
}