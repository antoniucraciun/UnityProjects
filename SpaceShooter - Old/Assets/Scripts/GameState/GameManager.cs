using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class EnemyTypes
{
    public string enemyType;
    public GameObject[] smallEnemies;
    public GameObject[] mediumEnemies;
    public GameObject[] bosses;
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public EnemyTypes[] enemies;
    public Transform[] enemySpawns;
    public GameObject[] ships;
    public GameObject player;
    public SaveVars save;
    public int shipIndex;
    //player resources
    private int coinsCollected = 0;
    private int gemsCollected = 0;
    //level variables
    private bool levelStarted = false;

    public int score;

	void Start ()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
	}

    void Update()
    {
        if (levelStarted)
        {
            //check if the player is alive
            //if (player == null)
            //   player = GameObject.FindGameObjectWithTag("Player");
            if (player != null && !player.GetComponent<PlayerHealth>().GetAlive())
                levelStarted = false;
        }
    }

    public void CollectCoins(int amount)
    {
        coinsCollected += amount;
    }

    public void CollectGems()
    {
        gemsCollected += 1;
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            levelStarted = false;
            save.coinsCollected += coinsCollected;
            save.gemsCollected += gemsCollected;
            LoadInSave.Instace.Load();
        }
        else
        {
            levelStarted = true;
            save.totalMissionsPlayed++;
            player = Instantiate(ships[shipIndex]);
        }
    }
}
