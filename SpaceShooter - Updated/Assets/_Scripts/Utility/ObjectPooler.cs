#if UNITY_EDITOR
#define DEBUG_LogPoolParty
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPooler : MonoBehaviour
{
    public List<GameObject> pool;
    public GameObject objectToPool;
    public bool b_shouldExpand;
    public int amountToPool;
    public string poolName;

    private void Start()
    {
        pool = new List<GameObject>();
        if (objectToPool != null)
            StartCoroutine(PopulatePool());
        GameController.sharedInstance.poolParty.Add(poolName, this);
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
                return pool[i];
        }
        if (b_shouldExpand)
        {
            GameObject obj = Instantiate(objectToPool, this.transform);
            obj.SetActive(false);
            pool.Add(obj);
            return obj;
        }
        else
        {
            return null;
        }
    }

    public void DestroyRemainingObjectsInPool()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            Destroy(pool[i]);
        }
        pool.Clear();
    }

    public IEnumerator PopulatePool()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool, this.transform);
            obj.SetActive(false);
            pool.Add(obj);
            yield return null;
        }
    }
}
