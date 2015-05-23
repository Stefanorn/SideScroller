using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	public float rotationSpeed = 10f;

	float rotationValue;
	// Update is called once per frame
	void FixedUpdate () {

		rotationValue += rotationSpeed*Time.deltaTime;
		if(rotationValue >= 360){
			rotationValue -= 360;
		}
		if(rotationValue <= -360){
			rotationValue += 360;
		}
		Debug.Log( rotationValue );

		transform.rotation = Quaternion.AngleAxis(rotationValue,Vector3.forward);
	}
}
