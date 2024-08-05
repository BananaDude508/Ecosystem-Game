using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInventory;

public class PlayerInventoryInitialiser : MonoBehaviour
{
	public List<string> itemTypesINIT = new List<string>();
    private void Awake()
	{
		itemTypes = itemTypesINIT;

        foreach (var type in itemTypes)
		{
			Item item = AddItem(type);
			switch (item.name)
			{
				case "wheat":
					item.amount = 2;
					break;
				case "tomato":
					item.amount = 1;
					break;
				case "watercan":
					item.amount = 1;
					break;
				default:
					item.amount = 0;
					break;
			}
		}
	}
}
