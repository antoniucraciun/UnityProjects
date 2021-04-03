using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryData
{
	public Item[] itemArray;

	public InventoryData()
	{

	}

	public InventoryData(Inventory inventory)
	{
		itemArray = new Item[10];
	}
}
