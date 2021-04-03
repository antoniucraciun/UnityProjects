using UnityEngine;
using TMPro;

#pragma warning disable

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text numOfCharacters;
    public PlayerData pd;
    private void Start()
    {
        if (!pd.playerName.Equals("New Player"))
        {
            gameObject.SetActive(false);
        }
    }

    public void DisableObject(string input)
    {
        if (input.Length > 15 || input.Length < 3)
            return;
        gameObject.SetActive(false);
    }

    public void GetNumberOfCharacters(string input)
    {
        numOfCharacters.text = "Characters " + input.Length + "/15";
    }
}
