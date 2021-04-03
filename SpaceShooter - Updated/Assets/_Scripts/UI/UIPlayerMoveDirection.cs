using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerMoveDirection : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    private LineRenderer lineRenderer;
    public string playerGameObjectName;

    private void Start()
    {
        playerInput = GameObject.Find(playerGameObjectName).GetComponent<PlayerInput>();
        lineRenderer = GetComponent<LineRenderer>();

        if (lineRenderer.positionCount != 3)
            lineRenderer.positionCount = 3;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                transform.position = playerInput.startPosition;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary) 
            {
                Vector2 moveDirection = playerInput.endPosition - playerInput.startPosition;
                transform.localScale = new Vector3(Mathf.Clamp(moveDirection.magnitude, -3, 3), 1f);
                float rotation = Mathf.Atan2(moveDirection.normalized.y, moveDirection.normalized.x) * Mathf.Rad2Deg;
                if (transform.localScale.x > 0)
                    transform.rotation = Quaternion.Euler(0f, 0f, rotation);
                else
                    transform.rotation = Quaternion.Euler(0f, 0f, rotation + 180);
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                transform.localScale = Vector3.zero;
            }
        }
    }
}
