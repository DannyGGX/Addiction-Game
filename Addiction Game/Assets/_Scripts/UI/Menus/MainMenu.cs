using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainScreen;
    //[SerializeField] private GameObject OptionsScreen;
    //[SerializeField] private GameObject CreditsScreen;
    [SerializeField] private GameObject RacingGameModesScreen;
    [Space]
    [SerializeField] private Button StartButton;
    [SerializeField] private Button CreditsButton;
    [SerializeField] private Button OptionsButton;
    [SerializeField] private Button QuitButton;
    [SerializeField] private Button BackButton;

    private void Start()
    {
        MainScreen.SetActive(true);
        StartButton.onClick.AddListener(StartGame);
        // CreditsButton.onClick.AddListener(GoToCredits);
        // OptionsButton.onClick.AddListener(GoToOptions);
        QuitButton.onClick.AddListener(QuitGame);
        // BackButton.onClick.AddListener(BackButtonClicked);
    }

    private void OnDestroy()
    {
        StartButton.onClick.RemoveListener(StartGame);
        // CreditsButton.onClick.RemoveListener(GoToCredits);
        // OptionsButton.onClick.RemoveListener(GoToOptions);
        QuitButton.onClick.RemoveListener(QuitGame);
        // BackButton.onClick.RemoveListener(BackButtonClicked);
    }

    private void BackButtonClicked()
    {
        //CreditsScreen.SetActive(false);
        //OptionsScreen.SetActive(false);
        MainScreen.SetActive(true);
        RacingGameModesScreen.SetActive(false);
    }

    private void StartGame()
    {
        SceneManagerScript.Instance.LoadScene(Scenes.MainTestScene);
    }

    private void GoToCredits()
    {
        //CreditsScreen.SetActive(true);
        MainScreen.SetActive(false);
    }

    private void GoToOptions()
    {
        //OptionsScreen.SetActive(true);
        MainScreen.SetActive(false);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
