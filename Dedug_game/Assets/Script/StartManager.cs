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

    // 원하는 때에 깜빡이는 동작을 시작하거나 중지하는 함수
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
            StartImage.enabled = true; // 깜빡이기를 중지하면 이미지를 활성화 상태로 유지
        }
    }



    public void TouchToStart()
    {
        sfx1AudioSource.Play();
        SceneManager.LoadScene("HomeScene");
        
    }

}
