using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public void Shoot(GameObject owner, Vector3 position, float angle)
    {
        GameController.sharedInstance.poolParty.TryGetValue("Bullets", out ObjectPooler val);
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
