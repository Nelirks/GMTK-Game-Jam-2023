using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class PickableObject : MonoBehaviour
{
    public PickableObject craftableWith;
    public PickableObject craftResult;
    private PlayerLogic playerLogic;
    public Sprite iconUI;
    public AudioClip pickupSound;
    private AudioSource audioSource;
    public int useNumber;

    public bool isPickable = false;
    public UnityEvent OnObtain;

    void Start()
    {
        playerLogic = FindObjectOfType<PlayerLogic>();
        audioSource = GetComponent<AudioSource>();
    }

    public void PickUp()
    {
        if (!isPickable) return;
        playerLogic.playerInventory.Add(this);
        OnInventoryAdd();
        playerLogic.Craft(this, craftableWith, craftResult);
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
            playerLogic.playerInventory.Remove(this);
        }
    }

    public void OnInventoryAdd() {
        OnObtain.Invoke();
	}

    public void SetPickable(bool pickable = true) {
        isPickable = pickable;
	}
}
