using UnityEngine;
using System.Collections;

public class DeathMessageSender : MonoBehaviour {

	public bool isAbleToKillEnemys = true;
	public GameObject deathAnimation;

	GameObject obj;

	void OnTriggerEnter2D ( Collider2D col ){
		if(col.tag == "Player"){
			obj = col.gameObject;
			Destroy(obj.gameObject);
			GameObject death = (GameObject)Instantiate(	deathAnimation,
			                                            col.gameObject.transform.position,
			                                            Quaternion.identity	);
			death.GetComponent<Rigidbody2D>().AddForce(	new Vector2 (0, 4f), 
			                                 			ForceMode2D.Impulse);
			Invoke("DeathDelay" , 2f);
		}
		else if(col.tag == "Enemy" && isAbleToKillEnemys) {
			Destroy(col.gameObject);
		}
	}
	void DeathDelay(){
		GameObject.FindWithTag("Respawn").GetComponent<gameLogic>().Respawn();	
	}
}