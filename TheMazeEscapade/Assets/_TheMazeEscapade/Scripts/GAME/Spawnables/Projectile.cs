using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float force = 2;
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.down * force, ForceMode2D.Impulse);
        Invoke("DestroyAfter", 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!collision.gameObject.GetComponent<Player2DMovement>().knockback)
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1, transform.position, 6.5f);
                Destroy(gameObject);
            }
        }
    }

    void DestroyAfter()
    {
        Destroy(gameObject);
    }
}