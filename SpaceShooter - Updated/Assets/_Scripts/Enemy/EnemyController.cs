using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyShoot))]
public class EnemyController : MonoBehaviour
{
    public static int count = 0;
    public int enemyId = 0;

	[HideInInspector] public GameObject objToFollow;
    [HideInInspector] public Pattern movementPattern;
    [HideInInspector] public Rigidbody2D rb2d;

    public string objToFollowName;
    public string patternObjName;

    [Range(1, 5)] public float distanceToTarget = 1f;

    public Enemy enemyData;
    public bool idle = true;

    public bool b_targetPlayer;
    public bool b_dodge;

    [HideInInspector] public float timeToDodge;
    [HideInInspector] public float timeToFollow;
    [HideInInspector] public bool dodgeRight = true;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (objToFollow == null)
            objToFollow = GameObject.Find(objToFollowName);
        if (movementPattern == null)
            movementPattern = GameObject.Find(patternObjName).GetComponent<Pattern>();
        timeToDodge = enemyData.initialTimeToDodge;
        timeToFollow = enemyData.initialTimeToFollow;
    }

    private void Start()
    {
        enemyId = count;
        count++;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, enemyData.checkRange);
    }
}
