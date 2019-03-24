using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    //this should stay on the game manager
    public static Inventory instance;

    public List<string> lettersFound = new List<string>();
    private void Awake()
    {
        //singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //this script shouldn't be destroyed when a new scene is loaded
        DontDestroyOnLoad(gameObject);
    }

    public List<int> CompareStrings(string word)
    {
        //used for the end of the game
        List<string> wordToCompare = new List<string>();
        List<int> letterFound = new List<int>();
        //separating each letter of the word
        for (int i = 0; i < word.Length; i++)
        {
            wordToCompare.Add(word[i].ToString());
            letterFound.Add(0);
        }
        //compare the 2 strings
        for (int i = 0; i < lettersFound.Count; i++)
        {
            for (int j = 0; j < wordToCompare.Count; j++)
            {
                if (wordToCompare[j] == lettersFound[i] && letterFound[j] == 0)
                {
                    letterFound[j] = 1;
                    break;
                }
            }
        }
        //return which letters the player found
        return letterFound;
    }

    public void NewLetterFound(string letter)
    {
        //if the player finds a new letter it's going to be added in the list
        lettersFound.Add(letter);
    }

    public void OnSceneChange()
    {
        //when the scene is changed then we should clear the letters we found so far
        lettersFound.Clear();
    }
}
