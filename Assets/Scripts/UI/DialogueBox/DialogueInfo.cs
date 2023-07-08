using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DialogueInfo", order = 1)]

public class DialogueInfo : ScriptableObject
{
    public List<DialogueLine> dialogueLines;
}
