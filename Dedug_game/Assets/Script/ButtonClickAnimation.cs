using UnityEngine;
using UnityEngine.UI;

public class ButtonClickAnimation : MonoBehaviour
{
    public Button button; // �������� �ҹ��ڷ� �����ϴ� ���� �Ϲ����Դϴ�.
    public Button hideButton;
    public Animator anim;
    
    private void Start()
    {
        anim = GameObject.Find("lock").GetComponent<Animator>();
        // ��ư Ŭ�� �� OnButtonClick �޼��带 �̺�Ʈ�� ���
        button.onClick.AddListener(OnButtonClick);
        hideButton.onClick.AddListener(OnHideButtonClick);
    }

    // ��ư Ŭ�� �� ȣ��� �Լ�
    private void OnButtonClick()
    {
        // Animator ������Ʈ�� ������ Ʈ���Ÿ� ����Ͽ� �ִϸ��̼� ����   
        anim.SetTrigger("Show");
    }

    void OnHideButtonClick()
    {
        anim.SetTrigger("Hide");
    }
}