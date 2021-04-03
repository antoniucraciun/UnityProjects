using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	private int inventorySpace;
	private List<Item> items;

	public event Action OnInventoryChanged;

	private void Start()
	{
		items = new List<Item>();
		//Get saved items
	}

	public void AddItem(Item item)
	{
		items.Add(item);
		OnInventoryChanged?.Invoke();
	}
}
