using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int playerHealth = 100;
    public Text showHealth;
    public Image hurtImage;

    GameObject player;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    bool damaged = false;
    float flashSpeed = 5f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (playerHealth <= 0)
        {
            Destroy(player.gameObject);
        }

        if (damaged)
        {
            hurtImage.color = flashColor;
        }
        else
        {
            hurtImage.color = Color.Lerp(hurtImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        playerHealth -= amount;
        showHealth.text = "Health: " + playerHealth;
        damaged = true;
    }
}
