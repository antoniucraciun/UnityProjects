using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealer : MonoBehaviour
{
    public float cooldown = 5f;
    public float radius = 2f;
    public GameObject circleHeal;
    private void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            Heal();
            cooldown = 5f;
        }
    }

    public void Heal()
    {
        Vector2 origin = transform.position;
        Collider2D[] hits;
        hits = Physics2D.OverlapCircleAll(origin, radius);
        foreach (var item in hits)
        {
            if (item != null)
            {
                if(item.tag == "Enemy")
                {
                    item.GetComponent<Enemy>().HealEnemy();
                }
            }
        }
        CreateParticle();
    }
    public void CreateParticle()
    {
        Instantiate(circleHeal, transform.position, Quaternion.identity);
    }
}
