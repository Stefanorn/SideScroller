using UnityEngine;
using System.Collections;

public class spittForward : MonoBehaviour {


	public float startDelay = 0f;
	public float repeatRate = 2f;
	public float spittForce = 2f;
	public GameObject spitt;
	public Transform spawnPoint;
	

	// Update is called once per frame
	void Start(){
		InvokeRepeating( "Spitt",  startDelay ,repeatRate);

	}

	void Spitt() {

		GameObject instanceOfSpitt = (GameObject)Instantiate(	spitt,
		                                                     	spawnPoint.position,
		                                                     	Quaternion.identity	);


		instanceOfSpitt.GetComponent<Rigidbody2D>().AddForce(	new Vector2 (spittForce, 0), 
		                                                     	ForceMode2D.Impulse);
		
	}
}
