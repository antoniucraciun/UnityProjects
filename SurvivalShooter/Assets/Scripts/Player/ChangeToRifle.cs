using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToRifle : MonoBehaviour
{
    GameObject player;
    GameObject pistolVFX;
    PlayerShooting playerShooting;

    private void Start()
    {
        pistolVFX = GameObject.FindGameObjectWithTag("PistolVFX");
        pistolVFX.GetComponent<MeshRenderer>().enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerShooting = player.GetComponent<PlayerShooting>();
    }

    void Update()
    {
        ChangeWeapon();
    }

    void ChangeWeapon()
    {
        if (playerShooting.reloading)
        {
            return;
        }
        if (Input.GetButton("1"))
        {
            pistolVFX.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (Input.GetButton("2"))
        {
            pistolVFX.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}

