using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class PlayerPopups
{
    public static TextMeshProUGUI popupText;


    public static void SetPopupText(string text)
    {
        popupText.text = text;
    }

    public static void ClearPopupText()
    {
        popupText.text = "";
    }

    public static bool CheckPopupText(string text)
    {
        return text == popupText.text;
    }
}
