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
    int randomobstacleImage;
    int randomstudentImage;

    float span = 2f;  // 굿즈가 생성되는 주기
    float delta = 0;
    int randPrefab = 0;

    public Transform parent;

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            randPrefab = Random.Range(0, 2);
           

            if (randPrefab == 0 )
            {
                randomstudentImage = Random.Range(0, studentSprites.Length);
                GameObject go = Instantiate(dropObstaclePrefab);
                go.GetComponent<SpriteRenderer>().sprite = studentSprites[randomstudentImage];
                float px = Random.Range(-1.8f, 1.8f);

                go.transform.position = new Vector3(px, 4, 1);             
                go.transform.SetParent(parent, false);
            }

            else
            {
                randomobstacleImage = Random.Range(0, obstacleSprites.Length);
                GameObject go = Instantiate(dropStudentPrefab);
                go.GetComponent<SpriteRenderer>().sprite = obstacleSprites[randomobstacleImage];
                float px = Random.Range(-1.8f, 1.8f);
                go.transform.position = new Vector3(px, 4, 1);
                go.transform.SetParent(parent, false);
            }
            
            
        }
       
    
       
        
    }
}
