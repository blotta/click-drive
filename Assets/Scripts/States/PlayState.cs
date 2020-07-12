using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : IState
{
    private Car _car;
    private Action<bool> _successCallaback;

    public PlayState(GameObject car, Action<bool> cb)
    {
        _successCallaback = cb;
        _car = car.GetComponent<Car>();
    }

    public void Enter()
    {
        EndArea.OnReachedEndArea += EndReached;
        Ground.OnTouchedGround += ObstacleHit;
    }

    void EndReached()
    {
        Debug.Log("Reached End!");
        _successCallaback(true);
    }

    void ObstacleHit()
    {
        Debug.Log("Obstacle Hit");
        _successCallaback(false);
    }

    public void Execute()
    {
        _car.UpdateCar(GUIInputController.ThrottleInput, GUIInputController.SteerInput, GUIInputController.BreakInput);

        if (_car.transform.position.y <= -50f)
        {
            Debug.Log($"Car fell {_car.transform.position}");
            _successCallaback(false);
        }
    }

    public void Exit()
    {
        EndArea.OnReachedEndArea -= EndReached;
        Ground.OnTouchedGround -= ObstacleHit;
    }
}
