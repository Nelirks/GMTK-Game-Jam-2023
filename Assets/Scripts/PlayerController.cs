using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 10.0f;
    private float speed;
    private Vector2 moveInput;
    private PlayerControls controls;
    private Rigidbody2D rb;
    private GameObject obj = null;
    private GameObject elem = null;
    private SpriteRenderer spriteRenderer;
    private Animator animator;


    void Awake()
    {
        speed = baseSpeed;
        controls = new PlayerControls();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.Interact.performed += ctx => Interact();
        controls.Player.Interact.performed += ctx => DialogueBox.instance.DisplayNextLine();
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
        
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
            animator.SetBool("isWalking", true);
        else
            animator.SetBool("isWalking", false);

        if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (rb.velocity.x < 0)
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

    public void PreventMovement(bool prevent) {
        if (prevent) speed = 0;
        else speed = baseSpeed;
	}
}
