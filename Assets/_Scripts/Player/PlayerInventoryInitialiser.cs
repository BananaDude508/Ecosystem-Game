using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using static PlayerInventory;

public class PlayerInventoryInitialiser : MonoBehaviour
{
	public List<string> itemTypesINIT = new List<string>();

    private void Awake()
	{
		itemTypes = itemTypesINIT;

		foreach (var type in itemTypes)
			AddItem(type).amount = 1;

		// foreach (var item in items)
		// 	Debug.Log(item.Key);
	}
}
