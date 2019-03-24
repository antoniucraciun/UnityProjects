using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour {

    bool calledOnce = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (calledOnce)
            return;
        calledOnce = true;
        if (collision.tag == "Player")
        {
            GameManager.instance.ResetLevel();
        }
    }

}
