using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PnjController : MonoBehaviour
{
    public Transform[] waypoints;  // List of points the PNJ will visit
    public float movementSpeed = 5f;  // Speed at which the PNJ moves
    public float pauseDuration = 1f;  // Duration to pause at each point

    private int currentWaypointIndex = 0;
    private bool isPaused = false;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        StartCoroutine(MoveToNextWaypoint());
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        Debug.Log(rb.velocity);
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
                    transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
                    yield return null;
                }
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
