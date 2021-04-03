using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDeath : MonoBehaviour
{
    public GameObject[] enemiesToSpawn;
    bool quit = false;

    private void OnApplicationQuit()
    {
        quit = true;
    }

    private void OnDestroy()
    {
        if (quit)
            return;
        Vector3[] points = new Vector3[3];
        points[0] = new Vector3(0f, 0.2f) + transform.position;
        points[1] = new Vector3(.2f, 0f) + transform.position;
        points[2] = new Vector3(0f, 0.2f) + transform.position;
        int index = 0;
        foreach (var item1 in enemiesToSpawn)
        {
            Instantiate(item1, points[index], Quaternion.identity);
            index++;
            if (index >= 3)
            {
                break;
            }
        }
    }
}
