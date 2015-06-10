using UnityEngine;
using System.Collections;

public class keyUnlocksDoor : MonoBehaviour {

	public GameObject door;
	public GameObject key;
	public float timeFromAtoB = 3f;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D (Collider2D col ) {
		if(col.tag == "Player"){
			door.GetComponent<BoxCollider2D>().enabled = false; 
			door.GetComponent<Rigidbody2D>().isKinematic = false;
			StartCoroutine("KeyToDoor");
		}

	}
	IEnumerator KeyToDoor() {
		float timer = 0f;
		while(timer <= timeFromAtoB ){
			key.transform.position = Vector3.Lerp( 	key.transform.position ,
			                             			door.transform.position , 
			                                      	timer / timeFromAtoB );
			timer += Time.deltaTime;
			yield return null;
		}
	}
}
