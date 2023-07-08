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

    public bool isInteractable = true;

    public UnityEvent OnInteract;

    void Start()
    {
        playerLogic = FindObjectOfType<PlayerLogic>();
    }

    public void TryInteractObject()
    {
        Debug.Log("TRY INTERACT");
        if (!isInteractable) return;
        if (interactibleObject == null) {
            ActivateElement();
            return;
        }
        int index = playerLogic.playerInventory.IndexOf(interactibleObject);
        if (interactibleObject == null || playerLogic.playerInventory.IndexOf(interactibleObject) != -1)
        {
            playerLogic.playerInventory[index].UseObject();
            ActivateElement();
        }
    }

    public void ActivateElement()
    {
        Debug.Log("INTERACT");
        isInteractable = false;
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
