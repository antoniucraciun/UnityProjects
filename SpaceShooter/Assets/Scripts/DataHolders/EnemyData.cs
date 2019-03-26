using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy")]
public class EnemyData : ScriptableObject
{
    public int health;
    public int damage;
    public int score;
    public float speed;
    [Tooltip("The higher the value the lower the attack speed")]
    public float attackSpeed;
    public GameObject shotFX;
    public GameObject explosionFx;
}
