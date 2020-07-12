using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform centerOfMass;
    public float motorTorque = 1500f;
    public float maxSteer = 20f;

    public float Steer { get; set; }
    public float Throttle { get; set; }
    public bool Break { get; set; }

    private Rigidbody _rigidbody;
    private Wheel[] wheels;

    private void Start()
    {
        wheels = GetComponentsInChildren<Wheel>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
    }

    void Update()
    {
        // Steer = GameManager.Instance.InputController.SteerInput;
        // Throttle = GameManager.Instance.InputController.ThrottleInput;
        // Break = GameManager.Instance.InputController.BreakInput > 0 ? true : false;
        // print(GameManager.Instance.InputController.BreakInput + " " + Break);

        // Throttle = GUIInputController.ThrottleInput;
        // Steer = GUIInputController.SteerInput;
        // Break = GUIInputController.BreakInput;

        // foreach (var wheel in wheels)
        // {
        //     wheel.SteerAngle = Steer * maxSteer;
        //     wheel.Torque = Throttle * motorTorque;
        //     wheel.Break = Break;
        // }
    }

    public void UpdateCar(float throttle, float steer, bool breakValue)
    {
        Throttle = throttle;
        Steer = steer;
        Break = breakValue;

        foreach (var wheel in wheels)
        {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Throttle * motorTorque;
            wheel.Break = Break;
        }
    }
}
