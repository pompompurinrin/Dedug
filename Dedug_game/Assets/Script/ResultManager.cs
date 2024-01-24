using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;

public class ResultManager : MonoBehaviour
{

    /*
    *이거 결과창인데 우선 씬에 있는 canvas를 미니게임 canvas 안에 복붙
    *스크립트도 기존 미니게임 스크립트에 복붙
    *자신이 게임 종료하는 함수 안에 Score(); 함수 실행

    
    내용 변경해야 하는 거 한번 더 잘 바꿨는지 체크해봐요(아래 내용)
    *53번째 줄에 StartGame();
        본인 게임 시작하는 함수명 변경

    *85번째 줄에  private void StartGame()
        게임 시작에 필요한 내용 넣어주기
        아니면 마음대로 넣고 StartGame(); 대신 해당 함수로 바꿔주면 됨

    *141번째 줄에 EndGame()의 어떤 컴포넌트에 배정할거임? 이거 전체 옮겨야 함
      ㄴ> 자신이 게임 종료하는 함수 안, 결과창 오브젝트 활성화 바로 밑에 줄으로
      ㄴ> 글로 설명하기 어려워서 이해 어려울 시 윤정에게 물어볼 것

    *146번째 줄에 ResultCanvas
        결과창 활성화 하는 캔버스 이름으로 변경 필요

    *319번째 줄에 void Score()
        본인 게임 점수 컷 넣어주기
    */

    // UI 요소들
    public Image ResultBG;
    public Image ScoreBG;
    public Text Scoretxt;
    public Text Rewardtxt;
    public Button Restart;
    public Button HomeBtn;
    public GameObject RestartPopup;
    public GameObject GoldlackPopup;
    public Text RestartGoldText;

    // 각종 효과 및 결과를 나타내는 텍스트들
    public Text UserScoretxt; //얘는 게임에서 저장 된 유저 점수를 불러올 것임!! 
    public string imageFileName; // 얘는 CSV에서 Goods열의 숫자를 가져와서 이미지로 뽑아낼거임!!

    // 게임 오브젝트 및 캔버스 관련 변수
    public Image Reward1;
    public Image Reward2;
    public Image Reward3;

    int score;
    int test;

    public List<int> gatchIdList;
    public List<int> gatchPerList;
    public List<int> rewards; // 줄 애들

    // 리워드 리스트 선언을 여기서 시킴
    public List<Image> RewardsImage = new List<Image>();

    public List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    public List<Sprite> goodsSprites = new List<Sprite>();

    //

    private void Start() //게임 시작
    {
        // 게임 시작 시 호출되는 함수
        //StartGame();으로 게임 내용 넣어준거로 바꾸면 됨

        //PercentageTable_1에서 배열을 사용할게
        data_Dialog = CSVReader.Read("PercentageTable");

        // 이건 왜인지 모르겠는데 넣으라고 해서 일단 넣음
        RewardsImage.Add(Reward1);
        RewardsImage.Add(Reward2);
        RewardsImage.Add(Reward3);

        Setting();
    }

    /*
    private void StartGame() 으로 게임 시작에 필요한 내용 넣어줘야 함

    뭐.. 대기 시간 3초 활성화라던지
    게임 총 시간, 점수 초기화, 게임 UI 활성화, 관련 메소드 호출 등등\

    */

