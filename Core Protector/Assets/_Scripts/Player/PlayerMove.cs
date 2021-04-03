using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
	private bool canMove;

	public float moveSpeed;

	public bl_Joystick joystick;

	private Rigidbody2D rigidbody2d;

    void Start()
    {
		canMove = false;
		rigidbody2d = GetComponent<Rigidbody2D>();
    }
	
    void Update()
    {
		if (!canMove)
			return;
		Turn();
    }

	private void FixedUpdate()
	{
		if (!canMove)
			return;
		Move();
	}

	public void Move()
	{
		Vector2 direction = new Vector2(joystick.Horizontal, joystick.Vertical).normalized;
		Vector2 velocity = direction * moveSpeed;
		rigidbody2d.velocity = velocity;
	}

	public void Turn()
	{
		if ((joystick.Horizontal < 0.01f && joystick.Horizontal > -0.01f) || (joystick.Vertical < 0.01f && joystick.Vertical > -0.01f))
			return;
		float angle = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90f));
	}

	public void SetCanMove(bool b)
	{
		canMove = b;
	}
}
