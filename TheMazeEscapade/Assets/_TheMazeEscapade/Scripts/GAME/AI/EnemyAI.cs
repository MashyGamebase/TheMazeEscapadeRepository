using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of movement
    public float roamRadius = 5f; // Maximum distance from the starting point
    public float changeDirectionTime = 3f; // Time before changing direction
    public float idleTime = 1.5f;

    private Vector2 roamCenter;
    private Vector2 targetPosition;
    private float timer;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    private bool isMoving = false;        // True when moving, False when idling
    private bool isIdling = false;

    void Start()
    {
        roamCenter = transform.position; // Set initial roam center
        PickNewTarget();
    }

    void Update()
    {
        if (isMoving)
        {
            Move();
        }

        AnimationControl();
    }

    void AnimationControl()
    {
        animator.SetBool("isMoving", isMoving);
    }

    void Move()
    {
        // Move towards the target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Flip the sprite based on movement direction
        spriteRenderer.flipX = targetPosition.x < transform.position.x;

        // Check if the enemy reached the target
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f && !isIdling)
        {
            StartCoroutine(IdleBeforeNextMove());
        }
    }

    IEnumerator IdleBeforeNextMove()
    {
        isMoving = false;
        isIdling = true;
        yield return new WaitForSeconds(idleTime); // Wait before moving again
        isIdling = false;
        PickNewTarget();
    }

    void PickNewTarget()
    {
        // Pick a random position within the roam radius
        targetPosition = roamCenter + Random.insideUnitCircle * roamRadius;
        isMoving = true;
    }

    public void Attack()
    {
        // Placeholder attack function
        Debug.Log("Enemy attacks!");
    }

    // Draw roaming radius in Scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(roamCenter, roamRadius);
    }
}