using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerUtility : MonoBehaviour
{
    public SceneType mySceneType;

    void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        switch (mySceneType)
        {
            case SceneType.Main:
                Screen.orientation = ScreenOrientation.Landscape;
                break;
            case SceneType.Level:
                Screen.orientation = ScreenOrientation.Portrait;
                break;
            default:
                break;
        }
    }

    //TODO: Remove function after testing
    //START
    public void GoBack()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void LoadTestScene()
    {
        SceneManager.LoadSceneAsync(1);
    }
    //END
}

public enum SceneType
{
    Main = 1,
    Level = 2
}