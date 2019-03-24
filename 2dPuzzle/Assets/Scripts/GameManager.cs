using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public RiddleSO riddle;
    //list used for storing the background images
    public List<GameObject> background = new List<GameObject>();
    //list used for storing the word
    public List<string> letterString = new List<string>();
    //list used for checking how many letters the player found
    public List<int> lettersFound = new List<int>();

    //an instance of GameManager class
    public static GameManager instance;
    
    //text mesh pro text vars
    public TMP_Text chestTMText;
    public TMP_Text coinTMText;
    public TMP_Text livesText;
    public TMP_Text finalWord;
    public TMP_Text riddleText;
    public TMP_Text guessText;

    public TMP_InputField inputField;
    
    //total coin value
    int totalValue = 0;

    //used for storing the player position
    public Transform targetPosition;
    private void Awake()
    {
        //making the game manager a singleton
        //you can call this script from anywhere in the game by GameManager.instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //the game object that contains this script shouldn't be destroyed
        DontDestroyOnLoad(gameObject);
        chestTMText = GameObject.FindGameObjectWithTag("ChestText").GetComponent<TMP_Text>();
        coinTMText = GameObject.FindGameObjectWithTag("CoinText").GetComponent<TMP_Text>();
        livesText = GameObject.FindGameObjectWithTag("LivesText").GetComponent<TMP_Text>();
        finalWord = GameObject.FindGameObjectWithTag("RiddleWordText").GetComponent<TMP_Text>();
        riddleText = GameObject.FindGameObjectWithTag("RiddleText").GetComponent<TMP_Text>();
        guessText = GameObject.FindGameObjectWithTag("GuessText").GetComponent<TMP_Text>();
        inputField = GameObject.FindGameObjectWithTag("InputField").GetComponent<TMP_InputField>();
        GameObject.FindGameObjectWithTag("InputField").transform.position = new Vector3(0, -1000, 0);
        finalWord.enabled = false;
        riddleText.enabled = false;
        inputField.enabled = false;
        guessText.enabled = false;
        GameObject[] bckg = GameObject.FindGameObjectsWithTag("BackGround");
        foreach (var item in bckg)
        {
            background.Add(item);
        }
        //initialize the variables
        chestTMText.text = "";
        coinTMText.text = "  Points: " + totalValue.ToString();
    }
    //use this for creating lists or game objects
    private void Start()
    {
        //create a list of word Google
        CreateList(riddle.levelWord);
        for (int i = 0; i < letterString.Count; i++)
        {
            lettersFound.Add(0);
        }
    }

    private void LateUpdate()
    {
        DoBackGroundMovement();
    }

    public void UpdateCoinText(int value)
    {
        //change the total value
        totalValue += value;
        //printing the total coin value 
        coinTMText.text = "  Points: " + totalValue.ToString();
    }

    //used for displaying the text
    public IEnumerator ChangeText(string letter)
    {
        if (chestTMText != null)
        {
            yield return null;
            //change the chest text to see what letter the player got
            chestTMText.text = "You got the letter: " + letter + "!";
            //wait 5 seconds
            yield return new WaitForSeconds(5f);
            //clear the chest text
            chestTMText.text = "";
            yield return null;
        }
        else if (chestTMText == null)
        {
            Debug.Log("No text box!");
            yield return null;
        }
    }

    public void CreateList(string word)
    {
        //we should start with a clear list so we don't add new letters on top of the old ones
        letterString.Clear();
        //iterate through the word
        for (int i = 0; i < word.Length; i++)
        {
            //add each letter in the list
            letterString.Add(word[i].ToString());
        }
    }

    public void OnEndOfGame()
    {
        int i = 0;
        finalWord.text = "";
        for (i = 0; i < letterString.Count; i++)
        {
            if (lettersFound[i] == 1)
            {
                finalWord.text += letterString[i] + " ";
            }
            else
            {
                finalWord.text += "_ ";
            }
        }
        riddleText.text = riddle.levelRiddle;
        GameObject.FindGameObjectWithTag("InputField").SetActive(true);
        finalWord.enabled = true;
        riddleText.enabled = true;
    }

    void DoBackGroundMovement()
    {
        if (background.Count == 0)
            return;

        if (background == null)
        {
            Debug.Log("No backgrounds!");
            return;
        }

        for (int i = 0; i < background.Count; i++)
        {
            //ternary if
            int div = i == 0 ? 1 : i;
            //set the position of the image
            background[i].transform.position = new Vector3(targetPosition.position.x,
                                                           targetPosition.position.y,
                                                           background[i].transform.position.z);
            //background scrolling
            background[i].gameObject.GetComponent<SpriteRenderer>().material.mainTextureOffset 
                = 
            new Vector2(targetPosition.position.x / 20 / div, 0);
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        background.Clear();
        Inventory.instance.OnSceneChange();
        //reset each list and the word to find
        //check if the position is set correctly
        if (targetPosition == null)
        {
            targetPosition = GameObject.FindGameObjectWithTag("Player").transform;
        }
        //check if the background variables are set correctly
        if (background == null || background.Count == 0)
        {
            GameObject[] bckg = GameObject.FindGameObjectsWithTag("BackGround");
            //Debug.Log(bckg[0]);
            background = new List<GameObject>();
            for (int i = 0; i < bckg.Length; i++)
            {
                background.Add(bckg[i]);
            }
        }
        //check if the text variables are set correctly
        if (chestTMText == null)
            chestTMText = GameObject.FindGameObjectWithTag("ChestText").GetComponent<TMP_Text>();
        if (coinTMText == null)
            coinTMText = GameObject.FindGameObjectWithTag("CoinText").GetComponent<TMP_Text>();
        if (livesText == null)
            livesText = GameObject.FindGameObjectWithTag("LivesText").GetComponent<TMP_Text>();
        if (finalWord == null)
        {
            finalWord = GameObject.FindGameObjectWithTag("RiddleWordText").GetComponent<TMP_Text>();
            finalWord.enabled = false;
        }
        if (riddleText == null)
        {
            riddleText = GameObject.FindGameObjectWithTag("RiddleText").GetComponent<TMP_Text>();
            riddleText.enabled = false;
        }
        for (int i = 0; i < letterString.Count; i++)
        {
            lettersFound[i] = 0;
        }
        guessText = GameObject.FindGameObjectWithTag("GuessText").GetComponent<TMP_Text>();
        inputField = GameObject.FindGameObjectWithTag("InputField").GetComponent<TMP_InputField>();
        GameObject.FindGameObjectWithTag("InputField").transform.position = new Vector3(0, -1000, 0);
        inputField.enabled = false;
        guessText.enabled = false;
    }
    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CallRestart()
    {
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(5f);
        ResetLevel();
    }
}
