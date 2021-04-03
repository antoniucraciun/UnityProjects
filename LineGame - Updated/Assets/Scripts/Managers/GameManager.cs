using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Advertisements;

[System.Serializable]
public class Enemies
{
    public string enemyName;
    public GameObject enemy;
    [Range(0, 100)]
    public float spawnChance;

    
}

public class GameManager : MonoBehaviour
{
    public static bool gameOver = false;
    public static bool levelChanged = false;
    public bool backClicked = false;
    public List<Enemies> enemiesModular;
    
    public GameObject gameOverMenu;

    public static int score = 0;
    public int oldScoreValue = 0;
    public static int lives = 0;
    public int oldLivesValue = 0;
    public static int enemyNumber;
    public static int enemiesKilled;
    public static int maxEnemies = 30;
    public float timeBetweenEnemyDelay = 0.5f;

    public Vector3 upLowerLimit;
    public Vector3 upUpperLimit;
    public Vector3 downLowerLimit;
    public Vector3 downUpperLimit;

    #region TextVariables
    [HideInInspector]
    public TMP_Text scoreText;
    [HideInInspector]
    public TMP_Text shieldText;
    [HideInInspector]
    public TMP_Text moneyText;
    [HideInInspector]
    public TMP_Text damageTextShop;
    [HideInInspector]
    public TMP_Text damagePriceTextShop;
    [HideInInspector]
    public TMP_Text shieldTextShop;
    [HideInInspector]
    public TMP_Text shieldPriceTextShop;
    [HideInInspector]
    public TMP_Text pulseTextShop;
    [HideInInspector]
    public TMP_Text pulsePriceTextShop;
    [HideInInspector]
    public TMP_Text defendersTextShop;
    [HideInInspector]
    public TMP_Text defendersPriceTextShop;
    [HideInInspector]
    public TMP_Text levelText;
    [HideInInspector]
    public TMP_Text armorText;
    #endregion

