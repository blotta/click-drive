using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFailedState : IState
{
    private Transform _panel;
    public StageFailedState(Transform panel)
    {
        _panel = panel;
    }

    public void Enter()
    {
        _panel.gameObject.SetActive(true);
    }

    public void Execute()
    {
    }

    public void Exit()
    {
    }
}
