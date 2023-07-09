using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    [SerializeField] private DialogueInfo info;
    [SerializeField] private DialogueInfo info2;

    // Start is called before the first frame update
    void Start()
    {
        DialogueBox.instance.DisplayDialogue(info);
        StartCoroutine(WaitForDialogueEnd());
    }

    private IEnumerator WaitForDialogueEnd() {
        while(DialogueBox.instance.gameObject.activeSelf) {
            yield return new WaitForSeconds(2);
            DialogueBox.instance.DisplayNextLine();
        }
        yield return new WaitForSeconds(2);
        DialogueBox.instance.DisplayDialogue(info2);
        while (DialogueBox.instance.gameObject.activeSelf) {
            yield return new WaitForSeconds(2);
            DialogueBox.instance.DisplayNextLine();
        }

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        Debug.Log(nextSceneIndex);
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(nextSceneIndex);
            Debug.Log("LOAD ?");
        }
    }
}
