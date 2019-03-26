using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class Data
{
    #region PlayerData
    public static int level = 1;
    public static int experience = 0;
    public static int experienceRequired = 100;
    public static int normalCurrency = 0;
    public static int specialCurrency = 0;
    public static int levelsUnlocked = 1;
    #endregion



    public static void Save()
    {
        SaveLoad.dataToSave.Clear();
        SaveLoad.dataToSave.Add(level);
        SaveLoad.dataToSave.Add(experience);
        SaveLoad.dataToSave.Add(experienceRequired);
        SaveLoad.dataToSave.Add(normalCurrency);
        SaveLoad.dataToSave.Add(specialCurrency);
        SaveLoad.dataToSave.Add(levelsUnlocked);
        SaveLoad.Save();
    }

    public static void Load()
    {
        SaveLoad.Load();
        level = SaveLoad.dataToSave[0];
        experience = SaveLoad.dataToSave[1];
        experienceRequired = SaveLoad.dataToSave[2];
        normalCurrency = SaveLoad.dataToSave[3];
        specialCurrency = SaveLoad.dataToSave[4];
        levelsUnlocked = SaveLoad.dataToSave[5];
    }

    public static void Reset()
    {
        level = 1;
        experience = 0;
        experienceRequired = 100;
        normalCurrency = 0;
        specialCurrency = 0;
    }
}
