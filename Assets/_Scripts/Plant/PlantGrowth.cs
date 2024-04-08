using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AllPlantsManager;

public class PlantGrowth : MonoBehaviour
{
	public SpriteRenderer sr;
	public Sprite[] growthStages;
	public int growthStage = 0;
	public string plantType = "wheat";

	[SerializeField] private int harvestPenalty = 0;
    [HideInInspector] public int harvestReward = 0;

	private void Awake()
	{
		AddPlant(this);
	}

	private void Start()
	{
		sr.sprite = growthStages[0];
	}

	public void Grow()
	{
		if (growthStage + 1 < growthStages.Length)
		{
			growthStage++;

			sr.sprite = growthStages[growthStage];

			harvestReward = Mathf.Max(0, growthStage - harvestPenalty);
		}
	}

}
