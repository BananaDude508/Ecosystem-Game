using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemKeepSelected : MonoBehaviour
{
    private EventSystem eventSystem;
    private static GameObject lastSelected = null;
    public GameObject defaultSelected;

    void Start()
    {
        eventSystem = GetComponent<EventSystem>();

        eventSystem.SetSelectedGameObject(defaultSelected);
    }

    void Update()
    {
        if (eventSystem != null)
        {
            if (eventSystem.currentSelectedGameObject != null)
            {
                lastSelected = eventSystem.currentSelectedGameObject;
            }
            else // if (lastSelected != null && lastSelected.tag == "InventoryButton")
            {
                eventSystem.SetSelectedGameObject(lastSelected);
            }
        }
    }
}