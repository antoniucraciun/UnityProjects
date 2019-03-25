using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource mainSource;
    public AudioSource menuSource;

    public List<AudioClip> mainClip;
    public List<AudioClip> menuClickSound;

    private float volume;

    private void Start()
    {
        volume = PlayerPrefs.GetFloat("Volume", 0.5f);
        mainSource.volume = volume;
        menuSource.volume = volume;
        PlayMainSound();
    }

    public void SetVolume(float vol)
    {
        volume = vol;
        mainSource.volume = volume;
        menuSource.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    public void PlayMenuSound()
    {
        int randClip = Random.Range(0, menuClickSound.Count);
        menuSource.clip = menuClickSound[randClip];
        menuSource.Play();
    }

    public void PlayMainSound()
    {
        int randClip = Random.Range(0, mainClip.Count);
        mainSource.clip = mainClip[randClip];
        mainSource.Play();
    }
}
