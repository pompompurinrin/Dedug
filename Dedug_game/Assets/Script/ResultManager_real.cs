using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using UnityEngine.EventSystems;
using System.Collections;
using Unity.VisualScripting;
using Unity.Mathematics;

public class ResultManager_real : MonoBehaviour
{

    // UI 요소들
    public Image ResultBG;
    public Image ScoreBG;
    public Text Scoretxt;
    public Text Rewardtxt;
    public Button Restart;
    public Button HomeBtn;

    // 각종 효과 및 결과를 나타내는 텍스트들
    public Text UserScoretxt; //얘는 게임에서 저장 된 유저 점수를 불러올 것임!! 
   
    // 게임 오브젝트 및 캔버스 관련 변수
    public Image Reward1;
    public Image Reward2;
    public Image Reward3;

    //숫자값 가져올거
    int Result1;
    int Result2;
    int UserScore;


    // 리워드 리스트 선언을 여기서 시킴
    public List<Image> Rewards = new List<Image>();

    List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    void Start()
    {
        //PercentageTable_1에서 배열을 사용할게
        data_Dialog = CSVReader.Read("PercentageTable_real");

        //어떤 컴포넌트에 배정할거임?
        ResultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        ScoreBG = GameObject.Find("ScoreBG").GetComponent<Image>();
        Restart = GameObject.Find("Restart").GetComponent<Button>();
        HomeBtn = GameObject.Find("Home").GetComponent<Button>();
        //UserScore = GameObject.Find("UserScoretxt").GetComponent<Text>();  //왜안되는거지ㅠㅠ

        // 이건 왜인지 모르겠는데 넣으라고 해서 일단 넣음
        Rewards.Add(Reward1);
        Rewards.Add(Reward2);
        Rewards.Add(Reward3);


        // 테스트용 시작 값이랑 넣은거
        Setting();

        // UserScore 동적으로 설정 (예시: 랜덤 값 설정)
        UserScore = UnityEngine.Random.Range(1, 10);
        Result2 = 3;
        Result1 = 1;
        Score();
    }

    List<int> gatchIdList;
    List<int> gatchPerList;
    List<int> rewards; // 줄 애들
    

    void Setting() // 씬 들어가자마자 한번 하면 됨
    {
        gatchPerList = new List<int>();
        gatchIdList = new List<int>();
        int rank = DataManager.Instance.nowRank;

        for (int i = 0; i < data_Dialog.Count; i++)
        {
            if ((int)data_Dialog[i]["Nowrank"] == rank)
            {
                gatchPerList.Add((int)data_Dialog[i]["Percentage"]);
                gatchIdList.Add((int)data_Dialog[i]["Percentage"]);
            }
        }
        
    }

    public void GetGoods(int count) // 실제 가챠를 하는 부분. count에는 뽑고 싶은 수량 넣기
    {


        // 여기 한 줄 수정함 리스트 초기화
        rewards = new List<int>(); // rewards 리스트 초기화

        for (int i = 0; i < Rewards.Count; i++)
        {
            Rewards[i].gameObject.SetActive(false); // 싹 다 꺼
        }

        int randMaxValue = 0; // 모든 가중치 값을 더하기 위한 변수. 휴먼 에러 방지 용
        for(int i = 0; i < gatchPerList.Count; i++)
        {
            randMaxValue += gatchPerList[i]; // 가중치 싹 다 더하기. 999, 1001 방지
        }

        for(int i = 0; i < count; i++) // 몇번
        {
            GetItems(randMaxValue); // 뽑기
            Rewards[i].sprite = Resources.Load<Sprite>("Goods" + rewards[i]);
            Rewards[i].gameObject.SetActive(true); // 바뀌었으니 켜라
        }
    }

    void GetItems(int maxValue) // 뽑기. 랜덤 최대값 받기
    {
        int randValue = UnityEngine.Random.Range(0, maxValue); // 뽑을 애의 해당 가중치량
        int checkRand = 0; // 가중치 체크용
        for(int i = 0; i < gatchIdList.Count; i++)
        {
            checkRand += gatchPerList[i];
            if (randValue < checkRand)
            {
                rewards.Add(gatchIdList[i]);
            }
        }
    }

    //public void Rank1RandomSetting() // 확률과 굿즈 id로 이미지를 출력할게 -> 오답노트 아카이브용...
    //{
    //    rankid_1 = UnityEngine.Random.Range(0, 18); 
    //    string imageFileName = data_Dialog[rankid_1]["goods"].ToString();
    //    percentage = (int)data_Dialog[rankid_1]["percentage"];

