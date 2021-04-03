using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    Item item;
    MainMenuManager manager;

    private void Start()
    {
        manager = MainMenuManager.Instance;
    }

    public void OnOpenClicked(ChestData cd)
    {
        switch (cd.type)
        {
            case 0:
                if (manager.commonChestAmount <= 0)
                    return;
                manager.commonChestAmount -= 1;
                manager.DisplayText(manager.commonChestCounter, manager.commonChestAmount.ToString());
                break;
            case 1:
                if (manager.uncommonChestAmount <= 0)
                    return;
                manager.uncommonChestAmount -= 1;
                manager.DisplayText(manager.uncommonChestCounter, manager.uncommonChestAmount.ToString());
                break;
            case 2:
                if (manager.rareChestAmount <= 0)
                    return;
                manager.rareChestAmount -= 1;
                manager.DisplayText(manager.rareChestCounter, manager.rareChestAmount.ToString());
                break;
            case 3:
                if (manager.legendaryChestAmount <= 0)
                    return;
                manager.legendaryChestAmount -= 1;
                manager.DisplayText(manager.legendaryChestCounter, manager.legendaryChestAmount.ToString());
                break;
        }
        item = cd.OpenChest();
        switch (item.contentString)
        {
            case "Coins":
                manager.totalCoins += item.amount;
                break;
            case "Gems":
                manager.totalGems += item.amount;
                break;
            case "Common Chest":
                manager.commonChestAmount += 1;
                manager.DisplayText(manager.commonChestCounter, manager.commonChestAmount.ToString());
                break;
            case "Uncommon Chest":
                manager.uncommonChestAmount += 1;
                manager.DisplayText(manager.uncommonChestCounter, manager.uncommonChestAmount.ToString());
                break;
            case "Rare Chest":
                manager.rareChestAmount += 1;
                manager.DisplayText(manager.rareChestCounter, manager.rareChestAmount.ToString());
                break;
            case "Legendary Chest":
                manager.legendaryChestAmount += 1;
                manager.DisplayText(manager.legendaryChestCounter, manager.legendaryChestAmount.ToString());
                break;
            default:
                break;
        }
        LoadInSave.Instace.Save();
        LoadInSave.Instace.Load();
    }
}
