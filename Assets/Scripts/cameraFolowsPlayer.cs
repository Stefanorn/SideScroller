using UnityEngine;
using System.Collections;

public class cameraFolowsPlayer : MonoBehaviour {

	public float speed = 2f;
	public Vector3 offset;

	Transform playerPos;
	
	// Use this for initialization
	void Start () {	
		
		playerPos = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void FixedUpdate (){
		playerPos = GameObject.FindWithTag("Respawn").GetComponent<gameLogic>().SendPlayerTransformInfo();
		if(playerPos == null) {
			return;
		}
		Vector3 cameraPos = new Vector3(transform.position.x,transform.position.y, -10f);
		Vector3 playerPosWithOutZ = new Vector3(playerPos.position.x, playerPos.position.y, -10f );

		Vector3 speedModifier =  cameraPos - playerPosWithOutZ;
		if(speedModifier.x < 0f ){
			speedModifier.x *= -1;
		}
		if(speedModifier.y < 0f ){
			speedModifier.y *= -1;
		}
		transform.position = Vector3.MoveTowards(	cameraPos , 
		                                         	playerPosWithOutZ , 
		                                         speed * Time.deltaTime * (speedModifier.x + speedModifier.y));
		transform.position += offset;
	}
}
