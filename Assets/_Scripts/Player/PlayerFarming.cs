using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using static PlayerInventory;
using static AllPlantsManager;
using TMPro;

public class PlayerFarming : MonoBehaviour
{
	public GameObject[] plants;
	public int currentPlant;

	public TextMeshProUGUI[] plantTexts;

	public LayerMask plantLayer;
	private bool touchingPlant = false;

	public LayerMask canPlantOn;

	private Transform plantParent;


	private void Awake()
	{
		plantParent = GameObject.FindGameObjectWithTag("PlantParent").transform;
	}

	private void Start()
	{
		UpdateAllPlantAmounts();
	}

	private void Update()
	{
		Item equippedItem = items[itemTypes[currentPlant]];
		if (!touchingPlant && !HoveringOverUI() && equippedItem.amount > 0 && Input.GetMouseButtonDown(0))
		{
			if (!PlantBoundsAllowed()) return;
			Instantiate(plants[currentPlant], transform.position.Round(), Quaternion.identity, plantParent);
			equippedItem.amount--;
			UpdatePlantAmount(equippedItem);
		}

		if (touchingPlant && Input.GetMouseButtonDown(1))
		{
			PlantGrowth targetPlant = GetPlantCollision();
			if (targetPlant == null) return;
			string type = targetPlant.plantType;

			items[type].amount += targetPlant.harvestReward;
			UpdatePlantAmount(type);
			Debug.Log(targetPlant.harvestReward + " " + type + " gained");
			Debug.Log("Current amount of " + type + " is " + items[type].amount);

			RemovePlant(targetPlant);
			Destroy(targetPlant.gameObject);
		}
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

	public void UpdatePlantAmount(string plantType)
	{
		plantTexts[itemTypes.IndexOf(plantType)].text = items[plantType].amount.ToString();
	}

	void UpdatePlantAmount(Item plant)
	{
		UpdatePlantAmount(plant.name);
	}

	public void UpdateAllPlantAmounts()
	{
		foreach (var item in items)
		{
			UpdatePlantAmount(item.Key);

		}
	}

	private bool HoveringOverUI()
	{
		Vector3 pos = Input.mousePosition;

		// This is the bounding box for the inventory. will need to find a
		// better solution if more ui interactables are added
		// should have another scene for shop or whatever so this wont ever be called there either
		return pos.x >= 585
			&& pos.x <= 1335
		    && pos.y >= 25
		    && pos.y <= 225;
	}

	private bool PlantBoundsAllowed()
	{
        Collider2D[] bBox = Physics2D.OverlapBoxAll(transform.position.Round(), new Vector2(0.75f, 0.75f), 0, ~canPlantOn);
		
		foreach (var collider in bBox) if (!collider.isTrigger) return false;

		return true;
	}
}