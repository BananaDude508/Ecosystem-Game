using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DayNightManager
{
	public static int currentDay = 0;


	public static bool TryAdvancingDay()
	{
		Debug.Log("Trying to advance to day " + (currentDay + 1));

		// Check if currently in sleep animation or before 7am or smth
		// Play sleeping animation

		// also add the sleep animation
		bool canAdvanceDay = true;
		if (!canAdvanceDay) return false;


		currentDay++;
		Debug.Log("Advance to " + currentDay + " successful");
		return true;
	}
}
