using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AllPlantsManager;
using static PlayerInventory;
using static CrowSpawner;
using Unity.VisualScripting;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CrowSpawner crowSpawner;

    public Transform player;
    public string oldScene = "";


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        if (instance != this)
        {
            SceneManager.sceneLoaded += PlantsOnLevelChange;
            SceneManager.sceneLoaded += GMOnLevelChange;
            SceneManager.sceneLoaded += CrowsOnLevelChange;

            Destroy(gameObject);
        }
    }

    private void GMOnLevelChange(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == "Game")
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            Invoke("ResetSleeps", Time.deltaTime);
        }

        switch (oldScene)
        {
            case "Shop":
                player.position = GameObject.FindGameObjectWithTag("ShopRespawn").transform.position;
                break;
            case "Home":
                player.position = GameObject.FindGameObjectWithTag("HomeRespawn").transform.position;
                break;
        
            case "Game":
                break;
            default:
                break;
        }

        oldScene = scene.name;
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
}
