using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyAttack : MonoBehaviour {

    GameObject player;
    Animator anim;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    EnemyController enemyController;
    bool playerInRange = false;
    float timer;
    float nextCooldown = 2f;

    public float attackCooldown = 2f;
    public int damageAmount = 10;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            return;
        }
        anim = GetComponent<Animator>();
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        enemyController = GetComponent<EnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemyController.enabled = false;
            playerInRange = true;
            anim.SetBool("IsWalking", false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enemyController.enabled = true;
            playerInRange = false;
            anim.SetBool("IsWalking", true);
        }
    }

    void Attack()
    {
        if (playerHealth.playerHealth > 0)
        {
            playerHealth.TakeDamage(damageAmount);
            anim.SetTrigger("Attack");
        }
    }

    void Update () {
        
        timer = Time.time;

        if (timer > nextCooldown && playerInRange && playerHealth.playerHealth > 0 && enemyHealth)
        {
            Attack();
            int zombieShout = Random.Range(0, 10);
            if (zombieShout < 4)
            {
                AudioManager.instance.PlaySound("ZombieHit", transform.position);
            }
            nextCooldown = timer + attackCooldown;
        }
	}
}
