using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Scene
{
    public Scenes SceneName;
    public int BuildIndex;
}

public enum Scenes
{
    MainMenu,

    MainTestScene,
    Level1,
    Level2,
    Level3,
    Level4,
    Level5
}
