using UnityEngine;
using System.Collections;

public class walkForward : MonoBehaviour {

	public float speed = 2f;
	Rigidbody2D rb;

	bool wasZeroLastFrame = false;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float xVel = rb.velocity.x;
		float yVel = rb.velocity.y;

		rb.velocity = new Vector2(-speed* Time.deltaTime, yVel);

		if(xVel == 0){
			if(xVel == 0 && wasZeroLastFrame){
				transform.Rotate( new Vector3( 0 , 180 ) );
				speed *= -1;
				wasZeroLastFrame = false;
				return;
			}
			wasZeroLastFrame = true;
		}
	}
}
