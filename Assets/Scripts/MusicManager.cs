using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MusicManager : MonoBehaviour
{
    public const float DEFAULT_MUSIC_VOLUME = 0.3f;
    public const float DEFAULT_SFX_VOLUME = 1;
    
    public const  string MUSIC_VOLUME = "musicVolume";
    public const string SFX_VOLUME = "sfxVolume";
    
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource[] sfxAudioSourceArray;

    private void Start()
    {
        SetMusicVolume();
        SetSFXVolume();
    }

    private void SetMusicVolume()
    {
        float musicVolume;
        if (PlayerPrefs.HasKey(MUSIC_VOLUME))
        {
            musicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME);
        }
        else
        {
            musicVolume = DEFAULT_MUSIC_VOLUME;
        }

        musicAudioSource.volume = musicVolume;
    }
    
    private void SetSFXVolume()
    {
        float sfxVolume;
        if (PlayerPrefs.HasKey(SFX_VOLUME))
        {
            sfxVolume = PlayerPrefs.GetFloat(SFX_VOLUME);
        }
        else
        {
            sfxVolume = DEFAULT_SFX_VOLUME;
        }

        foreach (AudioSource sfx in sfxAudioSourceArray)
        {
            sfx.volume = sfxVolume;
        }
        
    }
}
