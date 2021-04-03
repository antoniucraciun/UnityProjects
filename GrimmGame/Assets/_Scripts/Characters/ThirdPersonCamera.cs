using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
	public float mouseSensitivity = 10;
	public float distanceFromTarget = 2f;

	public Vector2 pitchMinMax = new Vector2(-40, 85);

	float yaw;
	float pitch;

	public Transform target;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	void LateUpdate()
    {
		yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
		pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;

		pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

		Vector3 targetRotation = new Vector3(pitch, yaw);
		transform.eulerAngles = targetRotation;

		transform.position = target.position - transform.forward * distanceFromTarget;
    }
}
