using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class AllPlantsManager
{
    public static List<PlantGrowth> allPlants = new List<PlantGrowth>();
    // private static List<GameObject> savedObjects = new List<GameObject>();

    public static int sleepsOutsideGame = 0;

    public static bool scarecrowPlaced = false;

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
        // Debug.Log(allPlants.Count);
        foreach (var plant in allPlants)
        {
            // Debug.Log(plant.plantType);
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
        if (sleepsOutsideGame > 0)
        {
            scarecrowPlaced = false;

            foreach (var plant in allPlants)
                if (plant.plantType == "scarecrow")
                {
                    plant.scarecrowDays += 1;

                    if (plant.scarecrowDays >= 3)
                        allPlants.Remove(plant);
                }

            if (scene.name == "Game")
            {
                for (int i = 0; i < sleepsOutsideGame; i++)
                    GrowAllPlants();
            }
        }
    }
}
