using UnityEngine;
using System.Collections;

public class CharacterMovemenetController : MonoBehaviour {

	private Rigidbody2D rigidboy;
	
	public float maxSpeed = 2f;
	public float jumpForce = 2f;

    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
	
	public static bool facingRight = true;

    public Transform deathHeight;

    private Animator anim;

    public float idleTime = 2.0f;
    public float idleCoolDown = 0;

	// Use this for initialization
	void Start () {
		rigidboy = gameObject.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		//If there's any vertical movement (e.g: right of left arrow pressed
		float move = Input.GetAxis("Horizontal");
		//Add vertical velocity
		this.rigidboy.velocity = new Vector2(move*maxSpeed, this.rigidboy.velocity.y);
		
		// If the input is moving the player right and the player is facing left...
		if (move > 0 && !facingRight)
		{
			// ... flip the player.
			flip();
		}
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (move < 0 && facingRight)
		{
			// ... flip the player.
			flip();
		}
		
		//if Jump button is pressed
		if (Input.GetButtonDown("Jump")) {
			//Add vertical force to the character
			rigidboy.velocity = new Vector2(0, jumpForce); 
		}

        if(this.transform.position.y < deathHeight.position.y)
        {
            GameObject.FindGameObjectWithTag("GameController").
                GetComponent<RespawnController>().respawn();
        }

        float speed;
        speed = Mathf.Abs(rigidboy.velocity.x);
        anim.SetFloat("Speed", speed);

        bool isGrounded;
        isGrounded = Physics2D.OverlapCircle(
                         groundCheck.position,
                         groundRadius,
                         whatIsGround);
        anim.SetBool("Grounded", isGrounded);

        if (rigidboy.velocity.magnitude == 0.0f)
        {
            idleTime -= idleTime.fixedDeltaTime;
            if (idleCoolDown < 0.0f)
            {
                anim.SetTrigger("Idle");
            }
        } else
        {
            idleCoolDown = idleTime;
        }
	}


private void flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
