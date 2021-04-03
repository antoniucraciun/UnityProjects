using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public int damage;
    float speed = 10f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.up * speed;
        DestroyAfterTime();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player" || other.tag == "Shot")
        {
            return;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void DestroyAfterTime()
    {
        Destroy(gameObject, 5f);
    }
}
