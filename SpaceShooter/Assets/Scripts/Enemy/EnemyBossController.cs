using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnemyHealth))]
public class EnemyBossController : MonoBehaviour
{
    
    public Transform mainShotSpawn;
    public Transform[] secondaryShotSpawns;
    public Transform firstPosition;
    public Transform secondPosition;
    public GameObject drop;

    public GameObject mainShotFx;
    public GameObject secondaryShotFx;
    public GameObject explosionFx;

    public float movingSpeed = 0.5f;
    public float mainAttackSpeed = 3f;
    public float secondaryAttackSpeed = 2f;
    public int mainGunDamage = 50;
    public int secondaryGunDamage = 5;
    public int score;

    //private Rigidbody rb;
    private EnemyHealth eh;
    private bool isAlive = true;
    private bool wasOnFirst = false;
    private float mainAttackSpeedCd = 3f;
    private float secondaryAttackSpeedCd = 2f;

	void Start ()
    {
        //rb = GetComponent<Rigidbody>();
        eh = GetComponent<EnemyHealth>();
        wasOnFirst = false;
        mainAttackSpeedCd = mainAttackSpeed;
        secondaryAttackSpeedCd = secondaryAttackSpeed;
	}
	
	void Update ()
    {
        if (!isAlive)
        {
            Instantiate(explosionFx, transform);
            Instantiate(drop, transform.position, drop.transform.rotation);
            AstraGameController.instance.UpdateScore(score);
            Destroy(gameObject);
            return;
        }
        ShootMainGun();
        ShootSecondaryGun();
        DoPingPongMovement();
	}

    void DoPingPongMovement()
    {
        if (!wasOnFirst)
        {
            transform.position = Vector3.Lerp(transform.position, firstPosition.position, movingSpeed * Time.deltaTime);
            if (transform.position.x > firstPosition.position.x - 0.2f && transform.position.x < firstPosition.position.x + 0.2f)
            {
                wasOnFirst = true;
            }
        }
        else if (wasOnFirst)
        {
            transform.position = Vector3.Lerp(transform.position, secondPosition.position, movingSpeed * Time.deltaTime);
            if (transform.position.x > secondPosition.position.x - 0.2f && transform.position.x < secondPosition.position.x + 0.2f)
            {
                wasOnFirst = false;
            }
        }
    }

    void ShootMainGun()
    {
        mainAttackSpeedCd -= Time.deltaTime;
        if (mainAttackSpeedCd <= 0)
        {
            GameObject go = Instantiate(mainShotFx, mainShotSpawn.position, Quaternion.identity);
            go.GetComponent<EnemyShot>().damage = mainGunDamage;
            mainAttackSpeedCd = mainAttackSpeed;
        }
    }

    void ShootSecondaryGun()
    {
        secondaryAttackSpeedCd -= Time.deltaTime;
        if (secondaryAttackSpeedCd <= 0)
        {
            for (int i = 0; i < secondaryShotSpawns.Length; i++)
            {
                GameObject go = Instantiate(secondaryShotFx, secondaryShotSpawns[i].position, Quaternion.identity);
                go.GetComponent<EnemyShot>().damage = secondaryGunDamage;
            }
            secondaryAttackSpeedCd = secondaryAttackSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "EnemyShot")
        {
            return;
        }
        if (other.tag == "PlayerShot")
        {
            isAlive = eh.TakeDamage(other.GetComponent<PlayerShot>().damage);
        }
        if (other.tag == "Player")
        {
            isAlive = eh.TakeDamage(other.GetComponent<PlayerHealth>().GetCurrentHealth());
            other.GetComponent<PlayerHealth>().TakeDamage(eh.GetCurrentHealth());
        }
    }
}
