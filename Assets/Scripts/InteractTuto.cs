using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTuto : MonoBehaviour
{
    public GameObject popupText;
    private Element element;

    private void Start()
    {
        element = GetComponent<Element>();
    }
    private void Update()
    {
        Debug.Log(element.isInteractable);
        if (!element.isInteractable)
        {
            popupText.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && element.isInteractable)
        {
            popupText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popupText.SetActive(false);
        }
    }
}
