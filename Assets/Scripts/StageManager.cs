using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject CarPrefab;
    public GameObject[] StagesPrefabs;
    public Transform StageClearedPanel;
    public Transform StageFailedPanel;

    private GameObject _stage;
    private GameObject _car;

    private StateMachine stateMachine;

    private bool _stageFailed = false;

    private void Awake()
    {
        stateMachine = new StateMachine();
    }

    private void Start()
    {
        LoadStage(GameManager.Instance.currentStage);

        stateMachine.ChangeState(new StageStart(OnStageStartEnded));
    }

    private void Update()
    {
        stateMachine.ExecuteStateUpdate();
    }

    private void OnStageStartEnded()
    {
        stateMachine.ChangeState(new PlayState(_car, PlayStateCallback));
    }

    private void PlayStateCallback(bool success)
    {
        if (success)
            stateMachine.ChangeState(new StageClearedState(StageClearedPanel));
        else
            stateMachine.ChangeState(new StageFailedState(StageFailedPanel));

    }

    public void LoadStage(int stage)
    {
        _stage = Instantiate(StagesPrefabs[stage - 1], Vector3.zero, Quaternion.identity);
        var carStart = _stage.transform.Find("StartPoint");
        _car = Instantiate(CarPrefab, carStart.transform.position, carStart.transform.rotation);
        Camera.main.GetComponent<CameraFollow>().SetTarget(_car.transform);
    }
}
