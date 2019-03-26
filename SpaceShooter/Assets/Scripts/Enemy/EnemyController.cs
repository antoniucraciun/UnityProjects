using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyData ed;
    public Transform shotSpawn;
    public GameObject drop;
    
    GameObject shotFx;
    GameObject explosionFx;
    Rigidbody rb;
    EnemyHealth eh;
    float speed = 0f;
    float attackSpeed = 2f;
    bool isAlive = true;
    int score;

    public static int killed;
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        eh = GetComponent<EnemyHealth>();
        speed = ed.speed;
        attackSpeed = ed.attackSpeed;
        shotFx = ed.shotFX;
        explosionFx = ed.explosionFx;
        score = ed.score;
	}
	
	void Update ()
    {
        if (!isAlive)
        {
            Instantiate(explosionFx, transform);
            Instantiate(drop, transform.position, drop.transform.rotation);
            AstraGameController.instance.UpdateScore(score);
            Destroy(gameObject);
            return;
        }
        if (isAlive)
        {
            attackSpeed -= Time.deltaTime;
            if (attackSpeed <= 0)
            {
                Shoot();
                attackSpeed = ed.attackSpeed;
            }
        }
        DestroyOverTime();
	}

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector3(0, -1, 0) * speed;
    }

    void Shoot()
    {
        GameObject es = Instantiate(shotFx, shotSpawn.position, Quaternion.identity);
        es.GetComponent<EnemyShot>().damage = ed.damage;
        //sound clip
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "EnemyShot")
        {
            return;
        }
        if (other.tag == "PlayerShot")
        {
            isAlive = eh.TakeDamage(other.GetComponent<PlayerShot>().damage);
        }
        if (other.tag == "Player")
        {
            isAlive = eh.TakeDamage(other.GetComponent<PlayerHealth>().GetCurrentHealth());
            other.GetComponent<PlayerHealth>().TakeDamage(eh.GetCurrentHealth());
        }
    }

    void DestroyOverTime()
    {
        Destroy(gameObject, 15f);
    }
}
