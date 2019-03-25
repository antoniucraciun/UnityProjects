using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public Vector3 mousePos;
    Vector3 offset;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    void Update () {
        SetPosition();
	}

    void SetPosition()
    {
        if (player)
        {
            /*
            Vector3 pos = player.transform.position + mousePos;
            Vector3 correctedPos = pos / 2;
            correctedPos.y = offset.y;
            transform.position = correctedPos;
            */
            transform.position = player.transform.position + offset;
        }
        else return;
    }
}
