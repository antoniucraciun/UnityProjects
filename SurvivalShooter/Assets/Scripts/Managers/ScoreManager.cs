using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    private int scorePoints;
    private int oldScore;
    public int totalPoints = 0;

    public static ScoreManager instance;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        totalPoints = scorePoints;
        if (oldScore != totalPoints)
        {
            scoreText.text = "Score: " + totalPoints;
            oldScore = totalPoints;
        }
    }

    public void IncreasePoints(int amount)
    {
        scorePoints += amount;
    }

}
