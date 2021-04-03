using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Data/Enemy/EnemyData", order = 0)]
public class Enemy : ScriptableObject
{
	public string enemyName;
	[TextArea]
	public string enemyDescription;

	[Header("Stats")]
	public Sprite sprite;
	public float health;
	public float speed;

	[Header("AI")]
	[Tooltip("How many bullets the enemy fires per second")]
	public float bulletsPerSecond;
	[Tooltip("How far away from the player the enemy should stop")] 
	public float distanceToObject;
	public float initialTimeToFollow;
	public float initialTimeToDodge;
	[Tooltip("How big the check for bullets range should be")]
	public float checkRange;
	//[Tooltip("How much force should be applied when dodging")]
	//public float dodgeForce;

	public float enemySizeSphere;

	public float FireRate
	{
		get
		{
			return 1 / bulletsPerSecond;
		}
	}
}
