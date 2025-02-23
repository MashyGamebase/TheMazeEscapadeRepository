using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Animator animator;
    private Rigidbody2D rb2d;

    Vector2 moveInput = Vector2.zero;
    Vector2 faceDirection = Vector2.zero;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
        AnimationControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetInput()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
    }

    private void AnimationControl()
    {
        if(moveInput.x > 0) // Moving Right
        {
            animator.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(moveInput.x < 0) // Moving Left
        {
            animator.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        animator.SetBool("isMoving", moveInput.sqrMagnitude > 0.01f ?  true : false);

        if(moveInput.sqrMagnitude > 0.01f)
        {
            faceDirection = moveInput;
            animator.SetFloat("FacingX", faceDirection.x);
            animator.SetFloat("FacingY", faceDirection.y);
        }
    }

    private void MovePlayer()
    {
        rb2d.MovePosition(rb2d.position + moveInput.normalized * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Explosion"))
        {
            GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}