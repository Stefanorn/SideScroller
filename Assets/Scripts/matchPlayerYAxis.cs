using UnityEngine;
using System.Collections;

public class matchPlayerYAxis : MonoBehaviour {

	public float speed = 2f;

	Transform playerPos;

	// Use this for initialization
	void Start () {	

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		playerPos = GameObject.FindWithTag("Respawn").GetComponent<gameLogic>().SendPlayerTransformInfo();

		if(playerPos.position.x > transform.position.x ){
			return;
		}

		Vector3 yPos = new Vector3(transform.position.x , playerPos.position.y, 0 );
		transform.position = Vector3.MoveTowards(transform.position , yPos, speed * Time.deltaTime );
	}


}
