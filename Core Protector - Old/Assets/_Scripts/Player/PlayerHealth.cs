using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField]private int health;

	public event Action OnTakeDamage;
	public event Action OnPlayerDeath;

	public void ChangeHealth(int amount)
	{
		health += amount;
		OnTakeDamage?.Invoke();
		if (health <= 0)
		{
			OnPlayerDeath?.Invoke();
		}
	}
}
