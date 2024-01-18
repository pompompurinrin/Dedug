using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI를 사용하므로 잊지 않고 추가

public class RewardGoodsGenerator : MonoBehaviour
{

    public GameObject rewardGoodsPrefab; // 생성할 리워드 굿즈 프리팹
    public GameObject rewardSlot1;
    public GameObject rewardSlot2;
    public GameObject rewardSlot3;

    public Sprite[] rewardGoodsSprites; // 굿즈 이미지 배열


    public int score;


    int randomRewardGoodsImage;
    int randReward = 0;
    public Text totalGetScore;

    //void Start()
    //{
    //    // Minigame_01_Manager 클래스의 인스턴스를 찾아옴
    //    Minigame_01_Manager minigameManager = FindObjectOfType<Minigame_01_Manager>();

    //    if (minigameManager != null)
    //    {
    //        int score = Minigame_01_Manager.getScore; // getScore 변수가 float 타입이므로 적절한 형변환을 수행
    //        totalGetScore.text = score.ToString();
    //    }
    //    else
    //    {
    //        Debug.LogError("Minigame_01_Manager 인스턴스를 찾을 수 없습니다.");
    //    }
    //}

    public void Reward()

    {

        // 랜덤으로 굿즈의 개수를 결정
      

        if (score == 0)
        {
            rewardSlot1.SetActive(true);
            rewardSlot2.SetActive(false);
            rewardSlot3.SetActive(false);

            randReward = Random.Range(0, 3);

            if (randReward == 0)
            {
                randomRewardGoodsImage = Random.Range(0, rewardGoodsSprites.Length);
                GameObject go = Instantiate(rewardGoodsPrefab);
                go.GetComponent<SpriteRenderer>().sprite = rewardGoodsSprites[randomRewardGoodsImage];
            }

            else if (randReward == 1)
            {
                //다른 종류의 굿즈를 생성하는 코드 추가
                GameObject go01 = Instantiate(rewardGoodsPrefab);
                go01.GetComponent<SpriteRenderer>().sprite = rewardGoodsSprites[randomRewardGoodsImage];

            }
            else
            {
                GameObject go02 = Instantiate(rewardGoodsPrefab);
                go02.GetComponent<SpriteRenderer>().sprite = rewardGoodsSprites[randomRewardGoodsImage];

            }
        }

        else if (score == 1)
        {
            rewardSlot1.SetActive(true);
            rewardSlot2.SetActive(true);
            rewardSlot3.SetActive(false);

            randReward = Random.Range(0, 3);

            if (randReward == 0)
            {
                randomRewardGoodsImage = Random.Range(0, rewardGoodsSprites.Length);
                GameObject go = Instantiate(rewardGoodsPrefab);
                go.GetComponent<SpriteRenderer>().sprite = rewardGoodsSprites[randomRewardGoodsImage];
            }

            else if (randReward == 1)
            {
                //다른 종류의 굿즈를 생성하는 코드 추가
                GameObject go01 = Instantiate(rewardGoodsPrefab);
                go01.GetComponent<SpriteRenderer>().sprite = rewardGoodsSprites[randomRewardGoodsImage];

            }
            else
            {
                GameObject go02 = Instantiate(rewardGoodsPrefab);
                go02.GetComponent<SpriteRenderer>().sprite = rewardGoodsSprites[randomRewardGoodsImage];

            }
        }

        else
        {
            rewardSlot1.SetActive(true);
            rewardSlot2.SetActive(true);
            rewardSlot3.SetActive(true);

            randReward = Random.Range(0, 3);

            if (randReward == 0)
            {
                randomRewardGoodsImage = Random.Range(0, rewardGoodsSprites.Length);
                GameObject go = Instantiate(rewardGoodsPrefab);
                go.GetComponent<SpriteRenderer>().sprite = rewardGoodsSprites[randomRewardGoodsImage];
            }

            else if (randReward == 1)
            {
                //다른 종류의 굿즈를 생성하는 코드 추가
                GameObject go01 = Instantiate(rewardGoodsPrefab);
                go01.GetComponent<SpriteRenderer>().sprite = rewardGoodsSprites[randomRewardGoodsImage];

            }
            else
            {
                GameObject go02 = Instantiate(rewardGoodsPrefab);
                go02.GetComponent<SpriteRenderer>().sprite = rewardGoodsSprites[randomRewardGoodsImage];

            }
        }
    }
}