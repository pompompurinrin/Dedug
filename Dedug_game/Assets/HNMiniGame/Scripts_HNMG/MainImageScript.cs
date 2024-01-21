using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MainImageScript : MonoBehaviour
{
    [SerializeField] private GameObject card_Back;
    [SerializeField] private GameObject image_frame;
    [SerializeField] private GameObject Image_BG;
    [SerializeField] private GameObject real_Image;
    [SerializeField] public GameObject error_fx;      // ��Ī ���� ȿ��
    [SerializeField] public GameObject correct_fx;    // ��Ī ���� ȿ��

    [SerializeField] private MainController mainController;


    public void Start()
    {
        card_Back.SetActive(false);
        Invoke("DisableShowImage", 3);
    }
    public void DisableShowImage()
    {
        card_Back.SetActive(true);
        real_Image.SetActive(false);
        image_frame.SetActive(false);
        Image_BG.SetActive(false);
    }
    // �̹����� Ŭ������ �� ȣ��Ǵ� �Լ�
    public void OnClick()
    {
        

        // �̹����� Ȱ��ȭ�Ǿ� �ְ�, ���� ��Ʈ�ѷ��� �̹����� �� �� �ִ� ������ �� ����
        if (card_Back.activeSelf && mainController.canOpen)
        {
            //vector3 �� x, y, z�� ������ 3���� ��ǥ��. (Vector2�� 2d)
            Vector3 originalScale = transform.localScale;
            Vector3 targetScale = new Vector3(0f, originalScale.y, originalScale.z);


            transform.DOScale(targetScale, 0.1f).OnComplete(() => // ���ٽ�

            {
                card_Back.SetActive(false);
                image_frame.SetActive(true);
                real_Image.SetActive(true);
                Image_BG.SetActive(true);


                mainController.imageOpened(this);
                transform.DOScale(originalScale, 0.1f);

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
        real_Image.GetComponent<Image>().sprite = image; // ��������Ʈ�� �����ϱ� ���� Image ������Ʈ�� ������ ���
     

    }

    // �̹����� �ݴ� �Լ�
    public void Close()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = new Vector3(0f, originalScale.y, originalScale.z);

        error_fx.gameObject.SetActive(true);

        transform.DOShakePosition(0.3f, 50).OnComplete(() =>

            { transform.DOScale(targetScale, 0.2f).OnComplete(() => // ���ٽ�
                {
                card_Back.SetActive(true);
                image_frame.SetActive(false);
                    real_Image.SetActive(false);
                Image_BG.SetActive(false);

                transform.DOScale(originalScale, 0.2f);
                error_fx.gameObject.SetActive(false);
                }           
            );
        });
        
    }
  
}
