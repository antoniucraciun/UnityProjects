using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public int level; //0
    public int money; //1
    public int gems; //2
    public int damage; //3
    public int shield; //4
    public int pulseDamage; //5
    public int numberOfDefenders; //6
    public int armorPoints;
    public int upgrades = 0;

    public int rotationSpeed = 100;
    public GameObject[] playerTriangleDefenders;
    public GameObject player;

    private void Awake()
    {
        Data.Load();
        level = Data.level;
        money = Data.money;
        gems = Data.gems;
        damage = Data.damage;
        shield = Data.shield;
        pulseDamage = Data.pulseDamage;
        numberOfDefenders = Data.numberOfDefenders;
        armorPoints = Data.armorPoints;
    }

    public void IncreaseLevel()
    {
        level++;
        Data.level = level;
        Data.Save();
    }

    public void IncreaseDamage()
    {
        //Debug.Log("damage: " + damage);
        if (money - damage * 2 < 0)
        {
            return;
        }
        money -= damage * 2;
        damage++;
        Data.damage = damage;
        Data.money = money;
        Data.Save();
        upgrades++;
        AchievementSystem.Notify(AchievementType.Upgrades, upgrades);
    }

    public void IncreasePulseDamage()
    {
        if (money - pulseDamage * 2 < 0)
        {
            return;
        }
        money -= pulseDamage * 2;
        pulseDamage++;
        Data.pulseDamage = pulseDamage;
        Data.money = money;
        Data.Save();
        upgrades++;
        AchievementSystem.Notify(AchievementType.Upgrades, upgrades);
    }

    public void IncreaseNumberOfDefenders()
    {
        if (numberOfDefenders == 4)
        {
            return;
        }
        if (money - numberOfDefenders * 200 < 0)
        {
            return;
        }
        money -= numberOfDefenders * 200;
        numberOfDefenders++;
        Data.numberOfDefenders = numberOfDefenders;
        Data.money = money;
        Data.Save();
        upgrades++;
        AchievementSystem.Notify(AchievementType.Upgrades, upgrades);
    }

    public void StartDefenders()
    {
        PlaceDefenders(Data.numberOfDefenders);
    }

    public void PlaceDefenders(int numberOfDefenders)
    {
        player = GameObject.FindGameObjectWithTag("PlayerTriangle");
        if (player != null)
            DestroyImmediate(player);
        switch (numberOfDefenders)
        {
            case 1:
                Destroy(player);
                player = Instantiate(playerTriangleDefenders[numberOfDefenders - 1], transform);
                break;
            case 2:
                Destroy(player);
                player = Instantiate(playerTriangleDefenders[numberOfDefenders - 1], transform);
                break;
            case 3:
                Destroy(player);
                player = Instantiate(playerTriangleDefenders[numberOfDefenders - 1], transform);
                break;
            case 4:
                Destroy(player);
                player = Instantiate(playerTriangleDefenders[numberOfDefenders - 1], transform);
                break;
            default:
                break;
        }
    }

    public void IncreaseMoney(int amount)
    {
        money += amount;
        Data.money = money;
        Data.Save();
    }

    public void IncreaseGems(int amount)
    {
        gems += amount;
        Data.gems = gems;
        Data.Save();
    }

    public void IncreaseShield()
    {
        if (money - shield * 2 < 0)
        {
            return;
        }
        money -= shield * 2;
        shield++;
        Data.shield = shield;
        Data.money = money;
        Data.Save();
        upgrades++;
        AchievementSystem.Notify(AchievementType.Upgrades, upgrades);
    }

    public void IncreaseArmor()
    {
        if (money - armorPoints * 2 < 0)
        {
            return;
        }
        money -= armorPoints * 2;
        armorPoints++;
        Data.armorPoints = armorPoints;
        Data.money = money;
        Data.Save();
        upgrades++;
        AchievementSystem.Notify(AchievementType.Upgrades, upgrades);
    }
}
