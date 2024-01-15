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


    public float score = 0; // ���ھ� �ʱⰪ
    public Text scoreText; // ���ھ� �ؽ�Ʈ ���
                           // public GameObject scoreText; // ���ھ� �ؽ�Ʈ ���

    public AudioSource Main_BGM2;


    private void Start()
    {
        // ���� ���� �� ȣ��Ǵ� �Լ�
        StartGame();

        Main_BGM2.loop = true;  // �ݺ� ���
        correct_sfx.Stop();
        error_sfx.Stop();
        correct_fx.gameObject.SetActive(false);
        error_fx.gameObject.SetActive(false);

    }
    // ������ ���۵� �� ȣ��Ǵ� �Լ�
    private void StartGame()
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
               
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                // �̹����� ��ġ ����
                float positionX = (Xspace * i) + startPosition.x;
                float positionY = (Yspace * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
                gameImage.transform.SetParent(parent, false);

                //scoreText.GetComponent<GameObject>().SetActive(true);

                

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





    // -------------------------------------------------------------------

    public Image restartBG;  // ����� ��
    public Image MainBG;     // ���� ���
   


    public AudioSource correct_sfx;     // ��Ī ���� ����
    public AudioSource error_sfx;       // ��Ī ���� ����


    public GameObject correct_fx;    // ��Ī ���� ȿ��
    public GameObject error_fx;      // ��Ī ���� ȿ��


    // �̹��� ��ġ ���θ� Ȯ���ϰ� ó���ϴ� �ڷ�ƾ
    private IEnumerator CheckGuessed()
    {
        if (firstOpen.spriteId == secondOpen.spriteId) // �� �̹����� ��������Ʈ ID ��
        {
            
            score++; // ��ġ�ϸ� ���� ����
            scoreText.text= "Score : " + score.ToString() ;
            correct_sfx.Play();
            correct_fx.gameObject.SetActive(true);

            Vector3 originalScale = new Vector3(1, 1, 1);
            Vector3 targetScale = new Vector3(1.5f, 1.5f, 1.5f);

            MainImageScript card1 = firstOpen;
            card1.transform.DOScale(targetScale, 0.2f).OnComplete(() => // ���ٽ�
            {
                card1.transform.DOScale(originalScale, 0.2f);
            });
            
            MainImageScript card2 = secondOpen;
            card2.transform.DOScale(targetScale, 0.2f).OnComplete(() => // ���ٽ�
            {
                card2.transform.DOScale(originalScale, 0.2f);
                secondOpen = null;  // ���� �ʱ�ȭ �߰�
            });

            if (score == 10) 
            {
                Main_BGM2.Stop();
                MainBG.gameObject.SetActive(false);
                restartBG.gameObject.SetActive(true);

            }

            


       }
        else
        {
            // ��ġ���� ������ 0.5�� �Ŀ� �̹����� ����
            yield return new WaitForSeconds(0.5f);

            firstOpen.Close();
            secondOpen.Close();

            error_sfx.Play();
            error_fx.gameObject.SetActive(true);



        }










        // ������ �̹��� ���� �ʱ�ȭ
        firstOpen = null;
        secondOpen = null;
    }

   

    // ���� ����� �Լ�

    public void Restart()
    {
        
        Debug.Log("HNMiniGameScene");
        
        SceneManager.LoadScene("HNMiniGameScene");
    }


    // ���� �Ͻ����� ���� ����
    public Image stopBg;
    public Button stop;
    public Button keepGoing;
    public Button goTitle;

    public Image realStopBg;
    public Button stopOk;
    public Button stopNo;


    // ���� �Ͻ����� ���¸� ��Ÿ���� ����
    private bool isGamePaused = false;

    // ���� �Ͻ����� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void StopButtonClick()
    {
        if (!isGamePaused)
        {
            // ���� �Ͻ�����
            PauseGame();
        }
        else if (isGamePaused)
        {
            // ���� �簳
            stopBg.gameObject.SetActive(false);
        }
    }

    // ���� �Ͻ����� ó��
    private void PauseGame()
    {
        isGamePaused = true;

        // ���� �Ͻ����� UI Ȱ��ȭ
        stopBg.gameObject.SetActive(true);
        
    }

    // �������� ���ư��� ��ư �Լ�
    public void keepGoingClick()
    {
        // ���� �Ͻ����� UI ��Ȱ��ȭ
        stopBg.gameObject.SetActive(false);
        ResumeGame();
    }

    // ����ŷ� ���ư��� ��ư �Լ�
    public void goTitleClick()
    {
        // ���� �Ͻ����� UI ��Ȱ��ȭ
        stopBg.gameObject.SetActive(false);

        // ������Bg Ȱ��ȭ
        realStopBg.gameObject.SetActive(true);
    }

    // �������� ���ư��� ��ư �Լ�
    public void stopNoClick()
    {
        // ������Bg Ȱ��ȭ
        realStopBg.gameObject.SetActive(false);
        ResumeGame();
    }

    // ���� �簳 ó��
    private void ResumeGame()
    {
        isGamePaused = false;
    }
}
