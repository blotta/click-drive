using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public string inputSteerAxis = "Horizontal";
    public string inputThrottleAxis = "Vertical";
    public string inputBreak = "Break";

    public float ThrottleInput { get; private set; }
    public float SteerInput { get; private set; }
    public float BreakInput { get; private set; }

    void Start()
    {
        
    }

    void Update()
    {
        // print($"Steer: {SteerInput}; Throttle: {ThrottleInput}; Break: {BreakInput}");
        SteerInput = Input.GetAxis(inputSteerAxis);
        ThrottleInput = Input.GetAxis(inputThrottleAxis);
        BreakInput = Input.GetAxis(inputBreak);
    }


}
