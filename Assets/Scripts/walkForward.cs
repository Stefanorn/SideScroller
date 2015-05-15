using UnityEngine;
using System.Collections;

public class walkForward : MonoBehaviour {

	public float speed = 2f;
	Rigidbody2D rb;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		Debug.Log (-speed * Time.deltaTime);
		rb.AddForce( new Vector2(-speed * Time.deltaTime, 0) );
	}
}
