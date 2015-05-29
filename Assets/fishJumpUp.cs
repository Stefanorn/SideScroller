using UnityEngine;
using System.Collections;

public class fishJumpUp : MonoBehaviour {

	public Sprite jumpUp;
	public Sprite fallDown;
	public float jumpForce;

	Renderer ren;
	Rigidbody2D rb;
	Vector3 parentPos;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		parentPos = transform.parent.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if ( transform.position.y < parentPos.y ){

			Jump();
		}
		if(rb.velocity.y < 0){
			GetComponent<SpriteRenderer>().sprite = fallDown;
		}
		if(rb.velocity.y > 0){
			GetComponent<SpriteRenderer>().sprite = jumpUp; 
		}
		rb.velocity = (new Vector2( 0f , rb.velocity.y)); //Passar að hann fari ekkert a Xas
	}

	void Jump (){
		rb.AddForce( new Vector2(  0,jumpForce), ForceMode2D.Impulse);
		Debug.Log("hello");
	}
}
