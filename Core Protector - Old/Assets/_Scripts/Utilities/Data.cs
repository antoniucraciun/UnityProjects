using System.Collections.Generic;

[System.Serializable]
public class Data
{
    #region PlayerData
    public static int level = 1;
    public static int experience = 0;
    public static int experienceRequired = 100;
    public static int normalCurrency = 0;
    public static int specialCurrency = 0;
    public static int levelsUnlocked = 1;
    #endregion

    public Data()
    {
        level = 1;
        experience = 0;
        experienceRequired = 1000;
        normalCurrency = 0;
        specialCurrency = 0;
        levelsUnlocked = 1;
    }

    public Data(PlayerData data)
    {
        //CoreData
        level = data.level;
        experience = data.experience;
        experienceRequired = data.experienceRequired;
        normalCurrency = data.normalCurrency;
        specialCurrency = data.specialCurrency;
        levelsUnlocked = data.levelsUnlocked;
    }

    public static void Reset()
    {
        level = 1;
        experience = 0;
        experienceRequired = 1000;
        normalCurrency = 0;
        specialCurrency = 0;
        levelsUnlocked = 1;
    }
}
