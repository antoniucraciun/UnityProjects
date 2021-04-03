using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "Data/BulletData", order = 1)]
public class Bullet : ScriptableObject
{
    public string bulletName;
    [TextArea]
    public string bulletDescription;

    [Header("Stats")]
    public Sprite sprite;
    public float speed;
    public float damage;
}
