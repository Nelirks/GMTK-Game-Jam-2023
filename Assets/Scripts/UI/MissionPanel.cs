using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionPanel : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI text;

	public static MissionPanel instance;

	private void Awake() {
		instance = this;
		text.text = "";
	}
	public void UpdateText() {
		text.text = MissionManager.instance.GetMissionReport(); ;
	}
}