    public void Awake() //굿즈 몇 개 가졌는지 확인, 현재 랭크 확인
    {
        DataManager.Instance.goods1011 = PlayerPrefs.GetInt("Goods1011");
        DataManager.Instance.goods1012 = PlayerPrefs.GetInt("Goods1012");
        DataManager.Instance.goods1021 = PlayerPrefs.GetInt("Goods1021");
        DataManager.Instance.goods1022 = PlayerPrefs.GetInt("Goods1022");
        DataManager.Instance.goods1031 = PlayerPrefs.GetInt("Goods1031");
        DataManager.Instance.goods1032 = PlayerPrefs.GetInt("Goods1032");
        DataManager.Instance.goods1041 = PlayerPrefs.GetInt("Goods1041");
        DataManager.Instance.goods1042 = PlayerPrefs.GetInt("Goods1042");
        DataManager.Instance.goods1051 = PlayerPrefs.GetInt("Goods1051");
        DataManager.Instance.goods1052 = PlayerPrefs.GetInt("Goods1052");

        DataManager.Instance.goods2011 = PlayerPrefs.GetInt("Goods2011");
        DataManager.Instance.goods2012 = PlayerPrefs.GetInt("Goods2012");
        DataManager.Instance.goods2021 = PlayerPrefs.GetInt("Goods2021");
        DataManager.Instance.goods2022 = PlayerPrefs.GetInt("Goods2022");
        DataManager.Instance.goods2031 = PlayerPrefs.GetInt("Goods2031");
        DataManager.Instance.goods2032 = PlayerPrefs.GetInt("Goods2032");
        DataManager.Instance.goods2041 = PlayerPrefs.GetInt("Goods2041");
        DataManager.Instance.goods2042 = PlayerPrefs.GetInt("Goods2042");
        DataManager.Instance.goods2051 = PlayerPrefs.GetInt("Goods2051");
        DataManager.Instance.goods2052 = PlayerPrefs.GetInt("Goods2052");

        DataManager.Instance.goods3011 = PlayerPrefs.GetInt("Goods3011");
        DataManager.Instance.goods3012 = PlayerPrefs.GetInt("Goods3012");
        DataManager.Instance.goods3021 = PlayerPrefs.GetInt("Goods3021");
        DataManager.Instance.goods3022 = PlayerPrefs.GetInt("Goods3022");
        DataManager.Instance.goods3031 = PlayerPrefs.GetInt("Goods3031");
        DataManager.Instance.goods3032 = PlayerPrefs.GetInt("Goods3032");
        DataManager.Instance.goods3041 = PlayerPrefs.GetInt("Goods3041");
        DataManager.Instance.goods3042 = PlayerPrefs.GetInt("Goods3042");
        DataManager.Instance.goods3051 = PlayerPrefs.GetInt("Goods3051");
        DataManager.Instance.goods3052 = PlayerPrefs.GetInt("Goods3052");

        DataManager.Instance.goods4051 = PlayerPrefs.GetInt("Goods4051");
        DataManager.Instance.goods4052 = PlayerPrefs.GetInt("Goods4052");
        DataManager.Instance.goods4053 = PlayerPrefs.GetInt("Goods4053");
        DataManager.Instance.goods4054 = PlayerPrefs.GetInt("Goods4054");
        DataManager.Instance.goods4055 = PlayerPrefs.GetInt("Goods4055");
        DataManager.Instance.goods4056 = PlayerPrefs.GetInt("Goods4056");
        DataManager.Instance.goods4057 = PlayerPrefs.GetInt("Goods4057");
        DataManager.Instance.goods4058 = PlayerPrefs.GetInt("Goods4058");
        DataManager.Instance.goods4059 = PlayerPrefs.GetInt("Goods4059");
        DataManager.Instance.goods4060 = PlayerPrefs.GetInt("Goods4060");

        DataManager.Instance.nowRank = PlayerPrefs.GetInt("NowRank");
    }

    private void EndGame() //결과창 기준으로는 Start임
    {
        //게임 종료시 활성화

        Score(); //점수 가져올게
        //ResultCanvas.SetActive(true);//게임 끝났을 때 결과창 활성화 시킬게

        //어떤 컴포넌트에 배정할거임?
        ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        Restart = GameObject.Find("Restart").GetComponent<Button>();
        HomeBtn = GameObject.Find("Home").GetComponent<Button>();
    }



