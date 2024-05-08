using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class AllPlantsManager
{
    public static List<PlantGrowth> allPlants = new List<PlantGrowth>();
    // private static List<GameObject> savedObjects = new List<GameObject>();

    public static int sleepsOutsideGame = 0;

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
        Debug.Log(allPlants.Count);
        foreach (var plant in allPlants)
        {
            Debug.Log(plant.plantType);
            plant.Grow();
        }
    }

    public static IEnumerator IETryGrowAllPlants(int delay = 2)
    {
        yield return new WaitForSeconds(delay);

        GrowAllPlants();
    }

    public static void PlantsOnLevelChange(Scene scene, LoadSceneMode sceneLoadMode)
    {
        if (scene.name == "Game")
        {
            for (int i = 0; i < sleepsOutsideGame; i++)
                GrowAllPlants();
            sleepsOutsideGame = 0;
        }

    }
}
