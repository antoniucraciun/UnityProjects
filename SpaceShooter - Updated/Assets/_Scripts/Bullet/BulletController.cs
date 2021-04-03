using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletMover))]
public class BulletController : MonoBehaviour
{
    BulletMover             bulletMover;
    [Header("Set in inspector")]
    public Bullet           bulletData;

    public bool             b_FollowTarget;
    public bool             b_stopFollowingWhenCloseToPlayer;
    [Range(1, 5)]
    [Tooltip("When 'Stop Following When Close To Player' is set to true then 'Follow Target' will be set to flase when in range")]
    public float            distanceToPlayer;
    public GameObject       target;

    [Tooltip("The owner of this bullet")]
    [HideInInspector]
    public GameObject       owner;

    void Start()
    {
        bulletMover = GetComponent<BulletMover>();
        if (bulletData.sprite != null)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = bulletData.sprite;
        }
    }

    void Update()
    {
        if (b_FollowTarget)
        {
            Vector2 direction = target.transform.position - transform.position;
            if (b_stopFollowingWhenCloseToPlayer && direction.magnitude < distanceToPlayer)
                b_FollowTarget = false;
            bulletMover.Move(bulletData.speed);
            bulletMover.ChangeRotation(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        }
        else
        {
            bulletMover.Move(bulletData.speed);
        }
    }

    public void SetOwner(GameObject owner)
    {
        this.owner = owner;
    }
}
