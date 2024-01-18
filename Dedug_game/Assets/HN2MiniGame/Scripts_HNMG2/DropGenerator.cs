using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI를 사용하므로 잊지 않고 추가

public class DropGenerator : MonoBehaviour
{

    public GameObject dropObstaclePrefab;  // 생성할 떨어지는 굿즈 프리팹
    public GameObject dropStudentPrefab;
    public Sprite[] obstacleSprites;
    public Sprite[] studentSprites;
    int randomObstacleImage;
    int randomStudentImage;

    float span = 2f;  // 굿즈가 생성되는 주기
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
                randomStudentImage = Random.Range(0, studentSprites.Length);
                GameObject go = Instantiate(dropStudentPrefab);
                go.GetComponent<SpriteRenderer>().sprite = studentSprites[randomStudentImage];
                float px = Random.Range(-1.8f, 1.8f);
                go.transform.position = new Vector3(px, 5, 1);
            }
            else
            {
                randomObstacleImage = Random.Range(0, obstacleSprites.Length);
                GameObject go = Instantiate(dropStudentPrefab);
                go.GetComponent<SpriteRenderer>().sprite = obstacleSprites[randomObstacleImage];
                float px = Random.Range(-1.8f, 1.8f);
                go.transform.position = new Vector3(px, 5, 1);
            }
            
            
        }
       
    
       
        
    }
}
