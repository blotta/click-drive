using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public bool steer;
    public bool invertSteer;
    public bool power;

    public float SteerAngle { get; set; }
    public float Torque { get; set; }

    public bool Break { get; set; }
    public float BreakForce  { get; set; }

    WheelFrictionCurve forwardNormalCurve;
    WheelFrictionCurve forwardBreakCurve;

    private WheelCollider wheelCollider;
    private Transform wheelTransform;

    void Start()
    {
        BreakForce = 400f;

        wheelCollider = GetComponentInChildren<WheelCollider>();
        wheelTransform = GetComponentInChildren<MeshRenderer>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }

    void FixedUpdate()
    {
        if (steer)
        {
            wheelCollider.steerAngle = SteerAngle * (invertSteer ? -1 : 1);
        }

        if (power)
        {
            wheelCollider.motorTorque = Torque;
        }

        wheelCollider.brakeTorque = Break ? BreakForce : 0f;
    }
}
