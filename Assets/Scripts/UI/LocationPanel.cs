using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocationPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public static LocationPanel instance;

	private void Awake() {
		instance = this;
		text.text = "";
	}

	public void SetText(string str) {
        text.text = str;
	}
}
