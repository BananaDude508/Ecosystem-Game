using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AllPlantsManager;
using static PlayerPopups;

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
            UpdateSprite();
        }
    }

	public void HurtByCrow(int damage)
	{
		growthStage -= damage;

		if (growthStage <= 0)
		{
			SetPopupText("Plants were destroyed by crows last night");
			Invoke("ClearPopupText", 3);
			Invoke("DestroyThis", Time.deltaTime); // Delete the plant after a delay to stop the invalidoperationexception error
			return;
		}

        UpdateSprite();

    }

    private void UpdateSprite()
	{
        sr.sprite = growthStages[growthStage];

        harvestReward = Mathf.Max(0, growthStage - harvestPenalty);
    }

	private void DestroyThis()
	{
		allPlants.Remove(this);
		Destroy(gameObject);
	}
}
