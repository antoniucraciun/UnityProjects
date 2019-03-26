using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float moveSpeed = 200;
    public float toLeft = 1f;
    public float attackSpeed = 0.1f;
    [Range(0.25f,1)]
    public static float sensitivity = 0.75f;

    public Transform target;
    public Transform shotPosition;
    public GameObject shot;

    public static int numberOfShots;
    public List<Move> shots;
    public GameObject shotsFired;
    public SoundManager sm;

    private void Awake()
    {

    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        sm = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        numberOfShots = 0;
        sensitivity = UIManager.sens;
    }

    void Update ()
    {
        //if (GameManager.gameStarted == false)
        //    return;
        toLeft = Input.GetAxisRaw("Horizontal");

        Touch[] touches = Input.touches;
        if (touches.Length != 0)
        {
            Vector3 input = Camera.main.ScreenToViewportPoint(touches[0].position);
            if (input.x > 0.5f)
            {
                toLeft = 1f;
            }
            else if (input.x <= 0.5f)
            {
                toLeft = -1f;
            }
            input = Vector3.zero;
        }

        if (attackSpeed <= 0)
        {
            Shoot();
            attackSpeed = 0.1f;
        }
        attackSpeed -= Time.deltaTime;
	}

    private void FixedUpdate()
    {
        transform.RotateAround(target.position, Vector3.forward, -moveSpeed * toLeft * Time.fixedDeltaTime * sensitivity);
    }

    public void Shoot()
    {
        if (numberOfShots > 75)
        {
            Move shot = shots[0];
            shots.RemoveAt(0);
            Destroy(shot);
        }
        shotsFired = Instantiate(shot, shotPosition.position, shotPosition.rotation);
        shots.Add(shotsFired.GetComponent<Move>());
        sm.PlayPlayerSound();
    }
}
