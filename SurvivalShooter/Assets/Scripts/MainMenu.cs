using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour {
    
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public Slider[] volumeSliders;
    public Toggle[] resolutionToggle;
    public int[] screenWidths;
    
    public bool canPressEscAgain = true;

    int activeScreenResIndex;

    private void Start()
    {
        activeScreenResIndex = PlayerPrefs.GetInt("screen res");
        bool isFullScreen = (PlayerPrefs.GetInt("full screen") == 1) ? true : false;

        volumeSliders[0].value = AudioManager.instance.masterVolumePercent;
        volumeSliders[1].value = AudioManager.instance.musicVolumePercent;
        volumeSliders[2].value = AudioManager.instance.sfxVolumePercent;

        for (int i = 0; i < resolutionToggle.Length; i++)
        {
            resolutionToggle[i].isOn = i == activeScreenResIndex;
        }

        SetFullscreen(isFullScreen);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPressEscAgain)
        {
            Time.timeScale = 0;
            mainMenu.SetActive(true);
        }
        
    }

    public void PlayGame()
    {
        MusicManager.instance.changeMusic = true;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        canPressEscAgain = false;
    }

    public void Resume()
    {
        mainMenu.SetActive(false);
        Time.timeScale = 1;
        canPressEscAgain = true;
    }

    public void Back()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetScreenResolution(int index)
    {
        if (resolutionToggle[index].isOn)
        {
            activeScreenResIndex = index;
            float aspectRatio = 16 / 9;
            Screen.SetResolution(screenWidths[index], (int)(screenWidths[index] * aspectRatio), false);
            PlayerPrefs.SetInt("screen res", activeScreenResIndex);
            PlayerPrefs.Save();
        }
    }
    
    public void SetFullscreen(bool isFullscreen)
    {
        for (int i = 0; i < resolutionToggle.Length; i++)
        {
            resolutionToggle[i].interactable = !isFullscreen;
        }

        if (isFullscreen)
        {
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolution = allResolutions[allResolutions.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);
        }
        else
        {
            SetScreenResolution(activeScreenResIndex);
        }

        PlayerPrefs.SetInt("full screen", ((isFullscreen) ? 1:0));
        PlayerPrefs.Save();
    }

    public void SetMasterVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Master);
    }

    public void SetMusicVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
    }

    public void SetSFXVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Sfx);
    }
}