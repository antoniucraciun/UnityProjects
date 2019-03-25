using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    GameObject scoreManager;
    Animator anim;
    ScoreManager score;
    bool dead = false;
    
    public int enemyHealth = 30;
    public int points = 10;

    private void Start()
    {
        anim = GetComponent<Animator>();
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
        score = scoreManager.GetComponent<ScoreManager>();
    }

    private void Update()
    {
        if (enemyHealth <= 0 && !dead)
        {
            anim.SetTrigger("Dead");
            dead = true;
            GetComponent<SphereCollider>().enabled = false;
            AudioManager.instance.PlaySound("ZombieDeath", transform.position);
            score.IncreasePoints(points);
            Destroy(gameObject, 0.9f);
        }
    }

    public void TakeDamage(int amount)
    {
        enemyHealth -= amount;
    }
}
