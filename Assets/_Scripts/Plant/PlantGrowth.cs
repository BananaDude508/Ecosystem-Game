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
		if (++growthStage < growthStages.Length)
		{
			sr.sprite = growthStages[growthStage];

			// Invoke("Grow", timeToGrow + Random.Range(-0.5f, 2.5f));
		}
	}

}
