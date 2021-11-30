using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerScriptableObject", order = 1)]

public class PlayerScriptableObjects : ScriptableObject
{
    public List<PlayerController> Players = new List<PlayerController>();
}
