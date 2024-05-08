using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingInteractor : MonoBehaviour
{
    private bool nearbyPlayer = false;
    public string targetScene = "Game";

    private void Update()
    {
        if (nearbyPlayer && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(targetScene);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            nearbyPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            nearbyPlayer = false;
    }
}
