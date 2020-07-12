using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    public InputController InputController { get; private set; }

    public int currentStage { get; private set; }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);

        InputController = GetComponentInChildren<InputController>();
        if (InputController == null)
            print("NULL");

        currentStage = 1;
    }

    public void NextStage()
    {
        if (currentStage <= 4)
        {
            currentStage++;
            LoadStage(currentStage);
        }
        else
        {
            LoadMenu();
        }
    }

    public void LoadStage(int stage)
    {
        currentStage = Mathf.Clamp(stage, 1, 5);
        LoadGame();
    }

    public void ReloadStage()
    {
        LoadGame();
    }

    private void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
