using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI를 사용하므로 잊지 않고 추가

public class DropGenerator : MonoBehaviour
{
    [SerializeField] public GameObject heal_fx;    // 힐 효과
    [SerializeField] public GameObject hit_fx;     // 피격 효과

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

                if (randPrefab == 0)
                {
                    span = 2f;
                    randomStudentImage = Random.Range(0, StudentSprites.Length);
                    GameObject go = Instantiate(StudentPrefab);
                    go.GetComponent<SpriteRenderer>().sprite = StudentSprites[randomStudentImage];
                    int px = Random.Range(-1, 1);
                    go.transform.position = new Vector3(px, 4, 1);
                    Transform healFxTransform = go.transform.Find("heal_fx");
                    if (healFxTransform != null)
                    {
                        healFxTransform.gameObject.SetActive(true);
                    }
                }
                else if (randPrefab == 1)
                {
                    span = 1f;
                    randomObstacleImage = Random.Range(0, ObstacleSprites.Length);
                    GameObject go2 = Instantiate(ObstaclePrefab);
                    go2.GetComponent<SpriteRenderer>().sprite = ObstacleSprites[randomObstacleImage];
                    int px = Random.Range(-1, 1);
                    go2.transform.position = new Vector3(px, 4, 1);
                    Transform hitfxTransform = go2.transform.Find("hit_fx");
                    if (hitfxTransform != null)
                    {
                        hitfxTransform.gameObject.SetActive(true);
                    }
                }

                else
                {
                    span = 5f;
                    randomMagicalGirlsImage = Random.Range(0, MagicalGirlsSprites.Length);
                    GameObject go3 = Instantiate(MagicalGirlsPrefab);
                    go3.GetComponent<SpriteRenderer>().sprite = MagicalGirlsSprites[randomMagicalGirlsImage];
                    int px = Random.Range(-1, 1);
                    go3.transform.position = new Vector3(px, 4, 1);
                    Transform healFxTransform = go3.transform.Find("heal_fx");
                    if (healFxTransform != null)
                    {
                        healFxTransform.gameObject.SetActive(true);
                    }
                }



            }
       
        }
       

        
        
    }
}
