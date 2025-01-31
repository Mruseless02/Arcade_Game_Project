using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scene Data", fileName = "New Scene Data")]
public class SceneSO : ScriptableObject
{
    public string sceneName;
    public int sceneIndex;
}
