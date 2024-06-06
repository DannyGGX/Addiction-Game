using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuObject;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _quitButton;
    

    private void Awake()
    {
        menuObject.SetActive(false);
    }
    
    private void Start()
    {
        _resumeButton.onClick.AddListener(ResumeGame);
        _restartButton.onClick.AddListener(RestartGame);
        _mainMenuButton.onClick.AddListener(GoToMainMenu);
        _quitButton.onClick.AddListener(QuitGame);
    }

    private void OnDestroy()
    {
        _resumeButton.onClick.RemoveListener(ResumeGame);
        _restartButton.onClick.RemoveListener(RestartGame);
        _mainMenuButton.onClick.RemoveListener(GoToMainMenu);
        _quitButton.onClick.RemoveListener(QuitGame);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePauseScreenState(PauseManager.Instance.IsPaused);
        }
    }
    private void ChangePauseScreenState(bool pauseState)
    {
        if (pauseState)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        menuObject.SetActive(true);
        PauseManager.Instance.SetPauseState(true);
    }

    private void ResumeGame()
    {
        menuObject.SetActive(false);
        PauseManager.Instance.SetPauseState(false);
    }

    private void RestartGame()
    {
        SceneManagerScript.Instance.RestartCurrentScene();
    }

    private void GoToMainMenu()
    {
        PauseManager.Instance.SetPauseState(false);
        SceneManagerScript.Instance.LoadScene(Scenes.MainMenu);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
