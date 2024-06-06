using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scenes", menuName = "Scriptable Object/Scenes")]
public class ScenesSO : ScriptableObject
{
    public Scene[] ScenesArray;
}
