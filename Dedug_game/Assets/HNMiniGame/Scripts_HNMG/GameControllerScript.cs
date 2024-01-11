using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;




public class GameControllerScript : MonoBehaviour
{
    
    // ���� ������ ���� ���� ��
    public const int columns = 4;
    public const int rows = 5;

    // �̹����� ��ġ�� �θ� ��ü
    public Transform parent;

    // �̹��� ������ ���� ����
    public const float Xspace = 260f;
    public const float Yspace = -300f;

    // ���� ���� �̹��� �� ���� ��������Ʈ �迭
    [SerializeField] private MainImageScript startObject;
    [SerializeField] private Sprite[] images;

    // ��ġ�� �������� ���� �Լ�
    private int[] Randomiser(int[] locations)
    {
        int[] array = locations.Clone() as int[];
        for (int i = 0; i < array.Length; i++)
        {
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }
        return array;
    }

    // ������ ���۵� �� ȣ��Ǵ� �Լ�
    private void Start()
    {
        // �̹��� ��ġ�� �������� ����
        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9};

        locations = Randomiser(locations);

        Vector3 startPosition = startObject.transform.position;

        // ���� ���忡 �̹��� ��ġ
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                MainImageScript gameImage;
                if (i == 0 && j == 0)
                {
                    // ���� �̹����� ���� ó��
                    gameImage = startObject;
                }
                else
                {
                    // ������ �̹����� �����Ͽ� ���
                    gameImage = Instantiate(startObject) as MainImageScript;
                }

                int index = j * columns + i;
                Debug.Log(index);
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                // �̹����� ��ġ ����
                float positionX = (Xspace * i) + startPosition.x;
                float positionY = (Yspace * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
                gameImage.transform.SetParent(parent, false);

                
            }
        }
    }

    // ������ �̹����� �����ϰ�, �´��� Ȯ���ϴ� �Լ�
    private MainImageScript firstOpen;
    private MainImageScript secondOpen;

    // �� ��° �̹����� �� �� �ִ��� ���θ� ��ȯ�ϴ� �Ӽ�
    public bool canOpen
    {
        get { return secondOpen == null; }
    }

    // �̹����� ������ �� ȣ��Ǵ� �Լ�
    public void imageOpened(MainImageScript startObject)
    {
        if (firstOpen == null)
        {
            // ù ��° �̹��� ����
            firstOpen = startObject;
        }
        else
        {
            // �� ��° �̹��� ���� �� ��ġ ���� Ȯ��
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }
    }
    public Image restartBtn;
    public Image MainBG;
    public float score = 0;
    public Text scoreText;
    // ��ġ ���θ� Ȯ���ϰ� ó���ϴ� �ڷ�ƾ
    private IEnumerator CheckGuessed()
    {
        if (firstOpen.spriteId == secondOpen.spriteId) // �� �̹����� ��������Ʈ ID ��
        {
            // ��ġ�ϸ� ���� ����
            score++;
            scoreText.text=score.ToString();

            Vector3 originalScale = new Vector3(1, 1, 1);
            Vector3 targetScale = new Vector3(2f, 2f, 2f);



            MainImageScript card1 = firstOpen;
            


            card1.transform.DOScale(targetScale, 0.2f).OnComplete(() => // ���ٽ�

            {

                card1.transform.DOScale(originalScale, 0.2f);
             

            });
            
          
 
            MainImageScript card2 = secondOpen;

            card2.transform.DOScale(targetScale, 0.2f).OnComplete(() =>
            {
                card2.transform.DOScale(originalScale, 0.2f);
                secondOpen = null;  // ���� �ʱ�ȭ �߰�
            });




            if (score == 10) // �� �̹����� ��������Ʈ ID ��
            {

                MainBG.gameObject.SetActive(false);
                restartBtn.gameObject.SetActive(true);
                


            }
            

        }
        else
        {
            // ��ġ���� ������ 0.5�� �Ŀ� �̹����� ����
            yield return new WaitForSeconds(0.5f);

            firstOpen.Close();
            secondOpen.Close();
        }


        // ������ �̹��� ���� �ʱ�ȭ
        firstOpen = null;
        secondOpen = null;
    }

 


    // ���� ����� �Լ�

    public void Restart()
    {
        Debug.Log("ddd");
        
        SceneManager.LoadScene("HNMiniGameScene");
    }
}