    public Controller ctrl;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        Data.Save();
        Data.Load();
        ctrl = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
    }

    private void Update()
    {
        lives = DefenseTarget.shield;
        if (oldScoreValue != score)
        {
            scoreText.text = score.ToString();
            oldScoreValue = score;
        }
        if (oldLivesValue != lives)
        {
            shieldText.text = lives.ToString();
            oldLivesValue = lives;
        }
        if (levelChanged)
        {
            levelChanged = false;
            ChangeLevel();
        }
        if (gameOver == true)
        {
            Time.timeScale = 0;
            if (!backClicked)
                gameOverMenu.SetActive(true);
            StopCoroutine(SpawnerModular());
            if (Data.scoreMax < score)
            {
                Data.scoreMax = score;
                ctrl.IncreaseMoney(5);
                Data.Save();
                Data.Load();
            }
            if (Data.levelMax < ctrl.level)
            {
                Data.levelMax = ctrl.level;
                ctrl.IncreaseMoney(5);
                Data.Save();
                Data.Load();
            }
        }
    }

    public void OnPlayClicked() //Start the game
    {
        gameOverMenu.SetActive(false);
        CleanUp();
        enemiesKilled = 0;
        gameOver = false;
        backClicked = false;
        DefenseTarget.Restart();
        StartCoroutine(SpawnerModular());
        score = 0;
        scoreText.text = score.ToString();
        shieldText.text = lives.ToString();
        ctrl.level = 1;
        score = 0;
        enemiesKilled = 0;
        Data.level = 1;
        Data.Save();
        Data.Load();
        Time.timeScale = 1;
        levelText.text = ctrl.level.ToString();
        AchievementSystem.ResetAll();
    }
    
    public void ResetAd() //Function that resets the game without losing progress
    {
        gameOverMenu.SetActive(false);
        CleanUp();
        gameOver = false;
        backClicked = false;
        DefenseTarget.Restart();
        StartCoroutine(SpawnerModular());
        scoreText.text = score.ToString();
        shieldText.text = lives.ToString();
        Data.Save();
        Data.Load();
        Time.timeScale = 1;
        levelText.text = ctrl.level.ToString();
    }

    public void OnBackClicked()
    {
        backClicked = true;
        gameOverMenu.SetActive(false);
    }
    
    public IEnumerator SpawnerModular()
    {
        bool spawned = false;
        while (gameOver == false)
        {
            while (enemyNumber < 10 * Data.level && enemyNumber <= maxEnemies)
            {
                spawned = false;
                int updown = (int)Random.Range(0, 2);
                Vector3 position = Vector3.zero;
                if (updown == 0)
                {
                    position.x = Random.Range(upLowerLimit.x, upUpperLimit.x);
                    position.y = Random.Range(upLowerLimit.y, upUpperLimit.y);
                }
                else
                {
                    position.x = Random.Range(downLowerLimit.x, downUpperLimit.x);
                    position.y = Random.Range(downLowerLimit.y, downUpperLimit.y);
                }
                foreach (var item in enemiesModular)
                {
                    var rand = Random.Range(0, 100);
                    if (rand < item.spawnChance)
                    {
                        spawned = true;
                        Instantiate(item.enemy, position, Quaternion.identity);
                        break;
                    }
                }
                if (!spawned)
                {
                    Instantiate(enemiesModular[0].enemy, position, Quaternion.identity);
                }
                yield return new WaitForSeconds(timeBetweenEnemyDelay);
            }
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(2f);
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }

    public void SetValues() //Set the UI variables
    {
        defendersTextShop.text = "Defenders: " + Data.numberOfDefenders.ToString();
        damagePriceTextShop.text = (Data.damage * 2).ToString();
        shieldPriceTextShop.text = (Data.shield * 2).ToString();
        pulsePriceTextShop.text = (Data.pulseDamage * 2).ToString();
        levelText.text = ctrl.level.ToString();
        armorText.text = (Data.armorPoints * 2).ToString();
        if (Data.numberOfDefenders != 4)
        {
            defendersPriceTextShop.text = (Data.numberOfDefenders * 200).ToString();
        }
        else
        {
            defendersPriceTextShop.text = "Max";
        }
        moneyText.text = Data.money.ToString();
    }
    
    public void ChangeLevel() //Function to check if the player killed enough enemies
    {
        AchievementSystem.Notify(AchievementType.EnemyKills, enemiesKilled);
        if (enemiesKilled >= Data.level * 30)
        {
            ctrl.IncreaseLevel();
            levelText.text = ctrl.level.ToString();
        }
        switch (enemiesKilled)
        {
            case 0:
                timeBetweenEnemyDelay = 0.5f;
                break;
            case 200:
                timeBetweenEnemyDelay = 0.4f;
                break;
            case 400:
                timeBetweenEnemyDelay = 0.3f;
                break;
            case 600:
                timeBetweenEnemyDelay = 0.2f;
                break;
            case 800:
                timeBetweenEnemyDelay = 0.1f;
                break;
            default:
                break;
        }
    }

    public void PlayAddShop() //Used for showing ads in shop
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("", new ShowOptions() { resultCallback = ManageAds });
        }
    }

    public void ManageAds(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                ctrl.IncreaseMoney(10);
                break;
            case ShowResult.Finished:
                ctrl.IncreaseMoney(20);
                break;
            default:
                break;
        }
        SetValues();
    }

    public void PlayAdReset() //Used for playing ads for resetting the level
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("", new ShowOptions() { resultCallback = ManageAdsReset });
        }
    }
    public void ManageAdsReset(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                ResetAd();
                break;
            case ShowResult.Finished:
                ResetAd();
                ctrl.IncreaseMoney(10);
                break;
            default:
                break;
        }
    }

    public void CleanUp() //Clean every enemy player shot and the pulse
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var item in enemies)
        {
            Destroy(item);
        }
        GameObject[] pulses = GameObject.FindGameObjectsWithTag("Pulse");
        foreach (var item in pulses)
        {
            Destroy(item);
        }
        GameObject[] playerShots = GameObject.FindGameObjectsWithTag("PlayerShot");
        foreach (var item in playerShots)
        {
            Destroy(item);
        }
    }
}