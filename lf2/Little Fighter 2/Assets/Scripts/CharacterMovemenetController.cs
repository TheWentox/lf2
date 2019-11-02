using UnityEngine;
using System.Collections;
using System;

public class CharacterMovemenetController : MonoBehaviour {

	private Rigidbody2D rigidBody;

    public float walkSpeed = 1.5f;
    public float runSpeed = 2.5f;
    public float jumpForce = 1f;

    public bool facingRight = true;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode fire;

    public Transform firePoint;
    public GameObject ballPrefab;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;
    public Animator animator;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        if (Input.GetKey(left))
        {
            if (facingRight)
            {
                Flip();
            }
            rigidBody.velocity = new Vector2(-walkSpeed, rigidBody.velocity.y);
        }
        if (Input.GetKey(right))
        {
            if (!facingRight)
            {
                Flip();
            }
            rigidBody.velocity = new Vector2(walkSpeed, rigidBody.velocity.y);
        }

        if (Input.GetKey(jump) && isGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }

        if (Input.GetKey(fire))
        {
            animator.SetTrigger("FreezeShoot");
            Instantiate(ballPrefab, firePoint.position, firePoint.rotation);
        }

        animator.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        animator.SetBool("Grounded", isGrounded);
    }

    private void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
