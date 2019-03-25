using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public enum AudioChannel
    {
        Master,
        Sfx,
        Music
    }

    public float masterVolumePercent { get; private set; }
    public float sfxVolumePercent { get; private set; }
    public float musicVolumePercent { get; private set; }
    
    AudioSource[] musicSources;
    int activeMusicSourceIndex = 0;

    public static AudioManager instance;
    Transform audioListener;
    Transform playerT;

    SoundLibrary library;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        library = GetComponent<SoundLibrary>();
        audioListener = FindObjectOfType<AudioListener>().transform;

        musicSources = new AudioSource[2];
        for (int i = 0; i < 2; i++)
        {
            GameObject newMusicSource = new GameObject("MusicSource " + (i + 1));
            musicSources[i] = newMusicSource.AddComponent<AudioSource>();
            musicSources[i].loop = true;
            newMusicSource.transform.parent = transform;
        }

        masterVolumePercent = PlayerPrefs.GetFloat("master volume");
        sfxVolumePercent = PlayerPrefs.GetFloat("sfx volume");
        musicVolumePercent = PlayerPrefs.GetFloat("music volume");
    }

    private void Update()
    {
        musicSources[activeMusicSourceIndex].volume = masterVolumePercent * musicVolumePercent;
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            playerT = Camera.main.transform;
            return;
        }
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
        if (playerT != null)
        {
            audioListener.position = playerT.position;
            audioListener.rotation = playerT.rotation;
        }
        
    }

    public void SetVolume(float volumePercent, AudioChannel channel)
    {
        switch (channel)
        {
            case AudioChannel.Master: masterVolumePercent = volumePercent;
                break;
            case AudioChannel.Sfx: sfxVolumePercent = volumePercent;
                break;
            case AudioChannel.Music: musicVolumePercent = volumePercent;
                break;
        }

        PlayerPrefs.SetFloat("master volume", masterVolumePercent);
        PlayerPrefs.SetFloat("sfx volume", sfxVolumePercent);
        PlayerPrefs.SetFloat("music volume", musicVolumePercent);
        PlayerPrefs.Save();
    }

    public void PlayMusic(AudioClip musicClip, float fadeDuration = 1f)
    {
        activeMusicSourceIndex = 1 - activeMusicSourceIndex;
        musicSources[activeMusicSourceIndex].clip = musicClip;
        musicSources[activeMusicSourceIndex].Play();
        StartCoroutine(CrossFadeMusic(fadeDuration));
    }

    public void PlaySound(AudioClip clip, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(clip, position, sfxVolumePercent * masterVolumePercent);
    }

    public void PlaySound(string soundName, Vector3 position)
    {
        PlaySound(library.GetClipFromName(soundName), position);
    }

    IEnumerator CrossFadeMusic(float duration)
    {
        float percent = 0;

        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / duration;
            musicSources[activeMusicSourceIndex].volume = Mathf.Lerp(0, musicVolumePercent * masterVolumePercent, percent);
            musicSources[1 - activeMusicSourceIndex].volume = Mathf.Lerp(musicVolumePercent * masterVolumePercent, 0, percent);
            yield return null;
        }
    }
}
