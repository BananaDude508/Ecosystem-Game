using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInventory;

public class ShopManager : MonoBehaviour
{
    public ShopItem[] shopItems;


    public void ResetShop()
    {
        foreach (var item in shopItems)
        {
            item.UpdatePrice();
            item.Restock();
        }
    }

    public void BuyItem(ShopItem item)
    {
        item.Purchase();
    }
}

public class ShopItem
{
    public string name;
    public string description;
    public int price;
    public int originalAmount;
    public int amountPurchasedToday;


    public ShopItem(string name, string description, int price, int amount)
    {
        this.name = name;
        this.description = description;
        this.price = price;
        this.originalAmount = amount;
        amountPurchasedToday = 0;
    }

	public int UpdatePrice()
    {
		price *= Mathf.RoundToInt(Random.Range(0.5f, 1.5f) * (amountPurchasedToday + 10)) - price;
        return price;
	}

    public int Restock()
    {
        amountPurchasedToday = 0;
        originalAmount = Mathf.Clamp(originalAmount + Random.Range(-2, 2), 5, 10);
        return originalAmount;
    }

    public bool Purchase()
    {
        if (amountPurchasedToday >= originalAmount) return false;

        amountPurchasedToday++;
        money -= price;
        // Add to player inventory

        return true;
    }
}