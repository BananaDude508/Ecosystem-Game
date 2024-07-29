using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static PlayerInventory;
using static AllPlantsManager;
using static SustainPlantsBetweenScenes;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerFarming : MonoBehaviour
{
	public GameObject[] plants;
	public static int currentPlant; // current plant selection

	public TextMeshProUGUI[] plantTexts;
	public GameObject[] inventoryButtons;

	public LayerMask plantLayer;
	private bool touchingPlant = false;

	public LayerMask canPlantOn;

	public static Transform plantParent;

	private bool inGameScene = true;

	public EventSystemKeepSelected buttonHighlighter;

	public TextMeshProUGUI moneyText;

	public InventoryUI inventoryUI;

	public AudioSource playerPlantSource;
	public AudioClip plantingSound;

	public AudioSource playerUISound;
	public AudioClip uiClickSound;

    private void Awake()
    {
		inGameScene = SceneManager.GetActiveScene().name == "Game";
		if (inGameScene)
		{
			buttonHighlighter.defaultSelected = inventoryButtons[currentPlant];
		}
    }

    private void Start()
	{
		UpdatePlantAmounts();
        if (plantParent == null)
			plantParent = instance.gameObject.transform;
    }

    private void Update()
	{
		if (!inGameScene) return;

		Item equippedItem = items[itemTypes[currentPlant]];
		if (!touchingPlant && !inventoryUI.hoveringOverInv && equippedItem.amount > 0 && Input.GetMouseButtonDown(0))
		{
			if (!PlantBoundsAllowed()) return;
			Instantiate(plants[currentPlant], transform.position.Round(), Quaternion.identity, plantParent);
			equippedItem.amount--;
			UpdatePlantAmounts();
            playerPlantSource.clip = plantingSound;
            playerPlantSource.Play();
			// print("playing sound");
		}

		if (touchingPlant && Input.GetMouseButtonDown(1))
		{
			PlantGrowth targetPlant = GetPlantCollision();
			if (targetPlant == null) return;
			string type = targetPlant.plantType;

			items[type].amount += targetPlant.harvestReward;
			UpdatePlantAmounts();
			Debug.Log(targetPlant.harvestReward + " " + type + " gained");
			Debug.Log("Current amount of " + type + " is " + items[type].amount);

			RemovePlant(targetPlant);
			Destroy(targetPlant.gameObject);
		}

		moneyText.text = '$' + money.ToString();
	}

	private PlantGrowth GetPlantCollision()
	{
		PlantGrowth hit = Physics2D.OverlapCircle(transform.position, 0.5f, plantLayer).GetComponent<PlantGrowth>();
		return hit;
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Plant")
			touchingPlant = true;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Plant")
			touchingPlant = false;
	}

	public void PreparePlant(int newPlantInvId)
	{
		currentPlant = newPlantInvId;
	}

	public void PlayClickSound()
	{
		playerUISound.clip = uiClickSound;
		playerUISound.Play();
	}

	public void UpdatePlantAmounts()
    {
        foreach (var item in items)
			plantTexts[itemTypes.IndexOf(item.Key)].text = items[item.Key].amount.ToString();
	}

	// private bool HoveringOverUI()
	// {
	// 	Vector3 pos = Input.mousePosition;
	// 
	// 	// This is the bounding box for the inventory. will need to find a
	// 	// better solution if more ui interactables are added
	// 
	// 	return pos.x >= 0.30 * Screen.width   // 585/1920
	// 		&& pos.x <= 0.70 * Screen.width   // 1335/1920
	// 	    && pos.y >= 0.02 * Screen.height  // 25/1080
	// 	    && pos.y <= 0.21 * Screen.height; // 225/1080
	// 
	// 	// the values arent random, they are the (rounded) percentage
	// 	// of how far across the screen they are, % shown on right comment
	// }

	private bool PlantBoundsAllowed()
	{
        Collider2D[] bBox = Physics2D.OverlapBoxAll(transform.position.Round(), new Vector2(0.75f, 0.75f), 0, ~canPlantOn);
		
		foreach (var collider in bBox) if (!collider.isTrigger) return false;

		return true;
	}
}