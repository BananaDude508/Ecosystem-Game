using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using static PlayerInventory;

public class PlayerInventoryInitialiser : MonoBehaviour
{
	public string[] itemTypes = new string[0];

	private void Awake()
	{
		foreach (var type in itemTypes)
			AddItem(type);

		foreach (var item in items)
			Debug.Log(item.Key);
	}
}
