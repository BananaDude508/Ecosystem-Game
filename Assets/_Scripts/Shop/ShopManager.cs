using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static PlayerInventory;

public class ShopManager : MonoBehaviour
{
    public ShopItem[] shopItems;

    public void Start()
    {
        new ShopItem("wheat", "A farmers most basic crop, always in supply and in demand", 10, 10, 10, -1); // least expensive
        // new ShopItem("Tomato"); 
        // new ShopItem("Potato"); 
        // new ShopItem("Carrot"); most expensive
    }

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

    public void SellItem(Item item)
    {
        // sell item to shop, gain money from it
        // item.Sell();
    }

    public void ReturnToFarm()
    {
        SceneManager.LoadScene("Game");
    }
}

public class ShopItem
{
    public string name;
    public string description;
    public int originalAmount;
    public int amountPurchasedToday;
    public int amountSoldToday;
    public int stockModifier;
    public int priceModifier;
    public int price;


    public ShopItem(string name, string description, int price, int amount, int stockModifier, int priceModifier)
    {
        this.name = name;
        this.description = description;
        this.price = price;
        this.originalAmount = amount;
        this.stockModifier = stockModifier;
        this.priceModifier = priceModifier;
        this.amountPurchasedToday = 0;
    }

	public int UpdatePrice()
    {
		price *= Mathf.RoundToInt(Random.Range(0.5f, 1.5f) * (10 + amountSoldToday - amountPurchasedToday)) - price + priceModifier;
        // find a way to limit price so it doesnt shoot up to infinity over time
        return price;
	}

    public int Restock()
    {
        amountPurchasedToday = 0;
        originalAmount = Mathf.Clamp(originalAmount + Random.Range(-2, 2), 5, 10) + stockModifier;
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