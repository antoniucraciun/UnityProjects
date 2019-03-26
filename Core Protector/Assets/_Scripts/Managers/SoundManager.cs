using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider sfxSlider;
    public Slider musicSlider;
    public AudioSource musicSource;

    bool sfxMuted = false;
    float sfxVolume = 1;
    bool musicMuted = false;
    float musicVolume;

    private void Start()
    {
        sfxVolume = PlayerPrefs.GetFloat("sfxVolume", 0.5f);
        musicVolume = PlayerPrefs.GetFloat("musicVolume", 0.5f);
        int sfxMute = PlayerPrefs.GetInt("sfxMute", 0);
        int musicMute = PlayerPrefs.GetInt("musicMute", 0);
        sfxMuted = sfxMute == 0 ? false : true;
        musicMuted = musicMute == 0 ? false : true;
        MuteSFX(sfxMuted);
        MuteMusic(musicMuted);
        SFXVolume(sfxVolume);
        MusicVolume(musicVolume);
        sfxSlider.value = sfxVolume;
        musicSlider.value = musicVolume;
    }

    public void MuteSFX(bool mute)
    {
        sfxMuted = mute;
        SaveVolume();
    }

    public void MuteMusic(bool mute)
    {
        musicSource.mute = mute;
        musicMuted = mute;
        SaveVolume();
    }

    public void SFXVolume(float volume)
    {
        sfxVolume = volume;
        SaveVolume();
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
        musicVolume = volume;
        SaveVolume();
    }

    public void PlaySFXSound(AudioClip clip, Vector3 position)
    {
        if (!sfxMuted)
            AudioSource.PlayClipAtPoint(clip, position, sfxVolume);
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        int sfxMute = sfxMuted == false ? 0 : 1;
        int musicMute = musicMuted == false ? 0 : 1;
        PlayerPrefs.SetInt("sfxMute", sfxMute);
        PlayerPrefs.SetInt("musicMute", musicMute);
        PlayerPrefs.Save();
    }
}
