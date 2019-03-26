using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float levelStartDelay = 2f;
    public float turnDelay = .1f;
    public BoardManager boardScript;
    public static GameManager instance = null;
    public int foodPoints = 200;
    public bool playerTurn = true;

    private int level = 1;
    private Text levelText;
    private GameObject levelImage;
    private List<Enemy> enemyList;
    private bool enemiesMoving = false;
    private bool doingSetup;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        enemyList = new List<Enemy>();
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }
    
    void InitGame()
    {
        doingSetup = true;
        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelText.text = "Day " + level;
        levelImage.SetActive(true);
        Invoke("HideLevelImage", levelStartDelay);
        enemyList.Clear();
        boardScript.SetupScene(level);
    }

    void HideLevelImage()
    {
        levelImage.SetActive(false);
        doingSetup = false;
    }

    public void GameOver()
    {
        levelText.text = "After " + level + " days, you starved.";
        levelImage.SetActive(true);
        enabled = false;
    }

    private void Update()
    {
        if (playerTurn || enemiesMoving || doingSetup)
        {
            return;
        }
        StartCoroutine(MoveEnemies());
    }

    public void AddEnemyToList(Enemy script)
    {
        enemyList.Add(script);
    }
    
    IEnumerator MoveEnemies()
    {
        enemiesMoving = true;
        yield return new WaitForSeconds(turnDelay);
        if (enemyList.Count == 0)
        {
            yield return new WaitForSeconds(turnDelay);
            playerTurn = true;
        }
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i].isActiveAndEnabled)
            {
                enemyList[i].MoveEnemy();
                yield return new WaitForSeconds(turnDelay);
            }
            else
            {
                enemyList.RemoveAt(i);
                yield return new WaitForSeconds(turnDelay);
            }
        }
        playerTurn = true;
        enemiesMoving = false;
    }

    //This is called each time a scene is loaded.
    static private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        instance.level++;
        instance.InitGame();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static public void CallbackInitialization()
    {
        //register the callback to be called everytime the scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
}
