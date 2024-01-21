using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI�� ����ϹǷ� ���� �ʰ� �߰�

public class DropGenerator : MonoBehaviour
{

    public GameObject MagicalGirlsPrefab;  // ������ �������� ���� ������
    public GameObject ObstaclePrefab;
    public GameObject StudentPrefab;
    public Sprite[] MagicalGirlsSprites;
    public Sprite[] ObstacleSprites;
    public Sprite[] StudentSprites;
    int randomMagicalGirlsImage;
    int randomObstacleImage;
    int randomStudentImage;

    float span = 2f;  // ��� �����Ǵ� �ֱ�
    float delta = 0;
    int randPrefab = 0;

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            randPrefab = Random.Range(0, 3);

            if ( randPrefab == 0 )
            {
                span = 3f;
                randomStudentImage = Random.Range(0, StudentSprites.Length);
                GameObject go = Instantiate(StudentPrefab);
                go.GetComponent<SpriteRenderer>().sprite = StudentSprites[randomStudentImage];
                int px = Random.Range(-2, 2);
                go.transform.position = new Vector3(px, 4, 1);
            }
            else if ( randPrefab == 1 )
            {
                span = 2f;
                randomObstacleImage = Random.Range(0, ObstacleSprites.Length);
                GameObject go = Instantiate(ObstaclePrefab);
                go.GetComponent<SpriteRenderer>().sprite = ObstacleSprites[randomObstacleImage];
                int px = Random.Range(-2, 2);
                go.transform.position = new Vector3(px, 4, 1);
            }

            else
            {
                span = 5f;
                randomMagicalGirlsImage = Random.Range(0, MagicalGirlsSprites.Length);
                GameObject go = Instantiate(MagicalGirlsPrefab);
                go.GetComponent<SpriteRenderer>().sprite = MagicalGirlsSprites[randomMagicalGirlsImage];
                int px = Random.Range(-2, 2);
                go.transform.position = new Vector3(px, 4, 1);
            }

            
            
        }
       
    
       
        
    }
}
