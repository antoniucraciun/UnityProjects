using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<Colors> colorsToGuess;
    public List<Square> colorsGuessed;
    public List<Square> colors;

    public TMP_Text txtScore;
    public GameObject mainMenu;
    public Animator animPause;
    public Animator animLevelComplete;
    public Animator animLevelFailed;

    public static GameManager instance;

    public GamePhase gp;

    public int score = 0;
    
    private IEnumerator showColors = null;

    private int numberOfColorsToGuess = 4;

    private float colorShowDelay = 0.5f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        colorsToGuess = new List<Colors>();
        colorsGuessed = new List<Square>();
        gp = GamePhase.Menu;
    }
    
    void Update()
    {
        switch (gp)
        {
            case GamePhase.Started:
                SetScore();
                colorsGuessed.Clear();
                SetColorsToGuess();
                showColors = ShowColors();
                StartCoroutine(showColors);
                break;
            case GamePhase.Ended:
                foreach (var item in colors)
                {
                    item.NormalColor();
                }
                if (CheckAnswer())
                {
                    gp = GamePhase.Menu;
                    numberOfColorsToGuess++;
                    animLevelComplete.SetTrigger("FadeIn");
                }
                else
                {
                    gp = GamePhase.Menu;
                    numberOfColorsToGuess = 4;
                    score = 0;
                    animLevelFailed.SetTrigger("FadeIn");
                }
                break;
            case GamePhase.Paused:
                StopCoroutine(showColors);
                break;
            case GamePhase.Playing:
                if (colorsGuessed.Count == colorsToGuess.Count)
                    gp = GamePhase.Ended;
                break;
            case GamePhase.Resumed:
                showColors = ShowColors();
                StartCoroutine(showColors);
                break;
            default:
                break;
        }
    }

    public void SetColorsToGuess()
    {
        int colorId = 0;
        colorsToGuess.Clear();

        for (int i = 0; i < numberOfColorsToGuess; i++)
        {
            colorId = Random.Range(0, 4);
            switch (colorId)
            {
                case 0:
                    colorsToGuess.Add(Colors.Red);
                    break;
                case 1:
                    colorsToGuess.Add(Colors.Blue);
                    break;
                case 2:
                    colorsToGuess.Add(Colors.Yellow);
                    break;
                case 3:
                    colorsToGuess.Add(Colors.Green);
                    break;
            }
        }
    }

    public IEnumerator ShowColors()
    {
        gp = GamePhase.ShowColors;
        yield return new WaitForSeconds(colorShowDelay);
        for (int i = 0; i < colorsToGuess.Count; i++)
        {
            if (colorsToGuess[i] == Colors.Red)
            {
                colors[0].ShowColor();
                yield return new WaitForSeconds(colorShowDelay);
                colors[0].NormalColor();
                yield return new WaitForSeconds(colorShowDelay);
            }
            else if (colorsToGuess[i] == Colors.Blue)
            {
                colors[1].ShowColor();
                yield return new WaitForSeconds(colorShowDelay);
                colors[1].NormalColor();
                yield return new WaitForSeconds(colorShowDelay);
            }
            else if (colorsToGuess[i] == Colors.Yellow)
            {
                colors[2].ShowColor();
                yield return new WaitForSeconds(colorShowDelay);
                colors[2].NormalColor();
                yield return new WaitForSeconds(colorShowDelay);
            }
            else if (colorsToGuess[i] == Colors.Green)
            {
                colors[3].ShowColor();
                yield return new WaitForSeconds(colorShowDelay);
                colors[3].NormalColor();
                yield return new WaitForSeconds(colorShowDelay);
            }
        }
        gp = GamePhase.Playing;
        yield return new WaitForEndOfFrame();
    }

    public bool CheckAnswer()
    {
        for (int i = 0; i < numberOfColorsToGuess; i++)
        {
            if (colorsGuessed[i].c != colorsToGuess[i])
                return false;
            else
                score++;
        }
        return true;
    }

    public void OnBeginPlay()
    {
        gp = GamePhase.Started;
    }

    public void Pause()
    {
        gp = GamePhase.Paused;
        animPause.SetTrigger("FadeIn");
    }

    public void EndGame()
    {
        gp = GamePhase.Ended;
    }

    public void ResumeGame()
    {
        gp = GamePhase.Resumed;
        animPause.SetTrigger("FadeOut");
    }

    public void NextLevel()
    {
        gp = GamePhase.Started;
        animLevelComplete.SetTrigger("FadeOut");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        numberOfColorsToGuess = 4;
        score = 0;
        gp = GamePhase.Started;
    }

    public void SetTriggerFailed()
    {
        animLevelFailed.SetTrigger("FadeOut");
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);
        numberOfColorsToGuess = 4;
        score = 0;
        gp = GamePhase.Started;
    }

    public void SetScore()
    {
        txtScore.text = "Score: " + score;
    }

    public void ToggleLow(bool value)
    {
        if (value)
            QualitySettings.SetQualityLevel(1);
    }

    public void ToggleMedium(bool value)
    {
        if (value)
            QualitySettings.SetQualityLevel(3);
    }

    public void ToggleHigh(bool value)
    {
        if (value)
            QualitySettings.SetQualityLevel(5);
    }
}

public enum GamePhase
{
    Started,
    Ended,
    Paused,
    Playing,
    Resumed,
    ShowColors,
    Menu
}

public enum Colors
{
    Red = 0,
    Blue = 1,
    Yellow = 2,
    Green = 3
}