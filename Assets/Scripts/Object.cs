using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Object : MonoBehaviour
{
    public bool pickable = false;
    public GameObject craftableWith;
    public GameObject craftResult;
    private PlayerControls controls;
    private PlayerLogic playerLogic;
    public Sprite iconUI;
    public AudioClip pickupSound;
    private AudioSource audioSource;
    public int useNumber;

    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerControls();
        playerLogic = FindObjectOfType<PlayerLogic>();
        audioSource = GetComponent<AudioSource>();
    }

    public void PickUp()
    {
        playerLogic.pickedUpObjects.Add(gameObject);
        playerLogic.Craft(gameObject, craftableWith, craftResult);
        gameObject.SetActive(false);

        if (pickupSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(pickupSound);
        }
    }

    public void UseObject()
    {
        useNumber--;
        if (useNumber <= 0)
        {
            playerLogic.pickedUpObjects.Remove(gameObject);
            //Destroy(gameObject);
        }
    }
}
