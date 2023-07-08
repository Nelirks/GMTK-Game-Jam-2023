using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChecklistElement
{
    public string id;
    public string text;
    public int infoLevel = 0;
    [HideInInspector] public bool isComplete = false;
}
