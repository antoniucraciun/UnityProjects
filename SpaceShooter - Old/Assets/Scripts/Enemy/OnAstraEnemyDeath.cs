using UnityEngine;

public class OnAstraEnemyDeath : MonoBehaviour
{
    private void OnDestroy()
    {
        if (gameObject.layer == 8)
        {
            AstraGameController.astraBossKilled++;
            return;
        }
        AstraGameController.astraEnemiesKilled++;
    }
}
