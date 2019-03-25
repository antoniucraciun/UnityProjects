using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour {

    public float moveSpeed = 5f;

    PlayerController playerController;
    Camera viewCamera;
    CameraController camContr;

    void Start ()
    {
        playerController = GetComponent<PlayerController>();
        viewCamera = Camera.main;
        camContr = viewCamera.GetComponent<CameraController>();
	}
	
	void Update ()
    {
        //Rotation
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDist;
        if (groundPlane.Raycast(ray, out rayDist))
        {
            Vector3 point = ray.GetPoint(rayDist);
            camContr.mousePos = point;
            playerController.LookAt(point);
        }
	}


    private void FixedUpdate()
    {
        //Movement
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 1f, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        playerController.Move(moveVelocity);
    }
}
