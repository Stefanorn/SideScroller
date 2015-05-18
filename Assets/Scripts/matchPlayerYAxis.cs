using UnityEngine;
using System.Collections;

public class matchPlayerYAxis : MonoBehaviour {

	public float speed = 2f;

	Transform playerPos;

	// Use this for initialization
	void Start () {	

		playerPos = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(playerPos == null){
			playerPos = GameObject.FindGameObjectWithTag("Player").transform; //Fynnur ekki player þegar hann er dauður NullRef
			return;
		}
		Vector3 yPos = new Vector3(transform.position.x , playerPos.position.y, 0 );
		transform.position = Vector3.MoveTowards(transform.position , yPos, speed * Time.deltaTime );
	}


}
