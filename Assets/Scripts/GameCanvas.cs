using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    public Transform ThrottleSlider;
    public Transform SteerSlider;
    public Transform ReverseButton;
    public Transform BreakButton;

    public Transform PausePanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePausePanel();
    }

    public void TogglePausePanel()
    {
        PausePanel.gameObject.SetActive(!PausePanel.gameObject.activeSelf);
        Time.timeScale = PausePanel.gameObject.activeSelf ? 0 : 1;
    }

    public void OnThrottleValueChanged(float value)
    {
        GUIInputController.SetThrottle(value);
    }

    public void OnSteerSliderChanged(float value)
    {
        GUIInputController.SetSteer(value);
    }

    public void OnBreakButtonPressed()
    {
        GUIInputController.ToggleBreak();

        if (GUIInputController.BreakInput)
            BreakButton.GetComponentInChildren<TMP_Text>().text = "BREAKING";
        else
            BreakButton.GetComponentInChildren<TMP_Text>().text = "BREAK";
    }

    public void OnReverseButtonPressed()
    {
        GUIInputController.ToggleReverse();


        if (GUIInputController.ReverseInput)
            ReverseButton.GetComponentInChildren<TMP_Text>().text = "FORWARD";
        else
            ReverseButton.GetComponentInChildren<TMP_Text>().text = "REVERSE";
    }

    public void PressedRetry()
    {
        GameManager.Instance.ReloadStage();
    }

    public void PressedNext()
    {
        GameManager.Instance.NextStage();
    }

    public void PressedMenu()
    {
        GameManager.Instance.LoadMenu();
    }
}
