using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    private bool movingRight = true;
    public SpriteRenderer visual;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Patrol();
    }

    private void Patrol()
    {
        // Move the AI based on the current direction
        if (movingRight)
        {
            rb2d.MovePosition(rb2d.position + Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            rb2d.MovePosition(rb2d.position + Vector2.left * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Explosion"))
        {
            Die();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reverse direction when hitting a collider
        if (collision.gameObject.CompareTag("Obstacle"))  // Make sure your boundary objects have the "Boundary" tag
        {
            movingRight = !movingRight;
            visual.flipX = !movingRight;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}