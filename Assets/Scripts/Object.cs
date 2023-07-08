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

    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerControls();
        playerLogic = FindObjectOfType<PlayerLogic>();
    }

    public void PickUp()
    {
        playerLogic.pickedUpObjects.Add(gameObject);
        playerLogic.Craft(gameObject, craftableWith, craftResult);
        gameObject.SetActive(false);
    }

}
