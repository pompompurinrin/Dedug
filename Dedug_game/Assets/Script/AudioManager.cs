using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{

    // 배경음악과 효과음을 관리하기 위한 딕셔너리 및 AudioSource
    private Dictionary<string, AudioClip> BGMDict = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> SFXDict = new Dictionary<string, AudioClip>();
    private AudioSource BGMSource;
    private AudioSource SFXSource;

    private void Awake()
    {
        // 여러 씬 간에 유지되어야 하는 오브젝트들을 처리하기 위해 DontDestroyOnLoad 사용
        DontDestroyOnLoad(gameObject);

        // 배경음악과 효과음을 처리할 AudioSource 추가
        BGMSource = gameObject.AddComponent<AudioSource>();
        SFXSource = gameObject.AddComponent<AudioSource>();
    }

    // 배경음악 재생
    public void PlayBGM(string musicName)
    {
        if (BGMDict.ContainsKey(musicName))
        {
            BGMSource.clip = BGMDict[musicName];
            BGMSource.Play();
        }
        else
        {
            Debug.LogWarning("BGM '" + musicName + "' 없음.");
        }
    }

    // 효과음 재생
    public void PlaySFX(string soundName)
    {
        if (SFXDict.ContainsKey(soundName))
        {
            SFXSource.PlayOneShot(SFXDict[soundName]);
        }
        else
        {
            Debug.LogWarning("SFX '" + soundName + "' 없음.");
        }
    }

    public void StopBGM(string musicName)
    {
        BGMSource.Stop();
       
    }

    // 효과음 재생
    public void StopSFX(string soundName)
    {
        SFXSource.Stop();
        
    }

    // 배경음악 추가
    public void AddBGM(string musicName, AudioClip musicClip)
    {
        if (!BGMDict.ContainsKey(musicName))
        {
            BGMDict.Add(musicName, musicClip);
        }
        else
        {
            Debug.LogWarning("BGM '" + musicName + "' 이미 있음.");
        }
    }

    // 효과음 추가
    public void AddSFX(string soundName, AudioClip soundClip)
    {
        if (!SFXDict.ContainsKey(soundName))
        {
            SFXDict.Add(soundName, soundClip);
        }
        else
        {
            Debug.LogWarning("SFX '" + soundName + "' 이미 있음.");
        }
    }
}
    


