using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private SpriteRenderer cardImage;
    [SerializeField] private Sprite goodsTexture;
    [SerializeField] private Sprite backTexture;

    private bool isFlipped = false;

    void Start()
    {
        // 초기 설정 등을 할 수 있습니다.
    }

    void Update()
    {
        // 필요한 경우에 업데이트 로직을 추가할 수 있습니다.
    }

    public void FlipCard()
    {
        isFlipped = !isFlipped;

        if (isFlipped)
        {
            cardImage.sprite = goodsTexture;
        }
        else
        {
            cardImage.sprite = backTexture;
        }
    }

    // 클릭 이벤트 처리를 위해 수정
    private void OnMouseDown()
    {
        FlipCard();
    }
}
