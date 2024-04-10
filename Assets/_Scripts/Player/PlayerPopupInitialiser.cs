using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static PlayerPopups;
public class PlayerPopupInitialiser : MonoBehaviour
{
    public TextMeshProUGUI popupTextINIT;

    void Awake()
    {
        popupText = popupTextINIT;
        ClearPopupText();
    }
}
