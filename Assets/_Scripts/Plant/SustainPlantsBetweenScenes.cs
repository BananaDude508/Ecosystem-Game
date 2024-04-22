using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SustainPlantsBetweenScenes : MonoBehaviour
{
    public static SustainPlantsBetweenScenes instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnLevelChange;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnLevelChange(Scene scene, LoadSceneMode sceneLoadMode)
    {
        if (scene.name == "Game") gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }
}
