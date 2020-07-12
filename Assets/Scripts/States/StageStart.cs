using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStart : IState
{
    private Action _callback;

    public StageStart(Action callback)
    {
        _callback = callback;
    }

    public void Enter()
    {
        GUIInputController.ResetAllValues();
        Time.timeScale = 1;
    }

    public void Execute()
    {
        _callback();
    }

    public void Exit()
    {
    }
}
