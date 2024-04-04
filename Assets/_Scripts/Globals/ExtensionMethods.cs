using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class ExtensionMethods
{
    public static Vector3 Round(this Vector3 value)
    {
        float x = Mathf.Round(value.x);
        float y = Mathf.Round(value.y);
        float z = Mathf.Round(value.z);

        return new Vector3(x, y, z);
    }
}
