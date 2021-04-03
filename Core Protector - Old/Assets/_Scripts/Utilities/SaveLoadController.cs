using UnityEngine;

public class SaveLoadController : MonoBehaviour
{
    public PlayerData player;
    public Inventory inv;

    private void Awake() => SaveLoad.LoadPlayerData();

    private void OnDestroy() => SaveLoad.SavePlayer(player);
}
