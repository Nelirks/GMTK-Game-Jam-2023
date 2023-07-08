using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Mission
{
    [SerializeField] private List<ChecklistElement> checklist;

    public UnityEvent OnStart;
    public UnityEvent OnComplete;

    [SerializeField] private int completeObjectives;

    public void CheckObjective(string id) {
        foreach(ChecklistElement element in checklist) {
            if (element.id == id) {
                element.isComplete = true;
                completeObjectives += 1;
			}
		}
	}

    public bool IsMissionFinished() {
        return completeObjectives >= checklist.Count;
	}

    public string GetMissionReport(int currentHideLevel) {
        string text = "";
        foreach (ChecklistElement element in checklist) {
            if (element.infoLevel > currentHideLevel) continue;
            if (element.isComplete) text += "<s>" + element.text + "</s>";
            else text += element.text;
            text += "\n";
        }
        return text;
    }
}
