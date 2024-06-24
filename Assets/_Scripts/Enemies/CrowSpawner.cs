using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AllPlantsManager;

public class CrowSpawner : MonoBehaviour // This is the script used for part 2 of the assignment
{
    public GameObject crow;

    [Tooltip("Each plant has a 1 in value chance to have a crow when sleeping")]
    public int spawnRarity = 10;

    public int minDamage = 0;
    public int maxDamage = 3;

    public void TrySpawningCrows()
    {
        print("trying to spawn crows");
        foreach (PlantGrowth plant in allPlants)
            if (Random.Range(0, spawnRarity + 1) == 0 && !scarecrowPlaced)
            {
                Instantiate(crow, plant.transform.position, Quaternion.identity);
                plant.HurtByCrow(Random.Range(minDamage, maxDamage + 1));
            }
    }
}
