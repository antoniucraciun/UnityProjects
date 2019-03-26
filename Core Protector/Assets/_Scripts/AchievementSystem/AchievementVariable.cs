using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AchievementVariable")]
public class AchievementVariable : ScriptableObject
{
    public string achName;

    public int currentValue = 0;
    //[HideInInspector]
    public int nextValue;
    public int defaultNextValue = 0;
    public static int currentId = 1;
    public static int nextId = 2;
    
    //[HideInInspector]
    public int reward;
    public int defaultReward = 0;
    public static int rewardId = 3;

    public RewardType rewardType;

    public void Initialize()
    {
        currentValue = PlayerPrefs.GetInt(achName + currentId.ToString(), 0);
        nextValue = PlayerPrefs.GetInt(achName + nextId.ToString(), defaultNextValue);
        reward = PlayerPrefs.GetInt(achName + rewardId.ToString(), defaultReward);
    }

    public float GetProgress()
    {
        return (float)currentValue / (float)nextValue;
    }

    public int GetReward()
    {
        if (GetProgress() < 1)
            return 0;
        return reward;
    }

    public void SetReward(int value)
    {
        reward = value;
        SaveProgress();
    }

    public void SetCurrentValue(int value)
    {
        currentValue = value;
        SaveProgress();
    }

    public void SetNextValue(int value)
    {
        nextValue = value;
        SaveProgress();
    }
    
    public void SaveProgress()
    {
        PlayerPrefs.SetInt(achName + currentId.ToString(), currentValue);
        PlayerPrefs.SetInt(achName + nextId.ToString(), nextValue);
        PlayerPrefs.SetInt(achName + rewardId.ToString(), reward);
        PlayerPrefs.Save();
    }
}

public enum RewardType
{
    RegularCurrency,
    PremiumCurrency
}