using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchableObject : MonoBehaviour
{
    [SerializeField] private GameObject firstState;
    [SerializeField] private GameObject secondState;

    public void Switch(bool toSecond) {
        firstState.SetActive(!toSecond);
        secondState.SetActive(toSecond);
	}
}
