using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerMove))]
public class PlayerController : MonoBehaviour
{
	private PlayerHealth playerHealth;
	private PlayerMove playerMove;

    void Start()
    {
		playerHealth = GetComponent<PlayerHealth>();
		playerHealth.OnPlayerDeath += PlayerDeath;
		playerMove = GetComponent<PlayerMove>();
    }
	
    void Update()
    {
        
    }

	public void PlayerDeath()
	{
		playerMove.SetCanMove(false);
		//player death particle
		//something else
	}

	public PlayerHealth GetPlayerHealth() => playerHealth;
}
