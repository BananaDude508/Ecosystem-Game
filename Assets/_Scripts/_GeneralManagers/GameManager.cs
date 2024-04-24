using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AllPlantsManager;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public string oldScene = "";

    private void Awake()
    {
        SceneManager.sceneLoaded += PlantsOnLevelChange;
        SceneManager.sceneLoaded += GMOnLevelChange;
    }

    private void GMOnLevelChange(Scene scene, LoadSceneMode loadSceneMode)
    {
        switch (oldScene)
        {
            case "Shop":
                player = GameObject.FindGameObjectWithTag("ShopRespawn").transform;
                break;
            case "Home":
                player = GameObject.FindGameObjectWithTag("HomeRespawn").transform;
                break;
        
            case "Game":
            default:
                break;
        }

        oldScene = scene.name;
    }
}
