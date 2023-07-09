using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager instance;

    [SerializeField] private List<Mission> missions;

    private int missionIndex;
    private int currentInfoLevel;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        missionIndex = 0;
        currentInfoLevel = 0;
        missions[missionIndex].OnStart.Invoke();
        MissionPanel.instance.UpdateText();
    }

    public void CompleteObjective(string id = "")
    {
        missions[missionIndex].CheckObjective(id);
        MissionPanel.instance.UpdateText();
        if (missions[missionIndex].IsMissionFinished())
        {
            missions[missionIndex].OnComplete.Invoke();
            if (missionIndex + 1 < missions.Count)
            {
                missionIndex += 1;
                currentInfoLevel = 0;
                missions[missionIndex].OnStart.Invoke();
                MissionPanel.instance.UpdateText();
            }
            else
            {
                StartCoroutine(WaitAndLoadScene());
            }
        }
    }

    private IEnumerator WaitAndLoadScene() {
        yield return new WaitForSeconds(5);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public string GetMissionReport()
    {
        return missions[missionIndex].GetMissionReport(currentInfoLevel);
    }

    public void IncreaseInfoLevel()
    {
        currentInfoLevel += 1;
        MissionPanel.instance.UpdateText();
    }
}
