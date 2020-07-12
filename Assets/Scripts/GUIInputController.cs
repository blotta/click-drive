using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public static class GUIInputController
{
    public static float ThrottleInput { get; private set; }
    public static bool ReverseInput { get; private set; }
    public static float SteerInput { get; private set; }
    public static bool BreakInput { get; private set; }

    public static void SetThrottle(float value)
    {
        ThrottleInput = (ReverseInput ? -1 : 1) * Mathf.Clamp(value, 0, 1);
    }

    public static void SetSteer(float value)
    {
        SteerInput = Mathf.Clamp(value, -1, 1);
    }

    public static void ToggleBreak()
    {
        BreakInput = !BreakInput;
    }

    public static void ToggleReverse()
    {
        ReverseInput = !ReverseInput;
        ThrottleInput = (ReverseInput ? -1 : 1) * Mathf.Abs(ThrottleInput);
    }

    public static void ResetAllValues()
    {
        ThrottleInput = 0;
        SteerInput = 0;
        BreakInput = false;
        ReverseInput = false;
    }
}
