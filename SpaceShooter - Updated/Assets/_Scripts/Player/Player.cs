using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Data/PlayerData", order = 0)]
public class Player : ScriptableObject
{
	public List<Sprite> playerSkins;

	[Header("Stats")]
	public int lives;
	public float speed;
}
