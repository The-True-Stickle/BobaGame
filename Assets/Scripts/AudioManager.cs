using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip fireClip;
    public AudioClip hitTeethClip;
    public AudioClip drinkClip;
    public AudioClip enemyHitClip;
    public AudioClip footstepClip;
    public AudioClip inhaleClip;
    public AudioClip liftStrawClip;
    public AudioClip newCupClip;
    public AudioClip chokeClip;
    public AudioClip stabStrawClip;


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
        sfxSource.PlayOneShot(clip, volume);
        sfxSource.volume = volume;
	}

    public void SetClip(AudioSource source, AudioClip clip)
    {
        source.clip = clip;   
    }

    public void PlayCurrentClip(AudioSource source, bool loop = false)
    {
        source.loop = loop;
        source.Play();
	}

    public void StopCurrentClip(AudioSource source)
    {
        source.Stop();
	}
}

