using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawEnemy : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.instance.ResetLevel();
        }
    }
}
