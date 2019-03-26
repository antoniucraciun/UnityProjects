using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject {

    public int playerDamage;

    private Animator animator;
    private Transform target;

    bool skipMove = true;
    public int health = 2;

    public AudioClip enemy1;
    public AudioClip enemy2;

    public AudioClip playerChop1;
    public AudioClip playerchop2;

    protected override void Start()
    {
        GameManager.instance.AddEnemyToList(this);
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        base.Start();
    }

    protected override bool AttemptMove<T>(int xDir, int yDir)
    {
        if (skipMove)
        {
            skipMove = false;
            return false;
        }
        base.AttemptMove<T>(xDir, yDir);
        skipMove = true;
        return true;
    }

    public void MoveEnemy()
    {
        int xDir=0;
        int yDir=0;

        if (Mathf.Abs(target.position.x - transform.position.x)<float.Epsilon)
        {
            yDir = target.position.y > transform.position.y ? 1 : -1;
        }
        else
        {
            xDir = target.position.x > transform.position.x ? 1 : -1;
        }
        AttemptMove<Player>(xDir, yDir);
    }

    protected override bool OnCantMove<T>(T component)
    {
        Player hitPlayer = component as Player;
        animator.SetTrigger("PlayerHit");
        hitPlayer.LoseFood(playerDamage);
        SoundManager.instance.RandomizeSfx(enemy1, enemy2);
        return true;
    }

    public void TakeDamage(int loss)
    {
        SoundManager.instance.RandomizeSfx(playerChop1, playerchop2);
        health -= loss;
        animator.SetTrigger("PlayerHit");
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
