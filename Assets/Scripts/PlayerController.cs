using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector2 moveInput;
    private PlayerControls controls;
    private Rigidbody2D rb;
    private GameObject obj = null;
    private GameObject elem = null;


    void Awake()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.Interact.performed += ctx => Interact();
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput * speed;
    }

    private void Interact()
    {
        if (obj != null && obj.GetComponent<Object>().pickable)
        {
            obj.GetComponent<Object>().PickUp();
        }
        else if (elem != null && elem.GetComponent<Element>().interactible)
        {
            elem.GetComponent<Element>().TryInteractObject();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Object"))
        {
            other.gameObject.GetComponent<Object>().pickable = true;
            obj = other.gameObject;
        }
        if (other.gameObject.tag.Equals("Element"))
        {
            other.gameObject.GetComponent<Element>().interactible = true;
            elem = other.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Object"))
        {
            other.gameObject.GetComponent<Object>().pickable = false;
            obj = null;
        }
        if (other.gameObject.tag.Equals("Element"))
        {
            other.gameObject.GetComponent<Element>().interactible = false;
            elem = null;
        }
    }
}
