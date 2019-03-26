using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoooter : MonoBehaviour
{

    public float delay = 4f;
    public GameObject shot;
    public Transform shotSpawn;

	void Start () {
		
	}
	
	void Update ()
    {
        if (delay < 0)
        {
            Instantiate(shot, shotSpawn);
            delay = 4f;
        }
        delay -= Time.deltaTime;
    }
}
