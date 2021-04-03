using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;
//using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    #region Variables

    public AudioMixer volumeMixer;
    public AudioClip clip;
    AudioSource audioS;
    float lastVolume = 0f;
    bool isMute = false;

    public static MainMenuManager Instance { set; get; }
    public TMP_Text shipText;
    public TMP_Text coinsText;
    public TMP_Text gemsText;
    public TMP_Text unlockButtonText;
    public TMP_Text levelUpCostText;
    public TMP_Text levelText;
    public TMP_Text damageText;
    public TMP_Text healthText;
    public TMP_Text armorText;
    public TMP_Text playLeveltext;

    public TMP_Text commonChestCounter;
    public TMP_Text uncommonChestCounter;
    public TMP_Text rareChestCounter;
    public TMP_Text legendaryChestCounter;

    public Slider slider;

    public GameObject unlockButton;
    public GameObject loadingScreen;
    public SaveVars save;
    public Sprite[] ships;
    public Image shipDisplayImage;
    public Image muteImage;

    public int commonChestAmount = 0;
    public int uncommonChestAmount = 0;
    public int rareChestAmount = 0;
    public int legendaryChestAmount = 0;


    public int[] shipLevel;
    public bool[] isLocked = new bool[7];
    public string[] shipNames;
    public int totalCoins = 0;
    public int totalGems = 0;

    int index = 0;
    int levelIndex = 0;
    int reward = 5;
    int gemsRequiredPerLevel = 100;
    int coinsRequiredPerLevel = 300; //300 if armor

    public bool canSendNotification;
    public bool trial = false;
    #endregion

    private void Awake()
    {
        Instance = this;
        audioS = GetComponent<AudioSource>();
    }

    private void Start()
    {
        index = PlayerPrefs.GetInt("ShipIndex", 0);
        SetImageAndText(index);
        LoadInSave.Instace.Load();
        DisplayText(commonChestCounter, commonChestAmount.ToString());
        DisplayText(uncommonChestCounter, uncommonChestAmount.ToString());
        DisplayText(rareChestCounter, rareChestAmount.ToString());
        DisplayText(legendaryChestCounter, legendaryChestAmount.ToString());
    }

    public void Next()
    {
        index = ++index % ships.Length;
        SetImageAndText(index);
    }

    public void Previous()
    {
        index--;
        index = index < 0 ? ships.Length - Mathf.Abs(index) : index;
        SetImageAndText(index);
    }

    void SetImageAndText(int index)
    {
        shipDisplayImage.sprite = ships[index];
        PlayerSettings();
        DisplayText(levelUpCostText, (shipLevel[index] * coinsRequiredPerLevel).ToString());
        DisplayText(shipText, shipNames[index]);
        DisplayText(levelText, "Level: " + shipLevel[index].ToString());
        ManageStatDisplay();
        if (isLocked[index] == true)
        {
            unlockButton.SetActive(true);
            DisplayText(unlockButtonText, "UNLOCK\n" + (index * gemsRequiredPerLevel).ToString() + "\nGEMS");
        }
        else
            unlockButton.SetActive(false);
        GameManager.instance.shipIndex = index;
    }
    
    void PlayerSettings()
    {
        PlayerPrefs.SetInt("ShipIndex", index);
        PlayerPrefs.Save();
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

    public void PlayAd()
    {
        /*
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
            totalGems += reward;
        }
        LoadInSave.Instace.Save();
        LoadInSave.Instace.Load();
        DisplayText(gemsText, totalGems.ToString());
        */
    }
    public void IncreaseStats()
    {
        if (isLocked[index] == true)
            return;
        if (totalCoins - shipLevel[index] * coinsRequiredPerLevel < 0)
            return;
        totalCoins -= shipLevel[index] * coinsRequiredPerLevel;
        ++shipLevel[index];
        DisplayText(coinsText, totalCoins.ToString());
        DisplayText(levelText, shipLevel[index].ToString());
        switch (index)
        {
            case 0:
                save.shipHealth_1 += 50;
                save.shipDamage_1 += 5;
                save.shipArmor_1 += 25;
                break;
            case 1:
                save.shipHealth_2 += 50;
                save.shipDamage_2 += 5;
                save.shipArmor_2 += 25;
                break;
            case 2:
                save.shipHealth_3 += 50;
                save.shipDamage_3 += 5;
                save.shipArmor_3 += 25;
                break;
            case 3:
                save.shipHealth_4 += 50;
                save.shipDamage_4 += 5;
                save.shipArmor_4 += 25;
                break;
            case 4:
                save.shipHealth_5 += 50;
                save.shipDamage_5 += 5;
                save.shipArmor_5 += 25;
                break;
            case 5:
                save.shipHealth_6 += 50;
                save.shipDamage_6 += 5;
                save.shipArmor_6 += 25;
                break;
            case 6:
                save.shipHealth_7 += 50;
                save.shipDamage_7 += 5;
                save.shipArmor_7 += 25;
                break;
            default:
                break;
        }
        LoadInSave.Instace.Save();
        LoadInSave.Instace.Load();
        DisplayText(levelUpCostText, (shipLevel[index] * coinsRequiredPerLevel).ToString());
        ManageStatDisplay();
    }
    public void PlayMenuSoundEffect()
    {
        audioS.clip = clip;
        audioS.Play();
    }

    public void DisplayText(TMP_Text textToWrite, string message)
    {
        textToWrite.text = message;
    }

    public void Unlock()
    {
        //Manage the unlock
        if (isLocked[index])
        {
            if (totalGems - shipLevel[index] * gemsRequiredPerLevel < 0)
                return;
            totalGems -= shipLevel[index] * gemsRequiredPerLevel;
            DisplayText(coinsText, totalGems.ToString());
            isLocked[index] = false;
            unlockButton.SetActive(false);
            switch (index)
            {
                case 0:
                    save.isLocked_1 = false;
                    break;
                case 1:
                    save.isLocked_2 = false;
                    break;
                case 2:
                    save.isLocked_3 = false;
                    break;
                case 3:
                    save.isLocked_4 = false;
                    break;
                case 4:
                    save.isLocked_5 = false;
                    break;
                case 5:
                    save.isLocked_6 = false;
                    break;
                case 6:
                    save.isLocked_7 = false;
                    break;
            }
        }
        LoadInSave.Instace.Save();
        LoadInSave.Instace.Load();
    }

    void ManageStatDisplay()
    {
        //Display the right text for each ship
        switch (index)
        {
            case 0:
                DisplayText(healthText, save.shipHealth_1.ToString());
                DisplayText(damageText, save.shipDamage_1.ToString());
                DisplayText(armorText, save.shipArmor_1.ToString());
                break;
            case 1:
                DisplayText(healthText, save.shipHealth_2.ToString());
                DisplayText(damageText, save.shipDamage_2.ToString());
                DisplayText(armorText, save.shipArmor_2.ToString());
                break;
            case 2:
                DisplayText(healthText, save.shipHealth_3.ToString());
                DisplayText(damageText, save.shipDamage_3.ToString());
                DisplayText(armorText, save.shipArmor_3.ToString());
                break;
            case 3:
                DisplayText(healthText, save.shipHealth_4.ToString());
                DisplayText(damageText, save.shipDamage_4.ToString());
                DisplayText(armorText, save.shipArmor_4.ToString());
                break;
            case 4:
                DisplayText(healthText, save.shipHealth_5.ToString());
                DisplayText(damageText, save.shipDamage_5.ToString());
                DisplayText(armorText, save.shipArmor_5.ToString());
                break;
            case 5:
                DisplayText(healthText, save.shipHealth_6.ToString());
                DisplayText(damageText, save.shipDamage_6.ToString());
                DisplayText(armorText, save.shipArmor_6.ToString());
                break;
            case 6:
                DisplayText(healthText, save.shipHealth_7.ToString());
                DisplayText(damageText, save.shipDamage_7.ToString());
                DisplayText(armorText, save.shipArmor_7.ToString());
                break;
            default:
                break;
        }
    }

    public void PlayLevelText()
    {
        if (isLocked[GameManager.instance.shipIndex])
        {
            playLeveltext.text = "Trial";
            trial = true;
        }
        else
        {
            playLeveltext.text = "Play";
            trial = false;
        }
    }

    public void Select(int index)
    {
        levelIndex = index;
    }

    public void Play()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(levelIndex + 1);

        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
    }
}
