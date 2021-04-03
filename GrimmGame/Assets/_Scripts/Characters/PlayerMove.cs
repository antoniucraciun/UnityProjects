using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public Animator animator;
	public Transform cameraTransform;

	public float walkSpeed = 4f;
	public float runSpeed = 8f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;

	public float turnSmoothTime = .2f;
	float turnSmoothVelocity;

	public float speedSmoothTime = .1f;
	float speedSmoothVelocity;
	float currentSpeed;

	void Start()
    {
		animator = GetComponent<Animator>();
		cameraTransform = Camera.main.transform;
    }

    void Update()
	{
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		Vector2 inputDir = input.normalized;

		if (inputDir != Vector2.zero)
		{
			float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
		}

		bool running = Input.GetKey(KeyCode.LeftShift);
		float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
		currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

		transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
		//animation
		float animationSpeedPercent = ((running) ? 1 : .5f) * inputDir.magnitude;
		animator.SetFloat("speed", animationSpeedPercent);
    }
}
