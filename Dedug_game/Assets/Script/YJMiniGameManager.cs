using System.Collections;
using System.Collections.Generic;
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

    // �޽��� Ÿ�� ��� �ؽ�Ʈ �� ����Ʈ
    public Text messageText;
    public Image loveEffect;

    // ������ Ÿ�̹� ���� �̹���
    public Image success;
    public Image fail;

    // ���� ���ð� ī��Ʈ
    public Text beforeCount;

    // �̴ϰ��� ž �� ���� ���� (����, ���ѽð�)
    public Text costText;
    public Text countDown;

    // �����ҳ� ĳ���� �� ����(���ΰ�) �ִϸ��̼� �̹���
    public Image badaChar;
    public Image meChar;

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
    int score;
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

    private void Start()
    {
        // ���� ���� �� ȣ��Ǵ� �Լ�
        StartGame();
    }

    private void StartGame()
    {
        // ���� ���ð� �ʱ�ȭ �� ���ð� UI Ȱ��ȭ
        beforeGameTime = 3;
        beforeCount.gameObject.SetActive(true);
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
            // CountDownBeforeGame ȣ�� �ߴ�
            CancelInvoke("CountDownBeforeGame");

            // ���� ���� ����
            StartRealTimeGame();
        }
        else
        {
            // ���ð� �ؽ�Ʈ ����
            beforeCount.text = beforeGameTime.ToString();
        }
    }

    // ���� ����
    private void StartRealTimeGame()
    {
        // ���� ���� ����
        isGameRunning = true;
        // �ʱ� ���ѽð� ����
        gameTime = 90;
        countDown.text = gameTime.ToString();
        // 1�ʸ��� UpdateGame �޼ҵ� ȣ��
        InvokeRepeating("UpdateGame", 1.0f, 1.0f);
        // BGM ��� �� ���� ���� ���� ���� �߰� �ʿ�

    }


    private void UpdateGame()
    {
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
        if (gameTime >= 60 && gameTime % 6 == 0)
        {
            ActivateRandomColorEffect();
            isBongTimeActive = true;

            // bongTime �� �Ŀ� �ƹ� ��ư�� Ŭ������ �ʾ��� �� ó���� ���� Invoke ȣ��
            Invoke("HandleButtonClick", bongTime);
        }

        // (5) countDown < 60�� ���
        if (gameTime < 60 && gameTime % 10 == 0)
        {
            // 10�ʸ��� ������ colorEffect�� 2���� �̹����� 3�� ���� Ȱ��ȭ �� ��Ȱ��ȭ
            StartCoroutine(ActivateRandomColorEffects());
        }


        // 3. ���� ��ư Ŭ�� ó��
        if (Input.GetMouseButtonDown(0))
        {
            HandleButtonClick();
        }
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
            yield return new WaitForSeconds(1.5f);

            // �����ϴ� bong ��ư�� expectedBongButtons�� ����
            expectedBongButtons.Enqueue(GetMatchingBongButton(randomColorEffect));

            // ��Ȱ��ȭ
            randomColorEffect.gameObject.SetActive(false);
        }

        // (5)���� ������ ��� 3�� ���ȸ� hardBongTimeNext�� �����
        isHardBongTimeActive = true;
        hardStart.gameObject.SetActive(true); // hardStart�� Ȱ��ȭ
        Invoke("DeactivateHardBongTime", hardBongTimeNext);

        yield return new WaitForSeconds(hardBongTimeNext);

        // hardBongTimeNext�� ���� �� isHardBongTimeActive = false�� �ϰ� ���ÿ� hardStart�� ��Ȱ��ȭ
        isHardBongTimeActive = false;
        hardStart.gameObject.SetActive(false);

        // hardBongTime�� ����Ǹ� �ٽ� activeColorEffects�� ���
        activeColorEffects.Clear();
    }

    // �ϵ� �� Ÿ�� ���� ó��
    private void DeactivateHardBongTime()
    {
        isHardBongTimeActive = false;
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
        Invoke("DeactivateColorEffect", bongTime);
    }

    // �Ϲ� ��Ÿ�� �÷� ����Ʈ ���� �̱�
    private Image GetRandomColorEffect()
    {
        // ������ colorEffect ��ȯ
        int randomIndex = Random.Range(1, 4);
        switch (randomIndex)
        {
            case 1:
                return colorEffect01;
            case 2:
                return colorEffect02;
            case 3:
                return colorEffect03;
            default:
                return colorEffect01;
        }
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
                Invoke("DeactivateFailImage", 2.0f);
            }
        }


        // ���� ���� üũ
        CheckGameEnd();

    }

    // �ϵ� ������ Ÿ�� ��ư Ŭ�� �Լ�
    private void CheckUserInput()
    {
        if (expectedBongButtons.Count > 0)
        {
            Button expectedButton = expectedBongButtons.Dequeue(); // ť���� ��ư�� ������� ������

            if (EventSystem.current.currentSelectedGameObject == expectedButton.gameObject)
            {
                // ��ư�� �ùٸ� ������ Ŭ���Ǿ��� ��
                score++;
                costText.text = score.ToString();

                // ���� �̹��� Ȱ��ȭ
                success.gameObject.SetActive(true);
                Invoke("DeactivateSuccessImage", 0.5f);
            }
            else
            {
                // ��ư�� �߸� Ŭ���Ǿ��� ��
                score--;
                costText.text = score.ToString();

                // ���� �̹��� Ȱ��ȭ
                fail.gameObject.SetActive(true);
                Invoke("DeactivateFailImage", 0.5f);
            }

            // UI ������Ʈ
            UpdateUI();
        }
    }

    // �Ϲ� ��Ÿ�� ���� �� Ŭ�� �˻�
    public void OnBongButtonClick(Button bongButton)
    {

        // bongTime�� ���� ���� ���� ó��
        if (isBongTimeActive == true)
        {
            // Ȱ��ȭ�� colorEffect�� �����Ǵ� bong ��ư���� Ȯ��
            if (IsMatchingBongButton(bongButton))
            {
                // ������ ���
                score++;
                costText.text = score.ToString();

                // ���� �̹��� Ȱ��ȭ
                success.gameObject.SetActive(true);
                Invoke("DeactivateSuccessImage", 2.0f);
            }
            else
            {
                // ������ ���
                score--;
                costText.text = score.ToString();

                // ���� �̹��� Ȱ��ȭ
                fail.gameObject.SetActive(true);
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
        // ���� ���� �� ȣ��Ǵ� �Լ�
        endBg.SetActive(true);
        isGameRunning = false;
    }

    public void OnMessage01ButtonClick()
    {
        if (isBongTimeActive == false && isGameRunning == true)
        {
            // message01 ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
            StartCoroutine(DisplayMessage("message01"));
        }
    }

    public void OnMessage02ButtonClick()
    {
        if (isBongTimeActive == false && isGameRunning == true)
        {
            // message02 ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
            StartCoroutine(DisplayMessage("message02"));
        }
    }

    private IEnumerator DisplayMessage(string message)
    {
        // �޽��� ��� �� ���� �ð� �Ŀ� ����
        messageBg.SetActive(true);
        messageText.text = message;
        loveEffect.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        messageBg.SetActive(false);
        messageText.text = "";
        loveEffect.gameObject.SetActive(false);
    }
}
