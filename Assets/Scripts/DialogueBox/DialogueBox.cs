using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image image;
    private DialogueInfo currentDialogue;
    private int currentLineIndex;

    private List<DialogueInfo> queue;

    public static DialogueBox instance;

    // Start is called before the first frame update
    void Awake()
    {
        queue = new List<DialogueInfo>();
        UpdateVisibility();
        instance = this;
    }

    public void DisplayDialogue(DialogueInfo dialogue) {
        if (currentDialogue != null) {
            queue.Add(dialogue);
            return;
		}
        currentDialogue = dialogue;
        currentLineIndex = 0;
        UpdateVisibility();
        DisplayNextLine();
	}

    public void DisplayNextLine() {
        if (currentDialogue == null) return;
        if (currentLineIndex >= currentDialogue.dialogueLines.Count) {
            if (queue.Count != 0) {
                currentDialogue = queue[0];
                queue.RemoveAt(0);
                currentLineIndex = 0;
                DisplayNextLine();
            }
            else {
                currentDialogue = null;
                UpdateVisibility();
            }
            return;
        }
        DialogueLine nextLine = currentDialogue.dialogueLines[currentLineIndex];
        image.sprite = nextLine.sprite;
        text.text = nextLine.line;
        currentLineIndex += 1;
	}

    private void UpdateVisibility() {
        gameObject.SetActive(currentDialogue != null);
        FindObjectOfType<PlayerController>().PreventMovement(currentDialogue != null);
    }
}