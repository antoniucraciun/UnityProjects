using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth = 1;
    public int maxHealth = 1;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void DecreaseHealth(int value)
    {
        currentHealth -= value;
    }

    public void SetMaxHealth(int value)
    {
        maxHealth = value;
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }
}
