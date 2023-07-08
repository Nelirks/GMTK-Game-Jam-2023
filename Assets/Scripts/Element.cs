using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Element : MonoBehaviour
{
    public PickableObject interactibleObject;
    private PlayerLogic playerLogic;
    public AudioClip activeSound;
    private AudioSource audioSource;

    public bool isInteractable = false;

    public UnityEvent OnInteract;

    void Start()
    {
        playerLogic = FindObjectOfType<PlayerLogic>();
    }

    public void TryInteractObject()
    {
        int index = playerLogic.playerInventory.IndexOf(interactibleObject);
        if (isInteractable && playerLogic.playerInventory.IndexOf(interactibleObject) != -1)
        {
            playerLogic.playerInventory[index].UseObject();
            ActiveElement();
        }
    }

    public void ActiveElement()
    {
        if (activeSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(activeSound);
        }
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);

        OnInteract.Invoke();
    }

    public void SetInteractible(bool interactible = true) {
        isInteractable = interactible;
	}
}
