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

    private bool isGameRunning = false;
    private float bongTime = 2.0f;
    private bool isBongTimeActive = false;

    private void Start()
    {
        // ���� ���� �� ȣ��Ǵ� �Լ�
        StartGame();
    }

    private void StartGame()
    {
        // ���� ���ð� �ʱ�ȭ
        beforeGameTime = 3;
        beforeCount.gameObject.SetActive(true);
        // 1�ʸ��� CountDownBeforeGame �޼ҵ� ȣ��
        InvokeRepeating("CountDownBeforeGame", 1.0f, 1.0f);
    }

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

        // 3. ���� ��ư Ŭ�� ó��
        if (Input.GetMouseButtonDown(0))
        {
            HandleButtonClick();
        }
    }

    private void ActivateRandomColorEffect()
    {
        // ������ colorEffect Ȱ��ȭ �� ���� �ð� �Ŀ� ��Ȱ��ȭ
        Image randomColorEffect = GetRandomColorEffect();
        randomColorEffect.gameObject.SetActive(true);
        Invoke("DeactivateColorEffect", bongTime);
    }

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

    private void HandleButtonClick()
    {
        // Ŭ���� ��ư�� ���� ó��
        if (EventSystem.current.currentSelectedGameObject == bong01.gameObject)
        {
            OnBongButtonClick(bong01);
        }
        else if (EventSystem.current.currentSelectedGameObject == bong02.gameObject)
        {
            OnBongButtonClick(bong02);
        }
        else if (EventSystem.current.currentSelectedGameObject == bong03.gameObject)
        {
            OnBongButtonClick(bong03);
        }
        else if (EventSystem.current.currentSelectedGameObject == message01.gameObject)
        {
            OnMessage01ButtonClick();
        }
        else if (EventSystem.current.currentSelectedGameObject == message02.gameObject)
        {
            OnMessage02ButtonClick();
        }

        // ���� ���� üũ
        CheckGameEnd();
    }

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
        // message01 ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
        StartCoroutine(DisplayMessage("message01"));
    }

    public void OnMessage02ButtonClick()
    {
        // message02 ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
        StartCoroutine(DisplayMessage("message02"));
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
