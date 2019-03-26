using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float speed = 5f;
    public int damage;
    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>() != null)
        {
            damage = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().damage;
        }
        else
        {
            damage = Data.damage;
        }
        damage = Data.damage;
        Mover.numberOfShots++;
    }

    void Update ()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        Destroy(gameObject, 5);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
        if (collision.tag == "Shot")
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Pulse" || collision.tag == "PlayerShot")
        {
            return;
        }
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Mover.numberOfShots--;
    }
}
