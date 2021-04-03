using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public void Move(float speed)
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
    }

    public void ChangeRotation(float angle)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
}