    void Setting() // 씬 들어가자마자 한번 하면 됨
    {
        gatchPerList = new List<int>();
        gatchIdList = new List<int>();
        goodsSprites = new List<Sprite>();
        int rank = DataManager.Instance.nowRank;
        
        //CSV에서 랭크에 맞는 굿즈를 검사하고 굿즈의 ID값에 Goods를 더한 이름과 같은 리소스를 불러올게

        if (rank == 0)
        {
            for (int i = 0; i < data_Dialog.Count; i++)
            {
                if ((int)data_Dialog[i]["Nowrank"] == rank)
                {
                    gatchPerList.Add((int)data_Dialog[i]["Percentage"]);
                    gatchIdList.Add((int)data_Dialog[i]["Goods"]);
                    string imageString = "Goods" + data_Dialog[i]["Goods"].ToString();
                    goodsSprites.Add(Resources.Load<Sprite>(imageString));

                    Debug.Log("rank" + rank);
                }
            }
        }

        else if (rank == 1)
        {
            for (int i = 1; i < data_Dialog.Count; i++)
            {
                if ((int)data_Dialog[i]["Nowrank"] == rank)
                {
                    gatchPerList.Add((int)data_Dialog[i]["Percentage"]);
                    gatchIdList.Add((int)data_Dialog[i]["Goods"]);
                    string imageString = "Goods" + data_Dialog[i]["Goods"].ToString();
                    goodsSprites.Add(Resources.Load<Sprite>(imageString));

                    Debug.Log("rank" + rank);
                }
            }
        }

        else if (rank == 2)
        {
            for (int i = 2; i < data_Dialog.Count; i++)
            {
                if ((int)data_Dialog[i]["Nowrank"] == rank)
                {
                    gatchPerList.Add((int)data_Dialog[i]["Percentage"]);
                    gatchIdList.Add((int)data_Dialog[i]["Goods"]);
                    string imageString = "Goods" + data_Dialog[i]["Goods"].ToString();
                    goodsSprites.Add(Resources.Load<Sprite>(imageString));

                    Debug.Log("rank" + rank);
                }
            }
        }

        else if (rank == 3)
        {
            for (int i = 3; i < data_Dialog.Count; i++)
            {
                if ((int)data_Dialog[i]["Nowrank"] == rank)
                {
                    gatchPerList.Add((int)data_Dialog[i]["Percentage"]);
                    gatchIdList.Add((int)data_Dialog[i]["Goods"]);
                    string imageString = "Goods" + data_Dialog[i]["Goods"].ToString();
                    goodsSprites.Add(Resources.Load<Sprite>(imageString));

                    Debug.Log("rank" + rank);
                }
            }
        }

        else if (rank == 4)
        {
            for (int i = 4; i < data_Dialog.Count; i++)
            {
                if ((int)data_Dialog[i]["Nowrank"] == rank)
                {
                    gatchPerList.Add((int)data_Dialog[i]["Percentage"]);
                    gatchIdList.Add((int)data_Dialog[i]["Goods"]);
                    string imageString = "Goods" + data_Dialog[i]["Goods"].ToString();
                    goodsSprites.Add(Resources.Load<Sprite>(imageString));

                    Debug.Log("rank" + rank);
                }
            }
        }
    }

    public void GetGoods(int _count) // 실제 가챠를 하는 부분
    { 

        if (data_Dialog.Count == 0)
        {
            data_Dialog = CSVReader.Read("PercentageTable");
        }

        for (int i = 0; i < RewardsImage.Count; i++)
        {
            RewardsImage[i].gameObject.SetActive(false); // 싹 다 꺼
        }

        int randMaxValue = 0; // 모든 가중치 값을 더하기 위한 변수. 휴먼 에러 방지 용
        for (int i = 0; i < gatchPerList.Count; i++)
        {
            randMaxValue += gatchPerList[i]; // 가중치 싹 다 더하기. 999, 1001 방지 -> 이거 안하면 픽뚫났을 때 굿즈 못받음
        }

        for (int i = 0; i < _count; i++) // 몇번
        {
            GetItems(randMaxValue); // 뽑기

            RewardsImage[i].sprite = rewardGoods[i];
            RewardsImage[i].gameObject.SetActive(true); // 바뀌었으니 켜라
        }

        Save();
    }

