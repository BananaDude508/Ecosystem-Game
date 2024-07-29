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

    private CrowSpawner crowSpawner;

    private void Awake()
    {
		crowSpawner = FindObjectOfType<CrowSpawner>();
    }

    private void Update()
	{
		if (playerNeaby && !sleeping && Input.GetKeyDown(KeyCode.E))
			if (TryAdvancingDay())
			{
				sleepsOutsideGame++;
				overlayAnim.SetTrigger("sleeping");
			}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "PlayerParent")
			playerNeaby = true;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "PlayerParent")
			playerNeaby = false;
	}
}