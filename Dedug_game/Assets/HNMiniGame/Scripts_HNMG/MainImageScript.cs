using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainImageScript : MonoBehaviour
{
    // ����Ų �̹����� ��Ÿ���� GameObject ����
    [SerializeField] private GameObject image_unknown;
    [SerializeField] private GameObject image_show;

    // ���� ��Ʈ�ѷ��� ����Ǵ� ����
    [SerializeField] private GameControllerScript gameController;

    Animator animator;

    // �̹����� Ŭ������ �� ȣ��Ǵ� �Լ�
    public void OnClick()
    {
        

        // �̹����� Ȱ��ȭ�Ǿ� �ְ�, ���� ��Ʈ�ѷ��� �̹����� �� �� �ִ� ������ �� ����
        if (image_unknown.activeSelf && gameController.canOpen)
        {
            animator.SetTrigger("Flip");
            // �̹����� ��Ȱ��ȭ�ϰ�, ���� ��Ʈ�ѷ��� imageOpened �Լ� ȣ��
            image_unknown.SetActive(false);
            gameController.imageOpened(this);
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
        image_unknown.SetActive(true); // �̹����� Ȱ��ȭ�Ͽ� ����
    }
    public void Start()
    {
        animator = GetComponent<Animator>();
        image_unknown.SetActive(false); 
        Invoke("DisableShowImage", 2);
    }
    public void DisableShowImage()
    {
        image_show.SetActive(false); 
        image_unknown.SetActive(true);


    }
}
