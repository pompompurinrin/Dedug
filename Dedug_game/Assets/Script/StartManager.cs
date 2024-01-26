using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartManager : MonoBehaviour
{
    public Image StartImage;
    private bool isBlinking = false;
    public AudioSource sfx1AudioSource;
    public AudioSource bgm1AudioSource;

    public TopbarManager topbarManager;

    private void Awake()
    {
        DataManager.Instance.storyID = PlayerPrefs.GetInt("StoryID");
        DataManager.Instance.first = PlayerPrefs.GetInt("First");
    }
    void Start()
    {
        StartCoroutine(BlinkImage());
        bgm1AudioSource.loop = true;
        bgm1AudioSource.Play();
        sfx1AudioSource.Stop();
    }

   public void ClearClick()
    {
        topbarManager.Clear();
    }
    IEnumerator BlinkImage()
    {
        while (true)
        {
            StartImage.enabled = !StartImage.enabled;
            yield return new WaitForSeconds(0.5f);
        }
    }

    // ���ϴ� ���� �����̴� ������ �����ϰų� �����ϴ� �Լ�
    public void ToggleBlinking(bool shouldBlink)
    {
        if (shouldBlink && !isBlinking)
        {
            isBlinking = true;
            StartCoroutine(BlinkImage());
        }
        else if (!shouldBlink && isBlinking)
        {
            isBlinking = false;
            StopCoroutine("BlinkImage");
            StartImage.enabled = true; // �����̱⸦ �����ϸ� �̹����� Ȱ��ȭ ���·� ����
        }
    }



    public void TouchToStart()
    {

        sfx1AudioSource.Play();
        if (DataManager.Instance.first == 0)
        {
            DataManager.Instance.storyID = 0;
            PlayerPrefs.SetInt("StoryID", DataManager.Instance.storyID);
            SceneManager.LoadScene("StoryScene");

        }
        else
        {
            SceneManager.LoadScene("HomeScene");
        }
    }

}
