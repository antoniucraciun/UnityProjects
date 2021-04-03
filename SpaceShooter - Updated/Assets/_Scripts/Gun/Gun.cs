using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Data/GunData")]
public class Gun : ScriptableObject
{
    public Bullet bullet;
    public string gunName;
    [TextArea]
    public string gunDescription;

	public float bulletsPerSecond;
	public float FireRate
	{
		get
		{
			return 1 / bulletsPerSecond;
		}
	}

    public float angleOpening;

    public void Initialize()
    {
        if (!GameController.sharedInstance.poolParty.TryGetValue(gunName, out ObjectPooler val))
        {
            Debug.LogError("No object pooler for gun: " + gunName);
        }
    }

    public void Shoot(GameObject owner, Vector3 position, float angle)
    {
        GameController.sharedInstance.poolParty.TryGetValue(gunName, out ObjectPooler val);
        GameObject bullet = val.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = position;
            bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            bullet.GetComponent<BulletController>().SetOwner(owner);
            bullet.SetActive(true);
        }
    }
}
