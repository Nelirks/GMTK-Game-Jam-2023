using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public List<GameObject> pickedUpObjects;
    private int index;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Craft(GameObject pickedObject, GameObject craftableWith, GameObject craftResult)
    {
        if (pickedUpObjects.IndexOf(craftableWith) != -1)
        {
            pickedUpObjects.Add(craftResult);
            pickedUpObjects.Remove(pickedObject);
            pickedUpObjects.Remove(craftableWith);
            Debug.Log("crafted");
        }
    }
}
