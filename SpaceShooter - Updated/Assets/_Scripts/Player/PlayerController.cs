using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    PlayerInput input;

    public Player playerScriptableObject;
    public Gun currentGun;

    float speed;
    float fireRate;
    float lives;

    public bool b_canMove;
    public bool b_canShoot;

    void Start()
    {
        currentGun.Initialize();
        input = GetComponent<PlayerInput>();
        speed = playerScriptableObject.speed;
        fireRate = currentGun.FireRate;
        lives = playerScriptableObject.lives;
    }

    void Update()
    {
#if UNITY_ANDROID
        if (b_canMove)
            input.MobileInput(speed);
#endif
#if UNITY_EDITOR
        if (b_canMove)
            input.KeyboardInput(speed);
#endif
        fireRate -= Time.deltaTime;
        if (b_canShoot && fireRate <= 0)
        {
            currentGun.Shoot(gameObject, transform.position, 0f);
            fireRate = currentGun.FireRate;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        lives--;
    }
}
