using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public int armorPoints;

    private void Start()
    {
        armorPoints = Data.armorPoints + Data.level/10;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Shot")
        {
            armorPoints--;
            Destroy(collision.gameObject);
            if (armorPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
