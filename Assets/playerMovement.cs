using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float speed = 5f;
	public float jumpForce = 5f;

	
	bool hasJumped = false;
	float jumpDelay = 0.5f; //TODO harðkoðun laga

	Rigidbody2D rb;
	Animator anim;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator>();
	}

	void Update () {

		if(Input.GetAxis("Horizontal") != 0 ){ //TODO aðlaga animation speed að walking speed
			anim.SetBool ("IsMoving", true);
		}
		else {
			anim.SetBool ("IsMoving", false);
		}
		anim.SetBool("Jump", hasJumped);

		rb.AddForce( new Vector2( Input.GetAxis("Horizontal") * speed,0 )); 

		if( Input.GetAxis("Jump") > 0f  && !hasJumped)  {
			rb.AddForce( new Vector2( 0, jumpForce ), ForceMode2D.Impulse );
			hasJumped = true;
		}
		if(hasJumped){
			jumpDelay -= Time.deltaTime;
			if(jumpDelay <= 0){
				jumpDelay = 0.5f;
				hasJumped = false;
			}
		}
	}
}
