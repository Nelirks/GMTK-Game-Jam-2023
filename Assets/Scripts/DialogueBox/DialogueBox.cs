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

    public static DialogueBox instance;

    // Start is called before the first frame update
    void Start()
    {
        SetVisible(false);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown) {
            DisplayNextLine();
		}
    }

    public void DisplayDialogue(DialogueInfo dialogue) {
        currentDialogue = dialogue;
        currentLineIndex = 0;
        SetVisible(true);
        DisplayNextLine();
	}

    private void DisplayNextLine() {
        if (currentLineIndex >= currentDialogue.dialogueLines.Count) {
            SetVisible(false);
            return;
        }
        DialogueLine nextLine = currentDialogue.dialogueLines[currentLineIndex];
        image.sprite = nextLine.sprite;
        text.text = nextLine.line;
        currentLineIndex += 1;
	}

    private void SetVisible(bool visible) {
        gameObject.SetActive(visible);
        enabled = visible;
    }
}
