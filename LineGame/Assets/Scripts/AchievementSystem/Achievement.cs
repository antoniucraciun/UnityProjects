using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : MonoBehaviour
{
    public int reward;
    public long threshold;
    public long initialThreshold;
    public Controller player;
    public AchievementType achType;
    public GameManager gm;
    public GameObject achievementUnlocked;
    
    public void Start()
    {
        AchievementSystem.Register(this);
    }

    private void OnDestroy()
    {
        AchievementSystem.Deregister(this);
    }

    public void ExecuteAchievement()
    {
        threshold *= 2;
        player.IncreaseMoney(reward);
        if (achType == AchievementType.Upgrades)
        {
            gm.SetValues();
        }
        achievementUnlocked.SetActive(true);
        achievementUnlocked.GetComponent<Animation>().Play();
    }

    public void Reset()
    {
        threshold = initialThreshold;
    }

    
}

public enum AchievementType
{
    EnemyKills,
    Score,
    Upgrades,
    LivesLost,
    PowerUps
}