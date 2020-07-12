using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearedState : IState
{
    Transform _panel;

    public StageClearedState(Transform panel)
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
