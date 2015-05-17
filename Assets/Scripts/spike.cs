using UnityEngine;
using System.Collections;

public class spike : MonoBehaviour {

	public float startDelay = 0f; //TODO Gera gafaðara
	public float repeatRate = 3f;
	public float spikingSpeed = 2f;	 
	public float spikeDistance = 2f;

	Vector3 originalPos;
	// Use this for initialization
	void Start () {
		originalPos = this.transform.position;
		StartCoroutine("DartUp",repeatRate);
	}
	
	// Update is called once per frame

	IEnumerator DartUp () {
		yield return new WaitForSeconds(startDelay);

		Vector3 endPos = new Vector3( originalPos.x, 
		                              originalPos.y + spikeDistance, 
		                              originalPos.z );
		float timer = 0;

		while(transform.position != endPos){ //upp

			timer += Time.deltaTime * spikingSpeed;
			transform.position = Vector3.Lerp( originalPos, 
			                                   endPos,
			                                   timer );
			yield return null;
		}
		timer = 0;
		while(transform.position != originalPos) { //nyður

			timer += Time.deltaTime * spikingSpeed; 
			transform.position = Vector3.Lerp( endPos, 
			                                  originalPos,
			                                  timer );

			yield return null;
		}
		yield return new WaitForSeconds(repeatRate);
		Start ();
	}
}
