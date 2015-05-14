using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float speed = 5f;
	public float jumpForce = 5f;

	
	bool hasJumped = false;
	float jumpDelay = 0.7f; //TODO harðkoðun laga

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		rb.AddForce( new Vector2( Input.GetAxis("Horizontal") * speed,0 ));

		if( Input.GetAxis("Jump") > 0f  && !hasJumped)  {
			rb.AddForce( new Vector2( 0, jumpForce ), ForceMode2D.Impulse );

			hasJumped = true;
		}
		if(hasJumped){
			jumpDelay -= Time.deltaTime;
			if(jumpDelay <= 0){
				jumpDelay = 0.7f;
				hasJumped = false;
			}
		}
	}
}
