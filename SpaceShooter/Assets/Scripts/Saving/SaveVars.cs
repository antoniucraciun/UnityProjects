using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Save")]
public class SaveVars : ScriptableObject
{
    //chests
    public int uncommonChestAmount;
    public int commonChestAmount;
    public int rareChestAmount;
    public int legendaryChestAmount;
    //level
    public int shipLevel1;
    public int shipLevel2;
    public int shipLevel3;
    public int shipLevel4;
    public int shipLevel5;
    public int shipLevel6;
    public int shipLevel7;
    //health
    public int shipHealth_1;
    public int shipHealth_2;
    public int shipHealth_3;
    public int shipHealth_4;
    public int shipHealth_5;
    public int shipHealth_6;
    public int shipHealth_7;
    //damage
    public int shipDamage_1;
    public int shipDamage_2;
    public int shipDamage_3;
    public int shipDamage_4;
    public int shipDamage_5;
    public int shipDamage_6;
    public int shipDamage_7;
    //armor
    public int shipArmor_1;
    public int shipArmor_2;
    public int shipArmor_3;
    public int shipArmor_4;
    public int shipArmor_5;
    public int shipArmor_6;
    public int shipArmor_7;
    //locked
    public bool isLocked_1;
    public bool isLocked_2;
    public bool isLocked_3;
    public bool isLocked_4;
    public bool isLocked_5;
    public bool isLocked_6;
    public bool isLocked_7;
    //speed
    public float shipSpeed;
    public int coins;
    public int gems;
    public int stars;
    //achievements
    public int score;
    public int totalEnemiesKilled;
    public int astraEnemiesKilled;

    public int totalUpgrades;
    public int upgradesShip1;
    public int upgradesShip2;
    public int upgradesShip3;
    public int upgradesShip4;
    public int upgradesShip5;
    public int upgradesShip6;
    public int upgradesShip7;

    public int totalBossesKilled;
    public int astraBossKills;

    public int gemsCollected;
    public int coinsCollected;
    public int starsCollected;
    public int powerUps;
    public int totalMissionsPlayed;
}