    void GetItems(int maxValue)
    {
        int randValue = UnityEngine.Random.Range(0, maxValue);
        Debug.Log("Random Value: " + randValue);

        int checkUpper = 0;
        int checkLower = 0;

        for (int i = 0; i < gatchIdList.Count; i++)
        {
            checkUpper += gatchPerList[i];
            Debug.Log("Check Upper: " + checkUpper);

            if (i == 0)
            {
                if (randValue < checkUpper)
                {
                    rewards.Add(gatchIdList[i]);
                    rewardGoods.Add(goodsSprites[i]);
                    Debug.Log("Reward Added: " + gatchIdList[i]);
                    break;
                }
            }
            else
            {
                if (randValue >= checkLower && randValue < checkUpper)
                {
                    rewards.Add(gatchIdList[i]);
                    rewardGoods.Add(goodsSprites[i]);
                    Debug.Log("Reward Added: " + gatchIdList[i]);
                    break;
                }
            }

            checkLower = checkUpper;
        }
    }


    public List<Sprite> rewardGoods = new List<Sprite>();

    public int _count = 0;// 몇개 줄 지 설정하는 변수
    void Score() // 점수에 따라 가챠 수량 설정
    {
        Scoretxt.text = score.ToString();

        //굿즈 지급
        if (score >= 10) // 각자의 게임 점수를 대입하면 됨
        {
            _count = 3; // 3번 돌릴게 = 굿즈 3개 줄게 = 젤 높은 점수꺼

        }
        else if (score < 10 && score >= 5)
        {
            _count = 2;
        }
        else
        {
            _count = 1;
        }

        GetGoods(_count);
    }


