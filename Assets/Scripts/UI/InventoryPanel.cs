using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] List<InventorySlot> slots;
    public static InventoryPanel instance;

	private void Awake() {
        instance = this;
	}

	public void AddItem(PickableObject item) {
        foreach(InventorySlot slot in slots) {
            if (slot.item == null) {
                slot.SetItem(item);
                return;
			}
		}
        Debug.LogError("Not enough space in inventory");
    }

    public void RemoveItem(PickableObject item) {
        foreach(InventorySlot slot in slots) {
            if (slot.item == item) {
                slot.RemoveItem();
                return;
			}
		}
        Debug.Log("Item not found in inventory");
	}
}
