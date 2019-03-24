using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelInput : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    public void InputLetter(string text)
    {
        string wordstr = "";
        for (int i = 0; i < gm.letterString.Count; i++)
        {
            wordstr += gm.letterString[i];
        }
        for (int i = 0; i < gm.letterString.Count; i++)
        {
            if (!string.Equals(text.ToLower(), wordstr.ToLower()))
            {
                gm.guessText.text = "Nivel esuat!";
                gm.guessText.enabled = true;
                gm.CallRestart();
                return;
            }
        }
        gm.guessText.text = "Nivel complet!";
        gm.guessText.enabled = true;
    }
}
