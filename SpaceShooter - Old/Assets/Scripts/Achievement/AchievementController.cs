using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementController : MonoBehaviour
{
    public static AchievementController instance;

    public SaveVars save;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ManageClaims(int reward, string rewardType)
    {
        switch (rewardType)
        {
            case "Coins":
                save.coins += reward;
                break;
            case "Gems":
                save.gems += reward;
                break;
            case "Stars":
                save.stars += reward;
                break;
        }
    }
}
