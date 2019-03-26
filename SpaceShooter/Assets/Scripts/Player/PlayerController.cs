using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerHealth))]
public class PlayerController : MonoBehaviour
{
    public PlayerData pd;
    public Transform shotSpawn;

    GameObject shotFX;
    Rigidbody rb;
    //PlayerHealth ph;
    float speed = 0;
    float attackSpeed = 0.1f;
    int damage = 0;
    int currentDamage = 0;

    Vector3 rotateTo = new Vector3(-90f, 0f, 25f);
    Vector3 initialRotation = new Vector3(-90f, 0f, 0f);

    Vector2 initTouchPos;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        shotFX = pd.shotFX;
        speed = pd.speed;
        damage = pd.damage;
        currentDamage = damage;
    }

    private void Start()
    {
        //ph = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (Time.timeScale == 0)
            return;
        Touch[] touches = Input.touches;
        if (touches.Length != 0)
        {
            Move(0);
        }
        attackSpeed -= Time.deltaTime;
        if (attackSpeed <= 0)
        {
            Shoot();
            attackSpeed = 0.1f;
        }

    }

    void Move(int touchIndex)
    {
        Touch input = Input.GetTouch(touchIndex);
        Vector3 point = Camera.main.ScreenToWorldPoint(input.position);
        Tilt(input, point);
        point.z = 0f;
        transform.position = Vector3.Lerp(transform.position, point, speed);
    }

    void Tilt(Touch touch, Vector3 worldPoint)
    {
        if (touch.phase == TouchPhase.Began)
        {
            initTouchPos = transform.position;
        }
        if (touch.phase == TouchPhase.Moved)
        {
            int sign = worldPoint.x > initTouchPos.x ? -1 : 1;
            transform.localRotation = Quaternion.Euler(rotateTo.x, rotateTo.y, rotateTo.z * sign);
            initTouchPos = transform.position;
        }
        if (touch.phase == TouchPhase.Ended)
        {
            transform.localRotation = Quaternion.Euler(initialRotation.x, initialRotation.y, initialRotation.z);
        }
    }

    void Shoot()
    {
        GameObject go = Instantiate(shotFX, shotSpawn.position, shotSpawn.localRotation);
        currentDamage = damage > currentDamage ? damage : currentDamage;
        go.GetComponent<PlayerShot>().damage = currentDamage;
        MusicManager.Instance.PlayClipAtLocation(MusicManager.Instance.mr[1].clips[GameManager.instance.shipIndex], go.transform);
    }
}
