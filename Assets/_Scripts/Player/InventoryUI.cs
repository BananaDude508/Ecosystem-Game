using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool hoveringOverInv = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoveringOverInv = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoveringOverInv = false;
    }
}