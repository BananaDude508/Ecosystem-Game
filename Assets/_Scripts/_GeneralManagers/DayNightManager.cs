using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class DayNightManager
{
	public static int currentDay = 0;
	public static bool sleeping = false;

	public static bool TryAdvancingDay()
	{
		if (sleeping || SceneManager.GetActiveScene().name != "Home") return false;
		currentDay++;

		return true;
	}
}
