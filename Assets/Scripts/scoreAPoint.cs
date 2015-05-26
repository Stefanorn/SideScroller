using UnityEngine;
using System.Collections;

public class scoreAPoint : MonoBehaviour {

	public float scoreAmmount = 10f;

	
	void OnTriggerEnter2D ( Collider2D col ){
		if(col.tag == "Player"){
			GameObject.FindWithTag("Respawn").GetComponent<gameLogic>().Score(10f);
		}
		Destroy(gameObject);
	}

}
