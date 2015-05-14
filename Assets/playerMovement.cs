using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float speed = 5f;
	public float jumpForce = 5f;


	float jumpTimer = 0.3f;
	bool hasJumped = false;
	float jumpDelay = 0.3f;

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		rb.AddForce( new Vector2( Input.GetAxis("Horizontal") * speed,0 ));

		if( jumpTimer > 0f && Input.GetAxis("Jump") > 0f  && !hasJumped)  {
			rb.AddForce( new Vector2( 0, jumpForce ), ForceMode2D.Impulse );
			jumpTimer -= Time.deltaTime;

			hasJumped = true;
		}
		if(hasJumped){
			jumpDelay -= Time.deltaTime;
			if(jumpDelay <= 0){
				jumpDelay = 0.7f;
				jumpTimer = 0.3f;
				hasJumped = false;
			}
		}
	}
}
