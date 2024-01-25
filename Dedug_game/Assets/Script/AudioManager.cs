using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{

    // ������ǰ� ȿ������ �����ϱ� ���� ��ųʸ� �� AudioSource
    private Dictionary<string, AudioClip> BGMDict = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> SFXDict = new Dictionary<string, AudioClip>();
    private AudioSource BGMSource;
    private AudioSource SFXSource;

    private void Awake()
    {
        // ���� �� ���� �����Ǿ�� �ϴ� ������Ʈ���� ó���ϱ� ���� DontDestroyOnLoad ���
        DontDestroyOnLoad(gameObject);

        // ������ǰ� ȿ������ ó���� AudioSource �߰�
        BGMSource = gameObject.AddComponent<AudioSource>();
        SFXSource = gameObject.AddComponent<AudioSource>();
    }

    // ������� ���
    public void PlayBGM(string musicName)
    {
        if (BGMDict.ContainsKey(musicName))
        {
            BGMSource.clip = BGMDict[musicName];
            BGMSource.Play();
        }
        else
        {
            Debug.LogWarning("BGM '" + musicName + "' ����.");
        }
    }

    // ȿ���� ���
    public void PlaySFX(string soundName)
    {
        if (SFXDict.ContainsKey(soundName))
        {
            SFXSource.PlayOneShot(SFXDict[soundName]);
        }
        else
        {
            Debug.LogWarning("SFX '" + soundName + "' ����.");
        }
    }

    public void StopBGM(string musicName)
    {
        BGMSource.Stop();
       
    }

    // ȿ���� ���
    public void StopSFX(string soundName)
    {
        SFXSource.Stop();
        
    }

    // ������� �߰�
    public void AddBGM(string musicName, AudioClip musicClip)
    {
        if (!BGMDict.ContainsKey(musicName))
        {
            BGMDict.Add(musicName, musicClip);
        }
        else
        {
            Debug.LogWarning("BGM '" + musicName + "' �̹� ����.");
        }
    }

    // ȿ���� �߰�
    public void AddSFX(string soundName, AudioClip soundClip)
    {
        if (!SFXDict.ContainsKey(soundName))
        {
            SFXDict.Add(soundName, soundClip);
        }
        else
        {
            Debug.LogWarning("SFX '" + soundName + "' �̹� ����.");
        }
    }
}
    


