using UnityEngine;
using System.Collections;

public class spittForward : MonoBehaviour {


	public float startDelay = 0f;
	public float repeatRate = 2f;
	public float spittForce = 2f;
	public GameObject spitt;
	public Transform spawnPoint;
	
	Transform playerPos;
	
	// Use this for initialization
	void Start () {	
		
		//playerPos = GameObject.FindGameObjectWithTag("Player").transform;
		InvokeRepeating( "Spitt",  startDelay ,repeatRate);
	}

	void Spitt() {
		playerPos = GameObject.FindGameObjectWithTag("Player").transform; //OPTIMIZE?

		Vector3 distPlayerTransform = spawnPoint.transform.position - playerPos.transform.position;
		float yArc = distPlayerTransform.x + distPlayerTransform.y;
		if (distPlayerTransform.x < 0){
			return;
		}
		Quaternion spitrotation = new Quaternion (	Quaternion.identity.x , 
			                                      	Quaternion.identity.y , 
			                                     	spawnPoint.rotation.z ,
		                                	   	   	Quaternion.identity.w );

		GameObject instanceOfSpitt = (GameObject)Instantiate(	spitt,
		                                                     	spawnPoint.position,
		                                                 	    spitrotation	);
		instanceOfSpitt.GetComponent<Rigidbody2D>().AddForce( new Vector2 (	spittForce, yArc), 
		                                                     				ForceMode2D.Impulse);
		
	}
}