    public void Save()
    {
        for (int i = 0; i < rewards.Count; i++)
        {
            int rewardId = rewards[i];

            // 보상을 ID에 따라 DataManager.Instance에 매핑
            switch (rewardId)
            {
                case 1011:
                    DataManager.Instance.goods1011++;
                    PlayerPrefs.SetInt("Goods1011", DataManager.Instance.goods1011);
                    break;
                case 1012:
                    DataManager.Instance.goods1012++;
                    PlayerPrefs.SetInt("Goods1012", DataManager.Instance.goods1012);
                    break;
                case 1021:
                    DataManager.Instance.goods1021++;
                    PlayerPrefs.SetInt("Goods1021", DataManager.Instance.goods1021);
                    break;
                case 1022:
                    DataManager.Instance.goods1022++;
                    PlayerPrefs.SetInt("Goods1022", DataManager.Instance.goods1022);
                    break;
                case 1031:
                    DataManager.Instance.goods1031++;
                    PlayerPrefs.SetInt("Goods1031", DataManager.Instance.goods1031);
                    break;
                case 1032:
                    DataManager.Instance.goods1032++;
                    PlayerPrefs.SetInt("Goods1032", DataManager.Instance.goods1032);
                    break;
                case 1041:
                    DataManager.Instance.goods1041++;
                    PlayerPrefs.SetInt("Goods1041", DataManager.Instance.goods1041);
                    break;
                case 1042:
                    DataManager.Instance.goods1042++;
                    PlayerPrefs.SetInt("Goods1042", DataManager.Instance.goods1042);
                    break;
                case 1051:
                    DataManager.Instance.goods1051++;
                    PlayerPrefs.SetInt("Goods1051", DataManager.Instance.goods1051);
                    break;
                case 1052:
                    DataManager.Instance.goods1052++;
                    PlayerPrefs.SetInt("Goods1052", DataManager.Instance.goods1052);
                    break;
                case 2011:
                    DataManager.Instance.goods2011++;
                    PlayerPrefs.SetInt("Goods2011", DataManager.Instance.goods2011);
                    break;
                case 2012:
                    DataManager.Instance.goods2012++;
                    PlayerPrefs.SetInt("Goods2012", DataManager.Instance.goods2012);
                    break;
                case 2021:
                    DataManager.Instance.goods2021++;
                    PlayerPrefs.SetInt("Goods2021", DataManager.Instance.goods2021);
                    break;
                case 2022:
                    DataManager.Instance.goods2022++;
                    PlayerPrefs.SetInt("Goods2022", DataManager.Instance.goods2022);
                    break;
                case 2031:
                    DataManager.Instance.goods2031++;
                    PlayerPrefs.SetInt("Goods2031", DataManager.Instance.goods2031);
                    break;
                case 2032:
                    DataManager.Instance.goods2032++;
                    PlayerPrefs.SetInt("Goods2032", DataManager.Instance.goods2032);
                    break;
                case 2041:
                    DataManager.Instance.goods2041++;
                    PlayerPrefs.SetInt("Goods2041", DataManager.Instance.goods2041);
                    break;
                case 2042:
                    DataManager.Instance.goods2042++;
                    PlayerPrefs.SetInt("Goods2042", DataManager.Instance.goods2042);
                    break;
                case 2051:
                    DataManager.Instance.goods2051++;
                    PlayerPrefs.SetInt("Goods2051", DataManager.Instance.goods2051);
                    break;
                case 2052:
                    DataManager.Instance.goods2052++;
                    PlayerPrefs.SetInt("Goods2052", DataManager.Instance.goods2052);
                    break;
                case 3011:
                    DataManager.Instance.goods3011++;
                    PlayerPrefs.SetInt("Goods3011", DataManager.Instance.goods3011);
                    break;
                case 3012:
                    DataManager.Instance.goods3012++;
                    PlayerPrefs.SetInt("Goods3012", DataManager.Instance.goods3012);
                    break;
                case 3021:
                    DataManager.Instance.goods3021++;
                    PlayerPrefs.SetInt("Goods3021", DataManager.Instance.goods3021);
                    break;
                case 3022:
                    DataManager.Instance.goods3022++;
                    PlayerPrefs.SetInt("Goods3022", DataManager.Instance.goods3022);
                    break;
                case 3031:
                    DataManager.Instance.goods3031++;
                    PlayerPrefs.SetInt("Goods3031", DataManager.Instance.goods3031);
                    break;
                case 3032:
                    DataManager.Instance.goods3032++;
                    PlayerPrefs.SetInt("Goods3032", DataManager.Instance.goods3032);
                    break;
                case 3041:
                    DataManager.Instance.goods3041++;
                    PlayerPrefs.SetInt("Goods3041", DataManager.Instance.goods3041);
                    break;
                case 3042:
                    DataManager.Instance.goods3042++;
                    PlayerPrefs.SetInt("Goods3042", DataManager.Instance.goods3042);
                    break;
                case 3051:
                    DataManager.Instance.goods3051++;
                    PlayerPrefs.SetInt("Goods3051", DataManager.Instance.goods3051);
                    break;
                case 3052:
                    DataManager.Instance.goods3052++;
                    PlayerPrefs.SetInt("Goods3052", DataManager.Instance.goods3052);
                    break;

                case 4051:
                    DataManager.Instance.goods4051++;
                    PlayerPrefs.SetInt("Goods4051", DataManager.Instance.goods4051);
                    break;
                case 4052:
                    DataManager.Instance.goods4052++;
                    PlayerPrefs.SetInt("Goods4052", DataManager.Instance.goods4052);
                    break;
                case 4053:
                    DataManager.Instance.goods4053++;
                    PlayerPrefs.SetInt("Goods4053", DataManager.Instance.goods4053);
                    break;
                case 4054:
                    DataManager.Instance.goods4054++;
                    PlayerPrefs.SetInt("Goods4054", DataManager.Instance.goods4054);
                    break;
                case 4055:
                    DataManager.Instance.goods4055++;
                    PlayerPrefs.SetInt("Goods4055", DataManager.Instance.goods4055);
                    break;
                case 4056:
                    DataManager.Instance.goods4056++;
                    PlayerPrefs.SetInt("Goods4056", DataManager.Instance.goods4056);
                    break;
                case 4057:
                    DataManager.Instance.goods4057++;
                    PlayerPrefs.SetInt("Goods4057", DataManager.Instance.goods4057);
                    break;
                case 4058:
                    DataManager.Instance.goods4058++;
                    PlayerPrefs.SetInt("Goods4058", DataManager.Instance.goods4058);
                    break;
                case 4059:
                    DataManager.Instance.goods4059++;
                    PlayerPrefs.SetInt("Goods4059", DataManager.Instance.goods4059);
                    break;
                case 4060:
                    DataManager.Instance.goods4060++;
                    PlayerPrefs.SetInt("Goods4060", DataManager.Instance.goods4060);
                    break;

                default:
                    break;

                // 다른 보상 ID에 대한 케이스 추가...
            }

        }
        
        // PlayerPrefs에 현재 값 저장
        PlayerPrefs.Save();

        //Debug.Log("미니게임 결과:" +  DataManager.Instance.goods1011); //특정 굿즈 오류 체크용
        
    }

