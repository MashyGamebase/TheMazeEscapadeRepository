using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelObjectives : Singleton<LevelObjectives>
{
    [Header("Panels")]
    public GameObject winScreenPanel;
    public GameObject loseScreenPanel;

    [Header("Buttons")]
    public Button winRetryButton;
    public Button winMMButton;
    public Button loseRetryButton;
    public Button loseMMButton;

    [Header("Key")]
    public bool hasKey = false;

    [Header("Properties")]
    [SerializeField] internal float currentLevelTime;
    public float maxLevelTime;

    private void Start()
    {
        currentLevelTime = maxLevelTime;
        Time.timeScale = 1; // Always set to 1
        AddButtonListeners();
    }

    void AddButtonListeners()
    {
        winRetryButton.onClick.AddListener(Scene_ReloadScene);
        loseRetryButton.onClick.AddListener(Scene_ReloadScene);
        winMMButton.onClick.AddListener(Scene_LoadMainMenu);
        loseMMButton.onClick.AddListener(Scene_LoadMainMenu);
    }

    public void Game_OnWin()
    {
        winScreenPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Game_OnLose()
    {
        loseScreenPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Scene_ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Scene_LoadMainMenu()
    {
        SceneManager.LoadScene(0); // Main menu scenes should always be index = 0
    }
}