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
    private GameObject obj;

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
        if (obj.GetComponent<Object>().pickable == true)
        {
            obj.GetComponent<Object>().PickUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Object"))
        {
            other.gameObject.GetComponent<Object>().pickable = true;
            obj = other.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Object"))
        {
            other.gameObject.GetComponent<Object>().pickable = false;
            obj = null;
        }
    }
}
