using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AllPlantsManager;
using static PlayerInventory;


public class GameManager : MonoBehaviour
{
    public Transform player;
    public string oldScene = "";

    public int PlayerMoney
    {
        get { return money; }
        set { money = value;  }
    }

    private void Awake()
    {
        SceneManager.sceneLoaded += PlantsOnLevelChange;
        SceneManager.sceneLoaded += GMOnLevelChange;
    }

    private void GMOnLevelChange(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == "Game")
            player = GameObject.FindGameObjectWithTag("Player").transform;

        switch (oldScene)
        {
            case "Shop":
                player.position = GameObject.FindGameObjectWithTag("ShopRespawn").transform.position;
                break;
            case "Home":
                player.position = GameObject.FindGameObjectWithTag("HomeRespawn").transform.position;
                break;
        
            case "Game":
            default:
                break;
        }

        oldScene = scene.name;
    }
}
