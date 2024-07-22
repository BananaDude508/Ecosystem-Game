using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HideTutorials : MonoBehaviour
{
    public GameObject tutorialSigns;

    private bool nearbyPlayer = false;


    private void Update()
    {
        if (nearbyPlayer && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(tutorialSigns);
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
