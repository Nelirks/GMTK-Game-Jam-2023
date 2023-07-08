using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Mission
{
    public UnityEvent OnStart;
    public UnityEvent OnComplete;

    [SerializeField] private int steps;

    public bool ProgressMission() {
        steps -= 1;
        return steps == 0;
	}
}
