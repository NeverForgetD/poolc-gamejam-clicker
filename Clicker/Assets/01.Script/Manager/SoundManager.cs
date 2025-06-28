using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singleton&Init
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        Init();
        InitAudioSource();
    }

    private void Init()
    {
        if (Instance == null)
        {
            Instance = this;
            // 씬 전환 시 파괴되지 않도록 설정 (필요 시)
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InitAudioSource()
    {
        if (bgmSource == null)
        {
            bgmSource = gameObject.AddComponent<AudioSource>();
            bgmSource.loop = true;
        }

        if (sfxSource == null)
            sfxSource = gameObject.AddComponent<AudioSource>();
    }
    #endregion

    #region Privates
    AudioSource bgmSource;
    AudioSource sfxSource;

    bool isBGMPlaying = false;
    #endregion

    #region Dependencies
    [Header("Sound Database")]
    [SerializeField] SoundDB soundDB;
    #endregion

    #region Sound Play Util
    // MP3 Player   -> AudioSource
    // MP3 음원   -> AudioClip
    // 관객(귀)    -> AudioListner

    /// <summary>
    /// BGM 재생
    /// </summary>
    /// <param name="bgmName"></param>
    public void PlayBGM(string bgmName)
    {
        if (isBGMPlaying)
            return;

        SoundData bgm = FindSound(soundDB.bgmList, bgmName); // 검색
        if (bgm != null)
        {
            bgmSource.clip = bgm.audioClip;
            bgmSource.volume = bgm.volume;
            bgmSource.Play();
            isBGMPlaying = true;
        }
        else
        {
            Debug.Log($"Failed to find sound data_BGM : {bgmName}");
        }
    }

    public void StopBGM()
    {
        if (!isBGMPlaying)
            return;
        bgmSource.Stop();
        isBGMPlaying = false;
    }

    /// <summary>
    /// SFX 재생
    /// </summary>
    /// <param name="sfxName"></param>
    public void PlaySFX(string sfxName)
    {
        SoundData sfx = FindSound(soundDB.sfxList, sfxName); // 검색
        if (sfx == null)
        {
            Debug.Log($"Failed to find sound data_SFX : {sfxName}");
        }
        else
        {
            sfxSource.pitch = sfx.pitch;
            sfxSource.volume = sfx.volume;
            sfxSource.PlayOneShot(sfx.audioClip);
        }
    }

    public void PlaySFXRandomPitch(string sfxName, float minPitch, float maxPitch)
    {
        SoundData sfx = FindSound(soundDB.sfxList, sfxName); // 검색
        if (sfx == null)
        {
            Debug.Log($"Failed to find sound data_SFX : {sfxName}");
        }
        else
        {
            //sfxSource.pitch = sfx.pitch;
            sfxSource.pitch = Random.Range(minPitch, maxPitch);
            sfxSource.volume = sfx.volume;
            sfxSource.PlayOneShot(sfx.audioClip);
        }
    }

    /// <summary>
    /// SoundData 배열에서 해당 이름의 sound data를 검색
    /// </summary>
    /// <param name="soundList"></param>
    /// <param name="soundName"></param>
    /// <returns></returns>
    private SoundData FindSound(SoundData[] soundList, string soundName)
    {
        if (soundDB == null)
        {
            Debug.Log("Can't Find SoundDb");
        }

        foreach (SoundData sound in soundList)
        {
            if (sound.soundName == soundName) // 이름 비교
            {
                return sound;
            }
        }
        return null;
    }

    /// <summary>
    /// SFX가 재생 중인지 확인
    /// </summary>
    /// <returns></returns>
    public bool IsSfxPlaying()
    {
        return sfxSource.isPlaying;
    }
    /*
    /// <summary>
    /// SFX 재생 끝날 때까지 대시
    /// </summary>
    /// <returns></returns>
    public async Task WaitForSfxEnd()
    {
        while (sfxSource.isPlaying)
        {
            await Task.Yield();
        }
    }
    */
    #endregion
}