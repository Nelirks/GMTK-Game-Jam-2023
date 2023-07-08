using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VictimPanel : MonoBehaviour
{
    [SerializeField] private Image victimSprite;
    [SerializeField] private TextMeshProUGUI victimDesc;

    public static VictimPanel instance;

	private void Awake() {
		instance = this;
		victimSprite.sprite = null;
		victimDesc.text = "";
	}

	public void SetVictimInfo(VictimInfo info) {
        victimSprite.sprite = info.victimSprite;
        victimDesc.text = info.victimDesc;
	}
}
