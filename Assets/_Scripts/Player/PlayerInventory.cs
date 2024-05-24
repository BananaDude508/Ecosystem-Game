using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static PlayerInventory;


public static class PlayerInventory
{
    public static int money = 0;

    public static Dictionary<string, Item> items = new Dictionary<string, Item>();
    public static List<string> itemTypes = new List<string>();

    public static Item AddItem(string name)
    {
        if (Exists(name)) return new Item();
        Item item = new Item(name);
        items.Add(name, item);
        return item;
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

    public Item()
    {
        this.name = null;
        this.amount = -1;
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

    public bool Exists(this Item item)
    {
        return items.ContainsKey(item.name);
    }

    public bool Exists(string name)
    {
        return items.ContainsKey(name);
    }
}
