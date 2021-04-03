using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicItem", menuName = "Item")]
public class Item : ScriptableObject
{
	public string itemName;
	public int count = 1;
}
