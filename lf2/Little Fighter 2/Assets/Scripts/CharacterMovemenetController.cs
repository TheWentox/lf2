using UnityEngine;
using System.Collections;
using System;
using Input = UnityEngine.Input;

public class CharacterMovemenetController : MonoBehaviour {

	private Rigidbody2D rigidBody;

    public float walkSpeed = 1.5f;
    public float runSpeed = 2.5f;
    public float jumpForce = 1f;

    public bool facingRight = true;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;
    public Animator animator;
    private EnemyDestroyer character;

    private float lastTimeWalkPressed = -1.0f;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        character = GetComponent<EnemyDestroyer>();
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
            rigidBody.velocity = rigidBody.velocity.x < -1.5f ? new Vector2(-runSpeed, rigidBody.velocity.y) : new Vector2(-walkSpeed, rigidBody.velocity.y);
        }
        if (Input.GetKey(right))
        {
            if (!facingRight)
            {
                Flip();
            }
            rigidBody.velocity = rigidBody.velocity.x > 1.5f ? new Vector2(runSpeed, rigidBody.velocity.y) : new Vector2(walkSpeed, rigidBody.velocity.y);
        }

        if (Input.GetKeyDown(left))
        {
            if (facingRight)
            {
                Flip();
            }
            rigidBody.velocity = Time.time - lastTimeWalkPressed < 0.2f ? new Vector2(-runSpeed, rigidBody.velocity.y) : new Vector2(-walkSpeed, rigidBody.velocity.y);
            lastTimeWalkPressed = Time.time;
        }
        if (Input.GetKeyDown(right))
        {
            if (!facingRight)
            {
                Flip();
            }
            rigidBody.velocity = Time.time - lastTimeWalkPressed < 0.2f ? new Vector2(runSpeed, rigidBody.velocity.y) : new Vector2(walkSpeed, rigidBody.velocity.y);
            lastTimeWalkPressed = Time.time;
        }

        if (Input.GetKey(jump) && isGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
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
