using UnityEngine;
using System.Collections;

public class cleanUp : MonoBehaviour {

	public bool destroyOnInvisible = true;
	public bool destroyOnTrigger = true;
	public bool destroyOnCollision = true;
	public bool destroyAfterXTime = true;
	public float time;

	void start(){
		if(destroyAfterXTime){
			Invoke("DestroyNow", time);
		}

	}
	void DestroyNow(){
		Destroy(gameObject);	
	}

	void OnBecameInvisible() { //TODO virkar ekki athuga betur
		if(destroyOnInvisible){
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D (){
		if(destroyOnTrigger)
			Destroy(gameObject);
	}
	void OnCollisionEnter2D () {
		if(destroyOnCollision)
			Destroy(gameObject);

	}
}
