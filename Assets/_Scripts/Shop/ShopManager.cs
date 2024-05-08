using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static PlayerInventory;
using static CustomFunctions;
using static AllPlantsManager;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public List<ShopItem> shopItems = new List<ShopItem>();
    // public Button[] buyButtons;
    // public Button[] sellButtons;
    public TextMeshProUGUI[] buyPrices;
    public TextMeshProUGUI[] sellPrices;
    public TextMeshProUGUI[] inventoryAmounts;
    public TextMeshProUGUI moneyText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);

            shopItems.Add(new ShopItem("Wheat", 10, 20)); // least expensive
            shopItems.Add(new ShopItem("Tomato", 15, 15));
            shopItems.Add(new ShopItem("Potato", 25, 10));
            shopItems.Add(new ShopItem("Carrot", 55, 5)); // most expensive
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnLevelChange;
    }

    public void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            buyPrices[i].text = shopItems[i].price.ToString();
            sellPrices[i].text = Mathf.RoundToInt(shopItems[i].price * 0.75f).ToString();
            inventoryAmounts[i].text = items[shopItems[i].name.ToLower()].amount.ToString();
            print(items[shopItems[i].name.ToLower()].amount.ToString());
        }
        UpdateMoney();
    }

    public void ShopNewDay()
    {
        foreach (var item in shopItems)
        {
            item.Restock();
            item.UpdatePrice();
        }
    }
    
    public void BuyItem(int itemID)
    {
        ShopItem item = shopItems[itemID];

        if (money < item.price) return;

        items[item.name.ToLower()].amount++;
        money -= item.price;

        inventoryAmounts[itemID].text = items[item.name.ToLower()].ToString();
        UpdateMoney();
    }

    public void SellItem(int itemID)
    {
        ShopItem item = shopItems[itemID];

        if (items[item.name.ToLower()].amount <= 0) return;

        items[item.name.ToLower()].amount--;
        money += Mathf.RoundToInt(item.price * 0.75f);

        inventoryAmounts[itemID].text = items[item.name.ToLower()].amount.ToString();
        UpdateMoney();
    }

    public void ReturnToFarm()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void UpdateMoney()
    {
        moneyText.text = "$" + money.ToString();
    }

    private void OnLevelChange(Scene scene, LoadSceneMode sceneLoadMode)
    {
        for (int i = 0; i < sleepsOutsideGame; i++)
        {
            ShopNewDay();
        }
    }
}

public class ShopItem
{
    public string name;
    public int price;
    private int day1Price;
    public int stock;
    private int day1Stock;
    public int amountPurchased;


    /// <summary>
    /// ShopItem initialiser
    /// </summary>
    /// <param name="name">The name of the item</param>
    /// <param name="price">The basic/initial price of the item</param>
    /// <param name="stock">The default/initial stock of the item</param>
    public ShopItem(string name, int price, int stock)
    {
        this.name = name;
        this.price = price;
        this.day1Price = price;
        this.stock = stock;
        this.day1Stock = stock;
        this.amountPurchased = 0;
    } 

    public void Restock()
    {
        amountPurchased = 0;
        stock += Random.Range(-2, 2);
        stock = stock.Limit(day1Stock - 3, day1Stock + 4);
    }

    public void UpdatePrice()
    {
        price = Mathf.RoundToInt(price * Random.Range(0.9f, 1.1f));
        price = Mathf.RoundToInt(((float)price).Limit(day1Price * 0.6f, day1Price * 1.4f));
    }
}