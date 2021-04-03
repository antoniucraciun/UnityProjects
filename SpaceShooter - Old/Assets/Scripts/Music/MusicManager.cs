using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class MusicRepository
{
    public string name;
    public AudioClip[] clips;
}

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { set; get; }
    public MusicRepository[] mr;
    public AudioMixer am;

    public AudioClip clip;

    AudioSource audioS;
    float volume = 0;
    float diff = 0;
    //float lastVolume = 0;
    //bool isMute = false;
    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
        DontDestroyOnLoad(gameObject);
        audioS = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayClip(mr[0].clips[Random.Range(0, mr[0].clips.Length)]);
    }

    public void PlayClip(AudioClip clip)
    {
        audioS.clip = clip;
        audioS.Play();
    }
    
    public void PlayClipAtLocation(AudioClip clip, Transform location)
    {
        am.GetFloat("Volume", out volume);
        if (volume < 0)
            diff = -80 - volume;
        volume = Mathf.Abs(diff);
        volume = Mathf.Clamp01((volume / 100) - 0.2f);
        AudioSource.PlayClipAtPoint(clip, location.position, volume);
    }

    public void PlayMenuSoundEffect()
    {
        //audioS.clip = clip;
        //audioS.Play();
    }

    /*
    public void SetVolume(float volume)
    {
        am.SetFloat("Volume", volume);
        if (isMute != true)
            lastVolume = volume;
    }
    */
}
