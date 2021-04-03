using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public GameObject target;

    public int speed = 1;

    public virtual void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
