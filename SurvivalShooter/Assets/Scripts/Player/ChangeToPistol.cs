using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToPistol : MonoBehaviour {

    GameObject rifleVFX;
    GameObject player;
    PlayerShooting playerShooting;


    private void Start()
    {
        rifleVFX = GameObject.FindGameObjectWithTag("RifleVFX");
        player = GameObject.FindGameObjectWithTag("Player");
        playerShooting = player.GetComponent<PlayerShooting>();
    }

    void Update ()
    {
        ChangeWeapon();
	}

    void ChangeWeapon()
    {
        if (playerShooting.reloading)
        {
            return;
        }
        if (Input.GetButton("2"))
        {
            rifleVFX.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (Input.GetButton("1"))
        {
            rifleVFX.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
