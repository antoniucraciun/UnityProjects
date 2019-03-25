using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyHealth))]
public class EnemyController : MonoBehaviour {

    Animator anim;
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent agent;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            return;
        }
        anim = GetComponent<Animator>();
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	void Update () {
        
        if (player == null)
        {
            return;
        }
		if (playerHealth.playerHealth > 0 && enemyHealth.enemyHealth >0)
        {
            anim.SetBool("IsWalking", true);
            agent.SetDestination(player.transform.position);
        }
        else
        {
            anim.SetBool("IsWalking", false);
            agent.enabled = false;
        }
	}
}
