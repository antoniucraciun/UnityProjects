using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnemy : MonoBehaviour {

    public GameObject player;
    public Vector3 raisedPosition = new Vector3(0, 1.1f, 0);
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        raisedPosition += transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= 6)
        {
            transform.position = Vector3.Lerp(transform.position, raisedPosition, 1);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, raisedPosition - new Vector3(0, 1.1f, 0), 1);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.instance.ResetLevel();
        }
    }
}
