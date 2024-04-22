using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AllPlantsManager
{
    public static List<PlantGrowth> allPlants = new List<PlantGrowth>();
    // private static List<GameObject> savedObjects = new List<GameObject>();
    public static void AddPlant(PlantGrowth plantGrowth)
    {
        allPlants.Add(plantGrowth);
    }

    public static void RemovePlant(PlantGrowth plantGrowth)
    {
        allPlants.Remove(plantGrowth);
    }

    public static void GrowAllPlants()
    {
        foreach (var plant in allPlants)
            plant.Grow();
    }

    public static IEnumerator IEGrowAllPlants()
    {
        yield return new WaitForSeconds(2);

		foreach (var plant in allPlants)
			plant.Grow();
	}
}
