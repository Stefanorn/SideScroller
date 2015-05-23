	using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float speed = 5f;
	public float jumpForce = 5f;

	
	bool hasJumped = false;
//	float jumpDelay = 0.5f; //TODO harðkoðun laga

	Rigidbody2D rb;
	Animator anim;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator>();
	}

	void Update () {

		RaycastHit2D groundCheck = Physics2D.Raycast (	transform.position,
		                                              	-Vector2.up,
		                     							0.2f  );
		RaycastHit2D jumpAnimationGroundCheck = Physics2D.Raycast ( transform.position,
		                                                           	-Vector2.up,
		                                                            0.3f );
		if(jumpAnimationGroundCheck.collider != null) {
			anim.SetBool("Jump", false);
		}
		else {
			anim.SetBool("Jump", true);
		}

		if( groundCheck.collider != null ) { 
			if( Input.GetAxis("Jump") > 0f & !hasJumped ) {
				rb.AddForce( new Vector2( 0, jumpForce ), ForceMode2D.Impulse );
				hasJumped = true;
				Invoke("JumpDelay", 0.2f );
			}

		}

		if(Input.GetAxis("Horizontal") != 0 ){
			anim.SetBool ("IsMoving", true);
		}
		else {
			anim.SetBool ("IsMoving", false);
		}
//		anim.SetBool("Jump", hasJumped); //TODO athuga jump animation betur
		float xVel = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float yVel = rb.velocity.y;
		rb.velocity = new Vector2(xVel, yVel );

	}
	void JumpDelay() {
		hasJumped = false;
	}
}
