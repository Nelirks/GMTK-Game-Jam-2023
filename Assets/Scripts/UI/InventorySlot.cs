using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] Image itemImage;
    [HideInInspector] public PickableObject item = null;

	private void Awake() {
        RemoveItem();
	}
	public void SetItem(PickableObject item) {
        itemName.text = item.itemName;
        itemImage.sprite = item.iconUI;
        this.item = item;
	}

    public void RemoveItem() {
        itemName.text = "";
        itemImage.sprite = null;
        item = null;
	}
}
