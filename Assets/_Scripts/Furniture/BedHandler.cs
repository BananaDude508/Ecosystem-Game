using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DayNightManager;
using static AllPlantsManager;

public class BedHandler : MonoBehaviour
{
	private bool collidingWithPlayer = false;

	public Animator overlayAnim;

	private void Update()
	{
		if (collidingWithPlayer && Input.GetKeyDown(KeyCode.E))
		{
			if (TryAdvancingDay())
			{
				PlaySleepAnim();
				StartCoroutine(IEGrowAllPlants());
			}

		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
			collidingWithPlayer = true;
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
			collidingWithPlayer = false;
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