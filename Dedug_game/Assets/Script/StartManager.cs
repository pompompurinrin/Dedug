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

    void Start()
    {
        StartCoroutine(BlinkImage());
        bgm1AudioSource.loop = true;
        bgm1AudioSource.Play();
        sfx1AudioSource.Stop();
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
        SceneManager.LoadScene("HomeScene");
        
    }

}
