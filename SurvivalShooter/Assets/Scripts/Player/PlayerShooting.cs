using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {

    public int numberOfBullets = 30;

    public Rigidbody shot;
    public Transform shotSpawn;
    public float shotForce = 100f;
    public Text bulletText;
    public Text totalBulletText;
    public bool reloading = false;

    public AudioClip shootAudio;
    public AudioClip reloadAudio;

    float timer = 0f;
    private float cooldown = 0.1f;
    private float timePassed = 0f;
    int bulletsConsumed = 30;

    public static PlayerShooting instance;

    private void Start()
    {

    }

    void Update () {

        if (numberOfBullets <= 0 && !reloading)
        {
            reloading = true;
            StartCoroutine(Reload());
        }

        if (Input.GetButtonDown("1") && !reloading)
        {
            cooldown = 0.1f;
            bulletsConsumed = 30;
            Wait();
            numberOfBullets = bulletsConsumed;
            bulletText.text = "" + numberOfBullets;
        }
        else if (Input.GetButtonDown("2") && !reloading)
        {
            cooldown = 0.5f;
            bulletsConsumed = 8;
            Wait();
            numberOfBullets = bulletsConsumed;
            bulletText.text = "" + numberOfBullets;
        }

        timer = Time.time;
		if (Input.GetButton("Fire1") && timer >= timePassed && numberOfBullets > 0)
        {
            timePassed = Time.time + cooldown;
            Rigidbody bulletInstance = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as Rigidbody;
            bulletInstance.velocity = shotForce * shotSpawn.forward;
            numberOfBullets--;
            bulletText.text = "" + numberOfBullets;
            AudioManager.instance.PlaySound(shootAudio, shotSpawn.position);
        }
        
	}

    IEnumerator Reload()
    {
        if (numberOfBullets <= 0)
        {
            AudioManager.instance.PlaySound(reloadAudio, transform.position);
            yield return new WaitForSeconds(2.5f);
            numberOfBullets = bulletsConsumed;
            bulletText.text = "" + numberOfBullets;
        }
        yield return new WaitForSeconds(1f);
        reloading = false;
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
    }
}
