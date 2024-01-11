using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MainImageScript : MonoBehaviour
{
    // 가리킨 이미지를 나타내는 GameObject 변수
    [SerializeField] private GameObject image_unknown;
    [SerializeField] private GameObject image_show;
    
   

    // 게임 컨트롤러와 연결되는 변수
    [SerializeField] private GameControllerScript gameController;


    // 이미지를 클릭했을 때 호출되는 함수
    public void OnClick()
    {
        

        // 이미지가 활성화되어 있고, 게임 컨트롤러가 이미지를 열 수 있는 상태일 때 실행
        if (image_unknown.activeSelf && gameController.canOpen)
        {
            //vector3 는 x, y, z로 구성된 3차원 좌표값. ( Vector2는 2d)
            Vector3 originalScale = transform.localScale;
            Vector3 targetScale = new Vector3(0f, originalScale.y, originalScale.z);


            transform.DOScale(targetScale, 0.2f).OnComplete(() => // 람다식

            {
                image_unknown.SetActive(false);
                gameController.imageOpened(this);
                transform.DOScale(originalScale, 0.2f);

            }
            
            );
            // 이미지를 비활성화하고, 게임 컨트롤러의 imageOpened 함수 호출
          
        }
    }

    // 이미지의 식별 ID를 저장하는 변수
    private int _spriteId;

    // 이미지의 식별 ID를 가져오는 속성
    public int spriteId
    {
        get { return _spriteId; }
    }

    // 이미지의 스프라이트를 변경하는 함수
    public void ChangeSprite(int id, Sprite image)
    {
        _spriteId = id;
        GetComponent<Image>().sprite = image; // 스프라이트를 변경하기 위해 Image 컴포넌트를 가져와 사용
        image_show.GetComponent<Image>().sprite = image;

    }

    // 이미지를 닫는 함수
    public void Close()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = new Vector3(0f, originalScale.y, originalScale.z);
       
        transform.DOShakePosition(0.5f, 50).OnComplete(() =>


            { transform.DOScale(targetScale, 0.2f).OnComplete(() => // 람다식

            {
                image_unknown.SetActive(true);

                transform.DOScale(originalScale, 0.2f);

            }

            );
        });


        
    }
    public void Start()
    {
       
        image_unknown.SetActive(false); 
        Invoke("DisableShowImage", 2);
    }
    public void DisableShowImage()
    {
        image_show.SetActive(false); 
        image_unknown.SetActive(true);


    }
}
