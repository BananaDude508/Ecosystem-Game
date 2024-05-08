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

    [HideInInspector]
    public bool scarecrowPlaced = false;

    public static CrowSpawner instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += CrowsOnLevelChange;
    }

    public void TrySpawningCrows()
    {
        foreach (var plant in allPlants)
            if (Random.Range(0, spawnRarity) == 0 && !scarecrowPlaced)
            {
                Instantiate(crow, plant.transform.position, Quaternion.identity);
                plant.HurtByCrow(Random.Range(minDamage, maxDamage + 1));
            }
    }

    public void CrowsOnLevelChange(Scene scene, LoadSceneMode sceneLoadMode)
    {
        if (scene.name == "Game")
            for (int i = 0; i < sleepsOutsideGame; i++)
                TrySpawningCrows();
        Invoke("ResetSleeps", Time.deltaTime);
    }

    private void ResetSleeps()
    {
        sleepsOutsideGame = 0;
    }
}
