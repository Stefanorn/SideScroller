using UnityEngine;
using System.Collections;

public class DeathMessageSender : MonoBehaviour {

	public GameObject deathAnimation;

	GameObject obj;

	void OnTriggerEnter2D ( Collider2D col ){
		if(col.tag == "Player"){
			if(GameObject.FindWithTag("Respawn").GetComponent<gameLogic>().ignoreDeath){
				return;
			}
			obj = col.gameObject;
			Destroy(obj.gameObject);
			GameObject death = (GameObject)Instantiate(	deathAnimation,
			                                            col.gameObject.transform.position,
			                                            Quaternion.identity	);
			death.GetComponent<Rigidbody2D>().AddForce(	new Vector2 (0, 12f), 
			                                 			ForceMode2D.Impulse);
			Invoke("DeathDelay" , 2f);
		}
	}
	void DeathDelay(){
		GameObject.FindWithTag("Respawn").GetComponent<gameLogic>().Respawn();	
		Debug.Log("asdfasf");
	}
}