using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AllPlantsManager;

public class PlantGrowth : MonoBehaviour
{
	public SpriteRenderer sr;
	public Sprite[] growthStages;
	public int growthStage = 0;
	public float timeToGrow = 3f;
	public string plantType = "wheat";

	private void Awake()
	{
		AddPlant(this);
	}

	private void Start()
	{
		sr.sprite = growthStages[0];
		// Invoke("Grow", timeToGrow + Random.Range(-0.5f, 2.5f));
	}

	public void Grow()
	{
		if (growthStage + 1 < growthStages.Length)
		{
			growthStage++;

			sr.sprite = growthStages[growthStage];

			// Invoke("Grow", timeToGrow + Random.Range(-0.5f, 2.5f));
		}
	}

}
