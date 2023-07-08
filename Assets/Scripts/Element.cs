using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public GameObject interactibleObject;
    //public bool interactible = false;
    private PlayerLogic playerLogic;
    public AudioClip activeSound;
    private AudioSource audioSource;
    void Start()
    {
        playerLogic = FindObjectOfType<PlayerLogic>();
    }

    public void TryInteractObject()
    {
        int index = playerLogic.playerInventor.IndexOf(interactibleObject);
        if (playerLogic.playerInventor.IndexOf(interactibleObject) != -1)
        {
            Debug.Log(index);
            playerLogic.playerInventor[index].GetComponent<Object>().UseObject();
            ActiveElement();
        }
    }

    public void ActiveElement()
    {
        if (activeSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(activeSound);
        }

        Debug.Log("Je suis activé !");
    }
}
