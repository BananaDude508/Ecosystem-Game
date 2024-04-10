using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DayNightManager;
using static AllPlantsManager;
using static PlayerPopups;

public class BedHandler : MonoBehaviour
{
	private bool playerNeaby = false;

	public Animator overlayAnim;
	public GameObject[] UIElementsToHideOvernight;

    public CrowSpawner crowSpawner;

	public string nearbyPopupText = "Press 'e' to sleep";

    private void Update()
	{
		if (playerNeaby && Input.GetKeyDown(KeyCode.E))
		{
			if (TryAdvancingDay())
			{
				PlaySleepAnim();
				StartCoroutine(IEGrowAllPlants());
			}

		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			playerNeaby = true;
			SetPopupText(nearbyPopupText);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			playerNeaby = false;
			if (CheckPopupText(nearbyPopupText)) ClearPopupText();
		}
	}

	private void PlaySleepAnim()
	{
		foreach (var element in UIElementsToHideOvernight)
			element.SetActive(false);

		overlayAnim.SetBool("sleeping", true);

		crowSpawner.Invoke("TrySpawningCrows", 2);
		Invoke("StopSleepAnim", 3.99f);
	}

	private void StopSleepAnim()
	{
        foreach (var element in UIElementsToHideOvernight)
            element.SetActive(true);

        overlayAnim.SetBool("sleeping", false);
	}
}