using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;




public class GameControllerScript : MonoBehaviour
{
    
    // 게임 보드의 열과 행의 수
    public const int columns = 4;
    public const int rows = 5;

    // 이미지를 배치할 부모 객체
    public Transform parent;

    // 이미지 사이의 간격 설정
    public const float Xspace = 260f;
    public const float Yspace = -300f;

    // 게임 시작 이미지 및 사용될 스프라이트 배열
    [SerializeField] private MainImageScript startObject;
    [SerializeField] private Sprite[] images;

    // 위치를 무작위로 섞는 함수
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


    public float score = 0; // 스코어 초기값
    public Text scoreText; // 스코어 텍스트 출력
                           // public GameObject scoreText; // 스코어 텍스트 출력

    public AudioSource Main_BGM2;


    private void Start()
    {
        // 게임 시작 시 호출되는 함수
        StartGame();

        Main_BGM2.loop = true;  // 반복 재생
        correct_sfx.Stop();
        error_sfx.Stop();
        correct_fx.gameObject.SetActive(false);
        error_fx.gameObject.SetActive(false);

    }
    // 게임이 시작될 때 호출되는 함수
    private void StartGame()
    {

        // 이미지 위치를 무작위로 섞음
        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9};

        locations = Randomiser(locations);

        Vector3 startPosition = startObject.transform.position;

        // 게임 보드에 이미지 배치
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                MainImageScript gameImage;
                if (i == 0 && j == 0)
                {
                    // 시작 이미지는 따로 처리
                    gameImage = startObject;
                }
                else
                {
                    // 나머지 이미지는 복제하여 사용
                    gameImage = Instantiate(startObject) as MainImageScript;
                }

                int index = j * columns + i;
               
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                // 이미지의 위치 설정
                float positionX = (Xspace * i) + startPosition.x;
                float positionY = (Yspace * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
                gameImage.transform.SetParent(parent, false);

                //scoreText.GetComponent<GameObject>().SetActive(true);

                

            }
        }
    }

    // 열려진 이미지를 추적하고, 맞는지 확인하는 함수
    private MainImageScript firstOpen;
    private MainImageScript secondOpen;

    // 두 번째 이미지를 열 수 있는지 여부를 반환하는 속성
    public bool canOpen
    {
        get { return secondOpen == null; }
    }

    // 이미지가 열렸을 때 호출되는 함수
    public void imageOpened(MainImageScript startObject)
    {
        if (firstOpen == null)
        {
            // 첫 번째 이미지 열림
            firstOpen = startObject;
        }
        else
        {
            // 두 번째 이미지 열림 후 일치 여부 확인
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }
    }





    // -------------------------------------------------------------------

    public Image restartBG;  // 재시작 씬
    public Image MainBG;     // 메인 배경
   


    public AudioSource correct_sfx;     // 매칭 성공 사운드
    public AudioSource error_sfx;       // 매칭 에러 사운드


    public GameObject correct_fx;    // 매칭 성공 효과
    public GameObject error_fx;      // 매칭 에러 효과


    // 이미지 일치 여부를 확인하고 처리하는 코루틴
    private IEnumerator CheckGuessed()
    {
        if (firstOpen.spriteId == secondOpen.spriteId) // 두 이미지의 스프라이트 ID 비교
        {
            
            score++; // 일치하면 점수 증가
            scoreText.text= "Score : " + score.ToString() ;
            correct_sfx.Play();
            correct_fx.gameObject.SetActive(true);

            Vector3 originalScale = new Vector3(1, 1, 1);
            Vector3 targetScale = new Vector3(1.5f, 1.5f, 1.5f);

            MainImageScript card1 = firstOpen;
            card1.transform.DOScale(targetScale, 0.2f).OnComplete(() => // 람다식
            {
                card1.transform.DOScale(originalScale, 0.2f);
            });
            
            MainImageScript card2 = secondOpen;
            card2.transform.DOScale(targetScale, 0.2f).OnComplete(() => // 람다식
            {
                card2.transform.DOScale(originalScale, 0.2f);
                secondOpen = null;  // 변수 초기화 추가
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
            // 일치하지 않으면 0.5초 후에 이미지를 닫음
            yield return new WaitForSeconds(0.5f);

            firstOpen.Close();
            secondOpen.Close();

            error_sfx.Play();
            error_fx.gameObject.SetActive(true);



        }










        // 열려진 이미지 변수 초기화
        firstOpen = null;
        secondOpen = null;
    }

   

    // 게임 재시작 함수

    public void Restart()
    {
        
        Debug.Log("HNMiniGameScene");
        
        SceneManager.LoadScene("HNMiniGameScene");
    }


    // 게임 일시정지 관련 변수
    public Image stopBg;
    public Button stop;
    public Button keepGoing;
    public Button goTitle;

    public Image realStopBg;
    public Button stopOk;
    public Button stopNo;


    // 게임 일시정지 상태를 나타내는 변수
    private bool isGamePaused = false;

    // 게임 일시정지 버튼 클릭 시 호출되는 함수
    public void StopButtonClick()
    {
        if (!isGamePaused)
        {
            // 게임 일시정지
            PauseGame();
        }
        else if (isGamePaused)
        {
            // 게임 재개
            stopBg.gameObject.SetActive(false);
        }
    }

    // 게임 일시정지 처리
    private void PauseGame()
    {
        isGamePaused = true;

        // 게임 일시정지 UI 활성화
        stopBg.gameObject.SetActive(true);
        
    }

    // 게임으로 돌아가기 버튼 함수
    public void keepGoingClick()
    {
        // 게임 일시정지 UI 비활성화
        stopBg.gameObject.SetActive(false);
        ResumeGame();
    }

    // 굿즈구매로 돌아가기 버튼 함수
    public void goTitleClick()
    {
        // 게임 일시정지 UI 비활성화
        stopBg.gameObject.SetActive(false);

        // 리얼스톱Bg 활성화
        realStopBg.gameObject.SetActive(true);
    }

    // 게임으로 돌아가기 버튼 함수
    public void stopNoClick()
    {
        // 리얼스톱Bg 활성화
        realStopBg.gameObject.SetActive(false);
        ResumeGame();
    }

    // 게임 재개 처리
    private void ResumeGame()
    {
        isGamePaused = false;
    }
}
