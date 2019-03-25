using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public bool changeMusic = false;
    public bool musicChanged = false;

    public static MusicManager instance;

    private void Start()
    {
        instance = this;
        AudioManager.instance.PlayMusic(menuMusic, 1);
    }

    private void Update()
    {
        if (changeMusic && !musicChanged)
        {
            AudioManager.instance.PlayMusic(gameMusic, 2);
            changeMusic = false;
            musicChanged = true;
        }
    }

}
