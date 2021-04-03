using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class LoadInSave : MonoBehaviour {

    public static LoadInSave Instace { set; get; }
    public PlayerData[] shipData;
    public SaveVars save;

    MainMenuManager main;
    GameManager gm;

    private void Awake()
    {
        Instace = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        main = MainMenuManager.Instance;
        gm = GameManager.instance;
        Load();
    }

    public void Save ()
    {
        if (main == null)
            main = MainMenuManager.Instance;
        if (gm == null)
            gm = GameManager.instance;
        //speed
        save.shipSpeed = shipData[0].speed;
        
        save.shipLevel1 = main.shipLevel[0];
        save.shipLevel2 = main.shipLevel[1];
        save.shipLevel3 = main.shipLevel[2];
        save.shipLevel4 = main.shipLevel[3];
        save.shipLevel5 = main.shipLevel[4];
        save.shipLevel6 = main.shipLevel[5];
        save.shipLevel7 = main.shipLevel[6];

        //currency
        save.coins = main.totalCoins;
        save.gems = main.totalGems;

        //chests
        save.commonChestAmount = main.commonChestAmount;
        save.uncommonChestAmount = main.uncommonChestAmount;
        save.rareChestAmount = main.rareChestAmount;
        save.legendaryChestAmount = main.legendaryChestAmount;

        save.totalUpgrades = save.shipLevel1 + save.shipLevel2 + save.shipLevel3 + save.shipLevel4 + save.shipLevel5 + save.shipLevel6 + save.shipLevel7 - 7;
        save.upgradesShip1 = save.shipLevel1 - 1;
        save.upgradesShip2 = save.shipLevel2 - 1;
        save.upgradesShip3 = save.shipLevel3 - 1;
        save.upgradesShip4 = save.shipLevel4 - 1;
        save.upgradesShip5 = save.shipLevel5 - 1;
        save.upgradesShip6 = save.shipLevel6 - 1;
        save.upgradesShip7 = save.shipLevel7 - 1;

        //SaveManager.Instance.Save();
    }
	

    public void Load()
    {
        if (main == null)
            main = MainMenuManager.Instance;
        //health
        shipData[0].health = save.shipHealth_1;
        shipData[1].health = save.shipHealth_2;
        shipData[2].health = save.shipHealth_3;
        shipData[3].health = save.shipHealth_4;
        shipData[4].health = save.shipHealth_5;
        shipData[5].health = save.shipHealth_6;
        shipData[6].health = save.shipHealth_7;
        //damage
        shipData[0].damage = save.shipDamage_1;
        shipData[1].damage = save.shipDamage_2;
        shipData[2].damage = save.shipDamage_3;
        shipData[3].damage = save.shipDamage_4;
        shipData[4].damage = save.shipDamage_5;
        shipData[5].damage = save.shipDamage_6;
        shipData[6].damage = save.shipDamage_7;
        //speed
        for (int i = 0; i < shipData.Length; i++)
        {
            shipData[i].speed = save.shipSpeed;
        }
        //ship level
        main.shipLevel = new int[7];
        main.shipLevel[0] = save.shipLevel1;
        main.shipLevel[1] = save.shipLevel2;
        main.shipLevel[2] = save.shipLevel3;
        main.shipLevel[3] = save.shipLevel4;
        main.shipLevel[4] = save.shipLevel5;
        main.shipLevel[5] = save.shipLevel6;
        main.shipLevel[6] = save.shipLevel7;
        //ship cost

        //islocked
        main.isLocked[0] = save.isLocked_1;
        main.isLocked[1] = save.isLocked_2;
        main.isLocked[2] = save.isLocked_3;
        main.isLocked[3] = save.isLocked_4;
        main.isLocked[4] = save.isLocked_5;
        main.isLocked[5] = save.isLocked_6;
        main.isLocked[6] = save.isLocked_7;
        //currency
        main.totalCoins = save.coins;
        main.totalGems = save.gems;
        main.DisplayText(main.coinsText, save.coins.ToString());
        main.DisplayText(main.gemsText, save.gems.ToString());
        //chests
        main.commonChestAmount = save.commonChestAmount;
        main.uncommonChestAmount = save.uncommonChestAmount;
        main.rareChestAmount = save.rareChestAmount;
        main.legendaryChestAmount = save.legendaryChestAmount;
    }
}
