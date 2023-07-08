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
    public string itemName;
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
        if (pickupSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(pickupSound);
        }
        playerLogic.playerInventory.Add(this);
        OnInventoryAdd();
        playerLogic.Craft(this, craftableWith, craftResult);
        gameObject.SetActive(false);

    }

    public void UseObject()
    {
        useNumber--;
        if (useNumber <= 0)
        {
            playerLogic.playerInventory.Remove(this);
            InventoryPanel.instance.RemoveItem(this);
        }
    }

    public void OnInventoryAdd()
    {
        OnObtain.Invoke();
        InventoryPanel.instance.AddItem(this);
    }

    public void SetPickable(bool pickable = true)
    {
        isPickable = pickable;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            transform.GetChild(0).gameObject.SetActive(false);
            Debug.Log("shine");
        }
    }
}
