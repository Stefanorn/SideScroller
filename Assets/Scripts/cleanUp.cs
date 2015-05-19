using UnityEngine;
using System.Collections;

public class cleanUp : MonoBehaviour {

	public bool destroyOnInvisible = true;

	void OnBecameInvisible() {
		if(destroyOnInvisible){
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D (){

		Destroy(gameObject);
	}
	void OnCollisionEnter2D () {
		Destroy(gameObject);

	}
}
