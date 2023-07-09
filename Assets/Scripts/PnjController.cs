using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PnjController : MonoBehaviour
{
    public Transform[] waypoints;  // List of points the PNJ will visit
    public float movementSpeed = 5f;  // Speed at which the PNJ moves
    public float pauseDuration = 1f;  // Duration to pause at each point
    private Animator NPCAnimator;
    private int currentWaypointIndex = 0;
    private bool isPaused = false;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        NPCAnimator = GetComponent<Animator>();
        StartCoroutine(MoveToNextWaypoint());
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = false;
        }

        //not working, MoveTowards doesn't change velocity
    }
    private IEnumerator MoveToNextWaypoint()
    {
        while (true)
        {
            if (!isPaused)
            {
                Vector2 targetPosition = waypoints[currentWaypointIndex].position;
                while ((Vector2)transform.position != targetPosition)
                {
                    NPCAnimator.SetBool("isMoving", true);
                    Vector2 newPos = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
                    transform.position = new Vector3(newPos.x, newPos.y, 1);
                    yield return null;
                }
                NPCAnimator.SetBool("isMoving", false);
                yield return new WaitForSeconds(pauseDuration);
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
            else
            {
                yield return null;
            }
        }
    }
}
