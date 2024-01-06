using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI�� ����ϹǷ� ���� �ʰ� �߰�

public class RewardGoodsGenerator : MonoBehaviour
{

    public GameObject rewardGoodsPrefab; // ������ ������ ���� ������
    public GameObject rewardSlot1;
    public GameObject rewardSlot2;
    public GameObject rewardSlot3;

    public Sprite[] rewardGoodsSprites; // ���� �̹��� �迭


    public int score;


    int randomRewardGoodsImage;
    int randReward = 0;
    public Text totalGetScore;

    //void Start()
    //{
    //    // Minigame_01_Manager Ŭ������ �ν��Ͻ��� ã�ƿ�
    //    Minigame_01_Manager minigameManager = FindObjectOfType<Minigame_01_Manager>();

    //    if (minigameManager != null)
    //    {
    //        int score = Minigame_01_Manager.getScore; // getScore ������ float Ÿ���̹Ƿ� ������ ����ȯ�� ����
    //        totalGetScore.text = score.ToString();
    //    }
    //    else
    //    {
    //        Debug.LogError("Minigame_01_Manager �ν��Ͻ��� ã�� �� �����ϴ�.");
    //    }
    //}

    public void Reward()

    {

        // �������� ������ ������ ����
      

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
                //�ٸ� ������ ��� �����ϴ� �ڵ� �߰�
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
                //�ٸ� ������ ��� �����ϴ� �ڵ� �߰�
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
                //�ٸ� ������ ��� �����ϴ� �ڵ� �߰�
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