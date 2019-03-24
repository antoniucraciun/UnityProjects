using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.instance.OnEndOfGame();
            GameObject.FindGameObjectWithTag("InputField").transform.position = new Vector3(350, 72.5f, 0);
            GameManager.instance.inputField.enabled = true;
            collision.GetComponent<PlayerMovement>().enabled = false;
            gameObject.SetActive(false);
        }
    }
}
