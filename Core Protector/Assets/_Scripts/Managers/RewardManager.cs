using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RewardManager
{
    public static int score = 0;
    public static int normalCurrency = 0;
    public static int specialCurrency = 0;

    public static void IncreaseScore(int value)
    {
        score += value;
    }

    public static void ResetScore()
    {
        score = 0;
        normalCurrency = 0;
        specialCurrency = 0;
    }

    public static void GetCurrency(int chance, int reward)
    {
        int ch = Random.Range(0, 100);
        if (chance > ch)
        {
            normalCurrency += reward;
        }
    }
}
