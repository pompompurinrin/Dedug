using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI를 사용하므로 잊지 않고 추가

public class DropGenerator : MonoBehaviour
{
    public MainController2 mainController2;

    public GameObject MagicalGirlsPrefab;  // 생성할 떨어지는 굿즈 프리팹
    public GameObject ObstaclePrefab;
    public GameObject StudentPrefab;
    public Sprite[] MagicalGirlsSprites;
    public Sprite[] ObstacleSprites;
    public Sprite[] StudentSprites;
    int randomMagicalGirlsImage;
    int randomObstacleImage;
    int randomStudentImage;

    float span;  // 굿즈가 생성되는 주기
    float delta = 0;
    int randPrefab = 0;

    void Update()
    {
        if (mainController2.isGameRunnig == true) 
        { 
            this.delta += Time.deltaTime;
            if (this.delta > this.span)
            {
                this.delta = 0;
                randPrefab = Random.Range(0, 3);

                if ( randPrefab == 0 )
                {
                    span = 2f;
                    randomStudentImage = Random.Range(0, StudentSprites.Length);
                    GameObject go = Instantiate(StudentPrefab);
                    go.GetComponent<SpriteRenderer>().sprite = StudentSprites[randomStudentImage];
                    int px = Random.Range(-1, 1);
                    go.transform.position = new Vector3(px, 4, 1);
                }
                else if ( randPrefab == 1 )
                {
                    span = 1f;
                    randomObstacleImage = Random.Range(0, ObstacleSprites.Length);
                    GameObject go = Instantiate(ObstaclePrefab);
                    go.GetComponent<SpriteRenderer>().sprite = ObstacleSprites[randomObstacleImage];
                    int px = Random.Range(-1, 1);
                    go.transform.position = new Vector3(px, 4, 1);
                }

                else
                {
                    span = 10f;
                    randomMagicalGirlsImage = Random.Range(0, MagicalGirlsSprites.Length);
                    GameObject go = Instantiate(MagicalGirlsPrefab);
                    go.GetComponent<SpriteRenderer>().sprite = MagicalGirlsSprites[randomMagicalGirlsImage];
                    int px = Random.Range(-1, 1);
                    go.transform.position = new Vector3(px, 4, 1);
                }

            
            
            }
       
        }
       

        
        
    }
}
