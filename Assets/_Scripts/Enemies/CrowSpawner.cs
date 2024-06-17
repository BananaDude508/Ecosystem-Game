using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AllPlantsManager;

public class CrowSpawner : MonoBehaviour
{
    public GameObject crow;

    [Tooltip("Each plant has a 1 in this value chance to have a crow when sleeping")]
    public int spawnRarity = 10;

    public int minDamage = 0;
    public int maxDamage = 3;

    public void TrySpawningCrows()
    {
        print("trying to spawn crows");
        foreach (var plant in allPlants)
            if (Random.Range(0, spawnRarity) == 0 && !scarecrowPlaced)
            {
                Instantiate(crow, plant.transform.position, Quaternion.identity);
                plant.HurtByCrow(Random.Range(minDamage, maxDamage + 1));
            }
    }
}
