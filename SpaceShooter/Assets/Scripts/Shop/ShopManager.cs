using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using TMPro;

public class ShopManager : MonoBehaviour
{
    //Item item;
    MainMenuManager manager;

    public TMP_Text costText;
    public int index = 0;

    private void Start()
    {
        manager = MainMenuManager.Instance;
    }

    public void SelectChest(int c)
    {
        index = c;
    }

    public void OnBuyClicked(Item chest)
    {
        DisplayText(costText, chest.price + " Gems");
        if (manager.totalGems - chest.price < 0)
            return;
        manager.totalGems -= chest.price;
        switch (chest.contentString)
        {
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
                Debug.Log(chest.contentString + " not found.");
                break;
        }
        DisplayText(costText, chest.price.ToString() + " Gems");
        LoadInSave.Instace.Save();
        LoadInSave.Instace.Load();
        
    }

    void DisplayText(TMP_Text text, string s)
    {
        text.text = s;
    }

    public void WatchAd()
    {
        /*
        if (Advertisement.IsReady())
        {
            switch (index)
            {
                case 0:
                    manager.commonChestAmount += 1;
                    manager.DisplayText(manager.commonChestCounter, manager.commonChestAmount.ToString());
                    break;
                case 1:
                    manager.uncommonChestAmount += 1;
                    manager.DisplayText(manager.uncommonChestCounter, manager.uncommonChestAmount.ToString());
                    break;
                case 2:
                    manager.rareChestAmount += 1;
                    manager.DisplayText(manager.rareChestCounter, manager.rareChestAmount.ToString());
                    break;
                case 3:
                    manager.legendaryChestAmount += 1;
                    manager.DisplayText(manager.legendaryChestCounter, manager.legendaryChestAmount.ToString());
                    break;
            }
            Advertisement.Show();
        }
        LoadInSave.Instace.Save();
        LoadInSave.Instace.Load();
        */
    }

    public void ExchangeCurrency(int type)
    {
        switch (type)
        {
            case 0:
                if (manager.totalGems - 10 < 0)
                    return;
                manager.totalCoins += 1000;
                manager.totalGems -= 10;
                DisplayText(costText, "10 Gems");
                break;
            case 1:
                if (manager.totalCoins - 2000 < 0)
                    return;
                manager.totalGems += 10;
                manager.totalCoins -= 2000;
                DisplayText(costText, "2000 Coins");
                break;
        }
        LoadInSave.Instace.Save();
        LoadInSave.Instace.Load();
    }
}
