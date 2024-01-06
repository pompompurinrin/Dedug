using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI�� ����ϹǷ� ���� �ʰ� �߰�

public class DropGoodsGenerator : MonoBehaviour
{
  //  GameObject goodsCountBar;
    public GameObject goodsCountBar;
    public GameObject dropGoodsPrefab;  // ������ �������� ���� ������
    public GameObject dropGoodsPrefab01;
    public Sprite[] bombSprites;
    public Sprite[] goodsSprites;
    int randomBombImage;
    int randomGoodsImage;

    float span = 2f;  // ��� �����Ǵ� �ֱ�
    float delta = 0;
    int randPrefab = 0;

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            randPrefab = Random.Range(0, 2);

            if (randPrefab == 0 )
            {
                randomGoodsImage = Random.Range(0, goodsSprites.Length);
                GameObject go = Instantiate(dropGoodsPrefab);
                go.GetComponent<SpriteRenderer>().sprite = goodsSprites[randomGoodsImage];
                float px = Random.Range(-1.8f, 1.8f);
                go.transform.position = new Vector3(px, 7, 1);
            }
            else
            {
                randomBombImage = Random.Range(0, bombSprites.Length);
                GameObject go = Instantiate(dropGoodsPrefab01);
                go.GetComponent<SpriteRenderer>().sprite = bombSprites[randomBombImage];
                float px = Random.Range(-1.8f, 1.8f);
                go.transform.position = new Vector3(px, 7, 1);
            }
            
            
        }
       
    
       
        
    }
}
