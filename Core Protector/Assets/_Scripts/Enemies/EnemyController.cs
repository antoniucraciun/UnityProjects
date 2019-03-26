using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(EnemyTrigger))]
public class EnemyController : MonoBehaviour
{
    public EnemyHealth eh;
    public EnemyTrigger et;

    public GameObject deathParticle;
    public int score = 1;
    public int reward = 1;
    public int chance = 5;
    bool killed = false;

    private void Start()
    {
        eh = GetComponent<EnemyHealth>();
        et = GetComponent<EnemyTrigger>();
    }

    public virtual void TakeDamage(int value)
    {
        eh.DecreaseHealth(value);
        if (!eh.IsAlive() && !killed)
        {
            killed = true;
            KillEnemy();
        }
    }

    public virtual void KillEnemy()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        RewardManager.IncreaseScore(score);
        RewardManager.GetCurrency(chance, reward);
        //increase achievement variable
        Destroy(gameObject);
    }
    
}
