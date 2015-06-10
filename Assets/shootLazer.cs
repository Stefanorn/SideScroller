using UnityEngine;
using System.Collections;

public class shootLazer : MonoBehaviour {

	public GameObject lazer;
	public float bulletLifeTime = 4f;
	public float cooldownDelay = 2f;
	public float refreshRate = 1f;
	public float offset = 0.5f;
	public float maxRange = 5f;
	

	float offsetSum = 0f;


	void Start () {
		Invoke("InstanciateLazer", refreshRate);
	}
	void InstanciateLazer(){

		GameObject lazerInstance = (GameObject)Instantiate(	lazer, 
		            										new Vector3((transform.position.x + offsetSum),
		                            	 								transform.position.y,
		                           	  	 								transform.position.z ),
		           	 										Quaternion.identity);
		lazerInstance.transform.SetParent(this.transform);
		Destroy(lazerInstance, bulletLifeTime);

		offsetSum += offset;
		if(offsetSum > maxRange){
			Invoke("InstanciateLazer", cooldownDelay );
			offsetSum = 0f;
		}
		else
			Invoke("InstanciateLazer", refreshRate);
	}
}
