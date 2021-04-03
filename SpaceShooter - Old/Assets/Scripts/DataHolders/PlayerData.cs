using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player")]
public class PlayerData : ScriptableObject
{
    public int health = 100;
    public int damage = 10;
    public int armor = 50;
    public float speed = 0.5f;

    public GameObject shotFX;
}
