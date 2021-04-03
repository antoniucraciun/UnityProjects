using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Dictionary<string, ObjectPooler> poolParty;

    public static GameController sharedInstance;

    private void Awake()
    {
        sharedInstance = this;
        poolParty = new Dictionary<string, ObjectPooler>();
    }
}
