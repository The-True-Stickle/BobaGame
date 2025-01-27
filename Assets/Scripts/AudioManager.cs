using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioSourceType
{ 
    Music, Drinking, MachineWorking
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource musicSource;
    public AudioSource drinkingSource;
    public AudioSource machineWorkingSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip fireClip;
    public AudioClip hitTeethClip;
    public AudioClip drinkClip;
    public AudioClip drinksFinisedClip;
    public AudioClip enemyHitClip;
    public AudioClip footstepClip;
    public AudioClip inhaleClip;
    public AudioClip liftStrawClip;
    public AudioClip newCupClip;
    public AudioClip chokeClip;
    public AudioClip stabStrawClip;
    public AudioClip trashCanClip;


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

    public void PlaySource(AudioSourceType type)
    {
        switch(type)
        {
            case AudioSourceType.Drinking:
                drinkingSource.Play();
                break;
            case AudioSourceType.MachineWorking:
                machineWorkingSource.Play();
                break;
            case AudioSourceType.Music:
                musicSource.Play();
                break;
        }
    }

    public void StopSource(AudioSourceType type)
    {
        switch(type)
        {
            case AudioSourceType.Drinking:
                drinkingSource.Stop();
                break;
            case AudioSourceType.MachineWorking:
                machineWorkingSource.Stop();
                break;
            case AudioSourceType.Music:
                musicSource.Stop();
                break;
        }
	}
}

