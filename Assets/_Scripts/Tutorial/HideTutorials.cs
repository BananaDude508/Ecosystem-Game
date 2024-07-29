using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HideTutorials : MonoBehaviour
{
    public GameObject[] tutorialSigns;

    private bool nearbyPlayer = false;

    static bool tutorialsHidden = false;


    private void Start()
    {
        foreach (GameObject sign in tutorialSigns)
            sign.SetActive(!tutorialsHidden);
        gameObject.SetActive(!tutorialsHidden);
    }

    private void Update()
    {
        if (nearbyPlayer && Input.GetKeyDown(KeyCode.E))
        {
            tutorialsHidden = true;
            foreach (GameObject sign in tutorialSigns)
                sign.SetActive(!tutorialsHidden);
            gameObject.SetActive(!tutorialsHidden);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerParent")
            nearbyPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerParent")
            nearbyPlayer = false;
    }
}
