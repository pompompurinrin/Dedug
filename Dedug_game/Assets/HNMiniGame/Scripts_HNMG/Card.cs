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
        // �ʱ� ���� ���� �� �� �ֽ��ϴ�.
    }

    void Update()
    {
        // �ʿ��� ��쿡 ������Ʈ ������ �߰��� �� �ֽ��ϴ�.
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

    // Ŭ�� �̺�Ʈ ó���� ���� ����
    private void OnMouseDown()
    {
        FlipCard();
    }
}
