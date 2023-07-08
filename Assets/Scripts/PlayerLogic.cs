using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public List<GameObject> playerInventory;
    public void Craft(GameObject pickedObject, GameObject craftableWith, GameObject craftResult)
    {
        if (playerInventory.IndexOf(craftableWith) != -1)
        {
            playerInventory.Add(craftResult);
            playerInventory.Remove(pickedObject);
            playerInventory.Remove(craftableWith);
            Debug.Log("crafted");
        }
    }
}
