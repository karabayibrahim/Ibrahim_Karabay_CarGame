using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelScriptableObject", order = 1)]
public class LevelScriptableObject : ScriptableObject
{
    public List<Level> Levels = new List<Level>();
}
