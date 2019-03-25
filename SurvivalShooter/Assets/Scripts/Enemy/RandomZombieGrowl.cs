using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomZombieGrowl : MonoBehaviour {

    int zombieGrowl;

    public float zombieShoutCooldown;

    private void Start()
    {
        StartCoroutine(ZombieShout());
    }

    IEnumerator ZombieShout()
    {
        yield return new WaitForSeconds(zombieShoutCooldown);
        zombieGrowl = Random.Range(0, 100);
        if (zombieGrowl < 5)
        {
            AudioManager.instance.PlaySound("ZombieHit", transform.position);
        }
        yield return new WaitForSeconds(zombieShoutCooldown);
        StartCoroutine(ZombieShout());
    }

}
