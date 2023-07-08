using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager instance;

    [SerializeField] List<Mission> missions;

    private int missionIndex;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        missionIndex = 0;
        missions[missionIndex].OnStart.Invoke();
        MissionPanel.instance.UpdateText();
    }

    public void CompleteObjective() {
        if (missions[missionIndex].ProgressMission()) {
            missions[missionIndex].OnComplete.Invoke();
            missionIndex += 1;
            if (missionIndex < missions.Count) {
                missions[missionIndex].OnStart.Invoke();
                Debug.Log("Next mission");
			}
            else {
                Debug.Log("Game end !!!");
			}
		}
        MissionPanel.instance.UpdateText();
	}

    public string GetMissionReport() {
        return "";
	}
}
