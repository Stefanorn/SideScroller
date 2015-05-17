using UnityEngine;
using System.Collections;

public class spike : MonoBehaviour {

	public float startDelay = 0f;
	public float repeatRate = 3f;
	public float spikingSpeed = 2; //Mælt i sek
	public float spikeDistance = 2f;

	Vector3 originalPos;
	// Use this for initialization
	void Start () {
		originalPos = this.transform.position;
		InvokeRepeating("Darting",startDelay,repeatRate);

		StartCoroutine("Darting",repeatRate);
	}
	
	// Update is called once per frame
	IEnumerator Darting () {
		spikeDistance /= 10f;
		Vector3 endPos = new Vector3( originalPos.x, 
		                              originalPos.y + spikeDistance , 
		                              originalPos.z );
		while(true){

			transform.position = Vector3.Lerp( originalPos, 
			                                   endPos,
			                                   spikingSpeed * Time.deltaTime );

			yield return null;
		}

	}
}
