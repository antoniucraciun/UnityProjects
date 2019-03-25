using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject enemy;
    public GameObject player;
    public GameObject gameOverUI;

    PlayerHealth playerHealth;
    bool canSpawn = true;
    bool gameOver = false;

    int enemyAmount = 10;

    float enemySpawnCd = 1f;
    float waveCd = 5f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        StartCoroutine(DoSpawnEnemy());
    }

    private void Update()
    {
        if (playerHealth.playerHealth <= 0)
        {
            gameOver = true;
        }
        if (gameOver)
        {
            gameOverUI.SetActive(true);
        }
    }

    IEnumerator DoSpawnEnemy()
    {
        if (!canSpawn)
        {
            yield break;
        }
        for (int i = 0; i < enemyAmount; i++)
        {
            RandomSpawn();
            yield return new WaitForSeconds(enemySpawnCd);
        }

        yield return new WaitForSeconds(waveCd);
        if (ScoreManager.instance.totalPoints > 5000)
        {
            enemyAmount += 10;
            enemySpawnCd = 0.5f;
            waveCd = 2.5f;
        }
        enemyAmount += 5;
        StartCoroutine(DoSpawnEnemy());
    }

    void RandomSpawn()
    {
        int spawnPointIndex;
        spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, Quaternion.identity);
        int zombieGrowl = Random.Range(0, 10);
        if (zombieGrowl < 1)
        {
            AudioManager.instance.PlaySound("ZombieSpawn", spawnPoints[spawnPointIndex].position);
        }
    }
}
