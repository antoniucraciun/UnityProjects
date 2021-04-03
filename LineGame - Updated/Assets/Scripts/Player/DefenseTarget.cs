using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseTarget : MonoBehaviour
{
    public static int shield;
    public static int maxShield;
    public int livesLost;
    private SpriteRenderer rd;

    private void Start()
    {
        rd = GetComponent<SpriteRenderer>();
        rd.color = Color.green;
    }

    public static void Restart()
    {
        shield = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().shield;
        maxShield = shield;
    }

    private void Update()
    {
        SetColor((float)shield / (float)maxShield);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Shot")
        {
            shield--;
            Destroy(collision.gameObject);
            if (shield <= 0)
            {
                GameManager.gameOver = true;
            }
            livesLost++;
            AchievementSystem.Notify(AchievementType.LivesLost, livesLost);
        }
    }

    private void SetColor(float percent)
    {
        if (percent < 0.5f && rd.color != Color.red)
        {
            rd.color = Color.Lerp(rd.color, Color.red, 100);
        }
        else if (percent >= 0.5f && rd.color != Color.green)
        {
            rd.color = Color.Lerp(rd.color, Color.green, 100);
        }
    }
}
