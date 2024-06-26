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

    /// <summary>
    /// INT return the maximum value of a and b
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int Max(int a, int b)
    {
        return a <= b ? b : a;
    }

    /// <summary>
    /// FLOAT return the maximum value of a and b
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static float Max(float a, float b)
    {
        return a <= b ? b : a;
    }

    /// <summary>
    /// INT return the minimum value of a and b
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int Min(int a, int b)
    {
        return a <= b ? a : b;
    }

    /// <summary>
    /// FLOAT return the minimum value of a and b
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static float Min(float a, float b)
    {
        return a <= b ? a : b;
    }
}
