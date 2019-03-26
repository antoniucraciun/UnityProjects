using UnityEngine;

[CreateAssetMenu(menuName = "Data/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon;
    public Color iconColor;

    public string contentString;
    public int amount;
    public int price;
}
