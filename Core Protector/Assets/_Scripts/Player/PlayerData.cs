using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

#pragma warning disable

public class PlayerData : MonoBehaviour
{
    public string playerName;

    public int level = 0;

    public int experience = 0;
    public int experienceRequired = 1000;

    public int normalCurrency = 0;
    public int specialCurrency = 0;

    public int levelsUnlocked = 1;

    [SerializeField] private TMP_Text playerNameText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Image progressImage;
    [SerializeField] private TMP_Text normalCurrencyText;
    [SerializeField] private TMP_Text specialCurrencyText;



    private void Awake()
    {
        playerName = PlayerPrefs.GetString("PlayerName", "New Player");
        LoadData();
        DontDestroyOnLoad(gameObject);
    }
    
    public void AddSpecialCurrency(int value)
    {
        specialCurrency += value;
    }

    private void CheckForLevelUp()
    {
        if (experience > experienceRequired)
        {
            experience = experience % 1000;
            level++;
        }
    }

    public float GetProgress()
    {
        return (float)experience / (float)experienceRequired;
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
        if (value.Length > 15)
            return;
        playerName = value;
        playerNameText.text = playerName;
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
