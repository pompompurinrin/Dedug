using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;
using UnityEditor.PackageManager.Requests;


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
        DataManager.Instance.ending1 = PlayerPrefs.GetInt("Ending1");
    }
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
        if (DataManager.Instance.first == 0)
        {
            DataManager.Instance.storyID = 0;
            PlayerPrefs.SetInt("StoryID", DataManager.Instance.storyID);
            SceneManager.LoadScene("StoryScene");

        }
        else if(DataManager.Instance.ending1 == 1)
        {
            Clear();
            SceneManager.LoadScene("HomeScene");
        }
        else
        {
            SceneManager.LoadScene("HomeScene");
        }
    }

    public void Clear()
    {
        DataManager.Instance.nowRank = 0;
        DataManager.Instance.nowGold = 0;
        DataManager.Instance.feverNum = 0;
        DataManager.Instance.goods1011 = 0;
        DataManager.Instance.goods2011 = 0;
        DataManager.Instance.goods3011 = 0;
        DataManager.Instance.goods1012 = 0;
        DataManager.Instance.goods2012 = 0;
        DataManager.Instance.goods3012 = 0;
        DataManager.Instance.goods1021 = 0;
        DataManager.Instance.goods2021 = 0;
        DataManager.Instance.goods3021 = 0;
        DataManager.Instance.goods1022 = 0;
        DataManager.Instance.goods2022 = 0;
        DataManager.Instance.goods3022 = 0;
        DataManager.Instance.goods1031 = 0;
        DataManager.Instance.goods2031 = 0;
        DataManager.Instance.goods3031 = 0;
        DataManager.Instance.goods1032 = 0;
        DataManager.Instance.goods2032 = 0;
        DataManager.Instance.goods3032 = 0;
        DataManager.Instance.goods1041 = 0;
        DataManager.Instance.goods2041 = 0;
        DataManager.Instance.goods3041 = 0;
        DataManager.Instance.goods1042 = 0;
        DataManager.Instance.goods2042 = 0;
        DataManager.Instance.goods3042 = 0;
        DataManager.Instance.goods1041 = 0;
        DataManager.Instance.goods2041 = 0;
        DataManager.Instance.goods3041 = 0;
        DataManager.Instance.goods1051 = 0;
        DataManager.Instance.goods2051 = 0;
        DataManager.Instance.goods3051 = 0;
        DataManager.Instance.goods1052 = 0;
        DataManager.Instance.goods2052 = 0;
        DataManager.Instance.goods3052 = 0;
        DataManager.Instance.goods4051 = 0;
        DataManager.Instance.goods4052 = 0;
        DataManager.Instance.goods4053 = 0;
        DataManager.Instance.goods4054 = 0;
        DataManager.Instance.goods4055 = 0;
        DataManager.Instance.goods4056 = 0;
        DataManager.Instance.goods4057 = 0;
        DataManager.Instance.goods4058 = 0;
        DataManager.Instance.goods4059 = 0;
        DataManager.Instance.goods4060 = 0;
        DataManager.Instance.story1_1 = 0;
        DataManager.Instance.story1_2 = 0;
        DataManager.Instance.story1_3 = 0;
        DataManager.Instance.story2_1 = 0;
        DataManager.Instance.story2_2 = 0;
        DataManager.Instance.story2_3 = 0;
        DataManager.Instance.story3_1 = 0;
        DataManager.Instance.story3_2 = 0;
        DataManager.Instance.story3_3 = 0;
        DataManager.Instance.story4_1 = 0;
        DataManager.Instance.story4_2 = 0;
        DataManager.Instance.story4_3 = 0;
        DataManager.Instance.storyID = 0;
        DataManager.Instance.first = 0;
        DataManager.Instance.firstHome = 0;
        DataManager.Instance.firstDG = 0;
        DataManager.Instance.firstGoodsBuy = 0;
        DataManager.Instance.firstRequest = 0;
        DataManager.Instance.firstRank = 0;
        DataManager.Instance.ending = 0;
        DataManager.Instance.ending1 = 0;
        Save();
    }
    public void Save()
    {
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        PlayerPrefs.SetInt("NowRank", DataManager.Instance.nowRank);
        PlayerPrefs.SetInt("FeverNum", DataManager.Instance.feverNum);
        PlayerPrefs.SetInt("StoryID", DataManager.Instance.storyID);
        PlayerPrefs.SetInt("Story1_1", DataManager.Instance.story1_1);
        PlayerPrefs.SetInt("Story1_2", DataManager.Instance.story1_2);
        PlayerPrefs.SetInt("Story1_3", DataManager.Instance.story1_2);
        PlayerPrefs.SetInt("Story2_1", DataManager.Instance.story2_1);
        PlayerPrefs.SetInt("Story2_2", DataManager.Instance.story2_2);
        PlayerPrefs.SetInt("Story2_3", DataManager.Instance.story2_2);
        PlayerPrefs.SetInt("Story3_1", DataManager.Instance.story3_1);
        PlayerPrefs.SetInt("Story3_2", DataManager.Instance.story3_2);
        PlayerPrefs.SetInt("Story3_3", DataManager.Instance.story3_3);
        PlayerPrefs.SetInt("Story4_1", DataManager.Instance.story4_1);
        PlayerPrefs.SetInt("Story4_2", DataManager.Instance.story4_2);
        PlayerPrefs.SetInt("Story4_3", DataManager.Instance.story4_3);
        PlayerPrefs.SetInt("Goods1011", DataManager.Instance.goods1011);
        PlayerPrefs.SetInt("Goods1012", DataManager.Instance.goods1012);
        PlayerPrefs.SetInt("Goods1021", DataManager.Instance.goods1021);
        PlayerPrefs.SetInt("Goods1022", DataManager.Instance.goods1022);
        PlayerPrefs.SetInt("Goods1031", DataManager.Instance.goods1031);
        PlayerPrefs.SetInt("Goods1032", DataManager.Instance.goods1032);
        PlayerPrefs.SetInt("Goods1041", DataManager.Instance.goods1041);
        PlayerPrefs.SetInt("Goods1042", DataManager.Instance.goods1042);
        PlayerPrefs.SetInt("Goods1051", DataManager.Instance.goods1051);
        PlayerPrefs.SetInt("Goods1052", DataManager.Instance.goods1052);
        PlayerPrefs.SetInt("Goods2011", DataManager.Instance.goods2011);
        PlayerPrefs.SetInt("Goods2012", DataManager.Instance.goods2012);
        PlayerPrefs.SetInt("Goods2021", DataManager.Instance.goods2021);
        PlayerPrefs.SetInt("Goods2022", DataManager.Instance.goods2022);
        PlayerPrefs.SetInt("Goods2031", DataManager.Instance.goods2031);
        PlayerPrefs.SetInt("Goods2032", DataManager.Instance.goods2032);
        PlayerPrefs.SetInt("Goods2041", DataManager.Instance.goods2041);
        PlayerPrefs.SetInt("Goods2042", DataManager.Instance.goods2042);
        PlayerPrefs.SetInt("Goods2051", DataManager.Instance.goods2051);
        PlayerPrefs.SetInt("Goods2052", DataManager.Instance.goods2052);
        PlayerPrefs.SetInt("Goods3011", DataManager.Instance.goods3011);
        PlayerPrefs.SetInt("Goods3012", DataManager.Instance.goods3012);
        PlayerPrefs.SetInt("Goods3021", DataManager.Instance.goods3021);
        PlayerPrefs.SetInt("Goods3022", DataManager.Instance.goods3022);
        PlayerPrefs.SetInt("Goods3031", DataManager.Instance.goods3031);
        PlayerPrefs.SetInt("Goods3032", DataManager.Instance.goods3032);
        PlayerPrefs.SetInt("Goods3041", DataManager.Instance.goods3041);
        PlayerPrefs.SetInt("Goods3042", DataManager.Instance.goods3042);
        PlayerPrefs.SetInt("Goods3051", DataManager.Instance.goods3051);
        PlayerPrefs.SetInt("Goods3052", DataManager.Instance.goods3052);

        PlayerPrefs.SetInt("Goods4051", DataManager.Instance.goods4051);
        PlayerPrefs.SetInt("Goods4052", DataManager.Instance.goods4052);
        PlayerPrefs.SetInt("Goods4053", DataManager.Instance.goods4053);
        PlayerPrefs.SetInt("Goods4054", DataManager.Instance.goods4054);
        PlayerPrefs.SetInt("Goods4055", DataManager.Instance.goods4055);
        PlayerPrefs.SetInt("Goods4056", DataManager.Instance.goods4056);
        PlayerPrefs.SetInt("Goods4057", DataManager.Instance.goods4057);
        PlayerPrefs.SetInt("Goods4058", DataManager.Instance.goods4058);
        PlayerPrefs.SetInt("Goods4059", DataManager.Instance.goods4059);
        PlayerPrefs.SetInt("Goods4060", DataManager.Instance.goods4060);

        PlayerPrefs.SetInt("First", DataManager.Instance.first);
        PlayerPrefs.SetInt("FirstDG", DataManager.Instance.firstDG);
        PlayerPrefs.SetInt("FirstHome", DataManager.Instance.firstHome);
        PlayerPrefs.SetInt("FirstGoodsBuy", DataManager.Instance.firstGoodsBuy);
        PlayerPrefs.SetInt("FirstRequest", DataManager.Instance.firstRequest);
        PlayerPrefs.SetInt("FirstRank", DataManager.Instance.firstRank);
        PlayerPrefs.SetInt("Ending", DataManager.Instance.ending);
        PlayerPrefs.SetInt("Ending1", DataManager.Instance.ending1);
        PlayerPrefs.SetInt("BGM", DataManager.Instance.bgm);
        PlayerPrefs.SetInt("SFX", DataManager.Instance.sfx);


        PlayerPrefs.Save();
    }
}
