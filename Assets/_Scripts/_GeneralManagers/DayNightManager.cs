using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DayNightManager
{
	public static int currentDay = 0;
	public static bool sleeping = false;

	public static bool TryAdvancingDay()
	{
		Debug.Log("Trying to advance to day " + (currentDay + 1));

		if (sleeping) return false;

		currentDay++;
		Debug.Log("Advance to " + currentDay + " successful");
		return true;
	}
}
