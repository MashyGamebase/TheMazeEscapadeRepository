using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float roamRadius = 5f;
    public float changeDirectionTime = 3f;
    public float idleTime = 1.5f;
    public bool canChasePlayer = false; // Determines if the enemy can chase the player

    private Vector2 roamCenter;
    private Vector2 targetPosition;
    private bool isMoving = false;
    private bool isIdling = false;
    private Transform player;
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    void Start()
    {
        roamCenter = transform.position;
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (canChasePlayer)
            idleTime = 0.05f;

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
        animator.SetBool("movingRight", !spriteRenderer.flipX);
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        spriteRenderer.flipX = targetPosition.x < transform.position.x;

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f && !isIdling)
        {
            StartCoroutine(IdleBeforeNextMove());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!collision.gameObject.GetComponent<Player2DMovement>().knockback)
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1, transform.position, 6.5f);
        }
    }

    IEnumerator IdleBeforeNextMove()
    {
        isMoving = false;
        isIdling = true;
        yield return new WaitForSeconds(idleTime);
        isIdling = false;
        PickNewTarget();
    }

    void PickNewTarget()
    {
        if (canChasePlayer && player != null)
        {
            Vector2 directionToPlayer = (player.position - (Vector3)roamCenter).normalized;
            Vector2 randomOffset = Random.insideUnitCircle * 2f; // Adds a random movement pattern
            targetPosition = (Vector2)player.position + randomOffset;
        }
        else
        {
            targetPosition = roamCenter + Random.insideUnitCircle * roamRadius;
        }
        isMoving = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(roamCenter, roamRadius);
    }
}
