using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AchievementSystem
{
    public static List<Achievement> achievements = new List<Achievement>();

    public static void Register(Achievement ach)
    {
        achievements.Add(ach);
        Debug.Log("Registered: " + ach);
    }

    public static void Deregister(Achievement ach)
    {
        achievements.Remove(ach);
        Debug.Log("Deregistered: " + ach);
    }

    public static void Notify(AchievementType ach, long threshold)
    {
        Debug.Log(ach + threshold.ToString());
        foreach (Achievement item in achievements)
        {
            if (item.achType == ach && item.threshold == threshold)
            {
                item.ExecuteAchievement();
            }
        }
    }

    public static void ResetAll()
    {
        foreach (Achievement item in achievements)
        {
            item.Reset();
        }
    }
}
