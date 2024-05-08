using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomFunctions
{
    /// <summary>
    /// INT min <= value <= max
    /// </summary>
    /// <param name="value"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static int Limit(this int value, int min, int max)
    {
        return (value < max) ? ((value > min) ? value : min) : max;
    }

    /// <summary>
    /// FLOAT min <= value <= max
    /// </summary>
    /// <param name="value"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static float Limit(this float value, float min, float max)
    {
        return (value < max) ? ((value > min) ? value : min) : max;
    }
}
