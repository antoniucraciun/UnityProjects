using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Transform position1;
    public Transform position2;
    public EnemySO so;

    public float speed;

	void Start ()
    {
        speed = so.speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.Lerp(position1.position, 
                                          position2.position, 
                                          Mathf.Abs(Mathf.Sin(Time.time / 1.5f)));
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.instance.ResetLevel();
        }
    }
}
