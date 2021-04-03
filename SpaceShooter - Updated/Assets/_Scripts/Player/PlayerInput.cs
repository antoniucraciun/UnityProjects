#if UNITY_ANDROID
#define DEBUG_LogPlayerPosition
#endif
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerInput : MonoBehaviour
{
    Camera mainCam;
    Rigidbody2D rb2d;
    SpriteRenderer charRenderer;
    [HideInInspector] public Vector2 startPosition;
    [HideInInspector] public Vector2 endPosition;

    Vector2 maxPositions;
    Vector2 minPositions;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        charRenderer = GetComponent<SpriteRenderer>();
        mainCam = Camera.main;
        maxPositions = mainCam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
        minPositions = mainCam.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
    }

    public void KeyboardInput(float speed)
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Move(direction, speed);
        ClampPosition();
    }

    public void MobileInput(float speed)
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startPosition = mainCam.ScreenToWorldPoint(Input.GetTouch(0).position);
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                endPosition = mainCam.ScreenToWorldPoint(Input.GetTouch(0).position);
                Move((endPosition - startPosition).normalized, speed);
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                startPosition = Vector2.zero;
                endPosition = Vector2.zero;
                Move(Vector2.zero, speed);
            }
        }
        else
        {
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
        }
        ClampPosition();
    }

    public void Move(Vector2 direction, float speed)
    {
        Vector2 newMoveDirection = direction * speed;
        rb2d.velocity = newMoveDirection;
    }

    void ClampPosition()
    {
        float x = Mathf.Clamp(transform.position.x, 
                                minPositions.x + charRenderer.bounds.extents.x, 
                                maxPositions.x - charRenderer.bounds.extents.x);
        float y = Mathf.Clamp(transform.position.y, 
                                minPositions.y + charRenderer.bounds.extents.y, 
                                maxPositions.y - charRenderer.bounds.extents.y);

        Vector2 clampedPosition = new Vector2(x, y);
        transform.position = clampedPosition;
    }
}
