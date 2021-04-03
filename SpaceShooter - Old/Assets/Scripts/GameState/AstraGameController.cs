using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class AstraGameController : MonoBehaviour
{
    public static AstraGameController instance;
    public static int astraEnemiesKilled;
    public static int astraBossKilled;
    public TMP_Text scoreText;

    public Slider healthBar;
    public Slider armorBar;

    public GameObject exitBox;
    public GameObject pauseBox;
    public GameObject replayBox;

    public AudioMixer volumeMixer;
    public Image muteImage;
    public SaveVars save;

    GameManager manager;
    int score = 0;
    public bool canClickOther = true;
    bool isMute;
    float lastVolume;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        manager = GameManager.instance;
        UpdateScore(0);
    }

    private void OnDestroy()
    {
        save.astraEnemiesKilled = astraEnemiesKilled;
        save.astraBossKills = astraBossKilled;
    }

    private void Start()
    {
        SetPlayer();
    }

    public void SetPlayer()
    {
        healthBar.minValue = 0;
        healthBar.maxValue = manager.player.GetComponent<PlayerHealth>().GetCurrentHealth();
        healthBar.value = healthBar.maxValue;
        armorBar.minValue = 0;
        armorBar.maxValue = manager.player.GetComponent<PlayerHealth>().GetCurrentArmor();
        armorBar.value = armorBar.maxValue;
    }

    public void UpdateUi()
    {
        //update the armor and health bar
        healthBar.value = manager.player.GetComponent<PlayerHealth>().GetCurrentHealth();
        armorBar.value = manager.player.GetComponent<PlayerHealth>().GetCurrentArmor();
    }

    public void UpdateScore(int value)
    {
        //increase value of score and display it
        score += value;
        GameManager.instance.score = score;
        scoreText.text = "Score: " + score.ToString();
    }

    public void NukeButton()
    {
        if (canClickOther == false)
            return;
        //deactivate button for some time
        //spawn rockets
    }

    public void DoubleDamage()
    {
        if (canClickOther == false)
            return;
        //deactivate button
        //increase damage for some time
    }

    public void RechargeArmor()
    {
        if (canClickOther == false)
            return;
        //deactivate button for some time
        //put armor to max value
    }

    public void ExitButton()
    {
        if (canClickOther == false)
            return;
        canClickOther = false;
        //pause game
        exitBox.SetActive(true);
        Time.timeScale = 0;
    }

    public void ExitApprove()
    {
        //do loading screen
        SceneManager.LoadScene(0);
    }

    public void ReloadLevel()
    {
        if (canClickOther == false)
            return;
        canClickOther = false;
        replayBox.SetActive(true);
        //pause game
        Time.timeScale = 0;
    }

    public void PauseGame()
    {
        if (canClickOther == false)
            return;
        canClickOther = false;
        pauseBox.SetActive(true);
        //pause game
        Time.timeScale = 0;
    }

    public void Resume()
    {
        canClickOther = true;
        Time.timeScale = 1;
    }

    public void SetVolume(float volume)
    {
        volumeMixer.SetFloat("Volume", volume);
        if (isMute != true)
            lastVolume = volume;
    }

    public void SetMute(bool mute)
    {
        isMute = mute;
        if (isMute == true)
        {
            SetVolume(-80);
        }
        else if (isMute == false)
        {
            SetVolume(lastVolume);
        }
        muteImage.enabled = mute ? false : true;
    }
}
