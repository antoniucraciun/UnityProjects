using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    public static int level = 1; //0
    public static int money = 20; //1
    public static int gems = 5; //2
    public static int damage = 1; //3
    public static int shield = 5; //4
    public static int pulseDamage = 5; //5
    public static int numberOfDefenders = 1; //6
    public static int levelMax = 1; //7
    public static int scoreMax = 0; //8
    public static int armorPoints = 5; //9

    public static void Save()
    {
        //Reset();
        if (SaveLoad.dataToSave.Count < 10)
        {
            SaveLoad.dataToSave.Clear();
            SaveLoad.dataToSave.Add(level);
            SaveLoad.dataToSave.Add(money);
            SaveLoad.dataToSave.Add(gems);
            SaveLoad.dataToSave.Add(damage);
            SaveLoad.dataToSave.Add(shield);
            SaveLoad.dataToSave.Add(pulseDamage);
            SaveLoad.dataToSave.Add(numberOfDefenders);
            SaveLoad.dataToSave.Add(levelMax);
            SaveLoad.dataToSave.Add(scoreMax);
            SaveLoad.dataToSave.Add(armorPoints);
            SaveLoad.Save();
        }
        else
        {
            SaveLoad.dataToSave[0] = level;
            SaveLoad.dataToSave[1] = money;
            SaveLoad.dataToSave[2] = gems;
            SaveLoad.dataToSave[3] = damage;
            SaveLoad.dataToSave[4] = shield;
            SaveLoad.dataToSave[5] = pulseDamage;
            SaveLoad.dataToSave[6] = numberOfDefenders;
            SaveLoad.dataToSave[7] = levelMax;
            SaveLoad.dataToSave[8] = scoreMax;
            SaveLoad.dataToSave[9] = armorPoints;
            SaveLoad.Save();
        }
    }

    public static void Load()
    {
        SaveLoad.Load();
        level = SaveLoad.dataToSave[0];
        money = SaveLoad.dataToSave[1];
        gems = SaveLoad.dataToSave[2];
        damage = SaveLoad.dataToSave[3];
        shield = SaveLoad.dataToSave[4];
        pulseDamage = SaveLoad.dataToSave[5];
        numberOfDefenders = SaveLoad.dataToSave[6];
        levelMax = SaveLoad.dataToSave[7];
        scoreMax = SaveLoad.dataToSave[8];
        armorPoints = SaveLoad.dataToSave[9];
    }

    public static void Reset()
    {
        level = 1;
        money = 10;
        gems = 5;
        damage = 1;
        shield = 5;
        pulseDamage = 5;
        numberOfDefenders = 1;
        levelMax = 1;
        scoreMax = 0;
        armorPoints = 5;
    }
}
