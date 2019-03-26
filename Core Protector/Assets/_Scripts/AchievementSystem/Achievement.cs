using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Achievement : MonoBehaviour
{
    public AchievementVariable achVar;
    public AchievementType achType;

    public int nextValueMultiplier;
    public int rewardMultiplier;

    public Image fillImage;
    public TMP_Text reward;

    private void Awake()
    {
        achVar.Initialize();
    }

    private void Start()
    {
        AchievementSystem.Register(this);
    }

    private void OnEnable()
    {
        SetAchievement();
    }

    private void OnDestroy()
    {
        AchievementSystem.Deregister(this);
        achVar.SaveProgress();
    }

    public void ExecuteAchievement()
    {
        achVar.SetNextValue(achVar.currentValue * nextValueMultiplier);
        switch (achVar.rewardType)
        {
            case RewardType.RegularCurrency:
                RewardManager.normalCurrency += achVar.reward;
                break;
            case RewardType.PremiumCurrency:
                RewardManager.specialCurrency += achVar.reward;
                break;
            default:
                break;
        }
        achVar.SetReward(achVar.reward * rewardMultiplier);
    }

    public void IncreaseAchievementCurrentValue(int value)
    {
        achVar.SetCurrentValue(achVar.currentValue + value);
    }

    public void Notify()
    {
        AchievementSystem.Notify(achType);
    }

    public void SetAchievement()
    {
        float var = achVar.GetProgress();
        if (var <= 1)
            fillImage.fillAmount = achVar.GetProgress();
        else
            fillImage.fillAmount = 1;

        reward.text = "Reward: " + achVar.reward;
    }
}

public enum AchievementType
{
    EnemiesKilled,
    ScoreGained,
    Upgrades
}
