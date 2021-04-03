using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerData pd;

    private int health = 0;
    private int currentHealth = 0;

    private int armor = 0;
    private int currentArmor = 0;

    private bool isAlive = true;

    private void Awake()
    {
        health = pd.health;
        currentHealth = health;
        armor = pd.armor;
        currentArmor = armor;
    }

    public void TakeDamage(int amount)
    {
        if (armor > 0)
        {
            armor = armor - amount > 0 ? armor - amount : 0;
        }
        else
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
                isAlive = false;
        }
    }
    
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetCurrentArmor()
    {
        return currentArmor;
    }

    public bool GetAlive()
    {
        return isAlive;
    }
}
