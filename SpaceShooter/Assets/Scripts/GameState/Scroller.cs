using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float scrollSpeed = .5f;
    public float randomHorizontal = 0f;

    private void Start()
    {
        randomHorizontal = Random.Range(0f, 3f);
    }

    void Update ()
    {
        GetComponent<SpriteRenderer>().material.SetTextureOffset("_MainTex", new Vector2(randomHorizontal, Time.time * scrollSpeed));
	}
    
}
