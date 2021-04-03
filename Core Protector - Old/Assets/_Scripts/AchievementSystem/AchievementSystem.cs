using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AchievementSystem
{
    public static List<Achievement> achievements = new List<Achievement>();

    public static void Register(Achievement ach)
    {
        achievements.Add(ach);
    }

    public static void Deregister(Achievement ach)
    {
        achievements.Remove(ach);
    }

    public static void Notify(AchievementType ach)
    {
        foreach (Achievement item in achievements)
        {
            if (item.achType == ach && item.achVar.GetProgress() >= 1)
            {
                item.ExecuteAchievement();
            }
        }
    }
}