    public void Click_OnRestartPopup() //리스타트 팝업 활성화
    {
        GoldText();
        RestartPopup.gameObject.SetActive(true);
    }

    public void Click_OffRestartPopup() //리스타트 팝업 비활성화
    {
        RestartPopup.gameObject.SetActive(false);
    }

    public void Click_OffGoldlack() //골드 부족 팝업 비활성화
    {
        GoldlackPopup.gameObject.SetActive(false);
    }

    public void RestartClick() //진수: 리스타트 클릭 시 현재 랭크에 맞추어 그에 해당하는 골드를 소모하는 스크립트
    {

        if (DataManager.Instance.nowRank == 0)
        {
            if (DataManager.Instance.nowGold >= 100)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 100;

                Save();
                Start();
            }
            else if (DataManager.Instance.nowGold < 100)
            {

                GoldlackPopup.SetActive(true);
            }
        }

        else if (DataManager.Instance.nowRank == 1)
        {
            if (DataManager.Instance.nowGold >= 500)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 500;

                Save();
                Start(); ;
            }
            else if (DataManager.Instance.nowGold < 500)
            {
                GoldlackPopup.SetActive(true);
            }
        }

        else if (DataManager.Instance.nowRank == 2)
        {
            if (DataManager.Instance.nowGold >= 1000)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 1000;

                Save();
                Start();
            }
            else if (DataManager.Instance.nowGold < 1000)
            {
                GoldlackPopup.SetActive(true);
            }
        }


        else if (DataManager.Instance.nowRank == 3)
        {
            if (DataManager.Instance.nowGold >= 1500)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 1500;

                Save();
                Start();
            }
            else if (DataManager.Instance.nowGold < 1500)
            {
                GoldlackPopup.SetActive(true);
            }
        }

        else if (DataManager.Instance.nowRank == 4)
        {
            if (DataManager.Instance.nowGold >= 3000)
            {
                DataManager.Instance.nowGold = DataManager.Instance.nowGold - 3000;

                Save();
                Start();
            }
            else if (DataManager.Instance.nowGold < 3000)
            {
                GoldlackPopup.SetActive(true);
            }
        }

    }

    public void GoldText() //다시 시작 팝업에서 필요한 골드량을 나타내는 스크립트
    {
        if (DataManager.Instance.nowRank == 0)
        {
            RestartGoldText.text = "다시 시도할 경우 100골드가 소모됩니다.";
        }

        else if (DataManager.Instance.nowRank == 1)
        {
            RestartGoldText.text = "다시 시도할 경우 500골드가 소모됩니다.";
        }

        else if (DataManager.Instance.nowRank == 2)
        {
            RestartGoldText.text = "다시 시도할 경우 1000골드가 소모됩니다.";
        }


        else if (DataManager.Instance.nowRank == 3)
        {
            RestartGoldText.text = "다시 시도할 경우 1500골드가 소모됩니다.";
        }

        else if (DataManager.Instance.nowRank == 4)
        {
            RestartGoldText.text = "다시 시도할 경우 3000골드가 소모됩니다.";
        }
    }
   
    /*public void RestartClick() 
    {
        SceneManager.LoadScene("DG_Scene"); //일단은 도감으로 연결해뒀던거라 다시 시작할 거면 이 부분 바꿔주어야 함
    }*/

    public void HomeClick()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void RequestClick()
    {
        SceneManager.LoadScene("RequestScene");
    }

}