using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadController : MonoBehaviour
{
    private void Awake()
    {
        Data.Load();
    }

    private void OnDestroy()
    {
        Data.Save();
    }
}
