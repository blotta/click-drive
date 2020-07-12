using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndArea : MonoBehaviour
{
    public static Action OnReachedEndArea;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            OnReachedEndArea();
        }
    }
}
