using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Chest")]
public class ChestData : ScriptableObject
{
    public List<Item> items;
    public int type;
    public Item OpenChest()
    {
        Item randomItem = items[Random.Range(0, items.Count)];
        return randomItem;
    }
}
