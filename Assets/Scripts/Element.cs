using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public GameObject interactibleObject;
    private PlayerLogic playerLogic;
    public AudioClip activeSound;
    private AudioSource audioSource;
    void Start()
    {
        playerLogic = FindObjectOfType<PlayerLogic>();
    }

    public void TryInteractObject()
    {
        int index = playerLogic.playerInventory.IndexOf(interactibleObject);
        if (playerLogic.playerInventory.IndexOf(interactibleObject) != -1)
        {
            Debug.Log(index);
            playerLogic.playerInventory[index].GetComponent<Object>().UseObject();
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

        Debug.Log("Je suis activé !");
    }
}
