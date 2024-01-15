using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class YJMiniGameManager : MonoBehaviour
{
    // �̴ϰ��� ���� �� �� �θ� ��ü
    public GameObject endBg;
    public GameObject startBg;

    // �޽��� ��� �̹��� �θ� ��ü
    public GameObject messageBg;
    public GameObject messageBg02;

    // �޽��� Ÿ�� ��� �ؽ�Ʈ �� ����Ʈ
    public Image loveEffect;

    // ������ Ÿ�̹� ���� �̹���
    public Image success;
    public Image fail;

    // ���� ���ð� ī��Ʈ
    public Text beforeCount;
    public Image beforeImg;

    // �̴ϰ��� ž �� ���� ���� (����, ���ѽð�)
    public Text costText;
    public Text countDown;

    // �����ҳ� ĳ���� �� ����(���ΰ�) �ִϸ��̼� �̹���
    public Image badaChar;
    public Image meChar;
    public Image meChar01;
    public Image meChar02;
    public Image meChar03;

    // ���� ��ư
    public Button message01;
    public Button message02;
    public Button bong01;
    public Button bong02;
    public Button bong03;

    // ������ Ÿ�� �ȳ� ����Ʈ
    public Image colorEffect01;
    public Image colorEffect02;
    public Image colorEffect03;

    // ���� �� ���ѽð�, ���ð� ����
    public static int score;
    int gameTime;
    int beforeGameTime;

    // ������ Ÿ��!
    private bool isGameRunning = false;
    private float bongTime = 2.0f;
    private bool isBongTimeActive = false;

    // �ϵ� ������ Ÿ��!
    public Image hardStart;
    private float hardBongTimeNext = 3.0f;
    private bool isHardBongTimeActive = false;

    // �ϵ� ������ Ÿ�� ������� ������ ��� �� ��ư ���� ����
    private Queue<Image> activeColorEffects = new Queue<Image>();
    private Queue<Button> expectedBongButtons = new Queue<Button>();

    // �ϵ� ������ Ÿ�� ���� Ŭ�� ���θ� �����ϴ� ����
    private bool isHardBongTimeButtonClick = false;

    // �ߺ� �÷� ������ ���� ����Ʈ ����
    private List<Image> availableColorEffects = new List<Image>();

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

    // ���� ��鸲
    private float shakeRange = 0.2f;
    private float shakeSpeed = 2f;

    public AudioSource gameAudioSource;  // ���� �� ����� ����

    public AudioSource badamessage01_SFX;
    public AudioSource badamessage02_SFX;

    public AudioSource badasucces_SFX;
    public AudioSource badafail_SFX;

    public AudioSource badacount_SFX;

    public AudioSource bongtime01;
    public AudioSource bongtime02;
    public AudioSource bongtime03;

    // ���� ���� ��
    public GameObject ResultCanvas;
    public static bool badaResult;


    private void Start()
    {
        // ���� ���� �� ȣ��Ǵ� �Լ�
        StartGame();

        gameAudioSource.loop = true;  // �ݺ� ���

    }

private void StartGame()
    {
        // ���� ���ð� �ʱ�ȭ �� ���ð� UI Ȱ��ȭ
        beforeGameTime = 3;
        beforeCount.gameObject.SetActive(true);
        beforeImg.gameObject.SetActive(true);
        // 1�ʸ��� CountDownBeforeGame �޼ҵ� ȣ��
        InvokeRepeating("CountDownBeforeGame", 1.0f, 1.0f);
    }

    // ���� ���ð� ����
    private void CountDownBeforeGame()
    {
        // ���� ���ð� ī��Ʈ �ٿ�
        beforeGameTime--;

        if (beforeGameTime == 0)
        {
            // ���� ���ð� ���� �� ����
            beforeCount.gameObject.SetActive(false);
            beforeImg.gameObject.SetActive(false);
            // CountDownBeforeGame ȣ�� �ߴ�
            CancelInvoke("CountDownBeforeGame");

            // ���� ���� ����
            StartRealTimeGame();
        }
        else
        {
            // ���ð� �ؽ�Ʈ ����
            badacount_SFX.Play();
            beforeCount.text = beforeGameTime.ToString();

        }
    }

    // ���� ����
    private void StartRealTimeGame()
    {
        // ���� ���� ����
        isGameRunning = true;

        // �ʱ� ���ѽð� ����
        gameTime = 3;
        countDown.text = gameTime.ToString();

        // 1�ʸ��� UpdateGame �޼ҵ� ȣ��
        InvokeRepeating("UpdateGame", 1.0f, 1.0f);

        gameAudioSource.Play();


    }


    private void UpdateGame()
    {
        // �Ͻ����� ���¿����� ���� ������Ʈ�� �ǳʶٱ�
        if (isGamePaused)
            return;

        // 0. ���ѽð��� ����� ���
        if (gameTime <= 0)
        {
            // ���� ���� ó��
            EndGame();
            return;
        }

        // 1. �ǽð� ī��Ʈ�ٿ� ���� �� BGM ���
        countDown.text = gameTime.ToString();
        gameTime--;

        // 2. bongTime ���� ������ colorEffect Ȱ��ȭ
        if (gameTime >= 75 && gameTime % 5 == 0)
        {
            ActivateRandomColorEffect();
            isBongTimeActive = true;

            // bongTime �� �Ŀ� �ƹ� ��ư�� Ŭ������ �ʾ��� �� ó���� ���� Invoke ȣ��
            Invoke("HandleButtonClick", bongTime);
        }

        // (5) countDown < 60�� ���
        if (gameTime > 42 && gameTime < 75 && gameTime % 7 == 0)
        {
            // ������ colorEffect�� 2���� �̹����� 3�� ���� Ȱ��ȭ �� ��Ȱ��ȭ
            StartCoroutine(ActivateRandomColorEffects());
        }

        if (gameTime <= 42 && gameTime % 10 == 0)
        {
            StartCoroutine(TooHardRandomColorEffects());
        }

        // 3. ���� ��ư Ŭ�� ó��
        if (Input.GetMouseButtonDown(0))
        {
            HandleButtonClick();
        }

        // 4. ���ھ 0 �̸����� �������� �ʵ��� Ȯ��
        if (score < 0)
        {
            score = 0;
            costText.text = score.ToString();
        }

        // meChar�� Y ���� �������� �պ��ϵ��� ����� �ڵ�
        if (isGameRunning)
        {
            float yOffset = Mathf.PingPong(Time.time * shakeSpeed, shakeRange * 2) - shakeRange;
            Vector3 newPos = meChar.transform.position;
            newPos.y = yOffset;
            meChar.transform.position = newPos;
        }

        // meChar�� Y ���� �������� �պ��ϵ��� ����� �ڵ�
        if (isGameRunning)
        {
            float yOffset = Mathf.PingPong(Time.time * shakeSpeed, shakeRange * 2) - shakeRange;
            Vector3 newPos = meChar01.transform.position;
            newPos.y = yOffset;
            meChar01.transform.position = newPos;
        }

        // meChar�� Y ���� �������� �պ��ϵ��� ����� �ڵ�
        if (isGameRunning)
        {
            float yOffset = Mathf.PingPong(Time.time * shakeSpeed, shakeRange * 2) - shakeRange;
            Vector3 newPos = meChar02.transform.position;
            newPos.y = yOffset;
            meChar02.transform.position = newPos;
        }

        // meChar�� Y ���� �������� �պ��ϵ��� ����� �ڵ�
        if (isGameRunning)
        {
            float yOffset = Mathf.PingPong(Time.time * shakeSpeed, shakeRange * 2) - shakeRange;
            Vector3 newPos = meChar03.transform.position;
            newPos.y = yOffset;
            meChar03.transform.position = newPos;
        }

        // �ٴ�» �¿�� ��鸮�� ����� �ڵ�
        if (isGameRunning)
        {
            ShakeObject(badaChar, shakeRange, shakeSpeed);
        }
    }

    // �ٴ�» ��� �Լ�
    private void ShakeObject(Image obj, float range, float speed)
    {
        float xOffset = Mathf.PingPong(Time.time * speed, range * 2) - range;
        Vector3 newPos = obj.transform.position;
        newPos.x = xOffset;
        obj.transform.position = newPos;
    }

    // �� �ϵ� ��Ÿ�� ����

    private IEnumerator TooHardRandomColorEffects()
    {
        expectedBongButtons.Clear(); // ������ ����� ��ư �ʱ�ȭ

        for (int i = 0; i < 3; i++)
        {
            // ������ colorEffect�� �����ͼ� ť�� �߰�
            Image randomColorEffect = GetRandomColorEffect();
            activeColorEffects.Enqueue(randomColorEffect);

            // 1.5�� ���� Ȱ��ȭ
            randomColorEffect.gameObject.SetActive(true);
            
            // ȿ���� ���
            PlayColorEffectSound(randomColorEffect);

            yield return new WaitForSeconds(1f);

            // �����ϴ� bong ��ư�� tooExpectedBongButtons�� ����
            expectedBongButtons.Enqueue(GetMatchingBongButton(randomColorEffect));

            // ��Ȱ��ȭ
            randomColorEffect.gameObject.SetActive(false);
        }

        // (5)���� ������ ��� 3�� ���ȸ� hardBongTimeNext�� �����
        isHardBongTimeActive = true;
        isHardBongTimeButtonClick = true;
        hardStart.gameObject.SetActive(true); // hardStart�� Ȱ��ȭ
        Invoke("DeactivateHardBongTime", hardBongTimeNext);

        yield return new WaitForSeconds(hardBongTimeNext);

        // hardBongTimeNext�� ���� �� isHardBongTimeActive = false�� �ϰ� ���ÿ� hardStart�� ��Ȱ��ȭ
        isHardBongTimeActive = false;
        hardStart.gameObject.SetActive(false);

        // hardBongTime�� ����Ǹ� �ٽ� activeColorEffects�� ���
        activeColorEffects.Clear();
    }

    // �ϵ� ��Ÿ�� ����
    private IEnumerator ActivateRandomColorEffects()
    {
        expectedBongButtons.Clear(); // ������ ����� ��ư �ʱ�ȭ

        for (int i = 0; i < 2; i++)
        {
            // ������ colorEffect�� �����ͼ� ť�� �߰�
            Image randomColorEffect = GetRandomColorEffect();
            activeColorEffects.Enqueue(randomColorEffect);

            // 1.5�� ���� Ȱ��ȭ
            randomColorEffect.gameObject.SetActive(true);

            // ȿ���� ���
            PlayColorEffectSound(randomColorEffect);

            yield return new WaitForSeconds(1.5f);

            // �����ϴ� bong ��ư�� expectedBongButtons�� ����
            expectedBongButtons.Enqueue(GetMatchingBongButton(randomColorEffect));

            // ��Ȱ��ȭ
            randomColorEffect.gameObject.SetActive(false);
        }

        // (5)���� ������ ��� 3�� ���ȸ� hardBongTimeNext�� �����
        isHardBongTimeActive = true;
        isHardBongTimeButtonClick = true;
        hardStart.gameObject.SetActive(true); // hardStart�� Ȱ��ȭ
        Invoke("DeactivateHardBongTime", hardBongTimeNext);

        yield return new WaitForSeconds(hardBongTimeNext);

        // hardBongTimeNext�� ���� �� isHardBongTimeActive = false�� �ϰ� ���ÿ� hardStart�� ��Ȱ��ȭ
        isHardBongTimeActive = false;
        hardStart.gameObject.SetActive(false);

        // hardBongTime�� ����Ǹ� �ٽ� activeColorEffects�� ���
        activeColorEffects.Clear();
    }

    // ȿ���� ��� �޼ҵ�
    private void PlayColorEffectSound(Image colorEffect)
    {
        if (colorEffect == colorEffect01)
        {
            bongtime01.Play();
        }

        else if (colorEffect == colorEffect02)
        {
            bongtime02.Play();
        }

        else if (colorEffect == colorEffect03)
        {
            bongtime03.Play();
        }
    }

    // �ϵ� �� Ÿ�� ���� ó��
    private void DeactivateHardBongTime()
    {
        isHardBongTimeActive = false;
        // �ϵ� �� Ÿ�� ���� ��ư�� Ŭ������ �ʾ��� ��� score�� -1 ����
        if (isHardBongTimeButtonClick == true)
        {
            score--;
            costText.text = score.ToString();

            // ���� �̹��� Ȱ��ȭ
            fail.gameObject.SetActive(true);
            badafail_SFX.Play();
            Invoke("DeactivateFailImage", 2.0f);
        }
        // hardBongTime�� ����Ǹ� �ٽ� activeColorEffects�� ���
        activeColorEffects.Clear();
    }

    // �������� ����Ʈ �÷� ����
    private Button GetMatchingBongButton(Image colorEffect)
    {
        if (colorEffect == colorEffect01)
        {
            return bong01;
        }
        else if (colorEffect == colorEffect02)
        {
            return bong02;
        }
        else if (colorEffect == colorEffect03)
        {
            return bong03;
        }

        return null;
    }

    // �Ϲ� ��Ÿ�� �÷� ����Ʈ ���� Ȱ��ȭ
    private void ActivateRandomColorEffect()
    {

        // ������ colorEffect Ȱ��ȭ �� ���� �ð� �Ŀ� ��Ȱ��ȭ
        Image randomColorEffect = GetRandomColorEffect();
        randomColorEffect.gameObject.SetActive(true);

        // ȿ���� ���
        PlayColorEffectSound(randomColorEffect);

        Invoke("DeactivateColorEffect", bongTime);
    }

    // �Ϲ� ��Ÿ�� �÷� ����Ʈ ���� �̱�
    private Image GetRandomColorEffect()
    {
        // ������ colorEffect ��ȯ
        if (availableColorEffects.Count == 0)
        {
            // ��� ������ �÷� ����Ʈ�� ������ ��� �÷� ����Ʈ�� �ٽ� �߰�
            availableColorEffects.AddRange(new List<Image> { colorEffect01, colorEffect02, colorEffect03 });
        }

        // ������ �÷� ����Ʈ ��ȯ �� ��� ��Ͽ��� ����
        int randomIndex = Random.Range(0, availableColorEffects.Count);
        Image randomColorEffect = availableColorEffects[randomIndex];
        availableColorEffects.RemoveAt(randomIndex);

        return randomColorEffect;
    }

    private void DeactivateColorEffect()
    {
        // ��� colorEffect ��Ȱ��ȭ
        colorEffect01.gameObject.SetActive(false);
        colorEffect02.gameObject.SetActive(false);
        colorEffect03.gameObject.SetActive(false);
    }

    // ������ Ŭ�� �˻�
    public void HandleButtonClick()
    {

        // �ϵ� ������ Ÿ���� �� �߰��� �κ�
        if (isHardBongTimeActive == true)
        {
            // ������ ��ư�� Ŭ������ �� ���� �˻�
            CheckUserInput();

        }

        // bongTime�� ������ �� �߰��� �κ�
        if (isBongTimeActive)
        {
            // bong ��ư�� �ϳ��� Ŭ������ �ʾ��� �� ó��
            if (expectedBongButtons.Count == 0)
            {
                // ��ư�� Ŭ������ �ʾ��� ���� ó��
                score--;  // ���ھ� ����
                costText.text = score.ToString();  // UI ������Ʈ
                isBongTimeActive = false;  // bongTime ���� Ŭ�� ���� ���� ���� �ʱ�ȭ
                DeactivateColorEffect();  // colorEffect ��Ȱ��ȭ

                // ���� �̹��� Ȱ��ȭ
                fail.gameObject.SetActive(true);
                badafail_SFX.Play();
                Invoke("DeactivateFailImage", 2.0f);
            }
        }

        if (isGameRunning)
        {
            // ���� ���� üũ
            CheckGameEnd();
        }

    }

    // �ϵ� ������ Ÿ�� ��ư Ŭ�� �Լ�
    private void CheckUserInput()
    {
        if (expectedBongButtons.Count > 0)
        {
            Button expectedButton = expectedBongButtons.Dequeue(); // ť���� ��ư�� ������� ������

            if (EventSystem.current.currentSelectedGameObject == expectedButton.gameObject)
            {
                // �̹� ���� ���� Invoke ����
                CancelInvoke("DeactivateSuccessImage");

                // �̹��� �ʱ�ȭ
                success.gameObject.SetActive(false);
                badasucces_SFX.Stop();

                // ��ư�� �ùٸ� ������ Ŭ���Ǿ��� ��
                score++;
                costText.text = score.ToString();

                // ���� �̹��� Ȱ��ȭ
                success.gameObject.SetActive(true);
                badasucces_SFX.Play();
                Invoke("DeactivateSuccessImage", 0.5f);
            }
            else
            {
                // �̹� ���� ���� Invoke ����
                CancelInvoke("DeactivateFailImage");

                // �̹��� �ʱ�ȭ
                fail.gameObject.SetActive(false);
                badafail_SFX.Stop();

                // ��ư�� �߸� Ŭ���Ǿ��� ��
                score--;
                costText.text = score.ToString();

                // ���� �̹��� Ȱ��ȭ
                fail.gameObject.SetActive(true);
                badafail_SFX.Play();
                Invoke("DeactivateFailImage", 0.5f);
            }

            // UI ������Ʈ
            UpdateUI();

            // Ŭ�� ���� ���� �ʱ�ȭ
            isHardBongTimeButtonClick = false;
        }
    }

    // �Ϲ� ��Ÿ�� ���� �� Ŭ�� �˻�
    public void OnBongButtonClick(Button bongButton)
    {

        // bongTime�� ���� ���� ���� ó��
        if (isGameRunning && isBongTimeActive == true)
        {
            // Ȱ��ȭ�� colorEffect�� �����Ǵ� bong ��ư���� Ȯ��
            if (IsMatchingBongButton(bongButton))
            {
                // ������ ���
                score++;
                costText.text = score.ToString();

                // ���� �̹��� Ȱ��ȭ
                success.gameObject.SetActive(true);
                badasucces_SFX.Play();
                Invoke("DeactivateSuccessImage", 2.0f);
            }
            else
            {
                // ������ ���
                score--;
                costText.text = score.ToString();

                // ���� �̹��� Ȱ��ȭ
                fail.gameObject.SetActive(true);
                badafail_SFX.Play();
                Invoke("DeactivateFailImage", 2.0f);
            }

            // UI ������Ʈ
            UpdateUI();

            // colorEffect ��Ȱ��ȭ
            DeactivateColorEffect();

            // bongTime ���� Ŭ�� ���� ���� ���� �ʱ�ȭ
            isBongTimeActive = false;
        }
    }

    private void DeactivateSuccessImage()
    {
        // ���� �̹��� ��Ȱ��ȭ
        success.gameObject.SetActive(false);
    }

    private void DeactivateFailImage()
    {
        // ���� �̹��� ��Ȱ��ȭ
        fail.gameObject.SetActive(false);
    }

    private bool IsBongTimeActive()
    {
        // bongTime�� ���� ������ ���� ��ȯ
        return isGameRunning;
    }

    // �Ϲ� ��Ÿ�� ���� �� Ŭ�� ���� �˻�
    private bool IsMatchingBongButton(Button bongButton)
    {
        // Ȱ��ȭ�� colorEffect�� �����Ǵ� bong ��ư���� Ȯ��
        Image activeColorEffect = GetActiveColorEffect();

        if (bongButton == bong01 && activeColorEffect == colorEffect01)
        {
            return true;
        }
        else if (bongButton == bong02 && activeColorEffect == colorEffect02)
        {
            return true;
        }
        else if (bongButton == bong03 && activeColorEffect == colorEffect03)
        {
            return true;
        }

        return false;
    }

    private Image GetActiveColorEffect()
    {
        // Ȱ��ȭ�� colorEffect ��ȯ
        if (colorEffect01.gameObject.activeSelf)
        {
            return colorEffect01;
        }
        else if (colorEffect02.gameObject.activeSelf)
        {
            return colorEffect02;
        }
        else if (colorEffect03.gameObject.activeSelf)
        {
            return colorEffect03;
        }

        return null;
    }

    private void UpdateUI()
    {
        // UI ������Ʈ (���ѽð�, ����)
        countDown.text = gameTime.ToString();
        costText.text = "Score: " + score.ToString();
    }

    private void CheckGameEnd()
    {
        // ���ѽð��� ����Ǹ� ���� ����
        if (gameTime <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        // ���� ���� �� ���� ����
        gameAudioSource.Stop();

        // ���� ���� �� ȣ��Ǵ� �Լ�
        // badaResult = true;
        ResultCanvas.SetActive(true);

        // badaResult = false;

        isGameRunning = false;
    }

    public void OnMessage01ButtonClick()
    {
        if (isBongTimeActive == false && isGameRunning == true)
        {
            badamessage01_SFX.Play();
            // message01 ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
            StartCoroutine(DisplayMessage01());
        }
    }

    public void OnMessage02ButtonClick02()
    {
        if (isBongTimeActive == false && isGameRunning == true)
        {
            badamessage02_SFX.Play();
            // message02 ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
            StartCoroutine(DisplayMessage02());
        }
    }

    private IEnumerator DisplayMessage01()
    {
        // �޽��� ��� �� ���� �ð� �Ŀ� ����
        messageBg.SetActive(true);
        loveEffect.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        messageBg.SetActive(false);
        loveEffect.gameObject.SetActive(false);
    }


    private IEnumerator DisplayMessage02()
    {
        // �޽��� ��� �� ���� �ð� �Ŀ� ����
        messageBg02.SetActive(true);
        loveEffect.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        messageBg02.SetActive(false);
        loveEffect.gameObject.SetActive(false);
    }


    // ���� �Ͻ����� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void StopButtonClick()
    {
        if (isGameRunning && !isGamePaused)
        {
            // ���� �Ͻ�����
            PauseGame();
        }
        else if (isGameRunning && isGamePaused)
        {
            // ���� �簳
            ResumeGame();
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
