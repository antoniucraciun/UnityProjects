using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    //variable used for referencing the animator
    Animator anim;
    bool calledOnce = false;

    public ParticleSystem particle;
    private void Awake()
    {
        //reference for animator
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (calledOnce)
        {
            return;
        }
        calledOnce = true;
        //if there are no letter left but more chests this code shouldn't run
        if (GameManager.instance.letterString.Count <= 0)
        {
            Debug.Log("Too many chests. Not enough letters!");
            return;
        }
        //check who interacted with the chest
        if (collision.tag == "Player")
        {
            particle.Play();
            //Get a random letter from the list
            int index = Random.Range(0, GameManager.instance.letterString.Count);
            //manage the animator
            anim.SetBool("isOpen", true);
            //add the found letter to the list
            Inventory.instance.NewLetterFound(GameManager.instance.letterString[index]);
            //print the text to the screen
            StartCoroutine(GameManager.instance.ChangeText(GameManager.instance.letterString[index]));
            //remove the letter
            //GameManager.instance.letterString.RemoveAt(index);
            GameManager.instance.lettersFound[index] = 1;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    
}
