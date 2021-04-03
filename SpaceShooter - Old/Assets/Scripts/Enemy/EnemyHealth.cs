using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int health;
    int currentHealth;
    public EnemyData ed;

    private void Start()
    {
        //set health and damage when enemy is spawned
        health = ed.health;
        currentHealth = health;
    }

    public bool TakeDamage(int amount)
    {
        //called when an enemy is hit
        currentHealth -= amount;
        return currentHealth > 0 ? true : false;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
