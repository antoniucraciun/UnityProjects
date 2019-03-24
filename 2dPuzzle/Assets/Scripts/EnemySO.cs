using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyData")]
public class EnemySO : ScriptableObject
{
    public float speed = 5f;
    public int health = 5;
}
