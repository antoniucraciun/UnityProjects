using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerMovementData")]
public class PlayerSO : ScriptableObject
{
    public int lives = 3;
    public int verticalForce = 450;
    public float speed = 5f;
}
