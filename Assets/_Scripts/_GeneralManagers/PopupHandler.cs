using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerPopups;

public class PopupHandler : MonoBehaviour
{
    public string popupText = "popup text";
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerParent")
            SetPopupText(popupText);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerParent")
            if (CheckPopupText(popupText)) ClearPopupText();
    }
}
