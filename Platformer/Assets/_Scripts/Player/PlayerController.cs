using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    private PlayerMovement pm;

    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }

    public void Update()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        bool jump = Input.GetKeyDown(KeyCode.Space);

        pm.Move(movement, jump);
    }
}
