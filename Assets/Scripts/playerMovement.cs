	using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float speed = 5f;
	public float jumpForce = 5f;
	public float GroundCheckRayLenght = 1f;

	
	bool hasJumped = false;

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
		                                              	GroundCheckRayLenght  );
		RaycastHit2D jumpAnimationGroundCheck = Physics2D.Raycast ( transform.position,
		                                                           	-Vector2.up,
		                                                            GroundCheckRayLenght * 1.2f );
		if(jumpAnimationGroundCheck.collider != null) {
			if(jumpAnimationGroundCheck.collider.tag == "Enemy"){
				rb.velocity = new Vector2(0, jumpForce/1.5f);
				jumpAnimationGroundCheck.collider.GetComponent<Rigidbody2D>().AddForce(	new Vector2( 0, 6f ),
				                                                                        ForceMode2D.Impulse );
				if( jumpAnimationGroundCheck.collider.GetComponent<matchPlayerYAxis>() ) {
					jumpAnimationGroundCheck.collider.GetComponent<matchPlayerYAxis>().enabled = false;
					jumpAnimationGroundCheck.collider.GetComponent<Rigidbody2D>().isKinematic = false;
				}
				Destroy(jumpAnimationGroundCheck.collider);

			}
			anim.SetBool("Jump", false);
		}
		else {
			anim.SetBool("Jump", true);
		}

		if( groundCheck.collider != null ) { 
			if( Input.GetAxis("Jump") > 0f & !hasJumped ) {
				rb.velocity = new Vector3(0, jumpForce);
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
