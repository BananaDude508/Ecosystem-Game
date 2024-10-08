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
	public bool grows = true;
	public bool wateredToday = false;
	public SpriteRenderer groundRenderer;
	[HideInInspector] public int scarecrowDays = 0;

	[SerializeField] private int harvestPenalty = 0;
    [HideInInspector] public int harvestReward = 0;

	private void Awake()
	{
		AddPlant(this);

		if (plantType == "scarecrow") scarecrowPlaced = true;
	}

	private void Start()
	{
		sr.sprite = growthStages[0];
	}

	public void Grow()
	{
		if (growthStage + 1 < growthStages.Length && wateredToday)
		{
			growthStage++;
			UpdateSprite();

            if (growthStage <= 0)
            {
                SetPopupText("Plants were destroyed by crows last night");
                Invoke("ClearPopupText", 3);
                Invoke("DestroyThis", Time.deltaTime); // Delete the plant after a delay to stop the invalidoperationexception error
                return;
            }
        }
		wateredToday = false;
    }

	public void HurtByCrow(int damage)
	{
		if (!grows) return;

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
		UpdateGround();

		if (!grows || growthStages.Length <= growthStage || growthStage < 0) return;

        sr.sprite = growthStages[growthStage];

        harvestReward = Mathf.Max(0, growthStage - harvestPenalty);
    }

    public void UpdateGround()
    {
		Color color = groundRenderer.color;
		color.a = wateredToday ? .5f : 0f;
		groundRenderer.color = color;
    }

    private void DestroyThis()
	{
		allPlants.Remove(this);
		Destroy(gameObject);
		if (plantType == "scarecrow") scarecrowPlaced = false;
    }
}
