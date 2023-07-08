using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public List<GameObject> playerInventor;
    public void Craft(GameObject pickedObject, GameObject craftableWith, GameObject craftResult)
    {
        if (playerInventor.IndexOf(craftableWith) != -1)
        {
            playerInventor.Add(craftResult);
            playerInventor.Remove(pickedObject);
            playerInventor.Remove(craftableWith);
            Debug.Log("crafted");
        }
    }
}
