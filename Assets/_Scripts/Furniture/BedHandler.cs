using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DayNightManager;
using static AllPlantsManager;
using UnityEngine.SceneManagement;

public class BedHandler : MonoBehaviour
{
	private bool playerNeaby = false;

	public Animator overlayAnim;
	public GameObject[] UIElementsToHideOvernight;

    private CrowSpawner crowSpawner;

    private void Awake()
    {
		crowSpawner = FindObjectOfType<CrowSpawner>();
    }

    private void Update()
	{
		if (playerNeaby && !sleeping && Input.GetKeyDown(KeyCode.E))
		{
			bool doTheThings = SceneManager.GetActiveScene().name == "Game";

			Debug.Log("trying to sleep " + doTheThings);

            if (TryAdvancingDay())
			{
				PlaySleepAnim(doTheThings);
				if (doTheThings)
					StartCoroutine(IETryGrowAllPlants());
				else 
					sleepsOutsideGame++;
			}

		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			playerNeaby = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			playerNeaby = false;
		}
	}

	private void PlaySleepAnim(bool summonCrows = true)
	{
		foreach (var element in UIElementsToHideOvernight)
			element.SetActive(false);

		overlayAnim.SetBool("sleeping", true);

		if (summonCrows) crowSpawner.Invoke("TrySpawningCrows", 2);
		Invoke("StopSleepAnim", 3.99f);
	}

	private void StopSleepAnim()
	{
        foreach (var element in UIElementsToHideOvernight)
            element.SetActive(true);

        overlayAnim.SetBool("sleeping", false);
	}
}