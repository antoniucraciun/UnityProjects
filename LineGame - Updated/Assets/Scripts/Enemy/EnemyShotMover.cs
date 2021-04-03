using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotMover : MonoBehaviour {

    public Transform target;
    public float speed = 2f;

    void Start ()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Target").transform;
        Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = direction;
    }
	
	void Update ()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
