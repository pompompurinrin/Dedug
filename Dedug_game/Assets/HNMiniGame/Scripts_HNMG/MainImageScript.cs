using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MainImageScript : MonoBehaviour
{
    // ����Ų �̹����� ��Ÿ���� GameObject ����
    [SerializeField] private GameObject image_unknown;
    [SerializeField] private GameObject image_show;
    
   

    // ���� ��Ʈ�ѷ��� ����Ǵ� ����
    [SerializeField] private GameControllerScript gameController;


    // �̹����� Ŭ������ �� ȣ��Ǵ� �Լ�
    public void OnClick()
    {
        

        // �̹����� Ȱ��ȭ�Ǿ� �ְ�, ���� ��Ʈ�ѷ��� �̹����� �� �� �ִ� ������ �� ����
        if (image_unknown.activeSelf && gameController.canOpen)
        {
            //vector3 �� x, y, z�� ������ 3���� ��ǥ��. ( Vector2�� 2d)
            Vector3 originalScale = transform.localScale;
            Vector3 targetScale = new Vector3(0f, originalScale.y, originalScale.z);


            transform.DOScale(targetScale, 0.2f).OnComplete(() => // ���ٽ�

            {
                image_unknown.SetActive(false);
                gameController.imageOpened(this);
                transform.DOScale(originalScale, 0.2f);

            }
            
            );
            // �̹����� ��Ȱ��ȭ�ϰ�, ���� ��Ʈ�ѷ��� imageOpened �Լ� ȣ��
          
        }
    }

    // �̹����� �ĺ� ID�� �����ϴ� ����
    private int _spriteId;

    // �̹����� �ĺ� ID�� �������� �Ӽ�
    public int spriteId
    {
        get { return _spriteId; }
    }

    // �̹����� ��������Ʈ�� �����ϴ� �Լ�
    public void ChangeSprite(int id, Sprite image)
    {
        _spriteId = id;
        GetComponent<Image>().sprite = image; // ��������Ʈ�� �����ϱ� ���� Image ������Ʈ�� ������ ���
        image_show.GetComponent<Image>().sprite = image;

    }

    // �̹����� �ݴ� �Լ�
    public void Close()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = new Vector3(0f, originalScale.y, originalScale.z);
       
        transform.DOShakePosition(0.5f, 50).OnComplete(() =>


            { transform.DOScale(targetScale, 0.2f).OnComplete(() => // ���ٽ�

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
