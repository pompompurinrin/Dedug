using UnityEngine;
using UnityEngine.UI;

public class ButtonClickAnimation : MonoBehaviour
{
    public Button button; // 변수명은 소문자로 시작하는 것이 일반적입니다.
    public Button hideButton;
    public Animator anim;
    
    private void Start()
    {
        anim = GameObject.Find("lock").GetComponent<Animator>();
        // 버튼 클릭 시 OnButtonClick 메서드를 이벤트로 등록
        button.onClick.AddListener(OnButtonClick);
        hideButton.onClick.AddListener(OnHideButtonClick);
    }

    // 버튼 클릭 시 호출될 함수
    private void OnButtonClick()
    {
        // Animator 컴포넌트에 정의한 트리거를 사용하여 애니메이션 실행   
        anim.SetTrigger("Show");
    }

    void OnHideButtonClick()
    {
        anim.SetTrigger("Hide");
    }
}