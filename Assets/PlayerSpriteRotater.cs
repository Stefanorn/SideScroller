using UnityEngine;
using System.Collections;

public class PlayerSpriteRotater : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if( Input.GetAxis("Horizontal") == 1 ){
			transform.rotation = Quaternion.Euler(0, 0,0);
		}
		if(Input.GetAxis("Horizontal") == -1 ) {
			transform.rotation = Quaternion.Euler(0, 180,0);
		}
	}
}
