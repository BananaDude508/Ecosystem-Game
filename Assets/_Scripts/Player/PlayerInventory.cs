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

    public static Goal currentGoal;

    public static int waterCanLevel = 0;

    public static Item AddItem(string name)
    {
        if (items.ContainsKey(name)) return new Item();
        Item item = new Item(name);
        items.Add(name, item);
        return item;
    }

    public static bool TryWaterPlant()
    {
        if (waterCanLevel <= 0) return false;
        waterCanLevel--;
        return true;
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


        if (!newItem.Exists())
            items.Add(newItem.name, newItem);

        // also fix this whole mess of code that probably wont work
		items[newItem.name].amount += amount;
	}

    public bool Exists()
    {
        return items.ContainsKey(name);
    }
}
