using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _followDiff;

    void Start()
    {
        _followDiff = transform.position;
    }

    void Update()
    {
        if (_target != null)
            transform.position = _target.position + _followDiff;
    }

    public void SetTarget(Transform t)
    {
        _target = t;
    }
}