    //    Reward1.sprite = Resources.Load<Sprite>("goods" + imageFileName);
    //    Reward2.sprite = Resources.Load<Sprite>("goods" + imageFileName);
    //    Reward3.sprite = Resources.Load<Sprite>("goods" + imageFileName);

    //     //GoodsNum.text = 데이터매니저에서 개수 가져오기
    //    Reward1.gameObject.SetActive(true);
    //    Reward2.gameObject.SetActive(true);
    //    Reward3.gameObject.SetActive(true);
    //}

    //public void Rank2RandomSetting() 
    //{
    //    rankid_2 = UnityEngine.Random.Range(18, 36);
    //    string imageFileName = data_Dialog[rankid_2]["goods"].ToString();
    //    percentage = (int)data_Dialog[rankid_2]["percentage"];

    //    Reward1.sprite = Resources.Load<Sprite>("goods" + imageFileName);
    //    Reward2.sprite = Resources.Load<Sprite>("goods" + imageFileName);
    //    Reward3.sprite = Resources.Load<Sprite>("goods" + imageFileName);

    //    //GoodsNum.text = 데이터매니저에서 개수 가져오기
    //    Reward1.gameObject.SetActive(true);
    //    Reward2.gameObject.SetActive(true);
    //    Reward3.gameObject.SetActive(true);
    //}

    //public void Rank3RandomSetting()
    //{ 
    //    rankid_3 = UnityEngine.Random.Range(36, 54);
    //    string imageFileName = data_Dialog[rankid_3]["goods"].ToString();
    //    percentage = (int)data_Dialog[rankid_3]["Percentage"];

    //    Reward1.sprite = Resources.Load<Sprite>("goods" + imageFileName);
    //    Reward2.sprite = Resources.Load<Sprite>("goods" + imageFileName);
    //    Reward3.sprite = Resources.Load<Sprite>("goods" + imageFileName);

    //    //GoodsNum.text = 데이터매니저에서 개수 가져오기
    //    Reward1.gameObject.SetActive(true);
    //    Reward2.gameObject.SetActive(true);
    //    Reward3.gameObject.SetActive(true);
    //}

    void Score() // 이름 바꿔. => 점수에 따라 가챠 수량 설정 하는 부분이라서
    {
        int _count = 0; // 몇개 줄 지 설정하는 변수

        //굿즈 지급
        if (UserScore >= Result2) // 바꿔
        {
            _count = 3;

        }
        else if(UserScore < Result2 && UserScore >= Result1)
        {
            _count = 2;
        }
        else
        {
            _count = 1;
        }

        GetGoods(_count);

        Save();
    }


    public void Save()
    {
        // PlayerPrefs에 현재 값 저장
        PlayerPrefs.SetInt("Goods1011", DataManager.Instance.goods1011);
        PlayerPrefs.SetInt("Goods1012", DataManager.Instance.goods1012);
        PlayerPrefs.SetInt("Goods1021", DataManager.Instance.goods1021);
        PlayerPrefs.SetInt("Goods1022", DataManager.Instance.goods1022);
        PlayerPrefs.SetInt("Goods1031", DataManager.Instance.goods1031);
        PlayerPrefs.SetInt("Goods1032", DataManager.Instance.goods1032);

        PlayerPrefs.SetInt("Goods2011", DataManager.Instance.goods2011);
        PlayerPrefs.SetInt("Goods2012", DataManager.Instance.goods2012);
        PlayerPrefs.SetInt("Goods2021", DataManager.Instance.goods2021);
        PlayerPrefs.SetInt("Goods2022", DataManager.Instance.goods2022);
        PlayerPrefs.SetInt("Goods2031", DataManager.Instance.goods2031);
        PlayerPrefs.SetInt("Goods2032", DataManager.Instance.goods2032);

        PlayerPrefs.SetInt("Goods3011", DataManager.Instance.goods3011);
        PlayerPrefs.SetInt("Goods3012", DataManager.Instance.goods3012);
        PlayerPrefs.SetInt("Goods3021", DataManager.Instance.goods3021);
        PlayerPrefs.SetInt("Goods3022", DataManager.Instance.goods3022);
        PlayerPrefs.SetInt("Goods3031", DataManager.Instance.goods3031);
        PlayerPrefs.SetInt("Goods3032", DataManager.Instance.goods3032);
        PlayerPrefs.Save();

    }

    public void RestartClick()
    {
        SceneManager.LoadScene("GoodsBuyScene");
    }

    public void HomeClick()
    {
        SceneManager.LoadScene("HomeScene");
    }

}
