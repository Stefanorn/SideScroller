using UnityEngine;
using System.Collections;

public class DeathMessageSender : MonoBehaviour {
	
	void OnTriggerEnter2D ( Collider2D col ){
		if(col.tag == "Player"){
			GameObject.FindWithTag("Respawn").GetComponent<gameLogic>().Respawn();
			Destroy(col.gameObject);	
		}
		else if(col.tag == "Enemy") {
			Destroy(col.gameObject);
		}
	}
}
