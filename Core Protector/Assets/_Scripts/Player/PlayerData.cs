using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public string playerName;

    public int level = 0;
    public int experience = 0;
    public int experienceRequired = 100;

    public int normalCurrency = 0;
    public int specialCurrency = 0;

    public TMP_Text playerNameText;
    public TMP_Text levelText;
    public Image progressImage;
    public TMP_Text normalCurrencyText;
    public TMP_Text specialCurrencyText;

    private void Awake()
    {
        playerName = PlayerPrefs.GetString("PlayerName", "New Player");
        LoadData();
    }

    public void AddExperience(int value)
    {
        experience += value;
        CheckForLevelUp();
    }

    public void CheckForLevelUp()
    {
        if (experience > experienceRequired)
        {
            experienceRequired +=  1000;
            level++;
        }
    }

    public float GetProgress()
    {
        CheckForLevelUp();
        return (float)experience / (float)experienceRequired;
    }

    public void IncreaseNormalCurrency(int value)
    {
        normalCurrency += value;
    }

    public void IncreaseSpecialCurrency(int value)
    {
        specialCurrency += value;
    }

    public bool DecreaseNormalCurrency(int value)
    {
        if (normalCurrency - value < 0)
            return false;
        normalCurrency -= value;
        return true;
    }

    public bool DecreaseSpecialCurrency(int value)
    {
        if (specialCurrency - value < 0)
            return false;
        specialCurrency -= value;
        return true;
    }

    public void SaveData()
    {
        Data.level = level;
        Data.experience = experience;
        Data.experienceRequired = experienceRequired;
        Data.normalCurrency = normalCurrency;
        Data.specialCurrency = specialCurrency;
        Data.Save();
    }

    public void LoadData()
    {
        level = Data.level;
        experience = Data.experience;
        experienceRequired = Data.experienceRequired;
        normalCurrency = Data.normalCurrency;
        specialCurrency = Data.specialCurrency;
    }
    
    public void NewName(string value)
    {
        playerName = value;
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
    }

    private void OnEnable()
    {
        SetData();
    }

    public void SetData()
    {
        playerNameText.text = playerName;
        levelText.text = level.ToString();
        progressImage.fillAmount = GetProgress();
        normalCurrencyText.text = normalCurrency.ToString();
        specialCurrencyText.text = specialCurrency.ToString();
    }
}
