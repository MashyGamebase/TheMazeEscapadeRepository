using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    float originalSpeed;
    [SerializeField] private Animator animator;
    private Rigidbody2D rb2d;

    Vector2 moveInput = Vector2.zero;
    Vector2 faceDirection = Vector2.zero;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioSource hurtSource;
    [SerializeField] private List<AudioClip> clips;
    [SerializeField] private AudioClip hurtSound;

    public List<SpriteRenderer> spr;

    internal bool knockback = false;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        originalSpeed = speed;
    }

    private void Update()
    {
        GetInput();
        AnimationControl();
    }

    private void FixedUpdate()
    {
        if(!knockback)
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

    public void TakeDamage(Vector2 damageSource, float knockbackForce)
    {
        PlayOneShotTakeDamage();
        knockback = true;

        animator.SetTrigger("TakeDamage");

        // Compute knockback direction (opposite of the attack source)
        Vector2 knockbackDir = (rb2d.position - damageSource).normalized;

        // Apply impulse force for knockback
        rb2d.velocity = knockbackDir * knockbackForce;

        // Optionally, disable movement for a short time
        StopAllCoroutines();
        StartCoroutine(DisableMovementForSeconds(0.2f)); // Adjust duration as needed
    }

    private IEnumerator DisableMovementForSeconds(float duration)
    {
        speed = 0; // Stop movement
        yield return new WaitForSeconds(duration);

        ResetMovement();
    }

    void ResetMovement()
    {
        speed = originalSpeed;
        knockback = false;
    }

    public void PlayOneShotFootstep()
    {
        source.PlayOneShot(clips[Random.Range(0, clips.Count)]);
    }

    public void PlayOneShotTakeDamage()
    {
        hurtSource.PlayOneShot(hurtSound);
    }
}