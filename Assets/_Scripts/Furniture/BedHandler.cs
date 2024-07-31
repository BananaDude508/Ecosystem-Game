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

	public PlayerFarming player;


    private void Awake()
    {
		player = GameObject.FindGameObjectWithTag("PlayerParent").GetComponent<PlayerFarming>();
    }

    private void Update()
	{
		if (playerNeaby && !sleeping && Input.GetKeyDown(KeyCode.E))
			if (TryAdvancingDay())
			{
				sleepsOutsideGame++;
				overlayAnim.SetTrigger("sleeping");
				player.Invoke("UpdateDayCounter", 1f);
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