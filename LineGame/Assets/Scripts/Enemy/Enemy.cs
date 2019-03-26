using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 1f;
    public float health = 1f;
    public float maxHealth;
    public int scoreValue = 100;
    public int rewardAmount = 1;
    public int moneyPercentChance = 10;
    public bool destroyed = true;

    public Transform target;
    public Controller ctrl;
    public GameObject particleDeath;
    private void Start()
    {
        destroyed = false;
        GameManager.enemyNumber++;
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Target").transform;
        if (ctrl == null)
            ctrl = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
        Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = direction;
        health += Data.level;
        maxHealth = health;
    }

    private void OnDestroy()
    {
        GameManager.enemyNumber--;
    }

    void Update ()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
	}

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0 && !destroyed)
        {
            destroyed = true;
            GameManager.score += scoreValue;
            AchievementSystem.Notify(AchievementType.Score, GameManager.score);
            GameManager.enemiesKilled++;
            GameManager.levelChanged = true;
            int rand = Random.Range(0, 100);
            if (rand < moneyPercentChance)
            {
                ctrl.IncreaseMoney(rewardAmount);
            }
            CreateParticle();
            Destroy(gameObject);
        }
    }

    public void CreateParticle()
    {
        Instantiate(particleDeath, transform.position, Quaternion.identity);
    }

    public void HealEnemy()
    {
        health = maxHealth;
    }
}
