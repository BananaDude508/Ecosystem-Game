using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using static PlayerInventory;
using static AllPlantsManager;

public class PlayerFarming : MonoBehaviour
{
	public GameObject plant;
	public LayerMask plantLayer;
	private bool touchingPlant = false;


	private void Update()
	{
		if (!touchingPlant && Input.GetMouseButtonDown(0))
			Instantiate(plant, transform.position.Round(), Quaternion.identity);

		if (touchingPlant && Input.GetMouseButtonDown(1))
		{
			PlantGrowth targetPlant = GetPlantCollision();
			if (targetPlant == null) return;
			string type = targetPlant.plantType;

			items[type].amount += targetPlant.growthStage;
			Debug.Log(targetPlant.growthStage + " " + type + " gained");
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
}