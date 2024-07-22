using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AllPlantsManager;
using static PlayerInventory;
using static CrowSpawner;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CrowSpawner crowSpawner;

    public Transform player;
    public string oldScene = "Game";


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        if (instance != this)
        {
            SceneManager.sceneLoaded += GMOnLevelChange;
            SceneManager.sceneLoaded += PlantsOnLevelChange;
            SceneManager.sceneLoaded += CrowsOnLevelChange;

            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void GMOnLevelChange(Scene scene, LoadSceneMode loadSceneMode)
    {
        print(oldScene);
        if (scene.name == "Game")
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

            switch (oldScene)
            {
                case "Shop":
                    player.position = GameObject.FindGameObjectWithTag("ShopRespawn").transform.position;
                    break;

                case "Home":
                    player.position = GameObject.FindGameObjectWithTag("HomeRespawn").transform.position;
                    instance.Invoke("ResetSleeps", Time.deltaTime);
                    break;

                case "Game":
                    break;

                default:
                    break;
            }
        }

        oldScene = scene.name;
    }

    public void PlantsOnLevelChange(Scene scene, LoadSceneMode sceneLoadMode)
    {
        if (sleepsOutsideGame > 0)
        {
            foreach (var plant in allPlants)
                if (plant.plantType == "scarecrow")
                {
                    plant.scarecrowDays += 1;

                    if (plant.scarecrowDays < 3) continue;

                    StartCoroutine(IE_DeletePlant(plant, Time.deltaTime));
                    
                    scarecrowPlaced = false;
                }

            if (scene.name == "Game")
            {
                for (int i = 0; i < sleepsOutsideGame; i++)
                    GrowAllPlants();
            }
        }
    }

    public void CrowsOnLevelChange(Scene scene, LoadSceneMode sceneLoadMode)
    {
        if (scene.name == "Game")
            for (int i = 0; i < sleepsOutsideGame; i++)
                crowSpawner.TrySpawningCrows();
    }

    private void ResetSleeps()
    {
        sleepsOutsideGame = 0;
    }

    IEnumerator IE_DeletePlant(PlantGrowth plant, float delay)
    {
        yield return new WaitForSeconds(delay);

        RemovePlant(plant);
        Destroy(plant.gameObject);

        yield break;
    }
}
