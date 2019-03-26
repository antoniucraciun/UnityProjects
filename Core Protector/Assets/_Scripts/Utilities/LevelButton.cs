using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public bool levelLocked = true;
    public string levelName;
    public int levelNumber;

    private void OnEnable()
    {
        if (levelNumber < Data.levelsUnlocked)
            levelLocked = false;
    }

    public void OnPlayCliked()
    {
        if (!levelLocked)
        {
            SceneManager.LoadSceneAsync(levelName);
        }
    }
}
