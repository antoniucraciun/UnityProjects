using UnityEngine;

public class BoundingBox : MonoBehaviour
{
    public LayerMask playerBulletLayer;

    Camera mainCam;
    BoxCollider2D boundingBox;

    private void Start()
    {
        mainCam = Camera.main;
        if (playerBulletLayer == LayerMask.NameToLayer("Nothing"))
            Debug.LogError("No layer selected");
        boundingBox = GetComponent<BoxCollider2D>();
        Vector3 maxPoints = mainCam.ViewportToWorldPoint(new Vector3(1f, 1f));
        boundingBox.size = new Vector2(maxPoints.x * 2 + 1f, maxPoints.y * 2+ 1f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Mathf.Log(playerBulletLayer.value, 2))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
