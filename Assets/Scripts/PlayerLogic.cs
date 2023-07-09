using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public List<PickableObject> playerInventory;
    public void Craft(PickableObject pickedObject, PickableObject craftableWith, PickableObject craftResult)
    {
        if (playerInventory.IndexOf(craftableWith) != -1)
        {
            playerInventory.Add(craftResult);
            playerInventory.Remove(pickedObject);
            InventoryPanel.instance.RemoveItem(pickedObject);
            playerInventory.Remove(craftableWith);
            InventoryPanel.instance.RemoveItem(craftableWith);
            craftResult.OnInventoryAdd();
        }
    }
}
