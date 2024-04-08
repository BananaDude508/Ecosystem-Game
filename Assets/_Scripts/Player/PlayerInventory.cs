using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static PlayerInventory;


public static class PlayerInventory
{
    public static int money = 0;

    public static Dictionary<string, Item> items = new Dictionary<string, Item>();

    public static void AddItem(string name)
    {
        items.Add(name, new Item(name));
    }
}

public class Item
{
    public string name;
    public int amount;


    public Item(string name)
    {
        this.name = name;
        amount = 0;
    }

    public void AddFromShop(ShopItem shopItem, int amount)
    {
        // add an actual shop ui and interactable so this can be tested properly

        Item newItem = new Item(shopItem.name);


        if (!Exists(newItem))
            items.Add(newItem.name, newItem);

        // also fix this whole mess of code that probably wont work
		items[newItem.name].amount += amount;
	}

    public bool Exists(Item item)
    {
        return items.ContainsKey(item.name);
    }
}