using UnityEngine;

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
}

public enum SceneType
{
    Main = 1,
    Level = 2
}