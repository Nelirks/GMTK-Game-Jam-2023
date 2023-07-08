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
    private SpriteRenderer spriteRenderer;
    private Animator animator;


    void Awake()
    {
        controls = new PlayerControls();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

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
        
        if (moveInput.x != 0 || moveInput.y != 0)
            animator.SetBool("isWalking", true);
        else
            animator.SetBool("isWalking", false);

        if (moveInput.x == 1)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveInput.x == -1)
        {
            spriteRenderer.flipX = false;
        }

    }

    private void Interact()
    {
        if (obj != null)
        {
            obj.GetComponent<Object>().PickUp();
        }
        else if (elem != null)
        {
            elem.GetComponent<Element>().TryInteractObject();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Object"))
        {
            obj = other.gameObject;
        }
        if (other.gameObject.tag.Equals("Element"))
        {
            elem = other.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Object"))
        {
            obj = null;
        }
        if (other.gameObject.tag.Equals("Element"))
        {
            elem = null;
        }
    }
}
