using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource gunShot;
    float volume;
    public AudioClip[] musicArray;
    public AudioClip playerShot;
    public AudioClip enemyShot;
    public AudioClip buttonClick;
    public Slider vol;
    public bool muteShots = false;

    private void Start()
    {
        music.clip = musicArray[Random.Range(0, musicArray.Length)];
        volume = PlayerPrefs.GetFloat("volume", 0.5f);
        music.Play();
        music.volume = volume;
        vol.value = volume;
        muteShots = PlayerPrefs.GetInt("muteShots", 0) == 1;
    }

    public void SetVolume(float value)
    {
        music.volume = value;
        volume = value;
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }

    public void PlayPlayerSound()
    {
        gunShot.PlayOneShot(playerShot, Random.Range(volume/2,volume));
        gunShot.pitch = Random.Range(0.95f, 1.15f);
        gunShot.mute = muteShots;
    }

    public void PlayEnemySound()
    {
        gunShot.PlayOneShot(enemyShot, Random.Range(volume / 2, volume));
        gunShot.pitch = Random.Range(0.95f, 1.15f);
        gunShot.mute = muteShots;
    }

    public void ToggleMute(bool isMuted)
    {
        muteShots = isMuted;
        if (muteShots)
            PlayerPrefs.SetInt("shotsMuted", 1);
        else
            PlayerPrefs.SetInt("shotsMuted", 0);
        PlayerPrefs.Save();
    }

    public void ButtonClicked()
    {
        gunShot.PlayOneShot(buttonClick);
        gunShot.mute = muteShots;
    }
}
