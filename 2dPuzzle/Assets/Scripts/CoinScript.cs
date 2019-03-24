using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
    
    //value of the coin
    int coinValue = 10;
    bool calledOnce = false;
    public ParticleSystem particle;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !calledOnce)
        {
            calledOnce = true;
            //update the coin text if the player collides with the coin
            GameManager.instance.UpdateCoinText(coinValue);
            //disable the game object so the player can't pick up the same coin again
            particle.Play();
            gameObject.SetActive(false);
        }
    }
}
