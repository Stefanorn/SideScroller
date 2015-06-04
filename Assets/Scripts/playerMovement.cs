	using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float speed = 5f;
	public float jumpForce = 5f;
	public float GroundCheckRayLenght = 1f;
	public float slidingDecayOnIcySurface = 3f;
	public float slidingSpeed = 10f;

	
	bool hasJumped = false;

	Rigidbody2D rb;
	Animator anim;
	int faceDirection = 1; //Is used to determen what direction the player is facing
	float slidingSpeedCatcher;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator>();
		slidingSpeedCatcher = slidingSpeed;
	}

	void Update () {
		float xVel = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //Determens speed and direction of the player
		if( xVel < 0f ){ // Changse the face direction to positive or negative when the player is turned to the right or left
			faceDirection = -1;
			slidingSpeed = slidingSpeedCatcher * faceDirection;
		}
		else if(xVel > 0f){ //Makes the Facedirection positive when xvel is positive
			faceDirection = 1;
			slidingSpeed = slidingSpeedCatcher * faceDirection;
		}
		RaycastHit2D groundCheck = Physics2D.Raycast (	transform.position,
		                                              	-Vector2.up,
		                                              	GroundCheckRayLenght  );  //Used when collidet to ground and allows you to jump
		RaycastHit2D jumpAnimationGroundCheck = Physics2D.Raycast ( transform.position,
		                                                           	-Vector2.up,
		                                                            GroundCheckRayLenght * 1.2f ); 	// a slightly longer ray to sop the Jumpanimatin befor hitting the ground
		if(jumpAnimationGroundCheck.collider != null) {												// Also used to turning of enemys colliter and killing them befor your colliters hits them
			if(jumpAnimationGroundCheck.collider.tag == "Enemy"){
				Collider2D enemyCollider = jumpAnimationGroundCheck.collider;
				rb.velocity = new Vector2(0, jumpForce/1.25f);
				enemyCollider.GetComponent<Rigidbody2D>().AddForce(	new Vector2( 0, 6f ),
				                                                   	ForceMode2D.Impulse );  //adds a little death jump to enemys
				if( enemyCollider.GetComponent<matchPlayerYAxis>() ) {						//Checks if eneny is the fly enemy and shuts of his BEEhavior 
					enemyCollider.GetComponent<matchPlayerYAxis>().enabled = false;		
					enemyCollider.GetComponent<spittForward>().enabled = false;
					enemyCollider.GetComponent<Rigidbody2D>().isKinematic = false;
				}
				Destroy(enemyCollider);	//Destroy the collider so the enemys fall through the map

			}
			anim.SetBool("Jump", false); //Using the slightly longer ray, shuts of the jump animation befor he hits the ground
		}
		else {
			anim.SetBool("Jump", true);
		}

		if( groundCheck.collider != null ) { //Checks if you are colliding with anything so you cant jump midAir
			if( Input.GetAxis("Jump") > 0f & !hasJumped ) { //hasJump is a jumpdelay so you cant spam the jump
				rb.velocity = new Vector3(0, jumpForce);
				hasJumped = true;
				Invoke("JumpDelay", 0.2f );
			}
			if(groundCheck.collider.tag == "SnowGround"){ // Makes player slide when standing on snowtile
				Collider2D snowCollider = jumpAnimationGroundCheck.collider; 
				snowCollider.GetComponent<SurfaceEffector2D>().speed = slidingSpeed; //Gifs the surficeEffector the sliding speed variable
				if(slidingSpeed > 0.1f || slidingSpeed < -0.1f) { // Clamps the sliding speed down so player whont start sliding in the opisode direction due to the -=
					slidingSpeed -= Time.deltaTime * slidingDecayOnIcySurface * faceDirection;
				}
				if(Input.GetAxis("Jump") > 0f){ //I he jumps he will slide on landing
					slidingSpeed = slidingSpeedCatcher * faceDirection ;
				}
			}


		}

		if(Input.GetAxis("Horizontal") != 0 ){ //Plays walking animation
			anim.SetBool ("IsMoving", true);
		}
		else {
			anim.SetBool ("IsMoving", false);
		}

		float yVel = rb.velocity.y; // Takes care of not changing the Y Axis when updating the velosity
		rb.velocity = new Vector2(xVel, yVel ); // Takes in the velosity variable and updates

	}
	void JumpDelay() {
		hasJumped = false;
	}
}
