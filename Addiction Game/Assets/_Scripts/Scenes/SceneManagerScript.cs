using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityUtils;
using Array = System.Array;

public class SceneManagerScript : Singleton<SceneManagerScript>
{
    [SerializeField] private ScenesSO scenes;

    public void LoadScene(Scenes sceneName)
    {
        Scene targetScene;
        try
        {
            targetScene = Array.Find(scenes.ScenesArray, x => x.SceneName == sceneName);
        }
        catch
        {
            this.LogError($"Didn't find scene: {sceneName}");
            return;
        }

        SceneManager.LoadScene(targetScene.BuildIndex);
    }
    
    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentSceneIndex++;
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    private Scenes GetCurrentSceneName()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        return (Scenes)currentSceneIndex;
    }
    
    public void RestartCurrentScene()
    {
        LoadScene(GetCurrentSceneName());
    }
}
