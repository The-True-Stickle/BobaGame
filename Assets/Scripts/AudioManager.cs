using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip reloadClip;
    public AudioClip shootClip;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    public void PlayClip(AudioClip clip, float volume = 1)
    {
        sfxSource.volume = volume;
        sfxSource.PlayOneShot(clip);    
	}
}

