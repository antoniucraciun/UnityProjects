using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    GameObject rifleVFX;
    GameObject pistolVFX;
    Vector3 velocity;

    float minDistX = -30;
    float maxDistX = 85;
    float minDistZ = -35;
    float maxDistZ = 80;

    Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
        rifleVFX = GameObject.FindGameObjectWithTag("RifleVFX");
        pistolVFX = GameObject.FindGameObjectWithTag("PistolVFX");
	}

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void LookAt(Vector3 point)
    {
        Vector3 correctedPoint = new Vector3(point.x, transform.position.y, point.z);
        transform.LookAt(correctedPoint);
    }

    public void FixedUpdate()
    {
        rb.MovePosition(new Vector3(Mathf.Clamp(rb.position.x + velocity.x * Time.fixedDeltaTime, minDistX, maxDistX),
                                    1f,
                                    Mathf.Clamp(rb.position.z + velocity.z * Time.fixedDeltaTime, minDistZ, maxDistZ)));
    }
}