using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvas : MonoBehaviour
{
    public Transform StageSelectPanel;

    public void PressedPlay()
    {
        GameManager.Instance.LoadStage(1);
    }

    public void PressedLoadStage(int stage)
    {
        GameManager.Instance.LoadStage(stage);
    }

    public void PressedStageSelect()
    {
        StageSelectPanel.gameObject.SetActive(!StageSelectPanel.gameObject.activeSelf);
    }

    public void PressedQuit()
    {
        GameManager.Instance.QuitGame();
    }
}
