using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
	public Item typeOfItem;

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			other.GetComponent<Inventory>().AddItem(typeOfItem);
		}
		Destroy(gameObject);
	}
}
