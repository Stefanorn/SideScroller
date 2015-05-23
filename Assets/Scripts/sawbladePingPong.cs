using UnityEngine;
using System.Collections;

public class sawbladePingPong : MonoBehaviour {
	
	public Transform targetLocation;
	public Transform sawbladeGO;
	public float timeFromAtoB = 2f;


	float timer = 0f;
	Vector3 originalLocation;
	
	// Use this for initialization
	void Start () {
		
		originalLocation = sawbladeGO.transform.position;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		timer += Time.deltaTime*timeFromAtoB;
		if(timer > 1f){
			timeFromAtoB *= -1f;
		}
		if(timer < -0.0f){
			timeFromAtoB *= -1f;
		}
		sawbladeGO.position = Vector3.Lerp( originalLocation, targetLocation.position, timer );

	}
}
