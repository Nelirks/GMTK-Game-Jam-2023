using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DialogueLine", order = 1)]

public class DialogueLine
{
    public string line;
    public Sprite sprite;
}
