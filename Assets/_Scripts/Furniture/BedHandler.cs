using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DayNightManager;
using static AllPlantsManager;

public class BedHandler : MonoBehaviour
{
	private bool playerNeaby = false;

	public Animator overlayAnim;

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
            playerNeaby = true;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
            playerNeaby = false;
	}

	private void PlaySleepAnim()
	{
		overlayAnim.SetBool("sleeping", true);
		Invoke("StopSleepAnim", 4);
	}

	private void StopSleepAnim()
	{
		overlayAnim.SetBool("sleeping", false);
	}
}